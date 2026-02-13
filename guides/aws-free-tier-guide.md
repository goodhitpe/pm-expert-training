# ☁️ AWS Free Tier 실습 가이드

> **학습 시간**: 90-120분  
> **난이도**: 초급-중급  
> **목적**: PM이 클라우드 컴퓨팅을 이해하고 AWS 기본 서비스를 실습할 수 있도록 환경 구축

---

## ⚠️ 중요 주의사항

**비용 발생 가능성**:
- AWS Free Tier는 **12개월간 무료**이지만, 한도를 초과하면 요금이 청구됩니다
- **신용카드 등록 필수** - 소액(약 $1)이 일시적으로 결제되었다가 취소됩니다
- 이 가이드를 따라하면 **대부분 무료**이지만, 실수로 서비스를 켜두면 요금이 발생할 수 있습니다
- **비용 알림 설정을 필수로** 진행하세요!

**책임 한계**:
- 본 가이드는 교육 목적으로 작성되었습니다
- 사용자의 실수로 인한 요금 발생은 사용자 책임입니다
- 항상 사용 후 리소스를 종료하고 확인하세요

---

## 📚 목차

1. [AWS와 클라우드 컴퓨팅 기초](#1-aws와-클라우드-컴퓨팅-기초)
2. [AWS 계정 생성](#2-aws-계정-생성)
3. [Free Tier 이해하기](#3-free-tier-이해하기)
4. [비용 알림 설정 (필수!)](#4-비용-알림-설정-필수)
5. [IAM 사용자 생성 (보안)](#5-iam-사용자-생성-보안)
6. [EC2 인스턴스 생성 및 접속](#6-ec2-인스턴스-생성-및-접속)
7. [S3 버킷 생성 및 파일 업로드](#7-s3-버킷-생성-및-파일-업로드)
8. [리소스 정리 및 종료](#8-리소스-정리-및-종료)
9. [PM을 위한 AWS 활용 팁](#9-pm을-위한-aws-활용-팁)
10. [문제 해결](#10-문제-해결)

---

## 1. AWS와 클라우드 컴퓨팅 기초

### 1.1 클라우드 컴퓨팅이란?

**전통적인 방식 (On-Premise)**:
```
회사 서버실
├─ 물리 서버 구매 ($10,000+)
├─ 네트워크 장비 설치
├─ 전기, 냉각 시스템
├─ IT 인력 상주
└─ 유지보수 비용
```

**클라우드 방식 (AWS)**:
```
AWS 데이터 센터 (전 세계)
├─ 필요한 만큼만 사용 (종량제)
├─ 몇 분 만에 서버 생성
├─ 자동 확장/축소
├─ 전 세계 배포 가능
└─ 관리 최소화
```

### 1.2 AWS란?

**Amazon Web Services (AWS)**:
- Amazon이 제공하는 클라우드 컴퓨팅 플랫폼
- 전 세계 시장 점유율 1위 (약 32%, 2024 기준)
- 200개 이상의 서비스 제공
- Netflix, Airbnb, NASA 등 사용

**주요 서비스**:
- **EC2**: 가상 서버 (Virtual Machine)
- **S3**: 파일 저장소 (Object Storage)
- **RDS**: 관리형 데이터베이스
- **Lambda**: 서버리스 컴퓨팅
- **VPC**: 가상 네트워크

### 1.3 PM이 AWS를 알아야 하는 이유

1. **프로젝트 범위 이해**
   - 클라우드 마이그레이션 복잡도
   - 아키텍처 설계 검토
   - 기술 부채 파악

2. **비용 산정**
   - 클라우드 비용 구조 이해
   - FinOps (비용 최적화)
   - 예산 계획

3. **리스크 관리**
   - 보안 요구사항 이해
   - 다운타임 영향 파악
   - 백업/복구 전략

4. **개발팀과 소통**
   - 기술 용어 이해
   - 인프라 이슈 논의
   - 배포 전략 검토

### 1.4 AWS vs Azure vs GCP

| 특징 | AWS | Azure | GCP |
|------|-----|-------|-----|
| **시장 점유율** | 1위 (32%) | 2위 (23%) | 3위 (10%) |
| **강점** | 서비스 다양성 | Microsoft 생태계 | 빅데이터/ML |
| **사용 기업** | Netflix, Airbnb | Adobe, Walmart | Spotify, Twitter |
| **Free Tier** | 12개월 | 12개월 | 90일 + $300 크레딧 |
| **한국 리전** | ✅ 서울 | ✅ 한국 중부 | ❌ (일본/싱가포르) |

---

## 2. AWS 계정 생성

### 2.1 사전 준비물

- ✅ 이메일 주소 (Gmail, Naver 등)
- ✅ 휴대폰 번호 (SMS 인증)
- ✅ 신용카드 또는 체크카드
  - Visa, Mastercard, American Express 등
  - $1 정도가 일시 결제 후 취소됨 (카드 유효성 확인)

### 2.2 계정 생성 단계

#### Step 1: AWS 웹사이트 방문

1. **URL 접속**: https://aws.amazon.com/ko/
2. 우측 상단 **"AWS 계정 생성"** 클릭

#### Step 2: 이메일 및 계정 이름 입력

```
Root 사용자 이메일 주소: your.email@example.com
AWS 계정 이름: My-AWS-Account (또는 원하는 이름)
```

**중요**:
- Root 계정은 최고 권한을 가지므로 보안에 주의
- 이메일 주소는 나중에 로그인 ID로 사용됩니다

**"이메일 주소 확인"** 클릭 → 이메일로 발송된 인증 코드 입력

#### Step 3: 비밀번호 설정

```
Root 사용자 비밀번호: [강력한 비밀번호]
비밀번호 확인: [동일한 비밀번호]
```

**비밀번호 요구사항**:
- 최소 8자 이상
- 대문자, 소문자, 숫자, 특수문자 중 3가지 이상 포함
- 예시: `MyAWS2025!Pass`

#### Step 4: 연락처 정보 입력

```
계정 유형: 개인 (Personal)
전체 이름: 홍길동
전화번호: +82-10-1234-5678
국가/지역: 대한민국 (South Korea)
주소: [실제 주소 입력]
도시: 서울
시/도: 서울특별시
우편번호: 12345
```

**약관 동의** 후 **"계속"** 클릭

#### Step 5: 결제 정보 입력

```
신용카드 또는 직불카드 정보:
  카드 번호: 1234-5678-9012-3456
  만료 날짜: 12/2028
  카드 소유자 이름: HONG GILDONG
  청구지 주소: [앞에서 입력한 주소와 동일]
```

**$1 일시 결제**:
- 카드 유효성 확인을 위해 소액($1 정도) 결제
- 몇 분 후 자동 취소됨
- 실제 요금이 아닙니다!

**"확인 및 계속"** 클릭

#### Step 6: 자격 증명 확인 (SMS)

```
방법 선택: 문자 메시지(SMS)
국가 코드: +82 (대한민국)
전화번호: 10-1234-5678
```

**"SMS 전송"** 클릭 → 받은 인증 코드 입력

#### Step 7: 지원 플랜 선택

**3가지 옵션**:
1. **Basic Support - Free** ⭐ 선택
   - 무료
   - 문서, 화이트페이퍼 접근
   - 포럼 지원
   - 개인 학습에 충분

2. Developer - $29/월
   - 이메일 지원
   - 12-24시간 응답

3. Business - $100/월 이상
   - 전화 지원
   - 1시간 응답

**"Free - Basic Support" 선택** → **"가입 완료"** 클릭

#### Step 8: 완료 및 로그인

축하합니다! AWS 계정이 생성되었습니다.

1. **"AWS Management Console로 이동"** 클릭
2. 로그인:
   - 계정 ID 또는 이메일 주소 입력
   - 비밀번호 입력
3. **AWS 콘솔** 접속 완료!

### 2.3 첫 로그인 후 확인사항

**콘솔 화면 구성**:
```
┌─────────────────────────────────────────────┐
│  AWS     Services  [검색]           [지역]   │
├─────────────────────────────────────────────┤
│                                             │
│  Recently visited (최근 방문)               │
│  [EC2] [S3] [RDS] ...                      │
│                                             │
│  Build a solution (솔루션 구축)             │
│  [Launch a virtual machine]                │
│  [Create a website]                        │
│  ...                                       │
└─────────────────────────────────────────────┘
```

**우측 상단 리전 확인**:
- 현재 리전: Seoul (ap-northeast-2) ✅
- 다른 리전으로 변경 가능하지만, 한국 사용자는 Seoul 권장

---

## 3. Free Tier 이해하기

### 3.1 Free Tier란?

**AWS Free Tier**:
- 신규 사용자를 위한 무료 사용 제공
- 12개월 동안 제한된 양을 무료로 사용 가능
- 일부 서비스는 영구 무료

### 3.2 Free Tier 유형

#### 유형 1: 12개월 무료 (계정 생성일부터)

**EC2 (가상 서버)**:
- t2.micro 또는 t3.micro 인스턴스
- 월 750시간 (= 31.25일)
- 즉, 1대를 24시간 켜두어도 무료!

**S3 (스토리지)**:
- 5GB 표준 스토리지
- 20,000 GET 요청
- 2,000 PUT 요청

**RDS (데이터베이스)**:
- db.t2.micro 또는 db.t3.micro
- 월 750시간
- 20GB 스토리지

**기타**:
- CloudFront: 50GB 데이터 전송
- Lambda: 100만 건 요청

#### 유형 2: 영구 무료

**DynamoDB**:
- 25GB 스토리지
- 월 2억 건 요청 (읽기/쓰기 합산)

**Lambda**:
- 월 100만 건 요청
- 월 40만 GB-초 컴퓨팅 시간

**CloudWatch**:
- 10개 사용자 지정 지표
- 10개 알람

#### 유형 3: 체험판 (일시적 무료)

**SageMaker**:
- 처음 2개월 무료 (250시간)

**Amazon Lex**:
- 1년 동안 월 10,000 텍스트 요청

### 3.3 Free Tier 한도 확인 방법

**AWS Console에서 확인**:

1. **우측 상단 계정 이름 클릭** → **"Billing and Cost Management"**
2. 좌측 메뉴에서 **"Free Tier"** 클릭
3. 현재 사용량 확인:
   ```
   EC2: 750시간 중 50시간 사용 (7%)
   S3: 5GB 중 1.2GB 사용 (24%)
   ```

**이메일 알림 설정** (다음 섹션에서 설명)

### 3.4 Free Tier 주의사항

**요금이 발생하는 경우**:

1. **한도 초과**
   - EC2를 2대 동시에 켜두면 750시간 x 2 = 1,500시간 → 750시간 초과분 청구

2. **지원되지 않는 인스턴스 유형**
   - t2.micro (무료) ✅
   - t2.small (유료) ❌
   - t3.micro (무료) ✅
   - t3.small (유료) ❌

3. **데이터 전송 초과**
   - 아웃바운드 데이터 전송: 월 100GB까지 무료
   - 초과분은 GB당 약 $0.09

4. **스냅샷 및 EBS 볼륨**
   - EBS 볼륨: 30GB까지 무료
   - 스냅샷: 무료가 아닐 수 있음

5. **Elastic IP 미사용**
   - Elastic IP를 할당했지만 인스턴스에 연결하지 않으면 시간당 $0.005 청구

**꿀팁**:
- 실습 후 반드시 인스턴스 **"중지"** 또는 **"종료"**
- 중지(Stop): 인스턴스 유지, EBS 스토리지 요금만 청구 (월 약 $1)
- 종료(Terminate): 완전히 삭제, 요금 없음

---

## 4. 비용 알림 설정 (필수!)

### 4.1 왜 비용 알림이 중요한가?

**실수 사례**:
- 개발자가 EC2 인스턴스를 켜놓고 퇴근 → 1주일 후 $500 청구
- 테스트용 RDS를 종료하지 않음 → 한 달에 $200
- 불필요한 S3 데이터 방치 → 누적 요금

**예방**:
- $1, $10, $50 단계별 알림 설정
- 이메일로 즉시 통보
- 문제 조기 발견

### 4.2 결제 알림 활성화

#### Step 1: Billing Dashboard 접속

1. AWS Console 우측 상단 **계정 이름** 클릭
2. **"Billing and Cost Management"** 선택

#### Step 2: Billing Preferences 설정

1. 좌측 메뉴 **"Billing Preferences"** 클릭
2. **"Receive Billing Alerts"** 체크 ✅
3. **"Save preferences"** 클릭

#### Step 3: CloudWatch로 알람 생성

1. **AWS Console 상단 검색창**에 "CloudWatch" 입력
2. **CloudWatch** 서비스 선택
3. 좌측 메뉴 **"Alarms"** → **"Billing"** 클릭 (또는 "All alarms")
4. **"Create alarm"** 버튼 클릭

#### Step 4: 지표 선택

1. **"Select metric"** 클릭
2. **"Billing"** → **"Total Estimated Charge"** 선택
3. **"Currency: USD"** 선택 (다른 통화는 선택 해제)
4. **"Select metric"** 클릭

#### Step 5: 조건 설정

```
Threshold type: Static
Whenever EstimatedCharges is...: Greater (>)
than...: 1 (또는 원하는 금액)
```

**예시 설정**:
- $1 초과 시 알림
- 또는 $10 초과 시 알림

**"Next"** 클릭

#### Step 6: 알림 구성

1. **"Create new topic"** 선택
2. **Topic name**: `billing-alert`
3. **Email endpoint**: `your.email@example.com` (본인 이메일)
4. **"Create topic"** 클릭
5. **이메일 확인**: AWS에서 발송된 이메일의 **"Confirm subscription"** 클릭

#### Step 7: 알람 이름 설정

```
Alarm name: BillingAlert-USD-1-Dollar
Alarm description: Alert when charges exceed $1
```

**"Next"** → **"Create alarm"** 클릭

#### Step 8: 추가 알람 생성 (권장)

동일한 방법으로 여러 단계 알람 생성:
- $1 초과 알람
- $10 초과 알람
- $50 초과 알람 (심각)

### 4.3 예산 설정 (Budget)

**더 정교한 비용 관리**:

1. **Billing Dashboard** → 좌측 메뉴 **"Budgets"** 클릭
2. **"Create budget"** 클릭
3. **템플릿 선택**:
   - "Zero spend budget" (무료 사용자에게 이상적!)
   - 또는 "Monthly cost budget"

4. **Zero spend budget 설정** (추천):
   ```
   Budget name: Zero-Spend-Budget
   Email recipients: your.email@example.com
   ```
   - Free Tier를 초과하거나 유료 서비스 사용 시 즉시 알림

5. **"Create budget"** 클릭

---

## 5. IAM 사용자 생성 (보안)

### 5.1 왜 IAM 사용자를 만들어야 하나?

**Root 계정 vs IAM 사용자**:

**Root 계정** (현재 사용 중):
- ❌ 모든 권한 (결제 정보 변경, 계정 폐쇄 등)
- ❌ 유출 시 심각한 피해
- ❌ 일상적 사용 비권장

**IAM 사용자**:
- ✅ 필요한 권한만 부여
- ✅ 여러 사용자 생성 가능
- ✅ 유출 시 해당 사용자만 삭제
- ✅ **AWS 모범 사례**

### 5.2 IAM 사용자 생성

#### Step 1: IAM 서비스 접속

1. AWS Console 상단 검색창에 **"IAM"** 입력
2. **IAM** 서비스 선택

#### Step 2: 사용자 생성

1. 좌측 메뉴 **"Users"** 클릭
2. **"Create user"** 버튼 클릭

#### Step 3: 사용자 세부 정보

```
User name: pm-admin (또는 원하는 이름)
```

**AWS Management Console access** 체크 ✅
- 이 사용자가 콘솔에 로그인할 수 있도록 허용

**I want to create an IAM user** 선택

**자동 생성된 비밀번호** 또는 **사용자 지정 비밀번호** 선택
- 사용자 지정 비밀번호 권장: `PM2025!Admin`

**"Users must create a new password at next sign-in"** 체크 해제 (선택)

**"Next"** 클릭

#### Step 4: 권한 설정

**"Attach policies directly"** 선택

**정책 선택**:
- 🔍 검색창에 "AdministratorAccess" 입력
- **"AdministratorAccess"** 체크 ✅
  - 이는 Root와 유사한 권한이지만, 결제 정보는 제외

**주의**: 학습 목적이므로 AdministratorAccess 사용. 실무에서는 최소 권한 원칙 적용.

**"Next"** 클릭

#### Step 5: 검토 및 생성

- 설정 확인
- **"Create user"** 클릭

#### Step 6: 로그인 정보 다운로드

**중요**: 이 화면은 한 번만 표시됩니다!

1. **"Download .csv"** 클릭하여 로그인 정보 저장
2. CSV 파일 내용:
   ```
   User name: pm-admin
   Password: [생성된 비밀번호]
   Console sign-in URL: https://123456789012.signin.aws.amazon.com/console
   ```

### 5.3 IAM 사용자로 로그인

#### Step 1: 로그아웃

현재 Root 계정에서 로그아웃

1. 우측 상단 계정 이름 클릭
2. **"Sign out"** 클릭

#### Step 2: IAM 사용자로 로그인

1. 다운로드한 CSV 파일의 **Console sign-in URL** 복사
2. 브라우저에 붙여넣기 또는 클릭
3. 로그인 정보 입력:
   ```
   Account ID or alias: 123456789012 (자동 입력됨)
   IAM user name: pm-admin
   Password: [CSV 파일의 비밀번호]
   ```
4. **"Sign in"** 클릭

### 5.4 MFA 설정 (권장)

**MFA (Multi-Factor Authentication)**: 이중 인증

1. IAM Dashboard → 우측 **"Security recommendations"**
2. **"Add MFA"** 클릭
3. **MFA device name**: `my-mfa-device`
4. **Authenticator app** 선택:
   - Google Authenticator (스마트폰 앱)
   - Microsoft Authenticator
   - Authy

5. 앱에서 QR 코드 스캔
6. 연속된 2개의 MFA 코드 입력
7. **"Add MFA"** 클릭

이제 로그인 시 비밀번호 + MFA 코드 필요 (더 안전!)

---

## 6. EC2 인스턴스 생성 및 접속

### 6.1 EC2란?

**Elastic Compute Cloud (EC2)**:
- 가상 서버 (Virtual Machine)
- 몇 분 만에 서버 생성
- Windows, Linux 등 다양한 OS
- 용도: 웹 서버, 애플리케이션 서버, 개발 환경 등

### 6.2 EC2 인스턴스 생성

#### Step 1: EC2 서비스 접속

1. AWS Console 검색창에 **"EC2"** 입력
2. **EC2** 서비스 선택

#### Step 2: 인스턴스 시작

1. 좌측 메뉴 **"Instances"** 클릭
2. **"Launch instances"** 버튼 클릭 (주황색 버튼)

#### Step 3: 이름 및 태그

```
Name: My-First-EC2-Instance
```

#### Step 4: AMI 선택 (운영체제)

**AMI (Amazon Machine Image)**: OS 템플릿

**추천**: Amazon Linux 2023 ⭐
- AWS에 최적화된 Linux
- 무료 (Free Tier 적용)
- 보안 업데이트 자동

**다른 옵션**:
- Ubuntu Server 22.04 LTS
- Amazon Linux 2 (이전 버전)
- Windows Server 2022 (Free Tier 750시간)

**"Amazon Linux 2023 AMI"** 선택

**"64-bit (x86)"** 선택

#### Step 5: 인스턴스 유형 선택

**"t2.micro"** 또는 **"t3.micro"** 선택 ⭐
- Free Tier 적합
- 1 vCPU, 1GB RAM
- 학습/개발 목적에 충분

**"Free tier eligible"** 라벨 확인!

#### Step 6: 키 페어 생성

**키 페어**:
- SSH로 인스턴스 접속 시 필요한 인증 키
- .pem 파일 (비밀번호 대신 사용)

1. **"Create new key pair"** 클릭
2. 키 페어 설정:
   ```
   Key pair name: my-ec2-key
   Key pair type: RSA
   Private key file format:
     - Windows: .pem (PuTTY 사용자는 .ppk)
     - Mac/Linux: .pem
   ```
3. **"Create key pair"** 클릭
4. **my-ec2-key.pem** 파일 자동 다운로드 → 안전한 곳에 보관!

**⚠️ 중요**: 이 파일은 다시 다운로드할 수 없습니다. 분실 시 인스턴스에 접속 불가!

#### Step 7: 네트워크 설정

**기본 설정 사용 (변경 없음)**

**보안 그룹 규칙**:
- SSH (Port 22): 어디서나 접속 가능 (0.0.0.0/0)
  - ⚠️ 실무에서는 특정 IP만 허용 권장

#### Step 8: 스토리지 구성

**기본값 사용**:
- 8 GiB gp3 (범용 SSD)
- Free Tier: 30 GiB까지 무료

#### Step 9: 고급 세부 정보 (선택, 건너뛰기 가능)

기본값 유지

#### Step 10: 요약 확인 및 시작

우측 **Summary** 패널 확인:
```
Number of instances: 1
Software Image (AMI): Amazon Linux 2023
Instance type: t2.micro (Free tier eligible) ✅
```

**"Launch instance"** 클릭!

#### Step 11: 인스턴스 시작 확인

성공 메시지:
```
Successfully initiated launch of instance i-0abcd1234efgh5678
```

**"View all instances"** 클릭

### 6.3 인스턴스 상태 확인

**Instance State**:
- Pending → Running (약 1-2분)
- Running: 인스턴스 사용 가능!

**Public IPv4 address**: 3.35.123.45 (예시)
- 이 IP로 접속 가능

### 6.4 인스턴스 접속 (SSH)

#### Mac/Linux 사용자

**Step 1: 터미널 열기**

**Step 2: 키 파일 권한 변경** (최초 1회만)
```bash
# 다운로드 폴더로 이동
cd ~/Downloads

# 권한 변경 (필수!)
chmod 400 my-ec2-key.pem
```

**Step 3: SSH 접속**
```bash
# 접속 명령
ssh -i my-ec2-key.pem ec2-user@3.35.123.45

# 처음 접속 시 물음
The authenticity of host '3.35.123.45' can't be established.
...
Are you sure you want to continue connecting (yes/no)? yes

# 성공 시 프롬프트 변경
[ec2-user@ip-172-31-0-1 ~]$
```

#### Windows 사용자

**방법 1: PowerShell (Windows 10 이상 권장)**

```powershell
# PowerShell 관리자 권한으로 실행
# SSH 접속
ssh -i my-ec2-key.pem ec2-user@3.35.123.45
```

**방법 2: PuTTY 사용**

1. **PuTTY 다운로드**: https://www.putty.org
2. **PuTTYgen 실행** (키 변환)
   - "Load" 클릭 → my-ec2-key.pem 선택
   - "Save private key" 클릭 → my-ec2-key.ppk 저장
3. **PuTTY 실행**
   - Host Name: ec2-user@3.35.123.45
   - Connection > SSH > Auth > Private key file: my-ec2-key.ppk 선택
   - "Open" 클릭

### 6.5 간단한 웹 서버 실습

**접속 후 실행**:

```bash
# 시스템 업데이트
sudo yum update -y

# Apache 웹 서버 설치
sudo yum install httpd -y

# 웹 서버 시작
sudo systemctl start httpd

# 부팅 시 자동 시작 설정
sudo systemctl enable httpd

# 간단한 HTML 페이지 생성
echo "<h1>Hello from AWS EC2!</h1>" | sudo tee /var/www/html/index.html
```

**보안 그룹에 HTTP 포트 추가**:

1. EC2 Console로 돌아가기
2. 인스턴스 선택 → 하단 **"Security"** 탭
3. **Security groups** 링크 클릭
4. **"Edit inbound rules"** 클릭
5. **"Add rule"** 클릭:
   ```
   Type: HTTP
   Port: 80
   Source: 0.0.0.0/0 (Anywhere IPv4)
   ```
6. **"Save rules"** 클릭

**브라우저에서 확인**:
- URL: http://3.35.123.45 (본인의 Public IP)
- "Hello from AWS EC2!" 메시지 확인!

---

## 7. S3 버킷 생성 및 파일 업로드

### 7.1 S3란?

**Simple Storage Service (S3)**:
- 객체 스토리지 (파일 저장소)
- 무제한 용량 (사용한 만큼 지불)
- 99.999999999% (11 nines) 내구성
- 용도: 이미지, 동영상, 백업, 로그, 정적 웹사이트 호스팅

### 7.2 S3 버킷 생성

#### Step 1: S3 서비스 접속

1. AWS Console 검색창에 **"S3"** 입력
2. **S3** 서비스 선택

#### Step 2: 버킷 생성

1. **"Create bucket"** 버튼 클릭

#### Step 3: 버킷 이름 및 리전

```
Bucket name: my-pm-training-bucket-2025
  - 전 세계적으로 고유해야 함
  - 소문자, 숫자, 하이픈만 사용
  - 예시: my-pm-training-bucket-2025

AWS Region: Asia Pacific (Seoul) ap-northeast-2
```

#### Step 4: 객체 소유권

**"ACLs disabled (recommended)"** 선택 (기본값)

#### Step 5: 퍼블릭 액세스 차단 설정

**"Block all public access"** 체크 ✅ (기본값)
- 안전을 위해 공개 접근 차단
- 실습에서는 나중에 특정 파일만 공개 가능

#### Step 6: 버전 관리 (선택)

**"Disable"** 선택 (기본값)
- Versioning: 파일의 이전 버전 보존
- 학습 목적이므로 비활성화

#### Step 7: 기본 암호화

**"Enable"** 유지 (기본값)
- 저장된 모든 객체 자동 암호화

**"Create bucket"** 클릭

### 7.3 파일 업로드

#### Step 1: 버킷 열기

1. S3 버킷 목록에서 방금 만든 버킷 클릭
   - `my-pm-training-bucket-2025`

#### Step 2: 파일 업로드

1. **"Upload"** 버튼 클릭
2. **"Add files"** 클릭
   - 로컬 컴퓨터에서 파일 선택 (예: 이미지, PDF 등)
   - 또는 드래그 앤 드롭
3. **"Upload"** 클릭

#### Step 3: 업로드 확인

- 파일 목록에 업로드된 파일 표시
- 크기, 업로드 시간 확인

#### Step 4: 파일 URL 확인

1. 파일 이름 클릭
2. **"Object URL"** 확인:
   ```
   https://my-pm-training-bucket-2025.s3.ap-northeast-2.amazonaws.com/sample.jpg
   ```
3. URL 복사하여 브라우저에서 열기 시도
   - "Access Denied" 오류 발생 (정상, 공개 접근 차단되어 있음)

### 7.4 파일 공개 설정 (선택)

**특정 파일을 인터넷에 공개하려면**:

#### Step 1: 버킷 정책 수정

1. 버킷 페이지에서 **"Permissions"** 탭 클릭
2. **"Block public access (bucket settings)"** → **"Edit"** 클릭
3. **"Block all public access"** 체크 해제
4. 경고 확인 → **"confirm"** 입력 → **"Save changes"**

#### Step 2: 버킷 정책 추가

1. **"Bucket policy"** → **"Edit"** 클릭
2. 다음 정책 붙여넣기 (버킷 이름 수정 필요):
   ```json
   {
     "Version": "2012-10-17",
     "Statement": [
       {
         "Sid": "PublicReadGetObject",
         "Effect": "Allow",
         "Principal": "*",
         "Action": "s3:GetObject",
         "Resource": "arn:aws:s3:::my-pm-training-bucket-2025/*"
       }
     ]
   }
   ```
   - `my-pm-training-bucket-2025`: 본인의 버킷 이름으로 변경!

3. **"Save changes"** 클릭

#### Step 3: 파일 공개 확인

1. 파일 URL 다시 접속:
   ```
   https://my-pm-training-bucket-2025.s3.ap-northeast-2.amazonaws.com/sample.jpg
   ```
2. 이제 파일이 표시됨!

**⚠️ 주의**: 민감한 정보는 공개하지 마세요!

---

## 8. 리소스 정리 및 종료

### 8.1 왜 리소스 정리가 중요한가?

**요금 발생 방지**:
- 사용하지 않는 리소스도 요금 청구될 수 있음
- EC2 중지 시에도 EBS 볼륨 요금 발생
- Elastic IP 미사용 시 요금 발생

### 8.2 EC2 인스턴스 종료

#### 방법 1: 중지 (Stop)

**용도**: 나중에 다시 사용할 예정

1. EC2 Console → **Instances** 클릭
2. 인스턴스 선택 (체크박스)
3. **"Instance state"** → **"Stop instance"** 클릭
4. 확인: **"Stop"** 클릭

**효과**:
- 인스턴스 중지 (컴퓨팅 요금 없음)
- EBS 볼륨은 유지 (스토리지 요금 약 $1/월)
- Public IP 주소 변경됨 (Elastic IP 사용 시 유지)

#### 방법 2: 종료 (Terminate) ⭐ 권장

**용도**: 더 이상 사용하지 않음

1. EC2 Console → **Instances** 클릭
2. 인스턴스 선택 (체크박스)
3. **"Instance state"** → **"Terminate instance"** 클릭
4. 확인: **"Terminate"** 클릭

**효과**:
- 인스턴스 완전히 삭제
- EBS 볼륨도 삭제 (기본 설정)
- **요금 없음!**

**⚠️ 주의**: 종료 후 복구 불가능!

### 8.3 S3 버킷 삭제

#### Step 1: 버킷 비우기

1. S3 Console → 버킷 선택
2. 버킷 이름 옆 라디오 버튼 클릭 (체크박스 아님!)
3. **"Empty"** 버튼 클릭
4. 확인: `permanently delete` 입력 → **"Empty"** 클릭

#### Step 2: 버킷 삭제

1. 빈 버킷 선택
2. **"Delete"** 버튼 클릭
3. 확인: 버킷 이름 입력 → **"Delete bucket"** 클릭

### 8.4 Elastic IP 해제 (있는 경우)

1. EC2 Console → 좌측 메뉴 **"Elastic IPs"** 클릭
2. 할당된 IP 선택
3. **"Actions"** → **"Release Elastic IP address"** 클릭
4. 확인: **"Release"** 클릭

### 8.5 보안 그룹 삭제 (선택)

기본 보안 그룹은 삭제할 수 없지만, 직접 생성한 것은 삭제 가능

1. EC2 Console → 좌측 메뉴 **"Security Groups"** 클릭
2. 사용하지 않는 보안 그룹 선택
3. **"Actions"** → **"Delete security group"** 클릭

### 8.6 리소스 정리 체크리스트

- [ ] EC2 인스턴스 종료 (Terminate)
- [ ] S3 버킷 비우기 및 삭제
- [ ] Elastic IP 해제
- [ ] 스냅샷 삭제 (있는 경우)
- [ ] AMI 등록 해제 (직접 생성한 경우)
- [ ] CloudWatch 알람 확인 (불필요한 것 삭제)

### 8.7 비용 확인

1. **Billing and Cost Management** 접속
2. **"Bills"** 클릭
3. 현재 월 청구액 확인:
   ```
   Total charges: $0.00 또는 소액
   ```
4. 서비스별 사용량 확인

---

## 9. PM을 위한 AWS 활용 팁

### 9.1 PM이 알아야 할 AWS 서비스

#### 핵심 서비스 (필수)

**컴퓨팅**:
- **EC2**: 가상 서버
- **Lambda**: 서버리스 함수

**스토리지**:
- **S3**: 객체 저장소
- **EBS**: 블록 스토리지 (EC2 디스크)

**데이터베이스**:
- **RDS**: 관리형 관계형 DB (MySQL, PostgreSQL)
- **DynamoDB**: NoSQL 데이터베이스

**네트워킹**:
- **VPC**: 가상 네트워크
- **CloudFront**: CDN (콘텐츠 전송 네트워크)
- **Route 53**: DNS 서비스

#### 중급 서비스

**컨테이너**:
- **ECS**: 컨테이너 오케스트레이션
- **EKS**: Kubernetes 관리형 서비스

**분석**:
- **Athena**: S3 데이터 SQL 쿼리
- **QuickSight**: BI 도구

**보안**:
- **IAM**: 사용자 및 권한 관리
- **KMS**: 암호화 키 관리

### 9.2 클라우드 비용 최적화 (FinOps)

**PM의 역할**:

1. **비용 가시성 확보**
   - Cost Explorer 정기 확인
   - 서비스별 비용 추적
   - 예산 대비 실제 비용 모니터링

2. **Right-sizing**
   - 과도한 인스턴스 크기 식별
   - 사용률 낮은 리소스 축소 또는 종료
   - Reserved Instances 활용 (1년/3년 약정 시 최대 75% 할인)

3. **태깅 전략**
   - 프로젝트별 태그:
     ```
     Project: ChatbotAI
     Environment: Production
     Owner: PMTeam
     ```
   - 비용 할당 및 추적 용이

4. **자동화**
   - Dev 환경: 업무 시간에만 실행 (EC2 Auto Scaling Schedule)
   - 불필요한 스냅샷 자동 삭제
   - Lambda로 비용 알림 자동화

### 9.3 PM을 위한 AWS 아키텍처 이해

**3-Tier 웹 애플리케이션 예시**:

```
                     사용자
                       |
                       ↓
              [Route 53 - DNS]
                       |
                       ↓
           [CloudFront - CDN]
                       |
                       ↓
            [ALB - Load Balancer]
                   /        \
                  ↓          ↓
          [EC2]         [EC2]      (Web/App Tier)
                   \        /
                       ↓
               [RDS - Database]    (Data Tier)
                       |
                       ↓
               [S3 - Backup]
```

**PM이 확인할 사항**:
- 단일 장애점 (SPOF) 없는지
- Auto Scaling 설정 여부
- 백업 및 복구 전략
- 보안 그룹 설정 적절성

### 9.4 AWS 문서 및 리소스 활용

**공식 문서**:
- AWS Documentation: https://docs.aws.amazon.com
- AWS 한국어 블로그: https://aws.amazon.com/ko/blogs/korea/

**학습 자료**:
- AWS Skill Builder: https://skillbuilder.aws
  - 무료 온라인 코스
  - AWS Cloud Practitioner 자격증 준비
- AWS re:Invent 세션: YouTube에서 검색

**비용 계산**:
- AWS Pricing Calculator: https://calculator.aws
  - 예상 비용 산정
  - 프로젝트 제안서 작성 시 유용

**지원**:
- AWS Support Center
- AWS Forums
- Stack Overflow (aws 태그)

### 9.5 프로젝트에서 AWS 활용 시나리오

**시나리오 1: 스타트업 MVP 개발**
```
서비스: EC2 (t2.micro), RDS (db.t2.micro), S3, CloudFront
비용: 월 $50 이하 (Free Tier 활용)
장점: 빠른 출시, 낮은 초기 비용
```

**시나리오 2: 데이터 분석 플랫폼**
```
서비스: S3, Athena, QuickSight, Lambda
비용: 데이터량에 따라 가변 (GB당 $0.023)
장점: 서버리스, 스케일링 자동
```

**시나리오 3: 글로벌 서비스**
```
서비스: Route 53, CloudFront, Multi-Region EC2, Aurora Global Database
비용: 월 수백~수천 달러
장점: 낮은 지연시간, 높은 가용성
```

---

## 10. 문제 해결

### 10.1 계정 생성 문제

**문제**: 신용카드 결제 실패

**원인**:
- 해외 결제 차단
- 카드 한도 초과
- 유효기간 만료

**해결**:
- 카드사에 해외 결제 가능 여부 확인
- 다른 카드 시도
- 체크카드 대신 신용카드 사용

---

**문제**: 이메일 인증 코드가 오지 않음

**해결**:
- 스팸 메일함 확인
- 5-10분 대기
- 다른 이메일 주소 사용

---

### 10.2 EC2 접속 문제

**문제**: "Permission denied (publickey)"

**원인**: 키 파일 권한 또는 경로 문제

**해결**:
```bash
# 키 파일 권한 변경
chmod 400 my-ec2-key.pem

# 정확한 경로 사용
ssh -i /path/to/my-ec2-key.pem ec2-user@3.35.123.45
```

---

**문제**: "Connection timed out"

**원인**: 보안 그룹 규칙 또는 네트워크 문제

**해결**:
- 보안 그룹에 SSH (Port 22) 허용 확인
- 인스턴스 상태가 "Running"인지 확인
- 올바른 Public IP 사용 확인

---

### 10.3 S3 문제

**문제**: "Access Denied" 오류

**원인**: 권한 부족 또는 퍼블릭 액세스 차단

**해결**:
- 버킷 정책 확인
- IAM 권한 확인
- "Block public access" 설정 확인

---

**문제**: 업로드한 파일이 보이지 않음

**해결**:
- 브라우저 새로고침
- 올바른 버킷인지 확인
- 리전 확인 (Seoul 리전에 업로드했는지)

---

### 10.4 요금 발생 문제

**문제**: 예상치 못한 요금 청구

**원인**:
- Free Tier 한도 초과
- 리소스 종료하지 않음
- 데이터 전송량 초과

**해결**:
1. **Cost Explorer** 확인:
   - Billing Dashboard → "Cost Explorer"
   - 서비스별 비용 상세 조회
2. **리소스 정리**:
   - 사용하지 않는 EC2 인스턴스 종료
   - Elastic IP 해제
   - 불필요한 S3 데이터 삭제
   - EBS 스냅샷 삭제
3. **AWS Support 문의**:
   - Support Center → "Create case"
   - 비용 관련 문의는 무료

---

### 10.5 보안 문제

**문제**: Root 계정 유출 우려

**해결**:
1. 즉시 비밀번호 변경
2. MFA 활성화
3. CloudTrail 로그 확인 (의심스러운 활동)
4. AWS Support에 연락

---

**문제**: IAM 사용자 비밀번호 분실

**해결**:
- Root 계정으로 로그인
- IAM → Users → 해당 사용자 선택
- "Security credentials" 탭 → "Manage" → 비밀번호 재설정

---

## 📚 추가 학습 자료

### 공식 문서
- AWS 한국어 문서: https://docs.aws.amazon.com/ko_kr/
- AWS Well-Architected Framework: https://aws.amazon.com/architecture/well-architected/

### 온라인 코스
- AWS Skill Builder (무료): https://skillbuilder.aws
- AWS Cloud Practitioner Essentials: https://aws.amazon.com/training/
- Udemy: "Ultimate AWS Certified Cloud Practitioner"

### 자격증
- **AWS Certified Cloud Practitioner** (입문)
  - 비용: $100
  - 난이도: 초급
  - PM에게 추천!
- AWS Certified Solutions Architect - Associate (중급)

### 유튜브 채널
- AWS 한국 채널: https://www.youtube.com/@AWSKorea
- AWS Online Tech Talks

---

## ✅ 학습 체크리스트

### 기본 (필수)
- [ ] AWS 계정 생성 완료
- [ ] Free Tier 이해
- [ ] 비용 알림 설정 완료
- [ ] IAM 사용자 생성 및 로그인
- [ ] EC2 인스턴스 생성 및 접속 성공
- [ ] 웹 서버 실습 완료
- [ ] S3 버킷 생성 및 파일 업로드
- [ ] 리소스 정리 및 종료 완료

### 중급 (권장)
- [ ] MFA 설정 완료
- [ ] 보안 그룹 규칙 이해
- [ ] S3 파일 공개 설정 경험
- [ ] Cost Explorer로 비용 분석
- [ ] 여러 인스턴스 유형 비교
- [ ] 스냅샷 생성 및 AMI 활용

### 고급 (선택)
- [ ] VPC 및 서브넷 이해
- [ ] RDS 데이터베이스 생성
- [ ] Lambda 함수 작성
- [ ] CloudWatch 모니터링 설정
- [ ] Auto Scaling 그룹 구성

---

## 🎓 마무리

축하합니다! 이제 PM으로서 AWS 클라우드를 활용할 준비가 되었습니다.

### 핵심 요약
- **Free Tier**: 12개월 무료 (t2.micro, 750시간/월)
- **비용 관리**: 알림 설정 필수!
- **보안**: IAM 사용자 + MFA
- **EC2**: 가상 서버 (실습 완료!)
- **S3**: 객체 스토리지 (파일 업로드 완료!)

### 실무 활용
- 프로젝트 범위 산정
- 클라우드 아키텍처 검토
- 비용 추정 및 최적화
- 개발팀과의 기술 소통

### 다음 단계
1. Week 15 수업에서 더 깊이 학습
2. 다른 AWS 서비스 탐색 (RDS, Lambda)
3. AWS Cloud Practitioner 자격증 준비
4. 실제 프로젝트에 AWS 적용

**Happy Cloud Computing! ☁️**

---

**문서 버전**: 1.0  
**최종 업데이트**: 2025년 2월  
**관련 문서**: [GitHub 실습 가이드](./github-setup-guide.md), [SQL 실습 가이드](./sql-practice-guide.md)

---

## ⚠️ 최종 주의사항

1. **리소스 종료 확인**: 실습 완료 후 반드시 EC2 인스턴스 종료!
2. **비용 모니터링**: 일주일에 한 번 Billing Dashboard 확인
3. **보안**: Root 계정은 긴급 시에만 사용, IAM 사용자 활용
4. **Free Tier 기간**: 계정 생성일로부터 12개월 (달력에 표시하세요!)
5. **질문/이슈**: AWS Support 또는 포럼 활용

**즐거운 학습 되세요! 🚀**
