# PMP 버전 정렬 실행 계획

**계획 수립일**: 2025년 2월 9일  
**예상 기간**: 3주 (16-24시간)  
**담당**: PM Expert Training Team  
**우선순위**: High

---

## 📊 Executive Summary

### 현재 상황
- 커리큘럼이 PMBOK 6판과 7판이 혼재되어 사용 중
- 학습자 혼란 및 평가 불일치 발생

### 해결 방안
- **하이브리드 접근**: 6판 기반 + 7판 보충
- 최소 변경으로 최대 효과 달성
- 3주간 단계적 실행

### 기대 효과
- ✅ 버전 일관성 확보
- ✅ 학습자 혼란 해소
- ✅ PMP 시험 완벽 대응
- ✅ 실무 적용성 향상

---

## 📅 주차별 실행 계획

### Week 1: 기반 구축 (우선순위 1)
**목표**: 핵심 정책 수립 및 주요 문서 업데이트  
**예상 시간**: 6시간

#### Day 1-2: 정책 문서 (2시간)
- [x] ✅ `PMBOK_VERSION_POLICY.md` 작성
- [x] ✅ `PMP_VERSION_ALIGNMENT_ANALYSIS.md` 작성
- [ ] README.md 업데이트

**산출물**:
- PMBOK 버전 정책 문서
- 상세 분석 보고서

#### Day 3: README 업데이트 (1시간)
**파일**: `/README.md`

**변경 내용**:
```markdown
## 📌 PMBOK 버전 정책

본 프로그램은 **PMBOK 6th Edition (2017)**을 주요 학습 기반으로 하며, 
**PMBOK 7th Edition (2021)**의 주요 변화를 보충 자료로 다룹니다.

- ✅ **체계적 학습**: 6판의 49개 프로세스로 PM 기초 확립
- ✅ **최신 트렌드**: 7판의 12가지 원칙과 8개 성과 영역 학습
- ✅ **PMP 대비**: 7판 기반 시험에 완벽 대응
- ✅ **실무 적용**: 대부분 조직의 PM 프로세스와 일치

👉 [상세 버전 정책 보기](./PMBOK_VERSION_POLICY.md) | [분석 보고서](./PMP_VERSION_ALIGNMENT_ANALYSIS.md)
```

#### Day 4-5: Week 2 커리큘럼 보강 (3시간)
**파일**: `curriculum/week02-pm-fundamentals/week02-pm-fundamentals_detailed-lecture-materials.md`

**추가 섹션**:

1. **"PMBOK 6판과 7판 활용 가이드" 섹션 추가**
```markdown
## PMBOK 6판과 7판 활용 가이드

### 본 과정의 접근법
본 커리큘럼은 **PMBOK 6판을 주요 기반**으로 합니다:
- Week 1-8: 6판의 49개 프로세스 체계 학습
- Week 9: 애자일 (7판의 적응형 접근 포함)
- Week 10-12: 실습 (6판 프로세스 적용)

**7판 내용은 다음과 같이 통합**:
- 본 Week: 6판과 7판 상세 비교
- 각 주차: 해당 지식영역의 7판 성과 영역 언급
- PMP 준비: 7판 기반 시험 대응 가이드

### 학습자별 권장 경로
...
```

2. **비교표 확장**
```markdown
### 상세 비교: 프로세스 그룹 vs 성과 영역

| 6판 지식영역 | 6판 프로세스 수 | 7판 성과 영역 | 비고 |
|-------------|---------------|--------------|------|
| 통합 관리 | 7개 | Planning, Project Work | 프로젝트 전체 조율 |
| 범위 관리 | 6개 | Planning, Delivery | 요구사항 및 범위 정의 |
...
```

3. **PMP 시험 대비 가이드**
```markdown
### PMP 시험 준비를 위한 6판 + 7판 학습법

**현재 PMP 시험 (2021년 1월 이후)**:
- People (42%): 팀, 리더십, 이해관계자
- Process (50%): 프로젝트 수행 프로세스
- Business Environment (8%): 전략, 가치 실현

**효과적인 학습 전략**:
1. 6판 49개 프로세스 완벽 숙지
2. 7판 12가지 원칙 이해
3. 7판 8개 성과 영역 이해
4. 6판 프로세스 → 7판 성과 영역 매핑
5. 하이브리드/애자일 접근법 학습
```

---

### Week 2: 평가 정렬 (우선순위 2)
**목표**: 평가 자료 버전 통일  
**예상 시간**: 8-10시간

#### Day 1-2: 매핑 문서 작성 (4시간)
**파일**: `guides/pmbok-6th-to-7th-mapping.md` (신규)

**내용**:
```markdown
# PMBOK 6판 → 7판 매핑 가이드

## 개요
이 문서는 PMBOK 6판의 49개 프로세스가 7판의 8개 성과 영역에 
어떻게 매핑되는지 설명합니다.

## 10대 지식영역 → 8개 성과 영역 매핑

### 1. 통합 관리 (Integration Management)
**6판 프로세스**:
1. 프로젝트 헌장 개발
2. 프로젝트 관리 계획서 개발
...

**7판 성과 영역**:
- **Planning**: 프로젝트 계획 수립
- **Project Work**: 작업 수행 및 관리
- **Delivery**: 최종 인도물 제공

**실무 적용**:
- 기존 6판 프로세스를 그대로 사용하되
- 7판의 가치 전달 관점 추가
- 성과 영역별 핵심 결과물 확인
...
```

#### Day 3-4: 루브릭 업데이트 (4시간)
**파일**: `assessment/rubrics/week*.md` (전체)

**현재**:
```markdown
**참고 자료**:
- PMBOK Guide 7th Edition, Chapter 3
```

**변경 후**:
```markdown
**참고 자료**:
- PMBOK Guide 6th Edition, Chapter 1-2: PM Introduction
- PMBOK Guide 7th Edition: Stakeholders Performance Domain
- [PMBOK 6판 → 7판 매핑](../../guides/pmbok-6th-to-7th-mapping.md)
```

**파일 목록**:
- [ ] week01-rubric.md
- [ ] week02-rubric.md
- [ ] week03-rubric.md
- [ ] week04-rubric.md
- [ ] week05-rubric.md

#### Day 5: 퀴즈 업데이트 (2시간)
**파일**: `assessment/quizzes/week*.md` (전체)

**변경 사항**:
1. 모든 질문에 버전 명시
   ```markdown
   **질문** (PMBOK 6th Edition 기준): ...
   ```

2. 7판 관련 질문 추가
   ```markdown
   **질문**: PMBOK 7판에서 새롭게 강조하는 개념은?
   - a) 프로세스 그룹
   - b) 원칙 기반 접근 ✓
   - c) 지식영역
   - d) ITTO
   ```

**파일 목록**:
- [ ] week01-quiz.md
- [ ] week02-quiz.md

---

### Week 3: 보완 및 완료 (우선순위 3)
**목표**: 나머지 문서 정렬 및 검증  
**예상 시간**: 6-8시간

#### Day 1-2: 각 주차 헤더 추가 (3시간)
**대상**: 모든 주차 README 파일

**추가 내용**:
```markdown
---
> **📚 PMBOK 버전**: 이 자료는 PMBOK 6th Edition을 기반으로 하며, 
> 7th Edition의 주요 변화를 추가로 다룹니다.  
> [버전 정책 상세보기](../../PMBOK_VERSION_POLICY.md)
---
```

**파일 목록**:
- [ ] week01-pm-introduction_README.md
- [ ] week02-pm-fundamentals_README.md
- [ ] week03-stakeholder-management_README.md
- [ ] week04-scope-management_README.md
- [ ] week05-schedule-management_README.md
- [ ] week06-cost-management_README.md
- [ ] week07-quality-risk-management_README.md
- [ ] week08-resource-procurement_README.md
- [ ] week09-agile-scrum_README.md
- [ ] week10-pm-tools_README.md
- [ ] week11-12-mock-project_README.md

#### Day 3: 가이드 문서 업데이트 (2시간)
**파일 목록**:

1. **`guides/pmbok-summary.md`**
   - 상단에 버전 정책 명시
   - "이 요약은 PMBOK 6판 기반입니다" 추가

2. **`guides/pm-glossary.md`**
   - 6판/7판 용어 차이 추가
   - 예: "Quality Management (6판) / Quality (7판 성과 영역)"

3. **`guides/checklists.md`**
   - 버전 기반 명시
   - 7판 관점 체크리스트 추가 (선택사항)

#### Day 4: 자격증 가이드 보강 (1시간)
**파일**: `resources/certification-guide.md`

**추가 섹션**:
```markdown
## PMBOK 6판 vs 7판: PMP 시험 준비 전략

### 현재 PMP 시험 구성 (2021년 1월 이후)
- **기반**: PMBOK 7판 + Agile Practice Guide
- **구성**: People (42%), Process (50%), Business Environment (8%)

### 6판 학습이 중요한 이유
1. **프로세스 지식**: 시험의 50%는 여전히 프로세스 이해 필요
2. **ITTO 이해**: 프로세스 입출력 관계 파악 필수
3. **계산 문제**: EVM, 일정, 비용 계산은 6판 기반

### 7판 학습이 중요한 이유
1. **원칙 적용**: People 영역은 7판의 12가지 원칙 기반
2. **성과 영역**: 시험 문제가 성과 영역 관점으로 출제
3. **애자일 통합**: 하이브리드 접근 문제 증가

### 효과적인 학습 전략
**1단계: 6판 기반 구축** (60% 시간)
- 49개 프로세스 완벽 숙지
- ITTO 이해
- 계산 문제 연습

**2단계: 7판 통합** (30% 시간)
- 12가지 원칙 이해
- 8개 성과 영역 학습
- 6판 프로세스 → 7판 성과 영역 매핑

**3단계: 실전 대비** (10% 시간)
- 모의고사 (7판 기반)
- 하이브리드 시나리오 문제
- 약점 보완
```

#### Day 5: 검증 및 완료 (2시간)

**검증 체크리스트**:
- [ ] 모든 PMBOK 참조에 버전 명시
- [ ] 6판/7판 용어 일관성 확인
- [ ] 평가 자료와 강의 자료 일치 확인
- [ ] 링크 정상 작동 확인
- [ ] 오타 및 포맷팅 점검

**문서화**:
- [ ] CHANGELOG.md 업데이트
- [ ] 팀 공유 및 피드백 수렴
- [ ] 최종 배포

---

## 📋 상세 작업 체크리스트

### Phase 1: 정책 및 핵심 문서 (Week 1)

#### 정책 문서
- [x] ✅ PMBOK_VERSION_POLICY.md 작성
- [x] ✅ PMP_VERSION_ALIGNMENT_ANALYSIS.md 작성
- [ ] PMP_VERSION_IMPLEMENTATION_PLAN.md 작성 (현재 문서)

#### 메인 문서
- [ ] README.md 버전 정책 섹션 추가
- [ ] 커리큘럼 개요에 버전 정보 추가

#### Week 2 커리큘럼
- [ ] week02-pm-fundamentals_detailed-lecture-materials.md
  - [ ] "PMBOK 6판과 7판 활용 가이드" 섹션 추가
  - [ ] 6판 vs 7판 비교표 확장
  - [ ] PMP 시험 대비 가이드 추가
  - [ ] 학습자별 권장 경로 추가

### Phase 2: 평가 자료 정렬 (Week 2)

#### 매핑 문서
- [ ] guides/pmbok-6th-to-7th-mapping.md 생성
  - [ ] 10대 지식영역 → 8개 성과 영역 매핑
  - [ ] 49개 프로세스 개별 매핑
  - [ ] 실무 적용 가이드

#### 루브릭 업데이트
- [ ] assessment/rubrics/week01-rubric.md
- [ ] assessment/rubrics/week02-rubric.md
- [ ] assessment/rubrics/week03-rubric.md
- [ ] assessment/rubrics/week04-rubric.md
- [ ] assessment/rubrics/week05-rubric.md

#### 퀴즈 업데이트
- [ ] assessment/quizzes/week01-quiz.md
- [ ] assessment/quizzes/week02-quiz.md
- [ ] 6판/7판 비교 문제 추가

### Phase 3: 보완 작업 (Week 3)

#### 주차별 README 헤더
- [ ] curriculum/week01-pm-introduction/week01-pm-introduction_README.md
- [ ] curriculum/week02-pm-fundamentals/week02-pm-fundamentals_README.md
- [ ] curriculum/week03-stakeholder-management/week03-stakeholder-management_README.md
- [ ] curriculum/week04-scope-management/week04-scope-management_README.md
- [ ] curriculum/week05-schedule-management/week05-schedule-management_README.md
- [ ] curriculum/week06-cost-management/week06-cost-management_README.md
- [ ] curriculum/week07-quality-risk-management/week07-quality-risk-management_README.md
- [ ] curriculum/week08-resource-procurement/week08-resource-procurement_README.md
- [ ] curriculum/week09-agile-scrum/week09-agile-scrum_README.md
- [ ] curriculum/week10-pm-tools/week10-pm-tools_README.md
- [ ] curriculum/week11-12-mock-project/week11-12-mock-project_README.md

#### 가이드 문서
- [ ] guides/pmbok-summary.md - 버전 명시
- [ ] guides/pm-glossary.md - 용어 버전 차이 추가
- [ ] guides/checklists.md - 버전 기반 표시

#### 자원 문서
- [ ] resources/certification-guide.md - PMP 준비 전략 보강
- [ ] resources/recommended-books.md - 버전별 추천 명확화

#### 최종 검증
- [ ] 모든 PMBOK 참조 버전 확인
- [ ] 용어 일관성 검증
- [ ] 링크 동작 확인
- [ ] 문서 포맷팅 통일

---

## 🎯 성공 기준

### 정량적 지표
- ✅ **문서 업데이트**: 30개+ 파일
- ✅ **버전 명시**: 100% 파일에 버전 정보
- ✅ **매핑 완료**: 49개 프로세스 → 8개 성과 영역
- ✅ **검증 완료**: 모든 링크 및 참조 정상 동작

### 정성적 지표
- ✅ **학습자 혼란 해소**: 명확한 버전 정책
- ✅ **PMP 대비 강화**: 7판 기반 시험 대응
- ✅ **실무 적용성**: 6판 프로세스 유지
- ✅ **일관성 확보**: 전체 커리큘럼 버전 통일

---

## 📊 리스크 관리

### 주요 리스크

| 리스크 | 확률 | 영향 | 대응 전략 |
|--------|------|------|----------|
| 작업 시간 초과 | 중 | 중 | 우선순위 조정, 단계별 완료 |
| 내용 불일치 | 중 | 고 | 교차 검증, 전문가 리뷰 |
| 학습자 혼란 | 저 | 중 | 명확한 안내, FAQ 추가 |
| PMI 정책 변경 | 저 | 고 | 정기 모니터링, 빠른 대응 |

### 완화 계획
- **작업 시간 초과**: 우선순위 1, 2만 필수 완료
- **내용 불일치**: PM 전문가 최종 검토
- **학습자 혼란**: 전환 가이드 제공
- **정책 변경**: 분기별 PMI 자료 확인

---

## 📞 의사소통 계획

### 내부 팀
- **주간 회의**: 진행 상황 공유
- **Slack 채널**: 즉시 질의응답
- **문서 리뷰**: 각 단계 완료 후

### 학습자
- **공지사항**: 변경 사항 사전 안내
- **FAQ**: 자주 묻는 질문 업데이트
- **피드백**: 변경 후 설문조사

---

## 📈 측정 및 모니터링

### KPI
- **완료율**: 주차별 체크리스트 진행률
- **품질**: 검증 체크리스트 통과율
- **만족도**: 학습자 피드백 점수

### 보고 주기
- **주간**: 진행률 업데이트
- **완료 시**: 최종 보고서
- **1개월 후**: 효과 분석

---

## 🎓 교훈 및 다음 단계

### 향후 개선 사항
- [ ] 자동화 스크립트 개발 (버전 일관성 검증)
- [ ] 학습자 대시보드 (버전별 학습 진도)
- [ ] 인터랙티브 매핑 도구 (6판 ↔ 7판)

### 지속적 개선
- 분기별 버전 정책 검토
- 학습자 피드백 반영
- PMI 최신 자료 모니터링

---

**계획 버전**: 1.0  
**최종 업데이트**: 2025년 2월 9일  
**다음 검토**: 매주 금요일

---

## 빠른 참조

- [분석 보고서](./PMP_VERSION_ALIGNMENT_ANALYSIS.md)
- [버전 정책](./PMBOK_VERSION_POLICY.md)
- [진행 상황 추적](https://github.com/goodhitpe/pm-expert-training/projects)
