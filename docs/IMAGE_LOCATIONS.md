# 🖼️ 커리큘럼 이미지 위치 가이드

## 📍 이미지가 어디 있나요?

모든 이미지는 **`copilot/create-curriculum-images` 브랜치**에 정상적으로 생성되어 있습니다.

### ✅ 전체 이미지 현황

총 **24개의 SVG 이미지**가 생성되었으며, 모두 커밋되어 있습니다.

---

## 📂 이미지 위치 상세

### 1️⃣ 루트 디렉토리 - 전체 프로그램 개요 (2개)

```
/images/
├── curriculum-phases-overview.svg      # 4단계 Phase별 커리큘럼 구조
└── curriculum-timeline.svg             # 16주 타임라인 및 마일스톤
```

**README에서 확인**:
- [메인 README.md](../README.md) 의 "📚 커리큘럼 구성" 섹션

---

### 2️⃣ Week 0: 오리엔테이션 (4개)

```
/curriculum/week00-pm-orientation/images/
├── week00-pm-orientation_images_curriculum-overview.svg        # 전체 커리큘럼 구조
├── week00-pm-orientation_images_pmbok-it-integration.svg       # PMBOK+IT 통합 모델
├── week00-pm-orientation_images_learning-roadmap.svg           # 16주 학습 로드맵
└── week00-pm-orientation_images_project-constraints.svg        # 4대 제약조건 극복 전략
```

**README에서 확인**:
- [Week 0 README](../curriculum/week00-pm-orientation/week00-pm-orientation_README.md)

---

### 3️⃣ Week 1-16: 주차별 이미지 (18개)

#### Week 1: PM의 이해 (2개)
```
/curriculum/week01-pm-introduction/images/
├── week01-pm-introduction_images_pm-role.svg              # PM의 핵심 역할
└── week01-pm-introduction_images_project-lifecycle.svg    # 프로젝트 생명주기
```

#### Week 2: PM 기초 (1개)
```
/curriculum/week02-pm-fundamentals/images/
└── week02-pm-fundamentals_images_process-groups-knowledge-areas.svg  # PMBOK 매트릭스
```

#### Week 3: 이해관계자 관리 (1개)
```
/curriculum/week03-stakeholder-management/images/
└── week03-stakeholder-management_images_stakeholder-matrix.svg  # 이해관계자 매트릭스
```

#### Week 4: 범위 관리 (1개)
```
/curriculum/week04-scope-management/images/
└── week04-scope-management_images_wbs-example.svg  # WBS 예시
```

#### Week 5: 일정 관리 (2개)
```
/curriculum/week05-schedule-management/images/
├── week05-schedule-management_images_gantt-chart.svg      # 간트 차트
└── week05-schedule-management_images_critical-path.svg    # 크리티컬 패스
```

#### Week 6: 원가 관리 (1개)
```
/curriculum/week06-cost-management/images/
└── week06-cost-management_images_evm-chart.svg  # EVM 차트
```

#### Week 7: 품질/리스크 관리 (1개)
```
/curriculum/week07-quality-risk-management/images/
└── week07-quality-risk-management_images_risk-matrix.svg  # 리스크 매트릭스
```

#### Week 8: 자원/조달 관리 (2개)
```
/curriculum/week08-resource-procurement/images/
├── week08-resource-procurement_images_resource-allocation.svg   # 자원 배분
└── week08-resource-procurement_images_procurement-process.svg   # 조달 프로세스
```

#### Week 9: 애자일/스크럼 (1개)
```
/curriculum/week09-agile-scrum/images/
└── week09-agile-scrum_images_scrum-framework.svg  # 스크럼 프레임워크
```

#### Week 10: PM 도구 활용 (1개)
```
/curriculum/week10-pm-tools/images/
└── week10-pm-tools_images_pm-tools-overview.svg  # PM 도구 개요
```

#### Week 11-12: 모의 프로젝트 (1개)
```
/curriculum/week11-12-mock-project/images/
└── week11-12-mock-project_images_project-timeline.svg  # 프로젝트 타임라인
```

#### Week 13: 소프트웨어 공학 (1개)
```
/curriculum/week13-software-engineering/images/
└── week13-software-engineering_images_sdlc-diagram.svg  # SDLC 다이어그램
```

#### Week 14: 데이터베이스 (1개)
```
/curriculum/week14-database/images/
└── week14-database_images_erd-example.svg  # ERD 예시
```

#### Week 15: 클라우드 (1개)
```
/curriculum/week15-cloud/images/
└── week15-cloud_images_cloud-architecture.svg  # 클라우드 아키텍처
```

#### Week 16: 네트워크 (1개)
```
/curriculum/week16-network/images/
└── week16-network_images_network-topology.svg  # 네트워크 토폴로지
```

---

## 🔍 GitHub에서 이미지 확인하는 방법

### 방법 1: 브랜치 선택하여 보기
1. GitHub 저장소로 이동
2. 브랜치 선택 드롭다운 클릭
3. `copilot/create-curriculum-images` 브랜치 선택
4. 원하는 README 파일로 이동하여 이미지 확인

### 방법 2: Pull Request에서 확인
1. 해당 PR로 이동
2. "Files changed" 탭에서 추가된 이미지 파일 확인
3. README 파일에서 이미지가 어떻게 참조되는지 확인

### 방법 3: 직접 파일 경로로 접근
```
https://github.com/goodhitpe/pm-expert-training/blob/copilot/create-curriculum-images/images/curriculum-phases-overview.svg
```

---

## 📊 이미지 통계

| 카테고리 | 개수 | 상태 |
|---------|------|------|
| 루트 개요 이미지 | 2개 | ✅ |
| Week 0 오리엔테이션 | 4개 | ✅ |
| Week 1-16 주차별 | 18개 | ✅ |
| **총 이미지** | **24개** | **✅ 모두 생성 완료** |

---

## 🎨 이미지 파일 형식

- **포맷**: SVG (Scalable Vector Graphics)
- **장점**: 
  - 확대/축소 시에도 품질 유지
  - 텍스트 기반으로 편집 가능
  - 파일 크기가 작음
  - GitHub에서 직접 렌더링 지원

---

## ✨ 다음 단계

이미지들이 모두 정상적으로 생성되었습니다. PR을 main 브랜치에 머지하면 모든 이미지가 공식적으로 저장소에 포함됩니다.

**참고**: 이미지는 `copilot/create-curriculum-images` 브랜치에 있으므로, main 브랜치를 보고 계시다면 이미지가 보이지 않을 수 있습니다.
