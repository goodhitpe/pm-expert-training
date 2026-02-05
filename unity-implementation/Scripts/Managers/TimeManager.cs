using System;
using System.Collections.Generic;
using UnityEngine;

namespace PMExpert.Core
{
    /// <summary>
    /// Time Block 시스템을 관리하는 매니저
    /// Phase 1.5 Week 1 - 게임 루프 재설계의 핵심 컴포넌트
    /// </summary>
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager Instance { get; private set; }

        // Constants
        public const int BLOCKS_PER_DAY = 8; // 하루 = 8 Time Blocks
        public const int WORK_HOURS_PER_DAY = 8; // 업무 시간
        
        // Current State
        private int currentBlock = 0;
        private int currentDay = 1;
        private int currentWeek = 1;
        
        // Configuration
        [SerializeField] private bool allowNegativeTime = false;
        [SerializeField] private float realTimePerBlock = 5f; // 실제 5초 = 게임 내 1 블록
        
        // Events
        public event Action<int, int> OnTimeAdvanced;  // (day, block)
        public event Action<int> OnDayEnded;           // (day)
        public event Action<int> OnWeekEnded;          // (week)
        public event Action<string> OnTimeWarning;     // 시간 부족 경고
        
        // Tracking
        private List<TimeBlockLog> timeBlockHistory = new List<TimeBlockLog>();
        
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
        
        void Start()
        {
            Debug.Log($"[TimeManager] Initialized: Day {currentDay}, Week {currentWeek}");
        }
        
        /// <summary>
        /// Time Block을 소비하려고 시도
        /// </summary>
        /// <param name="blocks">소비할 블록 수 (1-4 권장)</param>
        /// <param name="activityName">활동 이름 (로깅용)</param>
        /// <returns>성공 여부</returns>
        public bool TryConsumeTimeBlocks(int blocks, string activityName = "Unknown Activity")
        {
            if (blocks <= 0)
            {
                Debug.LogWarning($"[TimeManager] Invalid block count: {blocks}");
                return false;
            }
            
            // 하루 내에 가능한지 체크
            if (currentBlock + blocks > BLOCKS_PER_DAY)
            {
                if (allowNegativeTime)
                {
                    Debug.LogWarning($"[TimeManager] Overtime! Activity '{activityName}' requires {blocks} blocks but only {BLOCKS_PER_DAY - currentBlock} remaining today.");
                    // 다음 날로 넘어감
                    int overflow = (currentBlock + blocks) - BLOCKS_PER_DAY;
                    EndDay();
                    currentBlock = overflow;
                }
                else
                {
                    OnTimeWarning?.Invoke($"Not enough time blocks! Need {blocks}, have {BLOCKS_PER_DAY - currentBlock}");
                    return false;
                }
            }
            else
            {
                currentBlock += blocks;
            }
            
            // 로깅
            LogTimeBlock(activityName, blocks);
            
            // 이벤트 발생
            OnTimeAdvanced?.Invoke(currentDay, currentBlock);
            
            // 하루 끝났는지 체크
            if (currentBlock >= BLOCKS_PER_DAY)
            {
                EndDay();
            }
            
            Debug.Log($"[TimeManager] Consumed {blocks} blocks for '{activityName}'. Current: Day {currentDay}, Block {currentBlock}/{BLOCKS_PER_DAY}");
            return true;
        }
        
        /// <summary>
        /// 하루를 종료하고 다음 날로 진행
        /// </summary>
        private void EndDay()
        {
            Debug.Log($"[TimeManager] Day {currentDay} ended at block {currentBlock}");
            
            OnDayEnded?.Invoke(currentDay);
            
            currentDay++;
            currentBlock = 0;
            
            // 5일마다 주 종료
            if (currentDay % 5 == 1 && currentDay > 1)
            {
                EndWeek();
            }
        }
        
        /// <summary>
        /// 주를 종료하고 다음 주로 진행
        /// </summary>
        private void EndWeek()
        {
            Debug.Log($"[TimeManager] Week {currentWeek} ended");
            
            OnWeekEnded?.Invoke(currentWeek);
            currentWeek++;
        }
        
        /// <summary>
        /// 시간 건너뛰기 (테스트용)
        /// </summary>
        public void SkipToNextDay()
        {
            EndDay();
        }
        
        /// <summary>
        /// 현재 남은 시간 블록 수
        /// </summary>
        public int GetRemainingBlocks()
        {
            return BLOCKS_PER_DAY - currentBlock;
        }
        
        /// <summary>
        /// 현재 시간 정보 가져오기
        /// </summary>
        public (int day, int week, int block, int remaining) GetCurrentTime()
        {
            return (currentDay, currentWeek, currentBlock, GetRemainingBlocks());
        }
        
        /// <summary>
        /// 시간 사용 로그
        /// </summary>
        private void LogTimeBlock(string activity, int blocks)
        {
            timeBlockHistory.Add(new TimeBlockLog
            {
                day = currentDay,
                week = currentWeek,
                block = currentBlock,
                activity = activity,
                blocksUsed = blocks,
                timestamp = DateTime.Now
            });
        }
        
        /// <summary>
        /// 시간 사용 통계 가져오기
        /// </summary>
        public List<TimeBlockLog> GetTimeBlockHistory()
        {
            return new List<TimeBlockLog>(timeBlockHistory);
        }
        
        /// <summary>
        /// 시간 리셋 (디버그/테스트용)
        /// </summary>
        public void ResetTime()
        {
            currentDay = 1;
            currentWeek = 1;
            currentBlock = 0;
            timeBlockHistory.Clear();
            Debug.Log("[TimeManager] Time reset to Day 1, Week 1");
        }
    }
    
    /// <summary>
    /// 시간 블록 사용 로그
    /// </summary>
    [System.Serializable]
    public class TimeBlockLog
    {
        public int day;
        public int week;
        public int block;
        public string activity;
        public int blocksUsed;
        public DateTime timestamp;
    }
}
