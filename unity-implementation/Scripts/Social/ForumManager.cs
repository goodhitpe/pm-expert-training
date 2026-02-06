using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

namespace PMExpert.Social
{
    /// <summary>
    /// 토론 포럼 관리 시스템
    /// 주차별/주제별 토론, 게시글, 답글, 추천 기능
    /// </summary>
    public class ForumManager : MonoBehaviour
    {
        private static ForumManager instance;
        public static ForumManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<ForumManager>();
                    if (instance == null)
                    {
                        GameObject go = new GameObject("ForumManager");
                        instance = go.AddComponent<ForumManager>();
                    }
                }
                return instance;
            }
        }

        // API URL
        private string apiBaseUrl = "http://localhost:3002/api/forum";

        // 주제 카테고리
        public enum TopicCategory
        {
            Planning,    // 기획
            Execution,   // 실행
            Monitoring,  // 모니터링
            Closing,     // 종료
            General      // 일반
        }

        // 게시글 데이터
        [Serializable]
        public class ForumPost
        {
            public string id;
            public string authorId;
            public string authorName;
            public int week;
            public TopicCategory category;
            public string title;
            public string content;
            public int views;
            public int likes;
            public int replyCount;
            public DateTime createdAt;
            public DateTime updatedAt;
            public List<string> bookmarkedBy;
            public List<string> likedBy;
        }

        // 답글 데이터
        [Serializable]
        public class ForumReply
        {
            public string id;
            public string postId;
            public string authorId;
            public string authorName;
            public string content;
            public int likes;
            public DateTime createdAt;
            public List<string> likedBy;
        }

        private List<ForumPost> cachedPosts = new List<ForumPost>();
        private Dictionary<string, List<ForumReply>> cachedReplies = new Dictionary<string, List<ForumReply>>();

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
        /// 토론 포럼 UI 열기
        /// </summary>
        public void ShowForum(int week = 0, TopicCategory category = TopicCategory.General)
        {
            Debug.Log($"[ForumManager] 포럼 열기 - Week: {week}, Category: {category}");
            
            // 포럼 UI 표시
            // TODO: UI 구현
            
            // 게시글 로드
            StartCoroutine(LoadPosts(week, category));
        }

        /// <summary>
        /// 게시글 목록 로드
        /// </summary>
        private IEnumerator LoadPosts(int week, TopicCategory category)
        {
            string url = $"{apiBaseUrl}/posts?week={week}&category={category}";
            
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();
                
                if (request.result == UnityWebRequest.Result.Success)
                {
                    // JSON 파싱
                    string jsonResponse = request.downloadHandler.text;
                    // cachedPosts = JsonUtility.FromJson<List<ForumPost>>(jsonResponse);
                    Debug.Log($"[ForumManager] 게시글 {cachedPosts.Count}개 로드 완료");
                }
                else
                {
                    Debug.LogError($"[ForumManager] 게시글 로드 실패: {request.error}");
                }
            }
        }

        /// <summary>
        /// 게시글 작성
        /// </summary>
        public void CreatePost(string studentId, int week, TopicCategory category, string title, string content)
        {
            Debug.Log($"[ForumManager] 게시글 작성 - {title}");
            
            ForumPost newPost = new ForumPost
            {
                id = "POST_" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper(),
                authorId = studentId,
                authorName = "학습자",
                week = week,
                category = category,
                title = title,
                content = content,
                views = 0,
                likes = 0,
                replyCount = 0,
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now,
                bookmarkedBy = new List<string>(),
                likedBy = new List<string>()
            };
            
            StartCoroutine(PostToAPI("/posts", JsonUtility.ToJson(newPost)));
            cachedPosts.Insert(0, newPost);
            
            Debug.Log($"[ForumManager] 게시글 작성 완료 - ID: {newPost.id}");
        }

        /// <summary>
        /// 답글 작성
        /// </summary>
        public void CreateReply(string postId, string studentId, string content)
        {
            Debug.Log($"[ForumManager] 답글 작성 - Post ID: {postId}");
            
            ForumReply newReply = new ForumReply
            {
                id = "REPLY_" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper(),
                postId = postId,
                authorId = studentId,
                authorName = "학습자",
                content = content,
                likes = 0,
                createdAt = DateTime.Now,
                likedBy = new List<string>()
            };
            
            StartCoroutine(PostToAPI($"/posts/{postId}/replies", JsonUtility.ToJson(newReply)));
            
            if (!cachedReplies.ContainsKey(postId))
            {
                cachedReplies[postId] = new List<ForumReply>();
            }
            cachedReplies[postId].Add(newReply);
            
            // 게시글 답글 수 증가
            ForumPost post = cachedPosts.Find(p => p.id == postId);
            if (post != null)
            {
                post.replyCount++;
            }
            
            Debug.Log($"[ForumManager] 답글 작성 완료 - ID: {newReply.id}");
        }

        /// <summary>
        /// 게시글 추천
        /// </summary>
        public void LikePost(string postId, string studentId)
        {
            Debug.Log($"[ForumManager] 게시글 추천 - Post ID: {postId}");
            
            ForumPost post = cachedPosts.Find(p => p.id == postId);
            if (post != null && !post.likedBy.Contains(studentId))
            {
                post.likes++;
                post.likedBy.Add(studentId);
                StartCoroutine(PostToAPI($"/posts/{postId}/like", $"{{\"studentId\":\"{studentId}\"}}"));
                Debug.Log($"[ForumManager] 추천 완료 - 총 {post.likes}개");
            }
        }

        /// <summary>
        /// 게시글 북마크
        /// </summary>
        public void BookmarkPost(string postId, string studentId)
        {
            Debug.Log($"[ForumManager] 게시글 북마크 - Post ID: {postId}");
            
            ForumPost post = cachedPosts.Find(p => p.id == postId);
            if (post != null && !post.bookmarkedBy.Contains(studentId))
            {
                post.bookmarkedBy.Add(studentId);
                StartCoroutine(PostToAPI($"/posts/{postId}/bookmark", $"{{\"studentId\":\"{studentId}\"}}"));
                Debug.Log($"[ForumManager] 북마크 완료");
            }
        }

        /// <summary>
        /// 인기 게시글 조회
        /// </summary>
        public List<ForumPost> GetPopularPosts(int limit = 10)
        {
            Debug.Log($"[ForumManager] 인기 게시글 {limit}개 조회");
            
            // 좋아요 + 답글 수로 정렬
            cachedPosts.Sort((a, b) => 
            {
                int scoreA = a.likes * 2 + a.replyCount;
                int scoreB = b.likes * 2 + b.replyCount;
                return scoreB.CompareTo(scoreA);
            });
            
            return cachedPosts.GetRange(0, Math.Min(limit, cachedPosts.Count));
        }

        /// <summary>
        /// 게시글 검색
        /// </summary>
        public List<ForumPost> SearchPosts(string keyword)
        {
            Debug.Log($"[ForumManager] 게시글 검색 - 키워드: {keyword}");
            
            return cachedPosts.FindAll(p => 
                p.title.Contains(keyword) || p.content.Contains(keyword)
            );
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
                    Debug.Log($"[ForumManager] API 요청 성공: {endpoint}");
                }
                else
                {
                    Debug.LogError($"[ForumManager] API 요청 실패: {request.error}");
                }
            }
        }

        /// <summary>
        /// 게시글 상세 조회 (답글 포함)
        /// </summary>
        public void ShowPostDetail(string postId)
        {
            Debug.Log($"[ForumManager] 게시글 상세 조회 - ID: {postId}");
            
            ForumPost post = cachedPosts.Find(p => p.id == postId);
            if (post != null)
            {
                post.views++;
                
                // 답글 로드
                StartCoroutine(LoadReplies(postId));
                
                // UI 표시
                // TODO: 상세 UI 구현
            }
        }

        /// <summary>
        /// 답글 목록 로드
        /// </summary>
        private IEnumerator LoadReplies(string postId)
        {
            string url = $"{apiBaseUrl}/posts/{postId}";
            
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();
                
                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log($"[ForumManager] 답글 로드 완료");
                }
                else
                {
                    Debug.LogError($"[ForumManager] 답글 로드 실패: {request.error}");
                }
            }
        }

        /// <summary>
        /// 내 북마크 게시글 조회
        /// </summary>
        public List<ForumPost> GetMyBookmarks(string studentId)
        {
            return cachedPosts.FindAll(p => p.bookmarkedBy.Contains(studentId));
        }

        /// <summary>
        /// 내가 작성한 게시글 조회
        /// </summary>
        public List<ForumPost> GetMyPosts(string studentId)
        {
            return cachedPosts.FindAll(p => p.authorId == studentId);
        }
    }
}
