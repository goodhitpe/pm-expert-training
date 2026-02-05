/**
 * PM Expert LMS - Backend API Server
 * 
 * 목적: 강사 대시보드 및 학습 분석을 위한 REST API 제공
 * 기술: Node.js + Express + Firebase
 */

const express = require('express');
const cors = require('cors');
const morgan = require('morgan');
require('dotenv').config();

const app = express();
const PORT = process.env.PORT || 3000;

// Middleware
app.use(cors());
app.use(express.json());
app.use(morgan('dev'));

// Firebase Admin 초기화
const admin = require('firebase-admin');

// 실제 운영 시 서비스 계정 키 사용
// const serviceAccount = require('./firebase-service-account.json');
// admin.initializeApp({
//   credential: admin.credential.cert(serviceAccount)
// });

// 개발 환경: Mock 데이터 사용
const db = {
  students: require('./mock-data/students.json'),
  progress: require('./mock-data/progress.json'),
  metrics: require('./mock-data/metrics.json')
};

// ==========================================
// API 엔드포인트
// ==========================================

/**
 * 1. 강사 대시보드 - 전체 현황
 * GET /api/instructor/dashboard
 */
app.get('/api/instructor/dashboard', (req, res) => {
  try {
    const students = db.students;
    const progress = db.progress;
    
    // 통계 계산
    const totalStudents = students.length;
    const avgProgress = Math.round(
      progress.reduce((sum, p) => sum + p.overallProgress, 0) / totalStudents
    );
    
    // 위험군 자동 식별
    const atRisk = students.filter(s => {
      const studentProgress = progress.find(p => p.studentId === s.id);
      return (
        studentProgress.overallProgress < 50 ||
        (Date.now() - new Date(studentProgress.lastActive)) > 7 * 24 * 60 * 60 * 1000 ||
        studentProgress.avgQuizScore < 60
      );
    }).length;
    
    // 주간 통계
    const weeklyStats = calculateWeeklyStats(progress);
    
    // 최근 활동
    const recentActivity = progress
      .sort((a, b) => new Date(b.lastActive) - new Date(a.lastActive))
      .slice(0, 10)
      .map(p => ({
        studentId: p.studentId,
        studentName: students.find(s => s.id === p.studentId)?.name,
        lastActive: p.lastActive,
        currentWeek: p.currentWeek,
        recentAction: p.recentAction
      }));
    
    res.json({
      success: true,
      data: {
        totalStudents,
        atRisk,
        avgProgress,
        activeToday: students.filter(s => {
          const p = progress.find(pr => pr.studentId === s.id);
          return isToday(p.lastActive);
        }).length,
        weeklyStats,
        recentActivity
      }
    });
  } catch (error) {
    console.error('Dashboard error:', error);
    res.status(500).json({ success: false, error: error.message });
  }
});

/**
 * 2. 개별 학습자 상세 정보
 * GET /api/instructor/students/:id
 */
app.get('/api/instructor/students/:id', (req, res) => {
  try {
    const studentId = req.params.id;
    const student = db.students.find(s => s.id === studentId);
    
    if (!student) {
      return res.status(404).json({ success: false, error: 'Student not found' });
    }
    
    const studentProgress = db.progress.find(p => p.studentId === studentId);
    const studentMetrics = db.metrics.filter(m => m.studentId === studentId);
    
    // 위험 알림 생성
    const alerts = generateAlerts(studentProgress, studentMetrics);
    
    res.json({
      success: true,
      data: {
        student,
        progress: studentProgress,
        metrics: studentMetrics,
        alerts,
        recommendations: generateRecommendations(studentProgress, alerts)
      }
    });
  } catch (error) {
    console.error('Student detail error:', error);
    res.status(500).json({ success: false, error: error.message });
  }
});

/**
 * 3. 위험군 학습자 목록
 * GET /api/instructor/at-risk
 */
app.get('/api/instructor/at-risk', (req, res) => {
  try {
    const atRiskStudents = db.students
      .map(student => {
        const progress = db.progress.find(p => p.studentId === student.id);
        const riskScore = calculateRiskScore(progress);
        const riskFactors = identifyRiskFactors(progress);
        
        return {
          ...student,
          progress: progress.overallProgress,
          lastActive: progress.lastActive,
          riskScore,
          riskFactors
        };
      })
      .filter(s => s.riskScore > 50)
      .sort((a, b) => b.riskScore - a.riskScore);
    
    res.json({
      success: true,
      data: atRiskStudents
    });
  } catch (error) {
    console.error('At-risk error:', error);
    res.status(500).json({ success: false, error: error.message });
  }
});

/**
 * 4. 주차별 통계
 * GET /api/instructor/weeks/:weekNumber
 */
app.get('/api/instructor/weeks/:weekNumber', (req, res) => {
  try {
    const weekNumber = parseInt(req.params.weekNumber);
    
    const weekStats = db.progress
      .filter(p => p.currentWeek === weekNumber)
      .map(p => {
        const student = db.students.find(s => s.id === p.studentId);
        return {
          studentId: p.studentId,
          studentName: student?.name,
          weekProgress: p.weeklyProgress[weekNumber] || 0,
          quizScore: p.weeklyQuizScores[weekNumber] || null,
          timeSpent: p.weeklyTimeSpent[weekNumber] || 0,
          completed: p.completedWeeks.includes(weekNumber)
        };
      });
    
    const summary = {
      weekNumber,
      totalStudents: weekStats.length,
      completed: weekStats.filter(s => s.completed).length,
      avgQuizScore: Math.round(
        weekStats.reduce((sum, s) => sum + (s.quizScore || 0), 0) / weekStats.length
      ),
      avgTimeSpent: Math.round(
        weekStats.reduce((sum, s) => sum + s.timeSpent, 0) / weekStats.length
      ),
      dropOffRate: calculateDropOffRate(weekNumber, db.progress)
    };
    
    res.json({
      success: true,
      data: {
        summary,
        students: weekStats
      }
    });
  } catch (error) {
    console.error('Week stats error:', error);
    res.status(500).json({ success: false, error: error.message });
  }
});

/**
 * 5. 메시지 전송 (위험군 알림)
 * POST /api/instructor/send-message
 */
app.post('/api/instructor/send-message', (req, res) => {
  try {
    const { studentIds, message, type } = req.body;
    
    // 실제로는 이메일 또는 알림 전송
    // 여기서는 로그만 남김
    console.log(`Sending ${type} message to ${studentIds.length} students:`, message);
    
    // Mock 응답
    const results = studentIds.map(id => ({
      studentId: id,
      sent: true,
      timestamp: new Date().toISOString()
    }));
    
    res.json({
      success: true,
      data: {
        sent: results.length,
        failed: 0,
        results
      }
    });
  } catch (error) {
    console.error('Send message error:', error);
    res.status(500).json({ success: false, error: error.message });
  }
});

// ==========================================
// 헬퍼 함수
// ==========================================

function calculateWeeklyStats(progress) {
  const stats = [];
  for (let week = 1; week <= 16; week++) {
    const studentsInWeek = progress.filter(p => p.currentWeek >= week);
    const completedWeek = progress.filter(p => p.completedWeeks.includes(week));
    
    stats.push({
      week,
      enrolled: studentsInWeek.length,
      completed: completedWeek.length,
      completionRate: Math.round((completedWeek.length / studentsInWeek.length) * 100) || 0
    });
  }
  return stats;
}

function calculateRiskScore(progress) {
  let score = 0;
  
  // 진행률 낮음 (0-50)
  if (progress.overallProgress < 30) score += 40;
  else if (progress.overallProgress < 50) score += 25;
  
  // 최근 활동 없음
  const daysSinceActive = (Date.now() - new Date(progress.lastActive)) / (24 * 60 * 60 * 1000);
  if (daysSinceActive > 14) score += 30;
  else if (daysSinceActive > 7) score += 15;
  
  // 퀴즈 점수 낮음
  if (progress.avgQuizScore < 50) score += 20;
  else if (progress.avgQuizScore < 60) score += 10;
  
  // 연속 결석
  if (progress.consecutiveAbsences > 5) score += 30;
  else if (progress.consecutiveAbsences > 3) score += 15;
  
  return Math.min(score, 100);
}

function identifyRiskFactors(progress) {
  const factors = [];
  
  if (progress.overallProgress < 50) {
    factors.push({ type: 'low_progress', severity: 'high', message: '진행률 50% 미만' });
  }
  
  const daysSinceActive = (Date.now() - new Date(progress.lastActive)) / (24 * 60 * 60 * 1000);
  if (daysSinceActive > 7) {
    factors.push({ type: 'inactive', severity: 'high', message: `${Math.round(daysSinceActive)}일간 미접속` });
  }
  
  if (progress.avgQuizScore < 60) {
    factors.push({ type: 'low_quiz_score', severity: 'medium', message: `평균 퀴즈 점수 ${progress.avgQuizScore}점` });
  }
  
  if (progress.consecutiveAbsences > 3) {
    factors.push({ type: 'absence', severity: 'high', message: `${progress.consecutiveAbsences}일 연속 결석` });
  }
  
  return factors;
}

function generateAlerts(progress, metrics) {
  const alerts = [];
  const riskFactors = identifyRiskFactors(progress);
  
  riskFactors.forEach(factor => {
    alerts.push({
      type: 'warning',
      title: factor.message,
      severity: factor.severity,
      timestamp: new Date().toISOString()
    });
  });
  
  return alerts;
}

function generateRecommendations(progress, alerts) {
  const recommendations = [];
  
  if (progress.overallProgress < 50) {
    recommendations.push({
      type: 'intervention',
      message: '1:1 면담 또는 추가 학습 자료 제공 권장',
      priority: 'high'
    });
  }
  
  if (progress.avgQuizScore < 60) {
    recommendations.push({
      type: 'content',
      message: '복습 자료 또는 추가 연습 문제 제공',
      priority: 'medium'
    });
  }
  
  const daysSinceActive = (Date.now() - new Date(progress.lastActive)) / (24 * 60 * 60 * 1000);
  if (daysSinceActive > 7) {
    recommendations.push({
      type: 'engagement',
      message: '이메일 또는 메시지로 학습 독려',
      priority: 'high'
    });
  }
  
  return recommendations;
}

function calculateDropOffRate(weekNumber, allProgress) {
  const startedWeek = allProgress.filter(p => p.currentWeek >= weekNumber - 1).length;
  const completedWeek = allProgress.filter(p => p.completedWeeks.includes(weekNumber)).length;
  
  if (startedWeek === 0) return 0;
  return Math.round((1 - completedWeek / startedWeek) * 100);
}

function isToday(dateString) {
  const date = new Date(dateString);
  const today = new Date();
  return date.toDateString() === today.toDateString();
}

// ==========================================
// 서버 시작
// ==========================================

app.listen(PORT, () => {
  console.log(`🚀 PM Expert LMS Backend Server`);
  console.log(`📡 Server running on port ${PORT}`);
  console.log(`🌐 API: http://localhost:${PORT}`);
  console.log(`📊 Dashboard: http://localhost:${PORT}/api/instructor/dashboard`);
});

module.exports = app;
