# 🎯 Phase 2 액션 플랜: 주요 기능 추가

> **기간**: 2025년 2월 6일 - 2025년 4월 15일 (8-10주)  
> **목표**: 78점 → 85점 (+9%)  
> **예산**: $37,000  
> **팀**: Unity 개발자 2명, Backend 개발자 1명, UI/UX 디자이너 1명, QA 테스터 1명

---

## 📊 Phase 2 목표

### 종합 목표
- **점수**: 78/100 (C+) → 85/100 (B)
- **학습 완료율**: 72% → 80%
- **평균 플레이 시간**: 40분 → 56분/세션
- **사용자 만족도**: 4.0/5.0 → 4.3/5.0
- **재방문율**: 주 2.5회 → 주 3회

### 핵심 개선사항
1. **개인화**: 적응형 학습 경로로 맞춤 학습
2. **협업**: 토론 포럼, 스터디 그룹으로 커뮤니티 학습
3. **몰입**: NPC AI 고도화로 실감나는 시뮬레이션
4. **도전**: 동적 난이도 조절로 적절한 도전감
5. **통합**: LMS-Simulator 양방향 연계

---

## 🗓️ Month 1: 교육 고도화 (Week 1-4)

### Week 1-3: 적응형 학습 경로

#### 목표
학습자의 수준에 맞는 맞춤형 학습 경로 제공

#### Day 1-5: 사전 평가 시스템

**구현**:
```
1. Diagnostic Test (10문항)
   - Week 1-16 핵심 개념 커버
   - 객관식 + 주관식 혼합
   - 15-20분 소요
   
2. 자동 채점 시스템
   - 정답률 계산
   - 카테고리별 강약점 분석
   - 학습자 레벨 분류 알고리즘
```

**파일**:
- `backend/diagnostic-test-api.js` - API 서버
- `backend/diagnostic-test-scoring.js` - 채점 및 분석
- `backend/mock-data/diagnostic-questions.json` - 진단 문제
- `unity-implementation/Scripts/Assessment/DiagnosticTestManager.cs` - Unity UI

**측정**:
- 진단 테스트 완료율: >90%
- 레벨 분류 정확도: >85%

#### Day 6-10: 레벨별 콘텐츠 매핑

**구현**:
```
3가지 학습 경로:

초급 (0-40점):
  - 사전학습 자료 필수
  - 기본 개념 강화
  - 추가 예제 제공
  - 더 많은 퀴즈

중급 (41-70점):
  - 표준 경로
  - 정규 커리큘럼

고급 (71-100점):
  - 심화 콘텐츠
  - 일부 Week 스킵 가능
  - 고급 챌린지
```

**파일**:
- `backend/adaptive-learning-api.js` - 경로 제공 API
- `backend/learning-path-generator.js` - 경로 생성 알고리즘
- `unity-implementation/Scripts/Learning/AdaptiveLearningManager.cs` - Unity 통합
- `unity-implementation/Data/JSON/learning-paths.json` - 경로 데이터

**측정**:
- 맞춤형 경로 학습 효과: +20%
- 학습 시간 효율: +15%

#### Day 11-15: 실시간 경로 조정

**구현**:
```
동적 조정 알고리즘:
- 퀴즈 성적 → 난이도 조정
- 학습 시간 → 콘텐츠 추천
- 이탈 징후 → 개입 트리거
- 빠른 진행 → 스킵 허용
```

**파일**:
- `backend/real-time-adjustment.js` - 실시간 분석
- `python/path-adjustment-ml.py` - ML 기반 예측 (선택)

**측정**:
- 조정 응답 시간: <5초
- 조정 만족도: >4.0/5.0

---

### Week 4: 협업 학습 기능

#### Day 1-3: 토론 포럼

**구현**:
```
기능:
- 주차별 토론방 (Week 1-16)
- 주제별 스레드
- 댓글, 좋아요, 북마크
- 강사/조교 인증 표시
```

**파일**:
- `backend/forum-api.js` - 포럼 API (10 endpoints)
- `backend/mock-data/forum-data.json` - 샘플 토론
- `unity-implementation/Scripts/Social/ForumManager.cs` - Unity UI

**측정**:
- 토론 참여율: >50%
- 주간 평균 게시물: 학습자당 1.5개

#### Day 4-5: 스터디 그룹

**구현**:
```
기능:
- 그룹 생성 (2-6인)
- 그룹 채팅
- 공동 목표 설정
- 그룹 진행률 시각화
```

**파일**:
- `backend/study-group-api.js` - 그룹 관리 API
- `unity-implementation/Scripts/Social/StudyGroupManager.cs` - Unity UI

**측정**:
- 그룹 생성율: >30%
- 그룹 학습 완료율: >75%

---

## 🗓️ Month 2: 게임 심화 (Week 5-8)

### Week 5-7: NPC AI 고도화

#### Day 1-5: 관계 시스템

**구현**:
```
관계 시스템:
- 신뢰도 (Trust): 0-100
- 호감도 (Affection): 0-100
- 존경도 (Respect): 0-100

관계 변화 요인:
- 의사결정 (+/-5)
- 대화 선택 (+/-3)
- 프로젝트 성과 (+/-10)
- 시간 경과 (자연 회복 +1/day)
```

**파일**:
- `unity-implementation/Scripts/NPC/RelationshipSystem.cs`
- `unity-implementation/Scripts/NPC/NPCRelationship.cs`
- `unity-implementation/Data/JSON/npc-personalities.json`

**측정**:
- NPC 관계 인식도: >80%
- 관계 기반 플레이 비율: >60%

#### Day 6-10: 감정 상태

**구현**:
```
4가지 감정 상태:
1. Happy (행복): 작업 효율 +20%
2. Neutral (평온): 기본 상태
3. Angry (화남): 협조 거부 가능
4. Anxious (불안): 실수 증가

감정 변화 트리거:
- 메트릭 변화 (품질↓ → Anxious)
- 의사결정 영향 (범위↑↑ → Angry)
- 관계 수준 (신뢰도 높음 → Happy)
```

**파일**:
- `unity-implementation/Scripts/NPC/EmotionSystem.cs`
- `unity-implementation/Scripts/NPC/EmotionVisualizer.cs`

**측정**:
- 감정 변화 인식도: >75%
- 감정 기반 전략 사용: >50%

#### Day 11-15: 동적 대화 시스템

**구현**:
```
대화 시스템:
- 사전 정의 대화 (1000개)
- 템플릿 기반 생성 (무한)
- 컨텍스트 인식 (프로젝트 상황, 관계, 감정)
- 대화 히스토리 참조

선택 사항 (Phase 3):
- GPT-3.5 API 통합 (비용 고려)
```

**파일**:
- `unity-implementation/Scripts/NPC/DialogueSystem.cs`
- `unity-implementation/Scripts/NPC/DialogueGenerator.cs`
- `unity-implementation/Data/JSON/dialogue-templates.json`

**측정**:
- 대화 만족도: >4.0/5.0
- NPC 인게이지먼트: +30%

---

### Week 8: 난이도 및 챌린지 시스템

#### Day 1-3: 동적 난이도 조절 (DDA)

**구현**:
```
DDA 알고리즘:
- 성공률 추적 (최근 10개 의사결정)
- 성공률 >70% → 난이도 +10%
- 성공률 <40% → 난이도 -10%
- 난이도 범위: 50% - 150%

난이도 조절 방법:
- 이벤트 빈도 증가/감소
- Time Block 압박 조절
- 메트릭 변화 폭 조절
```

**파일**:
- `unity-implementation/Scripts/Difficulty/DynamicDifficultySystem.cs`
- `unity-implementation/Scripts/Difficulty/DifficultyAdjuster.cs`

**측정**:
- 성공률 범위 유지: 50-70%
- 좌절감 감소: -30%

#### Day 4-5: 챌린지 및 도전 과제

**구현**:
```
챌린지 시스템:
- 선택적 보너스 목표
- 일일 챌린지 (3개)
- 주간 챌린지 (1개)
- 특별 챌린지 (이벤트)

보상:
- 경험치 2배
- 배지 획득
- 리더보드 등록
```

**파일**:
- `unity-implementation/Scripts/Challenge/ChallengeSystem.cs`
- `unity-implementation/Scripts/Challenge/LeaderboardManager.cs`
- `backend/leaderboard-api.js`

**측정**:
- 챌린지 참여율: >60%
- 평균 도전 완료: 주 2회

---

## 🗓️ Month 2.5: 통합 및 테스트 (Week 9-10)

### Week 9: LMS-Simulator 양방향 통합

#### Day 1-3: 학습 → 시뮬레이션 연계

**구현**:
```
통합 포인트:
- 주차 학습 완료 후 미니 시뮬레이션
- 이론 → 실습 즉시 적용
- 퀴즈 점수 → 시뮬레이션 난이도
```

**파일**:
- `unity-implementation/Scripts/Integration/LearningToSimBridge.cs`

#### Day 4-5: 시뮬레이션 → 학습 피드백

**구현**:
```
피드백 루프:
- 시뮬레이션 실패 → 복습 추천
- 약점 발견 → 관련 콘텐츠 링크
- 성과 → 다음 주차 준비도 평가
```

**파일**:
- `unity-implementation/Scripts/Integration/SimToLearningBridge.cs`
- `backend/feedback-loop-api.js`

**측정**:
- 통합 경험 만족도: 4.2/5.0
- 학습 전이 효과: +25%

---

### Week 10: Beta 테스트

#### Beta 테스트 계획

**규모**: 30-50명  
**기간**: 2주  
**대상**: PM 관심자, 교육자, 게임 플레이어

**테스트 항목**:
1. 적응형 학습 경로 (초/중/고급 각 10명)
2. 협업 기능 (스터디 그룹 5개)
3. NPC AI 인터랙션
4. 난이도 밸런싱
5. 통합 경험

**수집 데이터**:
- 완료율, 플레이 시간, 만족도
- 버그 리포트
- 개선 제안

**목표**:
- 크리티컬 버그: 0개
- 사용자 만족도: >4.0/5.0
- NPS (순추천고객지수): >30

---

## 📊 Phase 2 성공 지표

### 정량적 지표

| 지표 | Phase 1.5 | Phase 2 목표 | 측정 방법 |
|------|-----------|-------------|----------|
| 종합 점수 | 78/100 | 85/100 | 전문가 재평가 |
| 학습 완료율 | 72% | 80% | Analytics 데이터 |
| 평균 플레이 시간 | 40분 | 56분 | Session tracking |
| 사용자 만족도 | 4.0/5.0 | 4.3/5.0 | 설문조사 |
| 재방문율 | 주 2.5회 | 주 3회 | 로그인 로그 |
| 협업 참여율 | 0% | 50% | 포럼/그룹 활동 |
| NPC 인게이지먼트 | 기본 | +30% | 대화 시간 |
| 챌린지 참여율 | 0% | 60% | 챌린지 완료 |

### 정성적 목표

**학습자 관점**:
- "내 수준에 맞는 학습 경로가 제공된다"
- "다른 학습자들과 교류가 즐겁다"
- "NPC가 실제 팀원처럼 느껴진다"
- "적절한 도전감을 느낀다"

**강사 관점**:
- "학습자별 맞춤 지도가 가능하다"
- "협업 활동으로 학습 효과가 높아졌다"
- "데이터 기반 개입이 효과적이다"

---

## 💰 예산 계획

### 인건비

| 역할 | 인원 | 기간 | 주급 | 총계 |
|------|------|------|------|------|
| Unity 개발자 (Senior) | 1명 | 10주 | $1,000 | $10,000 |
| Unity 개발자 (Mid) | 1명 | 10주 | $800 | $8,000 |
| Backend 개발자 | 1명 | 8주 | $1,000 | $8,000 |
| UI/UX 디자이너 | 1명 | 6주 | $800 | $4,800 |
| 3D 아티스트 | 1명 | 4주 | $800 | $3,200 |
| QA 테스터 | 1명 | 2주 | $600 | $1,200 |
| **인건비 소계** | | | | **$35,200** |

### 기타 비용

| 항목 | 비용 |
|------|------|
| Beta 테스트 인센티브 (50명 × $20) | $1,000 |
| GPT-3.5 API (선택) | $0-500 |
| 클라우드 서버 (2개월) | $300 |
| **기타 소계** | **$1,300-1,800** |

### 총 예산
**$36,500 - $37,000**

---

## 🎯 마일스톤

### M1: Month 1 완료 (Week 4)
- ✅ 적응형 학습 경로 작동
- ✅ 협업 학습 기능 작동
- ✅ 점수: 78 → 81점 예상

### M2: Month 2 완료 (Week 8)
- ✅ NPC AI 고도화 완료
- ✅ 난이도 시스템 작동
- ✅ 점수: 81 → 84점 예상

### M3: Beta 테스트 완료 (Week 10)
- ✅ 모든 시스템 통합
- ✅ 버그 수정 완료
- ✅ 점수: 84 → 85점 달성

---

## 🚨 위험 관리

### 주요 리스크

1. **적응형 알고리즘 복잡도**
   - 위험도: High
   - 영향: 일정 지연, 품질 저하
   - 완화: 단순 규칙 기반 → ML 기반은 Phase 3

2. **NPC AI 성능**
   - 위험도: Medium
   - 영향: 몰입도 저하
   - 완화: 사전 정의 대화 충분히 준비

3. **Beta 테스트 참여자 모집**
   - 위험도: Medium
   - 영향: 피드백 부족
   - 완화: 조기 홍보, 인센티브 제공

4. **통합 복잡도**
   - 위험도: Medium
   - 영향: 버그 증가
   - 완화: 단계별 통합, 충분한 테스트

---

## 📚 산출물

### 코드
- 적응형 학습 시스템 (Backend + Unity, 예상 30KB)
- 협업 플랫폼 (Backend + Unity, 예상 25KB)
- NPC AI 시스템 (Unity, 예상 35KB)
- 난이도 시스템 (Unity, 예상 15KB)
- 통합 시스템 (Unity, 예상 10KB)
- **총 예상**: 115KB

### 문서
- Phase 2 실행 가이드
- 적응형 학습 알고리즘 문서
- NPC AI 설계 문서
- Beta 테스트 리포트
- Phase 2 완료 보고서

### 데이터
- 진단 테스트 문제 (10개)
- 학습 경로 데이터 (3가지)
- NPC 성격 데이터 (5-10명)
- 대화 템플릿 (1000개)
- 챌린지 데이터 (50개)

---

## ✅ 체크리스트

### Month 1 (Week 1-4)
- [ ] 사전 평가 시스템
- [ ] 레벨별 콘텐츠 매핑
- [ ] 실시간 경로 조정
- [ ] 토론 포럼
- [ ] 스터디 그룹

### Month 2 (Week 5-8)
- [ ] NPC 관계 시스템
- [ ] NPC 감정 상태
- [ ] 동적 대화 시스템
- [ ] 동적 난이도 조절
- [ ] 챌린지 시스템

### Month 2.5 (Week 9-10)
- [ ] LMS-Sim 통합
- [ ] Beta 테스트
- [ ] 버그 수정
- [ ] 최종 문서

---

**작성일**: 2025년 2월 6일  
**Phase 2 시작!** 🚀
