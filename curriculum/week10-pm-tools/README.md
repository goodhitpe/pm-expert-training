# Week 10: PM 도구 활용

## 📝 학습 목표
- 주요 PM 도구의 특징 및 활용법 학습
- Jira를 활용한 애자일 프로젝트 관리
- MS Project를 활용한 전통적 프로젝트 관리
- 협업 도구를 활용한 팀 커뮤니케이션

## 📚 주요 내용

### 1. PM 도구 개요

#### 1.1 PM 도구의 필요성
- 프로젝트 가시성 확보
- 팀 협업 촉진
- 진척도 추적 자동화
- 문서 중앙 관리
- 보고서 생성 간소화

#### 1.2 도구 선택 기준
- **프로젝트 방법론**: 애자일 vs 전통적
- **팀 규모**: 소규모 vs 대규모
- **복잡도**: 단순 vs 복잡
- **예산**: 무료 vs 유료
- **통합 요구사항**: 다른 시스템과의 연동
- **사용자 친화성**: 학습 곡선

#### 1.3 주요 PM 도구 분류

**애자일 중심:**
- Jira
- Azure DevOps
- Trello
- Asana

**전통적 방법론 중심:**
- Microsoft Project
- Primavera P6

**하이브리드:**
- Monday.com
- Smartsheet
- ClickUp
- Notion

### 2. Jira

#### 2.1 Jira 개요
- Atlassian 제공
- 애자일 프로젝트 관리 특화
- 이슈 추적 시스템
- 소프트웨어 개발팀에서 널리 사용

#### 2.2 Jira 핵심 개념

**프로젝트 (Project):**
- 작업을 담는 컨테이너
- 스크럼/칸반 프로젝트 유형

**이슈 (Issue):**
- 작업 단위
- 유형: Epic, Story, Task, Bug, Subtask

**워크플로우 (Workflow):**
```
To Do → In Progress → Code Review → Testing → Done
```

**보드 (Board):**
- 스크럼 보드: 스프린트 기반
- 칸반 보드: 연속적 흐름

#### 2.3 Jira 실습: 스크럼 프로젝트

**1단계: 프로젝트 생성**
- "Create Project" 클릭
- "Scrum" 선택
- 프로젝트 이름 및 키 설정

**2단계: Epic 생성**
- Issue Type: Epic
- Epic Name: "사용자 인증 기능"
- Epic Summary: 로그인, 회원가입, 비밀번호 재설정

**3단계: 사용자 스토리 생성**
- Issue Type: Story
- Summary: "사용자는 이메일로 로그인할 수 있다"
- Epic Link: "사용자 인증 기능"
- Story Points: 5

**4단계: 백로그 관리**
- Backlog 메뉴 이동
- 드래그 앤 드롭으로 우선순위 조정
- 스프린트에 이슈 할당

**5단계: 스프린트 시작**
- "Start Sprint" 클릭
- Sprint Name, Duration, Goal 설정

**6단계: 보드에서 작업**
- 이슈를 칼럼 간 이동
- 진행 상태 업데이트
- 코멘트 추가

**7단계: 스프린트 종료**
- "Complete Sprint" 클릭
- 완료/미완료 이슈 확인
- 리포트 생성 (Burndown, Velocity)

#### 2.4 Jira 유용한 기능

**필터 (Filter):**
- JQL (Jira Query Language) 사용
- 예: `project = PROJ AND status = "In Progress"`

**대시보드 (Dashboard):**
- 가젯으로 구성
- 번다운 차트, 파이 차트 등 추가

**자동화 (Automation):**
- 규칙 설정
- 예: 이슈 상태 변경 시 담당자에게 알림

**연동 (Integration):**
- Confluence (문서화)
- Slack (알림)
- GitHub/Bitbucket (코드 연동)

### 3. Trello

#### 3.1 Trello 개요
- 간단하고 직관적
- 칸반 기반
- 소규모 팀에 적합
- 무료 플랜 제공

#### 3.2 Trello 구조

**보드 (Board):**
- 프로젝트 또는 팀 단위

**리스트 (List):**
- 작업 단계
- 예: To Do, Doing, Done

**카드 (Card):**
- 작업 항목
- 체크리스트, 첨부파일, 라벨, 기한 설정

#### 3.3 Trello 활용 팁

**템플릿 활용:**
- Kanban Template
- Project Management Template
- Sprint Board Template

**파워업 (Power-Up):**
- Calendar: 달력 뷰
- Card Aging: 오래된 카드 시각화
- Custom Fields: 추가 필드

**Butler 자동화:**
- 규칙, 버튼, 명령 설정
- 예: 카드가 Done으로 이동 시 체크리스트 초기화

### 4. Microsoft Project

#### 4.1 MS Project 개요
- 전통적 PM 도구의 표준
- 복잡한 프로젝트 일정 관리
- Gantt 차트 특화
- Windows 전용 (데스크톱 버전)

#### 4.2 MS Project 핵심 기능

**작업 (Task):**
- 작업명, 기간, 시작일, 종료일
- 요약 작업 (Summary Task)
- 마일스톤

**자원 (Resource):**
- 인적 자원, 물적 자원, 비용 자원
- 자원 캘린더
- 자원 배정 (Assignment)

**의존 관계 (Dependency):**
- FS, SS, FF, SF
- 리드/래그 설정

**기준선 (Baseline):**
- 초기 계획 저장
- 실제와 비교 분석

#### 4.3 MS Project 실습

**1단계: 새 프로젝트 생성**
- 프로젝트 시작일 설정
- 작업 달력 선택

**2단계: WBS 작성**
- Task Name 입력
- 들여쓰기로 계층 구조 생성
- Duration 입력 (예: 5일, 2주)

**3단계: 의존 관계 설정**
- Predecessor 칼럼에 선행 작업 번호 입력
- 예: 3FS+2d (작업 3이 끝나고 2일 후 시작)

**4단계: 자원 추가**
- Resource Sheet 뷰로 전환
- 자원명, 유형, 단가 입력

**5단계: 자원 배정**
- Gantt Chart 뷰로 전환
- Task Information → Resources
- 자원 선택 및 Units 설정

**6단계: 크리티컬 패스 확인**
- Format → Critical Tasks 체크
- 빨간색으로 표시된 경로 확인

**7단계: 기준선 설정**
- Project → Set Baseline
- Baseline 저장

**8단계: 진척도 업데이트**
- % Complete 입력
- Actual Start/Finish 입력
- Tracking Gantt 뷰로 비교

#### 4.4 MS Project 보고서
- Dashboard: 프로젝트 개요
- Burndown: 남은 작업량
- Cost Overview: 예산 대비 실적
- Resource Overview: 자원 활용도

### 5. 기타 협업 도구

#### 5.1 Slack
- 팀 커뮤니케이션
- 채널 기반 대화
- 파일 공유
- 도구 통합 (Jira, Trello, Google Drive)

#### 5.2 Microsoft Teams
- 채팅, 화상 회의
- Office 365 통합
- 파일 협업

#### 5.3 Confluence
- 위키 형태의 문서 관리
- 프로젝트 문서화
- Jira와 연동

#### 5.4 Miro
- 온라인 화이트보드
- 브레인스토밍
- 워크샵 진행

#### 5.5 Google Workspace
- 문서, 스프레드시트, 프레젠테이션
- 실시간 협업
- 클라우드 저장

### 6. 도구 통합 전략

#### 6.1 단일 도구 vs 여러 도구
**장점:**
- 단일: 학습 곡선 낮음, 데이터 일관성
- 여러: 각 분야 최적 도구 사용

**단점:**
- 단일: 기능 제약
- 여러: 데이터 동기화 문제

#### 6.2 통합 사례
- Jira (작업 관리) + Confluence (문서화) + Slack (커뮤니케이션)
- MS Project (일정) + Teams (협업) + SharePoint (문서)
- Trello (백로그) + Google Workspace (문서) + Zoom (회의)

## 💡 실습 과제

### 과제 1: Jira 프로젝트 생성
Jira 무료 계정을 생성하고, 스크럼 프로젝트를 생성한 후 다음을 수행하시오:
- Epic 2개 생성
- 사용자 스토리 10개 생성
- 첫 번째 스프린트 시작
- 스크린샷 제출

### 과제 2: MS Project 일정 작성
MS Project 또는 ProjectLibre(무료 대체)를 사용하여 선정한 프로젝트의 일정을 작성하시오:
- 최소 20개 작업
- 의존 관계 설정
- 크리티컬 패스 표시
- Gantt 차트 PDF 제출

### 과제 3: 도구 비교 분석
Jira, Trello, MS Project 중 2개를 선정하여 비교 분석 보고서를 작성하시오 (A4 1페이지).

## 📖 참고 자료
- Jira Documentation: https://support.atlassian.com/jira-software-cloud/
- Trello Guide: https://trello.com/guide
- Microsoft Project Help: https://support.microsoft.com/project
- ProjectLibre (무료 대체): https://www.projectlibre.com/

## ✅ 자가 점검 퀴즈

1. Jira에서 Epic, Story, Task의 관계는?
2. Trello의 3가지 주요 구성 요소는?
3. MS Project에서 크리티컬 패스를 확인하는 방법은?
4. 칸반 보드와 스크럼 보드의 차이는?
5. PM 도구 선택 시 고려해야 할 기준 3가지는?

## 📝 핵심 용어
- **Jira**: 애자일 프로젝트 관리 도구
- **Epic**: 큰 단위의 작업 (여러 스토리 포함)
- **JQL (Jira Query Language)**: Jira 검색 언어
- **Power-Up**: Trello의 확장 기능
- **Baseline**: MS Project의 계획 기준선
- **Gantt Chart**: 막대 형태의 일정 차트

## 다음 주 예고
Week 11-12에서는 팀별 모의 프로젝트를 진행합니다.
