using System;
using UnityEngine;

public class Diary
{
  public int diaryNum; //몇번째라인 읽기인지.. 필요없을지도?
  public string diaryfeelNum; //일기내용에 따른 기분변화 수치
  [Tooltip("대화 내용")]
  public string[] contexts;
}

[Serializable]
public class DiaryEvent
{
  public Vector2 line; //추출할 라인
  public Diary[] diaries;
}
