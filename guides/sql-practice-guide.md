# 🗄️ SQL 실습 환경 가이드

> **학습 시간**: 60-90분  
> **난이도**: 초급  
> **목적**: PM이 데이터베이스를 이해하고 기본 SQL 쿼리를 실행할 수 있도록 실습 환경 구축

---

## 📚 목차

1. [SQL과 데이터베이스 기초](#1-sql과-데이터베이스-기초)
2. [온라인 SQL 에디터 (추천)](#2-온라인-sql-에디터-추천)
3. [SQLite Online 실습](#3-sqlite-online-실습)
4. [MySQL Workbench 설치 (선택)](#4-mysql-workbench-설치-선택)
5. [샘플 데이터베이스 구축](#5-샘플-데이터베이스-구축)
6. [기본 SQL 쿼리 10선](#6-기본-sql-쿼리-10선)
7. [PM을 위한 SQL 활용 팁](#7-pm을-위한-sql-활용-팁)
8. [실습 문제](#8-실습-문제)

---

## 1. SQL과 데이터베이스 기초

### 1.1 SQL이란?

**SQL (Structured Query Language)**:
- 데이터베이스와 소통하는 표준 언어
- 데이터 조회, 삽입, 수정, 삭제
- 발음: "에스큐엘" 또는 "시퀄"
- 1970년대 IBM에서 개발

**SQL의 주요 카테고리**:
```
DQL (Data Query Language)
  - SELECT: 데이터 조회

DML (Data Manipulation Language)
  - INSERT: 데이터 삽입
  - UPDATE: 데이터 수정
  - DELETE: 데이터 삭제

DDL (Data Definition Language)
  - CREATE: 테이블 생성
  - ALTER: 테이블 구조 변경
  - DROP: 테이블 삭제

DCL (Data Control Language)
  - GRANT: 권한 부여
  - REVOKE: 권한 회수
```

### 1.2 관계형 데이터베이스 (RDBMS)

**주요 개념**:
- **테이블 (Table)**: 데이터를 저장하는 표 형태 구조
- **행 (Row)**: 레코드, 하나의 데이터 항목
- **열 (Column)**: 필드, 데이터 속성
- **기본 키 (Primary Key)**: 각 행을 고유하게 식별
- **외래 키 (Foreign Key)**: 다른 테이블과의 관계

**예시: 사용자 테이블**
```
users 테이블
+----+----------+------------------+-----+
| id | name     | email            | age |
+----+----------+------------------+-----+
| 1  | 김철수   | kim@example.com  | 30  |
| 2  | 이영희   | lee@example.com  | 25  |
| 3  | 박민수   | park@example.com | 28  |
+----+----------+------------------+-----+
```

### 1.3 PM이 SQL을 알아야 하는 이유

1. **데이터 기반 의사결정**
   - 프로젝트 메트릭 직접 조회
   - 사용자 행동 분석
   - 성능 모니터링

2. **개발자와 소통**
   - 데이터베이스 설계 리뷰
   - 성능 이슈 이해
   - 요구사항 명확히 전달

3. **프로젝트 범위 산정**
   - 데이터 마이그레이션 복잡도 파악
   - API 개발 공수 추정
   - 데이터 모델링 검토

4. **빠른 프로토타입**
   - 간단한 보고서 직접 작성
   - 데이터 품질 확인
   - 버그 재현 데이터 준비

### 1.4 PM이 알아야 할 SQL 범위

**필수 (80% 사용)**:
- ✅ SELECT (데이터 조회)
- ✅ WHERE (조건 필터링)
- ✅ JOIN (테이블 결합)
- ✅ GROUP BY (그룹화 및 집계)
- ✅ ORDER BY (정렬)

**권장 (15% 사용)**:
- ✅ INSERT (데이터 삽입)
- ✅ UPDATE (데이터 수정)
- ✅ DELETE (데이터 삭제)

**선택 (5% 사용)**:
- 🔸 CREATE TABLE (테이블 생성)
- 🔸 ALTER TABLE (테이블 수정)
- 🔸 INDEX (인덱스 생성)
- 🔸 복잡한 서브쿼리

---

## 2. 온라인 SQL 에디터 (추천)

### 2.1 왜 온라인 에디터인가?

**장점**:
- ✅ 설치 불필요 - 브라우저만 있으면 OK
- ✅ 즉시 시작 - 5분 안에 SQL 실습
- ✅ 무료 - 비용 없음
- ✅ 크로스 플랫폼 - Windows, Mac, Linux 모두 사용
- ✅ 안전 - 실수로 중요한 데이터 삭제 걱정 없음

**단점**:
- ❌ 인터넷 필요
- ❌ 대용량 데이터 처리 제한
- ❌ 고급 기능 제한

### 2.2 추천 온라인 SQL 에디터

#### 1순위: SQLite Online ⭐⭐⭐⭐⭐

**URL**: https://sqliteonline.com

**장점**:
- 간단한 UI
- 빠른 실행 속도
- 샘플 데이터베이스 제공
- 파일 import/export 가능

**사용 대상**:
- SQL 초보자
- 빠른 테스트가 필요한 경우
- Week 14 수업 실습

---

#### 2순위: DB Fiddle ⭐⭐⭐⭐

**URL**: https://www.db-fiddle.com

**장점**:
- 다양한 DB 지원 (MySQL, PostgreSQL, SQLite)
- 스키마와 쿼리 분리 UI
- URL 공유 기능 (팀 협업)

**사용 대상**:
- 다양한 DB 경험이 필요한 경우
- 쿼리 공유가 필요한 경우

---

#### 3순위: SQL Try Editor (W3Schools) ⭐⭐⭐

**URL**: https://www.w3schools.com/sql/trysql.asp?filename=trysql_select_all

**장점**:
- W3Schools의 튜토리얼과 통합
- 실습 예제 풍부
- 초보자 친화적

**사용 대상**:
- SQL을 처음 배우는 사람
- 단계별 튜토리얼을 선호하는 경우

---

#### 비교표

| 특징 | SQLite Online | DB Fiddle | SQL Try Editor |
|------|---------------|-----------|----------------|
| **설치** | 불필요 | 불필요 | 불필요 |
| **속도** | 빠름 | 보통 | 빠름 |
| **DB 종류** | SQLite | MySQL, PostgreSQL, SQLite | MySQL |
| **샘플 데이터** | ✅ | ❌ | ✅ |
| **공유 기능** | ❌ | ✅ | ❌ |
| **초보자 친화** | ⭐⭐⭐⭐⭐ | ⭐⭐⭐ | ⭐⭐⭐⭐⭐ |
| **추천 대상** | **모든 사용자** | 중급 이상 | 초급 |

---

## 3. SQLite Online 실습

### 3.1 시작하기

1. **웹사이트 방문**
   - URL: https://sqliteonline.com
   - 브라우저: Chrome, Firefox, Safari 모두 가능

2. **화면 구성 이해**
   ```
   ┌─────────────────────────────────────────────┐
   │  SQLite Online                    [File][?] │
   ├──────────────┬──────────────────────────────┤
   │              │                              │
   │  Left Panel  │      SQL Editor              │
   │  (Tables)    │  (여기에 쿼리 작성)          │
   │              │                              │
   ├──────────────┴──────────────────────────────┤
   │  Results (쿼리 실행 결과)                   │
   └─────────────────────────────────────────────┘
   ```

3. **기본 사용법**
   - SQL 에디터에 쿼리 작성
   - 단축키: `Ctrl + Enter` (Windows) 또는 `Cmd + Enter` (Mac)
   - 또는 "Run" 버튼 클릭

### 3.2 첫 SQL 쿼리 실행

**Hello World 쿼리**:
```sql
-- 간단한 값 출력
SELECT 'Hello, SQL!' AS greeting;
```

**결과**:
```
+-------------+
| greeting    |
+-------------+
| Hello, SQL! |
+-------------+
```

**설명**:
- `SELECT`: 데이터를 조회하는 명령
- `'Hello, SQL!'`: 문자열 리터럴 (작은따옴표 사용)
- `AS greeting`: 컬럼 이름을 "greeting"으로 지정
- `;`: SQL 문장의 끝 (필수는 아니지만 권장)

**계산 쿼리**:
```sql
-- 간단한 계산
SELECT 
    2 + 3 AS addition,
    10 * 5 AS multiplication,
    100 / 4 AS division;
```

**결과**:
```
+----------+----------------+----------+
| addition | multiplication | division |
+----------+----------------+----------+
| 5        | 50             | 25       |
+----------+----------------+----------+
```

### 3.3 날짜와 시간 함수

```sql
-- 현재 날짜와 시간
SELECT 
    DATE('now') AS today,
    TIME('now') AS current_time,
    DATETIME('now') AS current_datetime;
```

**결과**:
```
+------------+--------------+---------------------+
| today      | current_time | current_datetime    |
+------------+--------------+---------------------+
| 2025-02-12 | 13:30:00     | 2025-02-12 13:30:00 |
+------------+--------------+---------------------+
```

---

## 4. MySQL Workbench 설치 (선택)

### 4.1 MySQL Workbench란?

**MySQL Workbench**:
- MySQL 공식 GUI 도구
- 데이터베이스 설계, 개발, 관리
- 무료 및 오픈소스
- Windows, Mac, Linux 지원

**언제 사용하나?**:
- 로컬 MySQL 서버가 있는 경우
- 회사 데이터베이스에 접속해야 하는 경우
- ER 다이어그램을 그려야 하는 경우
- 대용량 데이터 작업

### 4.2 설치 방법

#### Windows

1. **다운로드**
   - URL: https://dev.mysql.com/downloads/workbench/
   - "MySQL Installer for Windows" 선택
   - "No thanks, just start my download" 클릭

2. **설치**
   ```
   Step 1: 설치 파일 실행
   Step 2: "Developer Default" 또는 "Custom" 선택
   Step 3: MySQL Server + Workbench 선택
   Step 4: "Execute" 클릭하여 설치 진행
   Step 5: MySQL Server 비밀번호 설정 (기억할 것!)
   Step 6: 설치 완료
   ```

3. **Workbench 실행**
   - 시작 메뉴 > MySQL Workbench
   - Local instance 클릭
   - 비밀번호 입력

#### Mac

1. **Homebrew 사용 (권장)**
   ```bash
   # MySQL 설치
   brew install mysql
   
   # MySQL 서버 시작
   brew services start mysql
   
   # Workbench 설치
   brew install --cask mysqlworkbench
   ```

2. **또는 공식 설치 파일**
   - URL: https://dev.mysql.com/downloads/workbench/
   - macOS용 DMG 파일 다운로드
   - 설치 및 실행

### 4.3 첫 연결 설정

1. **새 연결 생성**
   - Workbench 실행
   - "MySQL Connections" 옆 "+" 아이콘 클릭

2. **연결 정보 입력**
   ```
   Connection Name: Local MySQL
   Connection Method: Standard (TCP/IP)
   Hostname: 127.0.0.1
   Port: 3306
   Username: root
   Password: [설치 시 설정한 비밀번호]
   ```

3. **"Test Connection" 클릭**
   - 성공: "Successfully made the MySQL connection" 메시지
   - 실패: 비밀번호 확인 또는 MySQL 서버 상태 확인

4. **"OK" 클릭하여 연결 저장**

### 4.4 Workbench 기본 사용법

**화면 구성**:
```
┌─────────────────────────────────────────────┐
│  Navigator                Query Editor       │
├──────────────┬──────────────────────────────┤
│ Schemas      │  SQL 쿼리 작성 영역          │
│ - Database1  │                              │
│   - Tables   │  SELECT * FROM users;        │
│   - Views    │                              │
├──────────────┴──────────────────────────────┤
│  Result Grid (쿼리 실행 결과)               │
└─────────────────────────────────────────────┘
```

**기본 단축키**:
- `Ctrl + Enter`: 현재 쿼리 실행
- `Ctrl + Shift + Enter`: 모든 쿼리 실행
- `Ctrl + /`: 주석 토글
- `Ctrl + Space`: 자동완성

---

## 5. 샘플 데이터베이스 구축

### 5.1 프로젝트 관리 샘플 데이터베이스

**시나리오**:
PM 교육 프로그램을 위한 간단한 프로젝트 관리 시스템

**테이블 구조**:
```
projects (프로젝트)
  - id: 프로젝트 ID
  - name: 프로젝트 이름
  - start_date: 시작일
  - end_date: 종료일
  - budget: 예산
  - status: 상태

team_members (팀 멤버)
  - id: 멤버 ID
  - name: 이름
  - role: 역할
  - email: 이메일
  - hire_date: 입사일

tasks (작업)
  - id: 작업 ID
  - project_id: 프로젝트 ID (외래 키)
  - title: 작업 제목
  - assignee_id: 담당자 ID (외래 키)
  - status: 상태
  - priority: 우선순위
  - due_date: 마감일
```

### 5.2 테이블 생성 SQL

**SQLite Online 또는 Workbench에서 실행**:

```sql
-- 1. 프로젝트 테이블 생성
CREATE TABLE projects (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    start_date DATE,
    end_date DATE,
    budget DECIMAL(10, 2),
    status TEXT CHECK(status IN ('Planning', 'In Progress', 'Completed', 'On Hold'))
);

-- 2. 팀 멤버 테이블 생성
CREATE TABLE team_members (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    role TEXT NOT NULL,
    email TEXT UNIQUE,
    hire_date DATE
);

-- 3. 작업 테이블 생성
CREATE TABLE tasks (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    project_id INTEGER,
    title TEXT NOT NULL,
    assignee_id INTEGER,
    status TEXT CHECK(status IN ('To Do', 'In Progress', 'Done')),
    priority TEXT CHECK(priority IN ('Low', 'Medium', 'High', 'Critical')),
    due_date DATE,
    FOREIGN KEY (project_id) REFERENCES projects(id),
    FOREIGN KEY (assignee_id) REFERENCES team_members(id)
);
```

### 5.3 샘플 데이터 삽입

```sql
-- 프로젝트 데이터 삽입
INSERT INTO projects (name, start_date, end_date, budget, status) VALUES
('AI 챗봇 개발', '2025-01-01', '2025-06-30', 50000000, 'In Progress'),
('모바일 앱 리뉴얼', '2025-02-01', '2025-05-31', 30000000, 'Planning'),
('ERP 시스템 구축', '2024-10-01', '2025-03-31', 100000000, 'In Progress'),
('웹사이트 개편', '2025-03-01', '2025-04-30', 20000000, 'Planning'),
('데이터 마이그레이션', '2024-12-01', '2025-01-31', 15000000, 'Completed');

-- 팀 멤버 데이터 삽입
INSERT INTO team_members (name, role, email, hire_date) VALUES
('김철수', 'Project Manager', 'kim@example.com', '2020-01-15'),
('이영희', 'Backend Developer', 'lee@example.com', '2021-03-10'),
('박민수', 'Frontend Developer', 'park@example.com', '2021-06-20'),
('최지은', 'Designer', 'choi@example.com', '2022-01-05'),
('정대호', 'QA Engineer', 'jung@example.com', '2022-04-12'),
('강미영', 'Data Analyst', 'kang@example.com', '2023-02-01');

-- 작업 데이터 삽입
INSERT INTO tasks (project_id, title, assignee_id, status, priority, due_date) VALUES
(1, 'API 설계 및 명세 작성', 2, 'Done', 'High', '2025-01-15'),
(1, '챗봇 모델 학습', 6, 'In Progress', 'Critical', '2025-02-28'),
(1, 'UI/UX 디자인', 4, 'Done', 'High', '2025-01-20'),
(1, '프론트엔드 개발', 3, 'In Progress', 'High', '2025-03-31'),
(1, '통합 테스트', 5, 'To Do', 'Medium', '2025-04-30'),
(2, '요구사항 분석', 1, 'In Progress', 'High', '2025-02-15'),
(2, '와이어프레임 작성', 4, 'To Do', 'High', '2025-02-20'),
(3, '데이터베이스 설계', 2, 'Done', 'Critical', '2024-11-30'),
(3, '모듈 개발', 2, 'In Progress', 'High', '2025-02-28'),
(3, '사용자 교육', 1, 'To Do', 'Medium', '2025-03-20'),
(4, '현행 시스템 분석', 1, 'To Do', 'High', '2025-03-05'),
(5, '데이터 정합성 검증', 6, 'Done', 'Critical', '2025-01-20');
```

### 5.4 데이터 확인

```sql
-- 테이블 목록 확인
SELECT name FROM sqlite_master WHERE type='table';

-- 각 테이블 데이터 확인
SELECT * FROM projects;
SELECT * FROM team_members;
SELECT * FROM tasks;

-- 데이터 개수 확인
SELECT 'Projects' AS table_name, COUNT(*) AS count FROM projects
UNION ALL
SELECT 'Team Members', COUNT(*) FROM team_members
UNION ALL
SELECT 'Tasks', COUNT(*) FROM tasks;
```

---

## 6. 기본 SQL 쿼리 10선

### 6.1 SELECT - 데이터 조회

**기본 조회**:
```sql
-- 모든 컬럼 조회
SELECT * FROM projects;

-- 특정 컬럼만 조회
SELECT name, status, budget FROM projects;

-- 컬럼 이름 바꾸기 (AS)
SELECT 
    name AS project_name,
    budget AS project_budget
FROM projects;
```

### 6.2 WHERE - 조건 필터링

**기본 조건**:
```sql
-- 진행 중인 프로젝트만
SELECT * FROM projects
WHERE status = 'In Progress';

-- 예산이 5000만원 이상인 프로젝트
SELECT * FROM projects
WHERE budget >= 50000000;

-- 2025년에 시작한 프로젝트
SELECT * FROM projects
WHERE start_date >= '2025-01-01';
```

**복합 조건**:
```sql
-- AND: 두 조건 모두 만족
SELECT * FROM projects
WHERE status = 'In Progress' 
  AND budget > 30000000;

-- OR: 둘 중 하나라도 만족
SELECT * FROM projects
WHERE status = 'Planning' 
   OR status = 'In Progress';

-- IN: 여러 값 중 하나
SELECT * FROM projects
WHERE status IN ('Planning', 'In Progress');

-- BETWEEN: 범위 조건
SELECT * FROM projects
WHERE budget BETWEEN 20000000 AND 50000000;

-- LIKE: 패턴 매칭
SELECT * FROM projects
WHERE name LIKE '%앱%';
-- '%앱%': '앱'을 포함하는 모든 문자열
-- '앱%': '앱'으로 시작
-- '%앱': '앱'으로 끝남
```

### 6.3 ORDER BY - 정렬

```sql
-- 예산 기준 오름차순 (작은 것부터)
SELECT * FROM projects
ORDER BY budget ASC;

-- 예산 기준 내림차순 (큰 것부터)
SELECT * FROM projects
ORDER BY budget DESC;

-- 여러 컬럼 기준 정렬
SELECT * FROM projects
ORDER BY status ASC, budget DESC;
-- status를 먼저 정렬하고, 같은 status 내에서 budget으로 정렬
```

### 6.4 LIMIT - 결과 제한

```sql
-- 상위 3개만
SELECT * FROM projects
ORDER BY budget DESC
LIMIT 3;

-- 4번째부터 3개 (페이징)
SELECT * FROM projects
ORDER BY budget DESC
LIMIT 3 OFFSET 3;
```

### 6.5 집계 함수

```sql
-- COUNT: 개수 세기
SELECT COUNT(*) AS total_projects FROM projects;

-- SUM: 합계
SELECT SUM(budget) AS total_budget FROM projects;

-- AVG: 평균
SELECT AVG(budget) AS average_budget FROM projects;

-- MIN, MAX: 최소값, 최대값
SELECT 
    MIN(budget) AS min_budget,
    MAX(budget) AS max_budget
FROM projects;

-- 조건과 함께 사용
SELECT COUNT(*) AS in_progress_count
FROM projects
WHERE status = 'In Progress';
```

### 6.6 GROUP BY - 그룹화

```sql
-- 상태별 프로젝트 개수
SELECT 
    status,
    COUNT(*) AS count
FROM projects
GROUP BY status;

-- 우선순위별 작업 개수
SELECT 
    priority,
    COUNT(*) AS task_count
FROM tasks
GROUP BY priority
ORDER BY task_count DESC;

-- 상태별 작업 개수 (2개 이상인 것만)
SELECT 
    status,
    COUNT(*) AS count
FROM tasks
GROUP BY status
HAVING COUNT(*) >= 2;
-- HAVING: GROUP BY 결과에 조건 적용 (WHERE는 그룹화 전에 적용)
```

### 6.7 JOIN - 테이블 결합

**INNER JOIN** (가장 많이 사용):
```sql
-- 작업과 담당자 정보 결합
SELECT 
    tasks.title AS task,
    team_members.name AS assignee,
    tasks.status,
    tasks.priority
FROM tasks
INNER JOIN team_members ON tasks.assignee_id = team_members.id;

-- 더 복잡한 JOIN: 작업 + 프로젝트 + 담당자
SELECT 
    projects.name AS project,
    tasks.title AS task,
    team_members.name AS assignee,
    tasks.status,
    tasks.due_date
FROM tasks
INNER JOIN projects ON tasks.project_id = projects.id
INNER JOIN team_members ON tasks.assignee_id = team_members.id
WHERE tasks.status != 'Done'
ORDER BY tasks.due_date;
```

**LEFT JOIN**:
```sql
-- 모든 팀 멤버와 그들의 작업 (작업이 없어도 표시)
SELECT 
    team_members.name AS member,
    COUNT(tasks.id) AS task_count
FROM team_members
LEFT JOIN tasks ON team_members.id = tasks.assignee_id
GROUP BY team_members.id, team_members.name
ORDER BY task_count DESC;
```

### 6.8 서브쿼리

```sql
-- 평균 예산보다 큰 프로젝트
SELECT name, budget
FROM projects
WHERE budget > (SELECT AVG(budget) FROM projects);

-- 작업이 가장 많은 프로젝트
SELECT name, 
    (SELECT COUNT(*) FROM tasks WHERE tasks.project_id = projects.id) AS task_count
FROM projects
ORDER BY task_count DESC
LIMIT 1;
```

### 6.9 INSERT - 데이터 삽입

```sql
-- 단일 행 삽입
INSERT INTO team_members (name, role, email, hire_date)
VALUES ('홍길동', 'DevOps Engineer', 'hong@example.com', '2025-02-01');

-- 여러 행 삽입
INSERT INTO tasks (project_id, title, assignee_id, status, priority, due_date)
VALUES
    (1, '보안 테스트', 5, 'To Do', 'High', '2025-05-15'),
    (1, '성능 최적화', 2, 'To Do', 'Medium', '2025-05-20');
```

### 6.10 UPDATE & DELETE

**UPDATE - 데이터 수정**:
```sql
-- 특정 작업의 상태 변경
UPDATE tasks
SET status = 'In Progress'
WHERE id = 5;

-- 여러 컬럼 동시 수정
UPDATE tasks
SET status = 'Done', priority = 'Low'
WHERE id = 1;

-- ⚠️ 주의: WHERE 없으면 모든 행이 수정됨!
UPDATE tasks
SET status = 'Done';  -- 모든 작업이 Done으로 변경됨
```

**DELETE - 데이터 삭제**:
```sql
-- 특정 작업 삭제
DELETE FROM tasks
WHERE id = 12;

-- 조건에 맞는 행 삭제
DELETE FROM tasks
WHERE status = 'Done' AND due_date < '2025-01-01';

-- ⚠️ 주의: WHERE 없으면 모든 행이 삭제됨!
DELETE FROM tasks;  -- 모든 작업 삭제
```

---

## 7. PM을 위한 SQL 활용 팁

### 7.1 프로젝트 대시보드 쿼리

**전체 현황**:
```sql
SELECT 
    status,
    COUNT(*) AS project_count,
    SUM(budget) AS total_budget,
    AVG(budget) AS avg_budget
FROM projects
GROUP BY status
ORDER BY project_count DESC;
```

**예상 결과**:
```
+--------------+---------------+--------------+-------------+
| status       | project_count | total_budget | avg_budget  |
+--------------+---------------+--------------+-------------+
| In Progress  | 2             | 150000000    | 75000000    |
| Planning     | 2             | 50000000     | 25000000    |
| Completed    | 1             | 15000000     | 15000000    |
+--------------+---------------+--------------+-------------+
```

### 7.2 팀 워크로드 분석

```sql
SELECT 
    tm.name AS member,
    tm.role,
    COUNT(CASE WHEN t.status = 'To Do' THEN 1 END) AS todo,
    COUNT(CASE WHEN t.status = 'In Progress' THEN 1 END) AS in_progress,
    COUNT(CASE WHEN t.status = 'Done' THEN 1 END) AS done,
    COUNT(t.id) AS total_tasks
FROM team_members tm
LEFT JOIN tasks t ON tm.id = t.assignee_id
GROUP BY tm.id, tm.name, tm.role
ORDER BY total_tasks DESC;
```

### 7.3 마감일 임박 작업 조회

```sql
SELECT 
    p.name AS project,
    t.title AS task,
    tm.name AS assignee,
    t.due_date,
    JULIANDAY(t.due_date) - JULIANDAY('now') AS days_left
FROM tasks t
INNER JOIN projects p ON t.project_id = p.id
INNER JOIN team_members tm ON t.assignee_id = tm.id
WHERE t.status != 'Done'
  AND t.due_date <= DATE('now', '+7 days')
ORDER BY t.due_date;
```

### 7.4 Critical 우선순위 작업 리스트

```sql
SELECT 
    p.name AS project,
    t.title AS task,
    t.status,
    t.due_date,
    tm.name AS assignee
FROM tasks t
INNER JOIN projects p ON t.project_id = p.id
INNER JOIN team_members tm ON t.assignee_id = tm.id
WHERE t.priority = 'Critical'
  AND t.status != 'Done'
ORDER BY t.due_date;
```

### 7.5 프로젝트별 진행률 계산

```sql
SELECT 
    p.name AS project,
    COUNT(t.id) AS total_tasks,
    SUM(CASE WHEN t.status = 'Done' THEN 1 ELSE 0 END) AS completed_tasks,
    ROUND(
        SUM(CASE WHEN t.status = 'Done' THEN 1 ELSE 0 END) * 100.0 / COUNT(t.id),
        1
    ) AS completion_rate
FROM projects p
LEFT JOIN tasks t ON p.id = t.project_id
GROUP BY p.id, p.name
ORDER BY completion_rate DESC;
```

### 7.6 PM이 자주 사용하는 쿼리 패턴

**패턴 1: Top N 조회**
```sql
-- 예산 상위 3개 프로젝트
SELECT name, budget
FROM projects
ORDER BY budget DESC
LIMIT 3;
```

**패턴 2: 기간별 필터링**
```sql
-- 이번 달에 시작한 프로젝트
SELECT * FROM projects
WHERE start_date >= DATE('now', 'start of month')
  AND start_date < DATE('now', 'start of month', '+1 month');
```

**패턴 3: NULL 체크**
```sql
-- 마감일이 설정되지 않은 작업
SELECT * FROM tasks
WHERE due_date IS NULL;

-- 담당자가 할당된 작업
SELECT * FROM tasks
WHERE assignee_id IS NOT NULL;
```

**패턴 4: CASE문 활용**
```sql
-- 예산 규모 분류
SELECT 
    name,
    budget,
    CASE 
        WHEN budget >= 50000000 THEN 'Large'
        WHEN budget >= 20000000 THEN 'Medium'
        ELSE 'Small'
    END AS size
FROM projects;
```

---

## 8. 실습 문제

### 8.1 기초 문제 (필수)

**문제 1**: 모든 팀 멤버의 이름과 역할을 조회하세요.
```sql
-- 여기에 쿼리 작성
```

<details>
<summary>정답 보기</summary>

```sql
SELECT name, role FROM team_members;
```
</details>

---

**문제 2**: 예산이 30,000,000원 이상인 프로젝트를 조회하세요.
```sql
-- 여기에 쿼리 작성
```

<details>
<summary>정답 보기</summary>

```sql
SELECT * FROM projects
WHERE budget >= 30000000;
```
</details>

---

**문제 3**: 'High' 우선순위의 작업을 마감일 순으로 조회하세요.
```sql
-- 여기에 쿼리 작성
```

<details>
<summary>정답 보기</summary>

```sql
SELECT * FROM tasks
WHERE priority = 'High'
ORDER BY due_date;
```
</details>

---

### 8.2 중급 문제 (권장)

**문제 4**: 각 프로젝트의 작업 개수를 세세요.
```sql
-- 여기에 쿼리 작성
```

<details>
<summary>정답 보기</summary>

```sql
SELECT 
    p.name AS project,
    COUNT(t.id) AS task_count
FROM projects p
LEFT JOIN tasks t ON p.id = t.project_id
GROUP BY p.id, p.name
ORDER BY task_count DESC;
```
</details>

---

**문제 5**: 각 팀 멤버가 담당한 작업 개수를 조회하세요.
```sql
-- 여기에 쿼리 작성
```

<details>
<summary>정답 보기</summary>

```sql
SELECT 
    tm.name AS member,
    COUNT(t.id) AS task_count
FROM team_members tm
LEFT JOIN tasks t ON tm.id = t.assignee_id
GROUP BY tm.id, tm.name
ORDER BY task_count DESC;
```
</details>

---

**문제 6**: 'In Progress' 상태인 프로젝트의 모든 작업을 조회하세요 (프로젝트 이름 포함).
```sql
-- 여기에 쿼리 작성
```

<details>
<summary>정답 보기</summary>

```sql
SELECT 
    p.name AS project,
    t.title AS task,
    t.status,
    t.priority
FROM tasks t
INNER JOIN projects p ON t.project_id = p.id
WHERE p.status = 'In Progress';
```
</details>

---

### 8.3 고급 문제 (도전)

**문제 7**: 각 상태별 작업 개수와 비율을 계산하세요.
```sql
-- 여기에 쿼리 작성
-- 힌트: 전체 작업 개수를 서브쿼리로 구하고, 비율 계산
```

<details>
<summary>정답 보기</summary>

```sql
SELECT 
    status,
    COUNT(*) AS count,
    ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM tasks), 1) AS percentage
FROM tasks
GROUP BY status
ORDER BY count DESC;
```
</details>

---

**문제 8**: 프로젝트별로 완료된 작업 비율을 계산하여, 진행률이 50% 미만인 프로젝트만 조회하세요.
```sql
-- 여기에 쿼리 작성
```

<details>
<summary>정답 보기</summary>

```sql
SELECT 
    p.name AS project,
    COUNT(t.id) AS total_tasks,
    SUM(CASE WHEN t.status = 'Done' THEN 1 ELSE 0 END) AS completed_tasks,
    ROUND(
        SUM(CASE WHEN t.status = 'Done' THEN 1 ELSE 0 END) * 100.0 / COUNT(t.id),
        1
    ) AS completion_rate
FROM projects p
LEFT JOIN tasks t ON p.id = t.project_id
GROUP BY p.id, p.name
HAVING completion_rate < 50
ORDER BY completion_rate;
```
</details>

---

**문제 9**: 작업이 가장 많은 프로젝트의 이름, 작업 개수, 예산을 조회하세요.
```sql
-- 여기에 쿼리 작성
```

<details>
<summary>정답 보기</summary>

```sql
SELECT 
    p.name AS project,
    COUNT(t.id) AS task_count,
    p.budget
FROM projects p
LEFT JOIN tasks t ON p.id = t.project_id
GROUP BY p.id, p.name, p.budget
ORDER BY task_count DESC
LIMIT 1;
```
</details>

---

## 📚 추가 학습 자료

### 공식 문서
- SQLite Tutorial: https://www.sqlitetutorial.net
- MySQL Documentation: https://dev.mysql.com/doc/
- W3Schools SQL: https://www.w3schools.com/sql/

### 온라인 코스
- Khan Academy SQL: https://www.khanacademy.org/computing/computer-programming/sql
- SQLBolt: https://sqlbolt.com (인터랙티브 튜토리얼)
- Mode Analytics SQL Tutorial: https://mode.com/sql-tutorial/

### 연습 플랫폼
- LeetCode Database: https://leetcode.com/problemset/database/
- HackerRank SQL: https://www.hackerrank.com/domains/sql
- SQLZoo: https://sqlzoo.net

### 참고 도서
- "SQL 첫걸음" - 아사이 아츠시
- "모두의 SQL" - 김도윤
- "데이터 분석을 위한 SQL 레시피" - 가나기 나가토, 다미야 나오토

---

## ✅ 학습 체크리스트

### 기본 (필수)
- [ ] SQLite Online 접속 및 첫 쿼리 실행
- [ ] SELECT, WHERE, ORDER BY 실습 완료
- [ ] 샘플 데이터베이스 구축 완료
- [ ] 기초 문제 3개 해결
- [ ] COUNT, SUM, AVG 등 집계 함수 사용

### 중급 (권장)
- [ ] GROUP BY를 사용한 그룹화 실습
- [ ] JOIN을 사용한 테이블 결합 실습
- [ ] 중급 문제 3개 해결
- [ ] 프로젝트 대시보드 쿼리 작성
- [ ] 팀 워크로드 분석 쿼리 이해

### 고급 (선택)
- [ ] 서브쿼리 사용법 이해
- [ ] CASE 문을 활용한 조건부 로직
- [ ] 고급 문제 3개 해결
- [ ] MySQL Workbench 설치 및 사용
- [ ] 회사 데이터베이스 접속 경험

---

## 🆘 문제 해결 (Troubleshooting)

### 1. 쿼리 실행 오류

**증상**: "Syntax error near..."

**원인**: SQL 문법 오류

**해결**:
- 세미콜론(;) 확인
- 따옴표 (작은따옴표 ') 확인
- 예약어 대소문자 확인 (SELECT, FROM 등)
- 컬럼명, 테이블명 오타 확인

### 2. 결과가 비어있음

**증상**: "No results"

**원인**: 조건에 맞는 데이터가 없음

**해결**:
```sql
-- 테이블에 데이터가 있는지 확인
SELECT COUNT(*) FROM your_table;

-- WHERE 조건 제거하고 전체 조회
SELECT * FROM your_table;
```

### 3. JOIN 결과가 이상함

**증상**: 중복된 행이 나타남

**원인**: 1:N 관계를 잘못 이해

**해결**:
- 어떤 테이블이 1이고 N인지 확인
- LEFT JOIN vs INNER JOIN 차이 이해
- GROUP BY로 집계 필요 여부 확인

### 4. "Foreign key constraint failed"

**증상**: INSERT 또는 DELETE 실행 시 오류

**원인**: 외래 키 제약 위반

**해결**:
- 참조되는 행을 먼저 삭제
- 또는 외래 키 제약 해제 (개발 환경에서만!)
```sql
PRAGMA foreign_keys = OFF;  -- SQLite
```

---

## 🎓 마무리

축하합니다! 이제 PM으로서 SQL을 활용할 준비가 되었습니다.

### 핵심 요약
- **SELECT**: 데이터 조회의 기본
- **WHERE**: 필요한 데이터만 필터링
- **JOIN**: 여러 테이블의 데이터 결합
- **GROUP BY**: 데이터 집계 및 분석
- **ORDER BY**: 결과 정렬

### 실무 활용
- 프로젝트 대시보드 쿼리 작성
- 팀 워크로드 분석
- 마감일 관리
- 진행률 모니터링

### 다음 단계
1. Week 14 수업에서 더 깊이 학습
2. 실제 프로젝트 데이터로 연습
3. 팀과 함께 데이터 분석
4. 고급 SQL 기법 학습 (Window Function, CTE 등)

**Happy Querying! 🗄️**

---

**문서 버전**: 1.0  
**최종 업데이트**: 2025년 2월  
**관련 문서**: [GitHub 실습 가이드](./github-setup-guide.md), [AWS Free Tier 가이드](./aws-free-tier-guide.md)
