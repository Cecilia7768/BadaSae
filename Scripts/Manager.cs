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
  [Header("UI��")]
  public TMP_Text heartTxt;
  //���߿� ��Ʈ ���濩�ο����� �̺�Ʈ �߻��� set ���� �ʿ�
  //Heart UI Text�� UI �Ŵ����� �ű��
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

  [Header("�ὺũ��Ʈ")]
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
  /// ĳ���� Ŭ���� ��ȭ����, �ῡ ���� ĳ���� ���� ����
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
