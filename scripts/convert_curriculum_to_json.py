#!/usr/bin/env python3
"""
Unity LMS 데이터 변환 스크립트
커리큘럼 마크다운 파일을 Unity에서 사용 가능한 JSON 형식으로 변환
"""

import os
import json
import re
from pathlib import Path
from typing import Dict, List, Any

def extract_week_number(dirname: str) -> int:
    """주차 번호 추출"""
    match = re.search(r'week(\d+)', dirname)
    if match:
        # week11-12의 경우 11만 추출
        return int(match.group(1))
    return 0

def determine_phase(week_number: int) -> str:
    """주차에 따른 Phase 결정"""
    if 1 <= week_number <= 3:
        return "foundation"
    elif 4 <= week_number <= 8:
        return "core"
    elif 9 <= week_number <= 12:
        return "practical"
    elif 13 <= week_number <= 16:
        return "technical"
    return "unknown"

def extract_title_from_markdown(markdown_content: str) -> str:
    """마크다운에서 제목 추출 (첫 번째 # 헤더)"""
    match = re.search(r'^#\s+(.+)$', markdown_content, re.MULTILINE)
    if match:
        return match.group(1).strip()
    return "제목 없음"

def parse_week_directory(week_dir: Path) -> Dict[str, Any]:
    """주차 디렉토리 파싱"""
    week_number = extract_week_number(week_dir.name)
    
    week_data = {
        "weekNumber": week_number,
        "phase": determine_phase(week_number),
        "title": "",
        "description": "",
        "content": {
            "readme": "",
            "detailedLecture": "",
            "prerequisite": ""
        },
        "quiz": {
            "quizId": f"quiz_week{week_number:02d}",
            "questions": [],
            "passingScore": 70,
            "timeLimit": 0
        },
        "rubric": {
            "rubricId": f"rubric_week{week_number:02d}",
            "criteria": []
        },
        "simulationUnlocked": False,
        "learningObjectives": []
    }
    
    # README 파일 읽기
    readme_path = week_dir / f"{week_dir.name}_README.md"
    if readme_path.exists():
        readme_content = readme_path.read_text(encoding='utf-8')
        week_data["content"]["readme"] = readme_content
        week_data["title"] = extract_title_from_markdown(readme_content)
    
    # 상세 강의 자료 읽기
    lecture_path = week_dir / f"{week_dir.name}_detailed-lecture-materials.md"
    if lecture_path.exists():
        week_data["content"]["detailedLecture"] = lecture_path.read_text(encoding='utf-8')
    
    # 사전학습 자료 읽기
    prereq_path = week_dir / f"{week_dir.name}_prerequisite.md"
    if prereq_path.exists():
        week_data["content"]["prerequisite"] = prereq_path.read_text(encoding='utf-8')
    
    return week_data

def parse_case_study(case_file: Path) -> Dict[str, Any]:
    """케이스 스터디 파일 파싱"""
    content = case_file.read_text(encoding='utf-8')
    
    # 간단한 파싱 (실제로는 더 정교하게 구현 필요)
    case_data = {
        "id": case_file.stem,
        "title": extract_title_from_markdown(content),
        "content": content,
        "relatedWeeks": [],
        "difficulty": "medium"
    }
    
    return case_data

def convert_curriculum_to_json(
    curriculum_dir: str = "curriculum",
    output_file: str = "unity-data/curriculum.json"
):
    """커리큘럼 데이터를 JSON으로 변환"""
    
    curriculum_path = Path(curriculum_dir)
    if not curriculum_path.exists():
        print(f"Error: {curriculum_dir} 디렉토리를 찾을 수 없습니다.")
        return
    
    curriculum_data = {
        "version": "1.0",
        "weeks": []
    }
    
    # 주차별 디렉토리 파싱
    week_dirs = sorted([d for d in curriculum_path.iterdir() if d.is_dir()])
    
    for week_dir in week_dirs:
        print(f"Processing {week_dir.name}...")
        week_data = parse_week_directory(week_dir)
        curriculum_data["weeks"].append(week_data)
    
    # 출력 디렉토리 생성
    output_path = Path(output_file)
    output_path.parent.mkdir(parents=True, exist_ok=True)
    
    # JSON 저장
    with open(output_path, 'w', encoding='utf-8') as f:
        json.dump(curriculum_data, f, ensure_ascii=False, indent=2)
    
    print(f"\n✅ 변환 완료: {len(curriculum_data['weeks'])}개 주차")
    print(f"📄 출력 파일: {output_file}")

def convert_case_studies_to_json(
    case_studies_dir: str = "case-studies",
    output_file: str = "unity-data/case-studies.json"
):
    """케이스 스터디를 JSON으로 변환"""
    
    case_studies_path = Path(case_studies_dir)
    if not case_studies_path.exists():
        print(f"Error: {case_studies_dir} 디렉토리를 찾을 수 없습니다.")
        return
    
    case_studies_data = {
        "version": "1.0",
        "cases": []
    }
    
    # 케이스 스터디 파일 파싱
    case_files = sorted(case_studies_path.glob("*.md"))
    
    for case_file in case_files:
        print(f"Processing {case_file.name}...")
        case_data = parse_case_study(case_file)
        case_studies_data["cases"].append(case_data)
    
    # 출력 디렉토리 생성
    output_path = Path(output_file)
    output_path.parent.mkdir(parents=True, exist_ok=True)
    
    # JSON 저장
    with open(output_path, 'w', encoding='utf-8') as f:
        json.dump(case_studies_data, f, ensure_ascii=False, indent=2)
    
    print(f"\n✅ 변환 완료: {len(case_studies_data['cases'])}개 케이스")
    print(f"📄 출력 파일: {output_file}")

def create_sample_quiz_data(output_file: str = "unity-data/sample_quiz.json"):
    """샘플 퀴즈 데이터 생성"""
    
    sample_quiz = {
        "quizId": "quiz_week01",
        "questions": [
            {
                "questionId": "q01",
                "question": "프로젝트 매니저의 가장 중요한 역할은 무엇인가?",
                "type": "MultipleChoice",
                "options": [
                    "프로젝트 목표 달성을 위한 조율",
                    "기술적 문제 직접 해결",
                    "팀원 평가 및 채용",
                    "예산 집행 승인"
                ],
                "correctAnswer": "프로젝트 목표 달성을 위한 조율",
                "explanation": "PM의 핵심 역할은 프로젝트 목표를 달성하기 위해 다양한 이해관계자와 자원을 조율하는 것입니다.",
                "points": 10
            },
            {
                "questionId": "q02",
                "question": "프로젝트 생명주기는 몇 가지 단계로 구성되는가?",
                "type": "MultipleChoice",
                "options": [
                    "3단계",
                    "4단계",
                    "5단계",
                    "6단계"
                ],
                "correctAnswer": "5단계",
                "explanation": "PMBOK 기준 프로젝트 생명주기는 착수, 계획, 실행, 감시 및 통제, 종료의 5단계입니다.",
                "points": 10
            }
        ],
        "passingScore": 70,
        "timeLimit": 30
    }
    
    output_path = Path(output_file)
    output_path.parent.mkdir(parents=True, exist_ok=True)
    
    with open(output_path, 'w', encoding='utf-8') as f:
        json.dump(sample_quiz, f, ensure_ascii=False, indent=2)
    
    print(f"\n✅ 샘플 퀴즈 생성 완료")
    print(f"📄 출력 파일: {output_file}")

def main():
    """메인 실행 함수"""
    print("=" * 60)
    print("Unity LMS 데이터 변환 스크립트")
    print("=" * 60)
    print()
    
    # 1. 커리큘럼 데이터 변환
    print("1️⃣  커리큘럼 데이터 변환 중...")
    convert_curriculum_to_json()
    print()
    
    # 2. 케이스 스터디 변환
    print("2️⃣  케이스 스터디 변환 중...")
    convert_case_studies_to_json()
    print()
    
    # 3. 샘플 퀴즈 생성
    print("3️⃣  샘플 퀴즈 데이터 생성 중...")
    create_sample_quiz_data()
    print()
    
    print("=" * 60)
    print("✨ 모든 데이터 변환 완료!")
    print("=" * 60)

if __name__ == "__main__":
    main()
