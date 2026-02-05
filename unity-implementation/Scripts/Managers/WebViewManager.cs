using UnityEngine;
using System;

namespace PMExpert.Integration
{
    /// <summary>
    /// Unity WebView 통합 - 강사 대시보드 및 Q&A 게시판
    /// 
    /// 필요 패키지: UniWebView (Asset Store)
    /// 또는 무료 대안: gree-unity-webview
    /// </summary>
    public class WebViewManager : MonoBehaviour
    {
        private static WebViewManager _instance;
        public static WebViewManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new GameObject("WebViewManager");
                    _instance = go.AddComponent<WebViewManager>();
                    DontDestroyOnLoad(go);
                }
                return _instance;
            }
        }

        [Header("Backend Settings")]
        [SerializeField] private string backendURL = "http://localhost:3000";
        [SerializeField] private bool useLocalBackend = true;
        [SerializeField] private string productionURL = "https://api.pm-expert.com";

        private GameObject webViewObject;
        
        // UniWebView 사용 시 (유료 에셋)
        // private UniWebView webView;

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

        /// <summary>
        /// 강사 대시보드 표시
        /// </summary>
        public void ShowInstructorDashboard()
        {
            string url = GetBaseURL() + "/dashboard.html";
            Debug.Log($"[WebViewManager] Opening Instructor Dashboard: {url}");
            
            OpenWebView(url, "강사 대시보드");
        }

        /// <summary>
        /// Q&A 게시판 표시
        /// </summary>
        /// <param name="weekNumber">특정 주차 (0 = 전체)</param>
        public void ShowQABoard(int weekNumber = 0)
        {
            string url = GetBaseURL() + "/qa.html";
            if (weekNumber > 0)
            {
                url += $"?week={weekNumber}";
            }
            
            Debug.Log($"[WebViewManager] Opening Q&A Board: {url}");
            OpenWebView(url, "Q&A 게시판");
        }

        /// <summary>
        /// 개별 학습자 상세 정보 표시
        /// </summary>
        /// <param name="studentId">학습자 ID</param>
        public void ShowStudentDetail(string studentId)
        {
            string url = GetBaseURL() + $"/student.html?id={studentId}";
            Debug.Log($"[WebViewManager] Opening Student Detail: {url}");
            
            OpenWebView(url, "학습자 정보");
        }

        /// <summary>
        /// WebView 열기 (플랫폼별 구현)
        /// </summary>
        private void OpenWebView(string url, string title)
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            // PC: 기본 브라우저 열기
            Application.OpenURL(url);
            Debug.Log($"[WebViewManager] Opening in default browser: {url}");
            
#elif UNITY_ANDROID || UNITY_IOS
            // 모바일: UniWebView 사용 (유료 에셋)
            // 또는 gree-unity-webview (무료)
            
            /* UniWebView 예시:
            if (webView == null)
            {
                webView = gameObject.AddComponent<UniWebView>();
                webView.Frame = new Rect(0, 0, Screen.width, Screen.height);
                
                // 이벤트
                webView.OnPageFinished += (view, statusCode, url) =>
                {
                    Debug.Log($"Page loaded: {url}");
                };
                
                webView.OnShouldClose += (view) =>
                {
                    webView = null;
                    return true;
                };
            }
            
            webView.Load(url);
            webView.Show();
            */
            
            // 임시: 모바일도 브라우저로 열기
            Application.OpenURL(url);
            Debug.LogWarning("[WebViewManager] Mobile WebView not configured. Opening in browser.");
            
#elif UNITY_WEBGL
            // WebGL: iframe 또는 새 탭
            Application.ExternalEval($"window.open('{url}', '_blank');");
            Debug.Log($"[WebViewManager] Opening in new tab: {url}");
#endif
        }

        /// <summary>
        /// WebView 닫기
        /// </summary>
        public void CloseWebView()
        {
            /* UniWebView 사용 시:
            if (webView != null)
            {
                webView.Hide();
                webView.CleanCache();
                Destroy(webView);
                webView = null;
            }
            */
            
            Debug.Log("[WebViewManager] WebView closed");
        }

        /// <summary>
        /// Backend URL 가져오기
        /// </summary>
        private string GetBaseURL()
        {
            return useLocalBackend ? backendURL : productionURL;
        }

        /// <summary>
        /// Unity와 WebView 간 메시지 통신
        /// </summary>
        /// <param name="message">JSON 메시지</param>
        public void SendMessageToWebView(string message)
        {
            /* UniWebView 사용 시:
            if (webView != null)
            {
                // JavaScript 함수 호출
                webView.EvaluateJavaScript($"receiveFromUnity('{message}');", (payload) =>
                {
                    Debug.Log($"WebView response: {payload.data}");
                });
            }
            */
            
            Debug.Log($"[WebViewManager] Sending message to WebView: {message}");
        }

        /// <summary>
        /// WebView에서 Unity로 메시지 받기
        /// (WebView에서 호출)
        /// </summary>
        /// <param name="message">JSON 메시지</param>
        public void ReceiveMessageFromWebView(string message)
        {
            Debug.Log($"[WebViewManager] Received message from WebView: {message}");
            
            // JSON 파싱 및 처리
            try
            {
                // 예: {"action": "close_webview"}
                // 예: {"action": "student_selected", "studentId": "STU001"}
                
                // 실제 구현에서는 JSON 파싱 라이브러리 사용
                if (message.Contains("close_webview"))
                {
                    CloseWebView();
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"[WebViewManager] Message parsing error: {e.Message}");
            }
        }

        // ==========================================
        // 테스트용 메서드
        // ==========================================

        [ContextMenu("Test: Open Instructor Dashboard")]
        private void TestInstructorDashboard()
        {
            ShowInstructorDashboard();
        }

        [ContextMenu("Test: Open Q&A Board")]
        private void TestQABoard()
        {
            ShowQABoard();
        }

        [ContextMenu("Test: Open Q&A Week 5")]
        private void TestQAWeek5()
        {
            ShowQABoard(5);
        }

        [ContextMenu("Test: Close WebView")]
        private void TestCloseWebView()
        {
            CloseWebView();
        }
    }
}
