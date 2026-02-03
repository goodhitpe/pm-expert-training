# 🔧 Unity LMS 및 프로젝트 시뮬레이터 - 기술 사양서

> **버전**: 1.0  
> **작성일**: 2025년 2월 3일  
> **참조 문서**: UNITY_LMS_PHASE1_REQUIREMENTS.md

---

## 1. 시스템 아키텍처

### 1.1 전체 구조도

```
┌─────────────────────────────────────────────────────────┐
│                    Unity Application                     │
├─────────────────────────────────────────────────────────┤
│  ┌──────────────────┐         ┌────────────────────┐   │
│  │   LMS Module     │◄────────┤  Simulator Module  │   │
│  │                  │         │                    │   │
│  │ - Content Viewer │         │ - 3D Environment   │   │
│  │ - Progress Track │         │ - NPC System       │   │
│  │ - Quiz System    │         │ - Decision Engine  │   │
│  └────────┬─────────┘         └─────────┬──────────┘   │
│           │                             │              │
│  ┌────────▼─────────────────────────────▼──────────┐   │
│  │          Core Systems & Data Layer              │   │
│  │                                                  │   │
│  │  - Data Manager  - Save System                  │   │
│  │  - Event Bus     - Scene Manager                │   │
│  │  - UI Manager    - Audio Manager                │   │
│  └──────────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────────┘
           │                            │
           ▼                            ▼
    ┌─────────────┐            ┌─────────────┐
    │  Markdown   │            │  User Data  │
    │  Content    │            │  (Local)    │
    │  (JSON)     │            │  (JSON)     │
    └─────────────┘            └─────────────┘
```

### 1.2 레이어 구조

**Presentation Layer** (UI):
- Unity UI Canvas
- TextMesh Pro
- 사용자 입력 처리

**Business Logic Layer**:
- 학습 진행률 관리
- 시뮬레이션 로직
- 의사결정 엔진
- 평가 시스템

**Data Access Layer**:
- 로컬 파일 시스템 접근
- JSON 직렬화/역직렬화
- 캐싱 시스템

**Data Layer**:
- 커리큘럼 데이터 (Resources/Addressables)
- 사용자 진행률 (PlayerPrefs + JSON)
- 게임 상태 (ScriptableObjects)

---

## 2. 핵심 시스템 설계

### 2.1 Data Manager

**책임**:
- 커리큘럼 데이터 로딩 및 캐싱
- 사용자 진행률 관리
- 데이터 동기화

**주요 클래스**:
```csharp
public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    
    // 커리큘럼 데이터
    public CurriculumData Curriculum { get; private set; }
    
    // 사용자 데이터
    public UserProgressData UserProgress { get; private set; }
    
    // 초기화
    public async Task InitializeAsync()
    {
        await LoadCurriculumData();
        await LoadUserProgress();
    }
    
    // 커리큘럼 로딩
    private async Task LoadCurriculumData()
    {
        // Resources 또는 Addressables에서 로딩
    }
    
    // 진행률 저장
    public void SaveProgress()
    {
        // JSON으로 직렬화 후 로컬 저장
    }
}

// 데이터 모델
[System.Serializable]
public class CurriculumData
{
    public List<WeekData> weeks;
}

[System.Serializable]
public class WeekData
{
    public int weekNumber;
    public string phase;
    public string title;
    public ContentData content;
    public QuizData quiz;
    public RubricData rubric;
    public bool simulationUnlocked;
}

[System.Serializable]
public class UserProgressData
{
    public string userId;
    public int currentWeek;
    public List<int> completedWeeks;
    public Dictionary<int, int> quizScores;
    public List<string> simulationsCompleted;
    public List<string> badges;
    public float totalStudyTime;
}
```

### 2.2 Scene Manager

**책임**:
- 씬 전환 관리
- 로딩 화면 처리
- 씬 간 데이터 전달

**주요 클래스**:
```csharp
public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }
    
    // 씬 전환
    public async Task LoadSceneAsync(string sceneName, object context = null)
    {
        // 페이드 아웃
        await FadeOut();
        
        // 로딩 화면 표시
        ShowLoadingScreen();
        
        // 씬 로드
        await UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        
        // 컨텍스트 전달
        if (context != null)
            PassContextToScene(context);
        
        // 페이드 인
        await FadeIn();
    }
}
```

### 2.3 Event Bus (옵저버 패턴)

**책임**:
- 컴포넌트 간 느슨한 결합 통신
- 이벤트 발행/구독 관리

**주요 클래스**:
```csharp
public class EventBus : MonoBehaviour
{
    public static EventBus Instance { get; private set; }
    
    private Dictionary<string, List<Action<object>>> eventListeners = new();
    
    // 이벤트 구독
    public void Subscribe(string eventName, Action<object> callback)
    {
        if (!eventListeners.ContainsKey(eventName))
            eventListeners[eventName] = new List<Action<object>>();
        
        eventListeners[eventName].Add(callback);
    }
    
    // 이벤트 발행
    public void Publish(string eventName, object data = null)
    {
        if (eventListeners.ContainsKey(eventName))
        {
            foreach (var callback in eventListeners[eventName])
                callback?.Invoke(data);
        }
    }
    
    // 구독 해제
    public void Unsubscribe(string eventName, Action<object> callback)
    {
        if (eventListeners.ContainsKey(eventName))
            eventListeners[eventName].Remove(callback);
    }
}

// 이벤트 타입
public static class GameEvents
{
    public const string WEEK_COMPLETED = "WeekCompleted";
    public const string QUIZ_SUBMITTED = "QuizSubmitted";
    public const string SIMULATION_STARTED = "SimulationStarted";
    public const string DECISION_MADE = "DecisionMade";
    public const string PROGRESS_SAVED = "ProgressSaved";
}
```

---

## 3. LMS 모듈 설계

### 3.1 콘텐츠 뷰어 시스템

**마크다운 렌더링**:
```csharp
public class MarkdownViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text contentText;
    [SerializeField] private ScrollRect scrollRect;
    
    // 마크다운 파싱 및 표시
    public void DisplayMarkdown(string markdownContent)
    {
        // 마크다운을 TextMeshPro 태그로 변환
        string parsedContent = ParseMarkdownToTMP(markdownContent);
        contentText.text = parsedContent;
    }
    
    private string ParseMarkdownToTMP(string markdown)
    {
        // 헤더: # → <size=32><b>
        // 볼드: **text** → <b>text</b>
        // 이탤릭: *text* → <i>text</i>
        // 코드: `code` → <color=#00FF00>code</color>
        // 링크: [text](url) → <link="url">text</link>
        // 등등...
        
        return processedMarkdown;
    }
}
```

**옵션 라이브러리**:
- **Markdig** (C# 마크다운 파서)
- **Unity Markdown Viewer** (에셋 스토어)
- **Custom Parser** (TextMeshPro 태그 변환)

### 3.2 진행률 추적 시스템

```csharp
public class ProgressTracker : MonoBehaviour
{
    // 주차 완료 체크
    public void CompleteWeek(int weekNumber)
    {
        if (!DataManager.Instance.UserProgress.completedWeeks.Contains(weekNumber))
        {
            DataManager.Instance.UserProgress.completedWeeks.Add(weekNumber);
            DataManager.Instance.UserProgress.currentWeek = weekNumber + 1;
            
            // 다음 주차 잠금 해제
            UnlockNextWeek();
            
            // 이벤트 발행
            EventBus.Instance.Publish(GameEvents.WEEK_COMPLETED, weekNumber);
            
            // 저장
            DataManager.Instance.SaveProgress();
        }
    }
    
    // 진행률 계산
    public float GetOverallProgress()
    {
        int totalWeeks = DataManager.Instance.Curriculum.weeks.Count;
        int completedWeeks = DataManager.Instance.UserProgress.completedWeeks.Count;
        return (float)completedWeeks / totalWeeks * 100f;
    }
}
```

### 3.3 퀴즈 시스템

```csharp
[System.Serializable]
public class QuizQuestion
{
    public string question;
    public QuestionType type; // MultipleChoice, TrueFalse, ShortAnswer
    public List<string> options;
    public string correctAnswer;
    public string explanation;
    public int points;
}

public class QuizManager : MonoBehaviour
{
    private QuizData currentQuiz;
    private int currentQuestionIndex = 0;
    private int totalScore = 0;
    
    public void StartQuiz(int weekNumber)
    {
        currentQuiz = DataManager.Instance.Curriculum.weeks[weekNumber - 1].quiz;
        currentQuestionIndex = 0;
        totalScore = 0;
        
        DisplayQuestion(currentQuiz.questions[currentQuestionIndex]);
    }
    
    public void SubmitAnswer(string answer)
    {
        var question = currentQuiz.questions[currentQuestionIndex];
        
        if (IsCorrectAnswer(answer, question.correctAnswer))
        {
            totalScore += question.points;
            ShowFeedback(true, question.explanation);
        }
        else
        {
            ShowFeedback(false, question.explanation);
        }
        
        // 다음 문제로
        currentQuestionIndex++;
        if (currentQuestionIndex < currentQuiz.questions.Count)
        {
            DisplayQuestion(currentQuiz.questions[currentQuestionIndex]);
        }
        else
        {
            FinishQuiz();
        }
    }
}
```

---

## 4. 시뮬레이터 모듈 설계

### 4.1 3D 환경 시스템

**씬 구성**:
```
SimulatorScene
├── Environment
│   ├── Office Floor
│   ├── Project Room
│   ├── Meeting Room
│   └── Individual Workspace
├── NPCs
│   ├── Developer_01
│   ├── Designer_01
│   ├── QA_01
│   └── Client_01
├── Interactive Objects
│   ├── Whiteboard
│   ├── Computer
│   └── Documents
└── UI Canvas
    ├── Project Dashboard
    ├── Decision Panel
    └── Chat Interface
```

**캐릭터 컨트롤러**:
```csharp
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Camera mainCamera;
    
    private CharacterController characterController;
    
    void Update()
    {
        // WASD 이동
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        
        // 마우스 클릭 - 상호작용
        if (Input.GetMouseButtonDown(0))
        {
            CheckInteraction();
        }
    }
    
    private void CheckInteraction()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 5f))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            interactable?.Interact();
        }
    }
}
```

### 4.2 NPC 시스템

```csharp
[System.Serializable]
public class NPCData
{
    public string npcName;
    public string role; // Developer, Designer, QA, Client
    public Dictionary<string, int> traits; // productivity, mood, skill
    public List<DialogueNode> dialogues;
}

public class NPCController : MonoBehaviour, IInteractable
{
    public NPCData npcData;
    
    // 상호작용
    public void Interact()
    {
        // 대화 UI 표시
        DialogueManager.Instance.StartDialogue(npcData.dialogues);
    }
    
    // NPC 상태 업데이트
    public void UpdateMood(int change)
    {
        npcData.traits["mood"] += change;
        npcData.traits["mood"] = Mathf.Clamp(npcData.traits["mood"], 0, 100);
        
        // 시각적 피드백 (이모티콘, 애니메이션 등)
        UpdateVisualState();
    }
}
```

### 4.3 의사결정 엔진

```csharp
[System.Serializable]
public class Decision
{
    public string id;
    public string description;
    public List<DecisionChoice> choices;
    public DecisionContext context;
}

[System.Serializable]
public class DecisionChoice
{
    public string text;
    public DecisionConsequence consequence;
}

[System.Serializable]
public class DecisionConsequence
{
    public int budgetChange;
    public int scheduleChange;
    public int teamMoraleChange;
    public int clientSatisfactionChange;
    public string narrativeResult;
}

public class DecisionEngine : MonoBehaviour
{
    // 의사결정 제시
    public void PresentDecision(Decision decision)
    {
        // UI에 선택지 표시
        DecisionUI.Instance.ShowChoices(decision.choices, OnDecisionMade);
    }
    
    // 의사결정 처리
    private void OnDecisionMade(DecisionChoice choice)
    {
        // 결과 적용
        ApplyConsequence(choice.consequence);
        
        // 결과 피드백
        ShowDecisionResult(choice.consequence.narrativeResult);
        
        // 이벤트 발행
        EventBus.Instance.Publish(GameEvents.DECISION_MADE, choice);
    }
    
    private void ApplyConsequence(DecisionConsequence consequence)
    {
        ProjectState.Instance.Budget += consequence.budgetChange;
        ProjectState.Instance.Schedule += consequence.scheduleChange;
        ProjectState.Instance.TeamMorale += consequence.teamMoraleChange;
        ProjectState.Instance.ClientSatisfaction += consequence.clientSatisfactionChange;
    }
}
```

### 4.4 프로젝트 상태 관리

```csharp
public class ProjectState : MonoBehaviour
{
    public static ProjectState Instance { get; private set; }
    
    // 프로젝트 메트릭
    public int Budget { get; set; }
    public int Schedule { get; set; } // 남은 일수
    public int TeamMorale { get; set; }
    public int ClientSatisfaction { get; set; }
    
    // 프로젝트 진행률
    public float ProjectCompletion { get; private set; }
    
    // KPI 계산
    public float CalculateSPI() // Schedule Performance Index
    {
        // EV / PV
        return earnedValue / plannedValue;
    }
    
    public float CalculateCPI() // Cost Performance Index
    {
        // EV / AC
        return earnedValue / actualCost;
    }
    
    // 프로젝트 상태 체크
    public ProjectStatus GetProjectStatus()
    {
        if (Budget <= 0 || Schedule <= 0 || TeamMorale <= 20)
            return ProjectStatus.Critical;
        else if (ClientSatisfaction >= 80 && ProjectCompletion >= 0.9f)
            return ProjectStatus.Excellent;
        else
            return ProjectStatus.OnTrack;
    }
}

public enum ProjectStatus
{
    Excellent,
    OnTrack,
    AtRisk,
    Critical,
    Failed,
    Success
}
```

---

## 5. UI/UX 설계

### 5.1 UI 구조

```
Main Canvas (Screen Space - Overlay)
├── MainMenuPanel
│   ├── Logo
│   ├── StartButton
│   ├── ContinueButton
│   └── SettingsButton
├── LMSPanel
│   ├── NavigationBar
│   │   ├── HomeButton
│   │   ├── ProgressButton
│   │   └── ProfileButton
│   ├── WeekSelector
│   │   └── WeekCard (x16)
│   └── ContentViewer
│       ├── TitleText
│       ├── ContentScrollView
│       └── ActionButtons
├── SimulatorPanel
│   ├── ProjectDashboard
│   │   ├── BudgetDisplay
│   │   ├── ScheduleDisplay
│   │   ├── TeamMoraleDisplay
│   │   └── ClientSatisfactionDisplay
│   ├── DecisionPanel
│   │   ├── QuestionText
│   │   └── ChoiceButtons
│   └── ChatInterface
│       ├── DialogueText
│       └── ResponseButtons
└── LoadingPanel
    ├── ProgressBar
    └── TipText
```

### 5.2 UI 테마 및 스타일

**컬러 팔레트**:
- **Primary**: #2C3E50 (Dark Blue - 신뢰감)
- **Secondary**: #3498DB (Bright Blue - 활기)
- **Accent**: #E74C3C (Red - 강조)
- **Success**: #2ECC71 (Green - 성공)
- **Warning**: #F39C12 (Orange - 주의)
- **Background**: #ECF0F1 (Light Gray)
- **Text**: #2C3E50 (Dark)

**폰트**:
- **제목**: Noto Sans KR Bold, 24-32pt
- **본문**: Noto Sans KR Regular, 16-18pt
- **버튼**: Noto Sans KR Medium, 18pt

**UI 컴포넌트**:
- 둥근 모서리 (Corner Radius: 8-12px)
- 그림자 효과 (Drop Shadow)
- 부드러운 애니메이션 (DOTween 사용)

---

## 6. 데이터 변환 파이프라인

### 6.1 마크다운 → JSON 변환기

**목적**: 기존 커리큘럼 마크다운 파일을 Unity에서 사용 가능한 JSON 형식으로 변환

**Python 스크립트** (빌드 파이프라인에 통합):
```python
import os
import json
import re
from pathlib import Path

def convert_curriculum_to_json():
    curriculum_path = Path("curriculum")
    output_path = Path("unity-project/Assets/Resources/Curriculum")
    
    curriculum_data = {
        "weeks": []
    }
    
    for week_dir in sorted(curriculum_path.iterdir()):
        if week_dir.is_dir():
            week_data = parse_week_directory(week_dir)
            curriculum_data["weeks"].append(week_data)
    
    # JSON 저장
    output_file = output_path / "curriculum.json"
    with open(output_file, 'w', encoding='utf-8') as f:
        json.dump(curriculum_data, f, ensure_ascii=False, indent=2)

def parse_week_directory(week_dir):
    week_number = extract_week_number(week_dir.name)
    
    week_data = {
        "weekNumber": week_number,
        "phase": determine_phase(week_number),
        "title": "",
        "content": {},
        "quiz": {},
        "rubric": {}
    }
    
    # README 파싱
    readme_path = week_dir / f"{week_dir.name}_README.md"
    if readme_path.exists():
        week_data["content"]["readme"] = readme_path.read_text(encoding='utf-8')
        week_data["title"] = extract_title(week_data["content"]["readme"])
    
    # 상세 강의 자료 파싱
    lecture_path = week_dir / f"{week_dir.name}_detailed-lecture-materials.md"
    if lecture_path.exists():
        week_data["content"]["detailedLecture"] = lecture_path.read_text(encoding='utf-8')
    
    # 사전학습 자료 파싱
    prereq_path = week_dir / f"{week_dir.name}_prerequisite.md"
    if prereq_path.exists():
        week_data["content"]["prerequisite"] = prereq_path.read_text(encoding='utf-8')
    
    return week_data
```

### 6.2 빌드 파이프라인 통합

**Unity Editor 스크립트**:
```csharp
[MenuItem("Tools/Import Curriculum Data")]
public static void ImportCurriculumData()
{
    // Python 스크립트 실행
    RunPythonScript("convert_curriculum.py");
    
    // Unity에서 JSON 로드 및 검증
    ValidateCurriculumData();
    
    // Addressables 빌드
    BuildAddressables();
    
    Debug.Log("Curriculum data imported successfully!");
}
```

---

## 7. 성능 최적화

### 7.1 에셋 관리
- **Addressables 사용**: 대용량 콘텐츠 동적 로딩
- **텍스처 압축**: DXT/ASTC 압축 적용
- **오디오 압축**: Vorbis/MP3 사용
- **LOD (Level of Detail)**: 3D 모델 최적화

### 7.2 메모리 관리
- **오브젝트 풀링**: 반복 생성되는 UI 요소
- **리소스 언로딩**: 사용하지 않는 에셋 해제
- **텍스처 아틀라스**: UI 스프라이트 통합

### 7.3 코드 최적화
- **비동기 로딩**: UniTask/Async-Await 활용
- **UI 업데이트 최소화**: Dirty Flag 패턴
- **이벤트 구독 관리**: 메모리 누수 방지

---

## 8. 테스트 전략

### 8.1 단위 테스트
- **Unity Test Framework** 사용
- 핵심 로직 테스트 (DataManager, DecisionEngine 등)
- 커버리지 목표: 70% 이상

### 8.2 통합 테스트
- 씬 로딩 테스트
- 데이터 저장/로딩 테스트
- UI 플로우 테스트

### 8.3 사용자 테스트
- **Alpha 테스트**: 내부 팀 (5-10명)
- **Beta 테스트**: 외부 사용자 (20-30명)
- **피드백 수집**: Google Forms/설문조사

---

## 9. 배포 전략

### 9.1 빌드 설정
**Windows**:
- Build Target: Windows x64
- Compression: LZ4
- Script Backend: IL2CPP

**macOS**:
- Build Target: macOS
- Architecture: Universal (Intel + Apple Silicon)

**WebGL**:
- Compression: Gzip
- Memory Size: 2048 MB

### 9.2 배포 채널
- **Itch.io**: 초기 프로토타입 배포
- **Steam**: 정식 릴리즈 (Phase 2+)
- **자체 웹사이트**: WebGL 버전 호스팅

---

## 10. 개발 도구 및 워크플로우

### 10.1 버전 관리
- **Git**: 소스 코드 관리
- **.gitignore**: Library, Temp, Logs 제외
- **Git LFS**: 대용량 에셋 관리

### 10.2 협업 도구
- **Plastic SCM** (옵션): Unity 전용 VCS
- **Jira**: 이슈 트래킹
- **Confluence**: 문서화

### 10.3 CI/CD
- **Unity Cloud Build**: 자동 빌드
- **GitHub Actions**: 자동화 파이프라인

---

## 11. 보안 고려사항

### 11.1 데이터 보안
- **암호화**: 사용자 데이터 AES 암호화
- **난독화**: IL2CPP + 코드 난독화 도구
- **체크섬**: 데이터 무결성 검증

### 11.2 저작권 및 라이선스
- **오픈소스 라이브러리**: MIT/Apache 라이선스 준수
- **에셋 라이선스**: 상업적 사용 가능 여부 확인
- **폰트 라이선스**: Noto Sans KR (OFL)

---

## 12. 문서화 계획

### 12.1 개발자 문서
- API 레퍼런스 (XML 주석 + Doxygen)
- 아키텍처 가이드
- 코딩 컨벤션

### 12.2 사용자 문서
- 사용자 매뉴얼
- 튜토리얼 비디오
- FAQ

---

**문서 버전 이력**:
- v1.0 (2025.02.03): 초안 작성
