using System;
using System.Collections.Generic;
using UnityEngine;

namespace PMExpert.NPC
{
    /// <summary>
    /// NPC 관계 관리 시스템
    /// 신뢰도(0-100)를 기반으로 NPC와의 관계를 관리합니다.
    /// </summary>
    public class NPCRelationshipManager : MonoBehaviour
    {
        private static NPCRelationshipManager _instance;
        public static NPCRelationshipManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new GameObject("NPCRelationshipManager");
                    _instance = go.AddComponent<NPCRelationshipManager>();
                    DontDestroyOnLoad(go);
                }
                return _instance;
            }
        }

        // 관계 데이터
        private Dictionary<string, float> trustScores = new Dictionary<string, float>();
        
        public enum RelationshipLevel
        {
            Stranger, Acquaintance, Friend, Close, Trusted
        }

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

        public void InitializeTrust(string npcId, float initialTrust = 25f)
        {
            if (!trustScores.ContainsKey(npcId))
            {
                trustScores[npcId] = Mathf.Clamp(initialTrust, 0f, 100f);
            }
        }

        public void ModifyTrust(string npcId, float amount)
        {
            if (!trustScores.ContainsKey(npcId)) InitializeTrust(npcId);
            trustScores[npcId] = Mathf.Clamp(trustScores[npcId] + amount, 0f, 100f);
        }

        public float GetTrust(string npcId)
        {
            if (!trustScores.ContainsKey(npcId)) InitializeTrust(npcId);
            return trustScores[npcId];
        }

        public RelationshipLevel GetRelationshipLevel(string npcId)
        {
            float trust = GetTrust(npcId);
            if (trust <= 20f) return RelationshipLevel.Stranger;
            if (trust <= 40f) return RelationshipLevel.Acquaintance;
            if (trust <= 60f) return RelationshipLevel.Friend;
            if (trust <= 80f) return RelationshipLevel.Close;
            return RelationshipLevel.Trusted;
        }
    }
}
