# Unity-Backend 통합 가이드

> Unity LMS Frontend와 Node.js/Python Backend를 연결하는 완전한 가이드

**작성일**: 2026년 2월 9일  
**대상**: Unity 개발자, Backend 개발자  
**난이도**: 중급  
**소요 시간**: 2-3시간

---

## 📋 목차

1. [개요](#1-개요)
2. [아키텍처](#2-아키텍처)
3. [환경 설정](#3-환경-설정)
4. [Unity HTTP 통신](#4-unity-http-통신)
5. [API 엔드포인트 연동](#5-api-엔드포인트-연동)
6. [WebView 통합](#6-webview-통합)
7. [실전 예제](#7-실전-예제)
8. [보안 및 인증](#8-보안-및-인증)
9. [에러 처리](#9-에러-처리)
10. [테스트 및 디버깅](#10-테스트-및-디버깅)
11. [문제 해결](#11-문제-해결)

---

## 1. 개요

### 1.1 왜 Frontend-Backend 분리?

**Unity (Frontend)**:
- 게임플레이 로직
- UI/UX 인터랙션
- 실시간 시뮬레이션
- 로컬 상태 관리

**Backend (Node.js/Python)**:
- 데이터 영속성
- 멀티 유저 데이터
- 학습 분석
- 강사 도구

### 1.2 연결 방법

```
Unity (Client)  ←→  Backend (Server)
     ↓                    ↓
  C# HTTP            REST API
UnityWebRequest    Express.js
  JSON Data         Firebase
```

---

## 2. 아키텍처

### 2.1 전체 구조

```
┌─────────────────────────────────────────┐
│         Unity Client (PC/Mac)           │
│  ─────────────────────────────────────  │
│  ┌─────────────────────────────────┐   │
│  │  Unity C# Scripts               │   │
│  │  - TimeManager                  │   │
│  │  - EventManager                 │   │
│  │  - NPCManager                   │   │
│  │  - etc.                         │   │
│  └─────────────────────────────────┘   │
│              ⬇️                          │
│  ┌─────────────────────────────────┐   │
│  │  API Client Service             │   │
│  │  - UnityWebRequest              │   │
│  │  - JSON Serialization           │   │
│  └─────────────────────────────────┘   │
└─────────────────────────────────────────┘
              ⬇️ HTTP/HTTPS
┌─────────────────────────────────────────┐
│      Backend Server (Node.js)           │
│  ─────────────────────────────────────  │
│  ┌─────────────────────────────────┐   │
│  │  Express.js REST API            │   │
│  │  - server.js (강사 대시보드)    │   │
│  │  - qa-board.js (Q&A)           │   │
│  │  - analytics.py (분석)          │   │
│  └─────────────────────────────────┘   │
│              ⬇️                          │
│  ┌─────────────────────────────────┐   │
│  │  Firebase Database              │   │
│  └─────────────────────────────────┘   │
└─────────────────────────────────────────┘
```

### 2.2 데이터 흐름

**학습자 진행 상황 저장**:
```
1. Unity에서 퀴즈 완료
2. C# → JSON 변환
3. HTTP POST → Backend
4. Backend → Firebase 저장
5. 응답 → Unity
6. Unity UI 업데이트
```

---

## 3. 환경 설정

### 3.1 Backend 서버 실행

#### Step 1: Node.js 설치
```bash
# https://nodejs.org/ 에서 LTS 버전 다운로드
node --version  # v18+ 권장
npm --version
```

#### Step 2: Backend 의존성 설치
```bash
cd backend
npm install
```

#### Step 3: 환경 변수 설정
```bash
# .env 파일 생성
cp .env.example .env

# .env 파일 편집
FIREBASE_PROJECT_ID=your-project-id
FIREBASE_SERVICE_ACCOUNT=path/to/serviceAccountKey.json
PORT=3000
```

#### Step 4: 서버 실행
```bash
# 개발 모드 (자동 재시작)
npm run dev

# 또는 프로덕션 모드
npm start
```

**서버 확인**:
- http://localhost:3000
- 응답: `{"status":"ok","message":"PM Expert LMS API Server"}`

### 3.2 Unity 프로젝트 설정

#### Step 1: API URL 설정
```csharp
// Scripts/Config/APIConfig.cs
public static class APIConfig
{
    // 로컬 개발
    public const string BASE_URL = "http://localhost:3000";
    
    // 프로덕션 (배포 시)
    // public const string BASE_URL = "https://api.pmexpert.com";
    
    public const string API_VERSION = "/api";
    
    // 엔드포인트
    public static string INSTRUCTOR_DASHBOARD => $"{BASE_URL}{API_VERSION}/instructor/dashboard";
    public static string QA_QUESTIONS => $"{BASE_URL}{API_VERSION}/qa/questions";
    public static string STUDENT_PROGRESS => $"{BASE_URL}{API_VERSION}/student/progress";
}
```

#### Step 2: CORS 설정 (Backend)
```javascript
// backend/server.js
const cors = require('cors');

app.use(cors({
    origin: ['http://localhost:*', 'unity://'],
    methods: ['GET', 'POST', 'PUT', 'DELETE'],
    allowedHeaders: ['Content-Type', 'Authorization']
}));
```

---

## 4. Unity HTTP 통신

### 4.1 기본 HTTP 클라이언트

#### APIClient.cs - 전체 코드
```csharp
using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace PMExpert.Network
{
    public class APIClient : MonoBehaviour
    {
        private static APIClient _instance;
        public static APIClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new GameObject("APIClient");
                    _instance = go.AddComponent<APIClient>();
                    DontDestroyOnLoad(go);
                }
                return _instance;
            }
        }

        // GET 요청
        public IEnumerator Get(string url, Action<string> onSuccess, Action<string> onError)
        {
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                // 타임아웃 설정
                request.timeout = 10;
                
                // 요청 전송
                yield return request.SendWebRequest();
                
                // 응답 처리
                if (request.result == UnityWebRequest.Result.Success)
                {
                    onSuccess?.Invoke(request.downloadHandler.text);
                }
                else
                {
                    onError?.Invoke($"Error: {request.error}");
                }
            }
        }

        // POST 요청
        public IEnumerator Post(string url, string jsonData, Action<string> onSuccess, Action<string> onError)
        {
            using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
            {
                byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");
                request.timeout = 10;
                
                yield return request.SendWebRequest();
                
                if (request.result == UnityWebRequest.Result.Success)
                {
                    onSuccess?.Invoke(request.downloadHandler.text);
                }
                else
                {
                    onError?.Invoke($"Error: {request.error}");
                }
            }
        }

        // PUT 요청
        public IEnumerator Put(string url, string jsonData, Action<string> onSuccess, Action<string> onError)
        {
            using (UnityWebRequest request = UnityWebRequest.Put(url, jsonData))
            {
                request.SetRequestHeader("Content-Type", "application/json");
                request.timeout = 10;
                
                yield return request.SendWebRequest();
                
                if (request.result == UnityWebRequest.Result.Success)
                {
                    onSuccess?.Invoke(request.downloadHandler.text);
                }
                else
                {
                    onError?.Invoke($"Error: {request.error}");
                }
            }
        }

        // DELETE 요청
        public IEnumerator Delete(string url, Action<string> onSuccess, Action<string> onError)
        {
            using (UnityWebRequest request = UnityWebRequest.Delete(url))
            {
                request.timeout = 10;
                
                yield return request.SendWebRequest();
                
                if (request.result == UnityWebRequest.Result.Success)
                {
                    onSuccess?.Invoke(request.downloadHandler.text);
                }
                else
                {
                    onError?.Invoke($"Error: {request.error}");
                }
            }
        }
    }
}
```

### 4.2 JSON 직렬화/역직렬화

#### 데이터 모델 정의
```csharp
// Scripts/Models/StudentProgress.cs
using System;

[Serializable]
public class StudentProgress
{
    public string studentId;
    public int currentWeek;
    public int overallProgress;
    public float avgQuizScore;
    public int totalStudyTime;
    public string lastAccessDate;
}

[Serializable]
public class APIResponse<T>
{
    public bool success;
    public string message;
    public T data;
}
```

#### JSON 변환
```csharp
// 객체 → JSON
StudentProgress progress = new StudentProgress
{
    studentId = "STU001",
    currentWeek = 5,
    overallProgress = 45
};
string json = JsonUtility.ToJson(progress);

// JSON → 객체
string responseJson = "{\"studentId\":\"STU001\",\"currentWeek\":5}";
StudentProgress data = JsonUtility.FromJson<StudentProgress>(responseJson);
```

---

## 5. API 엔드포인트 연동

### 5.1 강사 대시보드 연동

#### Unity 코드
```csharp
// Scripts/Services/InstructorService.cs
using System;
using System.Collections;
using UnityEngine;

public class InstructorService : MonoBehaviour
{
    // 대시보드 데이터 가져오기
    public void GetDashboardData(Action<DashboardData> onSuccess, Action<string> onError)
    {
        string url = APIConfig.INSTRUCTOR_DASHBOARD;
        
        StartCoroutine(APIClient.Instance.Get(
            url,
            response => {
                DashboardData data = JsonUtility.FromJson<DashboardData>(response);
                onSuccess?.Invoke(data);
            },
            error => {
                Debug.LogError($"Dashboard Error: {error}");
                onError?.Invoke(error);
            }
        ));
    }

    // 위험군 학습자 가져오기
    public void GetAtRiskStudents(Action<AtRiskResponse> onSuccess, Action<string> onError)
    {
        string url = $"{APIConfig.BASE_URL}/api/instructor/at-risk";
        
        StartCoroutine(APIClient.Instance.Get(url, 
            response => {
                AtRiskResponse data = JsonUtility.FromJson<AtRiskResponse>(response);
                onSuccess?.Invoke(data);
            },
            onError
        ));
    }
}

[Serializable]
public class DashboardData
{
    public int totalStudents;
    public int atRiskCount;
    public float avgProgress;
    public StudentSummary[] recentStudents;
}

[Serializable]
public class StudentSummary
{
    public string studentId;
    public string name;
    public int progress;
    public int riskScore;
}

[Serializable]
public class AtRiskResponse
{
    public int count;
    public StudentSummary[] students;
}
```

#### 사용 예제
```csharp
// 강사 대시보드 UI에서 호출
public class InstructorDashboardUI : MonoBehaviour
{
    private InstructorService instructorService;

    void Start()
    {
        instructorService = gameObject.AddComponent<InstructorService>();
        LoadDashboard();
    }

    void LoadDashboard()
    {
        instructorService.GetDashboardData(
            data => {
                Debug.Log($"Total Students: {data.totalStudents}");
                Debug.Log($"At Risk: {data.atRiskCount}");
                UpdateUI(data);
            },
            error => {
                Debug.LogError($"Failed to load dashboard: {error}");
                ShowErrorMessage(error);
            }
        );
    }

    void UpdateUI(DashboardData data)
    {
        // UI 업데이트 로직
        totalStudentsText.text = data.totalStudents.ToString();
        atRiskCountText.text = data.atRiskCount.ToString();
        avgProgressText.text = $"{data.avgProgress:F1}%";
    }

    void ShowErrorMessage(string error)
    {
        errorMessagePanel.SetActive(true);
        errorMessageText.text = error;
    }
}
```

### 5.2 Q&A 게시판 연동

#### Unity 코드
```csharp
// Scripts/Services/QAService.cs
using System;
using System.Collections;
using UnityEngine;

public class QAService : MonoBehaviour
{
    // 질문 목록 가져오기
    public void GetQuestions(int week, string category, Action<QuestionsResponse> onSuccess, Action<string> onError)
    {
        string url = $"{APIConfig.QA_QUESTIONS}?week={week}&category={category}";
        
        StartCoroutine(APIClient.Instance.Get(url,
            response => {
                QuestionsResponse data = JsonUtility.FromJson<QuestionsResponse>(response);
                onSuccess?.Invoke(data);
            },
            onError
        ));
    }

    // 질문 작성
    public void PostQuestion(QuestionData question, Action<QuestionResponse> onSuccess, Action<string> onError)
    {
        string url = APIConfig.QA_QUESTIONS;
        string json = JsonUtility.ToJson(question);
        
        StartCoroutine(APIClient.Instance.Post(url, json,
            response => {
                QuestionResponse data = JsonUtility.FromJson<QuestionResponse>(response);
                onSuccess?.Invoke(data);
            },
            onError
        ));
    }

    // 답변 작성
    public void PostAnswer(string questionId, AnswerData answer, Action<AnswerResponse> onSuccess, Action<string> onError)
    {
        string url = $"{APIConfig.QA_QUESTIONS}/{questionId}/answers";
        string json = JsonUtility.ToJson(answer);
        
        StartCoroutine(APIClient.Instance.Post(url, json,
            response => {
                AnswerResponse data = JsonUtility.FromJson<AnswerResponse>(response);
                onSuccess?.Invoke(data);
            },
            onError
        ));
    }
}

[Serializable]
public class QuestionData
{
    public string studentId;
    public int week;
    public string category;
    public string title;
    public string content;
}

[Serializable]
public class AnswerData
{
    public string authorId;
    public string content;
}

[Serializable]
public class QuestionsResponse
{
    public int count;
    public Question[] questions;
}

[Serializable]
public class Question
{
    public string id;
    public string title;
    public string content;
    public string authorName;
    public int answerCount;
    public string createdAt;
}

[Serializable]
public class QuestionResponse
{
    public bool success;
    public string questionId;
    public string message;
}

[Serializable]
public class AnswerResponse
{
    public bool success;
    public string answerId;
    public string message;
}
```

### 5.3 학습 진행 상황 저장

#### Unity 코드
```csharp
// Scripts/Services/ProgressService.cs
using System;
using System.Collections;
using UnityEngine;

public class ProgressService : MonoBehaviour
{
    // 진행 상황 저장
    public void SaveProgress(StudentProgress progress, Action onSuccess, Action<string> onError)
    {
        string url = $"{APIConfig.STUDENT_PROGRESS}/{progress.studentId}";
        string json = JsonUtility.ToJson(progress);
        
        StartCoroutine(APIClient.Instance.Put(url, json,
            response => {
                Debug.Log("Progress saved successfully");
                onSuccess?.Invoke();
            },
            onError
        ));
    }

    // 퀴즈 점수 저장
    public void SaveQuizScore(string studentId, int week, float score, Action onSuccess, Action<string> onError)
    {
        QuizScore quizData = new QuizScore
        {
            studentId = studentId,
            week = week,
            score = score,
            completedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        };
        
        string url = $"{APIConfig.BASE_URL}/api/quiz/score";
        string json = JsonUtility.ToJson(quizData);
        
        StartCoroutine(APIClient.Instance.Post(url, json, 
            response => onSuccess?.Invoke(),
            onError
        ));
    }

    // 시뮬레이터 결과 저장
    public void SaveSimulationResult(string studentId, SimulationResult result, Action onSuccess, Action<string> onError)
    {
        string url = $"{APIConfig.BASE_URL}/api/simulation/result";
        result.studentId = studentId;
        string json = JsonUtility.ToJson(result);
        
        StartCoroutine(APIClient.Instance.Post(url, json,
            response => onSuccess?.Invoke(),
            onError
        ));
    }
}

[Serializable]
public class QuizScore
{
    public string studentId;
    public int week;
    public float score;
    public string completedAt;
}

[Serializable]
public class SimulationResult
{
    public string studentId;
    public int week;
    public string scenarioId;
    public int finalScore;
    public int scheduleMetric;
    public int budgetMetric;
    public int qualityMetric;
    public int teamMoraleMetric;
    public string completedAt;
}
```

---

## 6. WebView 통합

### 6.1 WebViewManager 사용

이미 구현된 `WebViewManager.cs`를 사용하여 웹 콘텐츠를 Unity 내에서 표시:

```csharp
// 강사 대시보드 열기
WebViewManager.Instance.ShowInstructorDashboard();

// Q&A 게시판 열기
WebViewManager.Instance.ShowQABoard(5); // Week 5

// 특정 URL 열기
WebViewManager.Instance.OpenURL("http://localhost:3000/dashboard");
```

### 6.2 Unity → WebView 메시지

```csharp
// Unity에서 WebView로 데이터 전송
string message = JsonUtility.ToJson(new {
    type = "updateProgress",
    data = new { week = 5, progress = 75 }
});

WebViewManager.Instance.SendMessageToWebView(message);
```

### 6.3 WebView → Unity 메시지

#### JavaScript (웹 페이지)
```javascript
// 웹에서 Unity로 메시지 전송
function sendToUnity(type, data) {
    const message = JSON.stringify({ type, data });
    
    // UniWebView (유료)
    if (window.webkit && window.webkit.messageHandlers.unityControl) {
        window.webkit.messageHandlers.unityControl.postMessage(message);
    }
    // Android WebView
    else if (window.UnityInterface) {
        window.UnityInterface.receiveMessage(message);
    }
    // PC/Mac (기본 브라우저)
    else {
        console.log('Unity message:', message);
    }
}

// 사용 예
sendToUnity('questionPosted', { questionId: 'Q123' });
```

#### Unity C# (메시지 수신)
```csharp
// WebViewManager.cs 내부
public void ReceiveMessageFromWebView(string jsonMessage)
{
    WebMessage message = JsonUtility.FromJson<WebMessage>(jsonMessage);
    
    switch (message.type)
    {
        case "questionPosted":
            OnQuestionPosted(message.data);
            break;
        case "answerSubmitted":
            OnAnswerSubmitted(message.data);
            break;
        default:
            Debug.LogWarning($"Unknown message type: {message.type}");
            break;
    }
}

[Serializable]
public class WebMessage
{
    public string type;
    public string data; // JSON string
}
```

---

## 7. 실전 예제

### 7.1 시나리오: 퀴즈 완료 후 점수 저장

#### Unity 코드 (전체 플로우)
```csharp
// QuizManager.cs
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    private ProgressService progressService;
    private string currentStudentId = "STU001";
    private int currentWeek = 5;

    void Start()
    {
        progressService = gameObject.AddComponent<ProgressService>();
    }

    // 퀴즈 완료 시 호출
    public void OnQuizCompleted(float score)
    {
        Debug.Log($"Quiz completed! Score: {score}");
        
        // UI에 로딩 표시
        ShowLoadingIndicator();
        
        // 백엔드에 점수 저장
        progressService.SaveQuizScore(
            currentStudentId,
            currentWeek,
            score,
            onSuccess: () => {
                HideLoadingIndicator();
                ShowSuccessMessage($"점수 저장 완료: {score}점");
                
                // 다음 단계로 이동
                GoToNextWeek();
            },
            onError: error => {
                HideLoadingIndicator();
                ShowErrorMessage($"점수 저장 실패: {error}");
                
                // 재시도 옵션 제공
                ShowRetryButton();
            }
        );
    }

    void ShowLoadingIndicator()
    {
        loadingPanel.SetActive(true);
    }

    void HideLoadingIndicator()
    {
        loadingPanel.SetActive(false);
    }

    void ShowSuccessMessage(string message)
    {
        successMessageText.text = message;
        successMessagePanel.SetActive(true);
    }

    void ShowErrorMessage(string message)
    {
        errorMessageText.text = message;
        errorMessagePanel.SetActive(true);
    }

    void ShowRetryButton()
    {
        retryButton.SetActive(true);
        retryButton.onClick.AddListener(() => OnQuizCompleted(lastScore));
    }
}
```

### 7.2 시나리오: 강사가 위험군 학습자 확인

#### Unity 코드
```csharp
// InstructorDashboardController.cs
using UnityEngine;
using UnityEngine.UI;

public class InstructorDashboardController : MonoBehaviour
{
    public Text totalStudentsText;
    public Text atRiskCountText;
    public Transform studentListContent;
    public GameObject studentCardPrefab;

    private InstructorService instructorService;

    void Start()
    {
        instructorService = gameObject.AddComponent<InstructorService>();
        RefreshDashboard();
    }

    public void RefreshDashboard()
    {
        // 대시보드 데이터 로드
        instructorService.GetDashboardData(
            data => {
                UpdateDashboardUI(data);
                LoadAtRiskStudents();
            },
            error => {
                Debug.LogError($"Dashboard load failed: {error}");
            }
        );
    }

    void UpdateDashboardUI(DashboardData data)
    {
        totalStudentsText.text = $"전체 학습자: {data.totalStudents}명";
        atRiskCountText.text = $"위험군: {data.atRiskCount}명";
    }

    void LoadAtRiskStudents()
    {
        instructorService.GetAtRiskStudents(
            data => {
                DisplayStudentList(data.students);
            },
            error => {
                Debug.LogError($"At-risk students load failed: {error}");
            }
        );
    }

    void DisplayStudentList(StudentSummary[] students)
    {
        // 기존 카드 삭제
        foreach (Transform child in studentListContent)
        {
            Destroy(child.gameObject);
        }

        // 새 카드 생성
        foreach (var student in students)
        {
            GameObject card = Instantiate(studentCardPrefab, studentListContent);
            
            Text nameText = card.transform.Find("NameText").GetComponent<Text>();
            Text progressText = card.transform.Find("ProgressText").GetComponent<Text>();
            Text riskText = card.transform.Find("RiskText").GetComponent<Text>();
            Button detailButton = card.transform.Find("DetailButton").GetComponent<Button>();
            
            nameText.text = student.name;
            progressText.text = $"진행률: {student.progress}%";
            riskText.text = $"위험도: {student.riskScore}";
            
            // 상세 보기 버튼
            detailButton.onClick.AddListener(() => ShowStudentDetail(student.studentId));
        }
    }

    void ShowStudentDetail(string studentId)
    {
        // 학습자 상세 페이지로 이동
        Debug.Log($"Show detail for: {studentId}");
    }
}
```

### 7.3 시나리오: Q&A 질문 작성

#### Unity 코드
```csharp
// QABoardController.cs
using UnityEngine;
using UnityEngine.UI;

public class QABoardController : MonoBehaviour
{
    public InputField titleInput;
    public InputField contentInput;
    public Dropdown categoryDropdown;
    public Button submitButton;

    private QAService qaService;
    private string studentId = "STU001";
    private int currentWeek = 5;

    void Start()
    {
        qaService = gameObject.AddComponent<QAService>();
        submitButton.onClick.AddListener(SubmitQuestion);
    }

    void SubmitQuestion()
    {
        string title = titleInput.text;
        string content = contentInput.text;
        string category = categoryDropdown.options[categoryDropdown.value].text;

        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
        {
            ShowError("제목과 내용을 입력해주세요.");
            return;
        }

        QuestionData question = new QuestionData
        {
            studentId = studentId,
            week = currentWeek,
            category = category,
            title = title,
            content = content
        };

        submitButton.interactable = false;

        qaService.PostQuestion(
            question,
            response => {
                submitButton.interactable = true;
                ShowSuccess("질문이 등록되었습니다!");
                ClearForm();
                RefreshQuestionList();
            },
            error => {
                submitButton.interactable = true;
                ShowError($"질문 등록 실패: {error}");
            }
        );
    }

    void ShowSuccess(string message)
    {
        Debug.Log(message);
        // UI 업데이트
    }

    void ShowError(string message)
    {
        Debug.LogError(message);
        // UI 업데이트
    }

    void ClearForm()
    {
        titleInput.text = "";
        contentInput.text = "";
    }

    void RefreshQuestionList()
    {
        // 질문 목록 새로고침
    }
}
```

---

## 8. 보안 및 인증

### 8.1 API Key 인증

#### Backend (server.js)
```javascript
// API Key 미들웨어
const apiKeyAuth = (req, res, next) => {
    const apiKey = req.headers['x-api-key'];
    
    if (!apiKey || apiKey !== process.env.API_KEY) {
        return res.status(401).json({ error: 'Unauthorized' });
    }
    
    next();
};

// 보호된 라우트에 적용
app.use('/api/instructor', apiKeyAuth);
```

#### Unity
```csharp
// API Key 추가
public IEnumerator GetWithAuth(string url, string apiKey, Action<string> onSuccess, Action<string> onError)
{
    using (UnityWebRequest request = UnityWebRequest.Get(url))
    {
        request.SetRequestHeader("X-API-Key", apiKey);
        request.timeout = 10;
        
        yield return request.SendWebRequest();
        
        if (request.result == UnityWebRequest.Result.Success)
        {
            onSuccess?.Invoke(request.downloadHandler.text);
        }
        else
        {
            onError?.Invoke($"Error: {request.error}");
        }
    }
}
```

### 8.2 JWT 토큰 인증

#### Backend
```javascript
const jwt = require('jsonwebtoken');

// 로그인
app.post('/api/auth/login', async (req, res) => {
    const { username, password } = req.body;
    
    // 사용자 확인 (간략화)
    const user = await verifyUser(username, password);
    
    if (!user) {
        return res.status(401).json({ error: 'Invalid credentials' });
    }
    
    // JWT 토큰 생성
    const token = jwt.sign(
        { userId: user.id, role: user.role },
        process.env.JWT_SECRET,
        { expiresIn: '24h' }
    );
    
    res.json({ token, user: { id: user.id, name: user.name } });
});

// JWT 검증 미들웨어
const jwtAuth = (req, res, next) => {
    const token = req.headers['authorization']?.split(' ')[1];
    
    if (!token) {
        return res.status(401).json({ error: 'No token provided' });
    }
    
    try {
        const decoded = jwt.verify(token, process.env.JWT_SECRET);
        req.user = decoded;
        next();
    } catch (error) {
        res.status(401).json({ error: 'Invalid token' });
    }
};
```

#### Unity
```csharp
// AuthService.cs
public class AuthService : MonoBehaviour
{
    private string authToken;

    public void Login(string username, string password, Action<LoginResponse> onSuccess, Action<string> onError)
    {
        string url = $"{APIConfig.BASE_URL}/api/auth/login";
        
        LoginRequest loginData = new LoginRequest
        {
            username = username,
            password = password
        };
        
        string json = JsonUtility.ToJson(loginData);
        
        StartCoroutine(APIClient.Instance.Post(url, json,
            response => {
                LoginResponse data = JsonUtility.FromJson<LoginResponse>(response);
                authToken = data.token;
                PlayerPrefs.SetString("AuthToken", authToken);
                onSuccess?.Invoke(data);
            },
            onError
        ));
    }

    public IEnumerator GetWithToken(string url, Action<string> onSuccess, Action<string> onError)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            string token = PlayerPrefs.GetString("AuthToken", "");
            request.SetRequestHeader("Authorization", $"Bearer {token}");
            
            yield return request.SendWebRequest();
            
            if (request.result == UnityWebRequest.Result.Success)
            {
                onSuccess?.Invoke(request.downloadHandler.text);
            }
            else
            {
                onError?.Invoke($"Error: {request.error}");
            }
        }
    }
}

[Serializable]
public class LoginRequest
{
    public string username;
    public string password;
}

[Serializable]
public class LoginResponse
{
    public string token;
    public UserInfo user;
}

[Serializable]
public class UserInfo
{
    public string id;
    public string name;
    public string role;
}
```

---

## 9. 에러 처리

### 9.1 네트워크 에러

```csharp
// NetworkErrorHandler.cs
using UnityEngine;
using UnityEngine.Networking;

public class NetworkErrorHandler
{
    public static void HandleError(UnityWebRequest.Result result, string error, string url)
    {
        switch (result)
        {
            case UnityWebRequest.Result.ConnectionError:
                Debug.LogError($"Connection Error: {error}\nURL: {url}");
                ShowMessage("서버 연결 실패. 네트워크 연결을 확인해주세요.");
                break;
                
            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError($"Protocol Error: {error}\nURL: {url}");
                
                // HTTP 상태 코드별 처리
                if (error.Contains("404"))
                {
                    ShowMessage("요청한 리소스를 찾을 수 없습니다.");
                }
                else if (error.Contains("401"))
                {
                    ShowMessage("인증이 필요합니다. 다시 로그인해주세요.");
                    // 로그인 화면으로 이동
                }
                else if (error.Contains("500"))
                {
                    ShowMessage("서버 오류가 발생했습니다. 잠시 후 다시 시도해주세요.");
                }
                break;
                
            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError($"Data Processing Error: {error}\nURL: {url}");
                ShowMessage("데이터 처리 중 오류가 발생했습니다.");
                break;
                
            default:
                Debug.LogError($"Unknown Error: {error}\nURL: {url}");
                ShowMessage("알 수 없는 오류가 발생했습니다.");
                break;
        }
    }

    private static void ShowMessage(string message)
    {
        // UI에 에러 메시지 표시
        Debug.LogWarning(message);
    }
}
```

### 9.2 재시도 로직

```csharp
// RetryableRequest.cs
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RetryableRequest : MonoBehaviour
{
    private const int MAX_RETRIES = 3;
    private const float RETRY_DELAY = 2f;

    public IEnumerator GetWithRetry(string url, Action<string> onSuccess, Action<string> onError)
    {
        int retryCount = 0;
        
        while (retryCount < MAX_RETRIES)
        {
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();
                
                if (request.result == UnityWebRequest.Result.Success)
                {
                    onSuccess?.Invoke(request.downloadHandler.text);
                    yield break; // 성공 시 종료
                }
                else
                {
                    retryCount++;
                    Debug.LogWarning($"Request failed. Retry {retryCount}/{MAX_RETRIES}");
                    
                    if (retryCount < MAX_RETRIES)
                    {
                        yield return new WaitForSeconds(RETRY_DELAY * retryCount);
                    }
                    else
                    {
                        onError?.Invoke($"Request failed after {MAX_RETRIES} retries");
                    }
                }
            }
        }
    }
}
```

---

## 10. 테스트 및 디버깅

### 10.1 Backend 테스트 (Postman/cURL)

#### cURL 예제
```bash
# 강사 대시보드 조회
curl -X GET http://localhost:3000/api/instructor/dashboard

# 질문 작성
curl -X POST http://localhost:3000/api/qa/questions \
  -H "Content-Type: application/json" \
  -d '{
    "studentId": "STU001",
    "week": 5,
    "category": "technical",
    "title": "테스트 질문",
    "content": "이것은 테스트 질문입니다."
  }'

# 퀴즈 점수 저장
curl -X POST http://localhost:3000/api/quiz/score \
  -H "Content-Type: application/json" \
  -d '{
    "studentId": "STU001",
    "week": 5,
    "score": 85,
    "completedAt": "2026-02-09 10:30:00"
  }'
```

### 10.2 Unity 디버그 로그

```csharp
// DebugAPIClient.cs
public class DebugAPIClient : APIClient
{
    public new IEnumerator Get(string url, Action<string> onSuccess, Action<string> onError)
    {
        Debug.Log($"[API] GET Request: {url}");
        
        yield return base.Get(
            url,
            response => {
                Debug.Log($"[API] GET Response: {response}");
                onSuccess?.Invoke(response);
            },
            error => {
                Debug.LogError($"[API] GET Error: {error}");
                onError?.Invoke(error);
            }
        );
    }

    public new IEnumerator Post(string url, string jsonData, Action<string> onSuccess, Action<string> onError)
    {
        Debug.Log($"[API] POST Request: {url}");
        Debug.Log($"[API] POST Body: {jsonData}");
        
        yield return base.Post(
            url,
            jsonData,
            response => {
                Debug.Log($"[API] POST Response: {response}");
                onSuccess?.Invoke(response);
            },
            error => {
                Debug.LogError($"[API] POST Error: {error}");
                onError?.Invoke(error);
            }
        );
    }
}
```

### 10.3 Mock 서버 (개발 중)

Backend가 준비되지 않았을 때 사용:

```csharp
// MockAPIService.cs
public class MockAPIService : MonoBehaviour
{
    public IEnumerator GetDashboardData(Action<string> onSuccess)
    {
        yield return new WaitForSeconds(0.5f); // 네트워크 지연 시뮬레이션
        
        string mockData = @"{
            ""totalStudents"": 50,
            ""atRiskCount"": 5,
            ""avgProgress"": 67.5,
            ""recentStudents"": [
                {""studentId"":""STU001"",""name"":""김철수"",""progress"":85,""riskScore"":10},
                {""studentId"":""STU002"",""name"":""이영희"",""progress"":45,""riskScore"":60}
            ]
        }";
        
        onSuccess?.Invoke(mockData);
    }
}
```

---

## 11. 문제 해결

### 11.1 CORS 오류

**증상**: Unity에서 API 요청 시 "CORS policy" 오류

**해결**:
```javascript
// backend/server.js
const cors = require('cors');

app.use(cors({
    origin: '*', // 개발 시에는 모든 origin 허용
    methods: ['GET', 'POST', 'PUT', 'DELETE'],
    allowedHeaders: ['Content-Type', 'Authorization']
}));
```

### 11.2 Timeout 오류

**증상**: 요청이 오래 걸려서 타임아웃

**해결**:
```csharp
// 타임아웃 시간 늘리기
request.timeout = 30; // 30초

// 또는 무제한
request.timeout = 0;
```

### 11.3 JSON 파싱 오류

**증상**: `JsonUtility.FromJson` 실패

**해결**:
```csharp
try
{
    MyData data = JsonUtility.FromJson<MyData>(json);
}
catch (Exception e)
{
    Debug.LogError($"JSON Parse Error: {e.Message}");
    Debug.LogError($"JSON: {json}");
}
```

### 11.4 서버 연결 실패

**체크리스트**:
1. Backend 서버가 실행 중인지 확인
   ```bash
   curl http://localhost:3000
   ```

2. 방화벽 확인
   - Windows: 포트 3000 허용
   - Mac: 시스템 환경설정 → 보안

3. URL 확인
   - `http://localhost:3000` (로컬)
   - `http://192.168.x.x:3000` (같은 네트워크)
   - `https://api.yourdomain.com` (프로덕션)

---

## 📋 체크리스트

### Backend 준비
- [ ] Node.js 설치 (v18+)
- [ ] `npm install` 실행
- [ ] `.env` 파일 설정
- [ ] Firebase 설정
- [ ] 서버 실행 확인 (`npm start`)
- [ ] API 테스트 (Postman/cURL)

### Unity 설정
- [ ] APIConfig.cs 생성
- [ ] BASE_URL 설정
- [ ] APIClient.cs 추가
- [ ] 서비스 클래스 생성 (InstructorService, QAService 등)
- [ ] JSON 모델 정의

### 통합 테스트
- [ ] GET 요청 테스트
- [ ] POST 요청 테스트
- [ ] 에러 처리 테스트
- [ ] 재시도 로직 테스트
- [ ] WebView 통합 테스트

### 보안
- [ ] API Key 설정
- [ ] HTTPS 사용 (프로덕션)
- [ ] 민감한 데이터 암호화
- [ ] 토큰 만료 처리

---

## 🚀 다음 단계

1. **Backend 서버 실행**
   ```bash
   cd backend
   npm install
   npm start
   ```

2. **Unity에서 테스트**
   - APIClient 테스트 씬 만들기
   - 간단한 GET/POST 요청 테스트
   - 응답 확인

3. **실제 기능 통합**
   - 강사 대시보드
   - Q&A 게시판
   - 진행 상황 저장

4. **배포 준비**
   - 프로덕션 URL 설정
   - HTTPS 적용
   - 에러 로깅
   - 성능 최적화

---

## 📚 참고 자료

**Unity 네트워크**:
- https://docs.unity3d.com/ScriptReference/Networking.UnityWebRequest.html
- https://docs.unity3d.com/Manual/webgl-networking.html

**Node.js/Express**:
- https://expressjs.com/
- https://firebase.google.com/docs

**REST API 설계**:
- https://restfulapi.net/

---

## 💡 요약

이 가이드를 따라하면:

✅ Unity와 Backend를 HTTP REST API로 연결  
✅ 데이터를 JSON으로 주고받기  
✅ WebView로 웹 콘텐츠 통합  
✅ 에러 처리 및 재시도 로직  
✅ 보안 및 인증 구현  

**Unity(Frontend)**와 **Backend(Server)**가 완벽하게 연동됩니다!

**질문이나 문제가 있으면 언제든 물어보세요!** 😊
