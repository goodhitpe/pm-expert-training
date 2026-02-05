using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PMExpert.Core
{
    /// <summary>
    /// 동시다발 이벤트 관리 시스템
    /// Phase 1.5 Week 1 - 게임 루프의 핵심 요소
    /// </summary>
    public class EventManager : MonoBehaviour
    {
        public static EventManager Instance { get; private set; }
        
        // Event Queue
        private Queue<GameEvent> pendingEvents = new Queue<GameEvent>();
        private List<GameEvent> simultaneousEvents = new List<GameEvent>();
        private GameEvent currentEvent = null;
        
        // Configuration
        [SerializeField] private int maxSimultaneousEvents = 3;
        
        // Events
        public event Action<GameEvent> OnEventTriggered;
        public event Action<GameEvent> OnEventCompleted;
        public event Action<List<GameEvent>> OnMultipleEventsTriggered;
        public event Action OnAllEventsCleared;
        
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
        /// 단일 이벤트 트리거
        /// </summary>
        public void TriggerEvent(GameEvent evt)
        {
            if (evt == null)
            {
                Debug.LogError("[EventManager] Cannot trigger null event");
                return;
            }
            
            Debug.Log($"[EventManager] Event triggered: {evt.eventName} (Priority: {evt.priority})");
            
            pendingEvents.Enqueue(evt);
            OnEventTriggered?.Invoke(evt);
            
            CheckEventQueue();
        }
        
        /// <summary>
        /// 동시다발 이벤트 트리거 (플레이어가 우선순위 결정 필요)
        /// </summary>
        public void TriggerMultipleEvents(params GameEvent[] events)
        {
            if (events == null || events.Length == 0)
            {
                Debug.LogWarning("[EventManager] No events to trigger");
                return;
            }
            
            Debug.Log($"[EventManager] Multiple events triggered: {events.Length} events");
            
            simultaneousEvents.Clear();
            simultaneousEvents.AddRange(events);
            
            OnMultipleEventsTriggered?.Invoke(simultaneousEvents);
            
            // UI에서 플레이어가 우선순위를 결정하도록 함
            ShowEventPriorityUI();
        }
        
        /// <summary>
        /// 이벤트 우선순위 선택 UI 표시
        /// </summary>
        private void ShowEventPriorityUI()
        {
            // UI Manager에게 전달
            Debug.Log("[EventManager] Showing event priority selection UI");
            // UIManager.Instance.ShowEventPrioritySelection(simultaneousEvents);
        }
        
        /// <summary>
        /// 플레이어가 선택한 순서대로 이벤트 큐에 추가
        /// </summary>
        public void SetEventPriority(List<GameEvent> orderedEvents)
        {
            foreach (var evt in orderedEvents)
            {
                pendingEvents.Enqueue(evt);
            }
            
            simultaneousEvents.Clear();
            CheckEventQueue();
        }
        
        /// <summary>
        /// 이벤트 큐 체크 및 다음 이벤트 시작
        /// </summary>
        private void CheckEventQueue()
        {
            if (currentEvent != null)
            {
                Debug.Log("[EventManager] Current event still active, waiting...");
                return;
            }
            
            if (pendingEvents.Count > 0)
            {
                currentEvent = pendingEvents.Dequeue();
                StartEvent(currentEvent);
            }
            else if (simultaneousEvents.Count == 0)
            {
                Debug.Log("[EventManager] All events cleared");
                OnAllEventsCleared?.Invoke();
            }
        }
        
        /// <summary>
        /// 이벤트 시작
        /// </summary>
        private void StartEvent(GameEvent evt)
        {
            Debug.Log($"[EventManager] Starting event: {evt.eventName}");
            
            // UI Manager에 이벤트 표시 요청
            // UIManager.Instance.ShowEvent(evt);
            
            // 시간 소비
            if (evt.timeBlocksRequired > 0)
            {
                TimeManager.Instance.TryConsumeTimeBlocks(evt.timeBlocksRequired, evt.eventName);
            }
        }
        
        /// <summary>
        /// 이벤트 완료
        /// </summary>
        public void CompleteEvent(GameEvent evt)
        {
            if (currentEvent != null && currentEvent.eventId == evt.eventId)
            {
                Debug.Log($"[EventManager] Event completed: {evt.eventName}");
                
                OnEventCompleted?.Invoke(evt);
                currentEvent = null;
                
                CheckEventQueue();
            }
            else
            {
                Debug.LogWarning($"[EventManager] Trying to complete event that's not current: {evt.eventName}");
            }
        }
        
        /// <summary>
        /// 이벤트 취소
        /// </summary>
        public void CancelEvent(GameEvent evt)
        {
            if (currentEvent != null && currentEvent.eventId == evt.eventId)
            {
                Debug.Log($"[EventManager] Event cancelled: {evt.eventName}");
                currentEvent = null;
                CheckEventQueue();
            }
        }
        
        /// <summary>
        /// 대기 중인 이벤트 수
        /// </summary>
        public int GetPendingEventCount()
        {
            return pendingEvents.Count + simultaneousEvents.Count;
        }
        
        /// <summary>
        /// 현재 이벤트 가져오기
        /// </summary>
        public GameEvent GetCurrentEvent()
        {
            return currentEvent;
        }
        
        /// <summary>
        /// 대기 중인 이벤트 목록
        /// </summary>
        public List<GameEvent> GetPendingEvents()
        {
            return pendingEvents.ToList();
        }
        
        /// <summary>
        /// 모든 이벤트 클리어 (디버그용)
        /// </summary>
        public void ClearAllEvents()
        {
            pendingEvents.Clear();
            simultaneousEvents.Clear();
            currentEvent = null;
            Debug.Log("[EventManager] All events cleared");
        }
    }
    
    /// <summary>
    /// 게임 이벤트 데이터 구조
    /// </summary>
    [System.Serializable]
    public class GameEvent
    {
        public string eventId;
        public string eventName;
        public string description;
        public EventPriority priority;
        public EventType eventType;
        public int timeBlocksRequired;
        public List<string> tags;
        public bool isUrgent;
        public int urgencyDecayPerDay; // 긴급도 감소율
        
        // 선택지가 있는 이벤트인 경우
        public bool requiresDecision;
        public List<DecisionChoice> choices;
        
        // 결과
        public EventResult result;
    }
    
    /// <summary>
    /// 이벤트 우선순위
    /// </summary>
    public enum EventPriority
    {
        Critical = 0,   // 즉시 처리 필요
        High = 1,       // 높음
        Medium = 2,     // 보통
        Low = 3         // 낮음
    }
    
    /// <summary>
    /// 이벤트 타입
    /// </summary>
    public enum EventType
    {
        Meeting,        // 회의
        Email,          // 이메일
        Task,           // 작업
        Emergency,      // 긴급 사안
        Opportunity,    // 기회
        Problem         // 문제
    }
    
    /// <summary>
    /// 이벤트 결과
    /// </summary>
    [System.Serializable]
    public class EventResult
    {
        public bool isSuccess;
        public string message;
        public Dictionary<string, int> metricChanges; // 메트릭 변화
    }
}
