# 🏗️ Unity 프로젝트 구조 설계서

> **버전**: 1.0  
> **작성일**: 2025년 2월 3일  
> **목적**: Unity 프로젝트의 폴더 구조 및 코드 구조 정의

---

## 1. 프로젝트 폴더 구조

```
pm-expert-training-unity/
├── Assets/
│   ├── _Project/                          # 프로젝트 메인 폴더
│   │   ├── Scenes/                        # 씬 파일
│   │   │   ├── MainMenu.unity
│   │   │   ├── LMS.unity
│   │   │   └── Simulator.unity
│   │   │
│   │   ├── Scripts/                       # C# 스크립트
│   │   │   ├── Core/                      # 핵심 시스템
│   │   │   │   ├── Managers/
│   │   │   │   │   ├── GameManager.cs
│   │   │   │   │   ├── DataManager.cs
│   │   │   │   │   ├── SceneController.cs
│   │   │   │   │   ├── AudioManager.cs
│   │   │   │   │   └── UIManager.cs
│   │   │   │   ├── Events/
│   │   │   │   │   ├── EventBus.cs
│   │   │   │   │   └── GameEvents.cs
│   │   │   │   └── Utils/
│   │   │   │       ├── Singleton.cs
│   │   │   │       ├── SaveLoadSystem.cs
│   │   │   │       └── MarkdownParser.cs
│   │   │   │
│   │   │   ├── Data/                      # 데이터 모델
│   │   │   │   ├── Models/
│   │   │   │   │   ├── CurriculumData.cs
│   │   │   │   │   ├── UserProgressData.cs
│   │   │   │   │   ├── WeekData.cs
│   │   │   │   │   ├── QuizData.cs
│   │   │   │   │   ├── ScenarioData.cs
│   │   │   │   │   └── NPCData.cs
│   │   │   │   └── ScriptableObjects/
│   │   │   │       ├── GameSettings.cs
│   │   │   │       └── ThemeSettings.cs
│   │   │   │
│   │   │   ├── LMS/                       # LMS 모듈
│   │   │   │   ├── ContentViewer/
│   │   │   │   │   ├── MarkdownViewer.cs
│   │   │   │   │   ├── ContentLoader.cs
│   │   │   │   │   └── BookmarkManager.cs
│   │   │   │   ├── Progress/
│   │   │   │   │   ├── ProgressTracker.cs
│   │   │   │   │   ├── ProgressDashboard.cs
│   │   │   │   │   └── WeekUnlocker.cs
│   │   │   │   ├── Quiz/
│   │   │   │   │   ├── QuizManager.cs
│   │   │   │   │   ├── QuestionDisplay.cs
│   │   │   │   │   └── QuizResultPanel.cs
│   │   │   │   ├── Assessment/
│   │   │   │   │   ├── RubricViewer.cs
│   │   │   │   │   └── AssignmentSubmission.cs
│   │   │   │   └── CaseStudy/
│   │   │   │       ├── CaseStudyLibrary.cs
│   │   │   │       └── CaseStudyViewer.cs
│   │   │   │
│   │   │   ├── Simulator/                 # 시뮬레이터 모듈
│   │   │   │   ├── Environment/
│   │   │   │   │   ├── OfficeEnvironment.cs
│   │   │   │   │   └── InteractableObject.cs
│   │   │   │   ├── Player/
│   │   │   │   │   ├── PlayerController.cs
│   │   │   │   │   └── PlayerInteraction.cs
│   │   │   │   ├── NPC/
│   │   │   │   │   ├── NPCController.cs
│   │   │   │   │   ├── NPCDialogue.cs
│   │   │   │   │   └── NPCStateMachine.cs
│   │   │   │   ├── Project/
│   │   │   │   │   ├── ProjectState.cs
│   │   │   │   │   ├── ProjectMetrics.cs
│   │   │   │   │   └── ProjectDashboard.cs
│   │   │   │   ├── Decision/
│   │   │   │   │   ├── DecisionEngine.cs
│   │   │   │   │   ├── DecisionUI.cs
│   │   │   │   │   └── ConsequenceHandler.cs
│   │   │   │   ├── Events/
│   │   │   │   │   ├── EventTrigger.cs
│   │   │   │   │   ├── TimedEventManager.cs
│   │   │   │   │   └── RandomEventGenerator.cs
│   │   │   │   ├── Scenario/
│   │   │   │   │   ├── ScenarioManager.cs
│   │   │   │   │   ├── ScenarioLoader.cs
│   │   │   │   │   └── ScenarioEvaluator.cs
│   │   │   │   └── Tools/
│   │   │   │       ├── GanttChartTool.cs
│   │   │   │       ├── WBSTool.cs
│   │   │   │       └── RiskMatrix.cs
│   │   │   │
│   │   │   └── UI/                        # UI 컴포넌트
│   │   │       ├── Common/
│   │   │       │   ├── ButtonAnimator.cs
│   │   │       │   ├── PanelTransition.cs
│   │   │       │   └── LoadingScreen.cs
│   │   │       ├── MainMenu/
│   │   │       │   └── MainMenuController.cs
│   │   │       ├── LMS/
│   │   │       │   ├── WeekSelector.cs
│   │   │       │   ├── WeekCard.cs
│   │   │       │   └── NavigationBar.cs
│   │   │       └── Simulator/
│   │   │           ├── HUDController.cs
│   │   │           ├── DialoguePanel.cs
│   │   │           └── MetricsDisplay.cs
│   │   │
│   │   ├── Prefabs/                       # 프리팹
│   │   │   ├── UI/
│   │   │   │   ├── WeekCard.prefab
│   │   │   │   ├── QuizQuestion.prefab
│   │   │   │   └── DecisionPanel.prefab
│   │   │   ├── Characters/
│   │   │   │   ├── Player.prefab
│   │   │   │   └── NPC_Generic.prefab
│   │   │   └── Environment/
│   │   │       ├── Desk.prefab
│   │   │       ├── Whiteboard.prefab
│   │   │       └── MeetingTable.prefab
│   │   │
│   │   ├── Materials/                     # 머티리얼
│   │   │   ├── UI/
│   │   │   ├── Environment/
│   │   │   └── Characters/
│   │   │
│   │   ├── Textures/                      # 텍스처
│   │   │   ├── UI/
│   │   │   └── Environment/
│   │   │
│   │   ├── Models/                        # 3D 모델
│   │   │   ├── Characters/
│   │   │   └── Environment/
│   │   │
│   │   ├── Animations/                    # 애니메이션
│   │   │   ├── UI/
│   │   │   └── Characters/
│   │   │
│   │   ├── Audio/                         # 오디오
│   │   │   ├── Music/
│   │   │   ├── SFX/
│   │   │   └── Voice/
│   │   │
│   │   └── Resources/                     # 런타임 로드 리소스
│   │       ├── Curriculum/                # 커리큘럼 데이터
│   │       │   └── curriculum.json
│   │       ├── Scenarios/                 # 시나리오 데이터
│   │       │   └── case01-mobile-app.json
│   │       └── Localization/              # 다국어
│   │           └── ko-KR.json
│   │
│   ├── AddressableAssets/                 # Addressables 에셋
│   │   └── [자동 생성]
│   │
│   ├── TextMesh Pro/                      # TMP 리소스
│   │   └── [TMP 자동 생성]
│   │
│   └── ThirdParty/                        # 써드파티 에셋
│       ├── DOTween/
│       ├── Markdig/
│       └── [기타 에셋]
│
├── Packages/                              # Unity 패키지
│   └── manifest.json
│
├── ProjectSettings/                       # 프로젝트 설정
│
└── [기타 Unity 생성 폴더]
```

---

## 2. 핵심 스크립트 구조

### 2.1 GameManager.cs

```csharp
using UnityEngine;

namespace PMExpertTraining.Core
{
    /// <summary>
    /// 게임 전체를 관리하는 메인 매니저
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {
        [Header("Managers")]
        public DataManager dataManager;
        public SceneController sceneController;
        public AudioManager audioManager;
        public UIManager uiManager;

        [Header("Settings")]
        public GameSettings gameSettings;

        private void Start()
        {
            InitializeGame();
        }

        private async void InitializeGame()
        {
            // 초기화 순서가 중요
            await dataManager.InitializeAsync();
            EventBus.Instance.Initialize();
            audioManager.Initialize();
            uiManager.Initialize();

            // 메인 메뉴로 이동
            await sceneController.LoadSceneAsync("MainMenu");
        }

        public void QuitGame()
        {
            dataManager.SaveProgress();
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}
```

### 2.2 DataManager.cs

```csharp
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;

namespace PMExpertTraining.Core
{
    /// <summary>
    /// 모든 데이터 로딩 및 저장 관리
    /// </summary>
    public class DataManager : MonoBehaviour
    {
        public static DataManager Instance { get; private set; }

        public CurriculumData Curriculum { get; private set; }
        public UserProgressData UserProgress { get; private set; }

        private string saveFilePath;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            saveFilePath = System.IO.Path.Combine(
                Application.persistentDataPath, "userProgress.json");
        }

        public async Task InitializeAsync()
        {
            await LoadCurriculumData();
            await LoadUserProgress();
        }

        private async Task LoadCurriculumData()
        {
            // Resources에서 JSON 로드
            TextAsset jsonFile = Resources.Load<TextAsset>("Curriculum/curriculum");
            if (jsonFile != null)
            {
                Curriculum = JsonConvert.DeserializeObject<CurriculumData>(jsonFile.text);
                Debug.Log($"Curriculum loaded: {Curriculum.weeks.Count} weeks");
            }
            else
            {
                Debug.LogError("Curriculum data not found!");
            }
        }

        private async Task LoadUserProgress()
        {
            if (System.IO.File.Exists(saveFilePath))
            {
                string json = System.IO.File.ReadAllText(saveFilePath);
                UserProgress = JsonConvert.DeserializeObject<UserProgressData>(json);
                Debug.Log("User progress loaded");
            }
            else
            {
                // 새 프로그레스 생성
                UserProgress = new UserProgressData
                {
                    userId = System.Guid.NewGuid().ToString(),
                    currentWeek = 1,
                    completedWeeks = new System.Collections.Generic.List<int>(),
                    quizScores = new System.Collections.Generic.Dictionary<int, int>(),
                    simulationsCompleted = new System.Collections.Generic.List<string>(),
                    badges = new System.Collections.Generic.List<string>(),
                    totalStudyTime = 0f
                };
                Debug.Log("New user progress created");
            }
        }

        public void SaveProgress()
        {
            string json = JsonConvert.SerializeObject(UserProgress, Formatting.Indented);
            System.IO.File.WriteAllText(saveFilePath, json);
            Debug.Log("Progress saved");
            
            EventBus.Instance.Publish(GameEvents.PROGRESS_SAVED, null);
        }

        public void AutoSave()
        {
            InvokeRepeating(nameof(SaveProgress), 300f, 300f); // 5분마다
        }
    }
}
```

### 2.3 EventBus.cs

```csharp
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PMExpertTraining.Core
{
    /// <summary>
    /// 이벤트 기반 통신 시스템
    /// </summary>
    public class EventBus : MonoBehaviour
    {
        public static EventBus Instance { get; private set; }

        private Dictionary<string, List<Action<object>>> eventListeners = new();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void Initialize()
        {
            Debug.Log("EventBus initialized");
        }

        public void Subscribe(string eventName, Action<object> callback)
        {
            if (!eventListeners.ContainsKey(eventName))
            {
                eventListeners[eventName] = new List<Action<object>>();
            }

            eventListeners[eventName].Add(callback);
        }

        public void Unsubscribe(string eventName, Action<object> callback)
        {
            if (eventListeners.ContainsKey(eventName))
            {
                eventListeners[eventName].Remove(callback);
            }
        }

        public void Publish(string eventName, object data = null)
        {
            if (eventListeners.ContainsKey(eventName))
            {
                foreach (var callback in eventListeners[eventName])
                {
                    callback?.Invoke(data);
                }
            }
        }

        private void OnDestroy()
        {
            eventListeners.Clear();
        }
    }

    /// <summary>
    /// 게임 이벤트 상수 정의
    /// </summary>
    public static class GameEvents
    {
        public const string WEEK_COMPLETED = "WeekCompleted";
        public const string QUIZ_SUBMITTED = "QuizSubmitted";
        public const string SIMULATION_STARTED = "SimulationStarted";
        public const string DECISION_MADE = "DecisionMade";
        public const string PROJECT_STATE_CHANGED = "ProjectStateChanged";
        public const string PROGRESS_SAVED = "ProgressSaved";
        public const string NPC_INTERACTION = "NPCInteraction";
        public const string BADGE_EARNED = "BadgeEarned";
    }
}
```

### 2.4 CurriculumData.cs (데이터 모델)

```csharp
using System;
using System.Collections.Generic;

namespace PMExpertTraining.Data
{
    [Serializable]
    public class CurriculumData
    {
        public List<WeekData> weeks;
    }

    [Serializable]
    public class WeekData
    {
        public int weekNumber;
        public string phase;
        public string title;
        public string description;
        public ContentData content;
        public QuizData quiz;
        public RubricData rubric;
        public bool simulationUnlocked;
        public List<string> learningObjectives;
    }

    [Serializable]
    public class ContentData
    {
        public string readme;
        public string detailedLecture;
        public string prerequisite;
    }

    [Serializable]
    public class QuizData
    {
        public string quizId;
        public List<QuizQuestion> questions;
        public int passingScore;
        public int timeLimit; // 분 단위, 0이면 무제한
    }

    [Serializable]
    public class QuizQuestion
    {
        public string questionId;
        public string question;
        public QuestionType type;
        public List<string> options;
        public string correctAnswer;
        public string explanation;
        public int points;
    }

    public enum QuestionType
    {
        MultipleChoice,
        TrueFalse,
        ShortAnswer
    }

    [Serializable]
    public class RubricData
    {
        public string rubricId;
        public List<RubricCriterion> criteria;
    }

    [Serializable]
    public class RubricCriterion
    {
        public string criterionName;
        public List<RubricLevel> levels;
        public int weight;
    }

    [Serializable]
    public class RubricLevel
    {
        public string levelName; // 부족, 보통, 우수, 탁월
        public string description;
        public int scoreRange; // 0-100
    }

    [Serializable]
    public class UserProgressData
    {
        public string userId;
        public int currentWeek;
        public List<int> completedWeeks;
        public Dictionary<int, int> quizScores;
        public List<string> simulationsCompleted;
        public List<string> badges;
        public float totalStudyTime;
        public Dictionary<string, bool> bookmarks;
        public DateTime lastLoginDate;
    }
}
```

---

## 3. 씬 구조

### 3.1 MainMenu 씬

```
MainMenu
├── Canvas
│   ├── Background
│   ├── Logo
│   ├── TitleText
│   ├── ButtonPanel
│   │   ├── StartButton
│   │   ├── ContinueButton (진행률 있을 때만)
│   │   ├── SettingsButton
│   │   └── QuitButton
│   └── VersionText
├── EventSystem
└── AudioSource (BGM)
```

### 3.2 LMS 씬

```
LMS
├── Canvas
│   ├── NavigationBar
│   │   ├── HomeButton
│   │   ├── ProgressButton
│   │   ├── ProfileButton
│   │   └── SettingsButton
│   ├── MainPanel
│   │   ├── WeekSelectorPanel
│   │   │   └── WeekGrid (16 WeekCards)
│   │   ├── ContentViewerPanel
│   │   │   ├── TitleText
│   │   │   ├── ScrollView
│   │   │   │   └── ContentText (TMP)
│   │   │   └── ActionButtons
│   │   ├── QuizPanel
│   │   │   └── [Quiz UI]
│   │   └── ProgressPanel
│   │       └── [Progress Dashboard]
│   └── LoadingPanel
├── EventSystem
└── Managers
    ├── LMSManager
    └── ContentManager
```

### 3.3 Simulator 씬

```
Simulator
├── Environment
│   ├── Floor
│   ├── Walls
│   ├── Furniture
│   └── Lighting
├── Player
│   └── PlayerCamera (Cinemachine)
├── NPCs
│   ├── Developer_01
│   ├── Designer_01
│   └── Client_01
├── Canvas
│   ├── HUD
│   │   ├── ProjectMetrics
│   │   └── Notifications
│   ├── DialoguePanel
│   ├── DecisionPanel
│   └── ProjectDashboard
├── EventSystem
└── Managers
    ├── SimulatorManager
    ├── NPCManager
    ├── ProjectStateManager
    └── DecisionEngine
```

---

## 4. 에셋 명명 규칙

### 4.1 일반 규칙
- **PascalCase**: 스크립트, 프리팹
- **camelCase**: 변수, 함수
- **kebab-case**: 씬, JSON 파일
- **UPPER_CASE**: 상수

### 4.2 프리팹 접두사
- `UI_`: UI 요소 (예: `UI_WeekCard.prefab`)
- `NPC_`: NPC 캐릭터 (예: `NPC_Developer.prefab`)
- `ENV_`: 환경 오브젝트 (예: `ENV_Desk.prefab`)
- `FX_`: 이펙트 (예: `FX_Sparkle.prefab`)

### 4.3 스크립트 접미사
- `Manager`: 시스템 관리자 (예: `DataManager.cs`)
- `Controller`: 동작 제어 (예: `PlayerController.cs`)
- `Handler`: 이벤트 처리 (예: `InputHandler.cs`)
- `Data`: 데이터 모델 (예: `CurriculumData.cs`)

---

## 5. ScriptableObject 활용

### 5.1 GameSettings.asset

```csharp
[CreateAssetMenu(fileName = "GameSettings", menuName = "PM Training/Game Settings")]
public class GameSettings : ScriptableObject
{
    [Header("General")]
    public string gameVersion = "1.0.0";
    public bool debugMode = false;

    [Header("Performance")]
    public int targetFrameRate = 60;
    public bool vSyncEnabled = true;

    [Header("Audio")]
    [Range(0f, 1f)] public float masterVolume = 1f;
    [Range(0f, 1f)] public float musicVolume = 0.7f;
    [Range(0f, 1f)] public float sfxVolume = 0.8f;

    [Header("Autosave")]
    public bool autoSaveEnabled = true;
    public int autoSaveIntervalSeconds = 300; // 5분
}
```

### 5.2 ThemeSettings.asset

```csharp
[CreateAssetMenu(fileName = "ThemeSettings", menuName = "PM Training/Theme Settings")]
public class ThemeSettings : ScriptableObject
{
    [Header("Colors")]
    public Color primaryColor = new Color(0.17f, 0.24f, 0.31f); // #2C3E50
    public Color secondaryColor = new Color(0.20f, 0.60f, 0.86f); // #3498DB
    public Color accentColor = new Color(0.91f, 0.30f, 0.24f); // #E74C3C
    public Color successColor = new Color(0.18f, 0.80f, 0.44f); // #2ECC71
    public Color warningColor = new Color(0.95f, 0.61f, 0.07f); // #F39C12

    [Header("Fonts")]
    public TMP_FontAsset titleFont;
    public TMP_FontAsset bodyFont;
    public TMP_FontAsset buttonFont;

    [Header("UI")]
    public float uiAnimationSpeed = 0.3f;
    public AnimationCurve uiAnimationCurve;
}
```

---

## 6. 코딩 컨벤션

### 6.1 C# 스타일 가이드
- Microsoft C# 코딩 컨벤션 준수
- 네임스페이스: `PMExpertTraining.[Module]`
- 들여쓰기: 4 스페이스
- 한 줄 최대 길이: 100자

### 6.2 주석 작성
```csharp
/// <summary>
/// 간단한 설명
/// </summary>
/// <param name="paramName">파라미터 설명</param>
/// <returns>리턴 값 설명</returns>
```

### 6.3 에러 처리
```csharp
try
{
    // 코드
}
catch (Exception ex)
{
    Debug.LogError($"Error in [MethodName]: {ex.Message}");
    // 적절한 폴백 처리
}
```

---

## 7. Git 워크플로우

### 7.1 브랜치 전략
- `main`: 프로덕션 빌드
- `develop`: 개발 브랜치
- `feature/[feature-name]`: 기능 개발
- `bugfix/[bug-name]`: 버그 수정

### 7.2 커밋 메시지
```
[Type] Short description

- Detail 1
- Detail 2

[Type]: feat, fix, docs, style, refactor, test, chore
```

### 7.3 .gitignore (Unity 전용)
```
# Unity
/[Ll]ibrary/
/[Tt]emp/
/[Oo]bj/
/[Bb]uild/
/[Bb]uilds/
/[Ll]ogs/
/[Uu]ser[Ss]ettings/

# Visual Studio
.vs/
*.csproj
*.sln
*.suo
*.user

# OS
.DS_Store
Thumbs.db
```

---

**문서 버전 이력**:
- v1.0 (2025.02.03): 초안 작성
