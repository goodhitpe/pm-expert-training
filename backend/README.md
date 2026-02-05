# PM Expert LMS - Backend Server

> **목적**: 강사 대시보드 및 학습 분석을 위한 REST API 서버  
> **기술 스택**: Node.js + Express + Firebase + Python  
> **Phase**: 1.5 Week 2

---

## 🚀 빠른 시작

### 1. 설치

```bash
cd backend
npm install
```

### 2. 환경 변수 설정

`.env` 파일 생성:
```env
PORT=3000
NODE_ENV=development
FIREBASE_PROJECT_ID=pm-expert-lms
```

### 3. 서버 시작

```bash
# 개발 모드
npm run dev

# 프로덕션 모드
npm start
```

서버가 `http://localhost:3000`에서 실행됩니다.

---

## 📡 API 엔드포인트

### 1. 강사 대시보드
```
GET /api/instructor/dashboard
```

**응답 예시**:
```json
{
  "success": true,
  "data": {
    "totalStudents": 5,
    "atRisk": 2,
    "avgProgress": 52,
    "activeToday": 2,
    "weeklyStats": [ ... ],
    "recentActivity": [ ... ]
  }
}
```

### 2. 개별 학습자 정보
```
GET /api/instructor/students/:id
```

**응답 예시**:
```json
{
  "success": true,
  "data": {
    "student": { ... },
    "progress": { ... },
    "metrics": [ ... ],
    "alerts": [ ... ],
    "recommendations": [ ... ]
  }
}
```

### 3. 위험군 학습자 목록
```
GET /api/instructor/at-risk
```

**응답 예시**:
```json
{
  "success": true,
  "data": [
    {
      "id": "STU005",
      "name": "정태양",
      "riskScore": 100,
      "riskFactors": [ ... ]
    }
  ]
}
```

### 4. 주차별 통계
```
GET /api/instructor/weeks/:weekNumber
```

**응답 예시**:
```json
{
  "success": true,
  "data": {
    "summary": {
      "weekNumber": 5,
      "totalStudents": 5,
      "completed": 4,
      "avgQuizScore": 75,
      "dropOffRate": 20
    },
    "students": [ ... ]
  }
}
```

### 5. 메시지 전송
```
POST /api/instructor/send-message
Body: {
  "studentIds": ["STU001", "STU002"],
  "message": "추가 학습 자료...",
  "type": "encouragement"
}
```

---

## 📊 Learning Analytics (Python)

### 실행

```bash
cd backend
python analytics.py
```

### 주요 기능

1. **Drop-off 포인트 분석**
   - 이탈률이 30% 이상인 주차 식별

2. **어려운 주차 식별**
   - 평균 퀴즈 점수가 70점 미만인 주차

3. **위험군 학습자 식별**
   - 위험도 점수 50점 이상 학습자

4. **주간 리포트 자동 생성**
   - 전체 통계 및 인사이트

5. **CSV 내보내기**
   - `analytics_report.csv` 파일 생성

### 출력 예시

```
📊 PM Expert LMS - Learning Analytics
============================================================

🔍 1. Drop-off 포인트 (이탈률 ≥ 30%)
   Week 7: 40.0% 이탈
   Week 10: 33.3% 이탈

📉 2. 어려운 주차 (평균 점수 < 70점)
   Week 3: 평균 64.2점 (5명)
   Week 6: 평균 66.6점 (4명)

⚠️  4. 위험군 학습자
   STU005: 위험도 100점
      - 매우 낮은 진행률, 10일 미접속, ...
   STU003: 위험도 80점
      - 낮은 진행률, 7일 미접속, ...

✅ 분석 완료!
```

---

## 🧪 테스트

### API 테스트 (cURL)

```bash
# 대시보드
curl http://localhost:3000/api/instructor/dashboard

# 학습자 정보
curl http://localhost:3000/api/instructor/students/STU001

# 위험군 목록
curl http://localhost:3000/api/instructor/at-risk

# 주차 통계
curl http://localhost:3000/api/instructor/weeks/5
```

### API 테스트 (Postman)

1. Postman 실행
2. 새 요청 생성
3. URL 입력: `http://localhost:3000/api/instructor/dashboard`
4. Send 클릭

---

## 📁 프로젝트 구조

```
backend/
├── server.js              # Express 서버
├── analytics.py           # Python 분석 스크립트
├── package.json           # npm 의존성
├── .env                   # 환경 변수 (생성 필요)
├── mock-data/            
│   ├── students.json      # 학습자 데이터
│   ├── progress.json      # 진행 데이터
│   └── metrics.json       # 메트릭 데이터
└── README.md             # 이 파일
```

---

## 🔒 Firebase 연동 (프로덕션)

### 1. Firebase 프로젝트 생성

1. [Firebase Console](https://console.firebase.google.com/) 접속
2. 새 프로젝트 생성: `pm-expert-lms`
3. Firestore 데이터베이스 생성

### 2. 서비스 계정 키 다운로드

1. 프로젝트 설정 → 서비스 계정
2. "새 비공개 키 생성" 클릭
3. JSON 파일 다운로드 → `firebase-service-account.json` 저장

### 3. 서버 코드 업데이트

`server.js`에서 주석 해제:

```javascript
const serviceAccount = require('./firebase-service-account.json');
admin.initializeApp({
  credential: admin.credential.cert(serviceAccount)
});

const db = admin.firestore();
```

---

## 🌐 Unity 연동

### Unity에서 WebView로 대시보드 열기

```csharp
using PMExpert.Integration;

// 강사 대시보드 열기
WebViewManager.Instance.ShowInstructorDashboard();

// Q&A 게시판 열기
WebViewManager.Instance.ShowQABoard();

// 특정 주차 Q&A
WebViewManager.Instance.ShowQABoard(5);
```

### WebView 설정

1. **PC/Mac**: 기본 브라우저로 자동 열림
2. **모바일**: UniWebView (유료) 또는 gree-unity-webview (무료) 필요
3. **WebGL**: 새 탭으로 열림

---

## 📦 의존성

### Node.js
- `express`: Web 서버
- `firebase-admin`: Firebase 연동
- `cors`: CORS 처리
- `dotenv`: 환경 변수
- `morgan`: HTTP 로깅

### Python
- 표준 라이브러리만 사용 (추가 설치 불필요)

---

## 🚀 배포

### Heroku 배포

```bash
# Heroku CLI 설치 후
heroku create pm-expert-lms-backend
heroku config:set NODE_ENV=production
git push heroku main
```

### Vercel 배포

```bash
# Vercel CLI 설치 후
vercel
```

---

## 📊 성능 목표

| 지표 | 목표 |
|------|------|
| API 응답 시간 | < 200ms |
| 동시 접속 | 100명 |
| 가용성 | 99.9% |

---

## 🔧 개발 팁

### Mock 데이터 수정

`mock-data/*.json` 파일을 수정하여 테스트 데이터 변경 가능

### 새 API 엔드포인트 추가

`server.js`에서 라우트 추가:

```javascript
app.get('/api/instructor/custom', (req, res) => {
  // 로직
  res.json({ success: true, data: { ... } });
});
```

### 분석 함수 추가

`analytics.py`의 `LearningAnalytics` 클래스에 메서드 추가

---

## 📞 지원

**문제 발생 시**:
1. `npm install` 재실행
2. `.env` 파일 확인
3. 포트 3000 사용 중인지 확인
4. Node.js 버전 확인 (>= 18.0.0)

---

**작성일**: 2025-02-05  
**버전**: 1.0  
**Phase**: 1.5 Week 2
