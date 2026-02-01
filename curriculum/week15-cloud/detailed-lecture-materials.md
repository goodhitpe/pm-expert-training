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

## 🐳 6. 컨테이너와 서버리스 아키텍처

### 6.1 컨테이너 기술 (Docker & Kubernetes)

#### 가상 머신 vs 컨테이너

**가상 머신 (VM)**:
```
Hardware (물리 서버)
  └─ Hypervisor (가상화 레이어)
      ├─ VM 1 (Guest OS + App)
      ├─ VM 2 (Guest OS + App)
      └─ VM 3 (Guest OS + App)

특징:
- 무거움 (GB 단위)
- 시작 시간: 분 단위
- 격리 수준: 높음
- 리소스 소비: 많음
```

**컨테이너**:
```
Hardware (물리 서버)
  └─ Host OS
      └─ Container Engine (Docker)
          ├─ Container 1 (App)
          ├─ Container 2 (App)
          └─ Container 3 (App)

특징:
- 가벼움 (MB 단위)
- 시작 시간: 초 단위
- 격리 수준: 중간
- 리소스 소비: 적음
```

#### Docker 핵심 개념

**이미지 (Image)**:
- 애플리케이션 실행에 필요한 모든 것을 포함한 패키지
- 읽기 전용 템플릿
- 예: `nginx:latest`, `python:3.9`

**컨테이너 (Container)**:
- 이미지의 실행 인스턴스
- 격리된 환경에서 실행
- 상태를 가짐 (실행 중, 중지, 삭제)

**Dockerfile 예시**:
```dockerfile
# 베이스 이미지
FROM python:3.9-slim

# 작업 디렉토리
WORKDIR /app

# 의존성 설치
COPY requirements.txt .
RUN pip install -r requirements.txt

# 애플리케이션 코드 복사
COPY . .

# 포트 노출
EXPOSE 8000

# 실행 명령어
CMD ["python", "app.py"]
```

**장점**:
- ✅ **일관성**: "내 컴퓨터에서는 되는데"→ 해결
- ✅ **이식성**: 어디서나 동일하게 실행
- ✅ **효율성**: 빠른 배포 및 시작
- ✅ **격리**: 애플리케이션 간 간섭 없음
- ✅ **확장성**: 쉬운 스케일링

#### Kubernetes 기초

**Kubernetes란?**
- 컨테이너 오케스트레이션 플랫폼
- 구글이 개발, 오픈소스
- 여러 컨테이너를 자동으로 관리

**핵심 개념**:
```
Cluster (클러스터)
  └─ Nodes (노드들)
      ├─ Pod (최소 배포 단위)
      │   └─ Container(s)
      ├─ Service (네트워킹)
      └─ Deployment (배포 관리)
```

**주요 기능**:
1. **자동 스케일링**: 트래픽에 따라 자동 확장/축소
2. **자가 치유**: 실패한 컨테이너 자동 재시작
3. **로드 밸런싱**: 트래픽 자동 분산
4. **롤링 업데이트**: 무중단 배포
5. **비밀 관리**: 보안 정보 안전하게 관리

**AWS에서의 Kubernetes**:
- **Amazon EKS** (Elastic Kubernetes Service)
  - 관리형 Kubernetes
  - 컨트롤 플레인 AWS가 관리
  - Free Tier 없음 (시간당 $0.10)

#### PM이 알아야 할 컨테이너 지식

**프로젝트 계획 시 고려사항**:
1. **개발 환경**: Docker로 일관성 유지
2. **배포 전략**: CI/CD 파이프라인에 통합
3. **비용**: VM보다 저렴 (리소스 효율)
4. **학습 곡선**: 개발팀 교육 필요
5. **모니터링**: 컨테이너 로그 및 메트릭 수집

**실무 적용 시나리오**:
```
시나리오: 마이크로서비스 아키텍처

Before (Monolith):
[단일 서버]
  └─ 모든 기능 (인증, 결제, 주문 등)
     → 하나 수정하면 전체 재배포

After (Microservices + Containers):
[인증 서비스] (Container)
[결제 서비스] (Container)
[주문 서비스] (Container)
[배송 서비스] (Container)
  → 독립적 배포 가능
  → 각각 스케일링 가능
```

### 6.2 서버리스 아키텍처

#### 서버리스란?

**정의**:
- 서버가 없는 것이 아님
- 서버 관리를 개발자가 하지 않음
- 코드 실행에만 집중

**전통적 vs 서버리스**:
```
전통적:
1. 서버 프로비저닝
2. OS 설치 및 패치
3. 애플리케이션 배포
4. 모니터링 및 관리
5. 확장 관리
→ 개발자가 모두 관리

서버리스:
1. 코드 작성
2. 함수 배포
→ 나머지는 클라우드 제공자가 관리
```

#### AWS Lambda

**특징**:
- 이벤트 기반 실행
- 사용한 시간만 과금 (밀리초 단위)
- 자동 스케일링
- 서버 관리 불필요

**Lambda 함수 예시 (Python)**:
```python
import json

def lambda_handler(event, context):
    """
    이미지 업로드 시 자동 리사이즈
    S3 → Lambda → S3
    """
    # S3 이벤트에서 파일 정보 추출
    bucket = event['Records'][0]['s3']['bucket']['name']
    key = event['Records'][0]['s3']['object']['key']
    
    # 이미지 처리 로직
    # ... (생략)
    
    return {
        'statusCode': 200,
        'body': json.dumps('이미지 리사이즈 완료')
    }
```

**Free Tier**:
- 100만 요청/월
- 400,000 GB-초 컴퓨팅 시간/월
- → 소규모 프로젝트는 거의 무료

**활용 사례**:
1. **이미지 처리**: 업로드 시 자동 리사이즈
2. **데이터 변환**: CSV → JSON 변환
3. **알림**: 이벤트 발생 시 이메일/SMS 전송
4. **백업**: 주기적 데이터 백업
5. **API 백엔드**: RESTful API 구축

#### 서버리스 장단점

**장점**:
- ✅ **비용 효율**: 사용한 만큼만 과금
- ✅ **자동 스케일링**: 동시 요청 자동 처리
- ✅ **관리 부담 없음**: 서버 관리 불필요
- ✅ **빠른 개발**: 인프라 설정 최소화

**단점**:
- ❌ **콜드 스타트**: 첫 실행 시 지연
- ❌ **실행 시간 제한**: AWS Lambda 15분
- ❌ **상태 비저장**: 상태 유지 어려움
- ❌ **벤더 종속**: 클라우드 제공자 의존

#### PM 관점의 서버리스 적용

**적합한 프로젝트**:
- 🎯 간헐적 트래픽 (배치 작업)
- 🎯 이벤트 기반 처리
- 🎯 빠른 프로토타이핑
- 🎯 마이크로서비스

**부적합한 프로젝트**:
- ❌ 지속적 높은 트래픽
- ❌ 실시간 처리 (레이턴시 민감)
- ❌ 상태 유지 필요 (웹소켓)
- ❌ 복잡한 모놀리식 애플리케이션

**비용 비교 예시**:
```
시나리오: 하루 1,000회 요청, 각 500ms 실행

EC2 (t2.micro):
- 월 비용: ~$10 (24시간 실행)
- 실제 사용: 1,000 × 0.5초 = 500초 (0.14시간)
- 낭비: 99.4%

Lambda:
- 월 비용: 거의 무료 (100만 요청 무료)
- 실제 사용한 만큼만 과금
- 낭비: 0%
```

### 6.3 실전 아키텍처 패턴

#### 패턴 1: 정적 웹사이트 + API

```
[사용자]
    ↓ HTTPS
[CloudFront (CDN)]
    ↓
[S3 (정적 파일)]
    +
[API Gateway + Lambda (API)]
    ↓
[DynamoDB (데이터베이스)]
```

**특징**:
- 완전 서버리스
- 자동 스케일링
- 비용 효율적

**적용 사례**: 블로그, 포트폴리오, 간단한 웹 앱

#### 패턴 2: 마이크로서비스 on Containers

```
[Application Load Balancer]
    ↓
[ECS/EKS (Container Orchestration)]
    ├─ [User Service] (Container)
    ├─ [Product Service] (Container)
    ├─ [Order Service] (Container)
    └─ [Payment Service] (Container)
    ↓
[RDS (데이터베이스)]
```

**특징**:
- 독립적 배포
- 확장 유연성
- 장애 격리

**적용 사례**: 전자상거래, SaaS 플랫폼

#### 패턴 3: 데이터 파이프라인

```
[데이터 소스]
    ↓
[Kinesis (스트리밍)]
    ↓
[Lambda (데이터 변환)]
    ↓
[S3 (데이터 레이크)]
    ↓
[Athena (분석)]
    ↓
[QuickSight (시각화)]
```

**특징**:
- 실시간 처리
- 스케일링 자동화
- 분석 최적화

**적용 사례**: 로그 분석, IoT 데이터, 실시간 대시보드

---

## 🌐 7. 클라우드 네이티브와 DevOps

### 7.1 클라우드 네이티브란?

**정의**:
- 클라우드 환경에 최적화된 애플리케이션 개발 방식
- 컨테이너, 마이크로서비스, CI/CD 활용

**클라우드 네이티브 12 요소 (12 Factor App)**:
1. **코드베이스**: 하나의 코드베이스, 여러 배포
2. **의존성**: 명시적으로 선언 및 격리
3. **설정**: 환경 변수로 설정 관리
4. **백엔드 서비스**: 리소스로 취급
5. **빌드, 릴리스, 실행**: 엄격히 분리
6. **프로세스**: 무상태 프로세스
7. **포트 바인딩**: 서비스를 포트로 노출
8. **동시성**: 프로세스 모델로 확장
9. **폐기 가능성**: 빠른 시작 및 종료
10. **개발/운영 환경 일치**: 최대한 유사하게
11. **로그**: 이벤트 스트림으로 처리
12. **관리 프로세스**: 일회성 작업

**PM이 알아야 할 이유**:
- 프로젝트 아키텍처 결정 시 참고
- 개발팀과 소통 시 용어 이해
- 클라우드 전환 프로젝트 계획

### 7.2 CI/CD 파이프라인

#### CI/CD란?

**CI (Continuous Integration)**:
```
코드 변경
  ↓
자동 빌드
  ↓
자동 테스트
  ↓
피드백 (성공/실패)
```

**CD (Continuous Delivery/Deployment)**:
```
테스트 통과
  ↓
스테이징 배포
  ↓
프로덕션 배포 (자동 또는 승인 후)
```

#### AWS에서의 CI/CD

**AWS CodePipeline 예시**:
```
1. Source (코드 저장소)
   └─ GitHub, CodeCommit
   
2. Build (빌드)
   └─ CodeBuild
      - 의존성 설치
      - 컴파일
      - 테스트 실행
      
3. Deploy (배포)
   └─ CodeDeploy
      - EC2, ECS, Lambda
      - Blue/Green 배포
      - 롤백 자동화
```

**GitHub Actions 예시 (YAML)**:
```yaml
name: Deploy to AWS

on:
  push:
    branches: [ main ]

jobs:
  deploy:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v2
      
      - name: Configure AWS credentials
        uses: aws-actions/configure-aws-credentials@v1
        with:
          aws-access-key-id: ${{ secrets.AWS_ACCESS_KEY_ID }}
          aws-secret-access-key: ${{ secrets.AWS_SECRET_ACCESS_KEY }}
          aws-region: ap-northeast-2
      
      - name: Build and push Docker image
        run: |
          docker build -t my-app .
          docker push my-app
      
      - name: Deploy to ECS
        run: |
          aws ecs update-service --cluster my-cluster --service my-service --force-new-deployment
```

#### 배포 전략

**1. Rolling Deployment (순차 배포)**:
```
Before: [V1] [V1] [V1] [V1]
Step 1: [V2] [V1] [V1] [V1]
Step 2: [V2] [V2] [V1] [V1]
Step 3: [V2] [V2] [V2] [V1]
After:  [V2] [V2] [V2] [V2]

장점: 다운타임 없음
단점: 일시적으로 V1과 V2 혼재
```

**2. Blue/Green Deployment**:
```
Blue (현재):  [V1] [V1] [V1]
Green (신규): [V2] [V2] [V2] (대기)
  ↓ 트래픽 전환
Blue (대기):  [V1] [V1] [V1]
Green (현재): [V2] [V2] [V2] (활성)

장점: 즉시 롤백 가능, 테스트 충분
단점: 리소스 2배 필요
```

**3. Canary Deployment**:
```
V1: 90% 트래픽
V2: 10% 트래픽 (일부 사용자만)
  ↓ 모니터링 (에러율, 응답 시간)
V1: 50% 트래픽
V2: 50% 트래픽
  ↓ 문제 없으면
V2: 100% 트래픽

장점: 위험 최소화
단점: 시간 소요, 복잡함
```

### 7.3 Infrastructure as Code (IaC)

#### IaC란?

**정의**:
- 인프라를 코드로 정의하고 관리
- Git으로 버전 관리
- 자동화 및 재현 가능

**장점**:
- ✅ 일관성: 동일한 환경 보장
- ✅ 버전 관리: 변경 이력 추적
- ✅ 자동화: 수동 작업 제거
- ✅ 문서화: 코드가 곧 문서

#### Terraform 예시

**EC2 인스턴스 생성 (main.tf)**:
```hcl
# Provider 설정
provider "aws" {
  region = "ap-northeast-2"
}

# 보안 그룹
resource "aws_security_group" "web" {
  name        = "web-sg"
  description = "Allow HTTP and HTTPS"

  ingress {
    from_port   = 80
    to_port     = 80
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  ingress {
    from_port   = 443
    to_port     = 443
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  egress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }
}

# EC2 인스턴스
resource "aws_instance" "web" {
  ami           = "ami-0c55b159cbfafe1f0"
  instance_type = "t2.micro"
  
  security_groups = [aws_security_group.web.name]

  tags = {
    Name = "WebServer"
    Environment = "Production"
  }
}

# Elastic IP
resource "aws_eip" "web" {
  instance = aws_instance.web.id
}

# Output
output "public_ip" {
  value = aws_eip.web.public_ip
}
```

**실행**:
```bash
# 초기화
terraform init

# 계획 확인
terraform plan

# 적용
terraform apply

# 삭제
terraform destroy
```

#### AWS CloudFormation

**스택 생성 (YAML)**:
```yaml
AWSTemplateFormatVersion: '2010-09-09'
Description: 'Simple web server stack'

Resources:
  WebServerSecurityGroup:
    Type: AWS::EC2::SecurityGroup
    Properties:
      GroupDescription: Enable HTTP access
      SecurityGroupIngress:
        - IpProtocol: tcp
          FromPort: 80
          ToPort: 80
          CidrIp: 0.0.0.0/0

  WebServerInstance:
    Type: AWS::EC2::Instance
    Properties:
      InstanceType: t2.micro
      ImageId: ami-0c55b159cbfafe1f0
      SecurityGroups:
        - !Ref WebServerSecurityGroup
      Tags:
        - Key: Name
          Value: WebServer

Outputs:
  WebsiteURL:
    Description: URL of the website
    Value: !Sub 'http://${WebServerInstance.PublicIp}'
```

#### PM이 IaC를 알아야 하는 이유

**프로젝트 계획**:
1. **환경 복제**: 개발/스테이징/프로덕션 동일화
2. **재해 복구**: 빠른 인프라 재구축
3. **비용 예측**: 코드로 리소스 확인
4. **변경 추적**: 누가, 언제, 무엇을 변경했는지

**개발팀 소통**:
- "인프라를 코드로 관리하고 있나요?"
- "CI/CD 파이프라인에 통합되어 있나요?"
- "환경별 설정 관리는 어떻게 하나요?"

---

## 💼 8. 실습 과제

### 과제 1: AWS 계정 생성 및 서비스 실습

**과제**:
1. AWS 계정 생성
2. EC2 인스턴스 생성 (t2.micro)
3. S3 버킷 생성 및 파일 업로드
4. Billing Alert 설정

**제출물**:
- 각 단계 스크린샷
- 비용 대시보드 캡처

### 과제 1: AWS 계정 생성 및 서비스 실습

**과제**:
1. AWS 계정 생성
2. EC2 인스턴스 생성 (t2.micro)
3. S3 버킷 생성 및 파일 업로드
4. Billing Alert 설정

**제출물**:
- 각 단계 스크린샷
- 비용 대시보드 캡처

### 과제 2: 컨테이너 실습 (선택)

**과제**:
1. Docker 설치
2. 간단한 웹 앱 컨테이너화
3. Docker Hub에 푸시

**제출물**:
- Dockerfile
- 실행 스크린샷

### 과제 3: 클라우드 비용 분석

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

**제출물**:
- 선택 근거 (각 1페이지)

---

## 🛡️ 9. 재해 복구 및 비즈니스 연속성

### 9.1 재해 복구 (Disaster Recovery) 전략

#### RPO vs RTO

**RPO (Recovery Point Objective)**: 데이터 손실 허용 시간
```
예시:
RPO = 1시간
→ 최대 1시간 전 데이터까지만 복구 가능
→ 1시간 동안의 데이터 손실 감수
```

**RTO (Recovery Time Objective)**: 복구 소요 시간
```
예시:
RTO = 4시간
→ 장애 발생 후 4시간 내 서비스 재개
→ 4시간 다운타임 허용
```

**비즈니스 영향 분석**:
```
예: 전자상거래 사이트
- 시간당 매출: $10,000
- RTO 4시간 = $40,000 손실
- RTO 1시간 = $10,000 손실
→ RTO 단축 투자 vs 잠재 손실 비교
```

#### AWS 재해 복구 전략

**1. Backup and Restore (백업 및 복원)**:
```
정상 상태:
[Production (서울)]
  └─ 정기 백업
     └─ [S3 (도쿄)] (백업 보관)

재해 발생:
[서울 Region 장애]
  ↓ 복구 시작
[S3 (도쿄)]에서 백업 가져오기
  ↓
[Production (도쿄)] 재구축

RPO: 시간 단위
RTO: 수 시간
비용: 낮음 ⭐
```

**2. Pilot Light (최소 인프라 대기)**:
```
정상 상태:
[Production (서울)] ← 주 시스템
[Minimal (도쿄)] ← 코어 시스템만 (DB 복제)

재해 발생:
[서울 Region 장애]
  ↓
[Minimal (도쿄)]
  └─ 인스턴스 확장 (수분 내)
     └─ [Full Production (도쿄)]

RPO: 분 단위
RTO: 10분-30분
비용: 중간
```

**3. Warm Standby (준비된 대기 시스템)**:
```
정상 상태:
[Production (서울)] ← 100% 트래픽
[Standby (도쿄)] ← 최소 용량으로 대기

재해 발생:
[서울 Region 장애]
  ↓ 트래픽 전환 (Route 53)
[Standby (도쿄)] ← 100% 트래픽
  └─ Auto Scaling으로 용량 확장

RPO: 초 단위
RTO: 분 단위
비용: 높음
```

**4. Multi-Site Active/Active (완전 중복)**:
```
정상 상태:
[Production (서울)] ← 50% 트래픽
[Production (도쿄)] ← 50% 트래픽

재해 발생:
[서울 Region 장애]
  ↓ 트래픽 재분배
[Production (도쿄)] ← 100% 트래픽
  └─ 즉시 Auto Scaling

RPO: 0 (데이터 손실 없음)
RTO: 0-초 단위 (자동 전환)
비용: 매우 높음 ⭐⭐⭐
```

#### 전략 선택 가이드

| 시스템 유형 | 추천 전략 | 이유 |
|-----------|---------|------|
| 사내 파일 서버 | Backup & Restore | 급하지 않음, 비용 중요 |
| 블로그 | Backup & Restore | 다운타임 허용 가능 |
| 전자상거래 | Warm Standby | 매출 손실 방지 |
| 금융 거래 | Multi-Site | 법적 요구사항, 무중단 |
| 의료 시스템 | Multi-Site | 생명 안전, 규제 준수 |

### 9.2 백업 전략

#### 3-2-1 백업 규칙

```
3개의 복사본:
  └─ 원본 + 백업 2개

2개의 다른 미디어:
  └─ 로컬 디스크 + 클라우드

1개는 오프사이트:
  └─ 다른 지리적 위치
```

**AWS에서 구현**:
```
원본: EC2 인스턴스 (서울)
백업 1: EBS 스냅샷 (서울)
백업 2: S3 버킷 (도쿄 region)
오프사이트: S3 Glacier (미국)
```

#### 백업 유형

**1. 전체 백업 (Full Backup)**:
```
월요일: [A B C D E] → 전체 백업 (5GB)
화요일: [A B C D E] → 전체 백업 (5GB)
수요일: [A B C D E] → 전체 백업 (5GB)

장점: 복구 빠름
단점: 시간, 공간 많이 소요
```

**2. 증분 백업 (Incremental Backup)**:
```
월요일: [A B C D E] → 전체 백업 (5GB)
화요일: [F] → 변경분만 (0.5GB)
수요일: [G] → 변경분만 (0.3GB)

장점: 빠르고 공간 절약
단점: 복구 시 모든 백업 필요
```

**3. 차등 백업 (Differential Backup)**:
```
월요일: [A B C D E] → 전체 백업 (5GB)
화요일: [F] → 월요일 이후 변경 (0.5GB)
수요일: [F G] → 월요일 이후 변경 (0.8GB)

장점: 복구 간단 (전체 + 마지막 차등)
단점: 백업 크기 누적 증가
```

#### 자동화된 백업

**AWS Backup 서비스**:
```yaml
# 백업 계획 예시
Backup Plan:
  Name: Daily-Backup
  Rules:
    - Rule Name: Daily
      Schedule: "cron(0 3 * * ? *)"  # 매일 새벽 3시
      Target Backup Vault: Default
      Lifecycle:
        Delete After Days: 30
      Copy to Region: ap-northeast-1
```

**스크립트 예시 (EBS 스냅샷)**:
```python
import boto3
from datetime import datetime

ec2 = boto3.client('ec2', region_name='ap-northeast-2')

def create_snapshot(volume_id):
    """EBS 볼륨 스냅샷 생성"""
    snapshot = ec2.create_snapshot(
        VolumeId=volume_id,
        Description=f'Automated backup {datetime.now()}',
        TagSpecifications=[{
            'ResourceType': 'snapshot',
            'Tags': [
                {'Key': 'Name', 'Value': 'Automated-Backup'},
                {'Key': 'Created', 'Value': str(datetime.now())}
            ]
        }]
    )
    return snapshot

# 모든 프로덕션 볼륨 백업
volumes = ec2.describe_volumes(
    Filters=[{'Name': 'tag:Environment', 'Values': ['Production']}]
)['Volumes']

for volume in volumes:
    create_snapshot(volume['VolumeId'])
    print(f"Created snapshot for {volume['VolumeId']}")
```

### 9.3 보안 및 컴플라이언스

#### 공동 책임 모델 (Shared Responsibility Model)

```
클라우드 제공자 책임 (AWS):
├─ 물리적 보안 (데이터센터)
├─ 네트워크 인프라
├─ 하드웨어
└─ 가상화 레이어

고객 책임:
├─ 운영체제 패치
├─ 애플리케이션 보안
├─ 데이터 암호화
├─ 접근 권한 관리
└─ 네트워크 설정 (보안 그룹)
```

**예시로 이해하기**:
```
IaaS (EC2):
고객 책임: 많음 (OS, 앱, 데이터, 네트워크)
AWS 책임: 하드웨어, 인프라

PaaS (RDS):
고객 책임: 중간 (데이터, 접근 관리)
AWS 책임: OS, DB 엔진, 백업

SaaS (Gmail):
고객 책임: 적음 (사용자 계정, 데이터)
AWS 책임: 거의 모든 것
```

#### 보안 모범 사례

**1. IAM (Identity and Access Management)**:
```
원칙: 최소 권한 (Principle of Least Privilege)

❌ 나쁜 예:
모든 사용자에게 관리자 권한

✅ 좋은 예:
- 개발자: EC2, S3 읽기 권한
- DBA: RDS 전체 권한
- PM: 읽기 전용 권한
```

**IAM 정책 예시**:
```json
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Effect": "Allow",
      "Action": [
        "ec2:Describe*",
        "s3:List*",
        "s3:Get*"
      ],
      "Resource": "*"
    },
    {
      "Effect": "Deny",
      "Action": [
        "ec2:Terminate*",
        "s3:Delete*"
      ],
      "Resource": "*"
    }
  ]
}
```

**2. 암호화**:

**데이터 암호화 (Data at Rest)**:
```
EBS 볼륨: AWS KMS로 암호화
S3: Server-side encryption (SSE-S3, SSE-KMS)
RDS: 자동 암호화 (생성 시 활성화)
```

**전송 중 암호화 (Data in Transit)**:
```
HTTPS/TLS: 모든 API 호출
VPN: 온프레미스 ↔ AWS 연결
```

**3. 네트워크 보안**:

**보안 그룹 (Security Group)**:
```
예: 웹 서버 보안 그룹
Inbound Rules:
- HTTP (80): 0.0.0.0/0 (모든 IP)
- HTTPS (443): 0.0.0.0/0
- SSH (22): 203.0.113.0/24 (회사 IP만)

Outbound Rules:
- All traffic: 0.0.0.0/0
```

**네트워크 ACL (NACL)**:
```
서브넷 레벨 방화벽
Stateless (규칙 명시적 정의 필요)

예:
Rule 100: Allow HTTP from 0.0.0.0/0
Rule 200: Allow HTTPS from 0.0.0.0/0
Rule *: Deny all
```

#### 컴플라이언스 인증

**주요 인증**:
```
글로벌:
- ISO 27001: 정보보안 관리
- SOC 2: 서비스 보안
- PCI DSS: 카드 결제 보안

지역별:
- HIPAA (미국): 의료 데이터
- GDPR (EU): 개인정보보호
- ISMS-P (한국): 정보보호 및 개인정보보호
```

**PM 체크리스트**:
```
프로젝트 시작 전:
☐ 어떤 규제를 준수해야 하는가?
☐ 데이터는 어느 리전에 저장하는가?
☐ 데이터 암호화가 필요한가?
☐ 감사 로그가 필요한가?
☐ 인증서가 필요한가? (AWS는 이미 보유)
```

#### AWS 보안 서비스

**1. AWS Shield**:
- DDoS 공격 방어
- Standard: 무료 (자동 활성화)
- Advanced: 유료 ($3,000/월)

**2. AWS WAF (Web Application Firewall)**:
```
규칙 예시:
- SQL Injection 차단
- XSS 공격 차단
- 지역별 차단 (특정 국가 IP)
- Rate limiting (속도 제한)
```

**3. Amazon GuardDuty**:
- 위협 탐지 서비스
- 머신러닝 기반
- 자동 모니터링

**4. AWS Security Hub**:
- 보안 상태 종합 대시보드
- 모범 사례 준수 확인

---

## 🌍 10. 클라우드 마이그레이션 전략

### 10.1 마이그레이션 6R 전략

#### 1. Rehost (Lift and Shift)

**정의**: 변경 없이 그대로 이동
```
온프레미스:
[Physical Server]
  └─ [OS + App]

클라우드:
[EC2 Instance]
  └─ [동일한 OS + App]
```

**장점**:
- ✅ 빠른 마이그레이션
- ✅ 위험 낮음
- ✅ 기술 부채 미해결

**단점**:
- ❌ 클라우드 이점 미활용
- ❌ 비용 최적화 어려움

**적합 사례**: 레거시 시스템, 마이그레이션 기한 촉박

#### 2. Replatform (Lift, Tinker, and Shift)

**정의**: 약간의 최적화
```
온프레미스:
[Physical Server]
  └─ [MySQL on VM]

클라우드:
[RDS (Managed MySQL)]
  └─ 관리형 서비스 활용
```

**장점**:
- ✅ 관리 부담 감소
- ✅ 일부 클라우드 이점
- ✅ 중간 난이도

**단점**:
- ❌ 완전한 최적화 아님

**적합 사례**: 데이터베이스, 미들웨어

#### 3. Repurchase (Re-buy)

**정의**: SaaS로 전환
```
온프레미스:
[자체 구축 CRM]
  └─ 서버, DB, 개발, 유지보수

클라우드:
[Salesforce (SaaS)]
  └─ 구독료만 지불
```

**장점**:
- ✅ 관리 불필요
- ✅ 최신 기능
- ✅ 빠른 전환

**단점**:
- ❌ 커스터마이징 제한
- ❌ 데이터 종속

**적합 사례**: CRM, ERP, 이메일

#### 4. Refactor (Re-architect)

**정의**: 클라우드 네이티브로 재설계
```
온프레미스:
[Monolith App]
  └─ 단일 애플리케이션

클라우드:
[Microservices on Containers]
  ├─ [Service 1] (Lambda)
  ├─ [Service 2] (ECS)
  └─ [Service 3] (Lambda)
```

**장점**:
- ✅ 최대 클라우드 이점
- ✅ 확장성, 유연성
- ✅ 비용 최적화

**단점**:
- ❌ 시간 소요
- ❌ 높은 비용
- ❌ 리스크 높음

**적합 사례**: 핵심 서비스, 장기 전략

#### 5. Retire (제거)

**정의**: 사용하지 않는 시스템 폐기
```
현황 분석:
- 시스템 A: 사용자 0명 → 폐기
- 시스템 B: 중복 기능 → 폐기
- 시스템 C: 필수 → 마이그레이션
```

**효과**:
- ✅ 비용 절감
- ✅ 관리 간소화

#### 6. Retain (유지)

**정의**: 온프레미스에 유지
```
이유:
- 규제 요구사항
- 레거시 시스템 (마이그레이션 불가)
- 비용 대비 효과 낮음
```

### 10.2 마이그레이션 프로세스

#### Phase 1: 평가 (Assess)

**현황 파악**:
```
인벤토리:
- 서버 50대
- 애플리케이션 30개
- 데이터베이스 10개
- 스토리지 100TB

의존성 매핑:
[웹 서버] → [앱 서버] → [DB 서버]
            ↓
        [파일 서버]
```

**비용 분석**:
```
현재 (온프레미스):
- 하드웨어: $500,000 (감가상각)
- 유지보수: $100,000/년
- 전력/공간: $50,000/년
합계: $650,000/년

클라우드 (예상):
- EC2: $200,000/년
- RDS: $80,000/년
- S3: $20,000/년
합계: $300,000/년

절감: $350,000/년 (54%)
```

#### Phase 2: 계획 (Plan)

**우선순위 결정**:
```
Wave 1 (즉시):
- 비핵심 시스템
- 단순 아키텍처
- 낮은 의존성

Wave 2 (3개월):
- 중요도 중간
- 일부 최적화 필요

Wave 3 (6개월):
- 핵심 시스템
- 복잡한 아키텍처
- 재설계 필요
```

#### Phase 3: 마이그레이션 (Migrate)

**실행 단계**:
```
1. 개발/테스트 환경 먼저
   └─ 문제 파악 및 해결

2. 파일럿 마이그레이션
   └─ 소규모 시스템으로 검증

3. 본 마이그레이션
   └─ Wave별 순차 진행

4. 검증 및 최적화
   └─ 성능, 비용, 보안 확인
```

#### Phase 4: 운영 및 최적화 (Operate)

**지속적 개선**:
```
월별 리뷰:
- 비용 최적화
- 성능 튜닝
- 보안 강화
- 미사용 리소스 정리
```

### 10.3 실제 사례 연구

#### Case Study 1: 스타트업 - 빠른 확장

**배경**:
- 사용자 급증 (10만 → 100만)
- 온프레미스 용량 부족
- 빠른 대응 필요

**전략**: Rehost + Replatform
```
Before:
[물리 서버 10대]
  └─ MySQL, 웹 서버, 앱 서버

After:
[EC2 Auto Scaling]
  └─ 웹/앱 서버 (확장 가능)
[RDS (Multi-AZ)]
  └─ 고가용성 DB
[S3 + CloudFront]
  └─ 정적 콘텐츠 (CDN)
```

**결과**:
- ✅ 확장성: 1,000% 증가 대응
- ✅ 가용성: 99.99%
- ✅ 비용: 30% 절감 (효율화)

#### Case Study 2: 금융사 - 규제 준수

**배경**:
- 규제 요구사항 (금융위원회)
- 데이터 보안 중요
- 감사 추적 필요

**전략**: Hybrid Cloud + 컴플라이언스
```
[온프레미스] (민감 데이터)
  ↕ Direct Connect (전용선)
[AWS] (프론트엔드, 분석)
  └─ VPC (격리된 네트워크)
      ├─ CloudTrail (감사 로그)
      ├─ KMS (암호화 키 관리)
      └─ CloudHSM (하드웨어 보안)
```

**결과**:
- ✅ 규제 준수
- ✅ 보안 강화
- ✅ 유연성 확보

#### Case Study 3: 전자상거래 - 클라우드 네이티브

**배경**:
- 레거시 모놀리식 아키텍처
- 배포 느림 (주 1회)
- 확장성 제한

**전략**: Refactor (마이크로서비스)
```
Before:
[Monolith]
  └─ 모든 기능 통합

After:
[API Gateway]
  ├─ [User Service] (Lambda)
  ├─ [Product Service] (ECS)
  ├─ [Order Service] (ECS)
  ├─ [Payment Service] (Lambda)
  └─ [Notification Service] (SNS + Lambda)

[DynamoDB] (주문)
[RDS] (제품)
[ElastiCache] (캐시)
```

**결과**:
- ✅ 배포 속도: 주 1회 → 일 10회
- ✅ 확장성: 서비스별 독립 스케일링
- ✅ 가용성: 99.99% (장애 격리)
- ✅ 개발 속도: 팀별 독립 개발

---

## 🎯 11. 자가 점검 퀴즈

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
