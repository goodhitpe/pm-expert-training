# Week 15: 클라우드 컴퓨팅 기초 상세 강의 자료

## 📚 학습 목표 (상세)
1. **클라우드 컴퓨팅 기본 개념** 이해 (IaaS, PaaS, SaaS)
2. **3대 클라우드 플랫폼** 비교 (AWS, Azure, GCP)
3. **AWS Free Tier** 활용 및 주요 서비스 실습
4. **FinOps 기초** - 클라우드 비용 최적화
5. **PM 관점의 클라우드 아키텍처** 검토
6. **클라우드 마이그레이션** 전략 이해

---

## ☁️ Part 1: 클라우드 컴퓨팅 기초

### 1.1 클라우드란?

#### 전통적 IT vs 클라우드

**전통적 IT (온프레미스)**:
```
문제점:
❌ 초기 투자 비용 높음 (서버, 네트워크 장비)
❌ 용량 예측 어려움 (과다 또는 부족)
❌ 유지보수 부담 (하드웨어, OS, 보안)
❌ 확장에 시간 소요 (주문 → 설치 → 설정)
❌ 재해 복구 비용 높음
```

**클라우드**:
```
장점:
✅ 사용한 만큼만 비용 지불
✅ 필요시 즉시 확장/축소
✅ 유지보수 부담 감소
✅ 전세계 어디서나 접근
✅ 높은 가용성 및 복구력
```

### 1.2 클라우드 서비스 모델

#### 서비스 계층

```
SaaS (Software as a Service)
예: Gmail, Office 365, Salesforce
→ 소프트웨어를 서비스로 사용
   PM이 관리: 없음 (모두 제공자가 관리)

PaaS (Platform as a Service)
예: Heroku, Google App Engine
→ 플랫폼(개발 환경)을 제공
   PM이 관리: 애플리케이션, 데이터

IaaS (Infrastructure as a Service)
예: AWS EC2, Azure VM
→ 인프라(서버, 네트워크)를 제공
   PM이 관리: OS, 미들웨어, 애플리케이션
```

**비유**:
```
Pizza as a Service

온프레미스 (집에서 피자 만들기):
- 재료 구매, 만들기, 청소 모두 직접

IaaS (피자 반죽만 제공):
- 토핑, 굽기, 서빙 직접

PaaS (피자 반죽 + 오븐 제공):
- 토핑만 선택

SaaS (완성된 피자 배달):
- 먹기만 하면 됨
```

### 1.3 클라우드 배포 모델

**퍼블릭 클라우드 (Public Cloud)**:
```
특징:
- 누구나 사용 가능
- 비용 효율적
- 확장성 높음

예: AWS, Azure, GCP

적합:
- 스타트업
- 웹 서비스
- 개발/테스트 환경
```

**프라이빗 클라우드 (Private Cloud)**:
```
특징:
- 조직 전용
- 보안 강화
- 통제력 높음

예: VMware, OpenStack

적합:
- 금융, 의료 등 규제 산업
- 민감한 데이터 처리
```

**하이브리드 클라우드 (Hybrid Cloud)**:
```
특징:
- 퍼블릭 + 프라이빗 혼합
- 유연성 극대화

예: 
- 프라이빗: 핵심 데이터
- 퍼블릭: 웹 서비스

적합:
- 대기업
- 규제 준수 + 확장성 필요
```

---

## 🌐 Part 2: 3대 클라우드 플랫폼

### 2.1 AWS (Amazon Web Services)

#### 개요
```
시장 점유율: 약 32% (1위)
강점: 가장 많은 서비스, 성숙한 생태계
약점: 복잡한 가격 체계
```

#### 주요 서비스

**컴퓨팅**:
- **EC2** (Elastic Compute Cloud): 가상 서버
- **Lambda**: 서버리스 함수
- **ECS/EKS**: 컨테이너 관리

**스토리지**:
- **S3** (Simple Storage Service): 객체 스토리지
- **EBS**: 블록 스토리지
- **Glacier**: 아카이브 스토리지 (저렴)

**데이터베이스**:
- **RDS**: 관계형 DB 관리
- **DynamoDB**: NoSQL DB
- **Aurora**: 고성능 MySQL/PostgreSQL

**네트워킹**:
- **VPC**: 가상 네트워크
- **CloudFront**: CDN
- **Route 53**: DNS 서비스

### 2.2 Azure (Microsoft Azure)

#### 개요
```
시장 점유율: 약 23% (2위)
강점: Microsoft 제품 통합, 엔터프라이즈 친화적
약점: AWS보다 서비스 적음
```

#### 주요 서비스

**컴퓨팅**:
- **Virtual Machines**: 가상 서버
- **App Service**: 웹 앱 호스팅
- **Azure Functions**: 서버리스

**스토리지**:
- **Blob Storage**: 객체 스토리지
- **Azure Files**: 파일 공유

**데이터베이스**:
- **SQL Database**: 관계형 DB
- **Cosmos DB**: NoSQL DB

**통합**:
- **Active Directory**: 인증/권한
- **Office 365**: 생산성 도구

### 2.3 GCP (Google Cloud Platform)

#### 개요
```
시장 점유율: 약 10% (3위)
강점: AI/ML, 빅데이터 분석, Kubernetes
약점: 엔터프라이즈 생태계 약함
```

#### 주요 서비스

**컴퓨팅**:
- **Compute Engine**: 가상 서버
- **Cloud Functions**: 서버리스
- **GKE** (Kubernetes Engine): 컨테이너

**스토리지**:
- **Cloud Storage**: 객체 스토리지

**데이터베이스**:
- **Cloud SQL**: 관계형 DB
- **Firestore**: NoSQL DB

**AI/ML**:
- **BigQuery**: 빅데이터 분석
- **Vertex AI**: ML 플랫폼
- **TensorFlow**: ML 프레임워크

### 2.4 3사 비교표

| 항목 | AWS | Azure | GCP |
|-----|-----|-------|-----|
| **시장 점유율** | 32% (1위) | 23% (2위) | 10% (3위) |
| **서비스 수** | 200+ | 100+ | 100+ |
| **가격** | 중간 | 높음 | 낮음 |
| **강점** | 가장 많은 서비스 | MS 제품 통합 | AI/ML, K8s |
| **약점** | 복잡함 | 서비스 적음 | 생태계 약함 |
| **적합** | 범용 | 엔터프라이즈 | 데이터 중심 |
| **Free Tier** | 12개월 | 12개월 | 90일 |

### 2.5 선택 가이드

**AWS 선택**:
```
✅ 가장 많은 서비스 필요
✅ 성숙한 생태계 선호
✅ 다양한 리전 필요
✅ 스타트업 (풍부한 자료)
```

**Azure 선택**:
```
✅ Microsoft 제품 사용 중
✅ .NET 개발
✅ 하이브리드 클라우드
✅ 엔터프라이즈 환경
```

**GCP 선택**:
```
✅ AI/ML 프로젝트
✅ 빅데이터 분석
✅ Kubernetes 사용
✅ 비용 절감 중요
```

---

## 🆓 Part 3: AWS Free Tier 실습

### 3.1 AWS 계정 생성

#### 준비물
- 이메일 주소
- 신용카드 (인증용, 무료 범위 내 과금 없음)
- 전화번호

#### 가입 절차
```
1. aws.amazon.com 접속
2. "Create an AWS Account" 클릭
3. 이메일, 비밀번호 입력
4. 연락처 정보 입력
5. 신용카드 정보 입력 (무료 범위 초과 시 청구됨)
6. 신원 확인 (전화 인증)
7. 지원 플랜 선택 (Basic - 무료)
```

⚠️ **주의사항**:
- Free Tier 한도 초과 시 과금됨
- 사용하지 않는 리소스는 즉시 삭제
- Billing Alert 설정 권장

### 3.2 주요 서비스 실습

#### EC2 (가상 서버)

**Free Tier 한도**:
- t2.micro 인스턴스 750시간/월
- Linux 또는 Windows

**실습: 웹 서버 띄우기**:
```
1. EC2 대시보드 → "Launch Instance"
2. AMI 선택: Amazon Linux 2
3. 인스턴스 타입: t2.micro (Free tier eligible)
4. 키 페어 생성 (SSH 접속용)
5. 보안 그룹: HTTP(80), SSH(22) 허용
6. "Launch Instance"
7. 퍼블릭 IP로 접속 확인
```

**비용 절감 팁**:
- 사용하지 않을 때 중지 (Stop)
- 완전히 삭제 (Terminate) 권장

#### S3 (객체 스토리지)

**Free Tier 한도**:
- 5GB 스토리지
- 20,000 GET 요청
- 2,000 PUT 요청

**실습: 정적 웹사이트 호스팅**:
```
1. S3 버킷 생성
   - 버킷 이름: 고유한 이름
   - 리전 선택
   
2. 정적 웹사이트 호스팅 활성화
   - Properties → Static website hosting

3. index.html 업로드

4. 퍼블릭 액세스 설정
   - Bucket Policy 설정

5. 웹사이트 URL로 접속
```

#### RDS (관계형 데이터베이스)

**Free Tier 한도**:
- db.t2.micro 750시간/월
- 20GB 스토리지

**실습: MySQL 데이터베이스 생성**:
```
1. RDS 대시보드 → "Create database"
2. 엔진: MySQL
3. 템플릿: Free tier
4. DB 인스턴스: db.t2.micro
5. 스토리지: 20GB
6. 마스터 사용자 이름/암호 설정
7. 퍼블릭 액세스: Yes (실습용)
8. "Create database"
```

### 3.3 비용 모니터링

#### Billing Alert 설정

```
1. Billing Dashboard → Billing preferences
2. "Receive Free Tier Usage Alerts" 체크
3. 이메일 입력
4. "Save preferences"

CloudWatch로 예산 알림:
1. AWS Budgets → "Create budget"
2. 예산 유형: Cost budget
3. 예산 금액: $10
4. 알림 임계값: 80% ($8)
5. 이메일 알림 설정
```

---

## 💰 Part 4: FinOps (클라우드 비용 최적화)

### 4.1 FinOps란?

**정의**: Financial Operations - 클라우드 재무 관리

**핵심 원칙**:
```
1. 가시성: 비용 투명하게 추적
2. 최적화: 불필요한 비용 제거
3. 협업: 개발/재무/운영 팀 협력
```

### 4.2 비용 절감 전략

#### 1. 적절한 인스턴스 크기 선택

**문제**:
```
과도한 사양:
- t2.large 사용 (CPU 30% 활용)
- 비용: $68/월

적정 사양:
- t2.small 사용 (CPU 60% 활용)
- 비용: $17/월
→ 75% 절감!
```

#### 2. 예약 인스턴스 (Reserved Instances)

**온디맨드 vs 예약**:
```
온디맨드 (On-Demand):
- 시간당 과금
- 유연성 높음
- 비용: $0.10/시간

1년 예약:
- 약 30-40% 할인
- 비용: $0.065/시간

3년 예약:
- 약 50-60% 할인
- 비용: $0.045/시간
```

**언제 사용?**:
- 예측 가능한 워크로드
- 최소 1년 이상 사용 계획

#### 3. 스팟 인스턴스 (Spot Instances)

```
특징:
- 유휴 용량 활용
- 최대 90% 할인
- 언제든 회수 가능 (2분 전 통지)

적합:
- 배치 작업
- 빅데이터 분석
- CI/CD 빌드
```

#### 4. 자동 스케일링

```
문제:
- 트래픽 변동에도 고정 서버 운영
- 피크 타임 기준으로 항상 운영
- 낮은 활용률, 높은 비용

해결:
- Auto Scaling Group 설정
- CPU 70% 이상: 인스턴스 추가
- CPU 30% 이하: 인스턴스 제거
- 비용 절감: 약 40-60%
```

#### 5. 미사용 리소스 정리

**흔한 낭비**:
```
☐ 중지된 EC2 (비용 발생: EBS, Elastic IP)
☐ 오래된 스냅샷
☐ 미사용 Elastic IP
☐ 로그 파일 무제한 보관
☐ 개발/테스트 환경 24시간 운영
```

**정리 전략**:
```
✅ 주말에 개발 환경 자동 중지
✅ 30일 이상 스냅샷 삭제
✅ 로그 보관 기간 설정 (30일)
✅ 미사용 리소스 태깅 및 정리
```

### 4.3 비용 최적화 체크리스트

**월별 점검**:
```
☐ Cost Explorer로 비용 추이 확인
☐ 가장 비용 높은 서비스 TOP 5
☐ 미사용 리소스 확인 및 삭제
☐ 예약 인스턴스 활용률
☐ 예산 대비 실제 지출
```

---

## 🏗️ Part 5: 클라우드 아키텍처

### 5.1 3-Tier 아키텍처

```
[사용자]
   │
   ↓
┌──────────────┐
│ Presentation │  웹 서버 (Nginx, Apache)
│    Tier      │  → EC2 + Auto Scaling
└──────────────┘
   │
   ↓
┌──────────────┐
│  Application │  애플리케이션 서버
│    Tier      │  → EC2 + Load Balancer
└──────────────┘
   │
   ↓
┌──────────────┐
│   Database   │  데이터베이스
│    Tier      │  → RDS (Multi-AZ)
└──────────────┘
```

### 5.2 고가용성 (High Availability)

**Multi-AZ 배포**:
```
Region (서울)
├─ AZ-a (가용 영역 A)
│  ├─ 웹 서버 1
│  └─ DB Primary
│
└─ AZ-c (가용 영역 C)
   ├─ 웹 서버 2
   └─ DB Standby (자동 페일오버)
```

**이점**:
- 한 AZ 장애 시 다른 AZ로 자동 전환
- 가동률 99.99% (연간 52분 다운타임)

### 5.3 PM 체크리스트

**아키텍처 검토**:
```
☐ 단일 장애 지점(SPOF) 없는가?
☐ 데이터 백업 계획이 있는가?
☐ 보안 그룹 설정이 적절한가?
☐ 비용 최적화되었는가?
☐ 확장 계획이 있는가?
```

---

## 💼 6. 실습 과제

### 과제 1: AWS 계정 생성 및 서비스 실습

**과제**:
1. AWS 계정 생성
2. EC2 인스턴스 생성 (t2.micro)
3. S3 버킷 생성 및 파일 업로드
4. Billing Alert 설정

**제출물**:
- 각 단계 스크린샷
- 비용 대시보드 캡처

### 과제 2: 클라우드 비용 분석

**시나리오**: 웹 서비스 운영 비용

**주어진 정보**:
- EC2 t2.medium 2대 (24시간 운영)
- RDS db.t2.small (24시간)
- S3 100GB
- 월 트래픽 1TB

**과제**:
1. 온디맨드 비용 계산
2. 예약 인스턴스 적용 시 비용
3. 비용 절감 방안 3가지 제안

**제출물**:
- 비용 분석 보고서 (2페이지)

### 과제 3: 클라우드 선택

**3가지 시나리오**:
1. AI 스타트업
2. 전통 제조업 (SAP 사용)
3. 게임 회사

**과제**:
각 시나리오에 AWS/Azure/GCP 중 선택 및 이유

**제출물**:
- 선택 근거 (각 1페이지)

---

## 📦 Part 7: 컨테이너와 오케스트레이션 기초

### 7.1 컨테이너란?

#### 가상 머신 vs 컨테이너

**가상 머신 (VM)**:
```
물리 서버
├─ 하이퍼바이저
├─ VM 1
│  ├─ Guest OS (5GB)
│  ├─ 라이브러리
│  └─ 애플리케이션
├─ VM 2
│  ├─ Guest OS (5GB)
│  ├─ 라이브러리
│  └─ 애플리케이션

특징:
- 무겁고 느림 (부팅 시간 분 단위)
- 리소스 많이 사용
- 완전한 격리
```

**컨테이너**:
```
물리 서버
├─ Host OS
├─ Container Engine (Docker)
├─ Container 1
│  ├─ 라이브러리
│  └─ 애플리케이션
├─ Container 2
│  ├─ 라이브러리
│  └─ 애플리케이션

특징:
- 가볍고 빠름 (부팅 시간 초 단위)
- 리소스 효율적
- 프로세스 레벨 격리
```

### 7.2 Docker 기초

#### Docker란?

**Docker**:
- 컨테이너 플랫폼
- "Build, Ship, Run" 어디서나 동작
- 개발 환경 = 운영 환경

**주요 개념**:
```
1. Image (이미지)
   - 컨테이너의 템플릿
   - 예: Ubuntu, Node.js, MySQL

2. Container (컨테이너)
   - 이미지의 실행 인스턴스
   - 격리된 환경에서 실행

3. Dockerfile
   - 이미지 빌드 방법 정의
   - 코드처럼 관리 (Infrastructure as Code)

4. Docker Hub
   - 이미지 저장소
   - 공개/비공개 이미지
```

#### Docker 기본 명령어 (PM 관점)

```bash
# 이미지 검색
docker search nginx

# 이미지 다운로드
docker pull nginx:latest

# 컨테이너 실행
docker run -d -p 80:80 nginx

# 실행 중인 컨테이너 확인
docker ps

# 컨테이너 중지
docker stop <container-id>

# 컨테이너 삭제
docker rm <container-id>
```

**PM이 알아야 할 것**:
- 개발자가 "Docker로 배포"라고 하면 → 컨테이너 사용
- 환경 일관성 보장 → 버그 감소
- 빠른 배포 → CI/CD에 유리

### 7.3 Kubernetes (K8s) 소개

#### Kubernetes란?

**Kubernetes (쿠버네티스, K8s)**:
- 컨테이너 오케스트레이션 플랫폼
- Google이 오픈소스로 공개 (2014)
- 컨테이너 수백~수천 개 관리

**해결하는 문제**:
```
문제: 컨테이너가 100개인데...
❌ 수동 배포 불가능
❌ 장애 시 자동 복구?
❌ 트래픽 증가 시 확장?
❌ 네트워크 설정?

해결: Kubernetes
✅ 자동 배포 및 롤백
✅ 자가 치유 (Self-healing)
✅ 수평 확장 (Horizontal scaling)
✅ 서비스 디스커버리 및 로드 밸런싱
```

#### Kubernetes 핵심 개념

**Pod (파드)**:
```
- 최소 배포 단위
- 1개 이상의 컨테이너 그룹
- 같은 네트워크, 스토리지 공유
```

**Deployment (디플로이먼트)**:
```
- Pod의 복제본 관리
- 롤링 업데이트
- 롤백 가능
```

**Service (서비스)**:
```
- Pod의 네트워크 진입점
- 로드 밸런싱
- 고정 IP/DNS 제공
```

**Namespace (네임스페이스)**:
```
- 리소스 그룹화
- 팀별, 환경별 분리
- 예: dev, staging, production
```

#### Kubernetes 아키텍처 (간단히)

```
Master Node (Control Plane)
├─ API Server (명령 수신)
├─ Scheduler (Pod 배치)
├─ Controller Manager (상태 관리)
└─ etcd (클러스터 데이터 저장)

Worker Node (실제 작업)
├─ kubelet (Pod 관리)
├─ kube-proxy (네트워크)
└─ Pods
   ├─ Container 1
   ├─ Container 2
   └─ ...
```

#### PM이 알아야 할 Kubernetes 개념

**선언적 설정**:
```yaml
# deployment.yaml 예시
apiVersion: apps/v1
kind: Deployment
metadata:
  name: my-app
spec:
  replicas: 3  # 3개의 Pod 복제본
  template:
    spec:
      containers:
      - name: app
        image: my-app:v1.0
        ports:
        - containerPort: 8080
```

**자가 치유**:
```
상황: Pod 1개가 크래시
Kubernetes: 자동으로 새 Pod 생성
결과: 사용자는 장애를 느끼지 못함
```

**오토 스케일링**:
```
CPU 사용률 80% 초과
→ Kubernetes가 자동으로 Pod 추가
→ 트래픽 감소 시 자동 축소
```

### 7.4 관리형 Kubernetes 서비스

#### AWS EKS (Elastic Kubernetes Service)

**특징**:
- AWS 관리형 Kubernetes
- Master Node 관리 불필요
- AWS 서비스와 통합 (ALB, RDS, S3)

**비용**:
- 클러스터당 $0.10/시간 ($73/월)
- Worker Node는 EC2 요금 별도

**언제 사용**:
- Kubernetes 운영 부담 감소
- AWS 생태계 활용

#### Azure AKS (Azure Kubernetes Service)

**특징**:
- Microsoft 관리형 Kubernetes
- Control Plane 무료!
- Azure DevOps 통합

**비용**:
- Control Plane 무료
- Worker Node는 VM 요금만

**언제 사용**:
- Microsoft 스택 사용
- Control Plane 비용 절감

#### GKE (Google Kubernetes Engine)

**특징**:
- Google의 Kubernetes (원조!)
- 가장 성숙한 플랫폼
- Autopilot 모드 (완전 관리형)

**비용**:
- Standard: 클러스터당 $0.10/시간
- Autopilot: Node 사용량만 청구

**언제 사용**:
- Kubernetes 전문 팀
- 최신 기능 필요

### 7.5 PM을 위한 컨테이너/K8s 활용 팁

#### 프로젝트 범위 산정

**Docker 도입 시**:
```
초기 투자:
- 개발자 학습 시간 (2-4주)
- Dockerfile 작성
- CI/CD 파이프라인 구축

장기 효과:
- 배포 시간 단축 (시간 → 분)
- 환경 불일치 버그 감소
- 개발-운영 협업 개선
```

**Kubernetes 도입 시**:
```
초기 투자:
- 학습 곡선 가파름 (2-3개월)
- 인프라 구축 (EKS, AKS, GKE)
- 모니터링 설정 (Prometheus, Grafana)

적합:
- 마이크로서비스 아키텍처
- 트래픽 변동 큼
- 다수의 서비스 운영

부적합:
- 소규모 단일 애플리케이션
- 팀에 Kubernetes 전문가 없음
```

#### 개발팀과의 소통

**PM이 물어볼 질문**:

1. **"왜 Docker를 사용하나요?"**
   - 답: 환경 일관성, 빠른 배포, 리소스 효율

2. **"Kubernetes가 정말 필요한가요?"**
   - 필요: 서비스 10개 이상, 트래픽 많음, 확장성 중요
   - 불필요: 서비스 1-2개, 트래픽 적음

3. **"컨테이너 보안은 어떻게 관리하나요?"**
   - 이미지 스캔 (취약점 검사)
   - 최소 권한 원칙
   - 정기 업데이트

4. **"장애 시 복구 계획은?"**
   - Kubernetes: 자가 치유
   - 모니터링: Prometheus, Grafana
   - 알람: Slack, PagerDuty

#### 비용 산정 예시

**시나리오**: 마이크로서비스 10개

**Docker + ECS (간단)**:
```
EC2 인스턴스 3대 (t3.medium)
- 온디맨드: $90/월
- Reserved (1년): $55/월

총: $165/월 (온디맨드)
```

**Kubernetes + EKS (고급)**:
```
EKS Control Plane: $73/월
Worker Node 3대 (t3.medium): $90/월

총: $163/월 (온디맨드)

차이: 거의 비슷하지만, K8s는 관리 복잡도 높음
```

**결론**: 비용보다 팀 역량과 프로젝트 복잡도를 고려!

---

## 🏗️ Part 8: 클라우드 아키텍처 패턴

### 8.1 대표적인 아키텍처 패턴

#### 패턴 1: 3-Tier 아키텍처

```
인터넷
  ↓
[Web Tier] - 웹 서버 (Nginx, Apache)
  ↓
[App Tier] - 애플리케이션 서버 (Node.js, Java)
  ↓
[Data Tier] - 데이터베이스 (RDS, DynamoDB)
```

**특징**:
- 계층 분리로 유지보수 용이
- 각 계층 독립적 확장
- 가장 일반적인 패턴

**AWS 구현**:
- Web: EC2 + Auto Scaling + ALB
- App: EC2 + Auto Scaling
- Data: RDS Multi-AZ

**비용**: 월 $200-500 (소규모)

#### 패턴 2: 서버리스 아키텍처

```
사용자 요청
  ↓
[API Gateway] - REST API 엔드포인트
  ↓
[Lambda] - 함수 실행 (코드만 배포)
  ↓
[DynamoDB] - NoSQL 데이터베이스
```

**특징**:
- 서버 관리 불필요
- 사용량에 따른 과금
- 자동 확장

**AWS 구현**:
- API Gateway + Lambda + DynamoDB
- S3 정적 호스팅 (프론트엔드)

**비용**: 월 $10-100 (소규모, 트래픽 적음)

**적합**:
- 간헐적 트래픽
- 빠른 MVP 개발
- 비용 민감

#### 패턴 3: 마이크로서비스 아키텍처

```
[API Gateway]
  ↓
[Service Mesh] - 서비스 간 통신 관리
  ├─ User Service
  ├─ Order Service
  ├─ Payment Service
  ├─ Inventory Service
  └─ Notification Service

각 서비스는 독립적인 DB 소유
```

**특징**:
- 서비스별 독립 개발/배포
- 기술 스택 자유도
- 복잡도 높음

**AWS 구현**:
- ECS/EKS + ALB + RDS (각 서비스별)
- Service Mesh: AWS App Mesh

**비용**: 월 $1,000+ (중대규모)

**적합**:
- 대규모 팀
- 빠른 기능 추가
- 높은 트래픽

### 8.2 고가용성 설계 원칙

#### 원칙 1: 단일 장애점 제거 (No SPOF)

**나쁜 예**:
```
사용자 → [EC2 1대] → [RDS 1대]
문제: EC2 장애 → 전체 서비스 중단
```

**좋은 예**:
```
사용자 → [Load Balancer]
              ├─ [EC2 #1]
              ├─ [EC2 #2]
              └─ [EC2 #3]
                    ↓
              [RDS Multi-AZ]
```

#### 원칙 2: Multi-AZ 배포

**Single-AZ** (가용성 99.9%):
```
Seoul AZ-A
├─ EC2 인스턴스
└─ RDS

문제: AZ 장애 → 서비스 중단
```

**Multi-AZ** (가용성 99.99%):
```
Seoul AZ-A        Seoul AZ-C
├─ EC2 #1         ├─ EC2 #2
└─ RDS Master     └─ RDS Standby

장애 시: AZ-A 다운 → AZ-C로 자동 전환
```

#### 원칙 3: 자동 복구

**헬스 체크**:
```
Load Balancer → EC2 헬스 체크 (30초마다)
실패 → 트래픽 중단
성공 → 트래픽 재개
```

**Auto Healing**:
```
Auto Scaling → EC2 헬스 체크
실패 → 인스턴스 종료 + 새 인스턴스 생성
```

### 8.3 PM을 위한 아키텍처 검토 체크리스트

**1. 가용성**:
- [ ] Multi-AZ 배포인가?
- [ ] 로드 밸런서 사용하는가?
- [ ] Auto Scaling 설정되었는가?
- [ ] 헬스 체크 설정되었는가?

**2. 보안**:
- [ ] 보안 그룹 최소 권한 원칙?
- [ ] 데이터 암호화 (전송, 저장)?
- [ ] IAM 역할 적절히 분리?
- [ ] VPC 네트워크 격리?

**3. 성능**:
- [ ] CDN (CloudFront) 사용?
- [ ] 캐싱 (Redis, ElastiCache)?
- [ ] 데이터베이스 인덱스 최적화?
- [ ] 리전 선택 적절 (지연시간)?

**4. 비용**:
- [ ] 리소스 크기 적절 (과도하지 않은가)?
- [ ] Reserved Instance 검토?
- [ ] 미사용 리소스 정리?
- [ ] 태깅 전략으로 비용 추적?

**5. 운영**:
- [ ] 모니터링 (CloudWatch) 설정?
- [ ] 로그 수집 및 분석?
- [ ] 백업 자동화?
- [ ] 재해 복구 계획 (DR)?

---

## 🎯 7. 자가 점검 퀴즈

### 객관식

**1. IaaS의 예시는?**
- A) Gmail
- B) AWS EC2
- C) Salesforce
- D) Office 365

**정답**: B

---

**2. 시장 점유율 1위 클라우드는?**
- A) AWS
- B) Azure
- C) GCP
- D) IBM Cloud

**정답**: A

---

**3. AWS Free Tier EC2 인스턴스 타입은?**
- A) t2.nano
- B) t2.micro
- C) t2.small
- D) t2.medium

**정답**: B

---

**4. 가장 비용 저렴한 EC2 구매 옵션은?**
- A) On-Demand
- B) Reserved (1년)
- C) Spot
- D) Dedicated

**정답**: C

---

**5. Multi-AZ 배포의 주요 목적은?**
- A) 비용 절감
- B) 성능 향상
- C) 고가용성
- D) 보안 강화

**정답**: C

---

### 서술형

**6. IaaS, PaaS, SaaS의 차이를 PM이 관리하는 부분을 중심으로 설명하시오.**

**모범 답안**:
- **IaaS**: OS, 미들웨어, 애플리케이션 모두 관리
- **PaaS**: 애플리케이션과 데이터만 관리
- **SaaS**: 관리할 것 없음, 사용만 함

---

**7. 클라우드 비용을 절감하는 5가지 방법을 나열하시오.**

**모범 답안**:
1. 적절한 인스턴스 크기 선택
2. 예약 인스턴스 활용
3. 자동 스케일링 설정
4. 미사용 리소스 정리
5. 스팟 인스턴스 활용 (배치 작업)

---

**8. AWS, Azure, GCP 중 하나를 선택해야 할 때 고려할 요소 3가지를 설명하시오.**

**모범 답안**:
1. **기존 기술 스택**: MS 제품 사용 → Azure
2. **프로젝트 특성**: AI/ML → GCP, 범용 → AWS
3. **비용**: 제한적 → GCP, 서비스 다양성 → AWS

---

**9. Multi-AZ 배포가 필요한 이유와 비용 대비 이점을 설명하시오.**

**모범 답안**:

**필요성**:
- 가용 영역 장애 대비
- 자동 페일오버
- 99.99% 가동률

**비용 대비 이점**:
- 비용: 약 2배
- 다운타임 비용 절감 (매출 손실 방지)
- 신뢰도 향상 → 고객 만족

---

**10. PM이 클라우드 아키텍처를 검토할 때 확인해야 할 5가지 체크 포인트를 설명하시오.**

**모범 답안**:
1. **고가용성**: Multi-AZ, 로드 밸런서
2. **보안**: 보안 그룹, 암호화
3. **확장성**: Auto Scaling 설정
4. **비용**: 리소스 최적화
5. **백업**: 데이터 백업 및 복구 계획

---

## 📚 8. 핵심 용어 정리

| 한글 | 영문 | 설명 |
|-----|------|------|
| 클라우드 | Cloud Computing | 인터넷을 통한 IT 리소스 제공 |
| 가용 영역 | Availability Zone | 독립된 데이터센터 |
| 리전 | Region | 지리적 위치 |
| 인스턴스 | Instance | 가상 서버 |
| 스냅샷 | Snapshot | 시점 백업 |
| 로드 밸런서 | Load Balancer | 트래픽 분산 |
| 오토 스케일링 | Auto Scaling | 자동 용량 조절 |

---

## 🎓 다음 주 예고

**Week 16: 네트워크 기초**

---

**강의 자료 버전**: 1.0  
**최종 업데이트**: 2026년 1월  
**작성자**: PM Expert Training Team
