using System;
using System.Collections.Generic;
using UnityEngine;

namespace PMExpert.Core
{
    /// <summary>
    /// 프로젝트 메트릭 관리 시스템
    /// Phase 1.5 - 모든 의사결정과 액션이 메트릭에 영향을 미침
    /// </summary>
    public class MetricManager : MonoBehaviour
    {
        public static MetricManager Instance { get; private set; }
        
        // 메트릭 저장소
        private Dictionary<MetricType, ProjectMetric> metrics = new Dictionary<MetricType, ProjectMetric>();
        
        // Events
        public event Action<MetricType, int, int> OnMetricChanged;  // (type, oldValue, newValue)
        public event Action<MetricType, MetricThreshold> OnThresholdCrossed;
        public event Action<string> OnCriticalWarning;
        
        // Configuration
        [SerializeField] private int defaultMinValue = 0;
        [SerializeField] private int defaultMaxValue = 100;
        
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                InitializeMetrics();
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        /// <summary>
        /// 메트릭 초기화
        /// </summary>
        private void InitializeMetrics()
        {
            // 기본 메트릭 생성
            CreateMetric(MetricType.Schedule, 50, "일정", "프로젝트 일정 준수율");
            CreateMetric(MetricType.Budget, 50, "예산", "예산 잔여율");
            CreateMetric(MetricType.Quality, 50, "품질", "제품 품질 수준");
            CreateMetric(MetricType.Scope, 50, "범위", "요구사항 완성도");
            CreateMetric(MetricType.TeamMorale, 50, "사기", "팀 사기 및 동기부여");
            CreateMetric(MetricType.Stakeholder, 50, "이해관계자", "이해관계자 만족도");
            CreateMetric(MetricType.Risk, 50, "리스크", "리스크 관리 수준");
            CreateMetric(MetricType.TechDebt, 20, "기술부채", "기술 부채 수준 (낮을수록 좋음)");
            
            Debug.Log($"[MetricManager] Initialized {metrics.Count} metrics");
        }
        
        /// <summary>
        /// 메트릭 생성
        /// </summary>
        private void CreateMetric(MetricType type, int initialValue, string displayName, string description)
        {
            metrics[type] = new ProjectMetric
            {
                type = type,
                value = initialValue,
                minValue = defaultMinValue,
                maxValue = defaultMaxValue,
                displayName = displayName,
                description = description,
                history = new List<MetricHistoryEntry>()
            };
        }
        
        /// <summary>
        /// 메트릭 수정
        /// </summary>
        public void ModifyMetric(MetricType type, int change)
        {
            if (!metrics.ContainsKey(type))
            {
                Debug.LogError($"[MetricManager] Metric not found: {type}");
                return;
            }
            
            ProjectMetric metric = metrics[type];
            int oldValue = metric.value;
            int newValue = Mathf.Clamp(oldValue + change, metric.minValue, metric.maxValue);
            
            metric.value = newValue;
            
            // 히스토리 기록
            metric.history.Add(new MetricHistoryEntry
            {
                day = TimeManager.Instance.GetCurrentTime().day,
                oldValue = oldValue,
                newValue = newValue,
                change = change,
                timestamp = DateTime.Now
            });
            
            Debug.Log($"[MetricManager] {type}: {oldValue} → {newValue} ({(change >= 0 ? "+" : "")}{change})");
            
            // 이벤트 발생
            OnMetricChanged?.Invoke(type, oldValue, newValue);
            
            // 임계값 체크
            CheckThresholds(type, oldValue, newValue);
        }
        
        /// <summary>
        /// 임계값 체크
        /// </summary>
        private void CheckThresholds(MetricType type, int oldValue, int newValue)
        {
            ProjectMetric metric = metrics[type];
            
            // Critical 임계값 (0-20)
            if (newValue <= 20 && oldValue > 20)
            {
                OnThresholdCrossed?.Invoke(type, MetricThreshold.Critical);
                OnCriticalWarning?.Invoke($"위험! {metric.displayName}이(가) 위험 수준입니다: {newValue}");
            }
            // Low 임계값 (21-40)
            else if (newValue <= 40 && oldValue > 40)
            {
                OnThresholdCrossed?.Invoke(type, MetricThreshold.Low);
            }
            // High 임계값 (80-100)
            else if (newValue >= 80 && oldValue < 80)
            {
                OnThresholdCrossed?.Invoke(type, MetricThreshold.High);
            }
        }
        
        /// <summary>
        /// 메트릭 값 가져오기
        /// </summary>
        public int GetMetricValue(MetricType type)
        {
            if (metrics.ContainsKey(type))
            {
                return metrics[type].value;
            }
            Debug.LogWarning($"[MetricManager] Metric not found: {type}");
            return 0;
        }
        
        /// <summary>
        /// 메트릭 정보 가져오기
        /// </summary>
        public ProjectMetric GetMetric(MetricType type)
        {
            if (metrics.ContainsKey(type))
            {
                return metrics[type];
            }
            return null;
        }
        
        /// <summary>
        /// 모든 메트릭 가져오기
        /// </summary>
        public Dictionary<MetricType, ProjectMetric> GetAllMetrics()
        {
            return new Dictionary<MetricType, ProjectMetric>(metrics);
        }
        
        /// <summary>
        /// 메트릭 리셋 (디버그/테스트용)
        /// </summary>
        public void ResetMetrics()
        {
            foreach (var metric in metrics.Values)
            {
                metric.value = 50;
                metric.history.Clear();
            }
            Debug.Log("[MetricManager] All metrics reset to 50");
        }
        
        /// <summary>
        /// 프로젝트 건강도 평가 (0-100)
        /// </summary>
        public int GetProjectHealth()
        {
            int total = 0;
            int count = 0;
            
            foreach (var metric in metrics.Values)
            {
                // 기술부채는 반대로 (낮을수록 좋음)
                if (metric.type == MetricType.TechDebt)
                {
                    total += (100 - metric.value);
                }
                else
                {
                    total += metric.value;
                }
                count++;
            }
            
            return count > 0 ? total / count : 0;
        }
    }
    
    /// <summary>
    /// 메트릭 타입
    /// </summary>
    public enum MetricType
    {
        Schedule,       // 일정
        Budget,         // 예산
        Quality,        // 품질
        Scope,          // 범위
        TeamMorale,     // 팀 사기
        Stakeholder,    // 이해관계자 만족도
        Risk,           // 리스크 관리
        TechDebt        // 기술 부채
    }
    
    /// <summary>
    /// 프로젝트 메트릭
    /// </summary>
    [System.Serializable]
    public class ProjectMetric
    {
        public MetricType type;
        public int value;
        public int minValue;
        public int maxValue;
        public string displayName;
        public string description;
        public List<MetricHistoryEntry> history;
    }
    
    /// <summary>
    /// 메트릭 히스토리 항목
    /// </summary>
    [System.Serializable]
    public class MetricHistoryEntry
    {
        public int day;
        public int oldValue;
        public int newValue;
        public int change;
        public DateTime timestamp;
    }
    
    /// <summary>
    /// 메트릭 임계값
    /// </summary>
    public enum MetricThreshold
    {
        Critical,   // 0-20
        Low,        // 21-40
        Normal,     // 41-79
        High        // 80-100
    }
}
