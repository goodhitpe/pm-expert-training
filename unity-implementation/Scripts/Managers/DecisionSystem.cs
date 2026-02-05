using System;
using System.Collections.Generic;
using UnityEngine;

namespace PMExpert.Core
{
    /// <summary>
    /// Trade-off 기반 의사결정 시스템
    /// Phase 1.5 Week 1 - "정답" 제거, 모든 선택에 장단점
    /// </summary>
    public class DecisionSystem : MonoBehaviour
    {
        public static DecisionSystem Instance { get; private set; }
        
        // Events
        public event Action<Decision> OnDecisionPresented;
        public event Action<Decision, DecisionChoice> OnDecisionMade;
        public event Action<DecisionResult> OnDecisionResultShown;
        
        // Current Decision
        private Decision currentDecision = null;
        
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        /// <summary>
        /// 의사결정 제시
        /// </summary>
        public void PresentDecision(Decision decision)
        {
            if (decision == null)
            {
                Debug.LogError("[DecisionSystem] Cannot present null decision");
                return;
            }
            
            currentDecision = decision;
            Debug.Log($"[DecisionSystem] Presenting decision: {decision.title}");
            
            OnDecisionPresented?.Invoke(decision);
        }
        
        /// <summary>
        /// 플레이어가 선택 수행
        /// </summary>
        public void MakeChoice(int choiceIndex)
        {
            if (currentDecision == null)
            {
                Debug.LogError("[DecisionSystem] No current decision");
                return;
            }
            
            if (choiceIndex < 0 || choiceIndex >= currentDecision.choices.Count)
            {
                Debug.LogError($"[DecisionSystem] Invalid choice index: {choiceIndex}");
                return;
            }
            
            DecisionChoice choice = currentDecision.choices[choiceIndex];
            Debug.Log($"[DecisionSystem] Player chose: {choice.text}");
            
            // 이벤트 발생
            OnDecisionMade?.Invoke(currentDecision, choice);
            
            // 결과 적용
            ApplyDecisionResult(choice);
        }
        
        /// <summary>
        /// 의사결정 결과 적용
        /// </summary>
        private void ApplyDecisionResult(DecisionChoice choice)
        {
            DecisionResult result = new DecisionResult
            {
                decisionId = currentDecision.decisionId,
                choiceText = choice.text,
                metricChanges = new Dictionary<string, int>(),
                consequences = new List<string>()
            };
            
            // 메트릭 변화 적용
            foreach (var impact in choice.impacts)
            {
                MetricManager.Instance.ModifyMetric(impact.metricType, impact.change);
                result.metricChanges[impact.metricType.ToString()] = impact.change;
                
                // 변화 설명 추가
                string changeText = impact.change > 0 ? $"+{impact.change}" : impact.change.ToString();
                result.consequences.Add($"{impact.metricType}: {changeText}");
            }
            
            // 숨겨진 결과 (랜덤 또는 조건부)
            if (choice.hiddenImpacts != null && choice.hiddenImpacts.Count > 0)
            {
                foreach (var hiddenImpact in choice.hiddenImpacts)
                {
                    if (UnityEngine.Random.value < hiddenImpact.probability)
                    {
                        MetricManager.Instance.ModifyMetric(hiddenImpact.metricType, hiddenImpact.change);
                        result.consequences.Add($"[예상 밖] {hiddenImpact.metricType}: {hiddenImpact.change}");
                    }
                }
            }
            
            // 시간 소비
            if (choice.timeBlocksRequired > 0)
            {
                TimeManager.Instance.TryConsumeTimeBlocks(choice.timeBlocksRequired, currentDecision.title);
            }
            
            // 결과 UI 표시
            OnDecisionResultShown?.Invoke(result);
            
            Debug.Log($"[DecisionSystem] Decision result: {result.consequences.Count} consequences");
            
            // 의사결정 완료
            currentDecision = null;
        }
        
        /// <summary>
        /// 현재 의사결정 가져오기
        /// </summary>
        public Decision GetCurrentDecision()
        {
            return currentDecision;
        }
    }
    
    /// <summary>
    /// 의사결정 데이터
    /// </summary>
    [System.Serializable]
    public class Decision
    {
        public string decisionId;
        public string title;
        public string context;          // 상황 설명
        public string question;         // 질문
        public DecisionCategory category;
        public List<DecisionChoice> choices;
        public int difficultyLevel;     // 1-5
        public List<string> tags;
    }
    
    /// <summary>
    /// 의사결정 선택지
    /// </summary>
    [System.Serializable]
    public class DecisionChoice
    {
        public string text;             // 선택지 텍스트
        public string prosText;         // 장점 (예: "속도↑↑ 효율↑")
        public string consText;         // 단점 (예: "품질↓↓ 기술부채↑")
        
        // 메트릭 영향
        public List<MetricImpact> impacts;
        
        // 숨겨진 영향 (확률적)
        public List<HiddenImpact> hiddenImpacts;
        
        // 시간 소비
        public int timeBlocksRequired;
        
        // 선택지 해설 (결과 후 표시)
        public string explanation;
    }
    
    /// <summary>
    /// 메트릭 영향
    /// </summary>
    [System.Serializable]
    public class MetricImpact
    {
        public MetricType metricType;
        public int change;              // -100 ~ +100
        public string description;
    }
    
    /// <summary>
    /// 숨겨진 영향 (확률적)
    /// </summary>
    [System.Serializable]
    public class HiddenImpact
    {
        public MetricType metricType;
        public int change;
        public float probability;       // 0.0 ~ 1.0
        public string description;
    }
    
    /// <summary>
    /// 의사결정 카테고리
    /// </summary>
    public enum DecisionCategory
    {
        Scope,          // 범위 관리
        Schedule,       // 일정 관리
        Quality,        // 품질 관리
        Team,           // 팀 관리
        Stakeholder,    // 이해관계자 관리
        Risk,           // 리스크 관리
        Resource        // 자원 관리
    }
    
    /// <summary>
    /// 의사결정 결과
    /// </summary>
    [System.Serializable]
    public class DecisionResult
    {
        public string decisionId;
        public string choiceText;
        public Dictionary<string, int> metricChanges;
        public List<string> consequences;
    }
}
