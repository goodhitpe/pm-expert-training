# 💻 Phase 1.5 샘플 코드 모음

> **목적**: Phase 1.5 구현을 위한 실제 사용 가능한 코드 스니펫  
> **언어**: C# (Unity), TypeScript (Backend), Python (Analytics)

---

## 🎮 게임 메커닉스

### 1. Time Block System

```csharp
// TimeManager.cs
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }
    
    public const int BLOCKS_PER_DAY = 8;
    public const int DAYS_PER_WEEK = 5;
    
    private int currentBlock = 0;
    private int currentDay = 1;
    private int currentWeek = 1;
    
    public event Action<int, int> OnTimeAdvanced;  // (day, block)
    public event Action<int> OnDayEnded;
    public event Action<int> OnWeekEnded;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public bool TryConsumeTimeBlocks(int blocks, string actionName)
    {
        if (currentBlock + blocks > BLOCKS_PER_DAY)
        {
            Debug.LogWarning($"Not enough time blocks. Need {blocks}, have {BLOCKS_PER_DAY - currentBlock}");
            return false;
        }
        
        currentBlock += blocks;
        Debug.Log($"[{currentDay}:{currentBlock}/{BLOCKS_PER_DAY}] {actionName} consumed {blocks} blocks");
        
        OnTimeAdvanced?.Invoke(currentDay, currentBlock);
        
        if (currentBlock >= BLOCKS_PER_DAY)
        {
            EndDay();
        }
        
        return true;
    }
    
    private void EndDay()
    {
        Debug.Log($"Day {currentDay} ended");
        OnDayEnded?.Invoke(currentDay);
        
        currentDay++;
        currentBlock = 0;
        
        if (currentDay > DAYS_PER_WEEK)
        {
            EndWeek();
        }
    }
    
    private void EndWeek()
    {
        Debug.Log($"Week {currentWeek} ended");
        OnWeekEnded?.Invoke(currentWeek);
        
        currentWeek++;
        currentDay = 1;
        
        // Trigger weekly review
        UIManager.Instance.ShowWeeklyReview(currentWeek - 1);
    }
    
    public int GetCurrentDay() => currentDay;
    public int GetCurrentWeek() => currentWeek;
    public int GetRemainingBlocks() => BLOCKS_PER_DAY - currentBlock;
}
```

### 2. Trade-off Decision System

```csharp
// DecisionSystem.cs
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DecisionChoice
{
    public string id;
    public string choiceText;
    public string prosText;  // "일정 단축, 팀 효율 증가"
    public string consText;  // "품질 하락, 기술 부채"
    
    public MetricImpact[] impacts;
}

[System.Serializable]
public class MetricImpact
{
    public MetricType type;
    public int value;  // -10 to +10
}

public enum MetricType
{
    Schedule,
    Budget,
    Quality,
    TeamMorale,
    ClientSatisfaction,
    TechnicalDebt
}

[CreateAssetMenu(fileName = "Decision", menuName = "Game/Decision")]
public class DecisionData : ScriptableObject
{
    public string decisionId;
    public string scenarioText;
    public string contextInfo;  // 추가 배경 정보
    
    public DecisionChoice[] choices;
    
    public int timeBlocksRequired = 0;  // 이 의사결정에 소요되는 시간
}

public class DecisionManager : MonoBehaviour
{
    public static DecisionManager Instance { get; private set; }
    
    private Queue<DecisionData> pendingDecisions = new Queue<DecisionData>();
    private DecisionData currentDecision;
    
    void Awake()
    {
        Instance = this;
    }
    
    public void PresentDecision(DecisionData decision)
    {
        currentDecision = decision;
        
        // UI에 표시
        DecisionUI.Instance.ShowDecision(decision);
        
        // 게임 일시정지 (선택할 때까지)
        Time.timeScale = 0;
    }
    
    public void MakeChoice(int choiceIndex)
    {
        if (currentDecision == null || choiceIndex >= currentDecision.choices.Length)
        {
            Debug.LogError("Invalid choice");
            return;
        }
        
        var choice = currentDecision.choices[choiceIndex];
        
        // 메트릭 적용
        foreach (var impact in choice.impacts)
        {
            MetricManager.Instance.ModifyMetric(impact.type, impact.value);
        }
        
        // 시간 소비
        if (currentDecision.timeBlocksRequired > 0)
        {
            TimeManager.Instance.TryConsumeTimeBlocks(
                currentDecision.timeBlocksRequired,
                "Decision: " + currentDecision.decisionId
            );
        }
        
        // 결과 표시
        ShowDecisionResult(choice);
        
        // 게임 재개
        Time.timeScale = 1;
        
        currentDecision = null;
    }
    
    private void ShowDecisionResult(DecisionChoice choice)
    {
        string result = $"선택: {choice.choiceText}\n\n";
        result += $"효과:\n";
        
        foreach (var impact in choice.impacts)
        {
            string sign = impact.value > 0 ? "+" : "";
            result += $"- {impact.type}: {sign}{impact.value}\n";
        }
        
        ResultUI.Instance.ShowResult(result);
    }
}
```

### 3. Metric Management

```csharp
// MetricManager.cs
using System;
using System.Collections.Generic;
using UnityEngine;

public class MetricManager : MonoBehaviour
{
    public static MetricManager Instance { get; private set; }
    
    private Dictionary<MetricType, int> metrics = new Dictionary<MetricType, int>();
    
    public event Action<MetricType, int, int> OnMetricChanged;  // (type, oldValue, newValue)
    
    void Awake()
    {
        Instance = this;
        InitializeMetrics();
    }
    
    private void InitializeMetrics()
    {
        // 초기값 설정 (0-100 범위)
        metrics[MetricType.Schedule] = 100;
        metrics[MetricType.Budget] = 100;
        metrics[MetricType.Quality] = 75;
        metrics[MetricType.TeamMorale] = 80;
        metrics[MetricType.ClientSatisfaction] = 70;
        metrics[MetricType.TechnicalDebt] = 20;
    }
    
    public void ModifyMetric(MetricType type, int change)
    {
        if (!metrics.ContainsKey(type))
        {
            Debug.LogError($"Metric {type} not found");
            return;
        }
        
        int oldValue = metrics[type];
        int newValue = Mathf.Clamp(oldValue + change, 0, 100);
        
        metrics[type] = newValue;
        
        Debug.Log($"Metric {type}: {oldValue} → {newValue} ({change:+0;-0})");
        
        OnMetricChanged?.Invoke(type, oldValue, newValue);
        
        // 임계값 체크
        CheckCriticalThresholds(type, newValue);
    }
    
    private void CheckCriticalThresholds(MetricType type, int value)
    {
        if (value <= 20)
        {
            // 위험 수준
            EventManager.Instance.TriggerCrisisEvent(type);
        }
        else if (value <= 40)
        {
            // 경고
            NotificationManager.Instance.ShowWarning($"{type}이(가) 낮습니다!");
        }
    }
    
    public int GetMetric(MetricType type)
    {
        return metrics.ContainsKey(type) ? metrics[type] : 0;
    }
    
    public Dictionary<MetricType, int> GetAllMetrics()
    {
        return new Dictionary<MetricType, int>(metrics);
    }
}
```

---

## 🎓 교육 기능

### 4. Instructor Dashboard API (Node.js + Express)

```typescript
// api/instructor.ts
import express from 'express';
import { firestore } from 'firebase-admin';

const router = express.Router();
const db = firestore();

interface StudentSummary {
  id: string;
  name: string;
  progress: number;
  currentWeek: number;
  avgQuizScore: number;
  lastActive: Date;
  status: 'on-track' | 'at-risk' | 'inactive';
}

// GET /api/instructor/dashboard
router.get('/dashboard', async (req, res) => {
  try {
    const studentsSnapshot = await db.collection('students').get();
    const students: StudentSummary[] = [];
    
    studentsSnapshot.forEach(doc => {
      const data = doc.data();
      students.push({
        id: doc.id,
        name: data.name,
        progress: data.progress || 0,
        currentWeek: data.currentWeek || 1,
        avgQuizScore: data.avgQuizScore || 0,
        lastActive: data.lastActive.toDate(),
        status: determineStatus(data)
      });
    });
    
    const atRisk = students.filter(s => s.status === 'at-risk');
    const inactive = students.filter(s => s.status === 'inactive');
    
    const dashboard = {
      totalStudents: students.length,
      activeToday: students.filter(s => isActiveToday(s.lastActive)).length,
      atRisk: atRisk.length,
      avgProgress: students.reduce((sum, s) => sum + s.progress, 0) / students.length,
      students: students,
      alerts: [
        ...atRisk.map(s => ({
          type: 'at-risk',
          studentId: s.id,
          message: `${s.name}이(가) 위험군입니다`
        })),
        ...inactive.map(s => ({
          type: 'inactive',
          studentId: s.id,
          message: `${s.name}이(가) 7일 이상 미접속`
        }))
      ]
    };
    
    res.json(dashboard);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

function determineStatus(data: any): 'on-track' | 'at-risk' | 'inactive' {
  const daysSinceActive = (Date.now() - data.lastActive.toMillis()) / (1000 * 60 * 60 * 24);
  
  if (daysSinceActive > 7) {
    return 'inactive';
  }
  
  if (data.progress < 30 || data.avgQuizScore < 60) {
    return 'at-risk';
  }
  
  return 'on-track';
}

function isActiveToday(lastActive: Date): boolean {
  const today = new Date();
  return lastActive.toDateString() === today.toDateString();
}

// GET /api/instructor/weekly-stats
router.get('/weekly-stats', async (req, res) => {
  try {
    const stats = [];
    
    for (let week = 1; week <= 16; week++) {
      const studentsSnapshot = await db.collection('students')
        .where('currentWeek', '>=', week)
        .get();
      
      const quizSnapshot = await db.collection('quizResults')
        .where('weekNumber', '==', week)
        .get();
      
      const quizScores = quizSnapshot.docs.map(doc => doc.data().score);
      const avgScore = quizScores.length > 0
        ? quizScores.reduce((a, b) => a + b, 0) / quizScores.length
        : 0;
      
      stats.push({
        weekNumber: week,
        completionRate: calculateCompletionRate(week),
        avgQuizScore: avgScore,
        studentCount: studentsSnapshot.size
      });
    }
    
    res.json(stats);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

export default router;
```

### 5. Learning Analytics (Python)

```python
# analytics/learning_analytics.py
import pandas as pd
import matplotlib.pyplot as plt
from datetime import datetime, timedelta
import json

class LearningAnalytics:
    def __init__(self, data_path):
        self.students_df = pd.read_json(f'{data_path}/students.json')
        self.progress_df = pd.read_json(f'{data_path}/progress.json')
        self.quiz_df = pd.read_json(f'{data_path}/quiz_results.json')
    
    def find_drop_off_points(self):
        """주차별 이탈률 분석"""
        week_stats = {}
        
        for week in range(1, 17):
            # 해당 주차 시작한 학생
            started = len(self.progress_df[
                self.progress_df['currentWeek'] >= week
            ])
            
            # 해당 주차 완료한 학생
            completed = len(self.progress_df[
                self.progress_df['completedWeeks'].apply(lambda x: week in x)
            ])
            
            drop_rate = ((started - completed) / started * 100) if started > 0 else 0
            
            week_stats[week] = {
                'started': started,
                'completed': completed,
                'drop_rate': round(drop_rate, 2)
            }
        
        # 이탈률 30% 이상인 주차
        high_drop = {
            week: stats for week, stats in week_stats.items()
            if stats['drop_rate'] > 30
        }
        
        return week_stats, high_drop
    
    def find_difficult_weeks(self):
        """어려운 주차 찾기 (낮은 퀴즈 점수)"""
        quiz_by_week = self.quiz_df.groupby('weekNumber').agg({
            'score': ['mean', 'std', 'count']
        }).round(2)
        
        # 평균 70점 미만
        difficult = quiz_by_week[
            quiz_by_week[('score', 'mean')] < 70
        ]
        
        return quiz_by_week, difficult
    
    def analyze_study_patterns(self):
        """학습 패턴 분석"""
        self.progress_df['lastActive'] = pd.to_datetime(
            self.progress_df['lastActive']
        )
        
        # 시간대별
        hourly = self.progress_df.groupby(
            self.progress_df['lastActive'].dt.hour
        )['studyTime'].sum()
        
        # 요일별
        daily = self.progress_df.groupby(
            self.progress_df['lastActive'].dt.dayofweek
        )['studyTime'].sum()
        
        return {
            'peak_hour': int(hourly.idxmax()),
            'peak_day': ['월', '화', '수', '목', '금', '토', '일'][int(daily.idxmax())],
            'hourly_pattern': hourly.to_dict(),
            'daily_pattern': daily.to_dict()
        }
    
    def generate_weekly_report(self):
        """주간 리포트 생성"""
        drop_off, high_drop = self.find_drop_off_points()
        quiz_stats, difficult = self.find_difficult_weeks()
        patterns = self.analyze_study_patterns()
        
        report = {
            'generated_at': datetime.now().isoformat(),
            'drop_off_analysis': {
                'high_drop_weeks': high_drop,
                'summary': f"{len(high_drop)}개 주차에서 30% 이상 이탈"
            },
            'difficulty_analysis': {
                'difficult_weeks': difficult.to_dict(),
                'summary': f"{len(difficult)}개 주차가 평균 70점 미만"
            },
            'study_patterns': patterns,
            'recommendations': self._generate_recommendations(high_drop, difficult)
        }
        
        return report
    
    def _generate_recommendations(self, high_drop, difficult):
        """자동 권장사항 생성"""
        recommendations = []
        
        for week in high_drop.keys():
            recommendations.append({
                'week': week,
                'issue': '높은 이탈률',
                'action': '사전학습 자료 보강, 추가 Q&A 세션 개최'
            })
        
        for week in difficult.index:
            recommendations.append({
                'week': int(week),
                'issue': '낮은 퀴즈 점수',
                'action': '퀴즈 난이도 조정, 보충 자료 제공'
            })
        
        return recommendations
    
    def export_csv(self, output_path):
        """CSV 내보내기"""
        report = self.generate_weekly_report()
        
        # DataFrame 생성
        df = pd.DataFrame(report['recommendations'])
        df.to_csv(f'{output_path}/recommendations.csv', index=False)
        
        print(f"Report exported to {output_path}")

# 사용 예시
if __name__ == "__main__":
    analytics = LearningAnalytics('./data')
    report = analytics.generate_weekly_report()
    
    print(json.dumps(report, indent=2, ensure_ascii=False))
    
    analytics.export_csv('./output')
```

---

## 🎨 UI/UX

### 6. Juice System

```csharp
// UIJuice.cs
using UnityEngine;
using DG.Tweening;
using TMPro;

public class UIJuice : MonoBehaviour
{
    public static UIJuice Instance { get; private set; }
    
    [Header("Prefabs")]
    public GameObject successParticlePrefab;
    public GameObject failureParticlePrefab;
    public GameObject clickSparkPrefab;
    
    void Awake()
    {
        Instance = this;
    }
    
    // 버튼 클릭 애니메이션
    public void AnimateButtonClick(GameObject button)
    {
        button.transform.DOKill();
        
        // Scale bounce
        button.transform.DOScale(0.9f, 0.1f)
            .SetEase(Ease.OutQuad)
            .SetUpdate(true)  // TimeScale 영향 안 받음
            .OnComplete(() =>
            {
                button.transform.DOScale(1f, 0.15f)
                    .SetEase(Ease.OutBounce)
                    .SetUpdate(true);
            });
        
        // Sound
        AudioManager.Instance?.PlaySFX("button_click");
        
        // Particle
        if (clickSparkPrefab != null)
        {
            Instantiate(clickSparkPrefab, button.transform.position, Quaternion.identity);
        }
    }
    
    // 성공 피드백
    public void ShowSuccess(string message, Vector3 position)
    {
        // Screen flash
        FlashScreen(new Color(0, 1, 0, 0.1f), 0.2f);
        
        // Particle confetti
        if (successParticlePrefab != null)
        {
            Instantiate(successParticlePrefab, position, Quaternion.identity);
        }
        
        // Sound
        AudioManager.Instance?.PlaySFX("success_chime");
        
        // Message
        ShowFloatingMessage(message, position, Color.green);
    }
    
    // 실패 피드백
    public void ShowFailure(string message, Vector3 position)
    {
        // Screen shake
        Camera.main.DOShakePosition(0.3f, 0.1f, 10, 90);
        
        // Red flash
        FlashScreen(new Color(1, 0, 0, 0.15f), 0.2f);
        
        // Particle
        if (failureParticlePrefab != null)
        {
            Instantiate(failureParticlePrefab, position, Quaternion.identity);
        }
        
        // Sound
        AudioManager.Instance?.PlaySFX("failure_buzz");
        
        // Message
        ShowFloatingMessage(message, position, Color.red);
    }
    
    // 메트릭 변화 애니메이션
    public void AnimateMetricChange(TMP_Text text, int from, int to, float duration = 0.5f)
    {
        DOTween.To(
            () => from,
            x => text.text = x.ToString(),
            to,
            duration
        ).SetEase(Ease.OutQuad);
        
        // 색상 변화
        Color targetColor = to > from ? Color.green : (to < from ? Color.red : Color.white);
        
        text.DOColor(targetColor, 0.2f)
            .OnComplete(() =>
            {
                text.DOColor(Color.white, 0.3f).SetDelay(0.3f);
            });
    }
    
    private void FlashScreen(Color color, float duration)
    {
        // 전체 화면 플래시 (Canvas Overlay)
        var flash = new GameObject("ScreenFlash");
        var canvas = flash.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 9999;
        
        var img = flash.AddComponent<UnityEngine.UI.Image>();
        img.color = color;
        
        img.DOFade(0, duration).OnComplete(() => Destroy(flash));
    }
    
    private void ShowFloatingMessage(string message, Vector3 worldPos, Color color)
    {
        // 간단한 floating text 구현
        var textObj = new GameObject("FloatingMessage");
        var text = textObj.AddComponent<TMP_Text>();
        text.text = message;
        text.color = color;
        text.fontSize = 24;
        text.alignment = TextAlignmentOptions.Center;
        
        textObj.transform.position = worldPos;
        
        // Float up and fade
        textObj.transform.DOMoveY(worldPos.y + 1f, 1f);
        text.DOFade(0, 1f).OnComplete(() => Destroy(textObj));
    }
}
```

---

## 📦 더 많은 샘플 코드

추가 코드 샘플은 다음 위치에서 확인:
- [UNITY_PROJECT_STRUCTURE.md](./UNITY_PROJECT_STRUCTURE.md) - 프로젝트 구조 및 기본 코드
- [UNITY_PROJECT_TECHNICAL_SPEC.md](./UNITY_PROJECT_TECHNICAL_SPEC.md) - 기술 사양 및 예제

---

**작성일**: 2025-02-04  
**버전**: 1.0  
**업데이트**: 구현하면서 실제 코드로 개선
