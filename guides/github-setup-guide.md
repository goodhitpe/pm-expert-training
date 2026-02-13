# 🚀 GitHub 실습 가이드

> **학습 시간**: 60-90분  
> **난이도**: 초급  
> **목적**: PM이 개발자와 효과적으로 협업하기 위한 GitHub 기초 실습

---

## 📚 목차

1. [GitHub란 무엇인가?](#1-github란-무엇인가)
2. [GitHub 계정 생성](#2-github-계정-생성)
3. [Git 설치하기](#3-git-설치하기)
4. [첫 Repository 만들기](#4-첫-repository-만들기)
5. [Git 기본 명령어](#5-git-기본-명령어)
6. [브랜치 전략](#6-브랜치-전략)
7. [Pull Request 만들기](#7-pull-request-만들기)
8. [Code Review 기초](#8-code-review-기초)
9. [GitHub Issues 활용](#9-github-issues-활용)
10. [PM을 위한 GitHub 활용 팁](#10-pm을-위한-github-활용-팁)

---

## 1. GitHub란 무엇인가?

### 1.1 Git vs GitHub

**Git**:
- 버전 관리 시스템 (Version Control System)
- 로컬 컴퓨터에서 작동
- 코드 변경 이력 추적
- 리누스 토발즈가 개발 (2005)

**GitHub**:
- Git 저장소 호스팅 서비스
- 웹 기반 협업 플랫폼
- 이슈 트래킹, PR, 위키 등 제공
- Microsoft 소유 (2018 인수)

### 1.2 PM이 GitHub를 알아야 하는 이유

1. **개발자와 소통**: 개발 진행 상황 파악
2. **프로젝트 투명성**: 실시간 코드 변경 추적
3. **이슈 관리**: 버그, 기능 요청 추적
4. **문서화**: README, 위키로 프로젝트 문서 관리
5. **협업 효율**: Pull Request를 통한 리뷰 프로세스

### 1.3 PM이 GitHub에서 하는 일

- ✅ 이슈(Issue) 생성 및 관리
- ✅ 프로젝트 보드로 작업 추적
- ✅ Pull Request 확인 및 승인
- ✅ 마일스톤 설정 및 진행률 모니터링
- ✅ README 및 문서 작성
- ❌ 직접 코딩 (필수 아님, 선택)

---

## 2. GitHub 계정 생성

### 2.1 회원가입

1. **GitHub 웹사이트 방문**
   - URL: https://github.com
   - 우측 상단 "Sign up" 클릭

2. **계정 정보 입력**
   ```
   Email: 이메일 주소 입력
   Password: 강력한 비밀번호 (최소 15자 또는 8자+숫자/특수문자)
   Username: 사용자 이름 (고유해야 함)
   ```

3. **이메일 인증**
   - 이메일로 발송된 인증 코드 입력
   - "Verify email address" 클릭

4. **계정 유형 선택**
   - 무료 계정 선택 (Free)
   - 개인 용도로 사용
   - 무제한 공개 저장소
   - 무제한 비공개 저장소 (단, 협업자 제한)

### 2.2 프로필 설정

1. **프로필 사진 업로드**
   - 우측 상단 프로필 아이콘 > Settings
   - Public profile > Picture
   - 프로페셔널한 사진 권장

2. **기본 정보 입력**
   ```
   Name: 실명 또는 닉네임
   Bio: 간단한 자기소개 (예: "Project Manager | Agile Enthusiast")
   Company: 소속 회사 (선택)
   Location: 위치 (예: "Seoul, South Korea")
   ```

3. **이메일 공개 설정**
   - Settings > Emails
   - "Keep my email addresses private" 체크 권장 (스팸 방지)

---

## 3. Git 설치하기

### 3.1 Windows에서 Git 설치

1. **Git 다운로드**
   - URL: https://git-scm.com/download/win
   - "64-bit Git for Windows Setup" 다운로드

2. **설치 진행**
   ```
   Step 1: Next 클릭
   Step 2: 설치 경로 선택 (기본값 권장: C:\Program Files\Git)
   Step 3: 컴포넌트 선택 - 모두 기본값 유지
   Step 4: 시작 메뉴 폴더 - 기본값 유지
   Step 5: 기본 에디터 선택 - "Use Visual Studio Code" 권장
   Step 6: 브랜치 이름 - "Let Git decide" 선택
   Step 7: PATH 환경변수 - "Git from the command line and also from 3rd-party software" 선택
   Step 8: SSH 실행 파일 - "Use bundled OpenSSH" 선택
   Step 9: HTTPS 백엔드 - "Use the OpenSSL library" 선택
   Step 10: 줄바꿈 변환 - "Checkout Windows-style, commit Unix-style" 선택
   Step 11: 터미널 에뮬레이터 - "Use MinTTY" 선택
   Step 12-15: 나머지는 모두 기본값 유지
   ```

3. **설치 확인**
   - Git Bash 실행 (시작 메뉴에서 검색)
   - 다음 명령어 입력:
   ```bash
   git --version
   ```
   - 출력 예시: `git version 2.43.0.windows.1`

### 3.2 Mac에서 Git 설치

**방법 1: Homebrew 사용 (권장)**
```bash
# Homebrew 설치 여부 확인
brew --version

# Homebrew가 없다면 설치
/bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"

# Git 설치
brew install git

# 설치 확인
git --version
```

**방법 2: Xcode Command Line Tools**
```bash
# 터미널에서 실행
xcode-select --install

# 설치 확인
git --version
```

**방법 3: 공식 설치 파일**
- URL: https://git-scm.com/download/mac
- .dmg 파일 다운로드 및 설치

### 3.3 Git 초기 설정

**사용자 정보 설정** (필수):
```bash
# 이름 설정 (커밋에 표시됨)
git config --global user.name "Your Name"

# 이메일 설정 (GitHub 계정 이메일)
git config --global user.email "your.email@example.com"

# 설정 확인
git config --list
```

**에디터 설정** (선택):
```bash
# Visual Studio Code를 기본 에디터로 설정
git config --global core.editor "code --wait"

# Vim을 기본 에디터로 설정
git config --global core.editor vim

# Nano를 기본 에디터로 설정
git config --global core.editor nano
```

**줄바꿈 설정** (선택):
```bash
# Windows
git config --global core.autocrlf true

# Mac/Linux
git config --global core.autocrlf input
```

---

## 4. 첫 Repository 만들기

### 4.1 웹에서 Repository 생성

1. **GitHub 웹사이트 로그인**
   - 우측 상단 "+" 아이콘 클릭
   - "New repository" 선택

2. **Repository 정보 입력**
   ```
   Repository name: my-first-project
   Description: 나의 첫 GitHub 프로젝트 (선택)
   Public/Private: Public 선택
   Initialize this repository with:
     ☑ Add a README file
     ☑ Add .gitignore (선택: Node, Python 등)
     ☐ Choose a license (선택)
   ```

3. **"Create repository" 클릭**

### 4.2 로컬에 Clone하기

**Clone이란?**
- GitHub의 원격 저장소를 로컬 컴퓨터로 복사하는 작업

**Clone 실행**:

1. **Repository URL 복사**
   - GitHub Repository 페이지에서 녹색 "Code" 버튼 클릭
   - HTTPS 탭 선택
   - URL 복사 (예: `https://github.com/username/my-first-project.git`)

2. **터미널/Git Bash에서 Clone**
   ```bash
   # 작업할 디렉토리로 이동
   cd ~/Documents  # Mac/Linux
   cd C:\Users\YourName\Documents  # Windows

   # Clone 실행
   git clone https://github.com/username/my-first-project.git

   # Clone한 디렉토리로 이동
   cd my-first-project

   # 파일 목록 확인
   ls -la  # Mac/Linux
   dir  # Windows
   ```

3. **Clone 성공 확인**
   - README.md 파일이 있는지 확인
   - `.git` 폴더가 있는지 확인 (숨김 폴더)

---

## 5. Git 기본 명령어

### 5.1 Git 워크플로우 이해

```
작업 디렉토리     Staging Area      로컬 저장소        원격 저장소
(Working Dir)     (Index)          (Local Repo)      (Remote Repo)
     |                |                 |                 |
     |   git add      |                 |                 |
     |--------------->|                 |                 |
     |                |   git commit    |                 |
     |                |---------------->|                 |
     |                |                 |   git push      |
     |                |                 |---------------->|
```

### 5.2 파일 추가 및 커밋

**시나리오**: README.md 파일 수정하기

1. **파일 수정**
   ```bash
   # 텍스트 에디터로 README.md 열기
   code README.md  # VS Code
   vim README.md   # Vim
   nano README.md  # Nano
   ```

   내용 추가:
   ```markdown
   # My First Project

   이것은 나의 첫 GitHub 프로젝트입니다.

   ## 목표
   - Git 기본 명령어 학습
   - GitHub 워크플로우 이해
   ```

2. **변경 사항 확인**
   ```bash
   # 상태 확인
   git status

   # 출력 예시:
   # On branch main
   # Changes not staged for commit:
   #   modified:   README.md
   ```

3. **Staging Area에 추가**
   ```bash
   # 특정 파일 추가
   git add README.md

   # 모든 변경 파일 추가
   git add .

   # 상태 재확인
   git status

   # 출력 예시:
   # On branch main
   # Changes to be committed:
   #   modified:   README.md
   ```

4. **커밋 생성**
   ```bash
   # 커밋 메시지와 함께 커밋
   git commit -m "Update README with project goals"

   # 출력 예시:
   # [main abc1234] Update README with project goals
   #  1 file changed, 5 insertions(+)
   ```

5. **원격 저장소에 푸시**
   ```bash
   # origin의 main 브랜치로 푸시
   git push origin main

   # 출력 예시:
   # Enumerating objects: 5, done.
   # To https://github.com/username/my-first-project.git
   #    def5678..abc1234  main -> main
   ```

### 5.3 커밋 메시지 작성 규칙

**좋은 커밋 메시지**:
```bash
# 명령형, 현재 시제 사용
git commit -m "Add user authentication feature"
git commit -m "Fix login button alignment issue"
git commit -m "Update API documentation"

# 의미 있는 제목과 본문 (선택)
git commit -m "Add user authentication

- Implement JWT token generation
- Add password hashing with bcrypt
- Create login/logout endpoints"
```

**피해야 할 커밋 메시지**:
```bash
# ❌ 너무 모호함
git commit -m "Update"
git commit -m "Fix bug"
git commit -m "Changes"

# ❌ 과거형 사용
git commit -m "Added feature"
git commit -m "Fixed bug"
```

**커밋 메시지 컨벤션** (선택):
```bash
# Conventional Commits 형식
feat: Add new feature
fix: Fix a bug
docs: Update documentation
style: Code formatting
refactor: Code refactoring
test: Add tests
chore: Build process or auxiliary tool changes

# 예시
git commit -m "feat: Add user profile page"
git commit -m "fix: Resolve memory leak in image loader"
git commit -m "docs: Update API endpoints in README"
```

### 5.4 주요 Git 명령어 요약

| 명령어 | 설명 | 예시 |
|--------|------|------|
| `git status` | 현재 상태 확인 | `git status` |
| `git add` | Staging Area에 추가 | `git add .` |
| `git commit` | 커밋 생성 | `git commit -m "message"` |
| `git push` | 원격 저장소로 푸시 | `git push origin main` |
| `git pull` | 원격 저장소에서 가져오기 | `git pull origin main` |
| `git log` | 커밋 이력 보기 | `git log --oneline` |
| `git diff` | 변경 사항 비교 | `git diff` |
| `git restore` | 파일 복원 | `git restore README.md` |

---

## 6. 브랜치 전략

### 6.1 브랜치란?

**브랜치**:
- 독립적인 작업 공간
- 메인 코드에 영향 없이 새 기능 개발
- 완료 후 메인 브랜치에 병합

**브랜치 시각화**:
```
main    A---B---E---F---G
             \         /
feature       C---D---/
```

### 6.2 브랜치 생성 및 전환

**브랜치 생성**:
```bash
# 현재 브랜치 확인
git branch

# 새 브랜치 생성
git branch feature/add-login

# 브랜치 목록 확인
git branch
# * main
#   feature/add-login

# 브랜치 전환
git checkout feature/add-login

# 브랜치 생성과 동시에 전환 (권장)
git checkout -b feature/add-logout

# 또는 (Git 2.23 이상)
git switch -c feature/add-profile
```

### 6.3 브랜치 작업 예시

**시나리오**: 로그인 기능 추가

1. **기능 브랜치 생성**
   ```bash
   git checkout -b feature/add-login
   ```

2. **파일 생성 및 수정**
   ```bash
   # 새 파일 생성
   echo "console.log('Login feature');" > login.js

   # 파일 확인
   cat login.js
   ```

3. **변경사항 커밋**
   ```bash
   git add login.js
   git commit -m "Add login functionality"
   ```

4. **원격에 브랜치 푸시**
   ```bash
   git push origin feature/add-login
   ```

5. **main 브랜치로 돌아가기**
   ```bash
   git checkout main
   ```

### 6.4 브랜치 병합 (Merge)

**Fast-forward merge**:
```bash
# main 브랜치로 전환
git checkout main

# feature 브랜치 병합
git merge feature/add-login

# 브랜치 삭제 (선택)
git branch -d feature/add-login
```

**3-way merge** (충돌 발생 가능):
```bash
# main 브랜치로 전환
git checkout main

# feature 브랜치 병합
git merge feature/add-logout

# 충돌이 발생하면
# 1. 충돌 파일 수정 (<<<<<<, ======, >>>>>> 표시 부분)
# 2. git add <파일명>
# 3. git commit (메시지 자동 생성)
```

### 6.5 주요 브랜치 전략

#### Git Flow

```
main (production)
  ↑
release (release candidates)
  ↑
develop (integration)
  ↑
feature/* (new features)
hotfix/* (urgent fixes) → main
```

**사용 예**:
- 대규모 프로젝트
- 정기 릴리스 주기
- 복잡한 배포 프로세스

#### GitHub Flow (권장 - 단순함)

```
main (always deployable)
  ↑
feature/* (short-lived branches)
```

**사용 예**:
- 중소규모 프로젝트
- 지속적 배포 (CD)
- 애자일 팀

**워크플로우**:
1. `main`에서 브랜치 생성
2. 커밋 작성
3. Pull Request 생성
4. 리뷰 및 논의
5. `main`에 병합
6. 즉시 배포

---

## 7. Pull Request 만들기

### 7.1 Pull Request란?

**정의**:
- 변경사항을 메인 브랜치에 병합하기 전 리뷰 요청
- 코드 품질 보장 및 지식 공유
- PM도 PR을 통해 문서 기여 가능

**PR 워크플로우**:
```
1. 브랜치 생성
2. 코드 작성 및 커밋
3. 원격에 푸시
4. PR 생성
5. 리뷰어 지정
6. 리뷰 및 수정
7. 승인 후 병합
8. 브랜치 삭제
```

### 7.2 PR 생성 실습

**Step 1: 기능 브랜치 생성 및 작업**
```bash
# 브랜치 생성 및 전환
git checkout -b docs/improve-readme

# README 수정
echo "## Installation\nRun \`npm install\` to install dependencies." >> README.md

# 커밋
git add README.md
git commit -m "docs: Add installation instructions"

# 원격에 푸시
git push origin docs/improve-readme
```

**Step 2: GitHub에서 PR 생성**

1. **GitHub Repository 방문**
   - 브라우저에서 Repository 페이지 열기
   - "Compare & pull request" 버튼이 자동으로 나타남 (클릭)

2. **PR 정보 입력**
   ```
   Title: Add installation instructions to README
   
   Description:
   ## Changes
   - Added installation section to README
   - Included npm install command
   
   ## Why
   - Users need clear installation instructions
   - Improves onboarding experience
   
   ## Testing
   - Verified markdown formatting
   - Checked for typos
   ```

3. **리뷰어 지정**
   - 우측 "Reviewers" 섹션에서 팀원 선택
   - PM의 경우: 기술 리드 또는 선임 개발자 지정

4. **라벨 추가** (선택)
   - documentation
   - enhancement
   - good first issue (초보자용)

5. **"Create pull request" 클릭**

### 7.3 PR 템플릿 활용

**.github/pull_request_template.md** 파일 생성:
```markdown
## Description
<!-- PR의 목적과 변경사항을 설명하세요 -->

## Type of Change
- [ ] Bug fix
- [ ] New feature
- [ ] Documentation update
- [ ] Refactoring

## Checklist
- [ ] 코드가 프로젝트 스타일 가이드를 따릅니다
- [ ] 자체 리뷰를 완료했습니다
- [ ] 관련 문서를 업데이트했습니다
- [ ] 테스트를 추가했습니다 (해당하는 경우)

## Screenshots (if applicable)
<!-- 스크린샷 추가 -->

## Related Issues
Closes #123
```

---

## 8. Code Review 기초

### 8.1 PM을 위한 Code Review

**PM이 리뷰해야 할 것**:
- ✅ 요구사항 충족 여부
- ✅ 사용자 경험 (UX) 관점
- ✅ 비즈니스 로직 일치 여부
- ✅ 문서화 품질
- ❌ 코드 구현 세부사항 (개발자의 영역)

### 8.2 PR 리뷰 방법

**Step 1: PR 확인**
1. GitHub PR 페이지 방문
2. "Files changed" 탭 클릭
3. 변경된 파일 목록 확인

**Step 2: 코멘트 작성**
- 특정 라인에 코멘트:
  - 라인 번호 옆 "+" 아이콘 클릭
  - 코멘트 작성
  - "Add single comment" 또는 "Start a review" 선택

**Step 3: 리뷰 완료**
- "Review changes" 버튼 클릭
- 선택지:
  - **Comment**: 의견만 남기기
  - **Approve**: 승인
  - **Request changes**: 수정 요청

### 8.3 좋은 리뷰 코멘트 예시

**긍정적이고 건설적인 코멘트**:
```
✅ 좋은 예:
"이 기능은 요구사항을 잘 충족하네요! 다만 에러 메시지가 사용자에게 
좀 더 명확하게 전달될 수 있도록 '이메일 형식이 올바르지 않습니다' 
같은 구체적인 문구는 어떨까요?"

✅ 좋은 예:
"문서화가 잘 되어 있네요 👍 다른 팀원들이 이해하기 쉬울 것 같습니다."

❌ 나쁜 예:
"이건 틀렸어요."

❌ 나쁜 예:
"왜 이렇게 했어요? 이상하네요."
```

**질문 형식 사용**:
```
✅ "이 부분을 이렇게 구현한 이유가 있나요?"
✅ "사용자가 이 버튼을 두 번 클릭하면 어떻게 되나요?"
✅ "이 시나리오는 고려하셨나요: ..."
```

### 8.4 PM 관점의 리뷰 체크리스트

```markdown
## 요구사항 검증
- [ ] 사용자 스토리의 인수 기준을 충족하는가?
- [ ] 비즈니스 요구사항과 일치하는가?
- [ ] Edge case가 처리되었는가?

## 사용자 경험
- [ ] UI가 직관적인가?
- [ ] 에러 메시지가 명확한가?
- [ ] 로딩 상태가 표시되는가?

## 문서화
- [ ] README가 업데이트되었는가?
- [ ] API 문서가 최신인가?
- [ ] 주석이 충분한가?

## 테스트
- [ ] 테스트 케이스가 포함되었는가?
- [ ] 수동 테스트를 수행했는가?

## 비기능적 요구사항
- [ ] 성능 요구사항을 충족하는가?
- [ ] 보안 이슈가 없는가?
- [ ] 접근성이 고려되었는가?
```

---

## 9. GitHub Issues 활용

### 9.1 Issue란?

**정의**:
- 버그, 기능 요청, 질문 등을 추적하는 도구
- 프로젝트의 백로그 역할
- PM의 주요 작업 공간

### 9.2 Issue 생성하기

**Step 1: New Issue 클릭**
- Repository > Issues 탭 > "New issue" 버튼

**Step 2: Issue 정보 입력**

**버그 리포트 예시**:
```markdown
**Title**: 로그인 버튼이 동작하지 않음

**Description**:
## 증상
로그인 페이지에서 "로그인" 버튼을 클릭해도 아무 반응이 없습니다.

## 재현 방법
1. 로그인 페이지 방문 (https://example.com/login)
2. 이메일과 비밀번호 입력
3. "로그인" 버튼 클릭
4. 아무 일도 일어나지 않음

## 예상 동작
- 로그인 성공 시 대시보드로 이동
- 로그인 실패 시 에러 메시지 표시

## 실제 동작
- 버튼 클릭 후 아무 변화 없음
- 콘솔에 에러 메시지: "Uncaught TypeError: Cannot read property 'submit'"

## 환경
- Browser: Chrome 120.0
- OS: Windows 11
- Date: 2024-12-15

## 스크린샷
[스크린샷 첨부]

## 우선순위
Critical - 사용자가 로그인할 수 없음
```

**기능 요청 예시**:
```markdown
**Title**: 다크 모드 지원 추가

**Description**:
## 요청 내용
사용자가 다크 모드와 라이트 모드를 선택할 수 있는 기능을 추가해주세요.

## 동기
- 많은 사용자가 다크 모드를 선호합니다
- 야간 사용 시 눈의 피로를 줄일 수 있습니다
- 배터리 절약 효과가 있습니다 (OLED 화면)

## 제안 사항
- 설정 페이지에 테마 선택 옵션 추가
- 시스템 설정을 따르는 "자동" 옵션 제공
- 사용자 선택을 로컬 스토리지에 저장

## 참고 자료
- Material Design Dark Theme: https://...
- 경쟁사 구현 예시: [링크]

## 우선순위
Medium
```

### 9.3 Issue 관리

**라벨 활용**:
```
bug            - 버그
feature        - 새 기능
documentation  - 문서 작업
enhancement    - 개선사항
question       - 질문
wontfix        - 수정하지 않음
duplicate      - 중복
good first issue - 초보자에게 적합
help wanted    - 도움 요청
```

**마일스톤 설정**:
- 특정 버전이나 스프린트에 Issue 할당
- 진행률 추적 가능
- 예시: "v1.0 Release", "Sprint 3"

**Assignee 지정**:
- 담당자 할당
- 여러 명 할당 가능

**프로젝트 보드 연결**:
- Kanban 보드에 Issue 추가
- To Do, In Progress, Done 등으로 관리

### 9.4 Issue 템플릿 만들기

**.github/ISSUE_TEMPLATE/bug_report.md**:
```markdown
---
name: Bug Report
about: 버그를 신고할 때 사용하세요
title: '[BUG] '
labels: bug
assignees: ''
---

## 증상
<!-- 버그에 대한 간단한 설명 -->

## 재현 방법
1. 
2. 
3. 

## 예상 동작
<!-- 어떻게 동작해야 하는지 설명 -->

## 실제 동작
<!-- 실제로 어떻게 동작하는지 설명 -->

## 환경
- Browser:
- OS:
- Version:

## 스크린샷
<!-- 가능하면 스크린샷 첨부 -->

## 추가 정보
<!-- 기타 관련 정보 -->
```

---

## 10. PM을 위한 GitHub 활용 팁

### 10.1 GitHub Projects 활용

**GitHub Projects = Kanban 보드**

1. **프로젝트 생성**
   - Repository > Projects 탭 > "New project"
   - 템플릿 선택: "Board" 또는 "Table"

2. **컬럼 설정**
   ```
   Backlog → To Do → In Progress → In Review → Done
   ```

3. **Issue를 카드로 추가**
   - 드래그 앤 드롭으로 상태 변경
   - 자동화 설정 가능:
     - PR 생성 시 자동으로 "In Progress"로 이동
     - PR 병합 시 자동으로 "Done"으로 이동

### 10.2 GitHub Actions로 자동화

**예시: PR에 자동으로 라벨 추가**

**.github/workflows/label.yml**:
```yaml
name: Auto Label
on:
  pull_request:
    types: [opened]

jobs:
  label:
    runs-on: ubuntu-latest
    steps:
      - name: Label PR
        uses: actions/labeler@v4
```

### 10.3 README 작성 팁

**좋은 README 구조**:
```markdown
# 프로젝트 이름

간단한 한 줄 설명

## 목차
- [소개](#소개)
- [기능](#기능)
- [설치](#설치)
- [사용법](#사용법)
- [기여 방법](#기여-방법)
- [라이선스](#라이선스)

## 소개
프로젝트의 배경과 목적

## 기능
- ✅ 기능 1
- ✅ 기능 2
- 🔜 예정된 기능 3

## 설치
\```bash
npm install
\```

## 사용법
\```bash
npm start
\```

## 기여 방법
1. Fork
2. 브랜치 생성
3. 커밋
4. PR 생성

## 라이선스
MIT License
```

### 10.4 알림 관리

**이메일 알림 줄이기**:
1. Settings > Notifications
2. "Automatic watching" 끄기
3. "Participating and @mentions" 선택

**Watch 설정**:
- Not watching: 알림 없음
- Releases only: 릴리스 시만 알림
- Watching: 모든 활동 알림
- Ignoring: 완전 무시

### 10.5 GitHub CLI 사용 (고급)

**설치**:
```bash
# Mac
brew install gh

# Windows
winget install --id GitHub.cli
```

**주요 명령어**:
```bash
# 인증
gh auth login

# Issue 생성
gh issue create --title "Bug fix" --body "Description"

# Issue 목록
gh issue list

# PR 생성
gh pr create --title "Feature" --body "Description"

# PR 체크아웃
gh pr checkout 123

# PR 병합
gh pr merge 123 --merge
```

---

## 📚 추가 학습 자료

### 공식 문서
- GitHub Docs: https://docs.github.com
- Git Documentation: https://git-scm.com/doc
- GitHub Learning Lab: https://lab.github.com

### 온라인 코스
- GitHub Skills: https://skills.github.com
- Udacity Git & GitHub: https://www.udacity.com/course/version-control-with-git--ud123

### 유용한 도구
- GitHub Desktop: GUI Git 클라이언트
- GitKraken: 시각적 Git 클라이언트
- VS Code Git Extension: 통합 Git 기능

### 치트시트
- Git Cheat Sheet: https://education.github.com/git-cheat-sheet-education.pdf
- GitHub Flow: https://guides.github.com/introduction/flow/

---

## ✅ 학습 체크리스트

### 기본 (필수)
- [ ] GitHub 계정 생성 완료
- [ ] Git 설치 및 초기 설정 완료
- [ ] Repository 생성 및 Clone 성공
- [ ] 파일 수정, 커밋, 푸시 실습 완료
- [ ] 브랜치 생성 및 전환 실습 완료
- [ ] Pull Request 생성 및 병합 완료
- [ ] Issue 생성 및 관리 실습 완료

### 중급 (권장)
- [ ] 브랜치 전략 이해 (Git Flow vs GitHub Flow)
- [ ] Code Review 참여 경험
- [ ] GitHub Projects로 작업 관리
- [ ] Issue 템플릿 활용
- [ ] PR 템플릿 활용
- [ ] README 작성 및 문서화

### 고급 (선택)
- [ ] GitHub Actions 자동화 구축
- [ ] GitHub CLI 사용
- [ ] 복잡한 병합 충돌 해결
- [ ] Rebase 사용법 이해

---

## 🆘 문제 해결 (Troubleshooting)

### 1. "Permission denied (publickey)" 오류

**원인**: SSH 키 설정이 안 됨

**해결**:
```bash
# SSH 키 생성
ssh-keygen -t ed25519 -C "your_email@example.com"

# SSH 키 복사
cat ~/.ssh/id_ed25519.pub

# GitHub에 SSH 키 등록
# Settings > SSH and GPG keys > New SSH key
```

### 2. "Authentication failed" 오류

**원인**: 비밀번호 인증이 비활성화됨 (2021년 8월부터)

**해결**: Personal Access Token 사용
1. Settings > Developer settings > Personal access tokens
2. "Generate new token (classic)" 클릭
3. 권한 선택: repo, workflow
4. 토큰 복사 (한 번만 표시됨!)
5. Git 명령 실행 시 비밀번호 대신 토큰 사용

### 3. "Merge conflict" 오류

**원인**: 같은 파일의 같은 부분이 다르게 수정됨

**해결**:
```bash
# 1. 충돌 파일 확인
git status

# 2. 파일 열기 (충돌 부분 확인)
# <<<<<<< HEAD
# 현재 브랜치 내용
# =======
# 병합하려는 브랜치 내용
# >>>>>>> feature-branch

# 3. 충돌 해결 (수동 편집)
# 4. 해결된 파일 추가
git add <파일명>

# 5. 병합 완료
git commit
```

### 4. "Detached HEAD" 상태

**원인**: 브랜치가 아닌 특정 커밋을 체크아웃함

**해결**:
```bash
# 브랜치로 돌아가기
git checkout main

# 또는 새 브랜치 생성
git checkout -b new-branch
```

---

## 📞 추가 도움말

### GitHub 용어집
- **Repository (Repo)**: 프로젝트 저장소
- **Clone**: 원격 저장소를 로컬로 복사
- **Commit**: 변경사항 저장 단위
- **Push**: 로컬 변경사항을 원격으로 업로드
- **Pull**: 원격 변경사항을 로컬로 다운로드
- **Branch**: 독립적인 작업 라인
- **Merge**: 브랜치 병합
- **Pull Request (PR)**: 병합 요청
- **Issue**: 작업 항목, 버그, 질문
- **Fork**: 다른 사람의 Repository 복사

### PM을 위한 주간 GitHub 루틴

**매일 (10분)**:
- [ ] 알림 확인 및 처리
- [ ] 새로운 Issue 확인
- [ ] PR 리뷰 (요구사항 관점)

**주간 (30분)**:
- [ ] 프로젝트 보드 업데이트
- [ ] 마일스톤 진행률 확인
- [ ] 완료된 Issue 정리
- [ ] 다음 주 우선순위 설정

**스프린트 종료 시 (1시간)**:
- [ ] 스프린트 회고 Issue 생성
- [ ] 다음 스프린트 마일스톤 생성
- [ ] README 및 문서 업데이트 확인

---

## 🎓 마무리

축하합니다! 이제 PM으로서 GitHub를 활용할 준비가 되었습니다.

### 다음 단계
1. **실습 프로젝트 시작**: 간단한 개인 프로젝트로 연습
2. **팀 협업 참여**: 실제 프로젝트에서 Issue와 PR 관리
3. **문서화 기여**: README, 위키 업데이트
4. **자동화 학습**: GitHub Actions로 워크플로우 구축

### 기억하세요
- GitHub는 단순한 코드 저장소가 아닙니다
- 프로젝트 관리, 협업, 문서화의 중심입니다
- PM으로서 GitHub를 마스터하면 개발팀과의 소통이 훨씬 원활해집니다

**Happy Collaborating! 🚀**

---

**문서 버전**: 1.0  
**최종 업데이트**: 2025년 2월  
**관련 문서**: [SQL 실습 가이드](./sql-practice-guide.md), [AWS Free Tier 가이드](./aws-free-tier-guide.md)
