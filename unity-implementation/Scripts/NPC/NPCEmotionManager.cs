using System;
using System.Collections.Generic;
using UnityEngine;

namespace PMExpert.NPC
{
    /// <summary>
    /// NPC 감정 관리 시스템
    /// 4가지 감정 상태를 관리하고 성과에 영향을 줍니다.
    /// </summary>
    public class NPCEmotionManager : MonoBehaviour
    {
        private static NPCEmotionManager _instance;
        public static NPCEmotionManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new GameObject("NPCEmotionManager");
                    _instance = go.AddComponent<NPCEmotionManager>();
                    DontDestroyOnLoad(go);
                }
                return _instance;
            }
        }

        public enum EmotionState
        {
            Happy,    // 행복 - 생산성↑ 협조도↑
            Neutral,  // 보통 - 기본 상태
            Angry,    // 화남 - 협조도↓ 갈등위험↑
            Anxious   // 불안 - 실수율↑ 생산성↓
        }

        public enum EmotionEvent
        {
            Praise, Criticism, Pressure, Success, Failure
        }

        private Dictionary<string, EmotionState> emotions = new Dictionary<string, EmotionState>();

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

        public void InitializeEmotion(string npcId)
        {
            if (!emotions.ContainsKey(npcId))
            {
                emotions[npcId] = EmotionState.Neutral;
            }
        }

        public void SetEmotion(string npcId, EmotionState newEmotion)
        {
            if (!emotions.ContainsKey(npcId)) InitializeEmotion(npcId);
            emotions[npcId] = newEmotion;
            Debug.Log($"[Emotion] {npcId} 감정: {newEmotion}");
        }

        public EmotionState GetEmotion(string npcId)
        {
            if (!emotions.ContainsKey(npcId)) InitializeEmotion(npcId);
            return emotions[npcId];
        }

        public void ApplyEmotionEvent(string npcId, EmotionEvent emotionEvent)
        {
            EmotionState currentEmotion = GetEmotion(npcId);
            
            switch (emotionEvent)
            {
                case EmotionEvent.Praise:
                    SetEmotion(npcId, EmotionState.Happy);
                    break;
                case EmotionEvent.Criticism:
                    SetEmotion(npcId, currentEmotion == EmotionState.Happy ? EmotionState.Neutral : EmotionState.Angry);
                    break;
                case EmotionEvent.Pressure:
                    SetEmotion(npcId, EmotionState.Anxious);
                    break;
                case EmotionEvent.Success:
                    SetEmotion(npcId, EmotionState.Happy);
                    break;
                case EmotionEvent.Failure:
                    SetEmotion(npcId, EmotionState.Anxious);
                    break;
            }
        }

        public Dictionary<string, float> GetEmotionEffects(string npcId)
        {
            EmotionState emotion = GetEmotion(npcId);
            var effects = new Dictionary<string, float>();

            switch (emotion)
            {
                case EmotionState.Happy:
                    effects["productivity"] = 1.2f;
                    effects["cooperation"] = 1.15f;
                    effects["error_rate"] = 0.9f;
                    break;
                case EmotionState.Neutral:
                    effects["productivity"] = 1.0f;
                    effects["cooperation"] = 1.0f;
                    effects["error_rate"] = 1.0f;
                    break;
                case EmotionState.Angry:
                    effects["productivity"] = 0.9f;
                    effects["cooperation"] = 0.7f;
                    effects["error_rate"] = 1.2f;
                    break;
                case EmotionState.Anxious:
                    effects["productivity"] = 0.85f;
                    effects["cooperation"] = 0.9f;
                    effects["error_rate"] = 1.25f;
                    break;
            }

            return effects;
        }
    }
}
