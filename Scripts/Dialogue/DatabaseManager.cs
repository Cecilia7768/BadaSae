using System.Collections;
using System.Collections.Generic;
using Unity.Rendering.HybridV2;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
   public static DatabaseManager instance;
  [SerializeField] string tsv_FileName;

  Dictionary<int, TalkingToSelf> dialogueDic = new Dictionary<int, TalkingToSelf>();

  public static bool isFinish = false; //저장완료 여부

  void Awake()
  {
    if (instance == null)
    {
      instance = this;
      TalkingToSelfParser theParser = GetComponent<TalkingToSelfParser>();
      TalkingToSelf[] dialogues = theParser.Parse(tsv_FileName);

      for(int i = 0; i< dialogues.Length; i++)
      {
        dialogueDic.Add(i + 1, dialogues[i]);
      }
      isFinish = true;
    }
  }

  public TalkingToSelf[] GetDialogue(int _startNum, int _EndNum)
  {
    List<TalkingToSelf> dialogueList = new List<TalkingToSelf>();
    for(int i=0; i<=_EndNum-_startNum;i++)
    {
      dialogueList.Add(dialogueDic[_startNum + i]);
    }
    return dialogueList.ToArray();
  }
}
