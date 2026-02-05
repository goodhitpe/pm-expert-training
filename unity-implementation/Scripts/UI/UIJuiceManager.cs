using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace PMExpert.UI
{
    /// <summary>
    /// UI Juice 시스템 - 게임 피드백과 생동감을 담당
    /// 애니메이션, 사운드, 파티클 효과로 사용자 경험을 향상시킵니다
    /// </summary>
    public class UIJuiceManager : MonoBehaviour
    {
        #region Singleton
        private static UIJuiceManager _instance;
        public static UIJuiceManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<UIJuiceManager>();
                    if (_instance == null)
                    {
                        GameObject go = new GameObject("UIJuiceManager");
                        _instance = go.AddComponent<UIJuiceManager>();
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

        #region Enums
        public enum SoundType
        {
            Click,          // 클릭
            Success,        // 성공
            Failure,        // 실패
            LevelUp,        // 레벨업
            Notification,   // 알림
            Transition      // 화면 전환
        }

        public enum ParticleType
        {
            Success,        // 성공 (별, 금색)
            LevelUp,        // 레벨업 (불꽃)
            Achievement,    // 업적 (리본)
            Sparkle         // 반짝임
        }
        #endregion

        #region Fields
        [Header("Audio")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip clickSound;
        [SerializeField] private AudioClip successSound;
        [SerializeField] private AudioClip failureSound;
        [SerializeField] private AudioClip levelUpSound;
        [SerializeField] private AudioClip notificationSound;
        [SerializeField] private AudioClip transitionSound;

        [Header("Particles")]
        [SerializeField] private GameObject successParticlePrefab;
        [SerializeField] private GameObject levelUpParticlePrefab;
        [SerializeField] private GameObject achievementParticlePrefab;
        [SerializeField] private GameObject sparkleParticlePrefab;

        [Header("Feedback UI")]
        [SerializeField] private GameObject feedbackPanel;
        [SerializeField] private TextMeshProUGUI feedbackText;
        [SerializeField] private Image feedbackIcon;
        [SerializeField] private Sprite successIcon;
        [SerializeField] private Sprite failureIcon;

        [Header("Loading UI")]
        [SerializeField] private GameObject loadingPanel;
        [SerializeField] private Image loadingSpinner;
        [SerializeField] private TextMeshProUGUI loadingText;

        [Header("Tooltip")]
        [SerializeField] private GameObject tooltipPanel;
        [SerializeField] private TextMeshProUGUI tooltipText;

        [Header("Settings")]
        [SerializeField] private float defaultAnimationDuration = 0.3f;
        [SerializeField] private float buttonScaleMultiplier = 1.2f;
        [SerializeField] private bool enableSounds = true;
        [SerializeField] private bool enableParticles = true;

        // 오브젝트 풀링
        private Dictionary<ParticleType, Queue<GameObject>> particlePool = new Dictionary<ParticleType, Queue<GameObject>>();
        private int poolSize = 5;

        // 실행 중인 애니메이션 추적
        private Dictionary<GameObject, Coroutine> runningAnimations = new Dictionary<GameObject, Coroutine>();
        #endregion

        #region Unity Lifecycle
        private void Start()
        {
            InitializeAudio();
            InitializeParticlePool();
            InitializeFeedbackUI();
        }
        #endregion

        #region Initialization
        private void InitializeAudio()
        {
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
            audioSource.playOnAwake = false;
        }

        private void InitializeParticlePool()
        {
            // 각 파티클 타입별로 풀 생성
            foreach (ParticleType type in Enum.GetValues(typeof(ParticleType)))
            {
                particlePool[type] = new Queue<GameObject>();
                
                GameObject prefab = GetParticlePrefab(type);
                if (prefab == null) continue;

                for (int i = 0; i < poolSize; i++)
                {
                    GameObject particle = Instantiate(prefab, transform);
                    particle.SetActive(false);
                    particlePool[type].Enqueue(particle);
                }
            }

            Debug.Log("[UIJuiceManager] Particle pool initialized");
        }

        private void InitializeFeedbackUI()
        {
            if (feedbackPanel != null)
            {
                feedbackPanel.SetActive(false);
            }

            if (loadingPanel != null)
            {
                loadingPanel.SetActive(false);
            }

            if (tooltipPanel != null)
            {
                tooltipPanel.SetActive(false);
            }
        }
        #endregion

        #region Button Animations
        /// <summary>
        /// 버튼 클릭 애니메이션 (Scale Bounce)
        /// </summary>
        public void AnimateButtonClick(GameObject button)
        {
            if (button == null) return;

            // 이전 애니메이션 중지
            StopAnimation(button);

            Coroutine anim = StartCoroutine(ButtonClickAnimation(button));
            runningAnimations[button] = anim;

            // 클릭 사운드
            PlaySound(SoundType.Click);
        }

        private IEnumerator ButtonClickAnimation(GameObject button)
        {
            Transform transform = button.transform;
            Vector3 originalScale = transform.localScale;
            
            // Scale up
            float elapsed = 0f;
            float duration = defaultAnimationDuration * 0.3f;
            while (elapsed < duration)
            {
                float t = elapsed / duration;
                transform.localScale = Vector3.Lerp(originalScale, originalScale * buttonScaleMultiplier, t);
                elapsed += Time.deltaTime;
                yield return null;
            }

            // Scale down (overshoot)
            elapsed = 0f;
            duration = defaultAnimationDuration * 0.4f;
            while (elapsed < duration)
            {
                float t = elapsed / duration;
                transform.localScale = Vector3.Lerp(originalScale * buttonScaleMultiplier, originalScale * 0.9f, t);
                elapsed += Time.deltaTime;
                yield return null;
            }

            // Return to original
            elapsed = 0f;
            duration = defaultAnimationDuration * 0.3f;
            while (elapsed < duration)
            {
                float t = elapsed / duration;
                transform.localScale = Vector3.Lerp(originalScale * 0.9f, originalScale, t);
                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.localScale = originalScale;
            runningAnimations.Remove(button);
        }

        private void StopAnimation(GameObject obj)
        {
            if (runningAnimations.ContainsKey(obj))
            {
                StopCoroutine(runningAnimations[obj]);
                runningAnimations.Remove(obj);
            }
        }
        #endregion

        #region Sound Effects
        /// <summary>
        /// 사운드 재생
        /// </summary>
        public void PlaySound(SoundType type)
        {
            if (!enableSounds || audioSource == null) return;

            AudioClip clip = GetAudioClip(type);
            if (clip != null)
            {
                audioSource.PlayOneShot(clip);
            }
        }

        private AudioClip GetAudioClip(SoundType type)
        {
            switch (type)
            {
                case SoundType.Click: return clickSound;
                case SoundType.Success: return successSound;
                case SoundType.Failure: return failureSound;
                case SoundType.LevelUp: return levelUpSound;
                case SoundType.Notification: return notificationSound;
                case SoundType.Transition: return transitionSound;
                default: return null;
            }
        }
        #endregion

        #region Particle Effects
        /// <summary>
        /// 파티클 효과 표시
        /// </summary>
        public void ShowParticles(ParticleType type, Vector3? position = null)
        {
            if (!enableParticles) return;

            GameObject particle = GetParticleFromPool(type);
            if (particle == null) return;

            // 위치 설정
            if (position.HasValue)
            {
                particle.transform.position = position.Value;
            }
            else
            {
                // 화면 중앙
                particle.transform.position = Camera.main != null 
                    ? Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10f))
                    : Vector3.zero;
            }

            particle.SetActive(true);
            
            // 파티클 시스템 재생
            ParticleSystem ps = particle.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
                StartCoroutine(ReturnParticleToPool(particle, type, ps.main.duration));
            }
            else
            {
                StartCoroutine(ReturnParticleToPool(particle, type, 2f));
            }
        }

        private GameObject GetParticleFromPool(ParticleType type)
        {
            if (!particlePool.ContainsKey(type) || particlePool[type].Count == 0)
            {
                // 풀이 비었으면 새로 생성
                GameObject prefab = GetParticlePrefab(type);
                if (prefab != null)
                {
                    return Instantiate(prefab, transform);
                }
                return null;
            }

            return particlePool[type].Dequeue();
        }

        private IEnumerator ReturnParticleToPool(GameObject particle, ParticleType type, float delay)
        {
            yield return new WaitForSeconds(delay);
            particle.SetActive(false);
            
            if (particlePool.ContainsKey(type))
            {
                particlePool[type].Enqueue(particle);
            }
        }

        private GameObject GetParticlePrefab(ParticleType type)
        {
            switch (type)
            {
                case ParticleType.Success: return successParticlePrefab;
                case ParticleType.LevelUp: return levelUpParticlePrefab;
                case ParticleType.Achievement: return achievementParticlePrefab;
                case ParticleType.Sparkle: return sparkleParticlePrefab;
                default: return null;
            }
        }
        #endregion

        #region Transition Effects
        /// <summary>
        /// 페이드 인
        /// </summary>
        public void FadeIn(GameObject panel, float duration = -1f)
        {
            if (panel == null) return;
            if (duration < 0) duration = defaultAnimationDuration;

            CanvasGroup group = panel.GetComponent<CanvasGroup>();
            if (group == null)
            {
                group = panel.AddComponent<CanvasGroup>();
            }

            StopAnimation(panel);
            Coroutine anim = StartCoroutine(FadeAnimation(group, 0f, 1f, duration));
            runningAnimations[panel] = anim;
        }

        /// <summary>
        /// 페이드 아웃
        /// </summary>
        public void FadeOut(GameObject panel, float duration = -1f)
        {
            if (panel == null) return;
            if (duration < 0) duration = defaultAnimationDuration;

            CanvasGroup group = panel.GetComponent<CanvasGroup>();
            if (group == null)
            {
                group = panel.AddComponent<CanvasGroup>();
            }

            StopAnimation(panel);
            Coroutine anim = StartCoroutine(FadeAnimation(group, 1f, 0f, duration));
            runningAnimations[panel] = anim;
        }

        private IEnumerator FadeAnimation(CanvasGroup group, float from, float to, float duration)
        {
            float elapsed = 0f;
            while (elapsed < duration)
            {
                float t = elapsed / duration;
                group.alpha = Mathf.Lerp(from, to, t);
                elapsed += Time.deltaTime;
                yield return null;
            }
            group.alpha = to;
        }

        /// <summary>
        /// 슬라이드 인
        /// </summary>
        public void SlideIn(GameObject panel, string direction = "up", float duration = -1f)
        {
            if (panel == null) return;
            if (duration < 0) duration = defaultAnimationDuration;

            RectTransform rect = panel.GetComponent<RectTransform>();
            if (rect == null) return;

            Vector2 startPos = GetSlideStartPosition(rect, direction);
            Vector2 endPos = rect.anchoredPosition;

            StopAnimation(panel);
            Coroutine anim = StartCoroutine(SlideAnimation(rect, startPos, endPos, duration));
            runningAnimations[panel] = anim;
        }

        private Vector2 GetSlideStartPosition(RectTransform rect, string direction)
        {
            Vector2 currentPos = rect.anchoredPosition;
            float offset = Screen.height; // 화면 밖

            switch (direction.ToLower())
            {
                case "up": return new Vector2(currentPos.x, currentPos.y - offset);
                case "down": return new Vector2(currentPos.x, currentPos.y + offset);
                case "left": return new Vector2(currentPos.x + offset, currentPos.y);
                case "right": return new Vector2(currentPos.x - offset, currentPos.y);
                default: return currentPos;
            }
        }

        private IEnumerator SlideAnimation(RectTransform rect, Vector2 from, Vector2 to, float duration)
        {
            float elapsed = 0f;
            while (elapsed < duration)
            {
                float t = elapsed / duration;
                // EaseOutCubic
                t = 1f - Mathf.Pow(1f - t, 3f);
                rect.anchoredPosition = Vector2.Lerp(from, to, t);
                elapsed += Time.deltaTime;
                yield return null;
            }
            rect.anchoredPosition = to;
        }
        #endregion

        #region Feedback Messages
        /// <summary>
        /// 성공 메시지 표시
        /// </summary>
        public void ShowSuccess(string message, float duration = 2f)
        {
            ShowFeedback(message, true, duration);
            PlaySound(SoundType.Success);
            ShowParticles(ParticleType.Success);
        }

        /// <summary>
        /// 실패 메시지 표시
        /// </summary>
        public void ShowFailure(string message, float duration = 2f)
        {
            ShowFeedback(message, false, duration);
            PlaySound(SoundType.Failure);
            // 화면 흔들기 효과 추가 가능
            StartCoroutine(ShakeScreen(0.2f, 5f));
        }

        private void ShowFeedback(string message, bool isSuccess, float duration)
        {
            if (feedbackPanel == null) return;

            // 텍스트 설정
            if (feedbackText != null)
            {
                feedbackText.text = message;
            }

            // 아이콘 설정
            if (feedbackIcon != null)
            {
                feedbackIcon.sprite = isSuccess ? successIcon : failureIcon;
            }

            // 배경색 설정
            Image bg = feedbackPanel.GetComponent<Image>();
            if (bg != null)
            {
                bg.color = isSuccess ? new Color(0.2f, 0.8f, 0.2f, 0.9f) : new Color(0.8f, 0.2f, 0.2f, 0.9f);
            }

            feedbackPanel.SetActive(true);
            FadeIn(feedbackPanel, 0.2f);

            StartCoroutine(HideFeedbackAfterDelay(duration));
        }

        private IEnumerator HideFeedbackAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            FadeOut(feedbackPanel, 0.2f);
            yield return new WaitForSeconds(0.3f);
            if (feedbackPanel != null)
            {
                feedbackPanel.SetActive(false);
            }
        }

        private IEnumerator ShakeScreen(float duration, float magnitude)
        {
            Vector3 originalPos = Camera.main != null ? Camera.main.transform.localPosition : Vector3.zero;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                float x = UnityEngine.Random.Range(-1f, 1f) * magnitude;
                float y = UnityEngine.Random.Range(-1f, 1f) * magnitude;

                if (Camera.main != null)
                {
                    Camera.main.transform.localPosition = originalPos + new Vector3(x, y, 0);
                }

                elapsed += Time.deltaTime;
                yield return null;
            }

            if (Camera.main != null)
            {
                Camera.main.transform.localPosition = originalPos;
            }
        }
        #endregion

        #region Loading
        /// <summary>
        /// 로딩 표시
        /// </summary>
        public void ShowLoading(string message = "로딩 중...")
        {
            if (loadingPanel == null) return;

            loadingPanel.SetActive(true);
            
            if (loadingText != null)
            {
                loadingText.text = message;
            }

            // 로딩 스피너 회전
            if (loadingSpinner != null)
            {
                StartCoroutine(SpinLoading());
            }
        }

        /// <summary>
        /// 로딩 숨기기
        /// </summary>
        public void HideLoading()
        {
            if (loadingPanel == null) return;

            FadeOut(loadingPanel, 0.2f);
            StartCoroutine(HideLoadingAfterFade(0.3f));
        }

        private IEnumerator HideLoadingAfterFade(float delay)
        {
            yield return new WaitForSeconds(delay);
            if (loadingPanel != null)
            {
                loadingPanel.SetActive(false);
            }
        }

        private IEnumerator SpinLoading()
        {
            while (loadingPanel != null && loadingPanel.activeSelf)
            {
                if (loadingSpinner != null)
                {
                    loadingSpinner.rectTransform.Rotate(0, 0, -360f * Time.deltaTime);
                }
                yield return null;
            }
        }
        #endregion

        #region Tooltip
        /// <summary>
        /// 툴팁 표시
        /// </summary>
        public void ShowTooltip(string text, Vector3? position = null)
        {
            if (tooltipPanel == null) return;

            if (tooltipText != null)
            {
                tooltipText.text = text;
            }

            if (position.HasValue)
            {
                tooltipPanel.transform.position = position.Value;
            }
            else
            {
                // 마우스 위치
                tooltipPanel.transform.position = Input.mousePosition;
            }

            tooltipPanel.SetActive(true);
        }

        /// <summary>
        /// 툴팁 숨기기
        /// </summary>
        public void HideTooltip()
        {
            if (tooltipPanel != null)
            {
                tooltipPanel.SetActive(false);
            }
        }
        #endregion

        #region Settings
        /// <summary>
        /// 사운드 활성화/비활성화
        /// </summary>
        public void SetSoundsEnabled(bool enabled)
        {
            enableSounds = enabled;
            PlayerPrefs.SetInt("UIJuice_SoundsEnabled", enabled ? 1 : 0);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// 파티클 활성화/비활성화
        /// </summary>
        public void SetParticlesEnabled(bool enabled)
        {
            enableParticles = enabled;
            PlayerPrefs.SetInt("UIJuice_ParticlesEnabled", enabled ? 1 : 0);
            PlayerPrefs.Save();
        }
        #endregion
    }
}
