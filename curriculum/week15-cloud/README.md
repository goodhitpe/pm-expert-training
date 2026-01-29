# Week 15: 클라우드 컴퓨팅 (Cloud Computing)

## 📝 학습 목표
- 클라우드 컴퓨팅의 개념과 장점 이해
- 클라우드 서비스 모델 (IaaS, PaaS, SaaS) 학습
- 주요 클라우드 제공자 (AWS, Azure, GCP) 서비스 이해
- 클라우드 마이그레이션 전략 파악

## 📚 주요 내용

### 1. 클라우드 컴퓨팅 개요

#### 1.1 클라우드 컴퓨팅이란?
- **정의**: 인터넷을 통해 IT 리소스를 온디맨드로 제공하는 서비스
- **핵심 개념**:
  - 온디맨드 셀프 서비스
  - 광범위한 네트워크 액세스
  - 리소스 풀링
  - 신속한 탄력성
  - 측정 가능한 서비스

#### 1.2 클라우드의 장점
**비용 절감:**
- CAPEX → OPEX 전환
- 초기 투자 비용 감소
- 사용한 만큼만 지불

**확장성 (Scalability):**
- 수직 확장 (Scale-up): 서버 성능 향상
- 수평 확장 (Scale-out): 서버 수 증가
- 자동 확장 (Auto Scaling)

**가용성 (Availability):**
- 높은 가동률 (99.9%, 99.99%)
- 다중 리전 및 가용 영역
- 자동 장애 복구

**민첩성 (Agility):**
- 빠른 리소스 프로비저닝
- 실험 및 혁신 용이
- 글로벌 확장

**보안:**
- 전문 보안 팀
- 규정 준수 (Compliance)
- 데이터 암호화

#### 1.3 온프레미스 vs 클라우드

| 구분 | 온프레미스 | 클라우드 |
|------|-----------|---------|
| 초기 비용 | 높음 | 낮음 |
| 확장성 | 제한적 | 유연함 |
| 유지보수 | 자체 관리 | 공급자 관리 |
| 배포 속도 | 느림 | 빠름 |
| 통제력 | 높음 | 제한적 |
| 보안 책임 | 자체 | 공동 책임 |

### 2. 클라우드 서비스 모델

#### 2.1 IaaS (Infrastructure as a Service)
- **정의**: 가상화된 컴퓨팅 리소스 제공
- **제공 항목**: 가상 머신, 스토리지, 네트워크
- **사용자 관리**: OS, 미들웨어, 애플리케이션
- **예시**: AWS EC2, Azure VM, GCP Compute Engine

**장점:**
- 높은 유연성
- 완전한 제어
- 레거시 애플리케이션 지원

**단점:**
- 관리 부담
- 보안 책임

#### 2.2 PaaS (Platform as a Service)
- **정의**: 애플리케이션 개발 및 실행 플랫폼 제공
- **제공 항목**: OS, 미들웨어, 런타임
- **사용자 관리**: 애플리케이션, 데이터
- **예시**: AWS Elastic Beanstalk, Azure App Service, Google App Engine

**장점:**
- 빠른 개발
- 인프라 관리 불필요
- 자동 스케일링

**단점:**
- 플랫폼 종속성
- 제한된 커스터마이징

#### 2.3 SaaS (Software as a Service)
- **정의**: 완전한 소프트웨어 애플리케이션 제공
- **제공 항목**: 모든 것 (인프라 + 소프트웨어)
- **사용자 관리**: 설정 및 데이터
- **예시**: Gmail, Office 365, Salesforce, Slack

**장점:**
- 즉시 사용 가능
- 유지보수 불필요
- 어디서나 접근

**단점:**
- 커스터마이징 제한
- 데이터 통제 제한

#### 2.4 서비스 모델 비교
```
┌─────────────────────────────────────┐
│ SaaS: 애플리케이션만 사용           │ Gmail, Salesforce
├─────────────────────────────────────┤
│ PaaS: 애플리케이션 개발 및 배포     │ Heroku, App Engine
├─────────────────────────────────────┤
│ IaaS: 인프라 리소스 관리           │ EC2, Azure VM
└─────────────────────────────────────┘
```

### 3. 클라우드 배포 모델

#### 3.1 퍼블릭 클라우드 (Public Cloud)
- 일반 대중에게 개방
- 공유 인프라
- 비용 효율적
- 예: AWS, Azure, GCP

#### 3.2 프라이빗 클라우드 (Private Cloud)
- 단일 조직 전용
- 온프레미스 또는 호스팅
- 높은 보안 및 통제
- 비용 높음

#### 3.3 하이브리드 클라우드 (Hybrid Cloud)
- 퍼블릭 + 프라이빗 조합
- 유연성
- 민감 데이터는 프라이빗, 나머지는 퍼블릭
- 복잡한 관리

#### 3.4 멀티 클라우드 (Multi-Cloud)
- 여러 클라우드 제공자 사용
- 벤더 종속성 회피
- 최적의 서비스 선택
- 관리 복잡도 증가

### 4. AWS (Amazon Web Services)

#### 4.1 AWS 주요 서비스

**컴퓨팅:**
- **EC2 (Elastic Compute Cloud)**: 가상 서버
- **Lambda**: 서버리스 컴퓨팅
- **ECS/EKS**: 컨테이너 오케스트레이션

**스토리지:**
- **S3 (Simple Storage Service)**: 객체 스토리지
- **EBS (Elastic Block Store)**: 블록 스토리지
- **Glacier**: 아카이브 스토리지

**데이터베이스:**
- **RDS (Relational Database Service)**: 관리형 RDBMS
- **DynamoDB**: NoSQL 데이터베이스
- **Aurora**: 고성능 관계형 DB
- **ElastiCache**: 인메모리 캐시

**네트워킹:**
- **VPC (Virtual Private Cloud)**: 가상 네트워크
- **CloudFront**: CDN (콘텐츠 전송 네트워크)
- **Route 53**: DNS 서비스
- **ELB (Elastic Load Balancing)**: 로드 밸런서

**보안:**
- **IAM (Identity and Access Management)**: 접근 제어
- **KMS (Key Management Service)**: 암호화 키 관리
- **CloudWatch**: 모니터링

#### 4.2 AWS 아키텍처 예시
```
인터넷
  ↓
Route 53 (DNS)
  ↓
CloudFront (CDN)
  ↓
ELB (Load Balancer)
  ↓
┌────────────────────────┐
│ EC2 인스턴스 (Web)     │
│ Auto Scaling 그룹      │
└────────────────────────┘
  ↓
┌────────────────────────┐
│ RDS (Database)         │
│ Multi-AZ               │
└────────────────────────┘
  ↓
S3 (파일 저장소)
```

### 5. Microsoft Azure

#### 5.1 Azure 주요 서비스

**컴퓨팅:**
- **Virtual Machines**: IaaS 가상 머신
- **App Service**: PaaS 웹앱 호스팅
- **Azure Functions**: 서버리스
- **AKS (Azure Kubernetes Service)**: 컨테이너

**스토리지:**
- **Blob Storage**: 객체 스토리지
- **Disk Storage**: 블록 스토리지
- **File Storage**: 파일 공유

**데이터베이스:**
- **Azure SQL Database**: 관리형 SQL Server
- **Cosmos DB**: 글로벌 분산 NoSQL
- **Azure Database for MySQL/PostgreSQL**

**네트워킹:**
- **Virtual Network**: 가상 네트워크
- **Load Balancer**: 부하 분산
- **Application Gateway**: 웹 트래픽 관리
- **Azure CDN**: 콘텐츠 전송

**AI/ML:**
- **Azure Machine Learning**: ML 플랫폼
- **Cognitive Services**: AI API

#### 5.2 Azure 특징
- Microsoft 제품과의 통합 (Windows Server, SQL Server, Active Directory)
- 엔터프라이즈 친화적
- 하이브리드 클라우드 강점

### 6. Google Cloud Platform (GCP)

#### 6.1 GCP 주요 서비스

**컴퓨팅:**
- **Compute Engine**: 가상 머신
- **Cloud Functions**: 서버리스
- **GKE (Google Kubernetes Engine)**: 컨테이너
- **App Engine**: PaaS

**스토리지:**
- **Cloud Storage**: 객체 스토리지
- **Persistent Disk**: 블록 스토리지

**데이터베이스:**
- **Cloud SQL**: 관리형 MySQL/PostgreSQL
- **Cloud Spanner**: 글로벌 분산 DB
- **Firestore**: NoSQL 문서 DB
- **Bigtable**: 대용량 NoSQL

**빅데이터/ML:**
- **BigQuery**: 데이터 웨어하우스
- **Dataflow**: 스트림/배치 처리
- **AI Platform**: ML 플랫폼

**네트워킹:**
- **VPC**: 가상 네트워크
- **Cloud Load Balancing**: 부하 분산
- **Cloud CDN**: 콘텐츠 전송

#### 6.2 GCP 특징
- 강력한 빅데이터 및 ML 서비스
- 네트워크 성능 우수
- 오픈소스 친화적 (Kubernetes 창시자)

### 7. 클라우드 네이티브 기술

#### 7.1 컨테이너 (Containers)
- **Docker**: 컨테이너화 플랫폼
- **장점**:
  - 일관된 환경
  - 빠른 배포
  - 리소스 효율성
  - 마이크로서비스 지원

**Dockerfile 예시:**
```dockerfile
FROM node:14
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
EXPOSE 3000
CMD ["npm", "start"]
```

#### 7.2 Kubernetes
- 컨테이너 오케스트레이션 플랫폼
- 자동 스케일링
- 자가 치유 (Self-healing)
- 로드 밸런싱
- 롤링 업데이트

**주요 개념:**
- **Pod**: 최소 배포 단위
- **Service**: 네트워크 엔드포인트
- **Deployment**: 배포 관리
- **Namespace**: 리소스 격리

#### 7.3 서버리스 (Serverless)
- 서버 관리 불필요
- 이벤트 기반 실행
- 사용한 만큼만 과금
- 자동 스케일링

**사용 사례:**
- API 백엔드
- 데이터 처리
- 예약 작업 (Cron)
- 이미지 변환

**AWS Lambda 예시:**
```python
def lambda_handler(event, context):
    name = event.get('name', 'World')
    return {
        'statusCode': 200,
        'body': f'Hello, {name}!'
    }
```

#### 7.4 마이크로서비스 아키텍처
- 작고 독립적인 서비스
- 각 서비스는 독립적으로 배포
- API를 통한 통신
- 장점: 확장성, 유연성
- 단점: 복잡성, 운영 부담

### 8. 클라우드 보안

#### 8.1 공동 책임 모델 (Shared Responsibility Model)
```
┌───────────────────────────┐
│ 고객 책임: 클라우드 내    │
│ - 데이터                  │
│ - 애플리케이션            │
│ - 접근 관리               │
│ - OS (IaaS의 경우)        │
└───────────────────────────┘
┌───────────────────────────┐
│ 공급자 책임: 클라우드의   │
│ - 물리적 보안             │
│ - 네트워크 인프라         │
│ - 하이퍼바이저            │
│ - 스토리지 인프라         │
└───────────────────────────┘
```

#### 8.2 보안 모범 사례
- **IAM (Identity and Access Management)**:
  - 최소 권한 원칙
  - MFA (다중 인증) 사용
  - 정기적인 권한 검토

- **데이터 암호화**:
  - 저장 데이터 암호화 (At Rest)
  - 전송 데이터 암호화 (In Transit)
  - 키 관리

- **네트워크 보안**:
  - 방화벽 규칙
  - VPN 또는 전용 연결
  - DDoS 방어

- **모니터링 및 로깅**:
  - 활동 로그 수집
  - 이상 탐지
  - 보안 감사

### 9. 클라우드 비용 관리

#### 9.1 비용 최적화 전략
- **적절한 사이징**: 필요한 만큼만 프로비저닝
- **예약 인스턴스**: 장기 사용 시 할인
- **스팟 인스턴스**: 여유 용량을 저렴하게
- **자동 스케일링**: 수요에 따라 조정
- **스토리지 라이프사이클**: 오래된 데이터는 저렴한 스토리지로

#### 9.2 비용 모니터링
- 비용 태그 사용
- 예산 알림 설정
- 정기적인 비용 리뷰
- 도구: AWS Cost Explorer, Azure Cost Management

#### 9.3 FinOps (Financial Operations)
- 클라우드 재무 관리
- 비용 투명성
- 부서별 비용 배분
- 최적화 문화

### 10. 클라우드 마이그레이션

#### 10.1 마이그레이션 전략 (6R)
- **Rehost (Lift and Shift)**: 그대로 이동
- **Replatform**: 약간의 최적화
- **Repurchase**: SaaS로 전환
- **Refactor**: 클라우드 네이티브로 재설계
- **Retire**: 사용 중지
- **Retain**: 온프레미스 유지

#### 10.2 마이그레이션 프로세스
```
1. 평가 (Assessment)
   ↓
2. 계획 (Planning)
   ↓
3. 마이그레이션 (Migration)
   ↓
4. 최적화 (Optimization)
   ↓
5. 운영 (Operations)
```

#### 10.3 마이그레이션 리스크
- 다운타임
- 데이터 손실
- 성능 저하
- 비용 초과
- 보안 취약점

### 11. PM이 알아야 할 클라우드 지식

#### 11.1 클라우드 프로젝트 관리
- 클라우드 서비스 선택
- 비용 추정 및 관리
- 마이그레이션 계획
- 리스크 관리
- 규정 준수

#### 11.2 클라우드 용어 이해
- 가용 영역 (Availability Zone)
- 리전 (Region)
- 엣지 로케이션 (Edge Location)
- SLA (Service Level Agreement)
- TCO (Total Cost of Ownership)

#### 11.3 클라우드 벤더 비교
| 구분 | AWS | Azure | GCP |
|------|-----|-------|-----|
| 시장 점유율 | 1위 | 2위 | 3위 |
| 강점 | 서비스 다양성 | 엔터프라이즈 | 빅데이터/ML |
| 리전 수 | 가장 많음 | 많음 | 보통 |
| 가격 | 보통 | 보통 | 경쟁적 |

## 💡 실습 과제

### 과제 1: 클라우드 아키텍처 설계
웹 애플리케이션을 위한 클라우드 아키텍처를 설계하시오:
- 3-tier 아키텍처 (Web, App, DB)
- 고가용성 고려
- Auto Scaling 적용
- 다이어그램 작성

### 과제 2: 클라우드 서비스 체험
AWS, Azure, GCP 중 하나의 무료 계정을 생성하고 다음을 수행하시오:
- 가상 머신 생성
- 웹 서버 설치 및 간단한 페이지 배포
- 스토리지에 파일 업로드
- 스크린샷 제출

### 과제 3: 클라우드 마이그레이션 계획
온프레미스 시스템을 클라우드로 마이그레이션하는 계획을 수립하시오:
- 현재 시스템 분석
- 마이그레이션 전략 선택 (6R)
- 단계별 계획
- 리스크 및 대응 방안 (A4 2페이지)

## 📖 참고 자료
- "클라우드 컴퓨팅 바이블" by Barrie Sosinsky
- AWS Well-Architected Framework: https://aws.amazon.com/architecture/well-architected/
- Azure Architecture Center: https://docs.microsoft.com/azure/architecture/
- GCP Solutions: https://cloud.google.com/solutions

## ✅ 자가 점검 퀴즈

1. IaaS, PaaS, SaaS의 차이점은?
2. 퍼블릭, 프라이빗, 하이브리드 클라우드의 특징은?
3. 클라우드의 주요 장점 3가지는?
4. 공동 책임 모델에서 고객의 책임은?
5. 클라우드 마이그레이션 6R 전략은?

## 📝 핵심 용어
- **IaaS/PaaS/SaaS**: 클라우드 서비스 모델
- **EC2/VM**: 가상 머신 서비스
- **S3/Blob Storage**: 객체 스토리지
- **Auto Scaling**: 자동 확장
- **Load Balancer**: 부하 분산
- **Serverless**: 서버리스 컴퓨팅
- **Kubernetes**: 컨테이너 오케스트레이션
- **SLA (Service Level Agreement)**: 서비스 수준 협약

## 다음 주 예고
Week 16에서는 네트워크의 기초 개념과 프로토콜, 보안을 학습합니다.
