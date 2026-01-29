# Week 16: 네트워크 (Network)

## 📝 학습 목표
- 네트워크의 기본 개념과 구조 이해
- OSI 7계층 및 TCP/IP 모델 학습
- IP 주소, 서브넷, 라우팅 이해
- 네트워크 보안 및 프로토콜 파악

## 📚 주요 내용

### 1. 네트워크 기초

#### 1.1 네트워크란?
- **정의**: 두 개 이상의 컴퓨터가 통신할 수 있도록 연결된 시스템
- **목적**:
  - 리소스 공유 (파일, 프린터)
  - 데이터 통신
  - 원격 접근
  - 협업

#### 1.2 네트워크 유형

**LAN (Local Area Network):**
- 제한된 지역 (사무실, 건물)
- 고속, 저비용
- 이더넷, Wi-Fi

**WAN (Wide Area Network):**
- 넓은 지역 (도시, 국가)
- 저속, 고비용
- 인터넷

**MAN (Metropolitan Area Network):**
- 도시 규모
- LAN과 WAN의 중간

**PAN (Personal Area Network):**
- 개인 기기 간 (블루투스)

#### 1.3 네트워크 토폴로지
```
버스형:  ─────●─────●─────●─────

링형:    ●─────●
        │       │
        ●─────●

스타형:      ●
           ╱│╲
          ● ● ●

메시형:  ●───●
        │╲ ╱│
        │ ╳ │
        │╱ ╲│
        ●───●
```

### 2. OSI 7계층 모델

#### 2.1 OSI 모델 개요
```
계층 7: 응용 계층 (Application)
계층 6: 표현 계층 (Presentation)
계층 5: 세션 계층 (Session)
계층 4: 전송 계층 (Transport)
계층 3: 네트워크 계층 (Network)
계층 2: 데이터 링크 계층 (Data Link)
계층 1: 물리 계층 (Physical)
```

#### 2.2 각 계층 설명

**계층 1: 물리 계층 (Physical Layer)**
- 비트 전송
- 물리적 매체 (케이블, 전파)
- 장비: 허브, 리피터
- 예: 이더넷 케이블, 광섬유

**계층 2: 데이터 링크 계층 (Data Link Layer)**
- 프레임 전송
- MAC 주소 사용
- 오류 검출
- 장비: 스위치, 브리지
- 프로토콜: Ethernet, Wi-Fi

**계층 3: 네트워크 계층 (Network Layer)**
- 패킷 라우팅
- IP 주소 사용
- 최적 경로 선택
- 장비: 라우터
- 프로토콜: IP, ICMP

**계층 4: 전송 계층 (Transport Layer)**
- 종단 간 통신
- 데이터 분할 및 재조립
- 오류 복구
- 프로토콜: TCP, UDP
- 포트 번호 사용

**계층 5: 세션 계층 (Session Layer)**
- 세션 관리
- 연결 설정/해제
- 동기화

**계층 6: 표현 계층 (Presentation Layer)**
- 데이터 형식 변환
- 암호화/복호화
- 압축

**계층 7: 응용 계층 (Application Layer)**
- 사용자 인터페이스
- 네트워크 서비스 제공
- 프로토콜: HTTP, FTP, SMTP, DNS

#### 2.3 데이터 전송 과정
```
발신자                       수신자
앱 데이터  → [L7] HTTP   → [L7] → 앱 데이터
           [L4] TCP     → [L4]
           [L3] IP      → [L3]
           [L2] Ethernet→ [L2]
           [L1] 비트    → [L1]
```

### 3. TCP/IP 모델

#### 3.1 TCP/IP 4계층
```
OSI 모델              TCP/IP 모델
응용/표현/세션  →     응용 계층 (Application)
전송            →     전송 계층 (Transport)
네트워크        →     인터넷 계층 (Internet)
데이터링크/물리 →     네트워크 접근 계층 (Network Access)
```

#### 3.2 주요 프로토콜

**응용 계층:**
- **HTTP/HTTPS**: 웹
- **FTP**: 파일 전송
- **SMTP**: 이메일 발송
- **POP3/IMAP**: 이메일 수신
- **DNS**: 도메인 이름 해석
- **SSH**: 원격 접속

**전송 계층:**
- **TCP (Transmission Control Protocol)**:
  - 연결 지향
  - 신뢰성 보장 (오류 검출, 재전송)
  - 순서 보장
  - 느림
  - 예: 웹, 이메일, 파일 전송

- **UDP (User Datagram Protocol)**:
  - 비연결 지향
  - 신뢰성 없음
  - 빠름
  - 예: 스트리밍, VoIP, DNS

**인터넷 계층:**
- **IP (Internet Protocol)**: 주소 지정 및 라우팅
- **ICMP**: 오류 보고 (ping)
- **ARP**: IP → MAC 주소 변환

### 4. IP 주소

#### 4.1 IPv4
- 32비트 주소
- 점으로 구분된 4개의 8비트 (옥텟)
- 예: `192.168.1.100`
- 약 43억 개 주소

**주소 클래스:**
| 클래스 | 범위 | 용도 |
|-------|------|------|
| A | 1.0.0.0 ~ 126.255.255.255 | 대규모 네트워크 |
| B | 128.0.0.0 ~ 191.255.255.255 | 중규모 네트워크 |
| C | 192.0.0.0 ~ 223.255.255.255 | 소규모 네트워크 |
| D | 224.0.0.0 ~ 239.255.255.255 | 멀티캐스트 |
| E | 240.0.0.0 ~ 255.255.255.255 | 예약 |

**사설 IP (Private IP):**
- 10.0.0.0 ~ 10.255.255.255 (Class A)
- 172.16.0.0 ~ 172.31.255.255 (Class B)
- 192.168.0.0 ~ 192.168.255.255 (Class C)
- 인터넷에서 라우팅 불가
- NAT 필요

**공인 IP (Public IP):**
- 인터넷에서 라우팅 가능
- ISP에서 할당

#### 4.2 IPv6
- 128비트 주소
- 콜론으로 구분된 8개의 16비트
- 예: `2001:0db8:85a3:0000:0000:8a2e:0370:7334`
- 약 340간(undecillion) 개 주소
- IPv4 고갈 문제 해결

#### 4.3 서브넷 마스크
- 네트워크 부분과 호스트 부분 구분
- 예: `255.255.255.0` 또는 `/24`

**예시:**
```
IP 주소:        192.168.1.100
서브넷 마스크:  255.255.255.0
네트워크 주소:  192.168.1.0
브로드캐스트:   192.168.1.255
호스트 범위:    192.168.1.1 ~ 192.168.1.254
```

**CIDR 표기법:**
- `192.168.1.0/24`
- /24는 앞의 24비트가 네트워크 부분

### 5. 네트워크 장비

#### 5.1 스위치 (Switch)
- 데이터 링크 계층 (L2)
- MAC 주소 기반 전달
- 충돌 도메인 분리
- LAN 내부 연결

#### 5.2 라우터 (Router)
- 네트워크 계층 (L3)
- IP 주소 기반 라우팅
- 네트워크 간 연결
- 브로드캐스트 도메인 분리

#### 5.3 방화벽 (Firewall)
- 트래픽 필터링
- 접근 제어
- 보안 정책 적용
- 종류: 패킷 필터링, 상태 기반, 애플리케이션

#### 5.4 로드 밸런서 (Load Balancer)
- 트래픽 분산
- 고가용성
- 서버 부하 분산
- 알고리즘: Round Robin, Least Connection

#### 5.5 기타 장비
- **허브 (Hub)**: 물리 계층, 모든 포트로 전송 (구식)
- **리피터**: 신호 증폭
- **게이트웨이**: 프로토콜 변환
- **프록시 서버**: 중계 서버

### 6. DNS (Domain Name System)

#### 6.1 DNS 개요
- 도메인 이름 → IP 주소 변환
- 계층적 구조
- 분산 데이터베이스

**DNS 계층:**
```
.                    (루트)
  ↓
.com   .net   .org   (최상위 도메인, TLD)
  ↓
example.com          (2차 도메인)
  ↓
www.example.com      (서브도메인)
```

#### 6.2 DNS 레코드 종류
- **A 레코드**: 도메인 → IPv4
- **AAAA 레코드**: 도메인 → IPv6
- **CNAME**: 도메인 별칭
- **MX**: 메일 서버
- **NS**: 네임 서버
- **TXT**: 텍스트 정보 (SPF, DKIM)

#### 6.3 DNS 조회 과정
```
1. 사용자: www.example.com 입력
2. 로컬 DNS 캐시 확인
3. 루트 DNS 서버 조회
4. .com TLD 서버 조회
5. example.com 네임 서버 조회
6. IP 주소 반환: 93.184.216.34
```

### 7. HTTP/HTTPS

#### 7.1 HTTP (HyperText Transfer Protocol)
- 웹 통신 프로토콜
- 요청-응답 모델
- 상태 비저장 (Stateless)
- 포트 80

**HTTP 메서드:**
- **GET**: 리소스 조회
- **POST**: 리소스 생성
- **PUT**: 리소스 전체 수정
- **PATCH**: 리소스 일부 수정
- **DELETE**: 리소스 삭제

**HTTP 상태 코드:**
- **2xx**: 성공 (200 OK, 201 Created)
- **3xx**: 리다이렉션 (301 Moved, 302 Found)
- **4xx**: 클라이언트 오류 (400 Bad Request, 404 Not Found)
- **5xx**: 서버 오류 (500 Internal Error, 503 Service Unavailable)

#### 7.2 HTTPS (HTTP Secure)
- HTTP + TLS/SSL
- 데이터 암호화
- 인증서 기반 신뢰
- 포트 443

**TLS/SSL 핸드셰이크:**
```
1. 클라이언트 → 서버: ClientHello
2. 서버 → 클라이언트: ServerHello, 인증서
3. 클라이언트: 인증서 검증
4. 세션 키 교환
5. 암호화 통신 시작
```

### 8. 네트워크 보안

#### 8.1 보안 위협
- **스니핑 (Sniffing)**: 네트워크 트래픽 도청
- **스푸핑 (Spoofing)**: IP/MAC 주소 위조
- **DDoS (Distributed Denial of Service)**: 분산 서비스 거부 공격
- **중간자 공격 (MITM)**: 통신 가로채기
- **SQL Injection**: 데이터베이스 공격
- **XSS (Cross-Site Scripting)**: 스크립트 삽입

#### 8.2 방화벽 (Firewall)
- 트래픽 필터링
- 인바운드/아웃바운드 규칙
- 포트 차단/허용

**방화벽 규칙 예시:**
```
규칙 1: 허용 - TCP 포트 80 (HTTP)
규칙 2: 허용 - TCP 포트 443 (HTTPS)
규칙 3: 허용 - TCP 포트 22 (SSH) - 특정 IP만
규칙 4: 차단 - 나머지 모든 트래픽
```

#### 8.3 VPN (Virtual Private Network)
- 암호화된 터널
- 원격 접속
- 사설망 확장
- 종류: 사이트 간, 원격 액세스

#### 8.4 침입 탐지/방지 시스템
- **IDS (Intrusion Detection System)**: 탐지 및 알림
- **IPS (Intrusion Prevention System)**: 탐지 및 차단

#### 8.5 인증 및 권한
- **인증 (Authentication)**: 신원 확인
  - 비밀번호
  - 이중 인증 (2FA)
  - 인증서
- **권한 (Authorization)**: 접근 제어
  - 역할 기반 (RBAC)
  - 최소 권한 원칙

### 9. 네트워크 성능

#### 9.1 주요 지표
- **대역폭 (Bandwidth)**: 초당 전송 가능한 데이터량 (bps)
- **지연 시간 (Latency)**: 패킷 전송 시간 (ms)
- **처리량 (Throughput)**: 실제 전송량
- **패킷 손실 (Packet Loss)**: 손실된 패킷 비율

#### 9.2 성능 최적화
- **CDN (Content Delivery Network)**:
  - 콘텐츠 분산 배포
  - 지연 시간 감소
  - 캐싱

- **로드 밸런싱**:
  - 부하 분산
  - 고가용성
  - 확장성

- **캐싱**:
  - 자주 사용하는 데이터 저장
  - 데이터베이스 부하 감소
  - 응답 속도 향상

- **압축**:
  - 데이터 크기 감소
  - 전송 시간 단축
  - Gzip, Brotli

### 10. 네트워크 진단 도구

#### 10.1 기본 명령어

**ping:**
```bash
ping google.com
# ICMP 패킷 전송, 연결 확인
```

**traceroute/tracert:**
```bash
traceroute google.com
# 경로 추적
```

**nslookup/dig:**
```bash
nslookup google.com
# DNS 조회
```

**netstat:**
```bash
netstat -an
# 네트워크 연결 상태
```

**ipconfig/ifconfig:**
```bash
ipconfig /all  # Windows
ifconfig       # Linux/Mac
# IP 주소 확인
```

#### 10.2 네트워크 분석 도구
- **Wireshark**: 패킷 캡처 및 분석
- **tcpdump**: 커맨드라인 패킷 캡처
- **nmap**: 포트 스캔
- **iperf**: 대역폭 측정

### 11. 최신 네트워크 기술

#### 11.1 5G
- 5세대 이동통신
- 초고속, 초저지연
- IoT 지원
- 네트워크 슬라이싱

#### 11.2 SD-WAN (Software-Defined WAN)
- 소프트웨어 정의 네트워크
- 중앙 집중 관리
- 자동화
- 비용 절감

#### 11.3 IoT (Internet of Things)
- 사물 인터넷
- 센서 네트워크
- 프로토콜: MQTT, CoAP
- 보안 중요

#### 11.4 네트워크 가상화
- NFV (Network Functions Virtualization)
- 가상 라우터, 방화벽
- 유연성 및 확장성

### 12. PM이 알아야 할 네트워크 지식

#### 12.1 네트워크 프로젝트 관리
- 네트워크 설계 검토
- 대역폭 요구사항
- 보안 요구사항
- 성능 목표 (지연, 처리량)

#### 12.2 네트워크 용어 이해
- ISP (Internet Service Provider)
- SLA (Service Level Agreement)
- Uptime/Downtime
- 대역폭, 지연 시간

#### 12.3 네트워크 리스크
- 네트워크 장애
- 보안 침해
- DDoS 공격
- 대역폭 부족

#### 12.4 네트워크 비용
- 회선 비용
- 장비 비용
- 운영 비용
- 클라우드 네트워크 비용

## 💡 실습 과제

### 과제 1: 네트워크 진단
본인의 네트워크 환경을 진단하고 보고서를 작성하시오:
- IP 주소, 서브넷 마스크, 게이트웨이 확인
- DNS 서버 확인
- 특정 사이트에 대한 ping 및 traceroute 실행
- 결과 스크린샷 및 분석

### 과제 2: OSI 7계층 이해
특정 웹 페이지 접속 시 OSI 7계층에서 일어나는 일을 단계별로 설명하시오 (A4 1페이지).

### 과제 3: 네트워크 보안 계획
소규모 사무실의 네트워크 보안 계획을 수립하시오:
- 방화벽 규칙
- VPN 설정
- 접근 제어
- 백업 및 복구 계획

## 📖 참고 자료
- "컴퓨터 네트워킹" by James F. Kurose
- "TCP/IP 완벽 가이드" by Charles M. Kozierok
- "Network Warrior" by Gary A. Donahue
- Cisco Networking Academy: https://www.netacad.com/

## ✅ 자가 점검 퀴즈

1. OSI 7계층의 각 계층 이름과 역할은?
2. TCP와 UDP의 차이점은?
3. 사설 IP와 공인 IP의 차이는?
4. DNS의 역할과 작동 원리는?
5. HTTP와 HTTPS의 차이점은?

## 📝 핵심 용어
- **OSI 7계층**: 네트워크 통신 표준 모델
- **TCP/IP**: 인터넷 프로토콜 스위트
- **IP 주소**: 네트워크 장치의 고유 주소
- **DNS**: 도메인 이름 시스템
- **방화벽 (Firewall)**: 네트워크 보안 장비
- **라우터 (Router)**: 네트워크 간 패킷 전달
- **VPN**: 가상 사설망
- **HTTPS**: 보안 HTTP

## 수료 안내
이것으로 16주 PM 전문가 양성 프로그램을 모두 마칩니다.
수료 조건을 충족한 분들은 수료증을 발급받으실 수 있습니다.
