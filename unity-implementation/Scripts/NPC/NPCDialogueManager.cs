using System;
using System.Collections.Generic;
using UnityEngine;

namespace PMExpert.NPC
{
    /// <summary>
    /// NPC 대화 관리 시스템
    /// 관계와 감정에 따라 동적으로 대화를 생성합니다.
    /// </summary>
    public class NPCDialogueManager : MonoBehaviour
    {
        private static NPCDialogueManager _instance;
        public static NPCDialogueManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new GameObject("NPCDialogueManager");
                    _instance = go.AddComponent<NPCDialogueManager>();
                    DontDestroyOnLoad(go);
                }
                return _instance;
            }
        }

        public enum DialogueContext
        {
            Greeting, DailyWork, Emergency, Conflict, Celebration, Personal
        }

        [Serializable]
        public class Dialogue
        {
            public string id;
            public string npcId;
            public string text;
            public List<DialogueResponse> responses;
        }

        [Serializable]
        public class DialogueResponse
        {
            public string id;
            public string text;
            public int trustChange;
            public string emotionChange; // Happy, Angry, etc.
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

        public Dialogue GetDialogue(string npcId, DialogueContext context)
        {
            var relationshipLevel = NPCRelationshipManager.Instance.GetRelationshipLevel(npcId);
            var emotion = NPCEmotionManager.Instance.GetEmotion(npcId);

            string dialogueText = GenerateDialogueText(npcId, context, relationshipLevel, emotion);
            var responses = GenerateResponses(context, relationshipLevel, emotion);

            return new Dialogue
            {
                id = $"DLG_{npcId}_{context}_{DateTime.Now.Ticks}",
                npcId = npcId,
                text = dialogueText,
                responses = responses
            };
        }

        private string GenerateDialogueText(string npcId, DialogueContext context, 
            NPCRelationshipManager.RelationshipLevel relationship, 
            NPCEmotionManager.EmotionState emotion)
        {
            // 간단한 대화 생성 로직
            string emotionPrefix = emotion == NPCEmotionManager.EmotionState.Happy ? "😊 " : 
                                   emotion == NPCEmotionManager.EmotionState.Angry ? "😠 " :
                                   emotion == NPCEmotionManager.EmotionState.Anxious ? "😰 " : "";

            string baseText = "";
            switch (context)
            {
                case DialogueContext.Greeting:
                    baseText = relationship >= NPCRelationshipManager.RelationshipLevel.Friend 
                        ? "안녕하세요, PM님! 오늘 기분 좋네요." 
                        : "안녕하세요.";
                    break;
                case DialogueContext.DailyWork:
                    baseText = "오늘 작업 진행 상황을 보고드립니다.";
                    break;
                case DialogueContext.Emergency:
                    baseText = "중요한 문제가 발생했습니다!";
                    break;
            }

            return emotionPrefix + baseText;
        }

        private List<DialogueResponse> GenerateResponses(DialogueContext context,
            NPCRelationshipManager.RelationshipLevel relationship,
            NPCEmotionManager.EmotionState emotion)
        {
            var responses = new List<DialogueResponse>();

            // 기본 응답 옵션
            responses.Add(new DialogueResponse
            {
                id = "R1",
                text = "감사합니다. 계속 진행해주세요.",
                trustChange = 5,
                emotionChange = "Happy"
            });

            responses.Add(new DialogueResponse
            {
                id = "R2",
                text = "빨리 처리해주세요.",
                trustChange = -5,
                emotionChange = "Anxious"
            });

            return responses;
        }

        public void ChooseResponse(string dialogueId, string responseId)
        {
            Debug.Log($"[Dialogue] 응답 선택: {responseId}");
            // 응답에 따른 관계/감정 변경 로직
        }
    }
}
