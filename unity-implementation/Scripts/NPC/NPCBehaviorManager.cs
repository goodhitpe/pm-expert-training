using System;
using System.Collections.Generic;
using UnityEngine;

namespace PMExpert.NPC
{
    /// <summary>
    /// NPC 자율 행동 관리 시스템
    /// 일일 루틴, 자율 의사결정, 이벤트 대응을 관리합니다.
    /// </summary>
    public class NPCBehaviorManager : MonoBehaviour
    {
        private static NPCBehaviorManager _instance;
        public static NPCBehaviorManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new GameObject("NPCBehaviorManager");
                    _instance = go.AddComponent<NPCBehaviorManager>();
                    DontDestroyOnLoad(go);
                }
                return _instance;
            }
        }

        public enum NPCActivity
        {
            Idle, Working, Meeting, Break, Commuting
        }

        [Serializable]
        public class NPCState
        {
            public string npcId;
            public NPCActivity currentActivity;
            public float workProgress; // 0-100
            public string currentTask;
            public DateTime lastUpdate;
        }

        private Dictionary<string, NPCState> npcStates = new Dictionary<string, NPCState>();

        void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void InitializeNPC(string npcId)
        {
            if (!npcStates.ContainsKey(npcId))
            {
                npcStates[npcId] = new NPCState
                {
                    npcId = npcId,
                    currentActivity = NPCActivity.Idle,
                    workProgress = 0f,
                    currentTask = "",
                    lastUpdate = DateTime.Now
                };
            }
        }

        public void UpdateNPC(string npcId, float deltaTime)
        {
            if (!npcStates.ContainsKey(npcId)) InitializeNPC(npcId);
            
            NPCState state = npcStates[npcId];
            
            // 일일 루틴 체크
            CheckDailyRoutine(state);
            
            // 작업 진행
            if (state.currentActivity == NPCActivity.Working)
            {
                UpdateWorkProgress(state, deltaTime);
            }
        }

        private void CheckDailyRoutine(NPCState state)
        {
            DateTime now = DateTime.Now;
            int hour = now.Hour;

            // 간단한 일일 루틴
            if (hour >= 9 && hour < 12)
            {
                state.currentActivity = NPCActivity.Working;
            }
            else if (hour >= 12 && hour < 13)
            {
                state.currentActivity = NPCActivity.Break;
            }
            else if (hour >= 13 && hour < 18)
            {
                state.currentActivity = NPCActivity.Working;
            }
            else
            {
                state.currentActivity = NPCActivity.Idle;
            }
        }

        private void UpdateWorkProgress(NPCState state, float deltaTime)
        {
            // 감정과 관계에 따른 생산성 계산
            var emotionEffects = NPCEmotionManager.Instance.GetEmotionEffects(state.npcId);
            var relationshipEffects = NPCRelationshipManager.Instance.GetRelationshipEffects(state.npcId);
            
            float productivity = emotionEffects["productivity"] * relationshipEffects["productivity"];
            
            state.workProgress += deltaTime * productivity * 0.1f;
            state.workProgress = Mathf.Clamp(state.workProgress, 0f, 100f);

            if (state.workProgress >= 100f)
            {
                Debug.Log($"[Behavior] {state.npcId} 작업 완료!");
                state.workProgress = 0f;
            }
        }

        public void AssignTask(string npcId, string taskName)
        {
            if (!npcStates.ContainsKey(npcId)) InitializeNPC(npcId);
            
            npcStates[npcId].currentTask = taskName;
            npcStates[npcId].workProgress = 0f;
            npcStates[npcId].currentActivity = NPCActivity.Working;
            
            Debug.Log($"[Behavior] {npcId}에게 작업 할당: {taskName}");
        }

        public NPCState GetNPCState(string npcId)
        {
            if (!npcStates.ContainsKey(npcId)) InitializeNPC(npcId);
            return npcStates[npcId];
        }
    }
}
