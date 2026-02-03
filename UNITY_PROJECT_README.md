# 🎓 Unity LMS 프로젝트 문서 가이드

> **시작일**: 2025년 2월 3일  
> **현재 상태**: Phase 1 요구사항 정의 완료

---

## 📚 문서 목록

### 1. [Phase 1 요구사항 정의서](./UNITY_LMS_PHASE1_REQUIREMENTS.md) ⭐⭐⭐
**목적**: Unity 기반 LMS 및 프로젝트 시뮬레이터 개발을 위한 전체 요구사항 정의

**주요 내용**:
- 프로젝트 개요 및 목표
- 기능 요구사항 (LMS + 시뮬레이터)
- 비기능 요구사항 (성능, 플랫폼, 보안)
- Unity 기술 스택 및 데이터 구조
- Phase 1 개발 범위 및 우선순위
- 기존 자료 통합 방안
- 성공 지표 (KPI)

**대상 독자**: 전체 팀 (PM, 개발자, 디자이너, 이해관계자)

---

### 2. [기술 사양서](./UNITY_PROJECT_TECHNICAL_SPEC.md) ⭐⭐
**목적**: 시스템 아키텍처 및 기술적 구현 방법 상세 정의

**주요 내용**:
- 시스템 아키텍처 및 레이어 구조
- 핵심 시스템 설계 (DataManager, SceneManager, EventBus 등)
- LMS/시뮬레이터 모듈 설계
- UI/UX 설계
- 데이터 변환 파이프라인
- 성능 최적화 전략
- 테스트 및 배포 전략

**대상 독자**: Unity 개발자, 백엔드 개발자

---

### 3. [구현 로드맵](./UNITY_IMPLEMENTATION_ROADMAP.md) ⭐⭐⭐
**목적**: 8주 Phase 1 개발 일정 및 마일스톤 관리

**주요 내용**:
- 주차별 상세 개발 일정
- 산출물 (Deliverables)
- 성공 기준 (Definition of Done)
- 리스크 관리
- 예산 계획
- 커뮤니케이션 계획

**대상 독자**: PM, 전체 팀

---

### 4. [프로젝트 구조 설계서](./UNITY_PROJECT_STRUCTURE.md) ⭐
**목적**: Unity 프로젝트 폴더 구조 및 코드 구조 표준화

**주요 내용**:
- 프로젝트 폴더 구조
- 핵심 스크립트 구조 및 코드 예제
- 씬 구조
- 에셋 명명 규칙
- ScriptableObject 활용
- 코딩 컨벤션
- Git 워크플로우

**대상 독자**: Unity 개발자

---

## 🚀 빠른 시작 가이드

### Step 1: 요구사항 이해
1. **[Phase 1 요구사항 정의서](./UNITY_LMS_PHASE1_REQUIREMENTS.md)** 전체 읽기
2. MVP(Minimum Viable Product) 범위 확인
3. 우선순위 이해 (P0 → P1 → P2)

### Step 2: 기술 스택 파악
1. **[기술 사양서](./UNITY_PROJECT_TECHNICAL_SPEC.md)** 아키텍처 섹션 검토
2. Unity 2022 LTS 및 필수 패키지 확인
3. 데이터 모델 이해

### Step 3: 개발 계획 수립
1. **[구현 로드맵](./UNITY_IMPLEMENTATION_ROADMAP.md)** Week별 작업 확인
2. 팀원 역할 분담
3. Jira 태스크 생성

### Step 4: 프로젝트 초기화
1. **[프로젝트 구조 설계서](./UNITY_PROJECT_STRUCTURE.md)** 참고하여 Unity 프로젝트 생성
2. 폴더 구조 및 명명 규칙 적용
3. Git 리포지토리 설정

---

## 📊 개발 단계별 체크리스트

### ✅ Phase 0: 준비 (현재 완료)
- [x] 요구사항 정의
- [x] 기술 사양 작성
- [x] 구현 로드맵 작성
- [x] 프로젝트 구조 설계

### ⏳ Phase 1: 개발 (예정, 8주)
- [ ] Week 1-2: 프로젝트 초기화 및 프로토타입
- [ ] Week 3-4: LMS 핵심 기능
- [ ] Week 5-6: 시뮬레이터 핵심 기능
- [ ] Week 7: 통합 및 테스트
- [ ] Week 8: 폴리싱 및 릴리즈

### 🔮 Phase 2: 확장 (미래)
- [ ] 전체 6개 시뮬레이션 시나리오
- [ ] 멘토 AI 시스템
- [ ] 모바일 버전
- [ ] 멀티플레이어 협업

---

## 🛠️ 개발 도구

### 필수 도구
- **Unity 2022 LTS**: [다운로드](https://unity.com/releases/editor/archive)
- **Visual Studio / Rider**: IDE
- **Git**: 버전 관리
- **Python 3.8+**: 데이터 변환 스크립트

### 권장 도구
- **Figma**: UI/UX 디자인
- **Jira**: 프로젝트 관리
- **Confluence**: 문서화
- **Blender**: 3D 모델링 (옵션)

---

## 🔄 데이터 변환 파이프라인

### 커리큘럼 데이터 변환

**스크립트**: `scripts/convert_curriculum_to_json.py`

**사용법**:
```bash
cd /path/to/pm-expert-training
python scripts/convert_curriculum_to_json.py
```

**출력**:
- `unity-data/curriculum.json`: 커리큘럼 전체 데이터
- `unity-data/case-studies.json`: 케이스 스터디 데이터
- `unity-data/sample_quiz.json`: 샘플 퀴즈 데이터

**Unity 프로젝트에 통합**:
```
unity-data/ → Unity Assets/Resources/Curriculum/
```

---

## 📐 아키텍처 다이어그램

### 시스템 전체 구조
```
┌─────────────────────────────────────────┐
│         Unity Application               │
├─────────────────────────────────────────┤
│  ┌────────────┐    ┌─────────────────┐ │
│  │ LMS Module │◄───┤Simulator Module │ │
│  └──────┬─────┘    └────────┬────────┘ │
│         │                   │          │
│  ┌──────▼───────────────────▼────────┐ │
│  │    Core Systems & Data Layer      │ │
│  └───────────────────────────────────┘ │
└─────────────────────────────────────────┘
           ▼                  ▼
    ┌────────────┐    ┌────────────┐
    │ Markdown   │    │ User Data  │
    │ Content    │    │ (Local)    │
    └────────────┘    └────────────┘
```

### 데이터 플로우
```
Markdown Files → Python Script → JSON → Unity Resources → C# Objects → UI
```

---

## 📞 연락 및 지원

### 질문 및 이슈
- **GitHub Issues**: 기술적 문제 및 버그 리포트
- **Discussions**: 일반 질문 및 아이디어 공유

### 문서 업데이트
문서 수정이 필요한 경우:
1. 해당 문서 파일 수정
2. 버전 이력 업데이트
3. PR 생성

---

## 📚 추가 참고 자료

### Unity 공식 문서
- [Unity Manual](https://docs.unity3d.com/Manual/index.html)
- [Unity Scripting API](https://docs.unity3d.com/ScriptReference/)
- [Unity Learn](https://learn.unity.com/)

### 디자인 패턴
- [Game Programming Patterns](https://gameprogrammingpatterns.com/)
- [Unity Design Patterns](https://github.com/QianMo/Unity-Design-Pattern)

### PM 교육 자료
- [프로젝트 매니저 커리큘럼](../curriculum/)
- [케이스 스터디](../case-studies/)
- [평가 체계](../assessment/)

---

## 🎯 다음 단계

### 즉시 실행 가능
1. **Unity 프로젝트 생성**
   - Unity Hub에서 새 프로젝트 생성
   - 템플릿: 3D (URP)
   - 프로젝트 이름: `pm-expert-training-unity`

2. **데이터 변환 실행**
   ```bash
   python scripts/convert_curriculum_to_json.py
   ```

3. **프로토타입 개발 시작**
   - LMS 메인 메뉴 UI
   - 커리큘럼 뷰어 기본 기능
   - 3D 환경 화이트박스

### 2주 후 목표
- LMS 프로토타입 완성
- 시뮬레이터 프로토타입 완성
- 데이터 로딩 시스템 완성

---

**마지막 업데이트**: 2025년 2월 3일  
**문서 버전**: 1.0  
**작성자**: PM Expert Training 개발팀
