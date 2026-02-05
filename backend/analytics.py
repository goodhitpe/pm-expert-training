"""
PM Expert LMS - Learning Analytics System

목적: 학습 데이터 분석 및 인사이트 도출
기능:
  1. Drop-off 포인트 분석 (이탈률 높은 주차)
  2. 어려운 주차 식별 (평균 점수 낮은 주차)
  3. 주간 리포트 자동 생성
  4. CSV 내보내기
"""

import json
import csv
from datetime import datetime, timedelta
from collections import defaultdict
from typing import List, Dict, Tuple

class LearningAnalytics:
    """학습 분석 시스템"""
    
    def __init__(self, progress_file: str = 'mock-data/progress.json'):
        """
        Args:
            progress_file: 학습자 진행 데이터 JSON 파일 경로
        """
        with open(progress_file, 'r', encoding='utf-8') as f:
            self.progress_data = json.load(f)
    
    def find_drop_off_points(self, threshold: float = 30.0) -> Dict[int, float]:
        """
        이탈률이 높은 주차 식별
        
        Args:
            threshold: 이탈률 임계값 (기본 30%)
            
        Returns:
            {week_number: drop_off_rate} 딕셔너리
        """
        drop_off_points = {}
        
        for week in range(1, 17):
            # 해당 주차를 시작한 학습자 수
            started_week = sum(
                1 for p in self.progress_data 
                if p['currentWeek'] >= week
            )
            
            # 해당 주차를 완료한 학습자 수
            completed_week = sum(
                1 for p in self.progress_data 
                if week in p['completedWeeks']
            )
            
            if started_week > 0:
                drop_rate = ((started_week - completed_week) / started_week) * 100
                if drop_rate >= threshold:
                    drop_off_points[week] = round(drop_rate, 1)
        
        return drop_off_points
    
    def find_difficult_weeks(self, threshold: float = 70.0) -> Dict[int, Dict]:
        """
        어려운 주차 식별 (평균 퀴즈 점수가 낮은 주차)
        
        Args:
            threshold: 점수 임계값 (기본 70점)
            
        Returns:
            {week_number: {avg_score, student_count}} 딕셔너리
        """
        week_scores = defaultdict(list)
        
        # 주차별 퀴즈 점수 수집
        for progress in self.progress_data:
            quiz_scores = progress.get('weeklyQuizScores', {})
            for week_str, score in quiz_scores.items():
                week = int(week_str)
                week_scores[week].append(score)
        
        # 평균 계산 및 어려운 주차 식별
        difficult_weeks = {}
        for week, scores in week_scores.items():
            if scores:
                avg_score = sum(scores) / len(scores)
                if avg_score < threshold:
                    difficult_weeks[week] = {
                        'avg_score': round(avg_score, 1),
                        'student_count': len(scores),
                        'min_score': min(scores),
                        'max_score': max(scores)
                    }
        
        return difficult_weeks
    
    def calculate_retention_rate(self) -> List[Dict]:
        """
        주차별 잔류율 계산
        
        Returns:
            [{week, started, completed, retention_rate}] 리스트
        """
        retention_data = []
        
        for week in range(1, 17):
            started = sum(
                1 for p in self.progress_data 
                if p['currentWeek'] >= week
            )
            completed = sum(
                1 for p in self.progress_data 
                if week in p['completedWeeks']
            )
            
            retention_rate = (completed / started * 100) if started > 0 else 0
            
            retention_data.append({
                'week': week,
                'started': started,
                'completed': completed,
                'retention_rate': round(retention_rate, 1)
            })
        
        return retention_data
    
    def identify_at_risk_students(self) -> List[Dict]:
        """
        위험군 학습자 식별
        
        Returns:
            [{student_id, risk_score, risk_factors}] 리스트
        """
        at_risk = []
        
        for progress in self.progress_data:
            risk_score = 0
            risk_factors = []
            
            # 진행률 낮음
            if progress['overallProgress'] < 30:
                risk_score += 40
                risk_factors.append('매우 낮은 진행률')
            elif progress['overallProgress'] < 50:
                risk_score += 25
                risk_factors.append('낮은 진행률')
            
            # 최근 활동 없음
            last_active = datetime.fromisoformat(progress['lastActive'].replace('Z', '+00:00'))
            days_inactive = (datetime.now().astimezone() - last_active).days
            if days_inactive > 14:
                risk_score += 30
                risk_factors.append(f'{days_inactive}일 미접속')
            elif days_inactive > 7:
                risk_score += 15
                risk_factors.append(f'{days_inactive}일 미접속')
            
            # 퀴즈 점수 낮음
            avg_quiz = progress['avgQuizScore']
            if avg_quiz < 50:
                risk_score += 20
                risk_factors.append(f'낮은 퀴즈 점수 ({avg_quiz}점)')
            elif avg_quiz < 60:
                risk_score += 10
                risk_factors.append(f'퀴즈 점수 주의 ({avg_quiz}점)')
            
            # 연속 결석
            absences = progress['consecutiveAbsences']
            if absences > 5:
                risk_score += 30
                risk_factors.append(f'{absences}일 연속 결석')
            elif absences > 3:
                risk_score += 15
                risk_factors.append(f'{absences}일 연속 결석')
            
            if risk_score > 50:
                at_risk.append({
                    'student_id': progress['studentId'],
                    'risk_score': min(risk_score, 100),
                    'risk_factors': risk_factors,
                    'current_week': progress['currentWeek'],
                    'overall_progress': progress['overallProgress']
                })
        
        return sorted(at_risk, key=lambda x: x['risk_score'], reverse=True)
    
    def generate_weekly_report(self, week: int = None) -> Dict:
        """
        주간 리포트 생성
        
        Args:
            week: 주차 번호 (None이면 최신 주차)
            
        Returns:
            리포트 딕셔너리
        """
        if week is None:
            week = max(p['currentWeek'] for p in self.progress_data)
        
        # 해당 주차 통계
        week_progress = [
            p for p in self.progress_data 
            if p['currentWeek'] >= week
        ]
        
        completed_week = [
            p for p in self.progress_data 
            if week in p['completedWeeks']
        ]
        
        # 퀴즈 점수
        quiz_scores = [
            p['weeklyQuizScores'].get(str(week), 0) 
            for p in self.progress_data 
            if str(week) in p.get('weeklyQuizScores', {})
        ]
        
        report = {
            'week': week,
            'generated_at': datetime.now().isoformat(),
            'statistics': {
                'total_students': len(self.progress_data),
                'active_students': len(week_progress),
                'completed_students': len(completed_week),
                'completion_rate': round(len(completed_week) / len(week_progress) * 100, 1) if week_progress else 0,
                'avg_quiz_score': round(sum(quiz_scores) / len(quiz_scores), 1) if quiz_scores else 0,
                'quiz_count': len(quiz_scores)
            },
            'drop_off_points': self.find_drop_off_points(),
            'difficult_weeks': self.find_difficult_weeks(),
            'at_risk_students': self.identify_at_risk_students()
        }
        
        return report
    
    def export_to_csv(self, filename: str = 'analytics_report.csv'):
        """
        분석 결과를 CSV로 내보내기
        
        Args:
            filename: 출력 파일명
        """
        with open(filename, 'w', newline='', encoding='utf-8-sig') as f:
            writer = csv.writer(f)
            
            # 헤더
            writer.writerow([
                '학습자ID', '진행률(%)', '현재주차', '평균퀴즈점수',
                '총학습시간(분)', '최근접속일', '연속결석일', '위험도'
            ])
            
            # 데이터
            for progress in self.progress_data:
                risk_score = self.calculate_risk_score(progress)
                writer.writerow([
                    progress['studentId'],
                    progress['overallProgress'],
                    progress['currentWeek'],
                    progress['avgQuizScore'],
                    progress['totalTimeSpent'],
                    progress['lastActive'],
                    progress['consecutiveAbsences'],
                    risk_score
                ])
        
        print(f"✅ CSV 내보내기 완료: {filename}")
    
    def calculate_risk_score(self, progress: Dict) -> int:
        """위험도 점수 계산 (헬퍼 함수)"""
        score = 0
        
        if progress['overallProgress'] < 30:
            score += 40
        elif progress['overallProgress'] < 50:
            score += 25
        
        last_active = datetime.fromisoformat(progress['lastActive'].replace('Z', '+00:00'))
        days_inactive = (datetime.now().astimezone() - last_active).days
        if days_inactive > 14:
            score += 30
        elif days_inactive > 7:
            score += 15
        
        if progress['avgQuizScore'] < 50:
            score += 20
        elif progress['avgQuizScore'] < 60:
            score += 10
        
        if progress['consecutiveAbsences'] > 5:
            score += 30
        elif progress['consecutiveAbsences'] > 3:
            score += 15
        
        return min(score, 100)


def main():
    """메인 실행 함수"""
    print("=" * 60)
    print("📊 PM Expert LMS - Learning Analytics")
    print("=" * 60)
    
    analytics = LearningAnalytics()
    
    # 1. Drop-off 포인트 분석
    print("\n🔍 1. Drop-off 포인트 (이탈률 ≥ 30%)")
    drop_offs = analytics.find_drop_off_points()
    if drop_offs:
        for week, rate in sorted(drop_offs.items()):
            print(f"   Week {week}: {rate}% 이탈")
    else:
        print("   ✅ 높은 이탈률 없음")
    
    # 2. 어려운 주차 분석
    print("\n📉 2. 어려운 주차 (평균 점수 < 70점)")
    difficult = analytics.find_difficult_weeks()
    if difficult:
        for week, data in sorted(difficult.items()):
            print(f"   Week {week}: 평균 {data['avg_score']}점 ({data['student_count']}명)")
    else:
        print("   ✅ 모든 주차 난이도 적정")
    
    # 3. 잔류율 분석
    print("\n📈 3. 주차별 잔류율")
    retention = analytics.calculate_retention_rate()
    for data in retention[:5]:  # 처음 5주만 표시
        print(f"   Week {data['week']}: {data['retention_rate']}% ({data['completed']}/{data['started']}명)")
    print("   ...")
    
    # 4. 위험군 학습자
    print("\n⚠️  4. 위험군 학습자")
    at_risk = analytics.identify_at_risk_students()
    if at_risk:
        for student in at_risk:
            print(f"   {student['student_id']}: 위험도 {student['risk_score']}점")
            print(f"      - {', '.join(student['risk_factors'])}")
    else:
        print("   ✅ 위험군 학습자 없음")
    
    # 5. 주간 리포트 생성
    print("\n📝 5. 주간 리포트 생성")
    report = analytics.generate_weekly_report()
    print(f"   Week {report['week']} 리포트")
    print(f"   - 전체: {report['statistics']['total_students']}명")
    print(f"   - 활성: {report['statistics']['active_students']}명")
    print(f"   - 완료: {report['statistics']['completed_students']}명")
    print(f"   - 완료율: {report['statistics']['completion_rate']}%")
    print(f"   - 평균 퀴즈: {report['statistics']['avg_quiz_score']}점")
    
    # 6. CSV 내보내기
    print("\n💾 6. CSV 내보내기")
    analytics.export_to_csv('analytics_report.csv')
    
    print("\n" + "=" * 60)
    print("✅ 분석 완료!")
    print("=" * 60)


if __name__ == '__main__':
    main()
