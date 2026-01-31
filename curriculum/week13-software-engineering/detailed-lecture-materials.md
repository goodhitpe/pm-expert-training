# Week 13: 소프트웨어 공학 상세 강의 자료

## 📚 학습 목표 (상세)
1. **소프트웨어 개발 생명주기(SDLC)** 이해
2. **Git 버전 관리** 기본 명령어 및 브랜치 전략 습득
3. **Pull Request 및 코드 리뷰** 프로세스 이해
4. **CI/CD 파이프라인** 개념 및 GitHub Actions 실습
5. **PM 관점의 기술 커뮤니케이션** 능력 향상
6. **개발 용어 및 프로세스** 이해로 개발팀과 원활한 협업

---

## 📖 Part 1: 소프트웨어 개발 기초

### 1.1 비전공자를 위한 프로그래밍 개념

#### 프로그래밍이란?
- **정의**: 컴퓨터에게 명령을 내리는 언어로 작성하는 것
- **프로그램**: 명령어들의 집합
- **코드**: 프로그래밍 언어로 작성된 텍스트

#### 프로그래밍 언어의 종류

| 언어 | 특징 | 주요 용도 |
|-----|------|----------|
| **Python** | 쉬운 문법, 다양한 라이브러리 | 데이터 분석, AI, 웹 백엔드 |
| **JavaScript** | 웹 브라우저에서 실행 | 웹 프론트엔드, 백엔드(Node.js) |
| **Java** | 안정적, 대규모 시스템 | 엔터프라이즈, Android 앱 |
| **C/C++** | 빠른 성능 | 시스템 프로그래밍, 게임 |
| **Swift** | Apple 생태계 | iOS/macOS 앱 |
| **Kotlin** | 현대적 Java 대안 | Android 앱 |

#### 소프트웨어의 구성

```
소프트웨어
├─ 프론트엔드 (Frontend)
│  └─ 사용자가 보는 화면 (UI/UX)
│
├─ 백엔드 (Backend)
│  └─ 비즈니스 로직, 데이터 처리
│
└─ 데이터베이스 (Database)
   └─ 데이터 저장 및 관리
```

#### PM이 알아야 할 기본 용어

**개발 관련 용어**:
```
소스 코드 (Source Code): 프로그래밍 언어로 작성된 코드
컴파일 (Compile): 코드를 컴퓨터가 이해할 수 있는 형태로 변환
빌드 (Build): 소스 코드를 실행 가능한 프로그램으로 만드는 과정
배포 (Deploy): 프로그램을 서버에 올려 사용자가 접근할 수 있게 함
버그 (Bug): 프로그램의 오류
디버깅 (Debugging): 버그를 찾아 수정하는 과정
```

**아키텍처 용어**:
```
API (Application Programming Interface): 프로그램 간 통신 규약
프레임워크 (Framework): 개발을 쉽게 하는 도구 모음
라이브러리 (Library): 재사용 가능한 코드 묶음
의존성 (Dependency): 프로그램이 동작하기 위해 필요한 다른 코드
```

### 1.2 소프트웨어 개발 생명주기 (SDLC)

#### SDLC 단계

```
1. 계획 (Planning)
   ↓
2. 요구사항 분석 (Requirements Analysis)
   ↓
3. 설계 (Design)
   ↓
4. 구현 (Implementation)
   ↓
5. 테스트 (Testing)
   ↓
6. 배포 (Deployment)
   ↓
7. 유지보수 (Maintenance)
```

#### 1. 계획 (Planning)
**목적**: 프로젝트 범위, 일정, 예산 결정

**주요 활동**:
- 프로젝트 목표 설정
- 타당성 검토
- 자원 계획
- 리스크 식별

**PM 역할**:
- 프로젝트 헌장 작성
- 이해관계자 관리
- 예산 및 일정 수립

#### 2. 요구사항 분석 (Requirements Analysis)
**목적**: 무엇을 만들 것인지 명확히 정의

**요구사항 유형**:
```
기능 요구사항 (Functional Requirements):
- 시스템이 해야 하는 기능
- 예: "사용자는 로그인할 수 있어야 한다"

비기능 요구사항 (Non-Functional Requirements):
- 성능, 보안, 사용성 등
- 예: "응답 시간은 2초 이내여야 한다"
```

**산출물**:
- 요구사항 명세서 (Requirements Specification)
- 사용자 스토리 (User Stories)
- 유스케이스 (Use Cases)

#### 3. 설계 (Design)
**목적**: 어떻게 만들 것인지 설계

**설계 수준**:
```
상위 설계 (High-Level Design):
- 시스템 아키텍처
- 주요 컴포넌트 구조
- 기술 스택 선정

상세 설계 (Low-Level Design):
- 데이터베이스 스키마
- API 명세
- 클래스 다이어그램
```

**PM이 검토할 사항**:
- 아키텍처가 요구사항을 충족하는가?
- 확장성 및 유지보수성은?
- 기술적 리스크는?

#### 4. 구현 (Implementation)
**목적**: 실제 코드 작성

**개발 프로세스**:
```
1. 코드 작성
2. 로컬 테스트
3. 코드 리뷰
4. 통합
```

**PM 역할**:
- 진행 상황 추적
- 장애물 제거
- 우선순위 조정

#### 5. 테스트 (Testing)
**목적**: 버그 발견 및 품질 확보

**테스트 단계**:
```
단위 테스트 (Unit Test):
- 개별 함수/모듈 테스트
- 개발자가 작성

통합 테스트 (Integration Test):
- 여러 모듈 간 연동 테스트

시스템 테스트 (System Test):
- 전체 시스템 테스트

인수 테스트 (Acceptance Test):
- 고객/사용자 관점 테스트
```

#### 6. 배포 (Deployment)
**목적**: 프로덕션 환경에 릴리즈

**배포 전략**:
```
빅뱅 배포 (Big Bang):
- 전체를 한 번에 배포
- 리스크 높음

점진적 배포 (Gradual):
- 일부 사용자부터 단계적 배포
- 카나리 배포, 블루-그린 배포
```

#### 7. 유지보수 (Maintenance)
**목적**: 버그 수정 및 개선

**유지보수 유형**:
```
수정 유지보수 (Corrective): 버그 수정
적응 유지보수 (Adaptive): 환경 변화 대응
완전화 유지보수 (Perfective): 기능 개선
예방 유지보수 (Preventive): 미래 문제 방지
```

### 1.3 개발 방법론

#### 워터폴 (Waterfall)
```
특징:
- 순차적 진행
- 단계별 완료 후 다음 단계
- 요구사항 변경 어려움

적합:
- 요구사항 명확
- 변경 가능성 낮음
- 규제가 엄격한 산업
```

#### 애자일 (Agile)
```
특징:
- 반복적 개발
- 빠른 피드백
- 변경 환영

적합:
- 요구사항 불명확
- 빠른 출시 필요
- 사용자 피드백 중요
```

#### DevOps
```
특징:
- 개발(Dev) + 운영(Ops) 통합
- 자동화 강조
- 지속적 배포

핵심:
- CI/CD 파이프라인
- 인프라 코드화 (IaC)
- 모니터링 및 로깅
```

---

## 🔧 Part 2: Git 버전 관리

### 2.1 Git이란?

#### Git의 필요성
**문제 상황**:
```
final.docx
final_수정.docx
final_수정2.docx
final_최종.docx
final_진짜최종.docx
final_진짜진짜최종.docx ← 혼란!
```

**Git 사용 시**:
```
main 브랜치
├─ commit 1: 초안 작성
├─ commit 2: 2장 추가
├─ commit 3: 오타 수정
└─ commit 4: 최종 검토 ← 깔끔!
```

#### Git 핵심 개념

**저장소 (Repository)**:
- 프로젝트 파일과 변경 이력을 저장하는 공간
- 로컬 저장소: 내 컴퓨터
- 원격 저장소: GitHub, GitLab 등

**커밋 (Commit)**:
- 특정 시점의 스냅샷
- 변경 내용 + 메시지

**브랜치 (Branch)**:
- 독립적인 작업 공간
- 메인 코드를 건드리지 않고 실험 가능

### 2.2 Git 기본 명령어

#### 저장소 초기화 및 클론
```bash
# 새 Git 저장소 생성
git init

# 원격 저장소 복제
git clone https://github.com/user/repo.git
```

#### 변경 사항 추적
```bash
# 현재 상태 확인
git status

# 변경 파일 확인
git diff

# 특정 파일 스테이징
git add 파일명

# 모든 파일 스테이징
git add .

# 커밋 생성
git commit -m "커밋 메시지"
```

#### 실습 예제: 첫 커밋 만들기

```bash
# 1. 새 폴더 생성 및 이동
mkdir my-project
cd my-project

# 2. Git 저장소 초기화
git init

# 3. 파일 생성
echo "# My Project" > README.md

# 4. 파일 스테이징
git add README.md

# 5. 커밋
git commit -m "Initial commit: Add README"

# 6. 로그 확인
git log
```

#### 브랜치 관리
```bash
# 브랜치 목록 확인
git branch

# 새 브랜치 생성
git branch feature-login

# 브랜치 전환
git checkout feature-login
# 또는 (Git 2.23+)
git switch feature-login

# 브랜치 생성 + 전환 (한 번에)
git checkout -b feature-login
# 또는
git switch -c feature-login

# 브랜치 삭제
git branch -d feature-login
```

#### 원격 저장소 작업
```bash
# 원격 저장소 추가
git remote add origin https://github.com/user/repo.git

# 원격 저장소 확인
git remote -v

# 변경사항 푸시
git push origin main

# 변경사항 가져오기
git pull origin main
```

### 2.3 브랜치 전략

#### Git Flow

```
main (프로덕션)
 │
 ├─ develop (개발)
 │   │
 │   ├─ feature/login (기능)
 │   ├─ feature/payment
 │   └─ feature/...
 │
 ├─ release/v1.0 (릴리즈)
 │
 └─ hotfix/critical-bug (긴급 수정)
```

**브랜치 종류**:
```
main: 프로덕션 코드
develop: 개발 통합 브랜치
feature: 새 기능 개발
release: 릴리즈 준비
hotfix: 긴급 버그 수정
```

**흐름**:
```
1. develop에서 feature 브랜치 생성
2. 기능 개발 완료
3. feature → develop 머지
4. 릴리즈 시 develop → release
5. 테스트 완료 후 release → main
6. 긴급 버그 발생 시 main → hotfix → main/develop
```

#### GitHub Flow (간소화 버전)

```
main (프로덕션)
 │
 ├─ feature/login
 ├─ feature/payment
 └─ bugfix/typo
```

**특징**:
- main 브랜치만 중요
- 모든 작업은 브랜치에서
- Pull Request로 코드 리뷰
- 머지 후 즉시 배포

**흐름**:
```
1. main에서 브랜치 생성
2. 작업 및 커밋
3. Pull Request 생성
4. 코드 리뷰
5. main으로 머지
6. 자동 배포
```

#### 브랜치 명명 규칙

**좋은 예**:
```
feature/user-authentication
feature/add-payment-method
bugfix/login-error
hotfix/critical-security-issue
release/v1.2.0
```

**나쁜 예**:
```
test
temp
my-branch
new-feature ← 무엇인지 불명확
```

### 2.4 커밋 메시지 작성법

#### 좋은 커밋 메시지

**형식**:
```
<타입>: <제목>

<본문>

<꼬리말>
```

**타입**:
```
feat: 새 기능
fix: 버그 수정
docs: 문서 변경
style: 코드 포맷팅 (기능 변경 없음)
refactor: 코드 리팩토링
test: 테스트 추가
chore: 빌드 설정 등
```

**예시**:
```
feat: 사용자 로그인 기능 추가

- 이메일/비밀번호 로그인 구현
- JWT 토큰 발급
- 세션 관리 추가

Closes #123
```

**나쁜 예**:
```
update ← 무엇을 업데이트?
fix bug ← 어떤 버그?
asdf ← 의미 없음
```

---

## 🔀 Part 3: Pull Request와 코드 리뷰

### 3.1 Pull Request (PR)이란?

**정의**: 내 코드를 메인 브랜치에 합치기 전에 검토 요청

**PR 프로세스**:
```
1. 브랜치에서 작업
2. 커밋 및 푸시
3. PR 생성
4. 코드 리뷰
5. 피드백 반영
6. 승인
7. 머지
```

### 3.2 PR 작성 가이드

#### PR 제목
```
좋은 예:
"feat: Add user profile page"
"fix: Resolve login timeout issue"
"refactor: Improve database query performance"

나쁜 예:
"Update"
"Changes"
"Fix"
```

#### PR 설명 템플릿

```markdown
## 🎯 목적
이 PR이 해결하는 문제나 추가하는 기능

## 📝 변경 사항
- 변경된 내용 1
- 변경된 내용 2
- 변경된 내용 3

## 🧪 테스트 방법
1. 단계 1
2. 단계 2
3. 예상 결과

## 📸 스크린샷 (UI 변경 시)
[스크린샷 첨부]

## ✅ 체크리스트
- [ ] 로컬에서 테스트 완료
- [ ] 코드 스타일 준수
- [ ] 문서 업데이트 (필요시)
- [ ] 테스트 추가 (필요시)

## 🔗 관련 이슈
Closes #123
```

### 3.3 코드 리뷰

#### 코드 리뷰의 목적
```
1. 버그 조기 발견
2. 코드 품질 향상
3. 지식 공유
4. 팀 표준 준수
5. 더 나은 설계
```

#### PM 관점의 코드 리뷰 체크리스트

**기능성**:
```
☐ 요구사항을 충족하는가?
☐ 엣지 케이스를 처리하는가?
☐ 에러 처리가 적절한가?
```

**가독성**:
```
☐ 코드가 이해하기 쉬운가?
☐ 변수명이 명확한가?
☐ 주석이 필요한 곳에 있는가?
```

**테스트**:
```
☐ 테스트 케이스가 충분한가?
☐ 테스트가 통과하는가?
☐ 엣지 케이스 테스트가 있는가?
```

**보안**:
```
☐ 입력 검증을 하는가?
☐ 민감한 정보가 노출되지 않는가?
☐ 인증/인가 처리가 적절한가?
```

**성능**:
```
☐ 불필요한 반복이 없는가?
☐ 데이터베이스 쿼리가 최적화되었는가?
☐ 메모리 누수 가능성은 없는가?
```

#### 코드 리뷰 피드백 작성법

**건설적 피드백**:
```
좋은 예:
"이 로직은 for 루프보다 filter()를 사용하면 
더 읽기 쉬울 것 같습니다. 예: 
users.filter(u => u.active)"

나쁜 예:
"이건 이상해요"
"다시 하세요"
"왜 이렇게 했어요?"
```

**칭찬도 중요**:
```
"이 에러 처리 방식이 매우 깔끔하네요! 👍"
"테스트 케이스가 잘 작성되어 있어요"
"성능 개선 좋습니다!"
```

---

## 🚀 Part 4: CI/CD 파이프라인

### 4.1 CI/CD란?

#### CI (Continuous Integration) - 지속적 통합
**정의**: 코드 변경사항을 자동으로 빌드하고 테스트

**흐름**:
```
1. 개발자가 코드 푸시
2. CI 서버가 자동 감지
3. 코드 빌드
4. 테스트 실행
5. 결과 알림
```

**이점**:
- 버그 조기 발견
- 통합 문제 빠른 해결
- 코드 품질 유지

#### CD (Continuous Deployment) - 지속적 배포
**정의**: 테스트를 통과한 코드를 자동으로 프로덕션에 배포

**흐름**:
```
1. CI 통과
2. 스테이징 환경 배포
3. 자동/수동 승인
4. 프로덕션 배포
5. 모니터링
```

**이점**:
- 빠른 릴리즈
- 수동 오류 감소
- 롤백 용이

### 4.2 GitHub Actions 실습

#### GitHub Actions 구조

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
        node-version: '16'
    
    - name: Install dependencies
      run: npm install
    
    - name: Run tests
      run: npm test
    
    - name: Build
      run: npm run build
```

#### 실습 예제 1: 기본 CI

`.github/workflows/ci.yml`:
```yaml
name: CI

on: [push, pull_request]

jobs:
  test:
    runs-on: ubuntu-latest
    
    steps:
    - name: Checkout code
      uses: actions/checkout@v2
    
    - name: Setup Python
      uses: actions/setup-python@v2
      with:
        python-version: '3.9'
    
    - name: Install dependencies
      run: |
        pip install -r requirements.txt
    
    - name: Run tests
      run: |
        pytest tests/
    
    - name: Check code style
      run: |
        flake8 .
```

#### 실습 예제 2: 자동 배포

`.github/workflows/deploy.yml`:
```yaml
name: Deploy

on:
  push:
    branches: [ main ]

jobs:
  deploy:
    runs-on: ubuntu-latest
    
    steps:
    - uses: actions/checkout@v2
    
    - name: Build Docker image
      run: docker build -t myapp .
    
    - name: Login to Docker Hub
      uses: docker/login-action@v1
      with:
        username: ${{ secrets.DOCKER_USERNAME }}
        password: ${{ secrets.DOCKER_PASSWORD }}
    
    - name: Push image
      run: docker push myapp
    
    - name: Deploy to server
      uses: appleboy/ssh-action@master
      with:
        host: ${{ secrets.SERVER_HOST }}
        username: ${{ secrets.SERVER_USER }}
        key: ${{ secrets.SSH_KEY }}
        script: |
          docker pull myapp
          docker stop myapp-container || true
          docker rm myapp-container || true
          docker run -d --name myapp-container -p 80:80 myapp
```

#### GitHub Actions 주요 이벤트

```yaml
# 푸시 시
on: push

# PR 생성 시
on: pull_request

# 특정 브랜치만
on:
  push:
    branches: [ main, develop ]

# 스케줄 (매일 자정)
on:
  schedule:
    - cron: '0 0 * * *'

# 수동 실행
on: workflow_dispatch
```

### 4.3 CI/CD 모범 사례

#### 빠른 피드백
```
목표: 10분 이내 CI 완료

최적화 방법:
- 병렬 실행
- 캐싱 활용
- 필수 테스트만 실행
```

#### 실패 시 빠른 실패
```
원칙: Fail Fast

구현:
- 린트 → 빌드 → 테스트 순서
- 첫 실패 시 중단
```

#### 환경 분리
```
환경 구성:
- development: 개발 환경
- staging: 검증 환경
- production: 프로덕션 환경

배포 순서:
dev → staging → production
```

---

## 💼 5. PM 실무 시나리오

### 시나리오 1: 개발 일정 지연

**상황**:
```
개발자: "API 통합이 생각보다 복잡해서 3일 더 필요합니다."
PM: ???
```

**PM의 대응**:
```
1. 상황 파악
   - 무엇이 복잡한가?
   - 어떤 기술적 이슈인가?
   - 예상하지 못한 의존성이 있는가?

2. 대안 검토
   - 스코프 축소 가능한가?
   - 다른 개발자 투입?
   - 우선순위 재조정?

3. 이해관계자 커뮤니케이션
   - 투명하게 상황 공유
   - 대안 제시
   - 리스크 설명
```

### 시나리오 2: 코드 리뷰 논쟁

**상황**:
```
시니어 개발자: "이 코드는 리팩토링이 필요합니다."
주니어 개발자: "기능은 잘 작동합니다. 왜 바꿔야 하죠?"
PM: ???
```

**PM의 중재**:
```
1. 양측 의견 청취
   - 시니어: 유지보수성, 확장성 우려
   - 주니어: 시간 압박, 기능 완성도 우선

2. 균형잡힌 결정
   - 긴급한 기능: 일단 머지, 리팩토링은 다음 스프린트
   - 여유 있음: 리팩토링 후 머지
   - 기술 부채 로그에 기록

3. 학습 기회 제공
   - 페어 프로그래밍 제안
   - 리팩토링 워크샵 계획
```

### 시나리오 3: CI 실패

**상황**:
```
PR을 머지하려는데 CI가 실패했습니다.
에러 메시지: "Test failed: 3 tests failing"
```

**PM의 역할**:
```
1. 즉시 조치
   - 머지 블로킹
   - 개발자에게 알림

2. 근본 원인 파악
   - 어떤 테스트가 실패했나?
   - 코드 변경과 관련 있는가?
   - 환경 문제인가?

3. 재발 방지
   - 테스트 커버리지 향상
   - 더 엄격한 PR 규칙
   - CI 개선
```

---

## 💼 6. 실습 과제

### 과제 1: Git 실습

**목표**: Git 기본 명령어 숙달

**과제 내용**:
1. GitHub에 새 저장소 생성
2. 로컬에 클론
3. `feature/add-readme` 브랜치 생성
4. README.md 파일 작성 (프로젝트 소개)
5. 커밋 및 푸시
6. Pull Request 생성
7. 셀프 코드 리뷰 후 머지

**제출물**:
- GitHub 저장소 URL
- PR 스크린샷
- 배운 점 정리 (1페이지)

### 과제 2: GitHub Actions 설정

**목표**: CI 파이프라인 구축

**과제 내용**:
1. 간단한 Python/Node.js 프로젝트 생성
2. 테스트 코드 작성 (최소 3개)
3. GitHub Actions 워크플로우 설정
   - 푸시 시 자동 테스트 실행
   - 테스트 통과 시 빌드
4. 의도적으로 테스트 실패시켜 보기
5. 수정 후 통과 확인

**제출물**:
- GitHub 저장소 URL
- Actions 실행 결과 스크린샷
- 설정 과정 문서 (2페이지)

### 과제 3: 코드 리뷰 연습

**목표**: 코드 리뷰 피드백 작성 능력 향상

**시나리오**:
제공된 샘플 코드에 대해 PM 관점의 코드 리뷰 수행

**검토 항목**:
- 기능 요구사항 충족 여부
- 에러 처리
- 보안 고려사항
- 성능 이슈
- 가독성

**제출물**:
- 코드 리뷰 코멘트 (5개 이상)
- 개선 제안 (3개 이상)
- 칭찬 포인트 (2개 이상)

---

## 🎯 7. 자가 점검 퀴즈

### 객관식 문제

**1. SDLC 단계의 올바른 순서는?**
- A) 설계 → 요구사항 → 구현 → 테스트
- B) 요구사항 → 설계 → 구현 → 테스트
- C) 구현 → 테스트 → 요구사항 → 설계
- D) 테스트 → 구현 → 설계 → 요구사항

**정답**: B

---

**2. Git에서 변경사항을 스테이징하는 명령어는?**
- A) git commit
- B) git add
- C) git push
- D) git pull

**정답**: B

---

**3. CI/CD에서 CI가 의미하는 것은?**
- A) Continuous Installation
- B) Continuous Integration
- C) Continuous Improvement
- D) Continuous Information

**정답**: B

---

**4. GitHub Flow에서 새 기능 개발 시 올바른 순서는?**
- A) 브랜치 생성 → 작업 → PR → 리뷰 → 머지
- B) 작업 → 브랜치 생성 → PR → 머지
- C) PR → 브랜치 생성 → 작업 → 머지
- D) 머지 → 작업 → PR → 브랜치 생성

**정답**: A

---

**5. 좋은 커밋 메시지의 특징이 아닌 것은?**
- A) 명확한 제목
- B) 변경 사항 설명
- C) 코드 전체 복사
- D) 관련 이슈 번호

**정답**: C

---

### 서술형 문제

**6. 소프트웨어 개발 생명주기(SDLC)의 7단계를 나열하고, PM이 각 단계에서 수행하는 주요 역할을 설명하시오.**

**모범 답안**:
1. **계획**: 프로젝트 헌장 작성, 범위/일정/예산 수립
2. **요구사항 분석**: 이해관계자와 요구사항 수집, 우선순위 결정
3. **설계**: 아키텍처 검토, 기술 스택 승인
4. **구현**: 진행 상황 추적, 장애물 제거
5. **테스트**: 테스트 계획 검토, 품질 기준 확인
6. **배포**: 릴리즈 계획 수립, 롤백 계획 준비
7. **유지보수**: 버그 우선순위 결정, 개선 사항 계획

---

**7. Git Flow와 GitHub Flow의 차이점을 설명하고, 각각 어떤 상황에 적합한지 서술하시오.**

**모범 답안**:

**Git Flow**:
- 복잡한 브랜치 구조 (main, develop, feature, release, hotfix)
- 명확한 릴리즈 주기
- 적합: 정기 릴리즈가 있는 대규모 프로젝트

**GitHub Flow**:
- 단순한 구조 (main + feature 브랜치)
- 지속적 배포
- 적합: 자주 배포하는 웹 서비스

---

**8. CI/CD 파이프라인을 구축할 때 고려해야 할 3가지 중요한 요소를 설명하시오.**

**모범 답안**:
1. **빠른 피드백**: 10분 이내 빌드 완료로 개발자 생산성 향상
2. **자동화**: 수동 개입 최소화로 오류 감소
3. **환경 분리**: dev/staging/production 환경 구분으로 안정성 확보

---

**9. 코드 리뷰에서 PM이 확인해야 할 주요 체크 포인트 5가지를 나열하시오.**

**모범 답안**:
1. 기능 요구사항 충족 여부
2. 에러 처리 적절성
3. 보안 고려사항 (입력 검증, 인증/인가)
4. 성능 이슈 (불필요한 반복, 쿼리 최적화)
5. 가독성 (변수명, 주석, 코드 구조)

---

**10. 개발팀이 "기술 부채가 너무 많아 신규 기능 개발이 어렵다"고 할 때, PM으로서 어떻게 대응해야 하는지 단계별로 설명하시오.**

**모범 답안**:

**1단계: 현황 파악**
- 기술 부채 목록 작성
- 각 항목의 영향도 평가
- 해결에 필요한 시간 추정

**2단계: 우선순위 결정**
- 비즈니스 영향도 vs 해결 난이도 매트릭스
- 긴급한 것부터 순서 정렬

**3단계: 계획 수립**
- 스프린트마다 20% 시간 할당
- 신규 기능과 균형 유지
- 단계적 개선 로드맵

**4단계: 이해관계자 설득**
- 기술 부채의 비즈니스 영향 설명
- ROI 계산 (리팩토링 투자 vs 미래 이득)
- 장기적 관점 제시

---

## 📚 8. 핵심 용어 정리

### 개발 용어

| 한글 | 영문 | 설명 |
|-----|------|------|
| 소스 코드 | Source Code | 프로그래밍 언어로 작성된 코드 |
| 컴파일 | Compile | 코드를 실행 파일로 변환 |
| 빌드 | Build | 실행 가능한 프로그램 생성 |
| 배포 | Deploy | 서버에 프로그램 설치 |
| 버그 | Bug | 프로그램 오류 |
| 디버깅 | Debugging | 버그 수정 과정 |
| API | Application Programming Interface | 프로그램 간 통신 규약 |
| 프레임워크 | Framework | 개발 도구 모음 |
| 라이브러리 | Library | 재사용 가능한 코드 |

### Git 용어

| 한글 | 영문 | 설명 |
|-----|------|------|
| 저장소 | Repository | 프로젝트 저장 공간 |
| 커밋 | Commit | 변경사항 저장 |
| 브랜치 | Branch | 독립적인 작업 공간 |
| 머지 | Merge | 브랜치 합치기 |
| 푸시 | Push | 원격 저장소에 업로드 |
| 풀 | Pull | 원격 저장소에서 다운로드 |
| 클론 | Clone | 저장소 복제 |
| 포크 | Fork | 다른 사람 저장소 복사 |

### CI/CD 용어

| 한글 | 영문 | 설명 |
|-----|------|------|
| 지속적 통합 | Continuous Integration | 자동 빌드/테스트 |
| 지속적 배포 | Continuous Deployment | 자동 배포 |
| 파이프라인 | Pipeline | 자동화 워크플로우 |
| 워크플로우 | Workflow | 작업 흐름 정의 |

---

## 🎓 다음 주 예고

**Week 14: 데이터베이스 기초**

다음 주에는 다음 내용을 학습합니다:
- SQL 기초 및 실습
- 데이터베이스 설계 (ER 다이어그램)
- NoSQL vs RDBMS
- PM 관점의 데이터 모델링

**사전 준비**:
- SQLite 온라인 도구 확인
- 관계형 데이터베이스 개념 예습

---

## 📖 추천 학습 자료

### Git
- **공식 문서**: https://git-scm.com/doc
- **온라인 실습**: https://learngitbranching.js.org/
- **무료 책**: Pro Git (https://git-scm.com/book/ko/v2)

### GitHub Actions
- **공식 문서**: https://docs.github.com/en/actions
- **예제 모음**: https://github.com/sdras/awesome-actions

### 개발 기초
- **코드카데미**: https://www.codecademy.com/
- **freeCodeCamp**: https://www.freecodecamp.org/

---

**강의 자료 버전**: 1.0  
**최종 업데이트**: 2026년 1월  
**작성자**: PM Expert Training Team
