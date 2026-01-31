# Week 10 퀴즈: PM 도구 활용

> **제한 시간**: 25분  
> **총 문항**: 객관식 10문제  
> **배점**: 각 10점, 총 100점  
> **합격 기준**: 60점 이상

---

## 📋 객관식 문제 (10문제)

### 문제 1
**질문**: Jira에서 이슈 유형의 계층 구조로 **올바른** 것은?

A) Epic > Task > Story > Subtask  
B) Story > Epic > Task > Subtask  
C) Epic > Story > Task > Subtask  
D) Task > Epic > Story > Subtask

**정답**: C

**해설**: Jira의 이슈 계층 구조는 Epic(큰 단위 작업) > Story/Task(중간 단위) > Subtask(세부 작업)입니다. Epic은 여러 스토리를 포함하는 큰 기능 단위이고, Story는 사용자 관점의 요구사항, Task는 기술적 작업, Subtask는 Story나 Task의 하위 작업입니다.

**관련 학습 내용**: Week 10 > Jira 핵심 개념 > 이슈

---

### 문제 2
**질문**: Jira의 스크럼 보드와 칸반 보드의 차이로 **올바른** 것은?

A) 스크럼 보드는 연속적 흐름, 칸반 보드는 스프린트 기반  
B) 스크럼 보드는 스프린트 기반, 칸반 보드는 연속적 흐름  
C) 둘 다 스프린트 기반이다  
D) 둘 다 연속적 흐름이다

**정답**: B

**해설**: Jira의 스크럼 보드는 스프린트를 기반으로 작업을 관리하며 스프린트 시작/종료가 명확합니다. 칸반 보드는 연속적 흐름으로 작업을 관리하며 스프린트 개념이 없고 WIP(Work In Progress) 제한을 통해 흐름을 최적화합니다.

**관련 학습 내용**: Week 10 > Jira 핵심 개념 > 보드

---

### 문제 3
**질문**: Trello의 3가지 주요 구성 요소로 **올바른** 것은?

A) Epic, Story, Task  
B) Board, List, Card  
C) Project, Sprint, Backlog  
D) Workspace, Dashboard, Report

**정답**: B

**해설**: Trello는 Board(프로젝트/팀 단위), List(작업 단계, 예: To Do, Doing, Done), Card(작업 항목)의 3가지 구성 요소로 이루어져 있습니다. 간단하고 직관적인 칸반 기반 도구로 소규모 팀에 적합합니다.

**관련 학습 내용**: Week 10 > Trello 구조

---

### 문제 4
**질문**: MS Project에서 **크리티컬 패스(Critical Path)**를 확인하는 방법은?

A) File → Options → Critical Tasks  
B) View → Gantt Chart → Baseline  
C) Format → Critical Tasks 체크  
D) Project → Set Baseline

**정답**: C

**해설**: MS Project에서 크리티컬 패스를 확인하려면 Gantt Chart 뷰에서 Format 탭의 Critical Tasks를 체크하면 크리티컬 패스에 속한 작업이 빨간색으로 표시됩니다. 크리티컬 패스는 프로젝트 완료에 가장 오래 걸리는 경로로, 이 경로의 지연은 전체 프로젝트 지연으로 이어집니다.

**관련 학습 내용**: Week 10 > MS Project 실습 > 크리티컬 패스 확인

---

### 문제 5
**질문**: PM 도구 선택 시 고려해야 할 기준이 **아닌** 것은?

A) 프로젝트 방법론 (애자일 vs 전통적)  
B) 팀 규모  
C) 팀원들의 선호 색상  
D) 다른 시스템과의 통합 요구사항

**정답**: C

**해설**: PM 도구 선택 시 고려 기준은 1) 프로젝트 방법론, 2) 팀 규모, 3) 프로젝트 복잡도, 4) 예산, 5) 통합 요구사항, 6) 사용자 친화성(학습 곡선) 등입니다. 팀원들의 선호 색상은 도구 선택 기준과 무관한 주관적 취향입니다.

**관련 학습 내용**: Week 10 > 도구 선택 기준

---

### 문제 6
**질문**: JQL(Jira Query Language)의 예시로 **올바른** 것은?

A) SELECT * FROM issues WHERE status = 'In Progress'  
B) project = PROJ AND status = "In Progress"  
C) GET /issues?status=in_progress  
D) FIND issues WITH status IN_PROGRESS

**정답**: B

**해설**: JQL은 Jira의 검색 언어로 "필드 = 값" 형식을 사용합니다. 예를 들어 `project = PROJ AND status = "In Progress"`는 PROJ 프로젝트의 진행 중인 이슈를 검색합니다. SQL이나 REST API 형식과는 다른 Jira 고유의 문법을 사용합니다.

**관련 학습 내용**: Week 10 > Jira 유용한 기능 > 필터

---

### 문제 7
**질문**: MS Project에서 작업 간 의존 관계 유형이 **아닌** 것은?

A) FS (Finish to Start)  
B) SS (Start to Start)  
C) FF (Finish to Finish)  
D) DD (Duration to Duration)

**정답**: D

**해설**: MS Project의 4가지 의존 관계 유형은 1) FS(Finish to Start): 선행 작업 완료 후 시작, 2) SS(Start to Start): 동시 시작, 3) FF(Finish to Finish): 동시 완료, 4) SF(Start to Finish): 선행 작업 시작 후 완료입니다. DD는 존재하지 않는 의존 관계 유형입니다.

**관련 학습 내용**: Week 10 > MS Project 핵심 기능 > 의존 관계

---

### 문제 8
**질문**: Trello의 Power-Up에 **해당하지 않는** 것은?

A) Calendar (달력 뷰)  
B) Card Aging (오래된 카드 시각화)  
C) Custom Fields (추가 필드)  
D) Git Commit (코드 커밋 기능)

**정답**: D

**해설**: Trello Power-Up은 Trello의 기능을 확장하는 애드온입니다. Calendar, Card Aging, Custom Fields는 대표적인 Power-Up입니다. Git Commit은 Jira, GitHub, Bitbucket 등의 개발 도구 통합 기능이며 Trello의 기본 Power-Up은 아닙니다. (GitHub Power-Up을 통해 간접 연동은 가능)

**관련 학습 내용**: Week 10 > Trello 활용 팁 > 파워업

---

### 문제 9
**질문**: 애자일 프로젝트에 **가장 적합한** PM 도구 조합은?

A) MS Project + SharePoint  
B) Jira + Confluence + Slack  
C) Excel + PowerPoint  
D) Primavera P6 + MS Teams

**정답**: B

**해설**: 애자일 프로젝트에는 Jira(작업 관리) + Confluence(문서화) + Slack(커뮤니케이션)의 조합이 가장 적합합니다. Jira는 애자일 특화 도구이고, Confluence는 위키 형태로 문서를 관리하며, Slack은 빠른 커뮤니케이션을 지원합니다. MS Project와 Primavera P6는 전통적 방법론에 적합합니다.

**관련 학습 내용**: Week 10 > 도구 통합 전략

---

### 문제 10
**질문**: 대규모 복잡한 건설 프로젝트에 **가장 적합한** 도구는?

A) Trello  
B) Notion  
C) MS Project 또는 Primavera P6  
D) Jira

**정답**: C

**해설**: 대규모 복잡한 프로젝트(건설, 제조 등)에는 MS Project나 Primavera P6 같은 전통적 PM 도구가 적합합니다. 이들은 복잡한 의존 관계, 자원 관리, Gantt 차트, 크리티컬 패스 분석 등을 지원합니다. Trello와 Notion은 소규모 프로젝트에, Jira는 소프트웨어 개발의 애자일 프로젝트에 적합합니다.

**관련 학습 내용**: Week 10 > 도구 선택 기준

---

## 📊 채점 기준

| 점수 | 등급 | 평가 |
|------|------|------|
| 90-100 | A | 탁월: PM 도구의 특징과 활용법을 완벽히 이해했습니다. |
| 80-89 | B | 우수: 대부분의 도구를 잘 이해했습니다. |
| 70-79 | C | 보통: Jira, Trello, MS Project 특징 복습이 필요합니다. |
| 60-69 | D | 부족: Week 10 자료를 다시 복습하세요. |
| 0-59 | F | 미흡: 각 도구의 기본 개념부터 재학습이 필요합니다. |

---

## 📚 복습이 필요한 경우

### 60점 미만인 경우
1. Week 10 강의 자료 전체 재학습
2. Jira, Trello, MS Project의 핵심 기능 정리
3. 각 도구의 적합한 사용 사례 학습
4. 실습 과제 1(Jira 프로젝트 생성) 수행

### 60-79점인 경우
1. 틀린 문제의 관련 학습 내용 복습
2. Jira 이슈 계층 구조 정리
3. 실습 과제 3(도구 비교 분석) 수행
4. 스크럼 보드 vs 칸반 보드 차이 명확히 이해

### 80점 이상인 경우
1. Jira 무료 계정 생성 및 실습
2. MS Project 또는 ProjectLibre 설치 및 연습
3. 실제 프로젝트에 적합한 도구 조합 설계

---

## 🔗 참고 자료

### 필수 복습 자료
- Week 10 강의 자료: `curriculum/week10-pm-tools/README.md`
- Jira Documentation: https://support.atlassian.com/jira-software-cloud/
- Trello Guide: https://trello.com/guide

### 추천 학습 자료
- Microsoft Project Help: https://support.microsoft.com/project
- ProjectLibre (무료 대체): https://www.projectlibre.com/
- Jira 무료 계정: https://www.atlassian.com/software/jira/free

### 실습 환경
- Jira Free: 10명까지 무료
- Trello: 기본 기능 무료
- ProjectLibre: MS Project 무료 대체

---

## 💬 질문 및 피드백

- **Slack 채널**: #week10-quiz
- **이메일**: [강사 이메일]
- **오피스 아워**: 매주 수요일, 금요일 16:00-17:00

---

**퀴즈 버전**: 1.0  
**작성일**: 2025년 2월 7일  
**작성자**: PM 강사진  
**난이도**: 기본 7문제 + 응용 3문제
