# SQL 실습 환경 가이드

> **대상**: PM 교육 Week 14 - 데이터베이스  
> **소요 시간**: 1-2시간  
> **난이도**: 초급

---

## 📚 목차
1. [SQL이란?](#1-sql이란)
2. [온라인 SQL 실습 환경](#2-온라인-sql-실습-환경)
3. [로컬 SQLite 설치](#3-로컬-sqlite-설치)
4. [샘플 데이터베이스 구축](#4-샘플-데이터베이스-구축)
5. [기본 SQL 명령어 실습](#5-기본-sql-명령어-실습)
6. [실습 프로젝트](#6-실습-프로젝트)

---

## 1. SQL이란?

### 1.1 SQL 개요
**SQL (Structured Query Language)**은 데이터베이스와 소통하기 위한 표준 언어입니다.

### 1.2 SQL의 용도
- ✅ **데이터 조회**: 원하는 데이터 검색
- ✅ **데이터 입력**: 새로운 데이터 추가
- ✅ **데이터 수정**: 기존 데이터 변경
- ✅ **데이터 삭제**: 불필요한 데이터 제거
- ✅ **데이터베이스 구조 설계**: 테이블, 관계 정의

### 1.3 PM이 SQL을 알아야 하는 이유
- 📊 **데이터 분석**: 프로젝트 성과 지표 직접 조회
- 🗣️ **개발팀 커뮤니케이션**: 기술 용어 이해 및 요구사항 명확화
- ✅ **데이터 검증**: 기능 테스트 시 데이터 확인
- 🎯 **데이터베이스 설계 검토**: ERD 검토 및 피드백

### 1.4 SQL 명령어 분류

| 분류 | 설명 | 주요 명령어 |
|-----|------|------------|
| **DQL** | Data Query Language (데이터 조회) | SELECT |
| **DML** | Data Manipulation Language (데이터 조작) | INSERT, UPDATE, DELETE |
| **DDL** | Data Definition Language (데이터 정의) | CREATE, ALTER, DROP |
| **DCL** | Data Control Language (데이터 제어) | GRANT, REVOKE |

**PM은 주로 DQL(SELECT)과 기본 DML을 사용합니다.**

---

## 2. 온라인 SQL 실습 환경

### 2.1 권장 온라인 도구

#### 🥇 Option 1: SQLite Online (가장 추천)
- **URL**: [https://sqliteonline.com](https://sqliteonline.com)
- **장점**:
  - 설치 불필요
  - 빠른 시작
  - 간단한 인터페이스
- **단점**:
  - 기능 제한적
  - 대용량 데이터 처리 불가

#### 🥈 Option 2: DB Fiddle
- **URL**: [https://www.db-fiddle.com](https://www.db-fiddle.com)
- **장점**:
  - 여러 DB 엔진 지원 (MySQL, PostgreSQL, SQLite)
  - 스키마와 쿼리 분리
  - 결과 공유 가능
- **단점**:
  - 인터페이스가 다소 복잡

#### 🥉 Option 3: SQL Fiddle
- **URL**: [http://sqlfiddle.com](http://sqlfiddle.com)
- **장점**:
  - 오래된 신뢰성 있는 도구
  - 쿼리 공유 가능
- **단점**:
  - 서버 느림
  - UI가 구식

#### 📚 Option 4: W3Schools SQL Tryit
- **URL**: [https://www.w3schools.com/sql/trysql.asp?filename=trysql_select_all](https://www.w3schools.com/sql/trysql.asp?filename=trysql_select_all)
- **장점**:
  - 학습용 샘플 데이터 제공
  - 초보자 친화적
- **단점**:
  - 샘플 데이터만 사용 가능

### 2.2 SQLite Online 시작하기

#### Step 1: 웹사이트 접속
1. [https://sqliteonline.com](https://sqliteonline.com) 접속
2. 자동으로 빈 데이터베이스 생성됨

#### Step 2: 인터페이스 이해
```
┌─────────────────────────────────────────┐
│ [File] [Import] [Export] [Settings]    │ ← 메뉴바
├─────────────────────────────────────────┤
│ Tables (좌측)      │ SQL Editor (우측)  │
│ - Table1          │                    │
│ - Table2          │ SELECT * FROM ...  │
│                   │                    │
├─────────────────────────────────────────┤
│ Results (하단)                          │
│ Query results appear here              │
└─────────────────────────────────────────┘
```

#### Step 3: 첫 SQL 쿼리 실행
1. SQL Editor에 입력:
```sql
SELECT 'Hello, SQL!' AS greeting;
```
2. **"Run"** 버튼 클릭 (또는 Ctrl+Enter)
3. Results에서 결과 확인

---

## 3. 로컬 SQLite 설치

### 3.1 SQLite란?
- 파일 기반 경량 데이터베이스
- 설치 간단
- 서버 불필요
- 학습 및 프로토타이핑에 최적

### 3.2 설치 방법

#### Windows

**방법 1: DB Browser for SQLite (GUI, 권장)**
1. [https://sqlitebrowser.org/dl/](https://sqlitebrowser.org/dl/) 접속
2. Windows 버전 다운로드
3. 설치 프로그램 실행
4. 설치 완료

**방법 2: SQLite CLI**
1. [https://www.sqlite.org/download.html](https://www.sqlite.org/download.html) 접속
2. **sqlite-tools-win32-x86-*.zip** 다운로드
3. 압축 해제
4. `sqlite3.exe` 실행

#### macOS

**SQLite는 기본 설치되어 있음**
```bash
# 버전 확인
sqlite3 --version
```

**GUI 도구 설치 (선택)**
```bash
brew install --cask db-browser-for-sqlite
```

#### Linux

**Ubuntu/Debian**
```bash
sudo apt update
sudo apt install sqlite3
```

**Fedora**
```bash
sudo dnf install sqlite
```

### 3.3 DB Browser for SQLite 사용법

#### Step 1: 새 데이터베이스 생성
1. **File → New Database** 클릭
2. 파일 이름 입력 (예: `practice.db`)
3. 저장 위치 선택

#### Step 2: 테이블 생성
1. **Create Table** 버튼 클릭
2. 테이블 이름 입력
3. 필드 추가:
   - Name: 필드 이름
   - Type: 데이터 타입 (TEXT, INTEGER, REAL, BLOB)
   - Not Null: 필수 여부
   - Primary Key: 기본 키 여부

#### Step 3: SQL 실행
1. **Execute SQL** 탭 클릭
2. SQL 쿼리 작성
3. **▶️ 실행** 버튼 클릭

---

## 4. 샘플 데이터베이스 구축

### 4.1 프로젝트 관리 데이터베이스 설계

#### ERD (개념)
```
Projects
  ├─ project_id (PK)
  ├─ project_name
  ├─ start_date
  ├─ end_date
  └─ budget

Tasks
  ├─ task_id (PK)
  ├─ project_id (FK → Projects)
  ├─ task_name
  ├─ status
  ├─ assignee
  └─ estimated_hours

Team_Members
  ├─ member_id (PK)
  ├─ name
  ├─ role
  └─ email
```

### 4.2 테이블 생성 SQL

#### 1) Projects 테이블
```sql
CREATE TABLE Projects (
    project_id INTEGER PRIMARY KEY AUTOINCREMENT,
    project_name TEXT NOT NULL,
    start_date DATE NOT NULL,
    end_date DATE,
    budget REAL,
    status TEXT DEFAULT 'Planning'
);
```

#### 2) Team_Members 테이블
```sql
CREATE TABLE Team_Members (
    member_id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    role TEXT NOT NULL,
    email TEXT UNIQUE,
    join_date DATE DEFAULT CURRENT_DATE
);
```

#### 3) Tasks 테이블
```sql
CREATE TABLE Tasks (
    task_id INTEGER PRIMARY KEY AUTOINCREMENT,
    project_id INTEGER NOT NULL,
    task_name TEXT NOT NULL,
    description TEXT,
    status TEXT DEFAULT 'To Do',
    assignee_id INTEGER,
    estimated_hours REAL,
    actual_hours REAL,
    due_date DATE,
    FOREIGN KEY (project_id) REFERENCES Projects(project_id),
    FOREIGN KEY (assignee_id) REFERENCES Team_Members(member_id)
);
```

### 4.3 샘플 데이터 입력

#### Projects 데이터
```sql
INSERT INTO Projects (project_name, start_date, end_date, budget, status)
VALUES 
    ('모바일 앱 개발', '2024-01-01', '2024-06-30', 50000000, 'In Progress'),
    ('웹사이트 리뉴얼', '2024-02-01', '2024-05-31', 30000000, 'In Progress'),
    ('ERP 시스템 구축', '2024-03-01', '2024-12-31', 100000000, 'Planning'),
    ('AI 챗봇 개발', '2024-01-15', '2024-04-15', 20000000, 'Completed');
```

#### Team_Members 데이터
```sql
INSERT INTO Team_Members (name, role, email, join_date)
VALUES 
    ('김철수', 'PM', 'kim@company.com', '2023-01-10'),
    ('이영희', '개발자', 'lee@company.com', '2023-03-15'),
    ('박민수', '개발자', 'park@company.com', '2023-06-01'),
    ('정수진', '디자이너', 'jung@company.com', '2023-02-20'),
    ('최지훈', 'QA', 'choi@company.com', '2023-05-10');
```

#### Tasks 데이터
```sql
INSERT INTO Tasks (project_id, task_name, description, status, assignee_id, estimated_hours, actual_hours, due_date)
VALUES 
    (1, 'UI 디자인', '앱 메인 화면 디자인', 'Done', 4, 40, 35, '2024-01-31'),
    (1, '로그인 기능 개발', '사용자 인증 구현', 'In Progress', 2, 20, 15, '2024-02-15'),
    (1, 'API 개발', 'RESTful API 구축', 'In Progress', 3, 60, NULL, '2024-03-01'),
    (2, '요구사항 분석', '현행 시스템 분석', 'Done', 1, 30, 28, '2024-02-10'),
    (2, '와이어프레임 제작', '페이지 구조 설계', 'To Do', 4, 25, NULL, '2024-02-28'),
    (3, 'RFP 작성', '제안 요청서 작성', 'In Progress', 1, 40, 20, '2024-03-15'),
    (4, 'AI 모델 학습', '챗봇 학습 데이터 준비', 'Done', 2, 80, 85, '2024-03-30');
```

---

## 5. 기본 SQL 명령어 실습

### 5.1 SELECT - 데이터 조회

#### 기본 문법
```sql
SELECT column1, column2
FROM table_name
WHERE condition;
```

#### 실습 1: 모든 프로젝트 조회
```sql
SELECT * FROM Projects;
```

**결과**:
```
project_id | project_name      | start_date | end_date   | budget    | status
-----------|-------------------|------------|------------|-----------|------------
1          | 모바일 앱 개발     | 2024-01-01 | 2024-06-30 | 50000000  | In Progress
2          | 웹사이트 리뉴얼   | 2024-02-01 | 2024-05-31 | 30000000  | In Progress
3          | ERP 시스템 구축   | 2024-03-01 | 2024-12-31 | 100000000 | Planning
4          | AI 챗봇 개발      | 2024-01-15 | 2024-04-15 | 20000000  | Completed
```

#### 실습 2: 특정 컬럼만 조회
```sql
SELECT project_name, budget 
FROM Projects;
```

#### 실습 3: 조건부 조회 (WHERE)
```sql
-- 진행 중인 프로젝트만 조회
SELECT project_name, status 
FROM Projects 
WHERE status = 'In Progress';
```

#### 실습 4: 정렬 (ORDER BY)
```sql
-- 예산 순으로 정렬 (높은 순)
SELECT project_name, budget 
FROM Projects 
ORDER BY budget DESC;
```

### 5.2 집계 함수

#### COUNT - 개수 세기
```sql
-- 전체 프로젝트 수
SELECT COUNT(*) AS total_projects 
FROM Projects;
```

#### SUM - 합계
```sql
-- 전체 예산 합계
SELECT SUM(budget) AS total_budget 
FROM Projects;
```

#### AVG - 평균
```sql
-- 평균 예산
SELECT AVG(budget) AS avg_budget 
FROM Projects;
```

#### MIN / MAX - 최소/최대
```sql
-- 최소 및 최대 예산
SELECT 
    MIN(budget) AS min_budget,
    MAX(budget) AS max_budget
FROM Projects;
```

### 5.3 GROUP BY - 그룹화

```sql
-- 상태별 프로젝트 수
SELECT status, COUNT(*) AS count
FROM Projects
GROUP BY status;
```

**결과**:
```
status      | count
------------|------
In Progress | 2
Planning    | 1
Completed   | 1
```

```sql
-- 프로젝트별 작업 수
SELECT 
    p.project_name,
    COUNT(t.task_id) AS task_count
FROM Projects p
LEFT JOIN Tasks t ON p.project_id = t.project_id
GROUP BY p.project_name;
```

### 5.4 JOIN - 테이블 결합

#### INNER JOIN
```sql
-- 작업과 담당자 정보 함께 조회
SELECT 
    t.task_name,
    t.status,
    m.name AS assignee
FROM Tasks t
INNER JOIN Team_Members m ON t.assignee_id = m.member_id;
```

#### LEFT JOIN
```sql
-- 모든 프로젝트와 작업 수 (작업 없는 프로젝트 포함)
SELECT 
    p.project_name,
    COUNT(t.task_id) AS task_count
FROM Projects p
LEFT JOIN Tasks t ON p.project_id = t.project_id
GROUP BY p.project_name;
```

#### 복잡한 JOIN 예제
```sql
-- 프로젝트, 작업, 담당자 정보 모두 조회
SELECT 
    p.project_name,
    t.task_name,
    t.status,
    m.name AS assignee,
    t.estimated_hours,
    t.actual_hours
FROM Projects p
INNER JOIN Tasks t ON p.project_id = t.project_id
LEFT JOIN Team_Members m ON t.assignee_id = m.member_id
WHERE p.status = 'In Progress'
ORDER BY p.project_name, t.task_name;
```

### 5.5 INSERT - 데이터 입력

```sql
-- 새 프로젝트 추가
INSERT INTO Projects (project_name, start_date, budget, status)
VALUES ('고객 관리 시스템', '2024-04-01', 40000000, 'Planning');
```

### 5.6 UPDATE - 데이터 수정

```sql
-- 작업 상태 업데이트
UPDATE Tasks
SET status = 'Done', actual_hours = 18
WHERE task_id = 2;
```

### 5.7 DELETE - 데이터 삭제

```sql
-- 특정 작업 삭제
DELETE FROM Tasks
WHERE task_id = 7;
```

**⚠️ 주의**: WHERE 절을 빠뜨리면 모든 데이터가 삭제됩니다!

---

## 6. 실습 프로젝트

### 6.1 프로젝트 시나리오

**목표**: SQL을 사용하여 프로젝트 관리 데이터 분석

**데이터**: 위에서 생성한 샘플 데이터베이스 사용

### 6.2 실습 과제

#### 과제 1: 기본 조회
```sql
-- Q1. 모든 팀원의 이름과 역할을 조회하세요.
-- 답안:
SELECT name, role FROM Team_Members;

-- Q2. 예산이 3천만원 이상인 프로젝트를 조회하세요.
-- 답안:
SELECT project_name, budget 
FROM Projects 
WHERE budget >= 30000000;

-- Q3. 'In Progress' 상태의 작업 목록을 조회하세요.
-- 답안:
SELECT task_name, status 
FROM Tasks 
WHERE status = 'In Progress';
```

#### 과제 2: 집계 및 그룹화
```sql
-- Q4. 상태별로 작업 수를 집계하세요.
-- 답안:
SELECT status, COUNT(*) AS task_count
FROM Tasks
GROUP BY status;

-- Q5. 프로젝트별 총 예상 작업 시간을 계산하세요.
-- 답안:
SELECT 
    p.project_name,
    SUM(t.estimated_hours) AS total_estimated_hours
FROM Projects p
LEFT JOIN Tasks t ON p.project_id = t.project_id
GROUP BY p.project_name;

-- Q6. 역할별 팀원 수를 세어보세요.
-- 답안:
SELECT role, COUNT(*) AS member_count
FROM Team_Members
GROUP BY role;
```

#### 과제 3: JOIN 활용
```sql
-- Q7. 각 작업의 프로젝트명과 담당자 이름을 함께 조회하세요.
-- 답안:
SELECT 
    p.project_name,
    t.task_name,
    m.name AS assignee
FROM Tasks t
INNER JOIN Projects p ON t.project_id = p.project_id
LEFT JOIN Team_Members m ON t.assignee_id = m.member_id;

-- Q8. '개발자' 역할을 가진 팀원이 담당한 작업을 모두 조회하세요.
-- 답안:
SELECT 
    m.name AS developer,
    t.task_name,
    p.project_name
FROM Team_Members m
INNER JOIN Tasks t ON m.member_id = t.assignee_id
INNER JOIN Projects p ON t.project_id = p.project_id
WHERE m.role = '개발자';
```

#### 과제 4: 고급 쿼리
```sql
-- Q9. 실제 작업 시간이 예상 시간을 초과한 작업을 찾으세요.
-- 답안:
SELECT 
    task_name,
    estimated_hours,
    actual_hours,
    (actual_hours - estimated_hours) AS overtime
FROM Tasks
WHERE actual_hours > estimated_hours;

-- Q10. 프로젝트별 완료율을 계산하세요.
-- 답안:
SELECT 
    p.project_name,
    COUNT(t.task_id) AS total_tasks,
    SUM(CASE WHEN t.status = 'Done' THEN 1 ELSE 0 END) AS completed_tasks,
    ROUND(
        (SUM(CASE WHEN t.status = 'Done' THEN 1 ELSE 0 END) * 100.0) / COUNT(t.task_id), 
        2
    ) AS completion_rate
FROM Projects p
LEFT JOIN Tasks t ON p.project_id = t.project_id
GROUP BY p.project_name;
```

### 6.3 도전 과제

#### 도전 1: 프로젝트 대시보드 쿼리
```sql
-- 프로젝트 현황 종합 보고서
SELECT 
    p.project_name,
    p.status,
    p.budget,
    COUNT(t.task_id) AS total_tasks,
    SUM(CASE WHEN t.status = 'Done' THEN 1 ELSE 0 END) AS completed_tasks,
    SUM(t.estimated_hours) AS estimated_hours,
    SUM(t.actual_hours) AS actual_hours
FROM Projects p
LEFT JOIN Tasks t ON p.project_id = t.project_id
GROUP BY p.project_id
ORDER BY p.start_date;
```

#### 도전 2: 팀원별 작업 부하 분석
```sql
-- 팀원별 할당된 작업 수와 예상 시간
SELECT 
    m.name,
    m.role,
    COUNT(t.task_id) AS assigned_tasks,
    SUM(t.estimated_hours) AS total_hours,
    SUM(CASE WHEN t.status = 'Done' THEN 1 ELSE 0 END) AS completed_tasks
FROM Team_Members m
LEFT JOIN Tasks t ON m.member_id = t.assignee_id
GROUP BY m.member_id
ORDER BY total_hours DESC;
```

---

## 7. 추가 학습 자료

### 7.1 무료 온라인 강의
- **W3Schools SQL Tutorial**: [https://www.w3schools.com/sql/](https://www.w3schools.com/sql/)
- **SQLBolt**: [https://sqlbolt.com/](https://sqlbolt.com/) (인터랙티브)
- **Khan Academy - SQL**: [https://www.khanacademy.org/computing/computer-programming/sql](https://www.khanacademy.org/computing/computer-programming/sql)

### 7.2 인터랙티브 학습
- **LeetCode Database**: SQL 문제 풀이
- **HackerRank SQL**: 난이도별 SQL 연습
- **Mode Analytics SQL Tutorial**: 실무 중심 학습

### 7.3 추천 서적
- **"SQL 첫걸음"** - 아사이 아츠시 (입문)
- **"SQL 레벨업"** - 미크 (중급)
- **"SQL AntiPatterns"** - Bill Karwin (고급)

---

## 8. 자주 묻는 질문 (FAQ)

### Q1: SQL과 NoSQL의 차이는 무엇인가요?
**A**: 
- **SQL (관계형)**: 정형화된 데이터, 명확한 스키마, JOIN 강력
- **NoSQL (비관계형)**: 유연한 스키마, 대용량 데이터, 수평 확장 용이

### Q2: PM이 얼마나 SQL을 알아야 하나요?
**A**: 기본적인 SELECT, JOIN, 집계 함수를 알면 충분합니다. 복잡한 쿼리는 데이터 팀에 요청하세요.

### Q3: 실무에서 가장 많이 쓰이는 SQL은 무엇인가요?
**A**: SELECT 문이 압도적으로 많고, 특히 WHERE, JOIN, GROUP BY 조합입니다.

### Q4: SQLite와 MySQL의 차이는 무엇인가요?
**A**: 
- **SQLite**: 파일 기반, 서버 불필요, 소규모
- **MySQL**: 서버 기반, 대규모, 동시 접속 많음

### Q5: 데이터베이스를 직접 수정해도 되나요?
**A**: 
- **개발/테스트 DB**: 가능 (백업 후)
- **운영 DB**: 절대 금지! DBA에게 요청

---

## 9. 치트 시트

### 기본 SELECT 패턴
```sql
-- 전체 조회
SELECT * FROM table_name;

-- 특정 컬럼
SELECT column1, column2 FROM table_name;

-- 조건부 조회
SELECT * FROM table_name WHERE condition;

-- 정렬
SELECT * FROM table_name ORDER BY column ASC/DESC;

-- 제한
SELECT * FROM table_name LIMIT 10;
```

### 집계 함수
```sql
COUNT(*)          -- 개수
SUM(column)       -- 합계
AVG(column)       -- 평균
MIN(column)       -- 최소값
MAX(column)       -- 최대값
```

### JOIN 패턴
```sql
-- INNER JOIN: 양쪽에 모두 있는 데이터
SELECT * FROM table1 
INNER JOIN table2 ON table1.id = table2.id;

-- LEFT JOIN: 왼쪽 테이블 전체 + 오른쪽 일치하는 것
SELECT * FROM table1 
LEFT JOIN table2 ON table1.id = table2.id;
```

---

## 10. 다음 단계

### 학습 로드맵
1. ✅ **기본 SQL 문법** (이 가이드)
2. **서브쿼리 (Subquery)**
3. **인덱스 (Index) 이해**
4. **트랜잭션 (Transaction)**
5. **저장 프로시저 (Stored Procedure)**

### 실전 프로젝트 아이디어
- 개인 가계부 데이터베이스
- 독서 목록 관리 시스템
- 프로젝트 시간 추적 시스템

---

## 11. 과제

### 필수 과제
1. **샘플 데이터베이스 구축**
   - Projects, Team_Members, Tasks 테이블 생성
   - 샘플 데이터 입력

2. **기본 쿼리 실습**
   - 10개 이상의 SELECT 쿼리 작성 및 실행
   - 결과 스크린샷 제출

3. **실무 쿼리 작성**
   - 프로젝트 현황 보고서 쿼리
   - 팀원별 작업 부하 쿼리

### 선택 과제
4. **추가 테이블 설계 및 구현**
   - 예: Milestones, Issues, Time_Logs 테이블 추가

5. **데이터 시각화**
   - SQL 결과를 Excel로 내보내기
   - 차트 작성

---

## 📝 요약

### SQL 핵심 개념
- **SELECT**: 데이터 조회
- **WHERE**: 조건 필터링
- **JOIN**: 테이블 결합
- **GROUP BY**: 데이터 집계
- **INSERT/UPDATE/DELETE**: 데이터 조작

### PM이 알아야 할 필수 SQL
1. **데이터 조회** (SELECT, WHERE, ORDER BY)
2. **집계 함수** (COUNT, SUM, AVG)
3. **테이블 결합** (JOIN)
4. **그룹화** (GROUP BY)

### 실무 활용 예시
- ✅ 프로젝트 진행률 확인
- ✅ 팀원별 작업 부하 분석
- ✅ 예산 사용 현황 조회
- ✅ 마일스톤별 완료율 추적

---

**문서 버전**: 1.0  
**작성일**: 2026년 2월 1일  
**다음 업데이트**: 피드백 반영 후

---

> **💡 Tip**: SQL은 PM의 필수 도구입니다. 매일 10분씩 연습하면 한 달 안에 실무에서 사용할 수 있는 수준이 됩니다!
