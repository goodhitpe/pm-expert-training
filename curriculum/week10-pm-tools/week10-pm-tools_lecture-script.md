# Week 10: PM 도구 활용 - 강의 스크립트 (Lecture Script)

> **강의 시간**: 6.0시간 (이론 2.0h + 실습 3.5h + Q&A 0.5h)  
> **강의 방식**: 도구 데모 + 실습 중심 + 프로젝트 구축

---

## 📋 강의 개요

### 학습 목표
- 주요 PM 도구의 특징 및 선택 기준 이해
- Jira를 활용한 애자일 프로젝트 관리 실습
- MS Project를 활용한 전통적 프로젝트 관리 실습
- 협업 도구를 활용한 팀 커뮤니케이션

### 준비물
- 강의 자료: [week10-pm-tools_README.md](./week10-pm-tools_README.md)
- 참고 자료: [week10-pm-tools_detailed-lecture-materials.md](./week10-pm-tools_detailed-lecture-materials.md)
- 필수: **노트북** (학습자 각자)
- 계정: Jira Cloud 계정 (무료), Trello 계정
- 설치: MS Project 또는 ProjectLibre (무료 대안)

---

## 🕐 시간별 강의 진행 (총 6.0시간)

### [00:00-00:15] 도입 (15분)

**강의 포인트**:
```
👋 환영 인사 및 주제 소개
"안녕하세요. Week 10 PM 도구 활용 시간입니다."
"오늘은 이론이 아니라 100% 실습입니다!"

💻 오늘의 특별함
"노트북을 열고 직접 따라 하세요.
오늘 끝나면 여러분은 Jira, Trello, MS Project를 
실무에서 바로 사용할 수 있습니다!"

📌 오늘 학습 목표
1. Jira로 스크럼 프로젝트 만들기
2. Trello로 칸반 보드 구성하기
3. MS Project로 간트 차트 작성하기
4. 실전 프로젝트에 바로 적용

⚙️ 사전 준비 확인
"모두 노트북 준비되었나요?"
"Jira 계정 만드셨나요? (안 만들었으면 지금!)"
"인터넷 연결 확인!"

💡 오늘의 학습 방식
- 강사가 화면 공유하며 시연
- 학습자가 따라서 실습
- 막히면 손들고 질문
- 진도 느린 분은 조교/이웃 도움

🎯 최종 결과물
"오늘 끝나면 여러분은:
✅ Jira 스크럼 보드 1개
✅ Trello 칸반 보드 1개
✅ MS Project 프로젝트 계획 1개
를 가지고 집에 갑니다!"
```

---

### [00:15-01:30] 섹션 1: PM 도구 개요 (75분)

#### [00:15-00:45] 1.1 PM 도구 소개 및 선택 기준 (30분)

**강의 내용**:
```
🛠️ PM 도구란?

정의: 프로젝트 계획, 실행, 모니터링을 지원하는 소프트웨어

필요성:
❌ 엑셀만으로는 한계
- 버전 관리 어려움
- 실시간 협업 불가
- 자동화 부족
- 시각화 제한

✅ PM 도구 장점
- 중앙화된 정보
- 실시간 협업
- 자동 보고서
- 진척도 시각화
- 알림 및 리마인더

📊 PM 도구 분류

1️⃣ 애자일 중심 도구

**Jira** ⭐ (가장 인기)
- Atlassian 제공
- 스크럼/칸반 특화
- 소프트웨어 개발팀 표준
- 강력한 커스터마이징
- 가격: $0~$100/user/month

장점:
✅ 강력한 기능
✅ 광범위한 통합
✅ 확장성

단점:
❌ 학습 곡선 높음
❌ 복잡할 수 있음
❌ 비용 (대규모 팀)

**Trello**
- 간단하고 직관적
- 칸반 보드 기반
- 소규모 팀 적합
- 무료 플랜 관대
- 가격: $0~$17.50/user/month

장점:
✅ 사용 쉬움
✅ 시각적
✅ 무료로도 충분

단점:
❌ 대규모 프로젝트엔 부족
❌ 고급 기능 제한
❌ 보고 기능 약함

**Azure DevOps**
- Microsoft 제공
- 개발 전체 라이프사이클
- Git 통합
- 가격: $0~$52/user/month

2️⃣ 전통적 방법론 도구

**MS Project**
- Microsoft 제공
- 간트 차트 강력
- 자원 관리 우수
- 엔터프라이즈 표준
- 가격: $10~$55/user/month

장점:
✅ 강력한 스케줄링
✅ 자원 평준화
✅ 상세한 보고서

단점:
❌ 비용
❌ 복잡함
❌ 애자일 부적합

**Primavera P6**
- Oracle 제공
- 건설/엔지니어링 특화
- 매우 상세한 계획
- 가격: 고가

3️⃣ 하이브리드 도구

**Monday.com**
- 시각적이고 유연
- 다양한 뷰 (칸반, 간트, 타임라인)
- No-code 자동화
- 가격: $8~$16/user/month

**Asana**
- 태스크 관리 중심
- 깔끔한 UI
- 협업 기능 강력
- 가격: $0~$24.99/user/month

**Notion**
- All-in-one 워크스페이스
- 문서 + 프로젝트 관리
- 커스터마이징 자유
- 가격: $0~$18/user/month

🎯 도구 선택 기준

6가지 고려사항:

1️⃣ 프로젝트 방법론
```
애자일 → Jira, Trello, Azure DevOps
전통적 → MS Project, Primavera
하이브리드 → Monday, Asana
```

2️⃣ 팀 규모
```
소규모 (5명 이하) → Trello, Asana
중규모 (5-20명) → Jira, Monday
대규모 (20명+) → Jira, MS Project, Azure DevOps
```

3️⃣ 복잡도
```
단순 → Trello
중간 → Asana, Monday
복잡 → Jira, MS Project
```

4️⃣ 예산
```
무료 → Trello, Asana (기본), Jira (소규모)
저가 → Monday, Asana
고가 → MS Project, Jira (대규모)
```

5️⃣ 통합 요구사항
```
개발 도구 통합 → Jira (Git, Jenkins)
Microsoft 생태계 → MS Project, Azure DevOps
범용 통합 → Monday, Asana
```

6️⃣ 학습 곡선
```
쉬움 → Trello
중간 → Asana, Monday
어려움 → Jira, MS Project
```

📊 비교표 (화이트보드에 그리기)

도구        │방법론│규모│복잡도│가격│학습
───────────┼──────┼────┼──────┼────┼────
Jira       │애자일│대  │높음  │중  │높음
Trello     │애자일│소  │낮음  │저  │낮음
MS Project │전통적│대  │높음  │중  │높음
Monday     │하이브리드│중│중간│중 │중간
Asana      │하이브리드│중│중간│중 │중간

💡 실무 팁:
"도구는 만능이 아닙니다.
팀과 프로젝트에 맞는 것을 선택하세요.
복잡한 도구보다 팀이 잘 쓰는 도구가 최고입니다!"

📌 오늘 실습할 도구:
1. Jira (애자일 대표)
2. Trello (간단한 칸반)
3. MS Project (전통적 대표)

💬 질문: "여러분 팀/회사는 어떤 도구를 쓰나요?"
(경험 공유)
```

**교수법**:
- 각 도구의 스크린샷 보여주기
- 비교표로 명확한 차이 시각화
- 실제 사용 사례 공유
- 선택 기준 체크리스트 제공

#### [00:45-01:30] 1.2 Jira 기본 개념 (45분)

**강의 내용**:
```
🎯 Jira 핵심 개념 이해

"실습 전에 개념을 명확히!"

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

1️⃣ 프로젝트 (Project)

정의: 작업을 담는 최상위 컨테이너

프로젝트 유형:
- **스크럼**: 스프린트 기반, 백로그 관리
- **칸반**: 연속 흐름, WIP 제한
- **버그 추적**: 이슈 관리 중심
- **프로젝트 관리**: 범용

프로젝트 키:
```
예: PROJ (모든 이슈에 PROJ-1, PROJ-2... 붙음)
```

2️⃣ 이슈 (Issue)

정의: 작업 단위 (가장 중요!)

이슈 유형:
- **Epic**: 큰 기능 묶음 (1-3개월)
  예: "사용자 인증 시스템"
  
- **Story**: 사용자 스토리 (1-2주)
  예: "사용자가 이메일로 로그인할 수 있다"
  
- **Task**: 일반 작업
  예: "데이터베이스 스키마 설계"
  
- **Bug**: 버그
  예: "로그인 시 오류 메시지 표시 안 됨"
  
- **Subtask**: 하위 작업
  예: "로그인 API 단위 테스트"

이슈 필드:
- Summary: 제목
- Description: 상세 설명
- Assignee: 담당자
- Reporter: 보고자
- Priority: 우선순위 (Highest~Lowest)
- Status: 상태
- Story Points: 크기 추정
- Labels: 태그
- Sprint: 소속 스프린트

3️⃣ 워크플로우 (Workflow)

정의: 이슈가 거치는 상태 흐름

기본 워크플로우:
```
To Do → In Progress → Done
```

상세 워크플로우:
```
Backlog → Selected for Dev → In Progress 
  → Code Review → Testing → Done
```

상태 설명:
- **To Do**: 착수 전
- **In Progress**: 작업 중
- **Code Review**: 코드 리뷰 대기
- **Testing**: 테스트 중
- **Done**: 완료

전환 (Transition):
- Start Progress: To Do → In Progress
- Resolve: In Progress → Done
- Reopen: Done → To Do

4️⃣ 보드 (Board)

정의: 이슈를 시각화하는 뷰

스크럼 보드:
- 스프린트 단위
- 백로그 + 활성 스프린트
- 번다운 차트

칸반 보드:
- 연속적 흐름
- WIP 제한 가능
- 누적 흐름 다이어그램

보드 구조:
```
┌─────────┬─────────────┬──────────┬──────┐
│ To Do   │ In Progress │ Review   │ Done │
├─────────┼─────────────┼──────────┼──────┤
│ PROJ-5  │ PROJ-3      │ PROJ-2   │ PROJ-1│
│ PROJ-7  │ PROJ-4      │          │      │
│ PROJ-9  │             │          │      │
└─────────┴─────────────┴──────────┴──────┘
```

5️⃣ 백로그 (Backlog)

정의: 우선순위화된 이슈 목록

2가지 백로그:
- **Product Backlog**: 전체 이슈
- **Sprint Backlog**: 스프린트 선정 이슈

백로그 관리:
- 드래그 앤 드롭으로 우선순위 조정
- Epic으로 그룹화
- 필터 및 정렬

6️⃣ 스프린트 (Sprint)

정의: 고정된 기간 (보통 2주)

스프린트 생명주기:
```
생성 → 이슈 추가 → 시작 → 진행 → 완료
```

스프린트 정보:
- Name: "Sprint 1", "2024-W03"
- Duration: 2 weeks
- Start Date: 2024-01-15
- End Date: 2024-01-29
- Goal: 스프린트 목표

7️⃣ 리포트 (Reports)

스크럼 리포트:
- **Burndown Chart**: 남은 작업량
- **Velocity Chart**: 스프린트별 완료 포인트
- **Sprint Report**: 스프린트 요약

칸반 리포트:
- **Cumulative Flow Diagram**: 누적 흐름
- **Control Chart**: 사이클 타임
- **Lead Time**: 리드 타임

8️⃣ 필터 및 JQL

필터: 이슈 검색 조건 저장

JQL (Jira Query Language):
```
project = PROJ AND status = "In Progress"
assignee = currentUser() AND sprint = "Sprint 1"
priority = Highest AND duedate < now()
```

예시:
```
나에게 할당된 진행 중 이슈:
assignee = currentUser() AND status = "In Progress"

이번 스프린트의 버그:
sprint = currentSprint() AND type = Bug

긴급 + 미완료:
priority = Highest AND status != Done
```

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

💡 Jira 사용 흐름 (스크럼)

1. 프로젝트 생성
2. Epic 생성 (큰 기능)
3. Story 생성 (사용자 스토리)
4. Backlog에서 우선순위 조정
5. Sprint 생성 및 이슈 추가
6. Sprint 시작
7. 일일 스크럼 (보드에서 이슈 이동)
8. Sprint 종료
9. 리포트 확인
10. 회고 후 다음 Sprint

💬 질문 받기:
"개념이 헷갈리는 부분 있나요?"
(질문 답변)

🎯 다음 순서:
"이제 직접 만들어봅시다!"
```

**교수법**:
- 화이트보드에 개념 다이어그램
- 실제 Jira 화면 스크린샷 공유
- 용어를 명확히 정의
- 흐름도로 전체 프로세스 시각화

---

### [01:30-01:45] 휴식 (15분) ☕

---

### [01:45-03:30] 섹션 2: Jira 실습 (105분)

**활동 내용**:
```
💻 Jira 핸즈온 실습

"이제부터는 100% 실습입니다!"
"강사 화면을 보면서 똑같이 따라 하세요"
"진도가 느린 분은 손들어주세요"

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

🎯 실습 목표:
"모바일 쇼핑몰 앱" 프로젝트를 Jira로 관리

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

📝 실습 1: 프로젝트 생성 (15분)

Step 1: Jira 로그인
1. https://www.atlassian.com/software/jira 접속
2. "Get it free" 클릭
3. 이메일로 계정 생성 (무료)
4. Site 이름: "yourname-training"

Step 2: 프로젝트 생성
1. 좌측 상단 "Create project" 클릭
2. "Scrum" 선택
3. Template: "Scrum" 선택
4. Project name: "Mobile Shopping App"
5. Key: "SHOP" (자동 생성, 수정 가능)
6. "Create" 클릭

결과 확인:
✅ 프로젝트가 생성됨
✅ 기본 백로그가 표시됨
✅ Sample 이슈가 있음 (삭제 가능)

💡 강사 순회: 모두 생성했는지 확인

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

📝 실습 2: Epic 및 Story 생성 (20분)

Step 1: Sample 이슈 삭제
1. Backlog 메뉴 클릭
2. 기존 이슈 선택 → 더보기 → Delete

Step 2: Epic 생성
1. Backlog에서 "Create epic" 클릭
2. Epic name: "사용자 인증"
3. Summary: "사용자 로그인, 회원가입, 비밀번호 재설정"
4. "Create" 클릭

같은 방법으로 Epic 3개 더:
- "상품 관리"
- "장바구니 & 결제"
- "주문 관리"

Step 3: Story 생성 (Epic: 사용자 인증)
1. Backlog에서 "Create issue" 클릭
2. Issue type: Story
3. Summary: "사용자가 이메일로 로그인할 수 있다"
4. Description:
```
As a 쇼핑몰 고객,
I want 이메일과 비밀번호로 로그인하고 싶다,
So that 나만의 장바구니와 주문 내역을 볼 수 있다.

Acceptance Criteria:
- 이메일과 비밀번호 입력 필드
- 로그인 버튼 클릭 시 인증
- 성공 시 홈 화면 이동
- 실패 시 오류 메시지
```
5. Epic Link: "사용자 인증"
6. Story Points: 5
7. "Create" 클릭

같은 방법으로 Story 5개 더 생성:

Story 2 (사용자 인증):
- "사용자가 회원가입할 수 있다" (8pt)

Story 3 (사용자 인증):
- "사용자가 비밀번호를 재설정할 수 있다" (3pt)

Story 4 (상품 관리):
- "사용자가 상품을 검색할 수 있다" (5pt)

Story 5 (상품 관리):
- "사용자가 상품 상세 정보를 볼 수 있다" (3pt)

Story 6 (장바구니 & 결제):
- "사용자가 장바구니에 상품을 담을 수 있다" (5pt)

Step 4: 백로그 우선순위 조정
1. Backlog에서 드래그 앤 드롭
2. 순서: 로그인 → 회원가입 → 상품 검색 → 상품 상세 → ...

결과 확인:
✅ Epic 4개
✅ Story 6개
✅ 우선순위 정렬됨

💡 강사: "모두 완료했나요? 손들어주세요"

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

📝 실습 3: 스프린트 계획 (15분)

Step 1: 스프린트 생성
1. Backlog 상단 "Create sprint" 클릭
2. Sprint name: "Sprint 1" (기본값)

Step 2: 스프린트에 이슈 추가
1. Story 3개를 드래그하여 Sprint 1로:
   - 사용자가 이메일로 로그인할 수 있다
   - 사용자가 회원가입할 수 있다
   - 사용자가 상품을 검색할 수 있다

2. 총 Story Points 확인: 5 + 8 + 5 = 18

Step 3: 스프린트 시작
1. Sprint 1 옆 "Start sprint" 클릭
2. Duration: 2 weeks
3. Start date: 오늘
4. Sprint goal: "사용자 인증 및 기본 검색 기능 완성"
5. "Start" 클릭

결과 확인:
✅ Sprint가 "Active" 상태
✅ Board에 선택한 이슈가 표시됨

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

📝 실습 4: 보드에서 작업 (20분)

Step 1: 보드 구조 이해
1. "Board" 메뉴 클릭
2. 컬럼 확인:
   - To Do
   - In Progress
   - Done

Step 2: 이슈 할당
1. SHOP-1 (로그인) 클릭
2. Assignee: "Assign to me"
3. Close

Step 3: 작업 시작
1. SHOP-1을 "To Do"에서 "In Progress"로 드래그
2. 상태가 변경됨 확인

Step 4: Subtask 추가
1. SHOP-1 클릭
2. "Add a subtask"
3. Summary: "로그인 API 개발"
4. Estimate: 8h
5. 같은 방법으로 Subtask 3개 더:
   - "로그인 UI 개발" (5h)
   - "단위 테스트" (3h)
   - "통합 테스트" (2h)

Step 5: Subtask 진행
1. "로그인 API 개발" → "In Progress"
2. "로그인 UI 개발" → "In Progress"
3. "로그인 API 개발" → "Done"

Step 6: 댓글 추가
1. SHOP-1 클릭
2. Comment: "API 개발 완료. UI 진행 중."
3. "Save"

Step 7: 다른 이슈도 진행
1. SHOP-2 (회원가입) → "In Progress"
2. SHOP-3 (검색) → "To Do" (아직 착수 안 함)

결과:
```
To Do        │ In Progress      │ Done
────────────┼──────────────────┼──────
SHOP-3 검색  │ SHOP-1 로그인     │
            │ SHOP-2 회원가입   │
```

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

📝 실습 5: 리포트 확인 (15분)

Step 1: Burndown Chart
1. 좌측 "Reports" → "Burndown Chart"
2. 그래프 확인:
   - Guideline (이상적 진행)
   - 실제 남은 Story Points
3. 해석 방법 설명

Step 2: Sprint 완료 시뮬레이션
1. Board로 돌아가기
2. SHOP-1 → "Done"으로 드래그
3. SHOP-2 → "Done"으로 드래그
4. Burndown Chart 다시 확인
   → Story Points 감소 확인

Step 3: Sprint Report
1. "Reports" → "Sprint Report"
2. Committed vs Completed 확인
3. 완료/미완료 이슈 목록

Step 4: Velocity Chart (Sprint 종료 후)
1. Board → "Complete sprint" 클릭
2. 미완료 이슈 처리 선택
3. "Complete" 클릭
4. "Reports" → "Velocity Chart"
5. Sprint 1 완료 포인트 확인

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

📝 실습 6: 필터 및 JQL (15분)

Step 1: 간단한 필터
1. 상단 검색창 클릭
2. "View all issues"
3. 필터 옵션:
   - Assignee: Me
   - Status: In Progress
4. 결과 확인

Step 2: JQL 사용
1. "Advanced" 버튼 클릭
2. JQL 작성:
```
project = SHOP AND status = "In Progress"
```
3. "Search" 클릭

Step 3: 더 복잡한 JQL
```
# 나에게 할당된 미완료 이슈
assignee = currentUser() AND status != Done

# 긴급 + 이번 스프린트
priority = Highest AND sprint in openSprints()

# 이번 주 생성된 버그
type = Bug AND created >= startOfWeek()
```

Step 4: 필터 저장
1. "Save as" 클릭
2. Name: "내 작업 중 이슈"
3. "Submit"
4. 좌측 메뉴에서 필터 확인

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

📝 실습 7: 대시보드 (5분)

Step 1: 대시보드 생성
1. 상단 "Dashboards" → "Create dashboard"
2. Name: "Sprint 대시보드"
3. "Create"

Step 2: 가젯 추가
1. "Add gadget"
2. 선택:
   - Sprint Burndown Chart
   - Filter Results (내 작업 중 이슈)
   - Pie Chart (이슈 상태별)
3. 배치 조정

결과:
✅ 한 화면에 주요 정보 표시
✅ 실시간 업데이트

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

🎉 실습 완료!

최종 확인:
✅ 프로젝트 "Mobile Shopping App" 생성
✅ Epic 4개, Story 6개 생성
✅ Sprint 1 시작 및 이슈 진행
✅ Burndown Chart 확인
✅ 필터 및 JQL 사용
✅ 대시보드 생성

💡 과제:
"여러분의 실제 프로젝트를 Jira에 만들어보세요!"
```

**교수법**:
- 화면 공유하며 단계별 시연
- 학습자가 동시에 따라 하기
- 각 단계마다 완료 확인
- 막히는 학습자 즉시 도움
- 중간중간 결과 확인 시간

---

### [03:30-03:45] 휴식 (15분) ☕

---

### [03:45-04:45] 섹션 3: Trello & MS Project 실습 (60분)

#### [03:45-04:15] 3.1 Trello 실습 (30분)

**활동 내용**:
```
📋 Trello 빠르게 익히기

특징: Jira보다 훨씬 간단!

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

Step 1: 계정 생성 및 로그인 (5분)
1. https://trello.com 접속
2. "Sign up" → 이메일로 가입
3. 로그인

Step 2: 보드 생성 (5분)
1. "Create new board" 클릭
2. Board name: "마케팅 캠페인"
3. Background: 색상 또는 이미지 선택
4. "Create board"

Step 3: 리스트 생성 (5분)
기본 리스트 3개:
- "To Do"
- "In Progress"
- "Done"

추가 리스트 2개:
1. "Add a list" 클릭
2. Name: "Ideas"
3. 같은 방법으로 "Blocked"

최종 구조:
```
Ideas│To Do│In Progress│Blocked│Done
```

Step 4: 카드 생성 (10분)
1. "To Do" 리스트에 "Add a card"
2. Card name: "SNS 광고 콘텐츠 제작"
3. "Add card"

카드에 상세 정보 추가:
1. 카드 클릭
2. Description: "인스타그램, 페이스북용 이미지 3종"
3. Checklist 추가: "Add checklist"
   - [ ] 디자인 시안
   - [ ] 내부 검토
   - [ ] 최종 승인
4. Due date: 1주일 후
5. Members: 담당자 할당
6. Labels: "디자인", "긴급"
7. Attachment: 파일 첨부 가능

같은 방법으로 카드 5개 더:
- "블로그 포스트 작성" (To Do)
- "이메일 뉴스레터" (In Progress)
- "유튜브 영상 촬영" (To Do)
- "광고 예산 승인 대기" (Blocked)
- "1월 캠페인 결과 분석" (Done)

Step 5: 카드 이동 (5분)
1. 드래그 앤 드롭으로 카드 이동
2. "SNS 광고 콘텐츠 제작" → "In Progress"
3. "이메일 뉴스레터" → "Done"

Step 6: Power-Ups (보너스)
1. 상단 "Power-Ups" 클릭
2. "Calendar" 추가
   → 카드를 캘린더뷰로 확인
3. "Card Aging" 추가
   → 오래된 카드 시각적 표시

결과:
✅ 간단하고 시각적인 작업 관리
✅ 팀 협업 가능
✅ 모바일 앱도 편리

💡 Trello 활용 팁:
- 소규모 프로젝트, 간단한 작업에 적합
- 개인 To-Do 리스트로도 훌륭
- 보드 템플릿 활용 (Project Management, Kanban)
```

#### [04:15-04:45] 3.2 MS Project 실습 (30분)

**활동 내용**:
```
📊 MS Project 기본 사용법

참고: MS Project 없으면 ProjectLibre (무료) 사용

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

Step 1: 프로그램 열기 (5분)
1. MS Project 실행
2. "Blank Project" 선택
3. Project Information 설정:
   - Start date: 오늘
   - Finish date: (자동 계산)

Step 2: 작업 입력 (10분)
Gantt Chart 뷰에서:

ID│Task Name           │Duration│Start    │Finish
──┼────────────────────┼────────┼─────────┼─────────
1 │프로젝트 계획        │5 days  │1/15     │1/19
2 │요구사항 분석        │10 days │1/22     │2/2
3 │설계                │15 days │2/5      │2/23
4 │개발                │30 days │2/26     │4/5
5 │테스트              │10 days │4/8      │4/19
6 │배포                │3 days  │4/22     │4/24

입력 방법:
1. Task Name 셀에 작업명 입력
2. Duration 셀에 기간 입력
3. Enter → 다음 행

Step 3: 작업 관계 설정 (5분)
선행 관계 (Predecessor) 설정:
1. Task 2 (요구사항) → Predecessor: 1 (계획)
2. Task 3 (설계) → Predecessor: 2
3. Task 4 (개발) → Predecessor: 3
4. Task 5 (테스트) → Predecessor: 4
5. Task 6 (배포) → Predecessor: 5

결과: Gantt Chart에서 자동으로 일정 조정됨

Step 4: 자원 할당 (5분)
1. "Resource Sheet" 뷰로 전환
2. 자원 입력:
   - PM (Type: Work, 비용: 100만원/월)
   - 개발자 (Type: Work, 비용: 80만원/월)
   - 디자이너 (Type: Work, 비용: 70만원/월)
   - QA (Type: Work, 비용: 60만원/월)

3. Gantt Chart 뷰로 돌아가기
4. 자원 할당:
   - 계획: PM 100%
   - 요구사항: PM 50%, 개발자 50%
   - 설계: 개발자 100%, 디자이너 100%
   - 개발: 개발자 100%
   - 테스트: QA 100%
   - 배포: PM 50%, 개발자 50%

Step 5: 마일스톤 추가 (5분)
1. Task 7 추가: "요구사항 승인"
2. Duration: 0 days
3. Predecessor: 2
4. → 다이아몬드 모양 표시 (마일스톤)

같은 방법으로:
- "설계 승인" (after Task 3)
- "개발 완료" (after Task 4)
- "프로젝트 완료" (after Task 6)

Step 6: 보고서 생성 (보너스)
1. "Report" 탭 → "Project Overview"
2. 자동 생성된 요약 보고서 확인
3. "Export" → PDF로 저장

결과:
✅ 간트 차트 완성
✅ 자원 할당됨
✅ 전체 일정 시각화

💡 MS Project 활용 팁:
- 대규모 프로젝트, 복잡한 일정에 적합
- 자원 평준화 기능 강력
- 전통적 방법론 프로젝트에 최적
```

**교수법**:
- Trello는 빠르게 (30분)
- MS Project는 핵심만 (30분)
- 두 도구의 차이 강조
- 학습자 속도에 맞춰 조절

---

### [04:45-05:30] 섹션 4: 통합 실습 및 비교 (45분)

**활동 내용**:
```
🎯 프로젝트별 최적 도구 선택 실습

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

📝 시나리오 기반 도구 선택 (30분)

시나리오 1: 스타트업 앱 개발
- 팀: 5명 (개발 3, 디자인 1, PM 1)
- 방법론: 애자일/스크럼
- 예산: 제한적
- 요구사항: 빠르게 변함

Q: 어떤 도구를 선택할까요?

소그룹 토론 (5분) 후 발표:
답: **Jira** 또는 **Trello**
이유:
✅ 애자일 지원
✅ 소규모 팀 적합
✅ 저렴 (Trello 무료, Jira 소규모 무료)
✅ 빠른 변경 대응

시나리오 2: 건설 프로젝트 IT 시스템
- 팀: 30명
- 방법론: 전통적 (폭포수)
- 기간: 18개월
- 요구사항: 명확, 고정
- 자원: 복잡한 배치

Q: 어떤 도구?

답: **MS Project**
이유:
✅ 전통적 방법론 지원
✅ 복잡한 일정 관리
✅ 자원 평준화
✅ 상세한 간트 차트

시나리오 3: 마케팅 캠페인
- 팀: 3명
- 복잡도: 낮음
- 협업: 중요
- 시각화: 필요

Q: 어떤 도구?

답: **Trello**
이유:
✅ 간단하고 직관적
✅ 시각적
✅ 빠른 설정
✅ 무료

시나리오 4: 대기업 IT 전환 프로젝트
- 팀: 100명 (여러 팀)
- 방법론: 하이브리드
- 통합: 다양한 시스템 연동 필요
- 보고: 경영진 보고 중요

Q: 어떤 도구?

답: **Jira** + **Confluence** 또는 **Azure DevOps**
이유:
✅ 확장성
✅ 강력한 통합
✅ 고급 리포팅
✅ 여러 팀 조율

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

📊 도구 비교 요약 (15분)

화이트보드에 요약 표:

상황              │ 추천 도구
─────────────────┼──────────────────
애자일 소규모     │ Trello
애자일 대규모     │ Jira
전통적 방법론     │ MS Project
하이브리드        │ Monday, Asana
개발자 중심       │ Jira + GitHub
간단한 협업       │ Trello
복잡한 일정       │ MS Project
대기업 표준       │ Jira, MS Project

💡 최종 조언:
"완벽한 도구는 없습니다.
팀이 편하게 쓸 수 있는 도구가 최고입니다.
복잡한 도구를 50% 쓰는 것보다
간단한 도구를 100% 쓰는 게 낫습니다!"

🎯 도구 도입 로드맵:
1. 팀 니즈 파악
2. 2-3개 도구 후보 선정
3. 무료 플랜으로 2주 파일럿
4. 팀 피드백 수집
5. 최종 선택 및 도입
6. 교육 및 온보딩
7. 지속적 개선
```

---

### [05:30-06:00] 마무리 및 Q&A (30분)

**강의 포인트**:
```
📝 오늘 배운 내용 정리

1️⃣ PM 도구 선택 기준
   - 방법론, 팀 규모, 복잡도, 예산, 통합

2️⃣ Jira 실습
   - 프로젝트 생성
   - Epic, Story, Sprint
   - 보드 관리
   - 리포트 확인

3️⃣ Trello 실습
   - 간단한 칸반 보드
   - 카드 관리

4️⃣ MS Project 실습
   - 간트 차트
   - 자원 할당

💡 핵심 메시지:
"도구는 수단이지 목적이 아닙니다.
프로젝트 성공이 목적, 도구는 그걸 돕는 것입니다.
팀에 맞는 도구를 선택하고, 꾸준히 사용하세요!"

🎯 실무 적용 팁:
✅ 무료 플랜으로 시작
✅ 작은 프로젝트로 연습
✅ 팀 전체가 함께 배우기
✅ 도구 도입 시 충분한 교육
✅ 템플릿 활용 (시간 절약)

❓ Q&A (15분)

자주 하는 질문:

Q1: "Jira vs Trello, 어느 게 나은가요?"
A: 상황에 따라. 복잡하면 Jira, 간단하면 Trello.

Q2: "MS Project가 너무 비싼데요?"
A: ProjectLibre (무료), Smartsheet 등 대안 있음.

Q3: "팀원들이 도구 사용을 거부하면?"
A: 점진적 도입. 먼저 PM만 사용 → 일부 기능만 → 확대.

Q4: "도구를 자주 바꿔도 되나요?"
A: 가급적 피하되, 정말 안 맞으면 바꾸기. 데이터 마이그레이션 고려.

Q5: "여러 도구를 함께 써도 되나요?"
A: 네! 예: Jira (프로젝트) + Slack (소통) + Confluence (문서).

🎓 추가 학습 자료:
- Jira 공식 튜토리얼: atlassian.com/software/jira/guides
- Trello 가이드: trello.com/guide
- MS Project 교육: Microsoft Learn
- PM 도구 비교 사이트: capterra.com, g2.com

📚 과제 안내:
1. Jira에 실제 프로젝트 만들기 (최소 3개 Sprint)
2. Trello로 개인 To-Do 관리 시작
3. 도구 비교 레포트 (A4 1장)

🎉 코스 전체 마무리 (5분)

10주간 배운 내용:
Week 1: PM의 이해
Week 2: PM 기본 원리
Week 3: 이해관계자 관리
Week 4: 범위 관리
Week 5: 일정 관리
Week 6: 원가 관리
Week 7: 품질 & 리스크 관리
Week 8: 자원 & 조달 관리
Week 9: 애자일/스크럼
Week 10: PM 도구 (오늘!)

💡 최종 메시지:
"10주 동안 정말 수고 많으셨습니다!
이제 여러분은 PM의 전체 지식과 도구를 가졌습니다.
실전에서 많이 적용해보세요.
경험이 최고의 스승입니다!

프로젝트 매니저로서의 여정을 응원합니다! 🎉"

📸 기념 사진 (선택)
- 수료증 수여
- 단체 사진

👏 마무리 인사:
"10주간 함께해주셔서 감사합니다!
앞으로의 프로젝트에서 행운을 빕니다!"
```

---

## 📌 강의 Tips

### 강사 준비사항
- [ ] **필수**: 학습자 노트북 사전 확인
- [ ] Jira Cloud 계정 (시연용)
- [ ] Trello 계정
- [ ] MS Project 또는 ProjectLibre 설치
- [ ] 화면 공유 테스트 (프로젝터 + 개인 화면)
- [ ] 백업 계정 (학습자 계정 문제 시)
- [ ] 실습 단계별 체크리스트 인쇄
- [ ] 조교 또는 보조 강사 (큰 클래스)

### 교수법 포인트
- 💻 **실습 중심**: 이론 최소, 실습 최대
- 👀 **화면 공유**: 큰 화면으로 단계별 시연
- 🐢 **속도 조절**: 가장 느린 학습자에 맞추기
- 🙋 **질문 환영**: 막히면 즉시 도움
- 🔄 **반복 확인**: 각 단계마다 "완료했나요?"
- 📸 **스크린샷**: 중요 단계 화면 캡처 제공

### 자주 하는 질문
1. **Q: "계정 만들기가 안 돼요"**
   A: 이메일 확인, VPN 확인, 백업 계정 제공.

2. **Q: "MS Project가 없어요"**
   A: ProjectLibre (무료) 다운로드 안내.

3. **Q: "따라가기 힘들어요"**
   A: 이웃과 페어, 조교 도움, 휴식 시간 활용.

4. **Q: "실습 파일을 잃어버렸어요"**
   A: 클라우드라 괜찮음. 다시 로그인.

### 주의사항
- ⚠️ **기술 문제 대비**: 인터넷, 로그인 등
- ⚠️ **시간 관리**: 실습은 예상보다 오래 걸림
- ⚠️ **학습자 속도 차이**: 빠른 학습자에게 추가 과제
- ⚠️ **도구 버전**: UI 변경 가능성 (최신 화면 확인)
- ⚠️ **저장 확인**: 학습자가 작업 저장하도록 리마인드

### 트러블슈팅 가이드
- 로그인 안 됨 → 비밀번호 재설정, 다른 브라우저
- 느린 인터넷 → 모바일 핫스팟, 간단한 실습으로 대체
- 프로그램 크래시 → 재시작, 클라우드는 자동 저장됨
- 화면 공유 끊김 → 해상도 낮추기, 유선 연결

---

## 📖 참고 자료
- Jira 공식 문서: atlassian.com/software/jira/guides
- Trello 가이드: trello.com/guide
- MS Project 튜토리얼: Microsoft Learn
- ProjectLibre 다운로드: projectlibre.com
- PM 도구 비교: capterra.com/project-management-software

---

**강의 준비 체크리스트**
- [ ] 학습자 노트북 준비 확인 (사전 공지)
- [ ] 인터넷 연결 안정성 테스트
- [ ] 모든 계정 로그인 테스트
- [ ] 프로젝터 + 노트북 듀얼 화면 설정
- [ ] 실습 가이드 문서 (PDF) 준비
- [ ] 조교 또는 보조 인력 배치
- [ ] 백업 계획 (오프라인 실습 대안)
- [ ] 충전기, 인터넷 공유기 등 비상 장비
- [ ] 긴 시간이므로 간식 준비!
