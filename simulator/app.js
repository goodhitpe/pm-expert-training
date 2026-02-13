const STORAGE_KEY = "pmLifecycleSimulator.v1";

const stakeholders = [
  {
    name: "고객사 PM",
    prompt: "핵심 납기와 우선순위를 확인한다.",
    impact: { rfp: 12, business: 4, alignment: 10 },
    tag: "일정 우선"
  },
  {
    name: "현업 사용자 대표",
    prompt: "실사용 시나리오와 품질 기대치를 수집한다.",
    impact: { rfp: 8, business: 2, alignment: 12, quality: 4 },
    tag: "품질 우선"
  },
  {
    name: "재무 담당",
    prompt: "예산 제한과 ROI 기준을 확인한다.",
    impact: { rfp: 4, business: 12, alignment: 8, cost: 3 },
    tag: "비용 관리"
  },
  {
    name: "법무/보안 담당",
    prompt: "컴플라이언스 요구사항을 반영한다.",
    impact: { rfp: 10, business: 4, alignment: 8, quality: 3 },
    tag: "리스크 예방"
  },
  {
    name: "개발 리드",
    prompt: "기술 제약과 구현 가능 범위를 조율한다.",
    impact: { rfp: 10, business: 6, alignment: 8, scope: -2, schedule: 2 },
    tag: "범위 현실화"
  }
];

const weeklyEvents = [
  {
    week: 1,
    title: "요구사항 추가 요청",
    description: "고객이 핵심 기능 외 대시보드 고도화를 즉시 반영해달라고 요청했다.",
    actions: [
      { label: "전부 수용하고 일정 재산정", effect: { scope: 8, schedule: -10, cost: -6, quality: 2 } },
      { label: "MVP만 반영하고 2차 릴리스로 분리", effect: { scope: 3, schedule: -2, cost: -2, quality: 4 } },
      { label: "요청 반려", effect: { scope: -2, alignment: -8, quality: -3 } }
    ]
  },
  {
    week: 2,
    title: "핵심 인력 이탈",
    description: "백엔드 리드가 개인 사정으로 장기 휴가를 신청했다.",
    actions: [
      { label: "외부 전문가 단기 투입", effect: { cost: -9, schedule: 3, quality: 2 } },
      { label: "내부 인력 재배치", effect: { schedule: -5, quality: -3, cost: -2 } },
      { label: "기능 일부 축소", effect: { scope: -6, schedule: 4, quality: 1 } }
    ]
  },
  {
    week: 3,
    title: "테스트 결함 급증",
    description: "통합 테스트에서 중대 결함이 다수 발견되었다.",
    actions: [
      { label: "결함 우선 해결 스프린트", effect: { quality: 8, schedule: -5, cost: -3 } },
      { label: "경미 결함만 처리", effect: { quality: -6, schedule: 3, cost: 1 } },
      { label: "테스트 자동화 도구 도입", effect: { quality: 6, cost: -5, schedule: -2 } }
    ]
  },
  {
    week: 4,
    title: "협력사 납품 지연",
    description: "외주 모듈 납품이 예정보다 2주 지연될 가능성이 높다.",
    actions: [
      { label: "계약 패널티 적용 + 병행 개발", effect: { schedule: -1, cost: -2, alignment: -3 } },
      { label: "일정 재조정 및 버퍼 사용", effect: { schedule: -6, quality: 2, alignment: 2 } },
      { label: "대체 공급사 긴급 변경", effect: { cost: -7, schedule: 2, quality: -2 } }
    ]
  },
  {
    week: 5,
    title: "경영진 중간 보고",
    description: "진척률 저하에 대한 경영진 설명 요청이 들어왔다.",
    actions: [
      { label: "투명하게 리스크 공유 + 완화계획 제시", effect: { alignment: 8, quality: 2, cost: -1 } },
      { label: "긍정 지표만 강조", effect: { alignment: -8, schedule: 1 } },
      { label: "범위 축소안 제안", effect: { scope: -4, alignment: 4, schedule: 3 } }
    ]
  },
  {
    week: 6,
    title: "보안 취약점 발견",
    description: "외부 점검에서 인증 모듈 취약점이 발견되었다.",
    actions: [
      { label: "핫픽스 즉시 수행", effect: { quality: 9, schedule: -3, cost: -3 } },
      { label: "정식 릴리스 시점에 함께 처리", effect: { quality: -8, schedule: 2 } },
      { label: "보안 컨설팅 병행", effect: { quality: 7, cost: -6, alignment: 3 } }
    ]
  },
  {
    week: 7,
    title: "사용자 교육 요청",
    description: "도입 조직에서 사용자 교육 시간을 추가 요청했다.",
    actions: [
      { label: "교육 세션 추가 편성", effect: { alignment: 6, quality: 4, schedule: -2, cost: -2 } },
      { label: "매뉴얼 배포로 대체", effect: { alignment: -2, quality: -2, schedule: 1 } },
      { label: "출시 후 교육", effect: { schedule: 3, alignment: -5, quality: -1 } }
    ]
  },
  {
    week: 8,
    title: "최종 승인 게이트",
    description: "고객이 성능 기준을 재검증하겠다고 통보했다.",
    actions: [
      { label: "성능 개선 태스크 추가", effect: { quality: 7, schedule: -4, cost: -3 } },
      { label: "현재 결과로 승인 추진", effect: { schedule: 2, alignment: -4, quality: -3 } },
      { label: "단계적 오픈 제안", effect: { schedule: -1, alignment: 4, scope: -2, quality: 3 } }
    ]
  }
];

const defaultState = () => ({
  phase: "preparation",
  week: 0,
  configured: false,
  preparedStakeholders: [],
  rfp: 0,
  businessCase: 0,
  alignment: 20,
  scope: 70,
  cost: 70,
  schedule: 70,
  quality: 70,
  projectScale: null,
  log: ["시뮬레이션을 시작했습니다. 준비 단계에서 이해관계자와 소통하세요."]
});

let state = loadState();

const metricsEl = document.getElementById("metrics");
const phaseContentEl = document.getElementById("phaseContent");
const phaseTitleEl = document.getElementById("phaseTitle");
const phaseDescriptionEl = document.getElementById("phaseDescription");
const phaseProgressEl = document.getElementById("phaseProgress");
const decisionLogEl = document.getElementById("decisionLog");
const statusMessageEl = document.getElementById("statusMessage");

document.getElementById("saveBtn").addEventListener("click", () => {
  saveState();
  flash("진행 상황을 저장했습니다.");
});

document.getElementById("resetBtn").addEventListener("click", () => {
  state = defaultState();
  saveState();
  render();
  flash("시뮬레이션을 초기화했습니다.");
});

function loadState() {
  const raw = localStorage.getItem(STORAGE_KEY);
  if (!raw) return defaultState();
  try {
    return { ...defaultState(), ...JSON.parse(raw) };
  } catch {
    return defaultState();
  }
}

function saveState() {
  localStorage.setItem(STORAGE_KEY, JSON.stringify(state));
}

function clamp(value) {
  return Math.max(0, Math.min(100, value));
}

function pushLog(message) {
  state.log.unshift(`${new Date().toLocaleTimeString()} - ${message}`);
  state.log = state.log.slice(0, 30);
}

function applyEffect(effect) {
  Object.entries(effect).forEach(([key, value]) => {
    if (typeof state[key] === "number") {
      state[key] = clamp(state[key] + value);
    }
  });
}

function metric(label, value) {
  return `<div class="metric"><div class="label">${label}</div><div class="value">${value}</div></div>`;
}

function flash(message) {
  statusMessageEl.textContent = message;
}

function render() {
  metricsEl.innerHTML = [
    metric("범위", state.scope),
    metric("비용 건전성", state.cost),
    metric("일정 건전성", state.schedule),
    metric("품질", state.quality),
    metric("이해관계자 정렬", state.alignment),
    metric("문서 준비도", Math.round((state.rfp + state.businessCase) / 2))
  ].join("");

  const progress =
    state.phase === "preparation"
      ? Math.round((state.rfp + state.businessCase + state.alignment) / 3)
      : state.phase === "execution"
      ? Math.round((state.week / weeklyEvents.length) * 100)
      : 100;

  phaseProgressEl.value = progress;
  renderLog();

  if (state.phase === "preparation") {
    renderPreparation();
  } else if (state.phase === "execution") {
    renderExecution();
  } else {
    renderClosure();
  }

  saveState();
}

function renderLog() {
  decisionLogEl.innerHTML = state.log.map((item) => `<li>${item}</li>`).join("");
}

function renderPreparation() {
  phaseTitleEl.textContent = "1) 준비 단계";
  phaseDescriptionEl.textContent =
    "목표: 이해관계자와 소통하여 RFP와 사업 추진안을 완성하고 실행 준비를 끝낸다.";

  const fragment = document.getElementById("prepTemplate").content.cloneNode(true);
  const list = fragment.getElementById("stakeholderList");

  stakeholders.forEach((person, idx) => {
    const used = state.preparedStakeholders.includes(idx);
    const item = document.createElement("div");
    item.className = "option-item";
    item.innerHTML = `
      <div>
        <strong>${person.name}</strong>
        <p class="small">${person.prompt}</p>
        <span class="badge ${used ? "good" : "warn"}">${person.tag}</span>
      </div>
      <button ${used ? "disabled" : ""} data-idx="${idx}">${used ? "완료" : "대화 실행"}</button>
    `;
    list.appendChild(item);
  });

  list.querySelectorAll("button[data-idx]").forEach((button) => {
    button.addEventListener("click", () => {
      const idx = Number(button.dataset.idx);
      if (state.preparedStakeholders.includes(idx)) return;
      state.preparedStakeholders.push(idx);
      applyEffect(stakeholders[idx].impact);
      pushLog(`[준비] ${stakeholders[idx].name}과(와) 소통하여 문서 품질을 향상했습니다.`);
      render();
    });
  });

  fragment.getElementById("rfpValue").textContent = `${state.rfp}%`;
  fragment.getElementById("businessValue").textContent = `${state.businessCase}%`;
  fragment.getElementById("alignmentValue").textContent = `${state.alignment}%`;

  const toExecutionBtn = fragment.getElementById("toExecutionBtn");
  const ready = state.rfp >= 70 && state.businessCase >= 70 && state.alignment >= 60;
  toExecutionBtn.disabled = !ready;
  toExecutionBtn.addEventListener("click", () => {
    state.phase = "execution";
    pushLog("[단계 전환] 준비 단계 종료. 실행 단계로 진입했습니다.");
    render();
  });

  phaseContentEl.innerHTML = "";
  phaseContentEl.appendChild(fragment);
}

function renderExecution() {
  phaseTitleEl.textContent = "2) 실행 단계";
  phaseDescriptionEl.textContent = "목표: 프로젝트 규모를 설정하고 주차별 이벤트에 대응하여 성과를 관리한다.";

  const fragment = document.getElementById("executionTemplate").content.cloneNode(true);
  const configEl = fragment.getElementById("executionConfig");
  const weeklyEventEl = fragment.getElementById("weeklyEvent");

  if (!state.configured) {
    configEl.innerHTML = `
      <h3>프로젝트 규모 설정</h3>
      <p class="small">규모 선택에 따라 초기 체력(범위/비용/일정/품질)이 달라집니다.</p>
      <div class="toolbar">
        <button data-scale="small">Small (6주 / 5명)</button>
        <button data-scale="medium">Medium (8주 / 8명)</button>
        <button data-scale="large">Large (10주 / 12명)</button>
      </div>
    `;
    configEl.querySelectorAll("button[data-scale]").forEach((btn) => {
      btn.addEventListener("click", () => {
        const scale = btn.dataset.scale;
        state.projectScale = scale;
        state.configured = true;
        state.week = 1;

        if (scale === "small") {
          state.scope = 75; state.cost = 82; state.schedule = 78; state.quality = 74;
        }
        if (scale === "medium") {
          state.scope = 80; state.cost = 72; state.schedule = 72; state.quality = 72;
        }
        if (scale === "large") {
          state.scope = 88; state.cost = 62; state.schedule = 64; state.quality = 68;
        }

        pushLog(`[실행] 프로젝트 규모를 ${scale.toUpperCase()}로 설정했습니다.`);
        render();
      });
    });
  } else {
    configEl.innerHTML = `<p><strong>선택 규모:</strong> ${state.projectScale.toUpperCase()}</p>`;

    const event = weeklyEvents[state.week - 1];
    if (!event) {
      state.phase = "closure";
      pushLog("[단계 전환] 실행 단계 종료. 종료 단계로 이동합니다.");
      return render();
    }

    weeklyEventEl.innerHTML = `
      <div class="event-card">
        <h3>${event.week}주차 - ${event.title}</h3>
        <p>${event.description}</p>
        <div class="event-actions">
          ${event.actions.map((a, i) => `<button data-action="${i}">${a.label}</button>`).join("")}
        </div>
      </div>
    `;

    weeklyEventEl.querySelectorAll("button[data-action]").forEach((btn) => {
      btn.addEventListener("click", () => {
        const idx = Number(btn.dataset.action);
        const action = event.actions[idx];
        applyEffect(action.effect);
        state.week += 1;
        pushLog(`[${event.week}주차] ${action.label} 선택`);
        render();
      });
    });
  }

  phaseContentEl.innerHTML = "";
  phaseContentEl.appendChild(fragment);
}

function renderClosure() {
  phaseTitleEl.textContent = "3) 종료 단계";
  phaseDescriptionEl.textContent = "성과를 리뷰하고 다음 프로젝트를 위한 교훈을 남긴다.";
  const fragment = document.getElementById("closureTemplate").content.cloneNode(true);

  const health = Math.round((state.scope + state.cost + state.schedule + state.quality + state.alignment) / 5);
  const grade = health >= 85 ? "A" : health >= 75 ? "B" : health >= 65 ? "C" : "D";

  fragment.getElementById("closureSummary").innerHTML = `
    <h3>최종 성과 등급: ${grade}</h3>
    <p>종합 프로젝트 건전성: <strong>${health}</strong></p>
    <ul>
      <li>범위 ${state.scope} / 비용 ${state.cost} / 일정 ${state.schedule} / 품질 ${state.quality}</li>
      <li>이해관계자 정렬 지수 ${state.alignment}</li>
      <li>준비 단계 문서 성숙도 (RFP ${state.rfp}%, 사업 추진안 ${state.businessCase}%)</li>
    </ul>
    <p class="small">교훈: 점수가 낮은 지표를 기준으로 다음 라운드에서 대응 전략을 개선하세요.</p>
  `;

  fragment.getElementById("restartBtn").addEventListener("click", () => {
    state = defaultState();
    pushLog("새 라운드를 시작했습니다.");
    render();
  });

  phaseContentEl.innerHTML = "";
  phaseContentEl.appendChild(fragment);
}

render();
