# Week 13: 소프트웨어 공학 (Software Engineering)

## 📝 학습 목표
- 소프트웨어 개발 생명주기(SDLC) 이해
- 소프트웨어 개발 방법론의 종류와 특성 학습
- 소프트웨어 품질 보증 및 테스팅 이해
- 버전 관리 및 CI/CD 개념 습득

## 📚 주요 내용

### 1. 소프트웨어 공학 개요

#### 1.1 소프트웨어 공학이란?
- **정의**: 소프트웨어 제품을 체계적이고 규율적이며 정량화 가능한 방법으로 개발, 운영, 유지보수하는 학문
- **목표**:
  - 고품질 소프트웨어 개발
  - 예측 가능한 일정 및 비용
  - 유지보수 용이성
  - 확장 가능성

#### 1.2 소프트웨어의 특성
- **비가시성**: 눈에 보이지 않는 제품
- **복잡성**: 높은 논리적 복잡도
- **순응성**: 환경 변화에 따른 수정 필요
- **변경 가능성**: 지속적인 요구사항 변경

### 2. 소프트웨어 개발 생명주기 (SDLC)

#### 2.1 SDLC 단계
```
요구사항 분석 → 설계 → 구현 → 테스트 → 배포 → 유지보수
```

**1. 요구사항 분석 (Requirements Analysis):**
- 기능적 요구사항 (Functional Requirements)
  - 시스템이 수행해야 할 기능
  - 예: "사용자는 로그인할 수 있어야 한다"
- 비기능적 요구사항 (Non-functional Requirements)
  - 성능, 보안, 가용성, 확장성
  - 예: "응답 시간은 3초 이내"

**2. 설계 (Design):**
- 아키텍처 설계
  - 시스템 구조 정의
  - 모듈 간 관계 설계
- 상세 설계
  - 클래스 다이어그램
  - 데이터베이스 스키마
  - API 명세

**3. 구현 (Implementation):**
- 프로그래밍 언어로 코드 작성
- 코딩 표준 준수
- 문서화

**4. 테스트 (Testing):**
- 단위 테스트 (Unit Test)
- 통합 테스트 (Integration Test)
- 시스템 테스트 (System Test)
- 인수 테스트 (Acceptance Test)

**5. 배포 (Deployment):**
- 운영 환경에 소프트웨어 설치
- 사용자 교육
- 운영 모니터링

**6. 유지보수 (Maintenance):**
- 오류 수정 (Corrective)
- 기능 개선 (Adaptive)
- 성능 향상 (Perfective)
- 예방적 조치 (Preventive)

#### 2.2 SDLC 모델

**폭포수 모델 (Waterfall Model):**
```
요구사항 ↓
설계      ↓
구현      ↓
테스트    ↓
유지보수  ↓
```
- 장점: 명확한 단계, 문서화 충실
- 단점: 변경 어려움, 늦은 피드백

**나선형 모델 (Spiral Model):**
- 반복적 개발
- 리스크 분석 중심
- 프로토타입 활용

**V 모델 (V-Model):**
```
요구사항 ←→ 인수 테스트
설계     ←→ 시스템 테스트
상세설계 ←→ 통합 테스트
구현     ←→ 단위 테스트
```
- 테스트 중심 모델
- 각 개발 단계에 대응하는 테스트 단계

### 3. 소프트웨어 개발 방법론

#### 3.1 전통적 방법론 (Traditional)
- 계획 중심 (Plan-driven)
- 문서 중심
- 순차적 개발
- 대규모 프로젝트에 적합

#### 3.2 애자일 방법론 (Agile)
- 반복적 개발
- 고객 협력
- 변화 수용
- 소규모 팀에 적합
- 종류: 스크럼, XP, 칸반 (Week 9 참조)

#### 3.3 DevOps
- 개발(Dev)과 운영(Ops)의 통합
- 지속적 통합/배포 (CI/CD)
- 자동화 강조
- 빠른 피드백 루프

### 4. 소프트웨어 아키텍처

#### 4.1 아키텍처 패턴

**계층 아키텍처 (Layered Architecture):**
```
┌─────────────────┐
│ Presentation    │ (UI)
├─────────────────┤
│ Business Logic  │ (서비스)
├─────────────────┤
│ Data Access     │ (DAO)
├─────────────────┤
│ Database        │
└─────────────────┘
```
- 관심사의 분리
- 계층 간 의존성 관리

**MVC 패턴 (Model-View-Controller):**
```
View ←→ Controller ←→ Model
```
- Model: 데이터 및 비즈니스 로직
- View: 사용자 인터페이스
- Controller: 입력 처리 및 조율

**마이크로서비스 아키텍처:**
```
API Gateway
    ↓
┌─────┬─────┬─────┬─────┐
│서비스A│서비스B│서비스C│서비스D│
└─────┴─────┴─────┴─────┘
```
- 독립적인 서비스 단위
- 각 서비스는 독립적으로 배포
- 확장성, 유연성 향상

#### 4.2 디자인 원칙

**SOLID 원칙:**
- **S**ingle Responsibility: 단일 책임 원칙
- **O**pen/Closed: 개방-폐쇄 원칙
- **L**iskov Substitution: 리스코프 치환 원칙
- **I**nterface Segregation: 인터페이스 분리 원칙
- **D**ependency Inversion: 의존성 역전 원칙

**DRY (Don't Repeat Yourself):**
- 중복 코드 제거
- 재사용성 향상

**KISS (Keep It Simple, Stupid):**
- 단순하게 유지
- 불필요한 복잡성 제거

### 5. 소프트웨어 테스팅

#### 5.1 테스트 레벨

**단위 테스트 (Unit Test):**
- 개별 함수/메서드 테스트
- 빠른 실행
- 개발자가 작성
- 예: JUnit, pytest, Jest

**통합 테스트 (Integration Test):**
- 모듈 간 상호작용 테스트
- API 테스트
- 데이터베이스 연동 테스트

**시스템 테스트 (System Test):**
- 전체 시스템 테스트
- 기능 및 비기능 요구사항 검증

**인수 테스트 (Acceptance Test):**
- 사용자 관점 테스트
- 비즈니스 요구사항 충족 확인
- UAT (User Acceptance Test)

#### 5.2 테스트 기법

**블랙박스 테스팅:**
- 내부 구조 모름
- 입력-출력 기반
- 동등 분할, 경계값 분석

**화이트박스 테스팅:**
- 내부 구조 알고 테스트
- 코드 커버리지
- 문장, 분기, 경로 커버리지

**회귀 테스팅 (Regression Testing):**
- 수정 후 기존 기능 확인
- 자동화 권장

#### 5.3 테스트 자동화
- 반복적 테스트 자동화
- CI/CD 파이프라인 통합
- 빠른 피드백
- 도구: Selenium, Cypress, Postman

### 6. 버전 관리 (Version Control)

#### 6.1 Git 기초

**Git 개념:**
- 분산 버전 관리 시스템
- 변경 이력 추적
- 협업 지원

**주요 명령어:**
```bash
git init           # 저장소 초기화
git clone          # 저장소 복제
git add            # 스테이징
git commit         # 커밋
git push           # 원격 저장소로 푸시
git pull           # 원격 저장소에서 가져오기
git branch         # 브랜치 관리
git merge          # 브랜치 병합
```

**브랜치 전략:**
- Git Flow
  - main, develop, feature, release, hotfix
- GitHub Flow
  - main, feature 브랜치
  - Pull Request 중심

#### 6.2 코드 리뷰
- Pull Request (PR) / Merge Request (MR)
- 코드 품질 향상
- 지식 공유
- 버그 조기 발견

### 7. CI/CD (Continuous Integration/Continuous Deployment)

#### 7.1 CI (지속적 통합)
- 코드 변경 시 자동 빌드
- 자동 테스트 실행
- 빠른 피드백
- 통합 문제 조기 발견

**CI 도구:**
- Jenkins
- GitLab CI
- GitHub Actions
- CircleCI

#### 7.2 CD (지속적 배포)
- 자동 배포
- 운영 환경까지 자동화
- 빠른 출시 주기

**CD 파이프라인:**
```
코드 커밋 → 빌드 → 테스트 → 스테이징 배포 → 프로덕션 배포
```

#### 7.3 CI/CD 모범 사례
- 작은 단위로 자주 커밋
- 빌드는 빠르게 (10분 이내)
- 자동화된 테스트
- 배포 자동화
- 롤백 계획

### 8. 코드 품질

#### 8.1 코드 리뷰 체크리스트
- ✅ 기능 요구사항 충족
- ✅ 버그 및 예외 처리
- ✅ 성능 고려
- ✅ 보안 취약점 없음
- ✅ 코딩 표준 준수
- ✅ 테스트 코드 작성
- ✅ 문서화

#### 8.2 정적 분석 도구
- **린터 (Linter)**: ESLint, Pylint
- **포맷터 (Formatter)**: Prettier, Black
- **정적 분석**: SonarQube, CodeClimate

#### 8.3 코드 메트릭
- **코드 커버리지**: 테스트 커버리지 비율
- **순환 복잡도**: 코드 복잡도 측정
- **기술 부채**: 개선이 필요한 코드

### 9. 소프트웨어 문서화

#### 9.1 문서 종류
- **요구사항 명세서 (SRS)**: Software Requirements Specification
- **설계 문서 (SDD)**: Software Design Document
- **API 문서**: API 명세 및 사용법
- **사용자 매뉴얼**: 사용자 가이드
- **개발자 가이드**: 개발 환경 설정, 코딩 가이드

#### 9.2 API 문서화
- Swagger/OpenAPI
- Postman Collection
- README.md

### 10. PM이 알아야 할 소프트웨어 개발 지식

#### 10.1 기술 스택 이해
- **프론트엔드**: HTML, CSS, JavaScript, React, Vue
- **백엔드**: Java, Python, Node.js, .NET
- **데이터베이스**: MySQL, PostgreSQL, MongoDB
- **클라우드**: AWS, Azure, GCP

#### 10.2 개발자와의 커뮤니케이션
- 기술 용어 이해
- 현실적인 일정 추정
- 기술적 리스크 파악
- 기술 부채 관리

#### 10.3 개발 프로세스 관리
- 스프린트 계획
- 코드 리뷰 프로세스
- 배포 전략
- 장애 대응

## 💡 실습 과제

### 과제 1: SDLC 모델 비교
폭포수 모델, 애자일, DevOps의 장단점을 비교하고, 각 모델이 적합한 프로젝트 유형을 설명하시오 (A4 1페이지).

### 과제 2: Git 실습
1. GitHub에 새 저장소를 생성하시오.
2. 로컬에서 간단한 프로젝트를 생성하고 Git으로 관리하시오.
3. 브랜치를 생성하여 기능을 추가하고 병합하시오.
4. 스크린샷 제출 (커밋 히스토리, 브랜치 구조)

### 과제 3: CI/CD 파이프라인 설계
선정한 프로젝트의 CI/CD 파이프라인을 설계하고, 각 단계에서 수행할 작업을 정의하시오 (다이어그램 포함).

## 📖 참고 자료
- "소프트웨어 공학" by Roger S. Pressman
- "Clean Code" by Robert C. Martin
- "The Pragmatic Programmer" by Andrew Hunt & David Thomas
- "Continuous Delivery" by Jez Humble & David Farley
- Git 공식 문서: https://git-scm.com/doc

## ✅ 자가 점검 퀴즈

1. SDLC의 6단계를 순서대로 나열하시오.
2. 단위 테스트, 통합 테스트, 시스템 테스트의 차이는?
3. Git의 주요 장점 3가지는?
4. CI/CD의 차이점과 각각의 목적은?
5. SOLID 원칙의 5가지는?

## 📝 핵심 용어
- **SDLC (Software Development Life Cycle)**: 소프트웨어 개발 생명주기
- **CI/CD**: 지속적 통합/지속적 배포
- **Git**: 분산 버전 관리 시스템
- **TDD (Test-Driven Development)**: 테스트 주도 개발
- **코드 리뷰 (Code Review)**: 코드 품질 향상을 위한 동료 검토
- **리팩토링 (Refactoring)**: 기능 변경 없이 코드 구조 개선
- **기술 부채 (Technical Debt)**: 단기적 해결로 인한 장기적 비용

## 다음 주 예고
Week 14에서는 데이터베이스 기초와 SQL, 데이터 모델링을 학습합니다.
