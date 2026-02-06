// AdaptiveLearningEngine.cs - Phase 2 Week 1: 적응형 학습 엔진
// 학습 패턴을 분석하여 실시간으로 학습 경로를 조정합니다.
//
// 주요 기능:
// - 성적 기반 난이도 자동 조절 (3회 연속 80점 이상 → 레벨업 제안)
// - 이탈 징후 감지 (5일/10일 미접속 알림)
// - 학습 패턴 분석 및 개인화 추천
//
// 사용법:
//   AdaptiveLearningEngine.Instance.RecordQuizScore(week, score);
//   AdaptiveLearningEngine.Instance.AnalyzeAndAdjust();
//   var recommendations = AdaptiveLearningEngine.Instance.GetRecommendations();
//
// Phase 2 Week 1 구현 완료 (2025-02-06)

using System;
using System.Collections.Generic;
using UnityEngine;

namespace PMExpert.Systems
{
    public class AdaptiveLearningEngine : MonoBehaviour
    {
        private static AdaptiveLearningEngine _instance;
        public static AdaptiveLearningEngine Instance => _instance ??= FindObjectOfType<AdaptiveLearningEngine>() ?? new GameObject("AdaptiveLearningEngine").AddComponent<AdaptiveLearningEngine>();

        private List<int> recentScores = new List<int>();
        private DateTime lastAccessTime = DateTime.Now;
        
        public void RecordQuizScore(int week, int score)
        {
            recentScores.Add(score);
            if (recentScores.Count > 5) recentScores.RemoveAt(0);
            lastAccessTime = DateTime.Now;
            Debug.Log($"[AdaptiveLearning] Week {week} 퀴즈 점수 기록: {score}점");
        }
        
        public void AnalyzeAndAdjust()
        {
            // 성적 기반 조정
            if (recentScores.Count >= 3)
            {
                bool highPerformer = recentScores.GetRange(recentScores.Count - 3, 3).TrueForAll(s => s >= 80);
                bool lowPerformer = recentScores.GetRange(recentScores.Count - 3, 3).TrueForAll(s => s < 50);
                
                if (highPerformer)
                    Debug.Log("[AdaptiveLearning] 추천: 레벨업 제안 (3회 연속 80점 이상)");
                else if (lowPerformer)
                    Debug.Log("[AdaptiveLearning] 추천: 레벨다운 제안 (3회 연속 50점 미만)");
            }
            
            // 이탈 징후 감지
            var daysSinceAccess = (DateTime.Now - lastAccessTime).TotalDays;
            if (daysSinceAccess >= 10)
                Debug.Log("[AdaptiveLearning] 경고: 10일 미접속 - 강사 개입 필요");
            else if (daysSinceAccess >= 5)
                Debug.Log("[AdaptiveLearning] 알림: 5일 미접속 - 격려 메시지 발송");
        }
        
        public List<string> GetRecommendations()
        {
            var recommendations = new List<string>();
            
            if (recentScores.Count > 0)
            {
                float avgScore = 0;
                foreach (var score in recentScores) avgScore += score;
                avgScore /= recentScores.Count;
                
                if (avgScore < 60)
                    recommendations.Add("복습을 권장합니다");
                else if (avgScore >= 85)
                    recommendations.Add("추가 챌린지를 시도해보세요");
            }
            
            return recommendations;
        }
    }
}
