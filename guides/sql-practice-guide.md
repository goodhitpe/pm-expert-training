# SQL 실습 환경 가이드 - PM을 위한 데이터베이스 실습

> **대상**: IT 비전공 PM 학습자  
> **소요 시간**: 1-1.5시간  
> **난이도**: 초급  
> **목적**: Week 14 데이터베이스 강의를 위한 SQL 실습 환경 구축

---

## 📚 이 가이드를 배워야 하는 이유

### PM에게 SQL이 중요한 이유

1. **데이터 기반 의사결정**
   - 프로젝트 지표 조회
   - 사용자 행동 분석
   - 성과 측정

2. **개발자와의 소통**
   - 데이터베이스 구조 이해
   - 데이터 요청 명확히 전달
   - 기술적 제약사항 파악

3. **요구사항 정의**
   - 데이터 모델 설계 참여
   - CRUD 기능 명세
   - 데이터 관계 이해

### 학습 목표

이 가이드를 완료하면:
- ✅ 온라인 SQL 에디터를 사용할 수 있습니다
- ✅ 기본 SQL 쿼리(SELECT, WHERE, JOIN)를 작성할 수 있습니다
- ✅ 샘플 데이터로 실습할 수 있습니다
- ✅ MySQL Workbench를 설치하고 사용할 수 있습니다 (선택)
- ✅ Week 14 과제를 수행할 준비가 됩니다

---

## 1️⃣ 온라인 SQL 에디터 사용하기 (권장)

가장 빠르고 쉬운 방법! 설치 없이 브라우저에서 바로 실습 가능합니다.

### Option 1: SQLite Online (추천) ⭐

**장점**:
- 설치 불필요
- 빠른 실행
- 샘플 데이터베이스 제공
- 무료

**사용 방법**:

1. **웹사이트 접속**: https://sqliteonline.com
2. 좌측 상단 **File** > **Open DB** 클릭
3. 샘플 데이터베이스 선택 (또는 새로 생성)
4. SQL 쿼리 입력창에 코드 작성
5. **Run** 버튼 클릭

**예제 쿼리**:
```sql
-- 테이블 생성
CREATE TABLE projects (
    id INTEGER PRIMARY KEY,
    name TEXT NOT NULL,
    status TEXT,
    budget INTEGER,
    start_date DATE
);

-- 데이터 입력
INSERT INTO projects (name, status, budget, start_date) VALUES 
('모바일 앱 개발', '진행중', 50000000, '2025-01-01'),
('웹사이트 리뉴얼', '완료', 30000000, '2024-10-01'),
('AI 챗봇 구축', '계획', 80000000, '2025-03-01');

-- 데이터 조회
SELECT * FROM projects;

-- 조건부 조회
SELECT name, budget 
FROM projects 
WHERE status = '진행중';

-- 정렬
SELECT * FROM projects 
ORDER BY budget DESC;
```

### Option 2: DB Fiddle

**웹사이트**: https://www.db-fiddle.com

**특징**:
- MySQL, PostgreSQL, SQLite 지원
- 스키마와 쿼리 분리
- 결과 공유 가능 (URL 생성)

**사용 방법**:
1. 웹사이트 접속
2. 좌측 **Schema SQL**: 테이블 생성 코드
3. 우측 **Query SQL**: SELECT 쿼리
4. **Run** 버튼으로 실행

### Option 3: SQL Try Editor (W3Schools)

**웹사이트**: https://www.w3schools.com/sql/trysql.asp?filename=trysql_select_all

**특징**:
- 기본 제공 샘플 데이터베이스 (Customers, Products 등)
- 초보자 친화적
- 즉시 실행 가능

---

## 2️⃣ 샘플 데이터베이스 만들기

### PM 프로젝트 관리 데이터베이스

Week 14 강의에 맞춰 프로젝트 관리 시나리오로 실습합니다.

#### 테이블 1: projects (프로젝트)

```sql
CREATE TABLE projects (
    project_id INTEGER PRIMARY KEY AUTOINCREMENT,
    project_name TEXT NOT NULL,
    client_name TEXT,
    status TEXT CHECK(status IN ('계획', '진행중', '완료', '보류')),
    budget INTEGER,
    start_date DATE,
    end_date DATE,
    pm_id INTEGER
);
```

#### 테이블 2: team_members (팀원)

```sql
CREATE TABLE team_members (
    member_id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    role TEXT,
    email TEXT UNIQUE,
    hire_date DATE
);
```

#### 테이블 3: tasks (작업)

```sql
CREATE TABLE tasks (
    task_id INTEGER PRIMARY KEY AUTOINCREMENT,
    task_name TEXT NOT NULL,
    project_id INTEGER,
    assigned_to INTEGER,
    status TEXT CHECK(status IN ('미착수', '진행중', '완료')),
    priority TEXT CHECK(priority IN ('낮음', '보통', '높음', '긴급')),
    due_date DATE,
    FOREIGN KEY (project_id) REFERENCES projects(project_id),
    FOREIGN KEY (assigned_to) REFERENCES team_members(member_id)
);
```

#### 샘플 데이터 입력

```sql
-- 팀원 데이터
INSERT INTO team_members (name, role, email, hire_date) VALUES
('김철수', 'PM', 'kim@company.com', '2023-01-15'),
('이영희', '개발자', 'lee@company.com', '2023-03-01'),
('박민수', '디자이너', 'park@company.com', '2023-05-10'),
('정수진', 'QA', 'jung@company.com', '2023-07-01');

-- 프로젝트 데이터
INSERT INTO projects (project_name, client_name, status, budget, start_date, end_date, pm_id) VALUES
('모바일 앱 개발', 'A사', '진행중', 50000000, '2025-01-01', '2025-06-30', 1),
('웹사이트 리뉴얼', 'B사', '완료', 30000000, '2024-10-01', '2024-12-31', 1),
('AI 챗봇 구축', 'C사', '계획', 80000000, '2025-03-01', '2025-09-30', 1);

-- 작업 데이터
INSERT INTO tasks (task_name, project_id, assigned_to, status, priority, due_date) VALUES
('요구사항 분석', 1, 1, '완료', '높음', '2025-01-15'),
('UI/UX 디자인', 1, 3, '진행중', '높음', '2025-02-15'),
('로그인 기능 개발', 1, 2, '진행중', '보통', '2025-02-28'),
('테스트 시나리오 작성', 1, 4, '미착수', '보통', '2025-03-15');
```

---

## 3️⃣ 필수 SQL 쿼리 10개 실습

### 1. 전체 데이터 조회 (SELECT *)

```sql
-- 모든 프로젝트 조회
SELECT * FROM projects;

-- 모든 팀원 조회
SELECT * FROM team_members;

-- 결과: 모든 열과 모든 행 반환
```

### 2. 특정 열만 조회 (SELECT 열이름)

```sql
-- 프로젝트 이름과 예산만 조회
SELECT project_name, budget FROM projects;

-- PM 관점: 필요한 정보만 보기
```

### 3. 조건부 조회 (WHERE)

```sql
-- 진행 중인 프로젝트만 조회
SELECT * FROM projects 
WHERE status = '진행중';

-- 예산 5천만원 이상 프로젝트
SELECT project_name, budget 
FROM projects 
WHERE budget >= 50000000;

-- 여러 조건 (AND)
SELECT * FROM tasks 
WHERE status = '진행중' AND priority = '높음';

-- 또는 조건 (OR)
SELECT * FROM tasks 
WHERE priority = '높음' OR priority = '긴급';
```

### 4. 정렬 (ORDER BY)

```sql
-- 예산 높은 순으로 정렬
SELECT project_name, budget 
FROM projects 
ORDER BY budget DESC;

-- 마감일 빠른 순으로 정렬
SELECT task_name, due_date 
FROM tasks 
ORDER BY due_date ASC;

-- 여러 열로 정렬
SELECT * FROM tasks 
ORDER BY priority DESC, due_date ASC;
```

### 5. 개수 세기 (COUNT)

```sql
-- 전체 프로젝트 개수
SELECT COUNT(*) AS total_projects FROM projects;

-- 진행 중인 작업 개수
SELECT COUNT(*) AS ongoing_tasks 
FROM tasks 
WHERE status = '진행중';

-- 상태별 프로젝트 개수
SELECT status, COUNT(*) AS count 
FROM projects 
GROUP BY status;
```

### 6. 합계 및 평균 (SUM, AVG)

```sql
-- 전체 프로젝트 예산 합계
SELECT SUM(budget) AS total_budget FROM projects;

-- 평균 예산
SELECT AVG(budget) AS avg_budget FROM projects;

-- 상태별 평균 예산
SELECT status, AVG(budget) AS avg_budget 
FROM projects 
GROUP BY status;
```

### 7. 최대/최소값 (MAX, MIN)

```sql
-- 가장 큰 예산
SELECT MAX(budget) AS max_budget FROM projects;

-- 가장 빠른 마감일
SELECT MIN(due_date) AS earliest_due FROM tasks;
```

### 8. 테이블 조인 (JOIN)

```sql
-- 작업과 담당자 정보 함께 조회
SELECT 
    t.task_name,
    t.status,
    t.priority,
    m.name AS assigned_member,
    m.role
FROM tasks t
JOIN team_members m ON t.assigned_to = m.member_id;

-- 프로젝트의 모든 작업 조회
SELECT 
    p.project_name,
    t.task_name,
    t.status,
    t.due_date
FROM projects p
JOIN tasks t ON p.project_id = t.project_id
WHERE p.status = '진행중';
```

### 9. 그룹화 (GROUP BY)

```sql
-- 팀원별 할당된 작업 개수
SELECT 
    m.name,
    COUNT(t.task_id) AS task_count
FROM team_members m
LEFT JOIN tasks t ON m.member_id = t.assigned_to
GROUP BY m.member_id, m.name;

-- 프로젝트별 작업 개수와 완료율
SELECT 
    p.project_name,
    COUNT(t.task_id) AS total_tasks,
    SUM(CASE WHEN t.status = '완료' THEN 1 ELSE 0 END) AS completed_tasks,
    ROUND(SUM(CASE WHEN t.status = '완료' THEN 1 ELSE 0 END) * 100.0 / COUNT(t.task_id), 2) AS completion_rate
FROM projects p
LEFT JOIN tasks t ON p.project_id = t.project_id
GROUP BY p.project_id, p.project_name;
```

### 10. 서브쿼리 (Subquery)

```sql
-- 평균 예산보다 높은 프로젝트
SELECT project_name, budget 
FROM projects 
WHERE budget > (SELECT AVG(budget) FROM projects);

-- 가장 많은 작업이 할당된 팀원
SELECT name, 
    (SELECT COUNT(*) FROM tasks WHERE assigned_to = team_members.member_id) AS task_count
FROM team_members
ORDER BY task_count DESC;
```

---

## 4️⃣ PM을 위한 실전 쿼리

### 대시보드 데이터 조회

```sql
-- 프로젝트 현황 요약
SELECT 
    status,
    COUNT(*) AS project_count,
    SUM(budget) AS total_budget,
    AVG(budget) AS avg_budget
FROM projects
GROUP BY status;

-- 이번 달 마감 작업
SELECT 
    t.task_name,
    p.project_name,
    m.name AS assigned_to,
    t.due_date,
    t.priority
FROM tasks t
JOIN projects p ON t.project_id = p.project_id
JOIN team_members m ON t.assigned_to = m.member_id
WHERE t.due_date BETWEEN '2025-02-01' AND '2025-02-28'
    AND t.status != '완료'
ORDER BY t.due_date;
```

### 위험 작업 식별

```sql
-- 긴급 미완료 작업
SELECT 
    p.project_name,
    t.task_name,
    m.name AS assigned_to,
    t.due_date,
    CASE 
        WHEN t.due_date < DATE('now') THEN '지연'
        WHEN t.due_date = DATE('now') THEN '오늘 마감'
        ELSE '정상'
    END AS status_flag
FROM tasks t
JOIN projects p ON t.project_id = p.project_id
JOIN team_members m ON t.assigned_to = m.member_id
WHERE t.status != '완료'
    AND t.priority IN ('높음', '긴급')
ORDER BY t.due_date;
```

### 팀 생산성 분석

```sql
-- 팀원별 완료 작업 비율
SELECT 
    m.name,
    m.role,
    COUNT(t.task_id) AS total_tasks,
    SUM(CASE WHEN t.status = '완료' THEN 1 ELSE 0 END) AS completed,
    ROUND(SUM(CASE WHEN t.status = '완료' THEN 1 ELSE 0 END) * 100.0 / 
          NULLIF(COUNT(t.task_id), 0), 2) AS completion_rate
FROM team_members m
LEFT JOIN tasks t ON m.member_id = t.assigned_to
GROUP BY m.member_id, m.name, m.role
ORDER BY completion_rate DESC;
```

---

## 5️⃣ MySQL Workbench 설치 (선택사항)

로컬 환경에서 더 강력한 기능을 원한다면 MySQL Workbench를 설치하세요.

### Step 1: MySQL 서버 설치

**Windows/Mac 공통**:

1. https://dev.mysql.com/downloads/mysql/ 접속
2. OS에 맞는 버전 다운로드
3. 설치 마법사 실행:
   - **Development Computer** 선택
   - Root 비밀번호 설정 (기억하기!)
   - 포트: 3306 (기본값)

### Step 2: MySQL Workbench 설치

1. https://dev.mysql.com/downloads/workbench/ 접속
2. OS에 맞는 버전 다운로드
3. 설치

### Step 3: 연결 설정

1. MySQL Workbench 실행
2. **+** 버튼으로 새 연결 추가:
   ```
   Connection Name: Local MySQL
   Hostname: localhost
   Port: 3306
   Username: root
   Password: (설치 시 설정한 비밀번호)
   ```
3. **Test Connection** 클릭하여 확인
4. **OK** 클릭

### Step 4: 데이터베이스 생성

```sql
-- 새 데이터베이스 생성
CREATE DATABASE pm_practice;

-- 데이터베이스 선택
USE pm_practice;

-- 앞서 만든 테이블 생성 및 데이터 입력
-- (위의 샘플 데이터베이스 코드 실행)
```

---

## 6️⃣ SQL 학습 로드맵

### 단계별 학습

```
1주차: 기본 조회 (SELECT, WHERE, ORDER BY)
    ↓
2주차: 집계 함수 (COUNT, SUM, AVG, GROUP BY)
    ↓
3주차: 조인 (INNER JOIN, LEFT JOIN)
    ↓
4주차: 고급 기능 (서브쿼리, CASE문)
```

### Week 14 과제 준비

Week 14 강의에서 다룰 내용:
- ✅ ERD (Entity-Relationship Diagram) 이해
- ✅ 정규화 (1NF, 2NF, 3NF)
- ✅ 트랜잭션 (ACID)
- ✅ 인덱스 및 성능 최적화

**과제 미리보기**:
1. 프로젝트 관리 ERD 설계
2. 샘플 데이터베이스 구축
3. 10개 이상 SQL 쿼리 작성
4. 성능 분석 및 개선안

---

## ✅ 체크리스트

학습을 완료했는지 확인하세요:

- [ ] 온라인 SQL 에디터를 사용할 수 있다
- [ ] 샘플 데이터베이스를 생성했다
- [ ] SELECT 문으로 데이터를 조회할 수 있다
- [ ] WHERE 절로 조건을 지정할 수 있다
- [ ] ORDER BY로 정렬할 수 있다
- [ ] COUNT, SUM, AVG 함수를 사용할 수 있다
- [ ] GROUP BY로 그룹화할 수 있다
- [ ] JOIN으로 여러 테이블을 조회할 수 있다
- [ ] 10개 필수 쿼리를 모두 실행해봤다
- [ ] PM 실전 쿼리를 이해했다
- [ ] (선택) MySQL Workbench를 설치했다

---

## 📚 추가 학습 자료

### 무료 온라인 강의
- [생활코딩 SQL](https://opentutorials.org/course/3884) - 한글, 무료
- [SQLBolt](https://sqlbolt.com) - 인터랙티브 튜토리얼
- [W3Schools SQL](https://www.w3schools.com/sql/) - 영문, 예제 풍부

### 연습 사이트
- [HackerRank SQL](https://www.hackerrank.com/domains/sql) - 문제 풀이
- [LeetCode Database](https://leetcode.com/problemset/database/) - 실전 문제
- [SQLZoo](https://sqlzoo.net) - 단계별 학습

### 참고 도서
- "SQL 첫걸음" - 이지스퍼블리싱
- "모두의 SQL" - 길벗

---

## 💬 자주 묻는 질문 (FAQ)

### Q1: SQL과 MySQL의 차이는?

**A**: 
- **SQL**: 데이터베이스 언어 (표준)
- **MySQL**: SQL을 사용하는 데이터베이스 소프트웨어 (구현체)

### Q2: PM이 SQL을 얼마나 깊이 알아야 하나?

**A**: 
- **필수**: SELECT, WHERE, JOIN, COUNT, SUM
- **권장**: GROUP BY, 서브쿼리
- **선택**: 복잡한 최적화, 인덱싱

### Q3: 어떤 데이터베이스를 배워야 하나?

**A**: 
- **MySQL**: 가장 널리 사용
- **PostgreSQL**: 고급 기능
- **SQLite**: 가볍고 간단
→ 기본 SQL은 거의 동일하므로 하나만 익히면 나머지도 쉽게 배울 수 있습니다.

### Q4: 실무에서 PM이 직접 SQL을 작성하나?

**A**: 
- 작은 회사: 직접 작성하는 경우 많음
- 큰 회사: 데이터 분석가/엔지니어에게 요청
- **핵심**: SQL을 알아야 정확한 요청 가능

### Q5: 데이터베이스 설계는 누가 하나?

**A**: 
- **초기 설계**: 개발자 + DBA
- **PM 역할**: 요구사항 명확히 전달, 데이터 모델 검토
- **협업이 중요**: ERD를 읽고 이해할 수 있어야 함

---

## 🎯 마무리

축하합니다! SQL 실습 환경을 완벽히 준비했습니다.

### 다음 단계

1. **Week 14 강의** 듣기 전에 이 가이드로 실습
2. **10개 필수 쿼리** 모두 직접 실행해보기
3. **Week 14 과제**에서 배운 내용 적용

### 기억하세요

✅ SQL은 데이터와 대화하는 언어입니다  
✅ 처음에는 어렵지만 반복하면 익숙해집니다  
✅ PM으로서 SQL을 알면 의사결정이 빨라집니다  
✅ 실습이 가장 중요합니다 - 지금 바로 시작하세요!

---

**작성일**: 2025년 2월 8일  
**버전**: 1.0  
**대상**: PM Expert 교육과정 Week 14 학습자  

**문의**: SQL 관련 질문은 Q&A 게시판에 올려주세요!

---

> 🚀 **데이터는 진실을 말합니다!**
> 
> SQL을 배우면 감이 아닌 데이터로 말할 수 있습니다.
> PM의 가장 강력한 무기가 될 수 있습니다.
> 
> **Happy Querying!** 💪
