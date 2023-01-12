using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Yarn.Unity;

public class Talk : MonoBehaviour
{
  [Header("얀스크립트")]
  [SerializeField] GameObject yarnObj;
  Yarn.Unity.DialogueRunner dialogueRunner;
  [Header("얀스크립트 노드 이름")]
  [SerializeField] List<string> yarnNodeName = new List<string>();


  void Start()
  {
    dialogueRunner = yarnObj.GetComponent<DialogueRunner>();
    var mouseDownStream = this.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(0));

    //보유한 재화에 따라 대화 시작
    mouseDownStream
      .Subscribe(_ =>
      {
        if (IsClickGGom())
        {         
          if (DDazoManager.Instance.CurrDDazo > 0)
            StartDialouge();
          else
            StartTalkingToSelf();
        }
      });
  }


  /// <summary>
  /// 따조가 없을 때 나오는 혼잣말
  /// </summary>
  void StartTalkingToSelf()
  {
    UIManager.Instance.OnOFTalkingToSelfUI(true);
    UIManager.Instance.startDialogue();
  }

  /// <summary>
  /// 이벤트 대화 시작
  /// </summary>
  public void StartDialouge()
  {
    //얀 스크립트 중 랜덤 노드의 대화내용을 불러온다.
    int ranNode = Random.Range(0, yarnNodeName.Count);

    var yarnMemory = GameObject.FindObjectOfType<InMemoryVariableStorage>();
    yarnMemory.SetValue("$Feel", UIManager.Instance.CurrFeel);
    //var currNodeName = dialogueRunner.CurrentNodeName;
    //if (currNodeName == null)
    //{
    //  string startName = Yarn.Dialogue.DefaultStartNodeName;
    //  dialogueRunner.StartDialogue(startName);
    //}
    //else
    dialogueRunner.StartDialogue(yarnNodeName[ranNode]);

    DDazoManager.Instance.ResetDDazo(-1); //테스트 끝난뒤 활성화 
  }


  bool IsClickGGom()
  {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit = new RaycastHit();

    if (true == (Physics.Raycast(ray.origin, ray.direction, out hit)))
    {
      if (hit.collider.name.Equals("GGom"))
        return true;
      else
        return false;
    }

    return false;
  }
}
