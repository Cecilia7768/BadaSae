using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryUI : MonoBehaviour
{
  [SerializeField] GameObject dialoguesObj;

  Diary[] diaries;

  int lineCount = 0; // 대화 카운트
  int contextCount = 0; // 대사 카운트

  //void Awake()
  //{
  //  UIManager.Instance.startDialogue += WaitCollision;
  //}

  public void ShowDialouge(Diary[] p_diary)
  {
    UIManager.Instance.SetDiaryText("");
    diaries = p_diary;
    TypeWriter();
  }

  //public void WaitCollision()
  //{
  //  StartCoroutine(CorWaitCollision());
  //}
  public void OnClickSetDiaryText()
  {
    ShowDialouge(dialoguesObj.GetComponent<DiaryInteractionEvent>().GetDiaries());
  }
  void TypeWriter()
  {
    lineCount = Random.Range(0, diaries.Length);
    string t_ReplaceText = diaries[lineCount].contexts[contextCount]; 
    // csv일경우 쉼표를 대체하기위해
    // t_ReplaceText = t_ReplaceText.Replace("'", ","); //쉼표 치환

    UIManager.Instance.SetDiaryText(t_ReplaceText);
    UIManager.Instance.SetFeelFromDiary(diaries[lineCount].diaryfeelNum);
  }

}
