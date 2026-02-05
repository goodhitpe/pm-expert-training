/**
 * Q&A Board Manager
 * Phase 1.5 Week 4 - Q&A 게시판 Unity 통합
 * 
 * 기능:
 * - Q&A 게시판 WebView 표시
 * - 질문/답변 작성
 * - 실시간 알림
 */

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PMExpert.UI
{
    public class QABoardManager : MonoBehaviour
    {
        // Singleton
        private static QABoardManager _instance;
        public static QABoardManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<QABoardManager>();
                    if (_instance == null)
                    {
                        GameObject go = new GameObject("QABoardManager");
                        _instance = go.AddComponent<QABoardManager>();
                    }
                }
                return _instance;
            }
        }

        [Header("Settings")]
        [SerializeField] private string qaApiUrl = "http://localhost:3001/api/qa";
        [SerializeField] private bool useWebView = true; // WebView vs Native UI
        
        [Header("UI References")]
        [SerializeField] private GameObject qaBoardPanel;
        [SerializeField] private GameObject questionListPanel;
        [SerializeField] private GameObject questionDetailPanel;
        [SerializeField] private GameObject newQuestionDialog;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // ==================== Public Methods ====================

        /// <summary>
        /// Q&A 게시판 열기
        /// </summary>
        /// <param name="week">특정 주차 필터 (0이면 전체)</param>
        public void ShowQABoard(int week = 0)
        {
            Debug.Log($"[QABoardManager] Q&A 게시판 열기 (Week: {(week == 0 ? "전체" : week.ToString())})");
            
            if (useWebView)
            {
                // WebView로 열기
                string url = $"{qaApiUrl}/board";
                if (week > 0)
                {
                    url += $"?week={week}";
                }
                WebViewManager.Instance.OpenURL(url);
            }
            else
            {
                // Native UI로 열기
                ShowNativeQABoard(week);
            }
        }

        /// <summary>
        /// 질문 상세 보기
        /// </summary>
        public void ShowQuestionDetail(string questionId)
        {
            Debug.Log($"[QABoardManager] 질문 상세 보기: {questionId}");
            StartCoroutine(LoadQuestionDetail(questionId));
        }

        /// <summary>
        /// 새 질문 작성 다이얼로그
        /// </summary>
        public void ShowNewQuestionDialog(int week, string category)
        {
            Debug.Log($"[QABoardManager] 새 질문 작성 (Week {week}, {category})");
            
            if (newQuestionDialog != null)
            {
                newQuestionDialog.SetActive(true);
                // TODO: 주차와 카테고리 기본값 설정
            }
        }

        /// <summary>
        /// 질문 작성
        /// </summary>
        public void PostQuestion(string studentId, int week, string category, string title, string content)
        {
            Debug.Log($"[QABoardManager] 질문 작성 중...");
            StartCoroutine(PostQuestionCoroutine(studentId, week, category, title, content));
        }

        /// <summary>
        /// 답변 작성
        /// </summary>
        public void PostAnswer(string questionId, string authorId, string authorType, string content)
        {
            Debug.Log($"[QABoardManager] 답변 작성 중...");
            StartCoroutine(PostAnswerCoroutine(questionId, authorId, authorType, content));
        }

        /// <summary>
        /// 투표 (추천/비추천)
        /// </summary>
        public void Vote(string targetId, string targetType, string voteType, string userId)
        {
            Debug.Log($"[QABoardManager] 투표: {voteType} on {targetType} {targetId}");
            StartCoroutine(VoteCoroutine(targetId, targetType, voteType, userId));
        }

        // ==================== Private Methods ====================

        private void ShowNativeQABoard(int week)
        {
            if (qaBoardPanel != null)
            {
                qaBoardPanel.SetActive(true);
            }
            
            // 질문 목록 로드
            StartCoroutine(LoadQuestions(week));
        }

        private IEnumerator LoadQuestions(int week = 0)
        {
            string url = $"{qaApiUrl}/questions";
            if (week > 0)
            {
                url += $"?week={week}";
            }
            
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();
                
                if (request.result == UnityWebRequest.Result.Success)
                {
                    string jsonResponse = request.downloadHandler.text;
                    Debug.Log($"[QABoardManager] 질문 목록 로드 성공");
                    
                    // TODO: JSON 파싱 및 UI 업데이트
                    // var response = JsonConvert.DeserializeObject<QuestionListResponse>(jsonResponse);
                    // UpdateQuestionListUI(response.questions);
                }
                else
                {
                    Debug.LogError($"[QABoardManager] 질문 목록 로드 실패: {request.error}");
                }
            }
        }

        private IEnumerator LoadQuestionDetail(string questionId)
        {
            string url = $"{qaApiUrl}/questions/{questionId}";
            
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();
                
                if (request.result == UnityWebRequest.Result.Success)
                {
                    string jsonResponse = request.downloadHandler.text;
                    Debug.Log($"[QABoardManager] 질문 상세 로드 성공: {questionId}");
                    
                    // TODO: JSON 파싱 및 UI 업데이트
                    if (questionDetailPanel != null)
                    {
                        questionDetailPanel.SetActive(true);
                    }
                }
                else
                {
                    Debug.LogError($"[QABoardManager] 질문 상세 로드 실패: {request.error}");
                }
            }
        }

        private IEnumerator PostQuestionCoroutine(string studentId, int week, string category, string title, string content)
        {
            var questionData = new
            {
                studentId = studentId,
                week = week,
                category = category,
                title = title,
                content = content
            };
            
            string jsonData = JsonConvert.SerializeObject(questionData);
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            
            using (UnityWebRequest request = new UnityWebRequest($"{qaApiUrl}/questions", "POST"))
            {
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");
                
                yield return request.SendWebRequest();
                
                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log($"[QABoardManager] 질문 작성 성공!");
                    
                    // 성공 피드백
                    UIJuiceManager.Instance.ShowSuccess("질문이 작성되었습니다!");
                    UIJuiceManager.Instance.PlaySound(SoundType.Success);
                    
                    // Q&A 게시판 새로고침
                    ShowQABoard(week);
                }
                else
                {
                    Debug.LogError($"[QABoardManager] 질문 작성 실패: {request.error}");
                    UIJuiceManager.Instance.ShowFailure("질문 작성에 실패했습니다.");
                }
            }
        }

        private IEnumerator PostAnswerCoroutine(string questionId, string authorId, string authorType, string content)
        {
            var answerData = new
            {
                questionId = questionId,
                authorId = authorId,
                authorType = authorType,
                content = content
            };
            
            string jsonData = JsonConvert.SerializeObject(answerData);
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            
            using (UnityWebRequest request = new UnityWebRequest($"{qaApiUrl}/answers", "POST"))
            {
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");
                
                yield return request.SendWebRequest();
                
                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log($"[QABoardManager] 답변 작성 성공!");
                    
                    // 성공 피드백
                    UIJuiceManager.Instance.ShowSuccess("답변이 작성되었습니다!");
                    UIJuiceManager.Instance.PlaySound(SoundType.Success);
                    
                    // 질문 상세 새로고침
                    ShowQuestionDetail(questionId);
                }
                else
                {
                    Debug.LogError($"[QABoardManager] 답변 작성 실패: {request.error}");
                    UIJuiceManager.Instance.ShowFailure("답변 작성에 실패했습니다.");
                }
            }
        }

        private IEnumerator VoteCoroutine(string targetId, string targetType, string voteType, string userId)
        {
            var voteData = new
            {
                targetId = targetId,
                targetType = targetType,
                voteType = voteType,
                userId = userId
            };
            
            string jsonData = JsonConvert.SerializeObject(voteData);
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            
            using (UnityWebRequest request = new UnityWebRequest($"{qaApiUrl}/votes", "POST"))
            {
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");
                
                yield return request.SendWebRequest();
                
                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log($"[QABoardManager] 투표 성공!");
                    
                    // 피드백
                    UIJuiceManager.Instance.PlaySound(SoundType.Click);
                }
                else
                {
                    Debug.LogError($"[QABoardManager] 투표 실패: {request.error}");
                }
            }
        }

        // ==================== Data Models ====================

        [System.Serializable]
        public class Question
        {
            public string id;
            public string studentId;
            public int week;
            public string category;
            public string title;
            public string content;
            public string status;
            public int votes;
            public int views;
            public string createdAt;
        }

        [System.Serializable]
        public class Answer
        {
            public string id;
            public string questionId;
            public string authorId;
            public string authorType;
            public string content;
            public int votes;
            public string createdAt;
        }

        [System.Serializable]
        public class QuestionListResponse
        {
            public List<Question> questions;
            public Pagination pagination;
        }

        [System.Serializable]
        public class QuestionDetailResponse
        {
            public Question question;
            public List<Answer> answers;
        }

        [System.Serializable]
        public class Pagination
        {
            public int currentPage;
            public int totalPages;
            public int totalItems;
            public int itemsPerPage;
        }
    }
}
