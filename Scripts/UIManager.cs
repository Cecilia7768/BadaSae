using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Yarn.Unity;
using static Manager;
using UniRx;
using UniRx.Triggers;

public class UIManager : MonoSingleton<UIManager>
{
  private float currFeel;
  public float CurrFeel
  {
    set
    {
      if (currFeel == value) return;
      currFeel = value;
    }
    get { return currFeel; }
  }

  private int currDDazo;
  public int CurrDDazo
  {
    set
    {
      if (currDDazo == value) return;
      currDDazo = value;
    }
    get { return currDDazo; }
  }

  [Header("��� ��")]
  public Slider feelSlider;
  [Header("���� ���� �ؽ�Ʈ")]
  public TMP_Text ddazoText;
  [Header("ȥ�㸻")]
  public GameObject talkAlonObj;
  public TMP_Text talkAlone;



  void Start()
  {

    ////Rx
    //var mouseDownStream = this.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(0));
    //mouseDownStream.Subscribe(_ => Debug.Log("Ŭ��"));
  }
  public void Init()
  {
    feelSlider.value = CurrFeel;
    ddazoText.text = currDDazo.ToString();

  }
  /// <summary>
  /// �����κ��� ���� ��� �����͸� �޾Ƽ� ���� ����
  /// </summary>
  /// <returns></returns>
  public void SetFeelFromYarn() 
  {
    Debug.Log("Ŭ��");
    var yarnMemory = GameObject.FindObjectOfType<InMemoryVariableStorage>();
    float testVariable;

      yarnMemory.TryGetValue("$shapes_like_you", out testVariable);
      CurrFeel = testVariable;

    feelSlider.value = CurrFeel; 
  }

  /// <summary>
  /// ��ȭ ������ ���� ��������(�Ҹ� �Ǵ� ����) ����
  /// </summary>
  public void ResetDDazo(int changeNum)
  {
    currDDazo += changeNum;
    ddazoText.text = currDDazo.ToString();
  }



}
