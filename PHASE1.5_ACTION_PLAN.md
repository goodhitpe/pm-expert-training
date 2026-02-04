# 🚀 Phase 1.5 즉시 실행 가이드

> **목표**: 전문가 평가를 바탕으로 4주 내 긴급 개선사항 완료  
> **점수 목표**: 70/100 → 78/100 (+11%)  
> **예산**: $12,500-15,000  
> **참조**: [INTEGRATED_IMPROVEMENT_PROPOSAL.md](./INTEGRATED_IMPROVEMENT_PROPOSAL.md)

---

## 📊 Quick Overview

### 왜 Phase 1.5가 필요한가?

전문가 평가 결과:
- ✅ **기술적 기반**: 탄탄함 (MVC, EventBus, Unity 2022 LTS)
- ❌ **사용자 경험**: 미흡 (강사 도구 없음, 게임 재미 부족)
- ❌ **실제 사용**: 불가 (교육 현장 배포 불가)

**Phase 1.5 완료 시**:
- ✅ 교육 기관 실제 사용 가능
- ✅ 강사의 학습자 관리 능력
- ✅ 게임으로서 기본 재미
- ✅ 신규 사용자 온보딩

---

## 🎯 4주 실행 계획

### Week 1: 게임 메커닉스 (Unity 개발자 2명)

#### 📌 Day 1-3: 게임 루프 재설계

**구현 목표**: 명확한 게임 루프로 지루함 해소

```csharp
// TimeManager.cs - 시간 관리 시스템
public class TimeManager : MonoBehaviour
{
    public const int BLOCKS_PER_DAY = 8;
    private int currentBlock = 0;
    private int currentDay = 1;
    
    public bool ConsumeTimeBlocks(int blocks)
    {
        if (currentBlock + blocks > BLOCKS_PER_DAY)
        {
            TriggerDailyReview();
            currentDay++;
            currentBlock = 0;
            return false;
        }
        currentBlock += blocks;
        return true;
    }
}
```

**체크리스트**:
- [ ] Time Block 시스템 구현 (하루 = 8블록)
- [ ] 동시다발 이벤트 시스템
- [ ] 일일 리뷰 기능
- [ ] 플레이테스트 (루프 인식 <5분)

#### 📌 Day 4-5: Trade-off 의사결정

**구현 목표**: "정답" 제거, 모든 선택에 장단점

```csharp
// Decision.cs
public class DecisionChoice
{
    public string text;
    public string pros;  // "품질↑↑ 신뢰↑"
    public string cons;  // "일정↓↓ 사기↓"
    public Dictionary<string, int> impacts;
}
```

**체크리스트**:
- [ ] 30개 Trade-off 의사결정 작성
- [ ] 의사결정 UI 개선 (장단점 명시)
- [ ] 3개 메트릭 동시 변화 시스템
- [ ] 플레이테스트 (고민 시간 30-60초)

---

### Week 2: 교육 기능 (Unity 1명 + Backend 1명)

#### 📌 Day 1-3: 강사 대시보드

**구현 목표**: 강사가 학습자 현황 파악 가능

```typescript
// API Endpoint
GET /api/instructor/dashboard
Response: {
  totalStudents: 24,
  atRisk: 5,  // 자동 식별
  avgProgress: 68,
  weeklyStats: [...]
}
```

**체크리스트**:
- [ ] Backend API (Node.js + Firebase)
- [ ] 위험군 자동 식별 알고리즘
- [ ] 웹 대시보드 (React/Vue)
- [ ] Unity WebView 통합
- [ ] 강사 테스트 (3-5명)

#### 📌 Day 4-5: 학습 분석

**구현 목표**: Drop-off 포인트 및 어려운 주차 자동 감지

```python
# analytics.py
def find_drop_off_points(progress_data):
    high_drop = {}
    for week in range(1, 17):
        drop_rate = calculate_drop_rate(week)
        if drop_rate > 30:
            high_drop[week] = drop_rate
    return high_drop
```

**체크리스트**:
- [ ] Python 분석 스크립트
- [ ] Drop-off 포인트 감지
- [ ] 어려운 주차 감지 (평균 <70점)
- [ ] 주간 자동 리포트 생성
- [ ] CSV 내보내기

---

### Week 3: UX 개선 (UI/UX 1명 + Unity 1명)

#### 📌 Day 1-3: 온보딩 튜토리얼

**구현 목표**: 신규 사용자 이탈률 감소 (35% → 20%)

**시나리오**:
```
LMS 튜토리얼 (5분):
1. 환영 (30초)
2. 학습 맵 (1분)
3. 콘텐츠 보기 (2분)
4. 퀴즈 체험 (1.5분)
5. 진행률 (30초)

시뮬레이터 튜토리얼 (5-10분):
1. 환영 (1분)
2. 이동 (1분)
3. NPC 대화 (2분)
4. 첫 의사결정 (3분)
5. 메트릭 (1min)
6. 마무리 (1분)
```

**체크리스트**:
- [ ] 튜토리얼 시나리오 작성
- [ ] 하이라이트 시스템
- [ ] 스킵 기능 (재방문자)
- [ ] "튜토리얼 완료" 배지
- [ ] 완료율 테스트 (목표 >90%)

#### 📌 Day 4-5: Juice (피드백감)

**구현 목표**: 모든 액션에 피드백

```csharp
// UIJuice.cs
public void OnButtonClick(GameObject button)
{
    button.transform.DOScale(0.9f, 0.1f)
           .OnComplete(() => button.transform.DOScale(1f, 0.1f));
    AudioManager.PlaySFX("click");
    SpawnParticle("spark", button.position);
}
```

**필요 에셋**:
- 사운드: button_click, success_chime, failure_buzz (8개)
- 파티클: 클릭 스파크, 성공 색종이, 실패 스파크

**체크리스트**:
- [ ] 버튼 클릭 애니메이션
- [ ] 성공/실패 파티클
- [ ] 사운드 이펙트 (8개)
- [ ] 메트릭 변화 애니메이션
- [ ] 만족도 테스트 (+0.5점)

---

### Week 4: 통합 및 테스트

#### 📌 Day 1-3: Q&A 게시판

**구현 목표**: 학습자 질문 채널

```typescript
// Firebase Firestore
interface QAPost {
  weekNumber: number;
  title: string;
  content: string;
  answers: Answer[];
  isResolved: boolean;
}
```

**체크리스트**:
- [ ] Firebase 설정
- [ ] 웹 앱 (간단한 게시판)
- [ ] Unity WebView 통합
- [ ] 강사/학습자 테스트

#### 📌 Day 4-5: 통합 테스트

**체크리스트**:
- [ ] 전체 플로우 테스트
- [ ] 크리티컬 버그 수정
- [ ] 내부 테스트 (10명)
- [ ] Alpha 테스트 준비

---

## ✅ 성공 기준

| 지표 | 현재 | 목표 |
|------|------|------|
| **종합 점수** | 70/100 | 78/100 |
| **학습 완료율** | 65% | 72% |
| **평균 플레이 시간** | 35분 | 40분 |
| **사용자 만족도** | 3.8/5.0 | 4.0/5.0 |
| **첫 15분 이탈률** | 35% | 20% |
| **강사 만족도** | N/A | 3.5/5.0 |

---

## 💰 예산

| 항목 | 비용 |
|------|------|
| Unity 개발자 2명 × 4주 | $8,000 |
| Backend 개발자 1명 × 2주 | $2,000 |
| UI/UX 디자이너 1명 × 2주 | $2,000 |
| QA 테스터 1명 × 1주 | $500 |
| 에셋 (사운드, 도구) | $600 |
| **총계** | **$13,100** |

---

## 🚀 즉시 시작

### 1주차 착수 전 준비
- [ ] 예산 확보 ($13,100)
- [ ] 팀원 확정 (4명)
- [ ] 개발 환경 설정
- [ ] Jira 태스크 생성
- [ ] 일일 스탠드업 스케줄

### 첫 3일 목표
- [ ] Time Block 시스템 프로토타입
- [ ] 게임 루프 테스트 가능 버전
- [ ] 팀 동기화 및 진행 상황 공유

---

## 📚 참고 문서

- [INTEGRATED_IMPROVEMENT_PROPOSAL.md](./INTEGRATED_IMPROVEMENT_PROPOSAL.md) - 전체 Phase 1-3 로드맵
- [EXPERT_EVALUATION_ELEARNING.md](./EXPERT_EVALUATION_ELEARNING.md) - 교육 전문가 평가 (72/100)
- [EXPERT_EVALUATION_GAME_DESIGN.md](./EXPERT_EVALUATION_GAME_DESIGN.md) - 게임 전문가 평가 (68/100)
- [UNITY_PROJECT_TECHNICAL_SPEC.md](./UNITY_PROJECT_TECHNICAL_SPEC.md) - 기술 사양서
- [UNITY_IMPLEMENTATION_ROADMAP.md](./UNITY_IMPLEMENTATION_ROADMAP.md) - 원래 8주 계획

---

**작성일**: 2025-02-04  
**버전**: 1.0  
**다음 업데이트**: Phase 1.5 완료 후 (4주 후)
