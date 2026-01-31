# Week 14: 데이터베이스 기초 상세 강의 자료

## 📚 학습 목표 (상세)
1. **데이터베이스 기본 개념** 이해 (DBMS, 테이블, 관계)
2. **SQL 기초 문법** 습득 (SELECT, INSERT, UPDATE, DELETE, JOIN)
3. **ER 다이어그램** 작성 및 데이터 모델링
4. **NoSQL vs RDBMS** 비교 및 선택 기준
5. **PM 관점의 데이터베이스** 설계 검토 능력
6. **데이터베이스 성능** 및 최적화 기초

---

## 📖 Part 1: 데이터베이스 기초

### 1.1 데이터베이스란?

#### 정의
**데이터베이스 (Database, DB)**:
- 체계적으로 조직된 데이터의 집합
- 여러 사용자가 공유하여 사용
- 효율적으로 저장, 검색, 관리

**DBMS (Database Management System)**:
- 데이터베이스를 관리하는 소프트웨어
- 예: MySQL, PostgreSQL, Oracle, MongoDB

#### 데이터베이스 없이 데이터 관리한다면?

**Excel 파일 사용 시 문제점**:
```
문제 1: 동시 접근 어려움
- 여러 사람이 동시에 수정 불가
- 버전 충돌 발생

문제 2: 데이터 중복
- 고객 정보가 여러 시트에 중복
- 수정 시 모든 곳을 업데이트해야 함

문제 3: 보안 취약
- 파일 전체 접근만 가능
- 세밀한 권한 제어 불가

문제 4: 확장성 한계
- 데이터 많아지면 느려짐
- 수백만 건 처리 어려움
```

**데이터베이스 사용 시 장점**:
```
✅ 동시성: 여러 사용자 동시 접근
✅ 무결성: 데이터 정합성 보장
✅ 보안: 사용자별 권한 관리
✅ 백업: 자동 백업 및 복구
✅ 확장성: 대용량 데이터 처리
✅ 트랜잭션: 안전한 데이터 변경
```

### 1.2 관계형 데이터베이스 (RDBMS)

#### 핵심 개념

**테이블 (Table)**:
```
고객 테이블 (customers)
┌────┬──────┬─────────────┬────────────┐
│ ID │ 이름  │    이메일    │   전화번호  │
├────┼──────┼─────────────┼────────────┤
│  1 │ 김철수│ kim@email.com│ 010-1234-5678│
│  2 │ 이영희│ lee@email.com│ 010-2345-6789│
│  3 │ 박민수│ park@email.com│010-3456-7890│
└────┴──────┴─────────────┴────────────┘
```

**용어**:
```
테이블 (Table): 데이터를 저장하는 구조
행 (Row/Record): 하나의 데이터 항목
열 (Column/Field): 데이터 속성
기본키 (Primary Key): 각 행을 고유하게 식별 (예: ID)
외래키 (Foreign Key): 다른 테이블 참조
```

#### 관계 (Relationship)

**1:N 관계 (일대다)**:
```
고객 1명 ─── 주문 N개

customers 테이블
┌────┬──────┐
│ ID │ 이름  │
├────┼──────┤
│  1 │ 김철수│
└────┴──────┘
         │
         │ (1:N)
         │
orders 테이블
┌────┬───────────┬───────┐
│ ID │ 주문일     │고객 ID│
├────┼───────────┼───────┤
│ 10 │ 2024-01-01│   1   │
│ 11 │ 2024-01-05│   1   │
│ 12 │ 2024-01-10│   1   │
└────┴───────────┴───────┘
```

**N:M 관계 (다대다)**:
```
학생 N명 ─── 강의 M개
(중간 테이블 필요)

students        enrollments        courses
┌────┬─────┐  ┌────┬────┬────┐  ┌────┬────────┐
│ ID │ 이름 │  │ ID │학생│강의│  │ ID │ 강의명  │
├────┼─────┤  ├────┼────┼────┤  ├────┼────────┤
│  1 │김철수│  │  1 │ 1  │ 10 │  │ 10 │ 수학    │
│  2 │이영희│  │  2 │ 1  │ 20 │  │ 20 │ 영어    │
└────┴─────┘  │  3 │ 2  │ 10 │  │ 30 │ 과학    │
              └────┴────┴────┘  └────┴────────┘
```

---

## 💻 Part 2: SQL 기초

### 2.1 SQL이란?

**SQL (Structured Query Language)**:
- 데이터베이스 조작 언어
- 거의 모든 RDBMS에서 사용
- 비교적 쉬운 영어 문장 구조

**SQL 종류**:
```
DDL (Data Definition Language):
- CREATE, ALTER, DROP
- 테이블 구조 정의

DML (Data Manipulation Language):
- SELECT, INSERT, UPDATE, DELETE
- 데이터 조작

DCL (Data Control Language):
- GRANT, REVOKE
- 권한 관리
```

### 2.2 기본 SELECT 문

#### SELECT 기본 구조
```sql
SELECT 컬럼명
FROM 테이블명
WHERE 조건
ORDER BY 정렬기준;
```

#### 실습 예제

**1. 모든 고객 조회**:
```sql
SELECT * FROM customers;
```
결과:
```
┌────┬──────┬─────────────┬────────────┐
│ ID │ 이름  │    이메일    │   전화번호  │
├────┼──────┼─────────────┼────────────┤
│  1 │ 김철수│ kim@email.com│ 010-1234-5678│
│  2 │ 이영희│ lee@email.com│ 010-2345-6789│
│  3 │ 박민수│ park@email.com│010-3456-7890│
└────┴──────┴─────────────┴────────────┘
```

**2. 특정 컬럼만 조회**:
```sql
SELECT name, email FROM customers;
```
결과:
```
┌──────┬─────────────┐
│ 이름  │    이메일    │
├──────┼─────────────┤
│ 김철수│ kim@email.com│
│ 이영희│ lee@email.com│
│ 박민수│ park@email.com│
└──────┴─────────────┘
```

**3. 조건으로 필터링 (WHERE)**:
```sql
SELECT * FROM customers
WHERE name = '김철수';
```

**4. 여러 조건 (AND, OR)**:
```sql
SELECT * FROM orders
WHERE price >= 10000 AND status = '완료';
```

**5. 정렬 (ORDER BY)**:
```sql
SELECT * FROM products
ORDER BY price DESC;  -- 가격 높은 순
```

**6. 중복 제거 (DISTINCT)**:
```sql
SELECT DISTINCT category FROM products;
```

**7. 개수 제한 (LIMIT)**:
```sql
SELECT * FROM products
ORDER BY price DESC
LIMIT 10;  -- 상위 10개
```

### 2.3 집계 함수

#### 주요 집계 함수

```sql
-- 개수
SELECT COUNT(*) FROM customers;
SELECT COUNT(DISTINCT category) FROM products;

-- 합계
SELECT SUM(price) FROM orders;

-- 평균
SELECT AVG(price) FROM products;

-- 최대/최소
SELECT MAX(price), MIN(price) FROM products;
```

#### GROUP BY

**카테고리별 상품 개수**:
```sql
SELECT category, COUNT(*) as count
FROM products
GROUP BY category;
```
결과:
```
┌──────────┬───────┐
│ category │ count │
├──────────┼───────┤
│ 전자제품  │   50  │
│ 의류     │   30  │
│ 식품     │   20  │
└──────────┴───────┘
```

**고객별 주문 총액**:
```sql
SELECT customer_id, SUM(price) as total
FROM orders
GROUP BY customer_id
HAVING total >= 100000;  -- 10만원 이상만
```

### 2.4 JOIN (조인)

#### INNER JOIN

**고객과 주문 정보 함께 조회**:
```sql
SELECT 
    customers.name,
    orders.order_date,
    orders.price
FROM customers
INNER JOIN orders ON customers.id = orders.customer_id;
```
결과:
```
┌──────┬────────────┬────────┐
│ 이름  │  주문일     │  금액   │
├──────┼────────────┼────────┤
│김철수│ 2024-01-01 │ 50,000 │
│김철수│ 2024-01-05 │ 30,000 │
│이영희│ 2024-01-02 │ 45,000 │
└──────┴────────────┴────────┘
```

**조인 시각화**:
```
customers            orders
┌────┬──────┐      ┌────┬───────────┬───────┐
│ ID │ 이름  │      │ ID │ customer_id│ price│
├────┼──────┤      ├────┼───────────┼───────┤
│  1 │ 김철수│ ──→ │ 10 │     1     │50,000│
│  2 │ 이영희│ ──→ │ 11 │     2     │45,000│
│  3 │ 박민수│      │ 12 │     1     │30,000│
└────┴──────┘      └────┴───────────┴───────┘
                    (customer_id = 1인 행과 매칭)
```

#### LEFT JOIN

**주문이 없는 고객도 포함**:
```sql
SELECT 
    customers.name,
    orders.order_date,
    orders.price
FROM customers
LEFT JOIN orders ON customers.id = orders.customer_id;
```
결과:
```
┌──────┬────────────┬────────┐
│ 이름  │  주문일     │  금액   │
├──────┼────────────┼────────┤
│김철수│ 2024-01-01 │ 50,000 │
│김철수│ 2024-01-05 │ 30,000 │
│이영희│ 2024-01-02 │ 45,000 │
│박민수│    NULL    │  NULL  │ ← 주문 없음
└──────┴────────────┴────────┘
```

### 2.5 INSERT, UPDATE, DELETE

#### INSERT (데이터 삽입)
```sql
-- 단일 삽입
INSERT INTO customers (name, email, phone)
VALUES ('정수진', 'jung@email.com', '010-4567-8901');

-- 다중 삽입
INSERT INTO products (name, category, price)
VALUES 
    ('노트북', '전자제품', 1200000),
    ('마우스', '전자제품', 30000),
    ('키보드', '전자제품', 80000);
```

#### UPDATE (데이터 수정)
```sql
-- 특정 행 업데이트
UPDATE customers
SET email = 'new_email@email.com'
WHERE id = 1;

-- 여러 컬럼 업데이트
UPDATE products
SET price = price * 0.9,  -- 10% 할인
    stock = stock - 1
WHERE id = 5;
```

**⚠️ 주의**: WHERE 없으면 모든 행이 변경됨!
```sql
-- 위험! 모든 고객 이메일이 바뀜
UPDATE customers
SET email = 'test@email.com';
```

#### DELETE (데이터 삭제)
```sql
-- 특정 행 삭제
DELETE FROM orders
WHERE id = 10;

-- 조건으로 삭제
DELETE FROM products
WHERE stock = 0 AND discontinued = true;
```

**⚠️ 주의**: WHERE 없으면 모든 행이 삭제됨!
```sql
-- 위험! 모든 데이터 삭제
DELETE FROM customers;
```

### 2.6 실습 데이터셋

#### 온라인 쇼핑몰 데이터베이스

**테이블 생성**:
```sql
-- 고객 테이블
CREATE TABLE customers (
    id INTEGER PRIMARY KEY,
    name TEXT NOT NULL,
    email TEXT UNIQUE,
    phone TEXT,
    created_at DATE DEFAULT CURRENT_DATE
);

-- 상품 테이블
CREATE TABLE products (
    id INTEGER PRIMARY KEY,
    name TEXT NOT NULL,
    category TEXT,
    price INTEGER,
    stock INTEGER DEFAULT 0
);

-- 주문 테이블
CREATE TABLE orders (
    id INTEGER PRIMARY KEY,
    customer_id INTEGER,
    order_date DATE DEFAULT CURRENT_DATE,
    total_price INTEGER,
    status TEXT DEFAULT '대기중',
    FOREIGN KEY (customer_id) REFERENCES customers(id)
);

-- 주문 상세 테이블
CREATE TABLE order_items (
    id INTEGER PRIMARY KEY,
    order_id INTEGER,
    product_id INTEGER,
    quantity INTEGER,
    price INTEGER,
    FOREIGN KEY (order_id) REFERENCES orders(id),
    FOREIGN KEY (product_id) REFERENCES products(id)
);
```

#### 샘플 데이터 삽입
```sql
-- 고객 데이터
INSERT INTO customers (name, email, phone) VALUES
('김철수', 'kim@email.com', '010-1234-5678'),
('이영희', 'lee@email.com', '010-2345-6789'),
('박민수', 'park@email.com', '010-3456-7890');

-- 상품 데이터
INSERT INTO products (name, category, price, stock) VALUES
('노트북', '전자제품', 1200000, 10),
('마우스', '전자제품', 30000, 50),
('키보드', '전자제품', 80000, 30),
('모니터', '전자제품', 300000, 20),
('티셔츠', '의류', 25000, 100);
```

#### 실습 쿼리 문제

**1. 전자제품 카테고리의 평균 가격은?**
```sql
SELECT AVG(price) as avg_price
FROM products
WHERE category = '전자제품';
```

**2. 고객별 총 주문 금액 (상위 3명)**
```sql
SELECT 
    c.name,
    SUM(o.total_price) as total
FROM customers c
INNER JOIN orders o ON c.id = o.customer_id
GROUP BY c.name
ORDER BY total DESC
LIMIT 3;
```

**3. 재고가 10개 이하인 상품 목록**
```sql
SELECT name, stock
FROM products
WHERE stock <= 10
ORDER BY stock ASC;
```

---

## 📐 Part 3: ER 다이어그램

### 3.1 ER 다이어그램이란?

**Entity-Relationship Diagram**:
- 데이터베이스 구조를 시각적으로 표현
- 엔티티(Entity)와 관계(Relationship) 표시
- 데이터베이스 설계의 청사진

#### 기본 요소

**엔티티 (Entity)**:
```
┌─────────────┐
│   고객      │  ← 사각형
│   (Customer)│
└─────────────┘
```

**속성 (Attribute)**:
```
       ┌───────┐
       │  이름  │  ← 타원
       └───────┘
           │
       ┌─────────┐
       │  고객    │
       └─────────┘
           │
       ┌───────┐
       │ 이메일 │
       └───────┘
```

**관계 (Relationship)**:
```
┌────────┐      ◇주문◇      ┌────────┐
│  고객   │────────────────│  상품   │
└────────┘                 └────────┘
           ← 마름모
```

### 3.2 Crow's Foot 표기법

#### 카디널리티 표시

```
일대일 (1:1)
├────────┤
│        │

일대다 (1:N)
├────────┼<
│        ││

다대다 (N:M)
>┼──────┼<
││      ││
```

#### 실습 예제: 온라인 서점

```
[저자]────◇작성◇────<[책]>────◇포함◇────[주문 상세]
 1:N                  1:N                 N:1
                                          ││
                                          ││
                                          ││
[고객]────◇생성◇────<[주문]>─────────────┘
 1:N
```

**설명**:
- 1명의 저자는 여러 책을 작성 (1:N)
- 1권의 책은 1명의 저자만 (간소화)
- 1개 주문은 여러 책 포함 (N:M, 주문 상세로 분해)
- 1명의 고객은 여러 주문 (1:N)

### 3.3 ER 다이어그램 작성 연습

#### 시나리오: 병원 예약 시스템

**요구사항**:
- 환자가 의사를 예약
- 1명의 의사는 여러 환자 진료
- 1명의 환자는 여러 예약 가능
- 예약에는 날짜, 시간 정보

**ER 다이어그램**:
```
[환자]                [예약]               [의사]
├────────┐           ├────────┐          ├────────┐
│ ID     │           │ ID     │          │ ID     │
│ 이름    │           │ 환자ID  │          │ 이름    │
│ 전화번호│───<───────│ 의사ID  │───>──────│ 전문분야│
│ 생년월일│    N:1    │ 예약일시│   N:1    │ 전화번호│
└────────┘           │ 상태    │          └────────┘
                     └────────┘
```

**SQL 테이블**:
```sql
CREATE TABLE patients (
    id INTEGER PRIMARY KEY,
    name TEXT NOT NULL,
    phone TEXT,
    birth_date DATE
);

CREATE TABLE doctors (
    id INTEGER PRIMARY KEY,
    name TEXT NOT NULL,
    specialty TEXT,
    phone TEXT
);

CREATE TABLE appointments (
    id INTEGER PRIMARY KEY,
    patient_id INTEGER,
    doctor_id INTEGER,
    appointment_datetime DATETIME,
    status TEXT DEFAULT '예약중',
    FOREIGN KEY (patient_id) REFERENCES patients(id),
    FOREIGN KEY (doctor_id) REFERENCES doctors(id)
);
```

---

## 🆚 Part 4: NoSQL vs RDBMS

### 4.1 NoSQL이란?

**NoSQL (Not Only SQL)**:
- 관계형 DB가 아닌 데이터베이스
- 유연한 스키마
- 수평 확장 용이

**NoSQL 종류**:
```
Document DB: MongoDB, Couchbase
- JSON 형식 문서 저장

Key-Value: Redis, DynamoDB
- 키-값 쌍으로 저장

Column-Family: Cassandra, HBase
- 컬럼 기반 저장

Graph: Neo4j, ArangoDB
- 그래프 구조
```

### 4.2 RDBMS vs NoSQL 비교

| 항목 | RDBMS | NoSQL |
|-----|-------|-------|
| **스키마** | 고정 (엄격) | 유연 (자유) |
| **확장** | 수직 (Scale-up) | 수평 (Scale-out) |
| **트랜잭션** | ACID 보장 | 대부분 BASE |
| **쿼리** | SQL (표준화) | 제품마다 다름 |
| **데이터 구조** | 테이블 (관계) | 문서, Key-Value 등 |
| **조인** | 지원 | 대부분 미지원 |
| **적합** | 정형 데이터 | 비정형 데이터 |

#### ACID vs BASE

**ACID (RDBMS)**:
```
Atomicity (원자성): 전부 성공 or 전부 실패
Consistency (일관성): 데이터 일관성 유지
Isolation (격리성): 동시 실행 격리
Durability (지속성): 영구 저장
```

**BASE (NoSQL)**:
```
Basically Available: 기본적으로 가용
Soft state: 유연한 상태
Eventually consistent: 최종적 일관성
```

### 4.3 선택 가이드

#### RDBMS 선택 상황
```
✅ 복잡한 쿼리 필요
✅ 트랜잭션 중요 (금융, 결제)
✅ 정형화된 데이터
✅ 데이터 일관성 필수
✅ 데이터 크기 중간 이하

예: 은행 시스템, ERP, 전자상거래
```

#### NoSQL 선택 상황
```
✅ 대용량 데이터
✅ 빠른 읽기/쓰기
✅ 유연한 스키마 필요
✅ 수평 확장 필요
✅ 비정형 데이터

예: 로그 수집, 실시간 분석, 소셜 미디어
```

#### 실제 사례

**전자상거래 사이트**:
```
RDBMS (MySQL):
- 주문 정보
- 결제 내역
- 재고 관리
→ 트랜잭션 중요

NoSQL (MongoDB):
- 상품 카탈로그
- 사용자 리뷰
- 장바구니
→ 유연한 구조

NoSQL (Redis):
- 세션 정보
- 캐시
→ 빠른 액세스
```

---

## 👔 Part 5: PM 관점의 데이터베이스

### 5.1 PM이 확인할 사항

#### 데이터 모델 검토 체크리스트

**비즈니스 요구사항**:
```
☐ 모든 엔티티가 명확히 정의되었는가?
☐ 관계가 비즈니스 로직과 일치하는가?
☐ 필수 데이터가 누락되지 않았는가?
```

**데이터 무결성**:
```
☐ 기본키가 모든 테이블에 있는가?
☐ 외래키 제약조건이 올바른가?
☐ NULL 허용 여부가 적절한가?
```

**성능**:
```
☐ 자주 조회하는 컬럼에 인덱스가 있는가?
☐ 조인이 너무 많지 않은가? (3개 초과 주의)
☐ 대용량 데이터 처리 계획이 있는가?
```

**보안**:
```
☐ 민감한 정보 암호화 계획이 있는가?
☐ 개인정보 보호 규정 준수하는가?
☐ 접근 권한 관리 계획이 있는가?
```

### 5.2 데이터베이스 관련 의사결정

#### 시나리오 1: RDBMS vs NoSQL 선택

**상황**:
```
스타트업이 소셜 미디어 플랫폼 개발
- 사용자 프로필
- 게시물
- 댓글
- 좋아요
- 팔로우 관계
```

**PM의 질문**:
```
1. 예상 사용자 수는?
   - 1년 내 100만 → RDBMS 가능
   - 1년 내 1000만 → NoSQL 고려

2. 데이터 구조가 자주 변경되는가?
   - 예 → NoSQL (유연성)
   - 아니오 → RDBMS (안정성)

3. 복잡한 쿼리가 필요한가?
   - 예 → RDBMS
   - 아니오 → NoSQL

4. 예산은?
   - 제한적 → PostgreSQL (무료)
   - 충분 → 요구사항에 맞게
```

**결정**:
```
하이브리드 접근:
- 사용자 정보, 인증: PostgreSQL
- 게시물, 댓글: MongoDB
- 세션, 캐시: Redis
```

#### 시나리오 2: 성능 문제

**상황**:
```
개발팀: "쿼리가 너무 느려요 (5초 이상)"
```

**PM의 대응**:
```
1. 현황 파악
   - 어떤 쿼리가 느린가?
   - 데이터 양은?
   - 조인 개수는?

2. 원인 분석
   - 인덱스 누락?
   - 비효율적 쿼리?
   - 하드웨어 한계?

3. 해결 방안
   단기: 인덱스 추가, 쿼리 최적화
   중기: 캐싱 도입
   장기: 데이터베이스 확장, 샤딩
```

### 5.3 데이터베이스 용량 계획

#### 용량 산정 예제

**온라인 쇼핑몰**:
```
예상 사용자: 100만 명
주문 평균: 월 2회/인
주문 상세: 평균 3개 상품/주문

연간 데이터:
- 사용자: 100만 × 1KB = 1GB
- 주문: 100만 × 24 × 2KB = 48GB
- 주문 상세: 100만 × 24 × 3 × 1KB = 72GB
- 총: 약 121GB/년

3년 보관: 약 363GB
여유 50%: 약 545GB 필요
```

---

## 💼 6. 실습 과제

### 과제 1: SQL 기초 연습

**온라인 도구**: https://sqliteonline.com/

**과제**:
1. 위의 쇼핑몰 데이터베이스 생성
2. 다음 쿼리 작성 및 실행:
   - 모든 고객 목록
   - 가격 50,000원 이상 상품
   - 고객별 주문 개수
   - 카테고리별 평균 가격
   - 주문이 없는 고객 찾기

**제출물**:
- 쿼리 스크립트
- 실행 결과 스크린샷

### 과제 2: ER 다이어그램 작성

**시나리오**: 도서관 관리 시스템

**요구사항**:
- 회원이 책을 대출
- 1권의 책은 여러 저자 가능
- 대출 기록 (대출일, 반납일)
- 연체료 계산

**과제**:
1. ER 다이어그램 작성 (손그림 or 도구)
2. 테이블 생성 SQL 작성
3. 샘플 데이터 삽입
4. 주요 쿼리 5개 작성

**제출물**:
- ER 다이어그램 이미지
- SQL 스크립트
- 설계 설명 (1페이지)

### 과제 3: NoSQL vs RDBMS 선택

**시나리오 3개 제공**:
1. 블로그 플랫폼
2. 실시간 채팅 앱
3. 회계 시스템

**과제**:
각 시나리오에 대해:
- RDBMS와 NoSQL 중 선택
- 선택 이유 (3가지 이상)
- 예상 문제점 및 대응

**제출물**:
- 분석 보고서 (2-3페이지)

---

## 🎯 7. 자가 점검 퀴즈

### 객관식

**1. 데이터베이스의 테이블에서 각 행을 고유하게 식별하는 것은?**
- A) 외래키
- B) 기본키
- C) 인덱스
- D) 속성

**정답**: B

---

**2. SQL에서 데이터를 조회하는 명령어는?**
- A) INSERT
- B) UPDATE
- C) SELECT
- D) DELETE

**정답**: C

---

**3. 다음 중 NoSQL 데이터베이스가 아닌 것은?**
- A) MongoDB
- B) Redis
- C) MySQL
- D) Cassandra

**정답**: C

---

**4. RDBMS의 ACID 원칙에 해당하지 않는 것은?**
- A) Atomicity
- B) Consistency
- C) Isolation
- D) Availability

**정답**: D (Availability는 BASE 원칙)

---

**5. LEFT JOIN과 INNER JOIN의 차이는?**
- A) LEFT JOIN은 왼쪽 테이블의 모든 행 포함
- B) INNER JOIN이 더 빠름
- C) LEFT JOIN은 사용 불가
- D) 차이 없음

**정답**: A

---

### 서술형

**6. 관계형 데이터베이스의 정규화가 필요한 이유를 3가지 설명하시오.**

**모범 답안**:
1. **데이터 중복 제거**: 같은 정보가 여러 곳에 저장되는 것 방지
2. **무결성 유지**: 데이터 수정 시 일관성 보장
3. **저장 공간 절약**: 중복 데이터 제거로 용량 감소

---

**7. 1:N 관계와 N:M 관계의 차이를 예시를 들어 설명하시오.**

**모범 답안**:

**1:N (일대다)**:
- 예: 1명의 고객 - N개의 주문
- 외래키로 직접 표현 가능

**N:M (다대다)**:
- 예: N명의 학생 - M개의 강의
- 중간 테이블 필요 (수강 신청 테이블)
- 양쪽 모두 1:N 관계로 분해

---

**8. NoSQL을 선택해야 하는 3가지 상황을 설명하시오.**

**모범 답안**:
1. **대용량 데이터**: 수억 건 이상의 데이터 처리 필요
2. **유연한 스키마**: 데이터 구조가 자주 변경되는 경우
3. **수평 확장**: 서버를 추가하여 확장해야 하는 경우

---

**9. PM이 데이터베이스 설계를 검토할 때 확인해야 할 5가지 체크 포인트를 나열하시오.**

**모범 답안**:
1. 비즈니스 요구사항 충족 여부
2. 데이터 무결성 (기본키, 외래키)
3. 성능 (인덱스, 쿼리 효율성)
4. 보안 (암호화, 접근 권한)
5. 확장성 (미래 데이터 증가 대비)

---

**10. 데이터베이스 성능이 느릴 때 PM이 취할 수 있는 3단계 대응을 설명하시오.**

**모범 답안**:

**1단계: 즉시 조치**
- 느린 쿼리 식별
- 인덱스 추가
- 쿼리 최적화

**2단계: 중기 대응**
- 캐싱 도입 (Redis 등)
- 데이터베이스 튜닝
- 읽기 전용 복제본 추가

**3단계: 장기 계획**
- 샤딩 (데이터 분산)
- NoSQL 도입 고려
- 아키텍처 재설계

---

## 📚 8. 핵심 용어 정리

| 한글 | 영문 | 설명 |
|-----|------|------|
| 데이터베이스 | Database | 조직화된 데이터 집합 |
| 테이블 | Table | 데이터를 저장하는 구조 |
| 행 | Row/Record | 하나의 데이터 항목 |
| 열 | Column/Field | 데이터 속성 |
| 기본키 | Primary Key | 고유 식별자 |
| 외래키 | Foreign Key | 다른 테이블 참조 |
| 인덱스 | Index | 빠른 검색을 위한 구조 |
| 정규화 | Normalization | 중복 제거 설계 |
| 트랜잭션 | Transaction | 원자적 작업 단위 |

---

## 🎓 다음 주 예고

**Week 15: 클라우드 컴퓨팅**

- AWS Free Tier 활용
- 3대 클라우드 비교
- FinOps 기초

---

**강의 자료 버전**: 1.0  
**최종 업데이트**: 2026년 1월  
**작성자**: PM Expert Training Team
