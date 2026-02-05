# 🎮 Unity LMS & 시뮬레이터 구현

> **Phase 1.5 개선사항 구현**  
> **목표**: 70점 → 78점 달성  
> **기간**: 4주

---

## 📁 프로젝트 구조

```
unity-implementation/
├── Scripts/
│   ├── Managers/           # 핵심 시스템 매니저
│   │   ├── TimeManager.cs       # Time Block 시스템
│   │   ├── EventManager.cs      # 동시다발 이벤트 관리
│   │   ├── DecisionSystem.cs    # Trade-off 의사결정
│   │   └── MetricManager.cs     # 프로젝트 메트릭 관리
│   ├── Core/               # 핵심 게임 로직
│   ├── UI/                 # UI 컴포넌트
│   ├── Data/               # 데이터 모델
│   └── Events/             # 이벤트 시스템
├── Data/
│   ├── JSON/               # JSON 데이터 파일
│   │   └── sample_decisions.json  # 샘플 의사결정 데이터
│   └── ScriptableObjects/  # Unity ScriptableObject
├── Scenes/                 # Unity 씬
├── Prefabs/                # Unity 프리팹
└── README.md
```

---

## 🎯 구현된 기능 (Week 1)

### 1. TimeManager - Time Block 시스템
**파일**: `Scripts/Managers/TimeManager.cs`

**기능**:
- ✅ 하루 = 8 Time Blocks
- ✅ 액션마다 1-4 블록 소비
- ✅ 일일/주간 종료 이벤트
- ✅ 시간 사용 히스토리 추적
- ✅ 오버타임 처리

**사용 예시**:
```csharp
// 회의에 2블록 소비
TimeManager.Instance.TryConsumeTimeBlocks(2, "팀 미팅");

// 현재 시간 정보
var (day, week, block, remaining) = TimeManager.Instance.GetCurrentTime();
Debug.Log($"Day {day}, Week {week}, Block {block}/{TimeManager.BLOCKS_PER_DAY}");
```

### 2. EventManager - 동시다발 이벤트 시스템
**파일**: `Scripts/Managers/EventManager.cs`

**기능**:
- ✅ 이벤트 큐 관리
- ✅ 동시다발 이벤트 (플레이어가 우선순위 결정)
- ✅ 이벤트 우선순위 (Critical/High/Medium/Low)
- ✅ 긴급도 및 타입 분류

**사용 예시**:
```csharp
// 단일 이벤트
GameEvent meeting = new GameEvent {
    eventId = "evt_001",
    eventName = "팀 회의",
    priority = EventPriority.High,
    timeBlocksRequired = 2
};
EventManager.Instance.TriggerEvent(meeting);

// 동시다발 이벤트 (플레이어가 선택)
EventManager.Instance.TriggerMultipleEvents(event1, event2, event3);
```

### 3. DecisionSystem - Trade-off 의사결정
**파일**: `Scripts/Managers/DecisionSystem.cs`

**기능**:
- ✅ 모든 선택지에 장단점 명시
- ✅ 메트릭 영향 (Schedule, Budget, Quality 등)
- ✅ 숨겨진 영향 (확률적)
- ✅ 의사결정 결과 적용

**사용 예시**:
```csharp
// 의사결정 제시
Decision decision = LoadDecisionFromJSON("dec_001");
DecisionSystem.Instance.PresentDecision(decision);

// 플레이어가 선택 (0, 1, 2...)
DecisionSystem.Instance.MakeChoice(0);
```

### 4. MetricManager - 프로젝트 메트릭 관리
**파일**: `Scripts/Managers/MetricManager.cs`

**기능**:
- ✅ 8개 메트릭 (일정, 예산, 품질, 범위, 팀사기, 이해관계자, 리스크, 기술부채)
- ✅ 메트릭 변화 추적
- ✅ 임계값 경고 (Critical: 0-20, Low: 21-40)
- ✅ 프로젝트 건강도 평가

**사용 예시**:
```csharp
// 메트릭 수정
MetricManager.Instance.ModifyMetric(MetricType.Schedule, -10);
MetricManager.Instance.ModifyMetric(MetricType.Quality, 15);

// 현재 값 조회
int scheduleValue = MetricManager.Instance.GetMetricValue(MetricType.Schedule);

// 프로젝트 건강도
int health = MetricManager.Instance.GetProjectHealth(); // 0-100
```

---

## 📊 샘플 데이터

### sample_decisions.json
3개의 샘플 의사결정 포함:
1. **기술 스택 선택** (난이도 2/5)
   - 최신 기술 vs 검증된 기술 vs 하이브리드
   
2. **긴급 버그 대응** (난이도 4/5)
   - 전체 팀 동원 vs 핵심 인력만 vs 일정 조율
   
3. **범위 변경 요청** (난이도 3/5)
   - 증액 협상 vs 범위 축소 vs MVP 접근

---

## 🚀 다음 단계

### Week 2: 교육 기능 (2주차)
- [ ] Instructor Dashboard API (Node.js + Firebase)
- [ ] Learning Analytics (Python)
- [ ] WebView 통합

### Week 3: UX 개선 (3주차)
- [ ] 온보딩 튜토리얼
- [ ] UI Juice 시스템 (애니메이션, 사운드, 파티클)

### Week 4: 통합 및 테스트 (4주차)
- [ ] Q&A 게시판
- [ ] 전체 통합 테스트
- [ ] Alpha 테스트 준비

---

## 💻 개발 환경 설정

### 필수 요구사항
- Unity 2022.3 LTS 이상
- Visual Studio 2022 또는 Rider
- Git LFS

### Unity 패키지
```
필수:
- TextMesh Pro
- Input System
- Cinemachine
- Addressables

권장:
- DOTween Pro (Asset Store)
- UniWebView (Asset Store, Week 2 필요)
```

### 프로젝트 시작
```bash
# 1. Unity Hub에서 프로젝트 생성
# - Template: 3D (URP)
# - Unity Version: 2022.3 LTS

# 2. 이 폴더를 Unity 프로젝트의 Assets/로 복사
cp -r unity-implementation/* <Unity-Project>/Assets/PMExpert/

# 3. Unity에서 첫 빌드 테스트
```

---

## 🧪 테스트

### 1. TimeManager 테스트
```csharp
[Test]
public void TimeBlock_ConsumeOne_Success()
{
    var consumed = TimeManager.Instance.TryConsumeTimeBlocks(1, "Test");
    Assert.IsTrue(consumed);
    Assert.AreEqual(1, TimeManager.Instance.GetCurrentTime().block);
}

[Test]
public void TimeBlock_ConsumeOverLimit_DayEnds()
{
    TimeManager.Instance.TryConsumeTimeBlocks(8, "Full Day");
    Assert.AreEqual(2, TimeManager.Instance.GetCurrentTime().day);
}
```

### 2. MetricManager 테스트
```csharp
[Test]
public void Metric_Modify_ChangesValue()
{
    int initial = MetricManager.Instance.GetMetricValue(MetricType.Schedule);
    MetricManager.Instance.ModifyMetric(MetricType.Schedule, 10);
    Assert.AreEqual(initial + 10, MetricManager.Instance.GetMetricValue(MetricType.Schedule));
}
```

---

## 📚 참고 문서

- [PHASE1.5_ACTION_PLAN.md](../PHASE1.5_ACTION_PLAN.md) - 4주 실행 계획
- [PHASE1.5_DEV_CHECKLIST.md](../PHASE1.5_DEV_CHECKLIST.md) - 개발자 체크리스트
- [PHASE1.5_CODE_SAMPLES.md](../PHASE1.5_CODE_SAMPLES.md) - 추가 코드 샘플
- [UNITY_PROJECT_TECHNICAL_SPEC.md](../UNITY_PROJECT_TECHNICAL_SPEC.md) - 기술 사양서

---

## 🎯 성공 기준

| 지표 | 목표 |
|------|------|
| 게임 루프 인식 시간 | < 5분 |
| 의사결정 고민 시간 | 30-60초 |
| Time Block 시스템 작동 | 100% |
| 메트릭 변화 시각화 | 실시간 |

---

## 📞 지원

**기술 질문**: Unity 개발 채널  
**버그 리포트**: GitHub Issues  
**피드백**: PM에게 직접 연락

---

**작성일**: 2025-02-05  
**버전**: 1.0  
**상태**: Week 1 완료 ✅
