/**
 * Q&A Board Backend API
 * Phase 1.5 Week 4 - Q&A 게시판 백엔드
 * 
 * 기능:
 * - 질문/답변 CRUD
 * - 주차별 필터링
 * - 검색 및 정렬
 * - 투표 시스템
 */

const express = require('express');
const cors = require('cors');
const fs = require('fs');
const path = require('path');

const app = express();
const PORT = process.env.QA_PORT || 3001;

// Middleware
app.use(cors());
app.use(express.json());

// Mock 데이터 로드
let qaData = require('./mock-data/qa-data.json');

// ==================== API Endpoints ====================

/**
 * GET /api/qa/questions
 * 질문 목록 조회
 * 
 * Query Parameters:
 * - week: 주차 필터 (1-16)
 * - category: 카테고리 필터 (technical, theoretical, practical, other)
 * - status: 상태 필터 (unanswered, answered, resolved)
 * - sort: 정렬 (latest, popular, unanswered)
 * - page: 페이지 번호 (기본: 1)
 * - limit: 페이지당 개수 (기본: 10)
 * - search: 검색어 (제목, 내용)
 */
app.get('/api/qa/questions', (req, res) => {
    try {
        let questions = [...qaData.questions];
        
        // 필터링
        if (req.query.week) {
            const week = parseInt(req.query.week);
            questions = questions.filter(q => q.week === week);
        }
        
        if (req.query.category) {
            questions = questions.filter(q => q.category === req.query.category);
        }
        
        if (req.query.status) {
            questions = questions.filter(q => q.status === req.query.status);
        }
        
        // 검색
        if (req.query.search) {
            const search = req.query.search.toLowerCase();
            questions = questions.filter(q => 
                q.title.toLowerCase().includes(search) ||
                q.content.toLowerCase().includes(search)
            );
        }
        
        // 정렬
        const sort = req.query.sort || 'latest';
        if (sort === 'latest') {
            questions.sort((a, b) => new Date(b.createdAt) - new Date(a.createdAt));
        } else if (sort === 'popular') {
            questions.sort((a, b) => b.votes - a.votes);
        } else if (sort === 'unanswered') {
            questions = questions.filter(q => q.status === 'unanswered');
            questions.sort((a, b) => new Date(b.createdAt) - new Date(a.createdAt));
        }
        
        // 페이지네이션
        const page = parseInt(req.query.page) || 1;
        const limit = parseInt(req.query.limit) || 10;
        const startIndex = (page - 1) * limit;
        const endIndex = startIndex + limit;
        
        const paginatedQuestions = questions.slice(startIndex, endIndex);
        
        res.json({
            questions: paginatedQuestions,
            pagination: {
                currentPage: page,
                totalPages: Math.ceil(questions.length / limit),
                totalItems: questions.length,
                itemsPerPage: limit
            }
        });
        
    } catch (error) {
        console.error('질문 목록 조회 오류:', error);
        res.status(500).json({ error: '서버 오류가 발생했습니다.' });
    }
});

/**
 * GET /api/qa/questions/:id
 * 질문 상세 조회
 * 
 * 기능:
 * - 질문 정보
 * - 답변 목록
 * - 조회수 자동 증가
 */
app.get('/api/qa/questions/:id', (req, res) => {
    try {
        const questionId = req.params.id;
        const question = qaData.questions.find(q => q.id === questionId);
        
        if (!question) {
            return res.status(404).json({ error: '질문을 찾을 수 없습니다.' });
        }
        
        // 조회수 증가
        question.views++;
        
        // 답변 조회
        const answers = qaData.answers.filter(a => a.questionId === questionId);
        
        res.json({
            question,
            answers
        });
        
    } catch (error) {
        console.error('질문 상세 조회 오류:', error);
        res.status(500).json({ error: '서버 오류가 발생했습니다.' });
    }
});

/**
 * POST /api/qa/questions
 * 질문 작성
 * 
 * Body:
 * - studentId: 학습자 ID
 * - week: 주차 (1-16)
 * - category: 카테고리
 * - title: 제목
 * - content: 내용
 */
app.post('/api/qa/questions', (req, res) => {
    try {
        const { studentId, week, category, title, content } = req.body;
        
        // 유효성 검사
        if (!studentId || !week || !category || !title || !content) {
            return res.status(400).json({ error: '필수 필드가 누락되었습니다.' });
        }
        
        if (week < 1 || week > 16) {
            return res.status(400).json({ error: '유효하지 않은 주차입니다.' });
        }
        
        const validCategories = ['technical', 'theoretical', 'practical', 'other'];
        if (!validCategories.includes(category)) {
            return res.status(400).json({ error: '유효하지 않은 카테고리입니다.' });
        }
        
        // 새 질문 생성
        const newQuestion = {
            id: `Q${String(qaData.questions.length + 1).padStart(3, '0')}`,
            studentId,
            week,
            category,
            title,
            content,
            status: 'unanswered',
            votes: 0,
            views: 0,
            createdAt: new Date().toISOString()
        };
        
        qaData.questions.push(newQuestion);
        
        res.status(201).json({
            message: '질문이 작성되었습니다.',
            question: newQuestion
        });
        
    } catch (error) {
        console.error('질문 작성 오류:', error);
        res.status(500).json({ error: '서버 오류가 발생했습니다.' });
    }
});

/**
 * POST /api/qa/answers
 * 답변 작성
 * 
 * Body:
 * - questionId: 질문 ID
 * - authorId: 작성자 ID (학습자 또는 강사)
 * - authorType: 작성자 유형 (student, instructor)
 * - content: 답변 내용
 */
app.post('/api/qa/answers', (req, res) => {
    try {
        const { questionId, authorId, authorType, content } = req.body;
        
        // 유효성 검사
        if (!questionId || !authorId || !authorType || !content) {
            return res.status(400).json({ error: '필수 필드가 누락되었습니다.' });
        }
        
        const question = qaData.questions.find(q => q.id === questionId);
        if (!question) {
            return res.status(404).json({ error: '질문을 찾을 수 없습니다.' });
        }
        
        // 새 답변 생성
        const newAnswer = {
            id: `A${String(qaData.answers.length + 1).padStart(3, '0')}`,
            questionId,
            authorId,
            authorType,
            content,
            votes: 0,
            createdAt: new Date().toISOString()
        };
        
        qaData.answers.push(newAnswer);
        
        // 질문 상태 업데이트
        if (question.status === 'unanswered') {
            question.status = 'answered';
        }
        
        res.status(201).json({
            message: '답변이 작성되었습니다.',
            answer: newAnswer
        });
        
    } catch (error) {
        console.error('답변 작성 오류:', error);
        res.status(500).json({ error: '서버 오류가 발생했습니다.' });
    }
});

/**
 * POST /api/qa/votes
 * 투표 (추천/비추천)
 * 
 * Body:
 * - targetId: 대상 ID (질문 또는 답변)
 * - targetType: 대상 유형 (question, answer)
 * - voteType: 투표 유형 (upvote, downvote)
 * - userId: 사용자 ID
 */
app.post('/api/qa/votes', (req, res) => {
    try {
        const { targetId, targetType, voteType, userId } = req.body;
        
        // 유효성 검사
        if (!targetId || !targetType || !voteType || !userId) {
            return res.status(400).json({ error: '필수 필드가 누락되었습니다.' });
        }
        
        let target;
        if (targetType === 'question') {
            target = qaData.questions.find(q => q.id === targetId);
        } else if (targetType === 'answer') {
            target = qaData.answers.find(a => a.id === targetId);
        }
        
        if (!target) {
            return res.status(404).json({ error: '대상을 찾을 수 없습니다.' });
        }
        
        // 투표 처리
        if (voteType === 'upvote') {
            target.votes++;
        } else if (voteType === 'downvote') {
            target.votes--;
        }
        
        res.json({
            message: '투표가 반영되었습니다.',
            votes: target.votes
        });
        
    } catch (error) {
        console.error('투표 처리 오류:', error);
        res.status(500).json({ error: '서버 오류가 발생했습니다.' });
    }
});

/**
 * PUT /api/qa/questions/:id/status
 * 질문 상태 변경 (해결됨으로 표시)
 * 
 * Body:
 * - status: 새로운 상태 (answered, resolved)
 */
app.put('/api/qa/questions/:id/status', (req, res) => {
    try {
        const questionId = req.params.id;
        const { status } = req.body;
        
        const question = qaData.questions.find(q => q.id === questionId);
        if (!question) {
            return res.status(404).json({ error: '질문을 찾을 수 없습니다.' });
        }
        
        const validStatuses = ['unanswered', 'answered', 'resolved'];
        if (!validStatuses.includes(status)) {
            return res.status(400).json({ error: '유효하지 않은 상태입니다.' });
        }
        
        question.status = status;
        
        res.json({
            message: '질문 상태가 변경되었습니다.',
            question
        });
        
    } catch (error) {
        console.error('상태 변경 오류:', error);
        res.status(500).json({ error: '서버 오류가 발생했습니다.' });
    }
});

// ==================== 서버 시작 ====================

app.listen(PORT, () => {
    console.log(`\n🎓 Q&A Board API Server 실행 중`);
    console.log(`포트: ${PORT}`);
    console.log(`URL: http://localhost:${PORT}`);
    console.log(`\n사용 가능한 엔드포인트:`);
    console.log(`  GET  /api/qa/questions        - 질문 목록`);
    console.log(`  GET  /api/qa/questions/:id    - 질문 상세`);
    console.log(`  POST /api/qa/questions        - 질문 작성`);
    console.log(`  POST /api/qa/answers          - 답변 작성`);
    console.log(`  POST /api/qa/votes            - 투표`);
    console.log(`  PUT  /api/qa/questions/:id/status - 상태 변경`);
    console.log(`\n예제:`);
    console.log(`  curl http://localhost:${PORT}/api/qa/questions`);
    console.log(`  curl http://localhost:${PORT}/api/qa/questions?week=5`);
    console.log(`  curl http://localhost:${PORT}/api/qa/questions/Q001\n`);
});

module.exports = app;
