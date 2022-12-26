using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.PlayerLoop;
using Yarn;
using TMPro;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
  private static T instance = null;
  public static T Instance
  {
    get
    {
      if (instance == null)
      {
        instance = FindObjectOfType(typeof(T)) as T;

        if (instance == null)
        {
          instance = new GameObject(typeof(T).ToString(), typeof(T)).AddComponent<T>();
        }
      }

      return instance;
    }
  }
}

public class Manager : MonoSingleton<Manager>
{
  [Header("UI들")]
  public TMP_Text heartTxt;
  //나중에 하트 변경여부에따른 이벤트 발생시 set 수정 필요
  //Heart UI Text는 UI 매니저로 옮길것
  private int heartNum;
  public int HeartNum 
  {
    get { return heartNum; }
    set { heartNum += value; }
  }
  public enum AdmobCase
  {
    None = -1,
    Banner,
    Reward,
  }

  [Header("얀스크립트")]
  public GameObject yarnObj;
  Yarn.Unity.DialogueRunner dialogueRunner;


  private void Start()
  {
    SetHeartNumText(AdmobCase.None);
    dialogueRunner = yarnObj.GetComponent<DialogueRunner>();
  }

  public void Init()
  {
    heartTxt.text = HeartNum.ToString();
  }
  public void SetHeartNumText(AdmobCase admobCase)
  {
    switch (admobCase)
    {
      case AdmobCase.Reward:
        heartNum += 1;
        break;
    }
    heartTxt.text = HeartNum.ToString();
  }

  /// <summary>
  /// 캐릭터 클릭시 대화시작, 얀에 기존 캐릭터 상태 전달
  /// </summary>
  public void OnClickDialog()
  {
    var yarnMemory = GameObject.FindObjectOfType<InMemoryVariableStorage>();
    yarnMemory.SetValue("$shapes_like_you", UIManager.Instance.CurrFeel);
    var currNodeName = dialogueRunner.CurrentNodeName;
    if (currNodeName == null)
    {
      string startName = Yarn.Dialogue.DefaultStartNodeName;
      dialogueRunner.StartDialogue(startName);
    }
    else
      dialogueRunner.StartDialogue(currNodeName);
  }



}
