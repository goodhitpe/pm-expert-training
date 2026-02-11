# Week 10: PM 도구 활용

---

> **📚 PMBOK 버전**: 이 자료는 PMBOK 6th Edition을 기반으로 하며,  
> 7th Edition의 주요 변화를 추가로 다룹니다.  
> 👉 [상세 버전 정책 보기](../../PMBOK_VERSION_POLICY.md)

---

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

## 🎯 실무 적용 예시: Jira + GitHub + CI/CD 통합 워크플로우

### 예시 1: 완전 자동화된 개발 파이프라인

**프로젝트**: SaaS 플랫폼 (10명 개발팀)

#### 통합 아키텍처

```
┌─────────┐    ┌─────────┐    ┌─────────┐    ┌─────────┐
│  Jira   │ ←→ │ GitHub  │ ←→ │Jenkins  │ ←→ │  AWS    │
│(작업관리)│    │(코드)   │    │(CI/CD)  │    │(배포)   │
└─────────┘    └─────────┘    └─────────┘    └─────────┘
     ↓              ↓              ↓              ↓
  Sprint        Pull          Auto           Auto
  Tracking      Request       Build          Deploy
```

#### Step-by-Step 워크플로우

```
Day 1: Sprint Planning
━━━━━━━━━━━━━━━━━━━━━━━━━━
Jira에서:
1. Epic 생성: "결제 시스템 v2.0"
2. Story 생성: "PROJ-123: 신용카드 결제 추가"
   - Story Points: 8
   - Sprint: Sprint 15
   - Assignee: 개발자 김철수

Day 2: 개발 시작
━━━━━━━━━━━━━━━━━━━━━━━━━━
개발자 김철수:

1. Jira 티켓 상태 변경
   Jira: PROJ-123 → "진행 중"
   
2. GitHub 브랜치 생성 (자동 연동)
   $ git checkout -b feature/PROJ-123-credit-card
   
   브랜치명 규칙: feature/[Jira 티켓번호]-[설명]
   → Jira Smart Commit으로 자동 연동

3. 코드 작성
   payment-service.js 수정
   
4. Commit (Smart Commit 활용)
   $ git commit -m "PROJ-123 #time 4h #comment 카드 검증 로직 구현"
   
   효과:
   - Jira에 자동으로 4시간 작업 시간 기록
   - 코멘트 자동 추가
   - Work Log 자동 업데이트

Day 3: Pull Request
━━━━━━━━━━━━━━━━━━━━━━━━━━
1. GitHub PR 생성
   Title: "[PROJ-123] 신용카드 결제 추가"
   Description:
   ```
   ## Changes
   - 신용카드 유효성 검증
   - PG사 API 연동
   - 에러 처리
   
   ## Jira Ticket
   https://company.atlassian.net/browse/PROJ-123
   
   ## Test Coverage
   - Unit Tests: 95%
   - Integration Tests: Pass
   ```

2. 자동 트리거 (GitHub Actions)
   PR 생성 → 자동으로:
   ✅ Lint 검사 (ESLint)
   ✅ 단위 테스트 (Jest)
   ✅ 코드 커버리지 (80% 이상 필수)
   ✅ 보안 스캔 (Snyk)
   ✅ 빌드 테스트
   
   결과: 모두 통과 ✅
   
3. Jira 자동 업데이트
   PROJ-123 상태 → "코드 리뷰"
   코멘트 추가: "PR#456 생성됨"

Day 4: 코드 리뷰
━━━━━━━━━━━━━━━━━━━━━━━━━━
시니어 개발자 이영희:

1. GitHub에서 리뷰
   Comment: "Line 45: 에러 처리 개선 필요"
   Request Changes
   
2. Jira 자동 알림
   김철수에게 Slack DM:
   "PROJ-123 코드 리뷰 피드백 있음"

Day 5: 수정 및 승인
━━━━━━━━━━━━━━━━━━━━━━━━━━
1. 김철수 수정
   $ git commit -m "PROJ-123 #comment 에러 처리 개선"
   $ git push
   
2. 자동 재검사
   CI 파이프라인 재실행 → 통과 ✅
   
3. 리뷰어 승인
   이영희: "Approved ✅"
   
4. Merge to main
   $ git merge feature/PROJ-123-credit-card
   
5. 자동 트리거 (Jenkins CI/CD)
   main 브랜치 merge → 자동으로:
   
   Stage 1: Build (2분)
   ━━━━━━━━━━━━━━━━━━━━━━━━━━
   ✅ npm install
   ✅ npm run build
   ✅ Docker image 생성
   
   Stage 2: Test (5분)
   ━━━━━━━━━━━━━━━━━━━━━━━━━━
   ✅ 단위 테스트 (2,000개)
   ✅ 통합 테스트 (500개)
   ✅ E2E 테스트 (50개)
   
   Stage 3: Security Scan (3분)
   ━━━━━━━━━━━━━━━━━━━━━━━━━━
   ✅ OWASP Dependency Check
   ✅ SonarQube 코드 분석
   ✅ 취약점: 0건
   
   Stage 4: Deploy to Staging (2분)
   ━━━━━━━━━━━━━━━━━━━━━━━━━━
   ✅ AWS ECS Staging 배포
   ✅ Health Check 통과
   ✅ Smoke Test 통과
   
   Stage 5: Deploy to Production (2분)
   ━━━━━━━━━━━━━━━━━━━━━━━━━━
   ✅ Blue-Green Deployment
   ✅ 트래픽 전환 (0% → 100%)
   ✅ Rollback 대기 (30분)
   
   총 소요 시간: 14분

6. Jira 자동 완료
   PROJ-123 상태 → "완료"
   코멘트: "배포 완료 - Production"
   Release Note 자동 생성
```

#### 통합 대시보드 (실시간 모니터링)

```
PM 대시보드 (Jira Dashboard):
━━━━━━━━━━━━━━━━━━━━━━━━━━
Sprint 15 진행 상황:

Burndown Chart:
Day 1: 40 SP 남음
Day 5: 28 SP 남음 ✅ (목표선 위)
Day 10: 예상 완료

Velocity:
Sprint 12: 35 SP
Sprint 13: 38 SP
Sprint 14: 40 SP ← 트렌드 상승
Sprint 15: 40 SP (목표)

Cycle Time:
평균: 3.2일 (목표: 5일 이하) ✅

Code Quality (SonarQube):
- 커버리지: 85% ✅
- 버그: 3건 (모두 Low)
- 기술 부채: 2일 (관리 가능)

Deployment Frequency:
- 주간: 8회
- 성공률: 100%
- 평균 배포 시간: 12분

Lead Time (Jira → Production):
- 평균: 2.5일 ✅
- 목표: 3일 이하
```

### 예시 2: Jira 자동화 규칙 (Automation Rules)

```
Rule 1: Sprint 시작 시 자동 알림
━━━━━━━━━━━━━━━━━━━━━━━━━━
Trigger: Sprint 상태 → "Active"
Action:
  - Slack 채널에 메시지
  - 모든 티켓 담당자에게 이메일
  - Sprint Goal Confluence 페이지 생성

Rule 2: 고위험 버그 자동 에스컬레이션
━━━━━━━━━━━━━━━━━━━━━━━━━━
Trigger: 
  - Issue Type = Bug
  - Priority = Critical
  - 생성 후 30분 경과
  - 상태 = "열림"

Action:
  - PM에게 Slack DM
  - Assignee를 시니어 개발자로 변경
  - Due Date = 당일
  - 라벨 추가: "urgent"

Rule 3: PR 병합 시 티켓 자동 전환
━━━━━━━━━━━━━━━━━━━━━━━━━━
Trigger: GitHub PR merged
Condition: PR 제목에 Jira 티켓번호 포함
Action:
  - 티켓 상태 → "배포 대기"
  - Comment: "PR#XXX merged"
  - QA 담당자에게 할당

Rule 4: 장기 미완료 티켓 알림
━━━━━━━━━━━━━━━━━━━━━━━━━━
Trigger: 매주 월요일 9:00
Condition:
  - 상태 = "진행 중"
  - 7일 이상 업데이트 없음

Action:
  - 담당자에게 Slack DM
  - PM에게 요약 리포트
  - 라벨 추가: "stale"
```

### 예시 3: MS Project + Teams 통합 (대기업 환경)

```
시나리오: 건설 프로젝트 (1,000개 태스크, 50명)

MS Project:
━━━━━━━━━━━━━━━━━━━━━━━━━━
- Gantt Chart: 마스터 스케줄
- Resource Leveling: 자원 평준화
- Critical Path: 크리티컬 패스 추적
- Baseline: 기준선 설정

Teams 통합:
━━━━━━━━━━━━━━━━━━━━━━━━━━
1. 프로젝트별 Team 생성
   - General 채널: 공지사항
   - Tasks 채널: 일일 업데이트
   - Issues 채널: 문제 해결

2. Planner 탭 추가
   - MS Project 태스크 동기화
   - 주간 마일스톤 표시
   - 담당자별 작업 목록

3. SharePoint 문서 라이브러리
   - 설계 도면 (AutoCAD)
   - 시방서 (PDF)
   - 회의록 (Word)
   - 버전 관리

4. Power BI 대시보드
   - MS Project 데이터 연동
   - 실시간 진척률
   - 비용 대비 실적 (EVM)
   - 리스크 Heat Map

워크플로우:
━━━━━━━━━━━━━━━━━━━━━━━━━━
오전 9:00 - Daily Meeting (Teams 화상)
- PM이 Gantt Chart 화면 공유
- 각 팀 리더 진행 상황 보고
- 이슈 식별 및 즉시 논의

오전 10:00 - MS Project 업데이트
- 팀 리더가 실적 입력
- PM이 일정 재계산
- Critical Path 변경 확인

오후 2:00 - Power BI 자동 리프레시
- 대시보드 업데이트
- 경영진에게 자동 이메일
- Red Alert 시 Teams 알림

주간 보고:
- MS Project → PDF Export
- Teams에 자동 업로드
- 이해관계자에게 공유
```

### 실전 팁: 도구 선택 기준

```
┌─────────────┬──────────┬──────────┬──────────┐
│ 기준        │ Jira     │ MS Project│ Trello   │
├─────────────┼──────────┼──────────┼──────────┤
│ 방법론      │ 애자일✅ │ 워터폴✅ │ 칸반✅   │
│ 팀 규모     │ 10-100명 │ 10-1000명│ 3-20명   │
│ 복잡도      │ 중-고    │ 고       │ 저-중    │
│ 가격        │ $7/월    │ $30/월   │ 무료~$10 │
│ 학습 곡선   │ 중간     │ 높음     │ 낮음     │
│ API 통합    │ 풍부✅   │ 제한적   │ 보통     │
└─────────────┴──────────┴──────────┴──────────┘

PM 선택 가이드:
━━━━━━━━━━━━━━━━━━━━━━━━━━
스타트업 (10명, 애자일):
→ Jira + GitHub + Slack

중견기업 (50명, 하이브리드):
→ Jira (애자일) + MS Project (마스터 스케줄)

대기업 (500명, 워터폴):
→ MS Project + Teams + SharePoint

소규모 팀 (5명, 칸반):
→ Trello + Google Workspace
```

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
