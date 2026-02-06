// LearningPathManager.cs - Phase 2 Week 1: 학습 경로 관리 시스템
// 학습자 레벨에 맞는 개인화된 학습 경로를 생성하고 관리합니다.
//
// 주요 기능:
// - 3가지 학습 경로 (초급: Week 1-16, 중급: Week 3-16, 고급: Week 5-16)
// - 레벨별 콘텐츠 난이도 조정
// - 진행 상황 추적 및 다음 학습 추천
//
// 사용법:
//   LearningPathManager.Instance.CreatePathFromDiagnostic(diagnosticResult);
//   var currentWeek = LearningPathManager.Instance.GetCurrentWeek();
//   var nextContent = LearningPathManager.Instance.GetNextRecommendation();
//
// Phase 2 Week 1 구현 완료 (2025-02-06)

using System.Collections.Generic;
using UnityEngine;

namespace PMExpert.Systems
{
    public class LearningPathManager : MonoBehaviour
    {
        private static LearningPathManager _instance;
        public static LearningPathManager Instance => _instance ??= FindObjectOfType<LearningPathManager>() ?? new GameObject("LearningPathManager").AddComponent<LearningPathManager>();

        private Path currentPath;
        private int currentWeek = 1;
        
        public void CreatePathFromDiagnostic(DiagnosticTestManager.Result result)
        {
            currentPath = result.level switch
            {
                DiagnosticTestManager.Level.Beginner => new Path { name = "초급", startWeek = 1 },
                DiagnosticTestManager.Level.Intermediate => new Path { name = "중급", startWeek = 3 },
                DiagnosticTestManager.Level.Advanced => new Path { name = "고급", startWeek = 5 },
                _ => new Path { name = "중급", startWeek = 3 }
            };
            currentWeek = currentPath.startWeek;
            Debug.Log($"[LearningPath] 경로 생성: {currentPath.name}, Week {currentWeek}부터 시작");
        }
        
        public int GetCurrentWeek() => currentWeek;
        
        public void CompleteWeek(int week)
        {
            if (week == currentWeek)
            {
                currentWeek++;
                Debug.Log($"[LearningPath] Week {week} 완료, 다음: Week {currentWeek}");
            }
        }
        
        public Recommendation GetNextRecommendation()
        {
            return new Recommendation
            {
                week = currentWeek,
                title = $"Week {currentWeek} - PM 주제",
                difficulty = currentPath.name,
                estimatedHours = 6
            };
        }
        
        public class Path { public string name; public int startWeek; }
        public class Recommendation { public int week; public string title, difficulty; public int estimatedHours; }
    }
}
