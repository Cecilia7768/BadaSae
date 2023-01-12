using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryInteractionEvent : MonoBehaviour
{
  [SerializeField] DiaryEvent diary;

  public Diary[] GetDiaries()
  {
    diary.diaries = DiaryDatabaseManager.instance.GetDiary((int)diary.line.x, (int)diary.line.y);
    return diary.diaries;
  }
}
