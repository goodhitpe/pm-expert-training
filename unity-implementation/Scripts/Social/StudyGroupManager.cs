using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

namespace PMExpert.Social
{
    /// <summary>
    /// 스터디 그룹 관리 시스템
    /// 그룹 생성, 초대, 채팅, 공동 목표 설정
    /// </summary>
    public class StudyGroupManager : MonoBehaviour
    {
        private static StudyGroupManager instance;
        public static StudyGroupManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<StudyGroupManager>();
                    if (instance == null)
                    {
                        GameObject go = new GameObject("StudyGroupManager");
                        instance = go.AddComponent<StudyGroupManager>();
                    }
                }
                return instance;
            }
        }

        // API URL
        private string apiBaseUrl = "http://localhost:3003/api/groups";

        // 그룹 데이터
        [Serializable]
        public class StudyGroup
        {
            public string id;
            public string name;
            public string description;
            public string creatorId;
            public int maxMembers;
            public List<GroupMember> members;
            public GroupGoal goal;
            public GroupStats stats;
            public DateTime createdAt;
            public bool isActive;
        }

        // 그룹 멤버
        [Serializable]
        public class GroupMember
        {
            public string studentId;
            public string studentName;
            public MemberRole role;
            public DateTime joinedAt;
            public int contributionScore;
        }

        public enum MemberRole
        {
            Creator,    // 생성자
            Admin,      // 관리자
            Member      // 멤버
        }

        // 그룹 목표
        [Serializable]
        public class GroupGoal
        {
            public string description;
            public DateTime deadline;
            public int targetWeek;
            public float targetScore;
            public bool achieved;
        }

        // 그룹 통계
        [Serializable]
        public class GroupStats
        {
            public float averageProgress;
            public float averageScore;
            public int completedWeeks;
            public int totalMessages;
            public int activeDays;
        }

        // 그룹 메시지
        [Serializable]
        public class GroupMessage
        {
            public string id;
            public string groupId;
            public string senderId;
            public string senderName;
            public string content;
            public DateTime sentAt;
            public bool isRead;
        }

        private List<StudyGroup> availableGroups = new List<StudyGroup>();
        private Dictionary<string, List<GroupMessage>> groupMessages = new Dictionary<string, List<GroupMessage>>();

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// 그룹 목록 UI 열기
        /// </summary>
        public void ShowGroupList()
        {
            Debug.Log("[StudyGroupManager] 그룹 목록 열기");
            
            // 그룹 목록 UI 표시
            // TODO: UI 구현
            
            // 그룹 목록 로드
            StartCoroutine(LoadGroups());
        }

        /// <summary>
        /// 그룹 목록 로드
        /// </summary>
        private IEnumerator LoadGroups()
        {
            string url = apiBaseUrl;
            
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();
                
                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log($"[StudyGroupManager] 그룹 {availableGroups.Count}개 로드 완료");
                }
                else
                {
                    Debug.LogError($"[StudyGroupManager] 그룹 로드 실패: {request.error}");
                }
            }
        }

        /// <summary>
        /// 그룹 생성
        /// </summary>
        public string CreateGroup(string name, string description, int maxMembers, string creatorId)
        {
            Debug.Log($"[StudyGroupManager] 그룹 생성 - {name}");
            
            if (maxMembers < 2 || maxMembers > 6)
            {
                Debug.LogWarning("[StudyGroupManager] 그룹 인원은 2-6명이어야 합니다");
                maxMembers = Mathf.Clamp(maxMembers, 2, 6);
            }
            
            StudyGroup newGroup = new StudyGroup
            {
                id = "GROUP_" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper(),
                name = name,
                description = description,
                creatorId = creatorId,
                maxMembers = maxMembers,
                members = new List<GroupMember>(),
                goal = null,
                stats = new GroupStats
                {
                    averageProgress = 0,
                    averageScore = 0,
                    completedWeeks = 0,
                    totalMessages = 0,
                    activeDays = 0
                },
                createdAt = DateTime.Now,
                isActive = true
            };
            
            // 생성자를 첫 번째 멤버로 추가
            GroupMember creator = new GroupMember
            {
                studentId = creatorId,
                studentName = "학습자",
                role = MemberRole.Creator,
                joinedAt = DateTime.Now,
                contributionScore = 0
            };
            newGroup.members.Add(creator);
            
            StartCoroutine(PostToAPI("", JsonUtility.ToJson(newGroup)));
            availableGroups.Add(newGroup);
            
            Debug.Log($"[StudyGroupManager] 그룹 생성 완료 - ID: {newGroup.id}");
            return newGroup.id;
        }

        /// <summary>
        /// 멤버 초대
        /// </summary>
        public void InviteMember(string groupId, string studentId)
        {
            Debug.Log($"[StudyGroupManager] 멤버 초대 - Group: {groupId}, Student: {studentId}");
            
            StudyGroup group = availableGroups.Find(g => g.id == groupId);
            if (group == null)
            {
                Debug.LogError("[StudyGroupManager] 그룹을 찾을 수 없습니다");
                return;
            }
            
            if (group.members.Count >= group.maxMembers)
            {
                Debug.LogWarning("[StudyGroupManager] 그룹 인원이 가득 찼습니다");
                return;
            }
            
            if (group.members.Exists(m => m.studentId == studentId))
            {
                Debug.LogWarning("[StudyGroupManager] 이미 그룹 멤버입니다");
                return;
            }
            
            // 초대 알림 전송
            StartCoroutine(PostToAPI($"/{groupId}/invite", $"{{\"studentId\":\"{studentId}\"}}"));
            
            Debug.Log("[StudyGroupManager] 초대 전송 완료");
        }

        /// <summary>
        /// 그룹 가입
        /// </summary>
        public void JoinGroup(string groupId, string studentId)
        {
            Debug.Log($"[StudyGroupManager] 그룹 가입 - Group: {groupId}, Student: {studentId}");
            
            StudyGroup group = availableGroups.Find(g => g.id == groupId);
            if (group == null)
            {
                Debug.LogError("[StudyGroupManager] 그룹을 찾을 수 없습니다");
                return;
            }
            
            if (group.members.Count >= group.maxMembers)
            {
                Debug.LogWarning("[StudyGroupManager] 그룹 인원이 가득 찼습니다");
                return;
            }
            
            GroupMember newMember = new GroupMember
            {
                studentId = studentId,
                studentName = "학습자",
                role = MemberRole.Member,
                joinedAt = DateTime.Now,
                contributionScore = 0
            };
            
            group.members.Add(newMember);
            StartCoroutine(PostToAPI($"/{groupId}/join", JsonUtility.ToJson(newMember)));
            
            Debug.Log($"[StudyGroupManager] 가입 완료 - 현재 인원: {group.members.Count}/{group.maxMembers}");
        }

        /// <summary>
        /// 그룹 채팅 메시지 전송
        /// </summary>
        public void SendMessage(string groupId, string studentId, string content)
        {
            Debug.Log($"[StudyGroupManager] 메시지 전송 - Group: {groupId}");
            
            GroupMessage newMessage = new GroupMessage
            {
                id = "MSG_" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper(),
                groupId = groupId,
                senderId = studentId,
                senderName = "학습자",
                content = content,
                sentAt = DateTime.Now,
                isRead = false
            };
            
            if (!groupMessages.ContainsKey(groupId))
            {
                groupMessages[groupId] = new List<GroupMessage>();
            }
            groupMessages[groupId].Add(newMessage);
            
            // 그룹 통계 업데이트
            StudyGroup group = availableGroups.Find(g => g.id == groupId);
            if (group != null)
            {
                group.stats.totalMessages++;
            }
            
            StartCoroutine(PostToAPI($"/{groupId}/messages", JsonUtility.ToJson(newMessage)));
            
            Debug.Log($"[StudyGroupManager] 메시지 전송 완료 - ID: {newMessage.id}");
        }

        /// <summary>
        /// 그룹 목표 설정
        /// </summary>
        public void SetGroupGoal(string groupId, string description, DateTime deadline, int targetWeek = 0, float targetScore = 0)
        {
            Debug.Log($"[StudyGroupManager] 그룹 목표 설정 - Group: {groupId}");
            
            StudyGroup group = availableGroups.Find(g => g.id == groupId);
            if (group == null)
            {
                Debug.LogError("[StudyGroupManager] 그룹을 찾을 수 없습니다");
                return;
            }
            
            group.goal = new GroupGoal
            {
                description = description,
                deadline = deadline,
                targetWeek = targetWeek,
                targetScore = targetScore,
                achieved = false
            };
            
            StartCoroutine(PutToAPI($"/{groupId}/goal", JsonUtility.ToJson(group.goal)));
            
            Debug.Log($"[StudyGroupManager] 목표 설정 완료 - {description}");
        }

        /// <summary>
        /// 그룹 통계 조회
        /// </summary>
        public GroupStats GetGroupStats(string groupId)
        {
            Debug.Log($"[StudyGroupManager] 그룹 통계 조회 - Group: {groupId}");
            
            StudyGroup group = availableGroups.Find(g => g.id == groupId);
            if (group != null)
            {
                return group.stats;
            }
            
            return null;
        }

        /// <summary>
        /// 그룹 메시지 조회
        /// </summary>
        public List<GroupMessage> GetGroupMessages(string groupId, int limit = 50)
        {
            Debug.Log($"[StudyGroupManager] 그룹 메시지 조회 - Group: {groupId}");
            
            if (groupMessages.ContainsKey(groupId))
            {
                List<GroupMessage> messages = groupMessages[groupId];
                return messages.GetRange(Math.Max(0, messages.Count - limit), Math.Min(limit, messages.Count));
            }
            
            return new List<GroupMessage>();
        }

        /// <summary>
        /// 멤버 제거 (관리자 전용)
        /// </summary>
        public void RemoveMember(string groupId, string studentId, string requesterId)
        {
            Debug.Log($"[StudyGroupManager] 멤버 제거 - Group: {groupId}, Student: {studentId}");
            
            StudyGroup group = availableGroups.Find(g => g.id == groupId);
            if (group == null)
            {
                Debug.LogError("[StudyGroupManager] 그룹을 찾을 수 없습니다");
                return;
            }
            
            // 권한 확인
            GroupMember requester = group.members.Find(m => m.studentId == requesterId);
            if (requester == null || (requester.role != MemberRole.Creator && requester.role != MemberRole.Admin))
            {
                Debug.LogWarning("[StudyGroupManager] 권한이 없습니다");
                return;
            }
            
            // 멤버 제거
            group.members.RemoveAll(m => m.studentId == studentId);
            StartCoroutine(DeleteFromAPI($"/{groupId}/members/{studentId}"));
            
            Debug.Log($"[StudyGroupManager] 멤버 제거 완료");
        }

        /// <summary>
        /// 그룹 목표 달성 확인
        /// </summary>
        public void CheckGoalAchievement(string groupId)
        {
            Debug.Log($"[StudyGroupManager] 목표 달성 확인 - Group: {groupId}");
            
            StudyGroup group = availableGroups.Find(g => g.id == groupId);
            if (group == null || group.goal == null || group.goal.achieved)
            {
                return;
            }
            
            bool achieved = false;
            
            // Week 목표 확인
            if (group.goal.targetWeek > 0)
            {
                achieved = group.stats.completedWeeks >= group.goal.targetWeek;
            }
            
            // 점수 목표 확인
            if (group.goal.targetScore > 0)
            {
                achieved = achieved && group.stats.averageScore >= group.goal.targetScore;
            }
            
            if (achieved)
            {
                group.goal.achieved = true;
                Debug.Log($"[StudyGroupManager] 🎉 그룹 목표 달성!");
                
                // 모든 멤버에게 알림
                // TODO: 알림 시스템 통합
            }
        }

        /// <summary>
        /// 내가 속한 그룹 목록
        /// </summary>
        public List<StudyGroup> GetMyGroups(string studentId)
        {
            return availableGroups.FindAll(g => g.members.Exists(m => m.studentId == studentId));
        }

        /// <summary>
        /// API POST 요청
        /// </summary>
        private IEnumerator PostToAPI(string endpoint, string jsonData)
        {
            string url = apiBaseUrl + endpoint;
            
            using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
            {
                byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");
                
                yield return request.SendWebRequest();
                
                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log($"[StudyGroupManager] API 요청 성공: {endpoint}");
                }
                else
                {
                    Debug.LogError($"[StudyGroupManager] API 요청 실패: {request.error}");
                }
            }
        }

        /// <summary>
        /// API PUT 요청
        /// </summary>
        private IEnumerator PutToAPI(string endpoint, string jsonData)
        {
            string url = apiBaseUrl + endpoint;
            
            using (UnityWebRequest request = UnityWebRequest.Put(url, jsonData))
            {
                request.SetRequestHeader("Content-Type", "application/json");
                
                yield return request.SendWebRequest();
                
                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log($"[StudyGroupManager] API 요청 성공: {endpoint}");
                }
                else
                {
                    Debug.LogError($"[StudyGroupManager] API 요청 실패: {request.error}");
                }
            }
        }

        /// <summary>
        /// API DELETE 요청
        /// </summary>
        private IEnumerator DeleteFromAPI(string endpoint)
        {
            string url = apiBaseUrl + endpoint;
            
            using (UnityWebRequest request = UnityWebRequest.Delete(url))
            {
                yield return request.SendWebRequest();
                
                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log($"[StudyGroupManager] API 요청 성공: {endpoint}");
                }
                else
                {
                    Debug.LogError($"[StudyGroupManager] API 요청 실패: {request.error}");
                }
            }
        }
    }
}
