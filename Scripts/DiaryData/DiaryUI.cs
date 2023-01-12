using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryUI : MonoBehaviour
{
  [SerializeField] GameObject dialoguesObj;

  Diary[] diaries;

  int lineCount = 0; // ��ȭ ī��Ʈ
  int contextCount = 0; // ��� ī��Ʈ

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
    // csv�ϰ�� ��ǥ�� ��ü�ϱ�����
    // t_ReplaceText = t_ReplaceText.Replace("'", ","); //��ǥ ġȯ

    UIManager.Instance.SetDiaryText(t_ReplaceText);
    UIManager.Instance.SetFeelFromDiary(diaries[lineCount].diaryfeelNum);
  }

}
