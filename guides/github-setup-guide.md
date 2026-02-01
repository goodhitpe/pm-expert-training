# GitHub 프로젝트 관리 실습 가이드

> **대상**: PM 교육 Week 10 - PM 도구 활용  
> **소요 시간**: 2-3시간  
> **난이도**: 초급

---

## 📚 목차
1. [GitHub란?](#1-github란)
2. [무료 계정 생성](#2-무료-계정-생성)
3. [저장소(Repository) 생성](#3-저장소repository-생성)
4. [GitHub Projects 활용](#4-github-projects-활용)
5. [이슈(Issue) 관리](#5-이슈issue-관리)
6. [Pull Request 워크플로우](#6-pull-request-워크플로우)
7. [팀 협업 설정](#7-팀-협업-설정)
8. [실습 프로젝트](#8-실습-프로젝트)

---

## 1. GitHub란?

### 1.1 개요
**GitHub**는 Git 버전 관리 시스템을 기반으로 한 소프트웨어 개발 협업 플랫폼입니다.

### 1.2 주요 기능
- ✅ **버전 관리**: 코드 변경 이력 추적
- ✅ **이슈 추적**: 작업, 버그, 기능 요청 관리
- ✅ **Pull Request**: 코드 리뷰 및 병합
- ✅ **GitHub Projects**: 칸반 보드 방식 프로젝트 관리
- ✅ **GitHub Actions**: CI/CD 자동화
- ✅ **협업**: 팀 권한 관리, 코멘트, 리뷰

### 1.3 GitHub vs Git
| 구분 | Git | GitHub |
|-----|-----|--------|
| 정의 | 버전 관리 시스템 (도구) | Git 호스팅 서비스 (플랫폼) |
| 설치 | 로컬 컴퓨터에 설치 필요 | 웹 브라우저로 접근 |
| 협업 | 로컬에서만 작동 | 클라우드 기반 협업 |
| 추가 기능 | 없음 | 이슈, PR, Projects, Actions 등 |

### 1.4 사용 사례
- 소프트웨어 개발 프로젝트
- 오픈소스 프로젝트 관리
- 문서 및 콘텐츠 버전 관리
- DevOps 및 CI/CD 파이프라인
- 포트폴리오 관리 (GitHub Pages)

---

## 2. 무료 계정 생성

### 2.1 GitHub Free 플랜 특징
- **사용자**: 무제한
- **Public 저장소**: 무제한
- **Private 저장소**: 무제한
- **GitHub Actions**: 월 2,000분 무료
- **GitHub Pages**: 무료 호스팅
- **비용**: 완전 무료

### 2.2 회원가입 단계

#### Step 1: GitHub 웹사이트 접속
1. [https://github.com](https://github.com) 접속
2. 우측 상단 **"Sign up"** 버튼 클릭

#### Step 2: 계정 정보 입력
1. **이메일 주소** 입력
2. **비밀번호** 설정 (최소 15자 또는 8자+숫자/특수문자)
3. **사용자 이름** 선택 (URL에 사용됨: `github.com/username`)
4. **이메일 수신 여부** 선택

#### Step 3: 계정 인증
1. **퍼즐 풀기** (스팸 방지)
2. 이메일로 전송된 **인증 코드** 입력

#### Step 4: 환영 설문 (선택)
- 팀 규모
- 학생/교사 여부
- 관심 분야
- **Skip 가능**

#### Step 5: 계정 생성 완료
- GitHub 대시보드로 이동
- 프로필 사진 및 Bio 추가 권장

### 2.3 GitHub CLI 설치 (선택)

#### Windows
```bash
# Winget 사용
winget install --id GitHub.cli

# Chocolatey 사용
choco install gh
```

#### macOS
```bash
brew install gh
```

#### Linux
```bash
# Debian/Ubuntu
sudo apt install gh

# Fedora
sudo dnf install gh
```

#### 인증
```bash
gh auth login
```

---

## 3. 저장소(Repository) 생성

### 3.1 저장소란?
- 프로젝트의 모든 파일과 변경 이력을 저장하는 공간
- **Public**: 누구나 볼 수 있음
- **Private**: 초대된 사람만 접근 가능

### 3.2 새 저장소 생성

#### Step 1: 저장소 생성 시작
1. 우측 상단 **"+"** 아이콘 클릭
2. **"New repository"** 선택

#### Step 2: 저장소 정보 입력

**필수 입력**:
- **Repository name**: 프로젝트 이름 (예: `mobile-app-project`)
  - 소문자, 숫자, 하이픈(-), 언더스코어(_) 사용
  - 공백 사용 불가

**선택 입력**:
- **Description**: 프로젝트 설명 (예: "우리 팀의 모바일 앱 개발 프로젝트")
- **Public/Private**: 공개 여부 선택
- **Initialize this repository with**:
  - ✅ **README file**: 프로젝트 소개 파일 (권장)
  - ✅ **.gitignore**: 제외할 파일 패턴 (권장)
  - ⬜ **License**: 오픈소스 라이선스 (필요 시)

#### Step 3: .gitignore 템플릿 선택 (권장)
프로젝트 유형에 맞는 템플릿 선택:
- **Python**: `__pycache__`, `.pyc` 등 제외
- **Node**: `node_modules`, `.env` 등 제외
- **Java**: `*.class`, `target/` 등 제외
- **None**: 템플릿 없음

#### Step 4: 저장소 생성 완료
- **"Create repository"** 버튼 클릭
- 저장소 메인 페이지로 이동

### 3.3 저장소 구조 이해

```
저장소 (Repository)
├─ Code (코드)
│  ├─ 파일 및 폴더
│  └─ 브랜치 (Branches)
│
├─ Issues (이슈)
│  └─ 작업, 버그, 기능 요청
│
├─ Pull requests (PR)
│  └─ 코드 변경 제안 및 리뷰
│
├─ Actions (자동화)
│  └─ CI/CD 워크플로우
│
├─ Projects (프로젝트 보드)
│  └─ 칸반 방식 작업 관리
│
├─ Wiki (문서)
│  └─ 프로젝트 문서화
│
└─ Settings (설정)
   └─ 권한, 협업자, 보안 등
```

---

## 4. GitHub Projects 활용

### 4.1 GitHub Projects란?
- 이슈와 PR을 시각적으로 관리하는 칸반 보드
- Jira, Trello와 유사한 기능
- 무료 플랜에서도 모든 기능 사용 가능

### 4.2 프로젝트 보드 생성

#### Step 1: Projects 탭 접속
1. 저장소 메뉴에서 **"Projects"** 클릭
2. **"Link a project"** 또는 **"New project"** 선택

#### Step 2: 프로젝트 유형 선택
**템플릿 종류**:
- **Board**: 칸반 보드 (To do, In progress, Done)
- **Table**: 스프레드시트 뷰
- **Roadmap**: 타임라인 뷰 (마일스톤)
- **Blank**: 빈 프로젝트

**초보자는 "Board" 템플릿 권장**

#### Step 3: 프로젝트 이름 및 설명
- **Project name**: 프로젝트 이름 (예: "Sprint 1 - MVP 개발")
- **Description**: 프로젝트 목표 (선택)
- **Visibility**: Public/Private 선택

#### Step 4: 프로젝트 생성 완료
- **"Create project"** 클릭
- 프로젝트 보드로 이동

### 4.3 프로젝트 보드 커스터마이징

#### 컬럼(Column) 추가
1. 우측 **"+ Add column"** 클릭
2. 컬럼 이름 입력 (예: "Review", "Testing", "Deployed")
3. **Enter** 키로 확인

#### 추천 컬럼 구성
```
📋 Backlog (백로그)
  └─ 아직 시작하지 않은 작업

🎯 To Do (할 일)
  └─ 이번 스프린트에 계획된 작업

🚧 In Progress (진행 중)
  └─ 현재 작업 중인 항목

✅ Done (완료)
  └─ 완료된 작업
```

#### 필드(Field) 추가
프로젝트 우측 상단 **"..."** 클릭 → **"Settings"** → **"Custom fields"**

추가 가능한 필드:
- **Priority**: 우선순위 (High/Medium/Low)
- **Status**: 상태 (Not started/In progress/Done)
- **Assignees**: 담당자
- **Labels**: 태그 (bug, feature, documentation 등)
- **Estimate**: 예상 시간
- **Sprint**: 스프린트 번호

### 4.4 자동화(Automation) 설정

#### 자동 이동 규칙 설정
1. 프로젝트 우측 상단 **"..."** → **"Workflows"**
2. 기본 제공 워크플로우:
   - **Auto-add to project**: 이슈/PR 자동 추가
   - **Item closed**: 완료 시 "Done"으로 이동
   - **Pull request merged**: PR 병합 시 "Done"으로 이동

#### 커스텀 워크플로우 예시
```yaml
name: Auto-move to In Progress
on:
  issues:
    types: [assigned]
steps:
  - name: Move to In Progress
    uses: actions/move-to-column@v1
    with:
      column-name: In Progress
```

---

## 5. 이슈(Issue) 관리

### 5.1 이슈란?
- 작업, 버그, 기능 요청 등을 추적하는 단위
- Jira의 "Task", "Bug", "Story"와 유사
- 각 이슈는 고유 번호를 가짐 (예: #1, #2)

### 5.2 이슈 생성

#### Step 1: Issues 탭 접속
1. 저장소 메뉴에서 **"Issues"** 클릭
2. **"New issue"** 버튼 클릭

#### Step 2: 이슈 정보 입력

**제목 (Title)**:
- 명확하고 간결하게 작성
- 동사로 시작 권장
- 예:
  - ✅ "로그인 페이지 UI 구현"
  - ✅ "사용자 등록 버그 수정"
  - ❌ "문제 있음" (불명확)

**설명 (Description)**:
```markdown
## 작업 내용
로그인 페이지의 UI를 Figma 디자인에 맞춰 구현합니다.

## 체크리스트
- [ ] 이메일 입력 필드
- [ ] 비밀번호 입력 필드
- [ ] 로그인 버튼
- [ ] "비밀번호 찾기" 링크

## 참고 자료
- Figma 디자인: [링크]
- API 문서: [링크]
```

**우측 사이드바 설정**:
- **Assignees**: 담당자 지정
- **Labels**: 태그 추가
  - `bug`: 버그
  - `enhancement`: 기능 개선
  - `documentation`: 문서 작업
  - `good first issue`: 초보자 환영
- **Projects**: 프로젝트 보드에 추가
- **Milestone**: 마일스톤 지정 (v1.0, Sprint 1 등)

#### Step 3: 이슈 생성 완료
- **"Submit new issue"** 클릭
- 이슈 번호 부여 (예: #15)

### 5.3 이슈 템플릿 설정

#### 템플릿 생성
1. 저장소 **"Settings"** → **"Issues"**
2. **"Set up templates"** 클릭
3. 템플릿 선택:
   - **Bug report**: 버그 보고
   - **Feature request**: 기능 요청
   - **Custom template**: 커스텀 템플릿

#### 버그 보고 템플릿 예시
```markdown
---
name: Bug report
about: 버그를 발견하셨나요? 알려주세요!
title: '[BUG] '
labels: bug
assignees: ''
---

## 버그 설명
버그에 대한 명확하고 간결한 설명을 작성해주세요.

## 재현 방법
1. '...' 페이지로 이동
2. '....' 버튼 클릭
3. '....' 입력
4. 에러 발생

## 예상 동작
정상적으로 작동했을 때 기대되는 동작을 설명해주세요.

## 실제 동작
실제로 발생한 동작을 설명해주세요.

## 스크린샷
가능하다면 스크린샷을 첨부해주세요.

## 환경
- OS: [예: Windows 11]
- 브라우저: [예: Chrome 120]
- 앱 버전: [예: v1.2.3]

## 추가 정보
다른 관련 정보가 있다면 작성해주세요.
```

### 5.4 이슈 관리 팁

#### 이슈 번호로 커밋 연결
```bash
git commit -m "로그인 UI 구현 (#15)"
```
- `#15`를 언급하면 자동으로 이슈와 연결됨

#### 커밋으로 이슈 자동 닫기
```bash
git commit -m "버그 수정, closes #23"
```
- `closes`, `fixes`, `resolves` 키워드 사용
- PR이 병합되면 이슈가 자동으로 닫힘

#### 이슈 간 참조
```markdown
이 이슈는 #15와 관련이 있습니다.
#20을 먼저 완료해야 합니다.
```

---

## 6. Pull Request 워크플로우

### 6.1 Pull Request(PR)란?
- 코드 변경을 제안하고 리뷰받는 프로세스
- 브랜치의 변경 사항을 메인 브랜치에 병합하기 전 검토
- 코드 리뷰, 토론, 승인 과정 포함

### 6.2 브랜치 전략

#### Git Flow (대규모 프로젝트)
```
main (프로덕션)
  ↑
develop (개발)
  ↑
feature/login (기능 개발)
```

#### GitHub Flow (간단한 프로젝트, 권장)
```
main (메인 브랜치)
  ↑
feature/login (기능 브랜치)
```

### 6.3 브랜치 생성 및 작업

#### 브랜치 생성
```bash
# 새 브랜치 생성 및 전환
git checkout -b feature/login-ui

# 또는
git switch -c feature/login-ui
```

#### 브랜치 명명 규칙
- `feature/기능명`: 새 기능 (예: `feature/user-auth`)
- `bugfix/버그명`: 버그 수정 (예: `bugfix/login-error`)
- `hotfix/긴급수정`: 긴급 수정 (예: `hotfix/security-patch`)
- `docs/문서명`: 문서 작업 (예: `docs/update-readme`)

#### 작업 및 커밋
```bash
# 변경 사항 확인
git status

# 파일 스테이징
git add src/login.js

# 커밋
git commit -m "로그인 UI 컴포넌트 추가 (#15)"

# 원격 저장소에 푸시
git push origin feature/login-ui
```

### 6.4 Pull Request 생성

#### Step 1: PR 페이지 접속
1. GitHub 저장소 페이지로 이동
2. **"Pull requests"** 탭 클릭
3. **"New pull request"** 버튼 클릭

또는:
- `git push` 후 터미널에 표시되는 PR 링크 클릭
- GitHub에서 자동으로 표시되는 **"Compare & pull request"** 버튼 클릭

#### Step 2: 브랜치 선택
- **base**: 병합될 대상 브랜치 (보통 `main` 또는 `develop`)
- **compare**: 병합하려는 브랜치 (예: `feature/login-ui`)

#### Step 3: PR 정보 입력

**제목 (Title)**:
```
로그인 UI 컴포넌트 구현
```

**설명 (Description)**:
```markdown
## 변경 사항
- 로그인 페이지 UI 컴포넌트 추가
- 이메일 및 비밀번호 입력 폼 구현
- 로그인 버튼 클릭 이벤트 핸들러 추가

## 관련 이슈
Closes #15

## 테스트
- [x] 수동 테스트 완료
- [x] 단위 테스트 추가
- [ ] E2E 테스트 (진행 중)

## 스크린샷
![로그인 페이지](./screenshots/login.png)

## 체크리스트
- [x] 코드 리뷰 준비 완료
- [x] 테스트 통과
- [x] 문서 업데이트
- [x] 커밋 메시지 규칙 준수
```

**우측 사이드바 설정**:
- **Reviewers**: 코드 리뷰어 지정
- **Assignees**: PR 담당자
- **Labels**: 태그 추가
- **Projects**: 프로젝트 보드에 추가
- **Milestone**: 마일스톤 지정

#### Step 4: PR 생성 완료
- **"Create pull request"** 클릭
- PR 번호 부여 (예: #16)

### 6.5 코드 리뷰

#### 리뷰 요청
1. PR 페이지에서 **"Reviewers"** 추가
2. 팀원에게 자동 알림 전송

#### 리뷰 진행
**리뷰어 역할**:
1. **"Files changed"** 탭에서 변경 사항 확인
2. 코드 라인에 **코멘트** 추가:
   - 코드 라인 클릭 → **"+"** 아이콘 → 코멘트 작성
3. 리뷰 제출:
   - **Comment**: 일반 의견
   - **Approve**: 승인
   - **Request changes**: 수정 요청

**리뷰 체크리스트**:
- [ ] 코드가 요구사항을 충족하는가?
- [ ] 코드 품질이 좋은가? (가독성, 유지보수성)
- [ ] 테스트가 충분한가?
- [ ] 문서가 업데이트되었는가?
- [ ] 보안 문제는 없는가?
- [ ] 성능 문제는 없는가?

#### 피드백 반영
```bash
# 피드백에 따라 수정
git add modified_file.js
git commit -m "리뷰 피드백 반영: 변수명 개선"
git push origin feature/login-ui
```
- PR이 자동으로 업데이트됨

### 6.6 PR 병합

#### 병합 방법 선택

**1. Merge commit** (기본)
```
main: A - B - C - M (merge commit)
              ↗
feature:      D - E
```
- 모든 커밋 이력 보존
- 병합 커밋 생성

**2. Squash and merge** (권장)
```
main: A - B - C - D' (squashed commit)
```
- 여러 커밋을 하나로 합침
- 깔끔한 히스토리

**3. Rebase and merge**
```
main: A - B - C - D - E
```
- 선형 히스토리 유지
- 커밋 재작성

#### 병합 실행
1. 리뷰 승인 확인
2. CI/CD 테스트 통과 확인
3. **"Merge pull request"** 버튼 클릭
4. 병합 커밋 메시지 확인
5. **"Confirm merge"** 클릭

#### 병합 후 정리
```bash
# 로컬 브랜치 삭제
git branch -d feature/login-ui

# 원격 브랜치 삭제 (GitHub에서 자동 제안)
git push origin --delete feature/login-ui
```

---

## 7. 팀 협업 설정

### 7.1 협업자(Collaborator) 추가

#### Step 1: Settings 접속
1. 저장소 **"Settings"** 클릭
2. 좌측 메뉴 **"Collaborators"** 클릭

#### Step 2: 협업자 초대
1. **"Add people"** 버튼 클릭
2. GitHub 사용자 이름 또는 이메일 입력
3. **"Add [username] to this repository"** 클릭

#### Step 3: 초대 수락
- 초대받은 사람이 이메일 확인
- 초대 수락
- 저장소 접근 권한 획득

### 7.2 팀(Team) 생성 (조직 계정)

#### 조직 계정의 장점
- 여러 저장소를 하나의 조직으로 관리
- 팀 단위 권한 관리
- 고급 보안 기능

#### 팀 생성
1. 조직 페이지 → **"Teams"** 탭
2. **"New team"** 클릭
3. 팀 이름 및 설명 입력
4. 팀원 추가

### 7.3 브랜치 보호 규칙

#### 브랜치 보호 설정
1. 저장소 **"Settings"** → **"Branches"**
2. **"Add branch protection rule"** 클릭

#### 권장 규칙
- ✅ **Require a pull request before merging**
  - `main` 브랜치에 직접 푸시 방지
- ✅ **Require approvals**
  - 최소 1명 이상의 승인 필요
- ✅ **Require status checks to pass**
  - CI/CD 테스트 통과 필수
- ✅ **Require conversation resolution**
  - 모든 코멘트 해결 필수
- ⬜ **Require signed commits** (선택)
  - 커밋 서명 필수

### 7.4 알림(Notification) 설정

#### 알림 종류
- **Watch**: 모든 활동 알림
- **Participating**: 참여한 이슈/PR만 알림
- **Ignore**: 알림 없음

#### 알림 설정 변경
1. 저장소 우측 상단 **"Watch"** 또는 **"Unwatch"** 클릭
2. 원하는 알림 수준 선택

#### 이메일 알림 관리
1. GitHub 프로필 → **"Settings"** → **"Notifications"**
2. 이메일 알림 설정 조정

---

## 8. 실습 프로젝트

### 8.1 프로젝트 시나리오

**프로젝트**: "할 일 관리 앱 (Todo App) 개발"

**팀 구성**:
- PM 1명 (본인)
- 개발자 2-3명 (팀원 또는 가상)

**기간**: 2주

**목표**:
- GitHub를 사용한 프로젝트 관리 경험
- 이슈, PR, 프로젝트 보드 활용

### 8.2 실습 단계

#### Week 1: 프로젝트 설정 및 계획

**Day 1-2: 초기 설정**
1. [ ] GitHub 계정 생성
2. [ ] 새 저장소 생성 (`todo-app-project`)
3. [ ] README.md 작성 (프로젝트 소개)
4. [ ] 협업자 초대 (팀원)
5. [ ] GitHub Projects 보드 생성

**Day 3-4: 요구사항 정리**
6. [ ] 기능 목록 작성 (이슈로 생성)
   - 예: "할 일 추가 기능", "할 일 삭제 기능", "완료 표시 기능"
7. [ ] 각 이슈에 라벨 추가 (`feature`, `bug`, `documentation`)
8. [ ] 우선순위 설정 (Priority 필드)
9. [ ] 프로젝트 보드에 이슈 추가

**Day 5: 마일스톤 설정**
10. [ ] 마일스톤 생성 (예: "v1.0 - MVP")
11. [ ] 각 이슈를 마일스톤에 할당
12. [ ] 일정 계획 (Due date 설정)

#### Week 2: 개발 및 협업

**Day 1-3: 개발 시작**
13. [ ] 브랜치 생성 (예: `feature/add-todo`)
14. [ ] 코드 작성 및 커밋
15. [ ] Pull Request 생성
16. [ ] 코드 리뷰 요청

**Day 4-5: 리뷰 및 병합**
17. [ ] 리뷰 피드백 확인 및 반영
18. [ ] PR 승인 받기
19. [ ] PR 병합
20. [ ] 프로젝트 보드 업데이트 (자동 또는 수동)

**Day 6-7: 마무리**
21. [ ] 모든 이슈 완료 확인
22. [ ] 문서 업데이트 (README, Wiki)
23. [ ] 회고 작성 (Discussion 또는 Issue)
24. [ ] 마일스톤 닫기

### 8.3 실습 체크리스트

#### 저장소 설정
- [ ] 저장소 생성 완료
- [ ] README.md 작성
- [ ] .gitignore 설정
- [ ] 협업자 추가

#### 프로젝트 관리
- [ ] GitHub Projects 보드 생성
- [ ] 컬럼 구성 (To Do, In Progress, Done)
- [ ] 이슈 5개 이상 생성
- [ ] 라벨 및 마일스톤 활용

#### 협업 실습
- [ ] 브랜치 생성 및 관리
- [ ] Pull Request 생성 (최소 2개)
- [ ] 코드 리뷰 진행
- [ ] PR 병합

#### 고급 기능 (선택)
- [ ] 이슈 템플릿 설정
- [ ] 브랜치 보호 규칙 설정
- [ ] GitHub Actions 워크플로우 추가
- [ ] Wiki 문서 작성

---

## 9. 추가 리소스

### 9.1 공식 문서
- [GitHub Docs](https://docs.github.com)
- [GitHub Skills](https://skills.github.com) - 인터랙티브 학습
- [GitHub Blog](https://github.blog)

### 9.2 추천 학습 자료
- **무료 강의**:
  - [GitHub Learning Lab](https://lab.github.com)
  - [freeCodeCamp - Git and GitHub for Beginners](https://www.youtube.com/watch?v=RGOj5yH7evk)
  
- **문서 및 가이드**:
  - [Pro Git Book](https://git-scm.com/book/ko/v2) (한글)
  - [GitHub Guides](https://guides.github.com)

- **치트 시트**:
  - [Git Cheat Sheet](https://education.github.com/git-cheat-sheet-education.pdf)

### 9.3 유용한 GitHub 기능

#### GitHub Pages
- 무료 정적 웹사이트 호스팅
- `username.github.io` 도메인
- Jekyll 지원

#### GitHub Gist
- 코드 스니펫 공유
- 버전 관리 포함
- 공개/비공개 선택 가능

#### GitHub Actions
- CI/CD 자동화
- 무료 플랜: 월 2,000분
- 다양한 템플릿 제공

#### GitHub Copilot
- AI 기반 코드 자동 완성
- 학생/교사 무료
- VS Code 확장

---

## 10. 자주 묻는 질문 (FAQ)

### Q1: Git과 GitHub의 차이는 무엇인가요?
**A**: Git은 로컬 컴퓨터에 설치하는 버전 관리 도구이고, GitHub는 Git 저장소를 클라우드에서 호스팅하고 협업 기능을 제공하는 플랫폼입니다.

### Q2: Private 저장소도 무료인가요?
**A**: 네, GitHub Free 플랜에서도 무제한 Private 저장소를 생성할 수 있습니다.

### Q3: Jira 대신 GitHub를 사용할 수 있나요?
**A**: 작은 팀이나 소프트웨어 개발 프로젝트에는 충분합니다. 하지만 복잡한 워크플로우나 고급 보고서가 필요하다면 Jira가 더 적합할 수 있습니다.

### Q4: 브랜치를 언제 삭제해야 하나요?
**A**: PR이 병합된 후에는 기능 브랜치를 삭제하는 것이 좋습니다. GitHub는 병합 후 자동으로 브랜치 삭제를 제안합니다.

### Q5: 실수로 잘못된 커밋을 푸시했어요. 어떻게 되돌리나요?
**A**: `git revert` 명령을 사용하세요:
```bash
git revert <commit-hash>
git push origin main
```
또는 `git reset`을 사용하되, 주의가 필요합니다.

### Q6: 코드 리뷰에서 무엇을 확인해야 하나요?
**A**: 
- 코드가 요구사항을 충족하는지
- 버그나 보안 문제가 없는지
- 가독성과 유지보수성
- 테스트 커버리지
- 문서화

### Q7: GitHub Actions는 무엇인가요?
**A**: CI/CD 자동화 도구로, 코드 푸시 시 자동으로 테스트, 빌드, 배포 등을 실행할 수 있습니다.

### Q8: 이슈와 PR의 차이는 무엇인가요?
**A**: 
- **이슈**: 작업, 버그, 논의 등을 추적하는 항목
- **PR**: 코드 변경을 제안하고 리뷰하는 프로세스

---

## 11. 트러블슈팅

### 문제: 푸시가 거부됩니다 (rejected)

**증상**:
```
! [rejected] main -> main (fetch first)
```

**원인**: 원격 저장소에 로컬에 없는 변경사항이 있음

**해결**:
```bash
# 원격 변경사항 가져오기
git pull origin main

# 충돌 해결 (있다면)
# 파일 편집 후:
git add .
git commit -m "충돌 해결"

# 다시 푸시
git push origin main
```

### 문제: 머지 충돌(Merge Conflict)

**증상**:
```
CONFLICT (content): Merge conflict in file.js
```

**해결**:
1. 충돌 파일 열기
2. 충돌 마커 확인:
```
<<<<<<< HEAD
현재 브랜치 코드
=======
병합하려는 브랜치 코드
>>>>>>> feature/branch
```
3. 올바른 코드로 수정
4. 충돌 마커 제거
5. 스테이징 및 커밋:
```bash
git add file.js
git commit -m "충돌 해결"
```

### 문제: 커밋 메시지를 잘못 작성했습니다

**해결** (아직 푸시하지 않은 경우):
```bash
# 마지막 커밋 메시지 수정
git commit --amend -m "올바른 메시지"
```

### 문제: 협업자가 저장소에 접근할 수 없습니다

**확인 사항**:
1. 협업자 초대를 수락했는지 확인
2. 저장소가 Private인 경우 초대했는지 확인
3. Settings → Collaborators에서 권한 확인

---

## 12. 다음 단계

### 추가 학습 주제
1. **GitHub Actions 마스터하기**
   - CI/CD 파이프라인 구축
   - 자동 테스트 및 배포
   
2. **고급 Git 기법**
   - Rebase 활용
   - Cherry-pick
   - Git hooks
   
3. **오픈소스 기여하기**
   - 오픈소스 프로젝트 찾기
   - 첫 PR 제출하기
   - 커뮤니티 참여

4. **GitHub 고급 기능**
   - GitHub Packages
   - GitHub Discussions
   - GitHub Sponsors

### 실전 프로젝트 아이디어
- 개인 포트폴리오 웹사이트 (GitHub Pages)
- 팀 프로젝트 관리
- 오픈소스 프로젝트 시작
- 개인 블로그 운영

---

## 13. 과제

### 필수 과제
1. **GitHub 계정 생성 및 프로필 설정**
   - 프로필 사진 추가
   - Bio 작성
   - 저장소 1개 이상 생성

2. **프로젝트 보드 실습**
   - GitHub Projects 보드 생성
   - 이슈 5개 이상 생성
   - 프로젝트 보드에서 이슈 이동

3. **Pull Request 실습**
   - 브랜치 생성
   - 코드 변경 및 커밋
   - PR 생성 및 병합

### 선택 과제
4. **이슈 템플릿 설정**
5. **브랜치 보호 규칙 설정**
6. **GitHub Actions 워크플로우 추가**

### 제출 방법
- 생성한 저장소 URL 제출
- 프로젝트 보드 스크린샷 제출
- 완료한 PR 링크 제출

---

## 📝 요약

### GitHub 핵심 개념
- **Repository**: 프로젝트 저장소
- **Issue**: 작업 추적
- **Pull Request**: 코드 리뷰 및 병합
- **Projects**: 프로젝트 관리 보드
- **Actions**: CI/CD 자동화

### 기본 워크플로우
1. 저장소 생성
2. 이슈 생성 (작업 정의)
3. 브랜치 생성 및 작업
4. PR 생성 및 리뷰
5. 병합 및 배포
6. 프로젝트 보드 업데이트

### PM이 알아야 할 것
- ✅ 이슈 관리 및 우선순위 설정
- ✅ 프로젝트 보드로 진행 상황 추적
- ✅ PR 리뷰 및 승인 프로세스
- ✅ 브랜치 전략 이해
- ✅ 팀 협업 설정 및 권한 관리

---

**문서 버전**: 1.0  
**작성일**: 2026년 2월 1일  
**다음 업데이트**: 피드백 반영 후

---

> **💡 Tip**: GitHub는 단순한 코드 호스팅을 넘어 강력한 프로젝트 관리 도구입니다. Issues, Projects, PR을 적극 활용하면 Jira 없이도 효과적인 프로젝트 관리가 가능합니다!
