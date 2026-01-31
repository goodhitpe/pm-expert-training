# Week 10: PM 도구 활용 상세 강의 자료

## 📚 학습 목표 (상세)
1. **GitHub Projects** 프로젝트 보드 생성 및 관리
2. **Trello** 칸반 보드 활용 및 Power-Ups 설정
3. **PM 도구 비교** (Jira, GitHub Projects, Trello) 및 선택 기준
4. **애자일 보드** 설정 및 워크플로우 최적화
5. **자동화 설정** 및 생산성 향상 기법

---

## 📖 Part 1: PM 도구 개요

### 1.1 PM 도구의 필요성

#### 프로젝트 관리의 어려움
- 작업 추적 어려움 (스프레드시트 한계)
- 팀 협업 비효율
- 진행 상황 가시성 부족
- 문서 산재 및 정보 손실
- 수작업 반복 (상태 업데이트, 알림 등)

#### PM 도구의 이점
- ✅ 작업 중앙 관리
- ✅ 실시간 협업
- ✅ 진행 상황 시각화
- ✅ 자동화로 생산성 향상
- ✅ 히스토리 추적 및 분석

### 1.2 PM 도구 선택 기준

| 기준 | 설명 | 중요도 |
|-----|------|--------|
| **팀 규모** | 소규모(~10명) vs 대규모(100명+) | 높음 |
| **예산** | 무료 vs 유료 | 높음 |
| **기능** | 필수 기능 충족 여부 | 높음 |
| **통합** | 기존 도구와 연동 | 중간 |
| **학습 곡선** | 사용 난이도 | 중간 |
| **커스터마이징** | 워크플로우 맞춤화 | 중간 |

---

## 🐙 Part 2: GitHub Projects 실습

### 2.1 GitHub Projects 개요

#### 특징
- GitHub 생태계 통합 (코드 + 이슈 + 프로젝트)
- 무료 (공개 저장소, 프라이빗은 Team/Enterprise)
- 간단한 칸반 보드
- 자동화 기능
- 코드와 긴밀한 연동

#### 언제 사용할까?
- ✅ 소프트웨어 개발 프로젝트
- ✅ GitHub 이미 사용 중
- ✅ 코드-이슈 연동 필요
- ✅ 예산 제한 (무료)

### 2.2 GitHub Projects 시작하기

#### Step 1: 프로젝트 생성

1. **저장소 프로젝트 vs 사용자 프로젝트**
   - 저장소 프로젝트: 특정 저장소에 속함
   - 사용자 프로젝트: 여러 저장소 연동 가능

2. **프로젝트 생성 방법**
   ```
   GitHub 저장소 → Projects 탭 → New project
   
   템플릿 선택:
   - Board: 칸반 스타일
   - Table: 스프레드시트 스타일
   - Roadmap: 타임라인 뷰
   ```

3. **프로젝트 이름 및 설명**
   - 예: "Mobile App Development Sprint 1"
   - 설명: "2주 스프린트, 로그인 및 메인 화면 개발"

#### Step 2: 칸반 보드 설정

**기본 컬럼**:
```
To Do → In Progress → Done
```

**확장 컬럼** (권장):
```
Backlog → To Do → In Progress → In Review → Done
```

**컬럼 추가 방법**:
```
+ Add column → 컬럼명 입력 → Create
```

**실습 예제: 웹 프로젝트 보드**
```
┌──────────┬─────────┬──────────┬─────────┬──────┐
│ Backlog  │  To Do  │In Progress│In Review│ Done │
├──────────┼─────────┼──────────┼─────────┼──────┤
│ Feature A│Issue #12│Issue #5  │Issue #8 │Issue1│
│ Feature B│Issue #15│Issue #10 │         │Issue2│
│ Feature C│         │          │         │Issue3│
└──────────┴─────────┴──────────┴─────────┴──────┘
```

#### Step 3: 이슈 (Issue) 생성 및 관리

**이슈 생성**:
```
Issues 탭 → New issue
또는
프로젝트 보드 → Add item → Create new issue

필드:
- Title: 간결한 제목
- Description: 상세 설명 (Markdown 지원)
- Assignees: 담당자
- Labels: 태그 (bug, feature, enhancement 등)
- Milestone: 마일스톤
- Projects: 프로젝트 연결
```

**이슈 템플릿 예시**:
```markdown
## 📋 Description
사용자가 이메일로 로그인할 수 있는 기능

## ✅ Acceptance Criteria
- [ ] 이메일 입력 필드
- [ ] 비밀번호 입력 필드
- [ ] 로그인 버튼
- [ ] 유효성 검사 (이메일 형식)
- [ ] 에러 메시지 표시
- [ ] 성공 시 메인 화면 이동

## 🔗 Related Issues
- #10 (User model)
- #11 (Authentication API)

## 📌 Notes
- JWT 토큰 사용
- 세션 7일 유지
```

#### Step 4: 라벨 (Labels) 활용

**기본 라벨**:
```
bug          🐛 버그 수정
feature      ✨ 새 기능
enhancement  🚀 기능 개선
documentation 📚 문서 작성
help wanted  🆘 도움 필요
wontfix      ❌ 수정 안 함
```

**우선순위 라벨**:
```
priority: high    🔴 긴급
priority: medium  🟡 보통
priority: low     🟢 낮음
```

**분류 라벨**:
```
frontend  🎨 프론트엔드
backend   ⚙️ 백엔드
design    🎨 디자인
testing   🧪 테스트
```

#### Step 5: 마일스톤 (Milestone) 설정

**마일스톤 생성**:
```
Issues → Milestones → New milestone

예시:
- Sprint 1 (2023-02-01 ~ 2023-02-14)
- MVP Release (2023-03-31)
- v1.0 Release (2023-06-30)
```

**마일스톤 활용**:
```
진행률 자동 계산:
Sprint 1 [████████░░] 80% (8/10 issues closed)

- 완료된 이슈 / 전체 이슈 비율
- 번다운 차트 대체
```

#### Step 6: 자동화 (Automation) 설정

**기본 자동화**:
```
1. Issue created → Backlog 컬럼에 자동 추가
2. Pull Request opened → In Review로 이동
3. Pull Request merged → Done으로 이동
4. Issue closed → Done으로 이동
```

**GitHub Actions 연동**:
```yaml
name: Move issue to In Progress
on:
  issues:
    types: [assigned]
jobs:
  move-to-in-progress:
    runs-on: ubuntu-latest
    steps:
      - uses: alex-page/github-project-automation-plus@v0.8.1
        with:
          project: Project Board Name
          column: In Progress
          repo-token: ${{ secrets.GITHUB_TOKEN }}
```

### 2.3 GitHub Projects 활용 팁

#### 팁 1: 커밋-이슈 연동
```bash
git commit -m "Add login form - closes #12"

결과:
- 커밋이 #12 이슈에 자동 연결
- "closes"로 커밋 시 이슈 자동 닫힘
- Done 컬럼으로 자동 이동
```

#### 팁 2: Pull Request 템플릿
```markdown
## What
로그인 기능 구현

## Why
사용자 인증 필요

## How
- JWT 토큰 방식
- 이메일 + 비밀번호 인증

## Testing
- [ ] 단위 테스트 추가
- [ ] 통합 테스트 통과

Closes #12
```

#### 팁 3: 필터 및 검색
```
검색 쿼리 예시:
- is:open label:bug : 열린 버그 이슈
- assignee:@me : 내가 담당한 이슈
- milestone:"Sprint 1" : 스프린트 1 이슈
- label:frontend is:pr : 프론트엔드 PR
```

---

## 📋 Part 3: Trello 실습

### 3.1 Trello 개요

#### 특징
- 직관적인 칸반 보드
- 드래그 앤 드롭 UX
- Power-Ups (확장 기능)
- 무료 버전으로 시작 가능
- 비개발 팀도 쉽게 사용

#### 언제 사용할까?
- ✅ 비개발 프로젝트 (마케팅, 이벤트 등)
- ✅ 간단한 작업 관리
- ✅ 시각적 보드 선호
- ✅ 빠른 설정 필요

### 3.2 Trello 시작하기

#### Step 1: 보드 생성

**보드 생성 방법**:
```
Trello 홈 → Create new board
- 보드 이름: "마케팅 캠페인 Q1"
- 배경: 색상 또는 이미지 선택
- 팀: Workspace 선택 (팀 작업 시)
```

**템플릿 활용**:
```
Trello 제공 템플릿:
- Kanban Board
- Project Management
- Scrum Board
- Weekly Planning
- Event Planning
```

#### Step 2: 리스트 (List) 설정

**기본 리스트**:
```
To Do → Doing → Done
```

**확장 리스트** (프로젝트 관리):
```
Backlog → This Week → In Progress → Review → Completed
```

**확장 리스트** (마케팅):
```
Ideas → Planning → In Progress → Review → Published
```

#### Step 3: 카드 (Card) 생성 및 관리

**카드 생성**:
```
리스트에서 + Add a card → 제목 입력 → Add card
```

**카드 상세 정보**:
```
카드 클릭 시:
- Description: 상세 설명
- Members: 담당자 배정
- Labels: 색상 라벨
- Checklist: 체크리스트 추가
- Due Date: 마감일 설정
- Attachments: 파일 첨부
- Comments: 코멘트
```

**실습 예제: 블로그 포스트 카드**
```
제목: "애자일 방법론 소개 블로그 작성"

Description:
- 애자일 선언문 설명
- 스크럼 vs 칸반 비교
- 실제 사례 2개
- 2,000자 이상

Checklist:
☑ 주제 조사
☑ 초안 작성
☐ 이미지 제작
☐ 1차 리뷰
☐ 수정
☐ 최종 승인
☐ 발행

Members: @김철수
Labels: Content, Priority: High
Due Date: 2023-02-15
```

#### Step 4: 라벨 (Label) 활용

**라벨 생성 및 편집**:
```
보드 메뉴 → Labels → Create new label

색상별 의미 부여 예시:
🔴 빨강: 긴급 (Urgent)
🟠 주황: 높음 (High)
🟡 노랑: 보통 (Medium)
🟢 초록: 낮음 (Low)
🔵 파랑: 정보 (Info)
🟣 보라: 디자인 (Design)
```

#### Step 5: Power-Ups 활용

**무료 Power-Ups** (보드당 1개):
```
추천 Power-Ups:
1. Calendar: 마감일을 달력으로 표시
2. Custom Fields: 커스텀 필드 추가
3. Card Repeater: 반복 작업 자동 생성
4. GitHub: GitHub 연동
5. Slack: Slack 알림
```

**Calendar Power-Up 활용**:
```
마감일이 있는 카드를 월별/주별 달력으로 시각화
- 이번 주 마감: 5개
- 다음 주 마감: 3개
- 지난 마감: 1개 (빨간색)
```

**Custom Fields 활용**:
```
추가 필드:
- 스토리 포인트: 숫자 (1-13)
- 담당 팀: 드롭다운 (Dev, Design, QA)
- 우선순위: 체크박스
```

#### Step 6: 자동화 (Butler) 활용

**Butler 자동화 예시**:

**규칙 1: 카드 완료 시 Done으로 이동**
```
When all items in a checklist are completed
→ Move the card to list "Done"
→ Add label "Completed"
```

**규칙 2: 마감일 자동 설정**
```
When a card is added to list "This Week"
→ Set due date to "Friday at 5:00 PM"
```

**규칙 3: 담당자 배정 시 알림**
```
When a member is added to a card
→ Post comment "@{membername} 님이 배정되었습니다"
```

**버튼 생성**:
```
버튼: "Ready for Review"
→ Move card to list "Review"
→ Add label "Review Needed"
→ Assign @reviewer
→ Post comment "리뷰 요청"
```

### 3.3 Trello 활용 팁

#### 팁 1: 보드 통합
```
여러 보드를 하나의 대시보드로:
- Workspace view 사용
- Table view로 전체 카드 한눈에 보기
- Timeline view로 간트 차트
```

#### 팁 2: 카드 템플릿
```
자주 사용하는 카드 유형:
- 버그 리포트 템플릿
- 기능 요청 템플릿
- 회의록 템플릿

Make Template 버튼으로 재사용
```

#### 팁 3: 키보드 단축키
```
유용한 단축키:
- N: 새 카드 추가
- E: 카드 빠른 편집
- Space: 자신을 카드에 배정
- L: 라벨 추가
- D: 마감일 설정
- /: 검색
```

---

## 🆚 Part 4: PM 도구 비교

### 4.1 Jira vs GitHub Projects vs Trello

| 기능 | Jira | GitHub Projects | Trello |
|-----|------|----------------|--------|
| **가격** | 유료 (소규모 무료) | 무료 (일부 유료) | 무료 (Power-Up 제한) |
| **학습 곡선** | 가파름 | 보통 | 완만함 |
| **기능 풍부도** | 매우 높음 | 보통 | 낮음 |
| **애자일 지원** | 강력 | 보통 | 기본 |
| **코드 연동** | 플러그인 | 네이티브 | 플러그인 |
| **보고서** | 강력 | 약함 | 약함 |
| **커스터마이징** | 매우 높음 | 낮음 | 보통 |
| **팀 규모** | 대규모 | 소중규모 | 소규모 |

### 4.2 용도별 추천

#### 소프트웨어 개발 프로젝트
```
1순위: Jira (예산 있음)
2순위: GitHub Projects (예산 없음)
3순위: Trello (간단한 프로젝트)
```

#### 마케팅/비개발 프로젝트
```
1순위: Trello
2순위: Asana
3순위: Monday.com
```

#### 스타트업 (소규모)
```
1순위: GitHub Projects (개발)
2순위: Trello (전사)
3순위: Linear (개발 + 디자인)
```

#### 대기업 (대규모)
```
1순위: Jira + Confluence
2순위: Azure DevOps
3순위: Jira + Trello 조합
```

### 4.3 팀 규모별 추천

| 팀 규모 | 추천 도구 | 이유 |
|--------|---------|------|
| **1-5명** | Trello, Notion | 간단, 무료, 빠른 설정 |
| **5-15명** | GitHub Projects, Linear | 개발 중심, 적당한 기능 |
| **15-50명** | Jira, Azure DevOps | 구조화 필요, 보고 기능 |
| **50명+** | Jira, ServiceNow | 엔터프라이즈 기능 필수 |

### 4.4 비용 비교

**Jira** (월 사용자당):
```
Free: 10명까지 무료
Standard: $7.75/user
Premium: $15.25/user
Enterprise: 맞춤 견적
```

**GitHub Projects**:
```
Free: 공개 저장소 무료
Team: $4/user (프라이빗)
Enterprise: $21/user
```

**Trello**:
```
Free: 무료 (제한적)
Standard: $5/user
Premium: $10/user
Enterprise: $17.50/user
```

**1년 비용 (10명 팀)**:
```
Jira Standard: $930/년
GitHub Team: $480/년
Trello Standard: $600/년
```

---

## 🔧 Part 5: 애자일 보드 설정 모범 사례

### 5.1 칸반 보드 워크플로우

#### 기본 워크플로우
```
Backlog → To Do → In Progress → Done
```

#### 스크럼 워크플로우
```
Backlog → Sprint Backlog → In Progress → In Review → Done
```

#### 개발팀 워크플로우
```
Backlog → To Do → Dev → Code Review → QA → Staging → Done
```

### 5.2 WIP 제한 설정

**Jira WIP 제한**:
```
보드 설정 → Columns → 컬럼별 Max/Min 설정

예시:
- To Do: 무제한
- In Progress: 3 (팀원 3명)
- Review: 2
- Done: 무제한
```

**Trello WIP 제한**:
```
List Limits Power-Up 사용
또는
리스트 이름에 표시: "In Progress (3/5)"
```

### 5.3 스윔레인 (Swimlane) 활용

**Jira 스윔레인**:
```
수평 레인으로 작업 그룹화:
- 담당자별
- 우선순위별
- 프로젝트별
- 스토리별
```

**스윔레인 예시**:
```
High Priority    │ Task A │ Task B │        │ Task C │
─────────────────┼────────┼────────┼────────┼────────┤
Medium Priority  │ Task D │        │ Task E │        │
─────────────────┼────────┼────────┼────────┼────────┤
Low Priority     │ Task F │ Task G │        │ Task H │
                 └────────┴────────┴────────┴────────┘
                   To Do    In Prog  Review   Done
```

### 5.4 자동화 설정

#### 자동화 시나리오

**시나리오 1: 이슈 자동 분류**
```
Jira Automation:
When: Issue created
If: Summary contains "bug"
Then: 
  - Set issue type to "Bug"
  - Set priority to "High"
  - Add label "needs-triage"
  - Assign to QA lead
```

**시나리오 2: 스프린트 완료 자동화**
```
When: Sprint ends
Then:
  - Move incomplete issues to next sprint
  - Create sprint report
  - Notify team in Slack
```

**시나리오 3: PR 생성 시 알림**
```
GitHub Actions:
When: Pull request opened
Then:
  - Create GitHub issue in project
  - Move to "In Review" column
  - Assign reviewers
  - Post in Slack channel
```

---

## 💼 6. 실습 과제

### 과제 1: GitHub Projects 설정

**시나리오**: 블로그 플랫폼 개발 프로젝트

**과제**:
1. GitHub 저장소 생성 (공개 또는 비공개)
2. Project 보드 생성 (Kanban 템플릿)
3. 컬럼 설정: Backlog → To Do → In Progress → Review → Done
4. 이슈 10개 생성 (기능 5개, 버그 3개, 문서 2개)
5. 라벨 생성 (frontend, backend, bug, feature)
6. 마일스톤 2개 생성 (MVP, v1.0)
7. 이슈를 마일스톤에 할당

**제출물**:
- GitHub Project 보드 URL
- 스크린샷 (보드 전체 뷰)
- 설정한 워크플로우 설명 (1페이지)

### 과제 2: Trello 보드 운영

**시나리오**: 마케팅 캠페인 관리

**과제**:
1. Trello 보드 생성 ("SNS 마케팅 캠페인")
2. 리스트 설정: Ideas → Planning → In Progress → Published
3. 카드 15개 생성 (블로그 5개, 인스타 5개, 유튜브 5개)
4. 각 카드에 체크리스트, 담당자, 마감일 설정
5. 라벨 5개 생성 (Content Type, Priority 등)
6. Power-Up 1개 추가 (Calendar 권장)
7. Butler 자동화 규칙 2개 생성

**제출물**:
- Trello 보드 URL (공개 설정)
- 스크린샷 (보드 + Calendar)
- Butler 자동화 규칙 설명

### 과제 3: 도구 비교 분석

**과제**:
자신의 프로젝트 또는 팀 상황을 고려하여 Jira, GitHub Projects, Trello 중 최적 도구 선택

**분석 항목**:
1. 팀 구성 (규모, 역할)
2. 프로젝트 특성 (개발, 비개발)
3. 예산
4. 기존 도구 (GitHub, Slack 등)
5. 필수 기능
6. 최종 추천 도구 및 이유

**제출물**:
- 비교 분석 보고서 (2-3페이지)
- 선정 도구로 샘플 보드 생성
- 향후 활용 계획

---

## 🎯 7. 자가 점검 퀴즈

### 객관식 문제

**1. GitHub Projects에서 이슈를 자동으로 닫는 커밋 메시지는?**
- A) fixes #123
- B) closes #123
- C) resolves #123
- D) 모두 가능

**정답**: D  
**해설**: fixes, closes, resolves 모두 이슈를 자동으로 닫습니다.

---

**2. Trello 무료 버전에서 사용 가능한 Power-Up 개수는?**
- A) 제한 없음
- B) 보드당 1개
- C) 보드당 3개
- D) 보드당 5개

**정답**: B  
**해설**: Trello 무료 버전은 보드당 1개의 Power-Up만 사용 가능합니다.

---

**3. WIP 제한의 주요 목적은?**
- A) 작업 속도 향상
- B) 병목 현상 조기 발견
- C) 문서 작성 강제
- D) 팀원 평가

**정답**: B  
**해설**: WIP 제한은 진행 중인 작업을 제한하여 병목 현상을 조기에 발견하고 흐름을 최적화합니다.

---

**4. 소규모 개발팀(5명)에게 가장 적합한 무료 도구는?**
- A) Jira
- B) GitHub Projects
- C) Monday.com
- D) ServiceNow

**정답**: B  
**해설**: 소규모 개발팀에게는 GitHub Projects가 무료이면서 코드 연동이 강력합니다.

---

**5. 칸반 보드의 기본 컬럼 구성은?**
- A) Backlog → To Do → Done
- B) To Do → Doing → Done
- C) Plan → Execute → Close
- D) New → Active → Resolved

**정답**: B  
**해설**: 칸반 보드의 가장 기본적인 구성은 To Do → Doing → Done입니다.

---

### 서술형 문제

**6. GitHub Projects와 Trello의 차이점을 3가지 이상 설명하시오.**

**모범 답안**:
1. **연동**: GitHub Projects는 GitHub 생태계와 네이티브 연동, Trello는 플러그인 필요
2. **대상 사용자**: GitHub Projects는 개발자 중심, Trello는 누구나 쉽게 사용
3. **기능 복잡도**: GitHub Projects는 단순, Trello는 Power-Ups로 확장 가능
4. **가격**: GitHub Projects는 공개 저장소 무료, Trello는 Power-Up 제한 있는 무료

---

**7. 칸반 보드에서 WIP 제한을 설정하는 이유와 방법을 설명하시오.**

**모범 답안**:

**이유**:
- 멀티태스킹 감소로 집중력 향상
- 병목 현상 조기 발견
- 사이클 타임 단축
- 품질 향상

**방법**:
- Jira: 컬럼 설정에서 Max 값 설정
- Trello: List Limits Power-Up 사용 또는 수동 관리
- 예: "In Progress (3/5)" - 현재 3개, 최대 5개

---

**8. PM 도구 선택 시 고려해야 할 5가지 기준을 설명하시오.**

**모범 답안**:
1. **팀 규모**: 소규모는 간단한 도구, 대규모는 강력한 도구
2. **예산**: 무료 vs 유료, ROI 고려
3. **프로젝트 특성**: 개발 프로젝트는 코드 연동 중요
4. **학습 곡선**: 팀의 기술 수준 고려
5. **통합**: 기존 사용 중인 도구(Slack, GitHub 등)와 연동
6. **필수 기능**: 자동화, 보고서, 커스터마이징 등

---

**9. Trello Butler 자동화의 3가지 활용 예시를 작성하시오.**

**모범 답안**:
1. **체크리스트 완료 시 자동 이동**
   ```
   When all items in checklist are completed
   → Move card to "Done" list
   ```

2. **마감일 자동 설정**
   ```
   When card is added to "This Week"
   → Set due date to Friday 5PM
   ```

3. **담당자 배정 시 알림**
   ```
   When member is added
   → Post comment "@{member} assigned"
   ```

---

**10. 애자일 보드의 컬럼 구성을 개발팀과 마케팅팀에 맞게 각각 설계하시오.**

**모범 답안**:

**개발팀**:
```
Backlog → Sprint Backlog → In Progress → Code Review → QA → Staging → Production
```
- 코드 리뷰 단계 명시적 포함
- QA 단계 분리
- 스테이징 환경 확인 단계

**마케팅팀**:
```
Ideas → Planning → In Progress → Review → Scheduled → Published
```
- 아이디어 수집 단계
- 스케줄링 단계 (발행 예정)
- 발행 후 분석은 별도 보드

---

## 📚 8. 핵심 용어 정리

| 한글 | 영문 | 설명 |
|-----|------|------|
| 이슈 | Issue | 작업, 버그, 기능 요청 등 |
| 라벨 | Label | 분류 태그 |
| 마일스톤 | Milestone | 주요 단계 또는 릴리즈 |
| 풀 리퀘스트 | Pull Request | 코드 변경 요청 |
| 칸반 보드 | Kanban Board | 작업 흐름 시각화 보드 |
| WIP | Work In Progress | 진행 중인 작업 |
| 자동화 | Automation | 반복 작업 자동 처리 |
| 파워업 | Power-Up | Trello 확장 기능 |
| 버틀러 | Butler | Trello 자동화 봇 |
| 스윔레인 | Swimlane | 보드의 수평 구분선 |

---

## 🎓 다음 주 예고

**Week 11-12: 모의 프로젝트**

다음 2주 동안은 실제 프로젝트를 팀으로 진행합니다:
- 팀 구성 (4-5명)
- 프로젝트 헌장 작성
- WBS 및 일정 계획
- 스프린트 실행
- PM 도구 활용 (Week 10 학습 내용)
- 최종 발표 및 평가

**사전 준비**:
- 프로젝트 아이디어 3개 준비
- 팀원 희망 역할 생각해오기
- PM 도구 선택 (Jira/GitHub/Trello)

---

## 📖 추천 학습 자료

### 공식 문서
- GitHub Projects: https://docs.github.com/en/issues/planning-and-tracking-with-projects
- Trello Guide: https://trello.com/guide
- Jira Documentation: https://www.atlassian.com/software/jira/guides

### 추천 도서
- "Making Work Visible" - Dominica DeGrandis (칸반)
- "Personal Kanban" - Jim Benson

### 유용한 도구
- **Notion**: 문서 + 프로젝트 관리 통합
- **Linear**: 개발팀 특화 이슈 추적
- **Asana**: 범용 프로젝트 관리
- **Monday.com**: 시각적 워크플로우

---

**강의 자료 버전**: 1.0  
**최종 업데이트**: 2026년 1월  
**작성자**: PM Expert Training Team

**다음 과제**: Week 10 실습 과제 (제출 기한: Week 11 수업 전)
