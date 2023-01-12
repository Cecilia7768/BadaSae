using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Analysis;

public class DiaryDatabaseManager : MonoBehaviour
{
  public static DiaryDatabaseManager instance;
  [SerializeField] string tsv_FileName;
  Dictionary<int, Diary> diaryDic = new Dictionary<int, Diary>();

  //저장완료 여부는 따로 확인안해도 되지않음?

  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
      DiaryParser theParser = GetComponent<DiaryParser>();
      Diary[] dialogues = theParser.Parse(tsv_FileName);

      for (int i = 0; i < dialogues.Length; i++)
      {
        diaryDic.Add(i + 1, dialogues[i]);
      }
    }
  }

  public Diary[] GetDiary(int _startNum, int _EndNum)
  {
    List<Diary> dialogueList = new List<Diary>();
    for (int i = 0; i < _EndNum - _startNum; i++)
    {
      dialogueList.Add(diaryDic[_startNum + i]);
    }
    return dialogueList.ToArray();
  }
}
