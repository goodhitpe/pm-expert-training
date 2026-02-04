# 🚀 Phase 1.5 빠른 시작 가이드

> **대상**: Unity LMS & 시뮬레이터 개발팀  
> **목표**: 오늘 바로 Phase 1.5 개발 시작하기  
> **소요 시간**: 설정 1-2시간, 개발 4주

---

## ⚡ 5분 Quick Start

### 1단계: 문서 읽기 (10분)
```bash
# 필수 읽기 (순서대로)
1. PHASE1.5_ACTION_PLAN.md       # 전체 개요 (5분)
2. PHASE1.5_DEV_CHECKLIST.md     # 내 역할 확인 (3분)
3. PHASE1.5_CODE_SAMPLES.md      # 코드 샘플 훑어보기 (2분)
```

### 2단계: 역할 확인
**나는 누구인가?**
- [ ] Unity 개발자 #1 (Senior) → Week 1, 3 담당
- [ ] Unity 개발자 #2 (Mid) → Week 1, 2, 4 담당
- [ ] Backend 개발자 → Week 2, 4 담당
- [ ] UI/UX 디자이너 → Week 2, 3, 4 담당
- [ ] QA 테스터 → Week 4 담당

### 3단계: 오늘 할 일 확인
**Week 1 Day 1이라면** (Unity 개발자):
- [ ] Unity 프로젝트 열기
- [ ] Time Block 시스템 설계
- [ ] TimeManager.cs 기본 구조 작성
- [ ] 팀 동기화 (스탠드업)

---

## 🛠️ 개발 환경 설정 (1-2시간)

### Unity 개발자

#### 필수 도구
```bash
# 1. Unity 2022 LTS 설치
https://unity.com/releases/editor/archive

# 2. Visual Studio 또는 Rider
# Visual Studio: https://visualstudio.microsoft.com/
# Rider: https://www.jetbrains.com/rider/

# 3. Git LFS (대용량 파일)
git lfs install
```

#### Unity 패키지
```
필수 패키지:
- TextMesh Pro (텍스트)
- Input System (입력)
- Cinemachine (카메라)
- Addressables (에셋 로딩)

추가 패키지:
- DOTween Pro (애니메이션) - Asset Store
- UniWebView (웹뷰) - Asset Store $100
```

#### 프로젝트 설정
```bash
# 1. Git 클론 (Unity 프로젝트 별도)
git clone <unity-project-repo>
cd pm-expert-training-unity

# 2. Unity Hub에서 프로젝트 열기
# Unity 2022.3 LTS 선택

# 3. 첫 빌드 테스트
File → Build Settings → Build
```

---

### Backend 개발자

#### 필수 도구
```bash
# 1. Node.js 18+ LTS
https://nodejs.org/

# 2. Firebase CLI
npm install -g firebase-tools
firebase login

# 3. VS Code
https://code.visualstudio.com/

# 4. Python 3.8+
https://www.python.org/
```

#### 프로젝트 설정
```bash
# 1. Firebase 프로젝트 생성
firebase projects:create pm-expert-training
firebase init

# 선택:
# - Firestore
# - Functions
# - Hosting

# 2. Node.js 프로젝트
cd functions
npm install express cors firebase-admin

# 3. Python 환경
pip install pandas matplotlib firebase-admin
```

---

### UI/UX 디자이너

#### 필수 도구
```bash
# 1. Figma
https://www.figma.com/

# 2. React 개발 환경 (Dashboard용)
npx create-react-app instructor-dashboard
cd instructor-dashboard
npm install firebase @mui/material recharts

# 3. 디자인 에셋
# 사운드: freesound.org, zapsplat.com
# 아이콘: flaticon.com, iconfinder.com
```

---

## 📅 첫 주 (Week 1) 상세 가이드

### Day 1: 프로젝트 설정 및 Time Block 시스템

#### Unity 개발자 #1 (오전)
```csharp
// 1. Scripts/Managers/ 폴더 생성
// 2. TimeManager.cs 생성

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }
    public const int BLOCKS_PER_DAY = 8;
    
    private int currentBlock = 0;
    private int currentDay = 1;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public bool TryConsumeTimeBlocks(int blocks)
    {
        // TODO: 구현
        return true;
    }
}

// 3. 빈 씬에 TimeManager 오브젝트 추가
// 4. 테스트 스크립트로 확인
```

#### Unity 개발자 #1 (오후)
```csharp
// 5. 이벤트 시스템 추가
public event Action<int, int> OnTimeAdvanced;
public event Action<int> OnDayEnded;

// 6. 일일 리뷰 기능
private void EndDay()
{
    Debug.Log($"Day {currentDay} ended");
    OnDayEnded?.Invoke(currentDay);
    currentDay++;
    currentBlock = 0;
}

// 7. UI 연동 (간단한 Text)
// 8. 플레이 테스트
```

#### Unity 개발자 #2 (하루종일)
```csharp
// 1. UI/TimeBlockUI.cs 생성
public class TimeBlockUI : MonoBehaviour
{
    public TMP_Text dayText;
    public TMP_Text blockText;
    
    void Start()
    {
        TimeManager.Instance.OnTimeAdvanced += UpdateUI;
    }
    
    void UpdateUI(int day, int block)
    {
        dayText.text = $"Day {day}";
        blockText.text = $"{block}/{TimeManager.BLOCKS_PER_DAY} blocks";
    }
}

// 2. Canvas에 UI 배치
// 3. TimeManager와 연결
```

#### 스탠드업 (17:00)
- 오늘 한 일: TimeManager 기본 구조 완성
- 내일 할 일: 동시다발 이벤트 시스템
- 이슈: 없음

---

### Day 2: 동시다발 이벤트 시스템

#### Unity 개발자 #1
```csharp
// EventManager.cs
public class EventManager : MonoBehaviour
{
    private Queue<GameEvent> pendingEvents = new Queue<GameEvent>();
    
    public void TriggerEvent(GameEvent evt)
    {
        pendingEvents.Enqueue(evt);
        CheckEventQueue();
    }
    
    public void TriggerMultipleEvents(params GameEvent[] events)
    {
        foreach (var evt in events)
        {
            pendingEvents.Enqueue(evt);
        }
        ShowEventPriorityUI();
    }
}

// GameEvent.cs
[System.Serializable]
public class GameEvent
{
    public string eventId;
    public string description;
    public EventPriority priority;
    public int timeBlocksRequired;
}
```

---

## 💡 개발 팁

### Unity 개발자

**디버깅**:
```csharp
// 로그 레벨 사용
Debug.Log("[TimeManager] " + message);      // 일반
Debug.LogWarning("[TimeManager] " + message); // 경고
Debug.LogError("[TimeManager] " + message);   // 에러

// 조건부 컴파일
#if UNITY_EDITOR
    Debug.Log("Editor only");
#endif
```

**테스트**:
```csharp
// Test 폴더에 PlayMode 테스트
[Test]
public void TimeBlock_ConsumeOne_Success()
{
    var timeManager = new TimeManager();
    Assert.IsTrue(timeManager.TryConsumeTimeBlocks(1));
}
```

---

### Backend 개발자

**Firebase 로컬 에뮬레이터**:
```bash
# 로컬에서 테스트
firebase emulators:start

# URL: http://localhost:4000
# Firestore: http://localhost:8080
```

**API 테스트**:
```bash
# Postman 또는 curl
curl http://localhost:5001/api/instructor/dashboard
```

---

## 📋 일일 체크리스트

### 매일 해야 할 것
- [ ] 아침 스탠드업 (10:00, 15분)
- [ ] 오늘 작업 선택 (PHASE1.5_DEV_CHECKLIST.md)
- [ ] 중간 체크 (점심 후)
- [ ] 코드 커밋 (하루 2-3회)
- [ ] 저녁 스탠드업 (17:00, 15분)
- [ ] 내일 작업 준비

### 주간 회의
- [ ] 월요일 주간 계획 (09:00, 30분)
- [ ] 금요일 주간 리뷰 (16:00, 1시간)

---

## 🆘 문제 해결

### "어디서부터 시작해야 할지 모르겠어요"
→ PHASE1.5_DEV_CHECKLIST.md에서 내 역할의 Day 1 확인

### "코드를 어떻게 작성해야 할지 모르겠어요"
→ PHASE1.5_CODE_SAMPLES.md에서 유사한 코드 찾기

### "시간이 부족해요"
→ PM에게 알리기, 작업 우선순위 재조정

### "버그가 너무 많아요"
→ 크리티컬만 먼저 수정, 나머지는 Week 4에

---

## 📞 연락처

**일일 질문**: Slack #phase15-dev  
**긴급 이슈**: PM 직접 연락  
**기술 질문**: #unity-help, #backend-help

---

## 🎯 성공 확인

### Week 1 완료 시
- [ ] Time Block 시스템 작동
- [ ] 게임 루프 체험 가능
- [ ] 30개 의사결정 작성 시작
- [ ] 팀 동기화 잘 됨

### Week 2 완료 시
- [ ] 강사 대시보드 접속 가능
- [ ] 학습 분석 리포트 생성
- [ ] Backend API 작동

### Week 3 완료 시
- [ ] 온보딩 튜토리얼 플레이 가능
- [ ] Juice 효과 체감

### Week 4 완료 시
- [ ] 전체 통합 테스트 통과
- [ ] Alpha 테스트 준비 완료

---

**화이팅! 4주 후에 만나요! 🚀**

**작성일**: 2025-02-04  
**버전**: 1.0  
**다음 업데이트**: Week 1 완료 후
