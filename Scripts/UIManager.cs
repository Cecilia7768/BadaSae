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

  [Header("기분 바")]
  public Slider feelSlider;
  [Header("따조 갯수 텍스트")]
  public TMP_Text ddazoText;
  [Header("혼잣말")]
  public GameObject talkAlonObj;
  public TMP_Text talkAlone;



  void Start()
  {

    ////Rx
    //var mouseDownStream = this.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(0));
    //mouseDownStream.Subscribe(_ => Debug.Log("클릭"));
  }
  public void Init()
  {
    feelSlider.value = CurrFeel;
    ddazoText.text = currDDazo.ToString();

  }
  /// <summary>
  /// 얀으로부터 현재 기분 데이터를 받아서 따로 저장
  /// </summary>
  /// <returns></returns>
  public void SetFeelFromYarn() 
  {
    Debug.Log("클릭");
    var yarnMemory = GameObject.FindObjectOfType<InMemoryVariableStorage>();
    float testVariable;

      yarnMemory.TryGetValue("$shapes_like_you", out testVariable);
      CurrFeel = testVariable;

    feelSlider.value = CurrFeel; 
  }

  /// <summary>
  /// 대화 등으로 보유 따조갯수(소모 또는 증가) 수정
  /// </summary>
  public void ResetDDazo(int changeNum)
  {
    currDDazo += changeNum;
    ddazoText.text = currDDazo.ToString();
  }



}
