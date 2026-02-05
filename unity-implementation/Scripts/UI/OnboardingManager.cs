using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace PMExpert.UI
{
    /// <summary>
    /// 온보딩 튜토리얼 관리 시스템
    /// LMS와 시뮬레이터의 초기 사용자 가이드를 제공합니다
    /// </summary>
    public class OnboardingManager : MonoBehaviour
    {
        #region Singleton
        private static OnboardingManager _instance;
        public static OnboardingManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<OnboardingManager>();
                    if (_instance == null)
                    {
                        GameObject go = new GameObject("OnboardingManager");
                        _instance = go.AddComponent<OnboardingManager>();
                    }
                }
                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
        #endregion

        #region Data Structures
        [Serializable]
        public class TutorialStep
        {
            public string title;
            public string description;
            public string highlightElement;  // UI 요소 이름
            public string arrowDirection;    // Up, Down, Left, Right, None
            public float duration;           // 자동 진행 시간 (0 = 수동)
        }

        public enum TutorialType
        {
            LMS,           // LMS 튜토리얼 (5분)
            Simulator      // 시뮬레이터 튜토리얼 (5-10분)
        }

        [Serializable]
        public class TutorialData
        {
            public TutorialType type;
            public List<TutorialStep> steps;
        }
        #endregion

        #region Fields
        [Header("Tutorial UI")]
        [SerializeField] private GameObject tutorialPanel;
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private Button nextButton;
        [SerializeField] private Button skipButton;
        [SerializeField] private Button previousButton;
        [SerializeField] private GameObject highlightOverlay;
        [SerializeField] private Image arrowImage;

        [Header("Tutorial Data")]
        [SerializeField] private TextAsset tutorialDataJson;  // tutorial_steps.json
        
        private List<TutorialData> allTutorials = new List<TutorialData>();
        private TutorialData currentTutorial;
        private int currentStepIndex = 0;
        private bool isTutorialActive = false;

        // 완료 상태 저장
        private Dictionary<TutorialType, bool> completedTutorials = new Dictionary<TutorialType, bool>();
        
        #endregion

        #region Unity Lifecycle
        private void Start()
        {
            LoadTutorialData();
            LoadCompletionStatus();
            SetupUI();
        }
        #endregion

        #region Initialization
        private void LoadTutorialData()
        {
            if (tutorialDataJson == null)
            {
                Debug.LogWarning("[OnboardingManager] Tutorial data JSON not assigned!");
                CreateDefaultTutorials();
                return;
            }

            try
            {
                // JSON에서 튜토리얼 데이터 로드
                string json = tutorialDataJson.text;
                TutorialDataList list = JsonUtility.FromJson<TutorialDataList>(json);
                allTutorials = list.tutorials;
                Debug.Log($"[OnboardingManager] Loaded {allTutorials.Count} tutorials");
            }
            catch (Exception e)
            {
                Debug.LogError($"[OnboardingManager] Failed to load tutorial data: {e.Message}");
                CreateDefaultTutorials();
            }
        }

        [Serializable]
        private class TutorialDataList
        {
            public List<TutorialData> tutorials;
        }

        private void CreateDefaultTutorials()
        {
            // LMS 튜토리얼 (기본)
            TutorialData lmsTutorial = new TutorialData
            {
                type = TutorialType.LMS,
                steps = new List<TutorialStep>
                {
                    new TutorialStep
                    {
                        title = "PM Expert LMS에 오신 것을 환영합니다",
                        description = "16주 프로젝트 관리 전문가 과정을 시작합니다.\n체계적인 커리큘럼과 실전 시뮬레이션으로 PM 역량을 키워보세요!",
                        highlightElement = "MainMenu",
                        arrowDirection = "None",
                        duration = 0
                    },
                    new TutorialStep
                    {
                        title = "커리큘럼 네비게이션",
                        description = "왼쪽 메뉴에서 Week 1부터 Week 16까지의 학습 내용을 확인할 수 있습니다.\n각 주차는 강의, 실습, 퀴즈로 구성되어 있습니다.",
                        highlightElement = "CurriculumMenu",
                        arrowDirection = "Left",
                        duration = 0
                    },
                    new TutorialStep
                    {
                        title = "퀴즈 시스템",
                        description = "각 주차 완료 후 퀴즈를 통해 학습 내용을 점검합니다.\n70점 이상이면 합격이며, 재시도도 가능합니다.",
                        highlightElement = "QuizButton",
                        arrowDirection = "Down",
                        duration = 0
                    },
                    new TutorialStep
                    {
                        title = "진행률 대시보드",
                        description = "상단 바에서 전체 진행률과 학습 시간을 확인할 수 있습니다.\n목표를 달성하면 배지를 획득합니다!",
                        highlightElement = "ProgressBar",
                        arrowDirection = "Up",
                        duration = 0
                    }
                }
            };

            // 시뮬레이터 튜토리얼 (기본)
            TutorialData simTutorial = new TutorialData
            {
                type = TutorialType.Simulator,
                steps = new List<TutorialStep>
                {
                    new TutorialStep
                    {
                        title = "가상 오피스 환경",
                        description = "3D 가상 오피스에서 실제 PM처럼 일해보세요.\nWASD로 이동하고, 마우스로 시점을 조정합니다.",
                        highlightElement = "Office3D",
                        arrowDirection = "None",
                        duration = 0
                    },
                    new TutorialStep
                    {
                        title = "Time Block 시스템",
                        description = "하루는 8개의 Time Block(각 1시간)으로 구성됩니다.\n모든 액션은 1-4블록을 소비하며, 효율적인 시간 관리가 핵심입니다.",
                        highlightElement = "TimeBlockUI",
                        arrowDirection = "Up",
                        duration = 0
                    },
                    new TutorialStep
                    {
                        title = "이벤트 시스템",
                        description = "프로젝트 진행 중 다양한 이벤트가 발생합니다.\n동시에 여러 이벤트가 발생하면 우선순위를 정해야 합니다.",
                        highlightElement = "EventQueue",
                        arrowDirection = "Right",
                        duration = 0
                    },
                    new TutorialStep
                    {
                        title = "의사결정 연습",
                        description = "모든 선택에는 장단점이 있습니다.\n'정답'은 없으며, 상황에 따른 최적해를 찾는 것이 중요합니다.",
                        highlightElement = "DecisionPanel",
                        arrowDirection = "Down",
                        duration = 0
                    },
                    new TutorialStep
                    {
                        title = "프로젝트 메트릭",
                        description = "일정, 예산, 품질 등 8개 메트릭을 관리합니다.\n균형을 유지하며 프로젝트를 성공으로 이끄세요!",
                        highlightElement = "MetricsPanel",
                        arrowDirection = "Left",
                        duration = 0
                    }
                }
            };

            allTutorials.Add(lmsTutorial);
            allTutorials.Add(simTutorial);
        }

        private void LoadCompletionStatus()
        {
            // PlayerPrefs에서 완료 상태 로드
            foreach (TutorialType type in Enum.GetValues(typeof(TutorialType)))
            {
                string key = $"Tutorial_{type}_Completed";
                completedTutorials[type] = PlayerPrefs.GetInt(key, 0) == 1;
            }
        }

        private void SetupUI()
        {
            if (tutorialPanel != null)
            {
                tutorialPanel.SetActive(false);
            }

            if (nextButton != null)
            {
                nextButton.onClick.AddListener(NextStep);
            }

            if (skipButton != null)
            {
                skipButton.onClick.AddListener(SkipTutorial);
            }

            if (previousButton != null)
            {
                previousButton.onClick.AddListener(PreviousStep);
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// 튜토리얼 시작
        /// </summary>
        public void StartTutorial(TutorialType type)
        {
            // 이미 완료한 튜토리얼인지 확인
            if (IsTutorialCompleted(type))
            {
                Debug.Log($"[OnboardingManager] Tutorial {type} already completed. Skipping.");
                // 재시청 옵션 제공 가능
                return;
            }

            currentTutorial = allTutorials.Find(t => t.type == type);
            if (currentTutorial == null || currentTutorial.steps.Count == 0)
            {
                Debug.LogError($"[OnboardingManager] Tutorial {type} not found or empty!");
                return;
            }

            currentStepIndex = 0;
            isTutorialActive = true;
            
            if (tutorialPanel != null)
            {
                tutorialPanel.SetActive(true);
            }

            ShowCurrentStep();
            Debug.Log($"[OnboardingManager] Started {type} tutorial with {currentTutorial.steps.Count} steps");
        }

        /// <summary>
        /// 튜토리얼 완료 여부 확인
        /// </summary>
        public bool IsTutorialCompleted(TutorialType type)
        {
            return completedTutorials.ContainsKey(type) && completedTutorials[type];
        }

        /// <summary>
        /// 튜토리얼 스킵
        /// </summary>
        public void SkipTutorial()
        {
            if (!isTutorialActive) return;

            Debug.Log($"[OnboardingManager] Skipped {currentTutorial.type} tutorial");
            EndTutorial(false);
        }

        /// <summary>
        /// 튜토리얼 재시청
        /// </summary>
        public void ReplayTutorial(TutorialType type)
        {
            // 완료 상태 초기화
            if (completedTutorials.ContainsKey(type))
            {
                completedTutorials[type] = false;
            }
            
            StartTutorial(type);
        }

        /// <summary>
        /// 다음 단계로
        /// </summary>
        public void NextStep()
        {
            if (!isTutorialActive) return;

            currentStepIndex++;
            
            if (currentStepIndex >= currentTutorial.steps.Count)
            {
                // 튜토리얼 완료
                EndTutorial(true);
            }
            else
            {
                ShowCurrentStep();
            }
        }

        /// <summary>
        /// 이전 단계로
        /// </summary>
        public void PreviousStep()
        {
            if (!isTutorialActive || currentStepIndex == 0) return;

            currentStepIndex--;
            ShowCurrentStep();
        }
        #endregion

        #region Private Methods
        private void ShowCurrentStep()
        {
            if (currentTutorial == null || currentStepIndex >= currentTutorial.steps.Count)
                return;

            TutorialStep step = currentTutorial.steps[currentStepIndex];

            // UI 업데이트
            if (titleText != null)
            {
                titleText.text = step.title;
            }

            if (descriptionText != null)
            {
                descriptionText.text = step.description;
            }

            // 하이라이트 표시
            HighlightElement(step.highlightElement);

            // 화살표 표시
            ShowArrow(step.arrowDirection);

            // 버튼 상태 업데이트
            if (previousButton != null)
            {
                previousButton.interactable = currentStepIndex > 0;
            }

            if (nextButton != null)
            {
                TextMeshProUGUI buttonText = nextButton.GetComponentInChildren<TextMeshProUGUI>();
                if (buttonText != null)
                {
                    buttonText.text = (currentStepIndex == currentTutorial.steps.Count - 1) ? "완료" : "다음";
                }
            }

            // 자동 진행
            if (step.duration > 0)
            {
                StartCoroutine(AutoAdvance(step.duration));
            }

            Debug.Log($"[OnboardingManager] Step {currentStepIndex + 1}/{currentTutorial.steps.Count}: {step.title}");
        }

        private void HighlightElement(string elementName)
        {
            if (string.IsNullOrEmpty(elementName) || highlightOverlay == null)
            {
                if (highlightOverlay != null)
                {
                    highlightOverlay.SetActive(false);
                }
                return;
            }

            // UI 요소 찾기
            GameObject element = GameObject.Find(elementName);
            if (element == null)
            {
                Debug.LogWarning($"[OnboardingManager] Element '{elementName}' not found for highlighting");
                highlightOverlay.SetActive(false);
                return;
            }

            // 하이라이트 오버레이 위치 조정
            highlightOverlay.SetActive(true);
            RectTransform highlightRect = highlightOverlay.GetComponent<RectTransform>();
            RectTransform elementRect = element.GetComponent<RectTransform>();
            
            if (highlightRect != null && elementRect != null)
            {
                highlightRect.position = elementRect.position;
                highlightRect.sizeDelta = elementRect.sizeDelta;
            }
        }

        private void ShowArrow(string direction)
        {
            if (arrowImage == null || string.IsNullOrEmpty(direction) || direction == "None")
            {
                if (arrowImage != null)
                {
                    arrowImage.gameObject.SetActive(false);
                }
                return;
            }

            arrowImage.gameObject.SetActive(true);

            // 화살표 방향 설정
            float rotation = 0f;
            switch (direction.ToLower())
            {
                case "up": rotation = 0f; break;
                case "right": rotation = 90f; break;
                case "down": rotation = 180f; break;
                case "left": rotation = 270f; break;
            }

            arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, rotation);
        }

        private IEnumerator AutoAdvance(float delay)
        {
            yield return new WaitForSeconds(delay);
            NextStep();
        }

        private void EndTutorial(bool completed)
        {
            isTutorialActive = false;

            if (tutorialPanel != null)
            {
                tutorialPanel.SetActive(false);
            }

            if (completed)
            {
                // 완료 상태 저장
                completedTutorials[currentTutorial.type] = true;
                string key = $"Tutorial_{currentTutorial.type}_Completed";
                PlayerPrefs.SetInt(key, 1);
                PlayerPrefs.Save();

                Debug.Log($"[OnboardingManager] Completed {currentTutorial.type} tutorial!");

                // 완료 보상 (배지, 파티클 등)
                if (UIJuiceManager.Instance != null)
                {
                    UIJuiceManager.Instance.ShowSuccess("튜토리얼 완료!");
                    UIJuiceManager.Instance.ShowParticles(UIJuiceManager.ParticleType.Achievement);
                    UIJuiceManager.Instance.PlaySound(UIJuiceManager.SoundType.LevelUp);
                }
            }
        }
        #endregion
    }
}
