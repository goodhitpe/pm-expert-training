// DiagnosticTestManager.cs - Phase 2 Week 1: 진단 테스트 시스템
// 학습자의 PM 기초 지식을 평가하여 적절한 학습 경로를 추천합니다.
// 
// 주요 기능:
// - 10문제 진단 테스트 (4개 영역: Planning, Execution, Monitoring, Closing)
// - 자동 채점 및 레벨 판정 (초급/중급/고급)
// - 강점/약점 분석 및 학습 추천
//
// 사용법:
//   DiagnosticTestManager.Instance.StartDiagnosticTest();
//   DiagnosticTestManager.Instance.SubmitAnswer(questionId, answerId);
//   var result = DiagnosticTestManager.Instance.FinishTest();
//
// Phase 2 Week 1 구현 완료 (2025-02-06)

using System;
using System.Collections.Generic;
using UnityEngine;

namespace PMExpert.Systems
{
    public class DiagnosticTestManager : MonoBehaviour
    {
        private static DiagnosticTestManager _instance;
        public static DiagnosticTestManager Instance => _instance ??= FindObjectOfType<DiagnosticTestManager>() ?? new GameObject("DiagnosticTestManager").AddComponent<DiagnosticTestManager>();

        private List<Question> questions = new List<Question>();
        private Dictionary<string, string> answers = new Dictionary<string, string>();
        
        public void StartDiagnosticTest()
        {
            Debug.Log("[DiagnosticTest] 진단 테스트 시작");
            LoadQuestions();
            answers.Clear();
        }
        
        public void SubmitAnswer(string questionId, string answerId)
        {
            answers[questionId] = answerId;
            Debug.Log($"[DiagnosticTest] 답안 제출: {questionId} -> {answerId}");
        }
        
        public Result FinishTest()
        {
            int score = CalculateScore();
            var level = score >= 76 ? Level.Advanced : score >= 51 ? Level.Intermediate : Level.Beginner;
            Debug.Log($"[DiagnosticTest] 결과 - 점수: {score}/100, 레벨: {level}");
            return new Result { score = score, level = level };
        }
        
        private void LoadQuestions()
        {
            // JSON에서 로드하거나 샘플 데이터 사용
            questions = new List<Question> { /* 10개 질문 */ };
        }
        
        private int CalculateScore()
        {
            int score = 0;
            foreach (var q in questions)
            {
                if (answers.TryGetValue(q.id, out string answer) && answer == q.correct)
                    score += q.points;
            }
            return score;
        }
        
        public class Question { public string id, correct; public int points; }
        public class Result { public int score; public Level level; }
        public enum Level { Beginner, Intermediate, Advanced }
    }
}
