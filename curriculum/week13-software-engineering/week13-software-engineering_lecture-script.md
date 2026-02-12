# Week 13: 소프트웨어 공학 - 강의 스크립트 (Lecture Script)

> **강의 시간**: 6.0시간 (이론 3.0h + 실습 2.5h + 토론/퀴즈 0.5h)  
> **강의 방식**: 이론 강의 + 실습 + 사례 분석 + 도구 체험

---

## 📋 강의 개요

### 학습 목표
- SDLC (Software Development Life Cycle)의 주요 방법론 이해
- CI/CD 파이프라인 개념 및 PM 관점의 적용
- 소프트웨어 테스팅 전략 및 품질 관리
- Git 기본 개념 및 PM 필수 사용법
- 코드 리뷰 프로세스 및 품질 메트릭 이해

### 준비물
- 강의 자료: [week13-software-engineering_README.md](./week13-software-engineering_README.md)
- 참고 자료: [week13-software-engineering_detailed-lecture-materials.md](./week13-software-engineering_detailed-lecture-materials.md)
- 실습 도구: Git 설치, GitHub 계정, 코드 에디터 (VS Code)
- 데모 환경: CI/CD 파이프라인 시연

---

## 🕐 시간별 강의 진행 (총 6.0시간)

### [00:00-00:15] 도입 (15분)

**강의 포인트**:
```
👋 환영 및 IT 기술 영역 시작
"지난 2주간의 모의 프로젝트 정말 수고하셨습니다.
이제부터 4주간은 IT PM에게 필수적인 기술 영역을 배웁니다."

🎯 오늘 학습 목표
"오늘은 소프트웨어가 어떻게 만들어지는지 배웁니다.
PM이 직접 코딩을 할 필요는 없지만,
개발자와 소통하고 프로젝트를 관리하려면 
소프트웨어 개발 프로세스를 이해해야 합니다."

💡 동기 부여 질문
"여러분이 앱을 하나 만든다면, 어떤 단계를 거쳐야 할까요?"
(2-3명 답변 듣기)

📌 학습 로드맵
1. SDLC 방법론 (Waterfall, Agile, DevOps)
2. CI/CD 파이프라인
3. 테스팅 전략
4. Git 기초
5. 코드 품질 관리

"개발자들이 쓰는 용어를 이해하고, 
같은 언어로 대화할 수 있게 됩니다."
```

---

### [00:15-01:30] 섹션 1: SDLC 방법론 (75분)

#### [00:15-00:45] 1.1 Waterfall vs Agile (30분)

**강의 내용**:
```
📖 SDLC란?
"Software Development Life Cycle
소프트웨어 개발의 시작부터 끝까지의 과정"

🌊 Waterfall (폭포수 모델)

특징:
- 순차적 진행
- 각 단계 완료 후 다음 단계
- 명확한 문서화
- 변경 어려움

단계:
1. 요구사항 분석 (Requirements)
2. 설계 (Design)
3. 구현 (Implementation)
4. 테스트 (Testing)
5. 배포 (Deployment)
6. 유지보수 (Maintenance)

    요구사항
       ↓
      설계
       ↓
      구현
       ↓
     테스트
       ↓
      배포

장점:
✅ 명확한 단계와 문서
✅ 관리하기 쉬움
✅ 큰 프로젝트에 적합

단점:
❌ 변경에 취약
❌ 후반에 문제 발견
❌ 고객 피드백 늦음

💼 적합한 프로젝트:
- 요구사항이 명확하고 변경이 적음
- 규제가 많은 산업 (금융, 국방)
- 대규모 인프라 프로젝트

🏃 Agile (애자일)

특징:
- 반복적 개발 (Iterative)
- 점진적 인도 (Incremental)
- 빠른 피드백
- 변화 환영

핵심 가치 (Agile Manifesto):
1. 개인과 상호작용 > 프로세스와 도구
2. 작동하는 소프트웨어 > 포괄적 문서
3. 고객 협력 > 계약 협상
4. 변화 대응 > 계획 준수

스프린트 (2-4주 반복):
    ┌─────────────────────┐
    │  Sprint (2주)       │
    │  계획→개발→테스트→리뷰  │
    └─────────────────────┘
    ┌─────────────────────┐
    │  Sprint (2주)       │
    │  계획→개발→테스트→리뷰  │
    └─────────────────────┘

장점:
✅ 빠른 피드백
✅ 변화 대응
✅ 점진적 가치 제공

단점:
❌ 범위 불명확
❌ 문서 부족
❌ 고도의 협업 필요

💼 적합한 프로젝트:
- 요구사항이 불명확하거나 변경이 많음
- 빠른 출시가 중요
- 스타트업, 웹/모바일 앱

📊 비교 표:
| 구분 | Waterfall | Agile |
|------|-----------|-------|
| 접근 | 순차적 | 반복적 |
| 요구사항 | 초기 확정 | 점진적 발견 |
| 변경 | 어려움 | 환영 |
| 피드백 | 후반 | 지속적 |
| 문서 | 상세 | 최소 |
| 위험 | 후반 발견 | 조기 발견 |

💡 PM의 역할 차이:
Waterfall PM: 계획 수립 및 통제
Agile PM: 촉진자 및 장애물 제거
```

**교수법**:
- 두 방법론을 명확히 대비
- 실제 프로젝트 사례 활용
- 장단점을 현실적으로 설명

#### [00:45-01:15] 1.2 DevOps 및 현대적 접근 (30분)

**강의 내용**:
```
🔄 DevOps란?
"Development + Operations
개발과 운영의 통합"

전통적 방식의 문제:
개발팀: "우리는 잘 만들었어요"
운영팀: "배포하면 안 돌아가는데요?"
→ 사일로 (Silo), 책임 떠넘기기

DevOps 철학:
- 개발과 운영의 협업
- 자동화
- 지속적 개선
- 공유된 책임

핵심 원칙:
1. 문화 (Culture)
   - 협업과 신뢰
   - 실패를 학습 기회로

2. 자동화 (Automation)
   - 수동 작업 최소화
   - 반복 작업 자동화

3. 측정 (Measurement)
   - 모든 것을 측정
   - 데이터 기반 의사결정

4. 공유 (Sharing)
   - 지식 공유
   - 투명성

DevOps 생명주기:
    Plan → Code → Build → Test → Release → Deploy → Operate → Monitor
     ↑                                                                ↓
     └────────────────────────────────────────────────────────────────┘

💡 핵심 실천 사항:
1. CI/CD (Continuous Integration/Deployment)
2. Infrastructure as Code (IaC)
3. Monitoring & Logging
4. Microservices
5. Container (Docker, Kubernetes)

📊 DevOps 효과:
- 배포 빈도: 주 1회 → 하루 수십 회
- 리드 타임: 몇 주 → 몇 시간
- 장애 복구: 몇 시간 → 몇 분
- 변경 실패율: 15% → 5%

🎯 PM의 역할:
- DevOps 문화 촉진
- 자동화 투자 의사결정
- 개발-운영 간 가교
- 메트릭 모니터링 및 개선

💼 실무 사례: 넷플릭스
"하루 1000번 이상 배포
장애 시 자동 롤백
Chaos Engineering (의도적 장애 주입)"

💡 PM이 알아야 할 것:
- DevOps는 도구가 아닌 문화
- 초기 투자 필요 (자동화 구축)
- 장기적으로 ROI 높음
- 작은 것부터 시작
```

**교수법**:
- DevOps를 철학 수준에서 설명
- 전통적 방식과 대비
- 실제 기업 사례 활용

#### [01:15-01:30] 1.3 SDLC 선택 실습 (15분)

**실습 활동**:
```
🎯 시나리오 기반 의사결정

4가지 프로젝트 시나리오 제공:

시나리오 1: 은행 코어 시스템 교체
- 예산: $10M
- 기간: 2년
- 요구사항: 명확, 변경 불가
- 규제: 금융위원회 승인 필요
→ 어떤 방법론? 왜?

시나리오 2: 스타트업 MVPapp
- 예산: $50K
- 기간: 3개월
- 요구사항: 불명확, 시장 반응 보고 피봇 가능
- 속도: 빠른 출시 필수
→ 어떤 방법론? 왜?

시나리오 3: 전자상거래 플랫폼 개선
- 기존 시스템 운영 중
- 신기능 지속적 추가
- A/B 테스트 필수
- 무중단 배포 필요
→ 어떤 방법론? 왜?

시나리오 4: 의료 기기 소프트웨어
- FDA 승인 필요
- 엄격한 문서화 요구
- 변경 추적 필수
- 생명과 직결
→ 어떤 방법론? 왜?

💬 활동 방식:
1. 개인 판단 (3분)
2. 짝 토론 (5분)
3. 전체 공유 및 토론 (7분)

💡 정답:
시나리오 1: Waterfall (명확한 요구사항, 규제)
시나리오 2: Agile (불확실성, 속도)
시나리오 3: DevOps + Agile (지속적 개선)
시나리오 4: Waterfall + DevOps (문서 + 자동화)

핵심 통찰:
"완벽한 방법론은 없습니다.
프로젝트 특성에 맞게 선택하고 조합하세요."
```

---

### [01:30-01:45] 휴식 (15분)

---

### [01:45-03:00] 섹션 2: CI/CD 파이프라인 (75분)

#### [01:45-02:15] 2.1 CI/CD 개념 (30분)

**강의 내용**:
```
🔄 CI: Continuous Integration (지속적 통합)

전통적 방식의 문제:
- 개발자들이 각자 개발
- 주 1회 통합
- 통합 시 충돌/오류 폭발
- "Integration Hell" (통합 지옥)

CI의 해결책:
- 하루에 여러 번 코드 통합
- 자동 빌드 및 테스트
- 문제 조기 발견
- 빠른 피드백

CI 프로세스:
1. 개발자가 코드 작성
2. Git에 Push
3. CI 서버가 자동 감지
4. 자동 빌드
5. 자동 테스트 실행
6. 결과 통보 (성공/실패)

    ┌─────────┐      ┌─────────┐      ┌─────────┐
    │ Commit  │ ───▶ │  Build  │ ───▶ │  Test   │
    └─────────┘      └─────────┘      └─────────┘
                                            │
                                      ✅ 또는 ❌

CI 도구:
- Jenkins
- GitLab CI
- GitHub Actions
- CircleCI
- Travis CI

💡 CI의 원칙:
1. 하나의 소스 저장소
2. 빌드 자동화
3. 테스트 자동화
4. 매일 통합
5. 빠른 빌드 (<10분)
6. 자동 배포 (스테이징)

🚀 CD: Continuous Delivery/Deployment

CD 두 가지 의미:

1️⃣ Continuous Delivery (지속적 전달)
- 언제든 배포 가능한 상태 유지
- 배포는 수동 승인
- 버튼 하나로 배포 가능

2️⃣ Continuous Deployment (지속적 배포)
- 자동으로 프로덕션 배포
- 수동 개입 없음
- 모든 변경이 자동 배포

CD 파이프라인:
    Build → Test → Staging → (승인) → Production
    
    또는 (Continuous Deployment):
    Build → Test → Staging → Production (자동)

🎯 배포 전략:

1. Blue-Green Deployment
   - Blue (현재): 사용자 서비스 중
   - Green (새 버전): 준비 완료
   - 스위치로 순간 전환
   - 문제 시 즉시 롤백

2. Canary Deployment
   - 일부 사용자에게만 새 버전
   - 10% → 50% → 100% 점진적
   - 문제 발생 시 영향 최소화

3. Rolling Deployment
   - 서버를 하나씩 업데이트
   - 무중단 배포
   - 느리지만 안전

💡 PM이 알아야 할 것:
- CI/CD는 자동화의 핵심
- 초기 구축 비용 vs 장기 효율성
- 배포 빈도와 품질은 trade-off 아님
- 빠른 피드백이 리스크 감소

📊 CI/CD 효과:
Before CI/CD:
- 배포: 월 1회, 금요일 밤
- 배포 시간: 4시간
- 실패율: 30%
- 복구 시간: 1일

After CI/CD:
- 배포: 하루 수십 회
- 배포 시간: 10분
- 실패율: 5%
- 복구 시간: 10분
```

**교수법**:
- CI/CD의 가치를 명확히 전달
- Before/After 비교
- 실제 배포 전략 사례

#### [02:15-02:45] 2.2 CI/CD 파이프라인 데모 (30분)

**실습/데모**:
```
💻 GitHub Actions를 이용한 CI/CD 데모

시나리오:
"간단한 웹 애플리케이션의 CI/CD 파이프라인 구축"

1️⃣ 샘플 프로젝트 소개 (5분)
- Node.js 기반 웹 앱
- 간단한 API 엔드포인트
- 유닛 테스트 포함

2️⃣ GitHub Actions 설정 (10분)

`.github/workflows/ci.yml` 파일:

```yaml
name: CI/CD Pipeline

on:
  push:
    branches: [ main ]
  pull_request:
    branches: [ main ]

jobs:
  build:
    runs-on: ubuntu-latest
    
    steps:
    - uses: actions/checkout@v2
    
    - name: Setup Node.js
      uses: actions/setup-node@v2
      with:
        node-version: '14'
    
    - name: Install dependencies
      run: npm install
    
    - name: Run linter
      run: npm run lint
    
    - name: Run tests
      run: npm test
    
    - name: Build
      run: npm run build
    
    - name: Deploy to Staging
      if: github.ref == 'refs/heads/main'
      run: ./deploy-staging.sh
```

3️⃣ 파이프라인 실행 시연 (10분)
- 코드 변경 및 커밋
- GitHub에서 실행 과정 관찰
- 각 단계 로그 확인
- 성공/실패 알림

4️⃣ 주요 포인트 설명 (5분)
- Trigger: Push 또는 PR 시 자동 실행
- Steps: 순차적 실행
- Parallel Jobs: 병렬 실행 가능
- Notifications: Slack, 이메일 연동

💡 PM 관점의 통찰:
"이 파이프라인이 없으면?"
- 수동 빌드: 30분
- 수동 테스트: 1시간
- 수동 배포: 30분
→ 총 2시간 vs 자동화 5분

"투자 대비 효과:"
- 파이프라인 구축: 2일
- 매일 5회 배포 × 1.5시간 절약 = 7.5시간/일
- 1주일이면 투자 회수
```

**교수법**:
- 라이브 데모로 실제 동작 확인
- 각 단계의 의미 설명
- PM이 이해해야 할 핵심만

#### [02:45-03:00] 휴식 (15분)

---

### [03:00-04:15] 섹션 3: 소프트웨어 테스팅 (75분)

#### [03:00-03:40] 3.1 테스트 레벨과 유형 (40분)

**강의 내용**:
```
🧪 소프트웨어 테스팅이란?
"소프트웨어가 의도대로 동작하는지 확인하는 과정"

테스트 피라미드:
           /\
          /  \    E2E Tests (5%)
         /────\   
        /      \  Integration Tests (15%)
       /────────\ 
      /          \ Unit Tests (80%)
     /────────────\

💡 테스트 피라미드 원칙:
- 아래로 갈수록 빠르고 저렴
- 위로 갈수록 느리고 비쌈
- 유닛 테스트를 가장 많이!

1️⃣ Unit Test (단위 테스트)

정의:
- 함수, 메서드 단위 테스트
- 독립적 실행
- 빠르고 저렴

예시:
```javascript
function add(a, b) {
  return a + b;
}

test('add function', () => {
  expect(add(2, 3)).toBe(5);
  expect(add(-1, 1)).toBe(0);
});
```

특징:
✅ 빠름 (<1초)
✅ 문제 정확히 파악
✅ 리팩토링 신뢰
❌ 전체 통합 확인 불가

2️⃣ Integration Test (통합 테스트)

정의:
- 모듈 간 상호작용 테스트
- 여러 컴포넌트 통합
- 인터페이스 확인

예시:
```javascript
test('user registration', async () => {
  const user = await createUser({
    email: 'test@example.com',
    password: 'password123'
  });
  
  const savedUser = await database.findUser(user.id);
  expect(savedUser.email).toBe('test@example.com');
});
```

특징:
✅ 실제 상호작용 검증
✅ 통합 버그 발견
❌ 느림 (초-분)
❌ 실패 원인 파악 어려움

3️⃣ System Test (시스템 테스트)

정의:
- 전체 시스템 테스트
- 요구사항 검증
- 실제 환경과 유사

예시:
- API 엔드투엔드 테스트
- 데이터베이스 포함
- 외부 서비스 연동

4️⃣ E2E Test (End-to-End)

정의:
- 사용자 시나리오 테스트
- UI부터 DB까지
- 실제 사용자처럼

예시 (Selenium):
```python
def test_login():
  browser.get('https://example.com')
  browser.find_element_by_id('email').send_keys('user@example.com')
  browser.find_element_by_id('password').send_keys('password')
  browser.find_element_by_id('login-button').click()
  assert 'Dashboard' in browser.title
```

특징:
✅ 실제 사용자 경험 검증
✅ 전체 시스템 확인
❌ 매우 느림 (분-시간)
❌ 불안정 (Flaky)
❌ 유지보수 비용 높음

📊 테스트 유형 비교:

| 유형 | 속도 | 비용 | 신뢰도 | 비율 |
|------|------|------|--------|------|
| Unit | 매우 빠름 | 낮음 | 높음 | 70-80% |
| Integration | 보통 | 보통 | 높음 | 15-20% |
| E2E | 느림 | 높음 | 보통 | 5-10% |

🎯 그 외 테스트 유형:

1. Functional Testing (기능 테스트)
   - 기능이 제대로 작동하는가?

2. Non-Functional Testing
   - Performance: 빠른가?
   - Security: 안전한가?
   - Usability: 사용하기 쉬운가?
   - Scalability: 확장 가능한가?

3. Regression Testing (회귀 테스트)
   - 새 기능이 기존 기능을 망가뜨리지 않았나?

4. Smoke Testing (스모크 테스트)
   - 기본 기능이 작동하나? (빠른 확인)

5. UAT (User Acceptance Testing)
   - 사용자가 만족하는가?

💡 PM이 알아야 할 것:
- 모든 테스트를 다 할 필요 없음
- 위험도 기반 테스트 전략
- 자동화 vs 수동 테스트 밸런스
- 테스트 비용 vs 버그 비용

🐛 버그 발견 비용:
- 개발 중: $100
- 테스트 중: $1,000
- 배포 후: $10,000
- 고객 발견: $100,000

"초기 테스트 투자가 나중에 수백 배 절약"
```

**교수법**:
- 테스트 피라미드로 전체 구조 제시
- 각 테스트 레벨의 실제 코드 예시
- 비용 관점의 의사결정 설명

#### [03:40-04:15] 3.2 테스트 전략 및 품질 메트릭 (35분)

**강의 내용**:
```
📋 테스트 전략 수립

1️⃣ 리스크 기반 테스트
"모든 것을 테스트할 수 없다. 우선순위를 정하라"

리스크 매트릭스:
         높음  │ 중간   높음
 영향도  ─────┼──────────
         낮음  │ 낮음   중간
               └──────────
                낮음    높음
                  발생 가능성

High Risk → 집중 테스트
Medium Risk → 일반 테스트
Low Risk → 최소 테스트

예시:
- 결제 시스템: High Risk → 철저히
- 검색 기능: Medium Risk → 보통
- About 페이지: Low Risk → 기본만

2️⃣ 테스트 커버리지

Code Coverage:
- Line Coverage: 실행된 코드 줄 비율
- Branch Coverage: 분기 처리 비율
- Function Coverage: 함수 호출 비율

목표 설정:
- Critical: 100%
- Important: 80%+
- Normal: 60%+

⚠️ 주의: 100% 커버리지 ≠ 버그 없음
"양이 아닌 질이 중요"

3️⃣ 테스트 자동화 전략

자동화 ROI:
반복 횟수 × 시간 절약 > 자동화 비용

자동화 우선순위:
✅ 자주 실행되는 테스트
✅ 안정적인 기능
✅ 단순 반복 작업
❌ 자주 변경되는 UI
❌ 일회성 테스트

4️⃣ Shift-Left Testing
"테스트를 더 일찍"

        Traditional              Shift-Left
    ────────────────────    ────────────────────
    요구사항                 요구사항 + 테스트 케이스
    설계                     설계 + 테스트 설계
    개발                     TDD (Test-Driven Dev)
    테스트 ← 여기서 발견     여기서는 확인만

TDD (Test-Driven Development):
1. 실패하는 테스트 작성
2. 테스트 통과하는 최소 코드 작성
3. 리팩토링
4. 반복

BDD (Behavior-Driven Development):
Given (준비)
When (실행)
Then (검증)

예시:
```gherkin
Given 사용자가 로그인되어 있고
When 장바구니에 상품을 추가하면
Then 장바구니 아이콘에 숫자 1이 표시된다
```

📊 품질 메트릭

1️⃣ 결함 메트릭:
- Defect Density: 결함 수 / KLOC (천 줄)
- Defect Removal Efficiency: 테스트에서 발견된 결함 / 전체 결함
- Defect Leakage: 프로덕션에서 발견된 결함 비율

2️⃣ 테스트 메트릭:
- Test Coverage: 테스트된 코드 비율
- Pass Rate: 통과한 테스트 비율
- Test Execution Time: 전체 테스트 수행 시간

3️⃣ 프로세스 메트릭:
- Mean Time to Detect (MTTD): 버그 발견까지 시간
- Mean Time to Resolve (MTTR): 버그 수정까지 시간
- Cycle Time: 개발 완료부터 배포까지

4️⃣ 품질 게이트:
"이 기준을 통과해야 다음 단계로"

예시 기준:
✅ 유닛 테스트 커버리지 80% 이상
✅ Critical/High 버그 0건
✅ Code Review 승인
✅ 성능 테스트 통과
✅ 보안 스캔 통과

통과 못하면?
→ 배포 불가, 다시 개발

💡 PM의 역할:
- 테스트 전략 수립 지원
- 품질 메트릭 모니터링
- 품질 vs 일정 trade-off 의사결정
- 품질 게이트 설정 및 예외 승인

💼 실무 사례:
"출시 일정이 촉박한데 Critical 버그 1건이 남았다면?"

Option 1: 일정 연기 (품질 우선)
Option 2: 알려진 이슈로 출시 (일정 우선)
Option 3: Workaround 제공 (절충)

→ 리스크 분석 및 이해관계자 협의 필요
```

**교수법**:
- 전략적 사고 강조
- 실무 의사결정 시나리오
- 메트릭의 실질적 활용

---

### [04:15-04:30] 휴식 (15분)

---

### [04:30-05:30] 섹션 4: Git 기초 및 협업 (60분)

#### [04:30-05:00] 4.1 Git 개념 및 기본 명령어 (30분)

**강의 내용**:
```
🌳 Git이란?
"분산 버전 관리 시스템 (Distributed Version Control System)"

왜 Git인가?
❌ 파일명 버전 관리의 문제:
- project_final.zip
- project_final_v2.zip
- project_final_final.zip
- project_final_really_final.zip

✅ Git의 해결책:
- 모든 변경 이력 추적
- 누가, 언제, 무엇을 변경했는지
- 이전 버전으로 복구 가능
- 병렬 개발 및 통합

🎯 Git 핵심 개념:

1️⃣ Repository (저장소)
- 프로젝트의 전체 이력이 저장된 곳
- Local Repository: 내 컴퓨터
- Remote Repository: GitHub, GitLab

2️⃣ Commit (커밋)
- 변경 사항의 스냅샷
- 고유한 ID (SHA)
- 커밋 메시지

Commit History:
    A ← B ← C ← D ← E (현재)
    
    A: 초기 커밋
    B: 로그인 기능 추가
    C: 버그 수정
    D: API 통합
    E: UI 개선

3️⃣ Branch (브랜치)
"독립적인 개발 라인"

    main:     A ← B ← C ← F ← G
                    ↑
    feature:        D ← E
    
    C에서 분기 → 독립 개발 → 나중에 병합

4️⃣ Merge (병합)
"브랜치를 합치기"

5️⃣ Pull Request (PR)
"코드 리뷰 요청"

🔧 Git 기본 명령어:

1️⃣ 저장소 초기화:
```bash
git init                  # 새 저장소 생성
git clone <url>          # 원격 저장소 복제
```

2️⃣ 기본 워크플로우:
```bash
git status               # 상태 확인
git add <file>           # 스테이징
git add .                # 모든 변경 사항 스테이징
git commit -m "메시지"   # 커밋
git push                 # 원격에 업로드
git pull                 # 원격에서 다운로드
```

Git 작업 흐름:
    Working Directory (작업 중)
           ↓ git add
    Staging Area (커밋 준비)
           ↓ git commit
    Local Repository (내 컴퓨터)
           ↓ git push
    Remote Repository (GitHub)

3️⃣ 브랜치 관리:
```bash
git branch               # 브랜치 목록
git branch <name>        # 새 브랜치 생성
git checkout <branch>    # 브랜치 전환
git checkout -b <name>   # 생성 + 전환
git merge <branch>       # 병합
git branch -d <name>     # 브랜치 삭제
```

4️⃣ 이력 확인:
```bash
git log                  # 커밋 이력
git log --oneline        # 간략한 이력
git diff                 # 변경 사항 확인
git show <commit-id>     # 특정 커밋 상세
```

5️⃣ 되돌리기:
```bash
git reset <file>         # 스테이징 취소
git reset --hard         # 모든 변경 취소 (위험!)
git revert <commit-id>   # 커밋 되돌리기 (안전)
```

💡 PM이 알아야 할 명령어:
```bash
git log --oneline --graph  # 이력 시각화
git blame <file>           # 누가 이 코드를 작성했나?
git show <commit-id>       # 특정 커밋 상세
git diff main...feature    # 브랜치 차이 확인
```

"PM이 직접 코딩은 안 하지만, 
개발자와 소통하고 진척도를 파악하려면 Git을 알아야 합니다"
```

**교수법**:
- Git의 철학과 개념 먼저
- 명령어는 PM에게 필요한 것만
- 실습은 간단하게

#### [05:00-05:30] 4.2 Git 실습 및 협업 워크플로우 (30분)

**실습 활동**:
```
💻 Git 실습

🎯 실습 1: 기본 워크플로우 (15분)

Step 1: 저장소 초기화
```bash
mkdir my-project
cd my-project
git init
```

Step 2: 파일 생성 및 커밋
```bash
echo "# My Project" > README.md
git add README.md
git commit -m "Initial commit"
```

Step 3: 파일 수정 및 커밋
```bash
echo "This is a PM training project" >> README.md
git add README.md
git commit -m "Update README with description"
```

Step 4: 이력 확인
```bash
git log --oneline --graph
```

🎯 실습 2: 브랜치 및 병합 (15분)

Step 1: 새 브랜치 생성
```bash
git checkout -b feature/add-license
```

Step 2: LICENSE 파일 추가
```bash
echo "MIT License" > LICENSE
git add LICENSE
git commit -m "Add MIT license"
```

Step 3: main 브랜치로 전환
```bash
git checkout main
```

Step 4: 병합
```bash
git merge feature/add-license
```

Step 5: 브랜치 삭제
```bash
git branch -d feature/add-license
```

🤝 협업 워크플로우

1️⃣ Feature Branch Workflow
"기능별로 브랜치를 만들어 개발"

    main (보호됨)
      ↓ 브랜치 생성
    feature/login
      ↓ 개발 및 커밋
    Pull Request
      ↓ 코드 리뷰
    Merge (승인 후)
      ↓
    main (업데이트)

2️⃣ Git Flow
"체계적인 브랜치 전략"

    main:        프로덕션 (배포용)
    develop:     개발 통합 브랜치
    feature/*:   기능 개발
    release/*:   출시 준비
    hotfix/*:    긴급 수정

예시:
```bash
# 기능 개발 시작
git checkout -b feature/payment develop

# 개발 완료 후
git checkout develop
git merge feature/payment

# 출시 준비
git checkout -b release/v1.0 develop

# 출시
git checkout main
git merge release/v1.0
git tag v1.0
```

3️⃣ GitHub Flow (간단)
"지속적 배포에 적합"

    main (항상 배포 가능)
      ↓
    feature 브랜치
      ↓ PR
    Code Review
      ↓ 승인
    Merge → Deploy

💡 PM 관점에서 Git:

1. 진척도 파악:
```bash
git log --since="1 week ago" --oneline
# 지난 주 작업 내용 확인
```

2. 기여도 확인:
```bash
git shortlog -sn
# 개발자별 커밋 수
```

3. 코드 변경 추적:
```bash
git blame app.js
# 각 줄을 누가 작성했는지
```

4. 브랜치 현황:
```bash
git branch -a
# 모든 브랜치 확인
```

🎯 실무 활용:
- Daily standup: "어제 어떤 커밋을 했나요?"
- Sprint review: "이번 스프린트의 커밋 이력"
- 문제 추적: "이 버그는 어느 커밋에서 발생했나?"
- 기여도 분석: "누가 가장 활발하게 작업하고 있나?"
```

**교수법**:
- 실습 중심
- 강사가 먼저 시연
- 수강생들이 따라하기
- PM 관점의 활용법 강조

---

### [05:30-06:00] 섹션 5: 코드 리뷰 및 품질 관리 (30분)

**강의 내용**:
```
👀 코드 리뷰란?
"다른 개발자가 작성한 코드를 검토하는 과정"

왜 코드 리뷰를 하는가?
1. 버그 조기 발견
2. 코드 품질 향상
3. 지식 공유
4. 팀 코딩 스타일 통일
5. 멘토링 및 학습

📊 통계:
- 코드 리뷰로 60-70% 버그 발견
- 개발 속도 10-15% 향상 (장기적)
- 코드 이해도 증가

🔍 코드 리뷰 프로세스:

1️⃣ Pull Request 생성
- 기능 개발 완료
- PR 생성 및 설명 작성
- 리뷰어 지정

2️⃣ 리뷰 수행
- 코드 읽기
- 문제점 지적
- 개선 제안
- 질문

3️⃣ 피드백 반영
- 수정 커밋
- 토론 및 설명

4️⃣ 승인 및 병합
- Approve
- Merge to main

📋 코드 리뷰 체크리스트:

1️⃣ 기능성:
✅ 요구사항 충족?
✅ 예상대로 동작?
✅ 엣지 케이스 처리?

2️⃣ 코드 품질:
✅ 읽기 쉬운가?
✅ 중복 코드 없는가?
✅ 함수가 너무 크지 않은가?
✅ 변수명이 명확한가?

3️⃣ 테스트:
✅ 유닛 테스트 포함?
✅ 테스트 커버리지 충분?
✅ 엣지 케이스 테스트?

4️⃣ 성능:
✅ 성능 이슈 없는가?
✅ 불필요한 연산 없는가?
✅ 메모리 누수 없는가?

5️⃣ 보안:
✅ 보안 취약점 없는가?
✅ 입력 검증?
✅ 민감 정보 하드코딩?

6️⃣ 문서:
✅ 코드 주석 적절?
✅ API 문서 업데이트?
✅ README 업데이트?

💬 효과적인 코드 리뷰 댓글:

❌ 나쁜 예:
"이 코드 별로네요"
"다시 작성하세요"
"왜 이렇게 했어요?"

✅ 좋은 예:
"이 부분은 함수로 분리하면 재사용하기 좋을 것 같습니다"
"엣지 케이스가 고려되지 않은 것 같습니다: [예시]"
"성능 개선 제안: 이 반복문을 Map으로 대체하면 O(n²)→O(n)"

원칙:
- 코드를 비판, 사람을 비판하지 않음
- 구체적이고 실행 가능한 피드백
- 긍정적 피드백도 함께
- 질문하는 톤

📊 코드 품질 메트릭:

1️⃣ Cyclomatic Complexity (순환 복잡도)
- 코드의 복잡성 측정
- 경로의 수
- <10: Good, 10-20: Medium, >20: High

2️⃣ Code Duplication (중복 코드)
- 중복된 코드 비율
- <5% 권장

3️⃣ Code Smells (코드 냄새)
- 잠재적 문제 징후
- 긴 함수
- 큰 클래스
- 중복 코드
- 긴 매개변수 목록

4️⃣ Technical Debt (기술 부채)
- 나중에 수정해야 할 것들
- 임시 해결책 (Workaround)
- 미완성 리팩토링
- 누적되면 개발 속도 저하

Technical Debt Quadrant:
    의도적      │  전략적   무모한
    ──────────┼────────────
    무의식적    │  신중한   비효율적
                └────────────

🎯 정적 분석 도구:

1. SonarQube
- 종합 코드 품질 분석
- Bugs, Vulnerabilities, Code Smells
- 대시보드 제공

2. ESLint (JavaScript)
- 코딩 스타일 검사
- 자동 수정 가능

3. Pylint (Python)
4. RuboCop (Ruby)
5. Checkstyle (Java)

💡 PM의 역할:

1️⃣ 코드 리뷰 문화 조성
- 코드 리뷰를 일정에 반영
- 리뷰 시간 확보 (개발 시간의 10-15%)
- 건설적 피드백 문화

2️⃣ 프로세스 정립
- 리뷰 기준 및 체크리스트
- 리뷰어 지정 규칙
- 승인 기준

3️⃣ 도구 도입
- 코드 리뷰 툴 (GitHub, GitLab)
- 정적 분석 도구
- CI/CD 통합

4️⃣ 메트릭 모니터링
- 리뷰 소요 시간
- 발견된 이슈 수
- 코드 품질 트렌드

5️⃣ 기술 부채 관리
- 기술 부채 추적
- 리팩토링 시간 할당
- 품질 vs 속도 밸런스

💼 실무 사례:
"출시 일정이 촉박할 때 코드 리뷰를 건너뛰자는 의견이 나온다면?"

❌ 건너뛰기: 단기 이득, 장기 손실
✅ 필수 리뷰만: 핵심 부분만 리뷰
✅ 페어 프로그래밍: 리뷰+개발 동시
✅ 출시 후 리뷰: 기술 부채로 기록

"코드 리뷰를 건너뛰는 것은 미래의 속도를 빌려오는 것"
```

**교수법**:
- 코드 리뷰의 가치 강조
- PM 관점의 프로세스 관리
- 문화와 도구의 균형

---

### [05:45-06:00] 마무리 및 평가 (15분)

**강의 내용**:
```
📌 오늘 배운 핵심 내용

1️⃣ SDLC 방법론
- Waterfall: 순차적, 명확한 요구사항
- Agile: 반복적, 변화 대응
- DevOps: 개발+운영 통합, 자동화

2️⃣ CI/CD 파이프라인
- 지속적 통합 및 배포
- 자동화를 통한 효율성 및 품질 향상
- 배포 전략 (Blue-Green, Canary)

3️⃣ 소프트웨어 테스팅
- 테스트 피라미드 (Unit > Integration > E2E)
- 리스크 기반 테스트 전략
- 품질 메트릭 및 게이트

4️⃣ Git 기초
- 버전 관리 시스템
- 브랜치 및 병합
- 협업 워크플로우

5️⃣ 코드 리뷰 및 품질
- 코드 리뷰 프로세스
- 품질 메트릭
- 기술 부채 관리

💬 질문 타임
"오늘 배운 내용 중 가장 중요하다고 생각하는 것은?"
"실무에 바로 적용하고 싶은 것은?"

✅ 퀴즈 (구두)
1. CI/CD의 장점 3가지는?
2. 테스트 피라미드에서 가장 많아야 하는 테스트는?
3. Git에서 브랜치는 왜 사용하나요?
4. 코드 리뷰의 주요 목적 3가지는?

📝 과제
1. Git 실습: 개인 GitHub 프로젝트 생성
   - README, LICENSE 파일 포함
   - 3개 이상 커밋
   - 2개 브랜치 생성 및 병합

2. CI/CD 파이프라인 설계 (A4 1장)
   - 본인의 프로젝트 (또는 가상)
   - 파이프라인 단계 정의
   - 각 단계의 목적 및 도구

3. 테스트 전략 수립 (A4 1-2장)
   - 프로젝트 선택
   - 리스크 분석
   - 테스트 레벨별 계획
   - 품질 게이트 정의

📚 다음 주 예고
"Week 14: 데이터베이스"
- RDBMS 개념 및 ER 다이어그램
- SQL 기초 (SELECT, JOIN)
- NoSQL 개요
- 데이터베이스 설계 및 성능

"개발자와 대화하려면 데이터베이스를 이해해야 합니다.
다음 주에는 실제로 SQL을 작성해보며 배웁니다!"

🙏 마무리
"오늘 소프트웨어 개발 프로세스의 핵심을 배웠습니다.
이제 개발자들이 무슨 일을 하는지 이해하셨을 겁니다.
다음 주에 뵙겠습니다. 수고하셨습니다!"
```

---

## 📊 강의 시간 배분 요약

| 섹션 | 내용 | 시간 | 누적 |
|------|------|------|------|
| 도입 | 오리엔테이션 | 15분 | 0:15 |
| 섹션 1 | SDLC 방법론 | 75분 | 1:30 |
| 휴식 | 휴식 | 15분 | 1:45 |
| 섹션 2 | CI/CD 파이프라인 | 75분 | 3:00 |
| 휴식 | 휴식 | 15분 | 3:15 |
| 섹션 3 | 소프트웨어 테스팅 | 75분 | 4:30 |
| 휴식 | 휴식 | 15분 | 4:45 |
| 섹션 4 | Git 기초 | 60분 | 5:45 |
| 섹션 5 | 코드 리뷰 및 품질 | 30분 | 6:15 |
| 마무리 | 복습 및 평가 | 15분 | 6:30 |

**실제 운영 시**: 질문/실습 조정으로 6.0시간

---

## 💡 강의 운영 팁

### 효과적인 기술 교육을 위한 조언

1. **비전공자 눈높이**
   - 전문 용어 쉽게 풀어 설명
   - 비유와 실생활 예시 활용
   - 코딩보다는 개념 이해 중심

2. **PM 관점 강조**
   - "PM이 왜 알아야 하는가"
   - 프로젝트 관리 맥락에서 설명
   - 의사결정에 필요한 지식

3. **실습 균형**
   - 너무 깊이 들어가지 않음
   - 기본 개념 체험 정도
   - 도구 사용법보다 원리

4. **실무 연결**
   - 모든 개념을 실무 사례와 연결
   - 문제 상황 시나리오
   - 의사결정 포인트 강조

### 주의 사항

- ⚠️ 코딩 교육이 아님 (개념 이해)
- ⚠️ 개발자 vs PM의 관점 차이
- ⚠️ 기술 변화 빠름 (원리 중심)
- ⚠️ 실습 환경 사전 점검

---

## 📚 참고 자료

- [Week 13 README](./week13-software-engineering_README.md)
- [Week 13 상세 강의 자료](./week13-software-engineering_detailed-lecture-materials.md)
- PMBOK Guide - Quality Management
- "Continuous Delivery" by Jez Humble
- "The DevOps Handbook"
- Git Documentation
- GitHub Guides

---

## ✅ 강의 준비 체크리스트

**사전 준비**:
- [ ] 모든 수강생 Git 설치 확인
- [ ] GitHub 계정 생성 확인
- [ ] CI/CD 데모 환경 준비
- [ ] 샘플 코드 리포지토리 준비
- [ ] VS Code 또는 텍스트 에디터

**강의 자료**:
- [ ] SDLC 비교 차트
- [ ] CI/CD 파이프라인 다이어그램
- [ ] 테스트 피라미드 시각 자료
- [ ] Git 워크플로우 다이어그램
- [ ] 코드 리뷰 체크리스트

**실습 준비**:
- [ ] Git 실습 가이드
- [ ] 샘플 프로젝트
- [ ] CI/CD 데모 스크립트
- [ ] 테스트 코드 예시

---

**"코딩을 잘할 필요는 없지만, 개발 프로세스를 이해하는 PM이 성공합니다!"**
