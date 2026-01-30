# Jira 프로젝트 관리 실습 가이드

> **대상**: PM 교육 Week 10 - PM 도구 활용  
> **소요 시간**: 2-3시간  
> **난이도**: 초급

---

## 📚 목차
1. [Jira란?](#1-jira란)
2. [무료 계정 생성](#2-무료-계정-생성)
3. [첫 프로젝트 생성](#3-첫-프로젝트-생성)
4. [백로그 관리](#4-백로그-관리)
5. [스프린트 운영](#5-스프린트-운영)
6. [보드 활용](#6-보드-활용)
7. [보고서 및 대시보드](#7-보고서-및-대시보드)
8. [실습 프로젝트](#8-실습-프로젝트)

---

## 1. Jira란?

### 1.1 개요
**Jira**는 Atlassian이 개발한 이슈 추적 및 프로젝트 관리 도구입니다.

### 1.2 주요 기능
- ✅ **이슈 추적**: 작업, 버그, 스토리 관리
- ✅ **스크럼/칸반 보드**: 애자일 프로젝트 관리
- ✅ **워크플로우**: 작업 흐름 자동화
- ✅ **보고서**: 번다운 차트, 속도 차트 등
- ✅ **통합**: Confluence, Slack, GitHub 등

### 1.3 사용 사례
- 소프트웨어 개발팀
- IT 지원팀 (헬프데스크)
- 마케팅 캠페인 관리
- HR 프로세스 관리

---

## 2. 무료 계정 생성

### 2.1 Jira Free 플랜 특징
- 사용자: 최대 10명
- 스토리지: 2GB
- 기능: 대부분의 핵심 기능 사용 가능
- 비용: 완전 무료

### 2.2 회원가입 단계

#### Step 1: Jira 웹사이트 접속
1. [https://www.atlassian.com/software/jira/free](https://www.atlassian.com/software/jira/free) 접속
2. **"Get it free"** 버튼 클릭

#### Step 2: 이메일로 가입
1. 이메일 주소 입력
2. 인증 이메일 확인
3. 비밀번호 설정
4. 이름 입력

#### Step 3: 사이트 이름 설정
- 예: `your-company.atlassian.net`
- 이 URL이 Jira 접속 주소가 됨

#### Step 4: 프로젝트 유형 선택
- **Scrum**: 스프린트 기반 (권장)
- **Kanban**: 지속적 흐름
- **Bug tracking**: 버그 추적
- **나중에 선택 가능**

---

## 3. 첫 프로젝트 생성

### 3.1 프로젝트 생성

#### Step 1: Projects 메뉴
1. 좌측 사이드바 **"Projects"** 클릭
2. **"Create project"** 버튼 클릭

#### Step 2: 템플릿 선택
**Scrum 템플릿** 선택 (권장)
- ✅ 백로그
- ✅ 스프린트
- ✅ 보드
- ✅ 보고서

#### Step 3: 프로젝트 정보 입력
- **Name**: 프로젝트 이름 (예: "모바일 앱 개발")
- **Key**: 이슈 접두사 (예: "MA" → MA-1, MA-2...)
- **Access**: 
  - Team-managed (소규모, 간단)
  - Company-managed (대규모, 복잡)

**초보자는 Team-managed 권장**

#### Step 4: 프로젝트 생성 완료
- **"Create"** 버튼 클릭
- 프로젝트 대시보드로 이동

### 3.2 프로젝트 설정

#### 팀원 초대
1. 우측 상단 **"..."** 메뉴
2. **"Project settings"**
3. **"People"** 섹션
4. **"Add people"** → 이메일 입력

#### 워크플로우 설정
**기본 워크플로우** (Scrum):
```
To Do → In Progress → Done
```

**커스터마이징** (선택):
1. **"Workflows"** 섹션
2. 상태 추가/삭제
3. 전환(Transition) 규칙 설정

**권장 워크플로우**:
```
Backlog → To Do → In Progress → Code Review → Testing → Done
```

---

## 4. 백로그 관리

### 4.1 이슈 유형

**Scrum 프로젝트 기본 이슈 유형**:
1. **Epic**: 큰 기능 묶음 (예: "사용자 인증")
2. **Story**: 사용자 스토리 (예: "로그인 기능")
3. **Task**: 작업 (예: "로그인 UI 디자인")
4. **Bug**: 버그 (예: "로그인 실패 시 오류")
5. **Subtask**: 하위 작업

### 4.2 Story 작성 방법

#### Step 1: 백로그에서 Create
1. **"Backlog"** 탭 클릭
2. **"+ Create issue"** 클릭

#### Step 2: Story 정보 입력

**Summary** (제목):
```
사용자 로그인 기능
```

**Description** (설명) - User Story 형식:
```
As a [사용자 역할]
I want to [원하는 기능]
So that [비즈니스 가치]

예:
As a 앱 사용자
I want to 이메일과 비밀번호로 로그인하고 싶다
So that 개인화된 서비스를 이용할 수 있다

Acceptance Criteria:
- [ ] 이메일 형식 검증
- [ ] 비밀번호 최소 8자
- [ ] 로그인 실패 시 오류 메시지
- [ ] 로그인 성공 시 홈 화면 이동
```

**Story Points**: 1, 2, 3, 5, 8, 13, 21 (피보나치 수열)
- 1-2: 간단한 작업 (1-2시간)
- 3-5: 보통 작업 (1-2일)
- 8-13: 복잡한 작업 (3-5일)
- 21+: 너무 큰 작업 → 분리 필요

**Priority**: 
- Highest (빨간색)
- High
- Medium (기본값)
- Low
- Lowest

**Assignee**: 담당자 지정

**Labels**: 태그 (예: frontend, backend, urgent)

#### Step 3: 생성
**"Create"** 클릭

### 4.3 Epic 관리

#### Epic 생성
1. 백로그에서 **"Create epic"** 버튼
2. **Epic name**: 예: "사용자 관리"
3. **Epic description**: 전체 기능 설명

#### Story를 Epic에 연결
1. Story 클릭하여 열기
2. **"Epic Link"** 필드에서 Epic 선택
3. 또는 드래그 앤 드롭으로 Epic 아래에 배치

### 4.4 백로그 우선순위 정렬

**드래그 앤 드롭**:
- 위쪽: 높은 우선순위
- 아래쪽: 낮은 우선순위

**필터 활용**:
- Epic별로 필터
- 담당자별로 필터
- Label별로 필터

---

## 5. 스프린트 운영

### 5.1 스프린트 생성

#### Step 1: 백로그에서 스프린트 생성
1. **"Create sprint"** 버튼 클릭
2. Sprint 이름: "Sprint 1" (자동 생성)

#### Step 2: Sprint에 이슈 추가
**방법 1**: 드래그 앤 드롭
- 백로그에서 이슈를 Sprint 영역으로 드래그

**방법 2**: 이슈에서 Sprint 선택
- 이슈 클릭 → **"Sprint"** 필드에서 선택

#### Step 3: Sprint 목표 및 기간 설정
1. Sprint 이름 옆 **"..."** 클릭
2. **"Edit sprint"** 선택
3. **Sprint Goal**: 예: "로그인 및 회원가입 기능 완성"
4. **Duration**: 1주 또는 2주 (권장: 2주)
5. **Start date**: 시작일
6. **End date**: 종료일 (자동 계산)

### 5.2 스프린트 시작

#### Sprint 시작하기
1. Sprint 우측 **"Start sprint"** 버튼 클릭
2. Sprint가 활성화되어 **Board** 탭에 표시됨

### 5.3 Daily Scrum (일일 스탠드업)

**팀원들이 매일 확인**:
1. **Board** 탭 열기
2. 각자 담당한 이슈 상태 업데이트
3. 질문:
   - 어제 무엇을 했나?
   - 오늘 무엇을 할 것인가?
   - 장애물은 없는가?

### 5.4 스프린트 중 이슈 상태 업데이트

**이슈 이동**:
- **To Do** → **In Progress**: 작업 시작
- **In Progress** → **Code Review**: 코드 리뷰 요청
- **Code Review** → **Testing**: 테스트 중
- **Testing** → **Done**: 완료

**드래그 앤 드롭**으로 간편하게 이동

### 5.5 스프린트 완료

#### Sprint 종료하기
1. Sprint 종료일이 되면 **"Complete sprint"** 버튼 표시
2. 버튼 클릭
3. **완료되지 않은 이슈 처리**:
   - **Option 1**: 다음 Sprint로 이동
   - **Option 2**: Backlog로 반환

#### Sprint Report 확인
- 완료된 Story Points
- 번다운 차트
- 속도(Velocity)

---

## 6. 보드 활용

### 6.1 Board 뷰

**칸반 스타일 보드**:
```
┌─────────┬─────────────┬─────────┬────────┐
│ To Do   │ In Progress │ Testing │ Done   │
├─────────┼─────────────┼─────────┼────────┤
│ MA-5    │ MA-3        │ MA-2    │ MA-1   │
│ MA-6    │ MA-4        │         │        │
└─────────┴─────────────┴─────────┴────────┘
```

### 6.2 Board 커스터마이징

#### 컬럼 추가/삭제
1. Board 우측 상단 **"..."** 메뉴
2. **"Board settings"**
3. **"Columns"** 섹션
4. **"Add column"** 또는 컬럼 삭제

#### 컬럼 WIP 제한 (Work In Progress)
- 동시에 진행할 수 있는 이슈 개수 제한
- 예: **In Progress** 컬럼에 최대 3개
- 병목 현상 방지

#### Swimlanes 설정
**Swimlanes**: 이슈를 그룹화하는 수평 레인

**옵션**:
- Queries: JQL로 그룹화
- Stories: Story별로 그룹화
- Assignees: 담당자별로 그룹화
- Epics: Epic별로 그룹화

**권장**: Epics 또는 Assignees

### 6.3 Quick Filters

**빠른 필터 생성**:
1. **Board settings** → **Quick filters**
2. **Add quick filter**
3. 예:
   - **My Issues**: assignee = currentUser()
   - **Bugs**: type = Bug
   - **High Priority**: priority in (Highest, High)

---

## 7. 보고서 및 대시보드

### 7.1 Burndown Chart (번다운 차트)

**접근**:
1. **Reports** 탭 클릭
2. **Burndown Chart** 선택

**차트 읽는 법**:
- X축: 날짜
- Y축: 남은 Story Points
- **파란선**: 실제 진행
- **회색선**: 이상적 진행

**건강한 Sprint**:
- 파란선이 회색선을 따라감
- 꾸준히 감소

**문제 있는 Sprint**:
- 파란선이 평평 → 작업 정체
- 파란선이 증가 → 범위 증가 (Scope Creep)

### 7.2 Velocity Chart (속도 차트)

**접근**:
1. **Reports** 탭
2. **Velocity Chart** 선택

**차트 구성**:
- X축: Sprint 번호
- Y축: Story Points
- **초록색**: 완료된 Story Points
- **파란색**: 커밋된 Story Points (목표)

**활용**:
- 팀의 평균 속도 파악
- 다음 Sprint 계획에 활용
- 예: 평균 속도 20 SP → 다음 Sprint도 20 SP 계획

### 7.3 Cumulative Flow Diagram

**접근**:
1. **Reports** 탭
2. **Cumulative Flow Diagram** 선택

**차트 해석**:
- 각 상태별 이슈 누적
- 병목 현상 파악 (특정 상태가 계속 증가)
- 흐름의 일관성 확인

### 7.4 대시보드 생성

#### 개인 대시보드
1. **Dashboards** 메뉴
2. **"Create dashboard"**
3. **"Add gadget"** 클릭
4. 유용한 Gadget:
   - **Filter Results**: JQL 쿼리 결과
   - **Sprint Health**: Sprint 건강도
   - **Activity Stream**: 최근 활동
   - **Pie Chart**: 이슈 분포

#### 팀 대시보드 예시
```
┌────────────────────┬────────────────────┐
│ Sprint Burndown    │ Velocity Chart     │
├────────────────────┼────────────────────┤
│ My Issues          │ Team Activity      │
├────────────────────┴────────────────────┤
│ Bug List (High Priority)               │
└────────────────────────────────────────┘
```

---

## 8. 실습 프로젝트

### 8.1 프로젝트: 온라인 서점 웹사이트

**목표**: Jira로 2주 Sprint 계획 및 관리

#### Epic 생성 (3개)

**Epic 1: 사용자 관리**
- 회원가입
- 로그인/로그아웃
- 프로필 관리

**Epic 2: 도서 탐색**
- 도서 목록 조회
- 도서 검색
- 도서 상세 정보

**Epic 3: 주문 관리**
- 장바구니
- 주문하기
- 주문 내역 조회

#### Story 생성 (각 Epic당 2-3개)

**예: Epic 1 - 사용자 관리**

**Story 1**: 
```
Summary: 사용자 회원가입 기능
Description:
As a 신규 사용자
I want to 이메일과 비밀번호로 회원가입하고 싶다
So that 도서를 구매할 수 있다

Acceptance Criteria:
- [ ] 이메일 중복 확인
- [ ] 비밀번호 최소 8자, 영문+숫자 조합
- [ ] 회원가입 성공 시 로그인 페이지로 이동
- [ ] 실패 시 오류 메시지 표시

Story Points: 5
Priority: High
```

**Story 2**:
```
Summary: 사용자 로그인 기능
Description: (위 형식과 동일)
Story Points: 3
Priority: Highest
```

#### Task 및 Subtask 생성

**Story 1 하위 Task**:
1. 회원가입 UI 디자인 (1 SP)
2. 백엔드 API 개발 (2 SP)
3. 프론트엔드 구현 (2 SP)
4. 테스트 작성 (1 SP)

#### Sprint 계획

**Sprint 1 (2주)**:
- Story Points 목표: 20-25 SP
- Epic 1의 모든 Story (회원가입, 로그인, 프로필)
- Epic 2의 일부 Story (도서 목록)

#### Sprint 실행 시뮬레이션

**Day 1-3**: 
- 회원가입 UI 완료 → **Done**
- 로그인 백엔드 개발 중 → **In Progress**

**Day 4-7**:
- 회원가입 백엔드 완료 → **Done**
- 로그인 프론트엔드 구현 → **In Progress**

**Day 8-10**:
- 모든 회원가입 작업 완료 → **Done**
- 도서 목록 UI 시작 → **In Progress**

**Day 11-14**:
- 로그인 기능 완료 → **Done**
- 도서 목록 일부 완료, 일부 미완성 → **Next Sprint**

### 8.2 체크리스트

완료해야 할 항목:

#### 프로젝트 설정
- [ ] Jira 계정 생성
- [ ] "온라인 서점" 프로젝트 생성 (Scrum)
- [ ] 워크플로우 확인 (To Do → In Progress → Done)

#### 백로그 작성
- [ ] 3개 Epic 생성
- [ ] 각 Epic당 2-3개 Story 생성
- [ ] 각 Story당 Story Points 부여
- [ ] 우선순위 설정

#### Sprint 운영
- [ ] Sprint 1 생성 (2주)
- [ ] 20-25 SP 상당의 Story를 Sprint에 추가
- [ ] Sprint 시작
- [ ] 매일 이슈 상태 업데이트 (시뮬레이션)
- [ ] Sprint 완료

#### 보고서
- [ ] Burndown Chart 스크린샷
- [ ] Velocity Chart 스크린샷 (최소 1 Sprint 완료 후)
- [ ] 완료된 Story 목록

### 8.3 제출 자료

**스크린샷 모음** (PDF로 제출):
1. 프로젝트 백로그 전체 화면
2. Epic 및 Story 목록
3. Sprint Board (활성 Sprint)
4. Burndown Chart
5. 완료된 Sprint Report

**소감문** (A4 1페이지):
- Jira 사용 경험
- 어려웠던 점
- 실무에서 어떻게 활용할 수 있을지

---

## 9. 고급 기능 (선택)

### 9.1 JQL (Jira Query Language)

**JQL이란?**: Jira의 강력한 검색 언어

**예제**:
```jql
project = "온라인서점" AND status = "In Progress" AND assignee = currentUser()
```

**자주 쓰는 JQL**:
```jql
# 내가 담당한 이슈
assignee = currentUser()

# 높은 우선순위 버그
type = Bug AND priority in (Highest, High)

# 이번 Sprint 이슈
sprint in openSprints()

# 지난 주에 생성된 이슈
created >= -1w

# Epic별 이슈
"Epic Link" = MA-1
```

### 9.2 Automation

**자동화 규칙 예**:
1. **Story가 Done이 되면 자동으로 Epic 진행률 업데이트**
2. **High Priority 이슈 생성 시 PM에게 자동 알림**
3. **3일 이상 In Progress 상태면 경고 알림**

**설정**:
1. **Project settings** → **Automation**
2. **Create rule**
3. **Trigger** → **Condition** → **Action** 설정

### 9.3 Confluence 연동

**Confluence**: Atlassian의 위키/문서 도구

**연동 방법**:
1. Confluence 페이지에서 Jira 이슈 임베드
2. Jira 이슈에서 Confluence 페이지 링크
3. 자동 동기화

---

## 10. 참고 자료

### 공식 문서
- [Jira 사용자 가이드](https://support.atlassian.com/jira-software-cloud/docs/)
- [Jira Scrum 가이드](https://www.atlassian.com/agile/scrum)

### 동영상 튜토리얼
- [Jira Tutorial for Beginners (YouTube)](https://www.youtube.com/results?search_query=jira+tutorial+for+beginners)
- [Atlassian University (무료)](https://university.atlassian.com/)

### 한글 자료
- Jira 한글 커뮤니티 (네이버 카페 등)
- 유튜브 "Jira 사용법" 검색

---

## 11. 자주 묻는 질문 (FAQ)

**Q1: Jira Free vs Paid 차이는?**
**A**: Free는 10명 제한, 2GB 스토리지. Standard는 무제한 사용자, 250GB. 소규모 팀은 Free로 충분.

**Q2: Scrum vs Kanban 어떤 것을 선택해야 하나요?**
**A**: 
- **Scrum**: 정해진 Sprint 주기가 있는 프로젝트 (2-4주)
- **Kanban**: 지속적 흐름, 고정 Sprint 없음 (지원팀, 운영팀)

**Q3: Story Points는 어떻게 정하나요?**
**A**: 팀의 상대적 추정. Planning Poker 활용. 작은 Story를 기준(1 SP)으로 삼고 비교.

**Q4: Epic, Story, Task, Subtask 차이는?**
**A**:
- **Epic**: 큰 기능 (예: 사용자 관리) - 여러 Sprint
- **Story**: 사용자 스토리 (예: 로그인) - 1 Sprint 내
- **Task**: 기술적 작업 (예: DB 설계)
- **Subtask**: Story/Task의 하위 작업 (예: UI 버튼 구현)

**Q5: Jira를 혼자서도 사용할 수 있나요?**
**A**: 네, 개인 프로젝트 관리에도 유용합니다. To-Do 리스트보다 강력.

---

**문서 버전**: 1.0  
**작성일**: 2025년 1월  
**업데이트**: 정기적으로 최신 Jira 기능 반영 예정
