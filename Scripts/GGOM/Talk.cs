using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Yarn.Unity;

public class Talk : MonoBehaviour
{
  [Header("�ὺũ��Ʈ")]
  [SerializeField] GameObject yarnObj;
  Yarn.Unity.DialogueRunner dialogueRunner;
  [Header("�ὺũ��Ʈ ��� �̸�")]
  [SerializeField] List<string> yarnNodeName = new List<string>();


  void Start()
  {
    dialogueRunner = yarnObj.GetComponent<DialogueRunner>();
    var mouseDownStream = this.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(0));

    //������ ��ȭ�� ���� ��ȭ ����
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
  /// ������ ���� �� ������ ȥ�㸻
  /// </summary>
  void StartTalkingToSelf()
  {
    UIManager.Instance.OnOFTalkingToSelfUI(true);
    UIManager.Instance.startDialogue();
  }

  /// <summary>
  /// �̺�Ʈ ��ȭ ����
  /// </summary>
  public void StartDialouge()
  {
    //�� ��ũ��Ʈ �� ���� ����� ��ȭ������ �ҷ��´�.
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

    DDazoManager.Instance.ResetDDazo(-1); //�׽�Ʈ ������ Ȱ��ȭ 
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
