using System.Collections;
using UnityEngine;
using TMPro;

public class TalkingToSelfUI : MonoBehaviour
{
  [SerializeField] GameObject dialoguesObj;

  TalkingToSelf[] dialogues;

  int lineCount = 0; // 대화 카운트
  int contextCount = 0; // 대사 카운트

  void Awake()
  {
    UIManager.Instance.startDialogue += WaitCollision;
  }

  public void ShowDialouge(TalkingToSelf[] p_dialogues)
  {
    UIManager.Instance.SetTalkingToSelfText("");
    dialogues = p_dialogues;
    StartCoroutine(TypeWriter());
  }

  public void WaitCollision()
  {
    StartCoroutine(CorWaitCollision());
  }
  IEnumerator CorWaitCollision()
  {
    ShowDialouge(dialoguesObj.GetComponent<InteractionEvent>().GetDialogues());
    yield return null;
  }
  IEnumerator TypeWriter()
  {
    lineCount = Random.Range(0, dialogues.Length);
    string t_ReplaceText = dialogues[lineCount].contexts[contextCount]; 

    UIManager.Instance.SetTalkingToSelfText(t_ReplaceText);
    yield return new WaitForSeconds(1f);
    UIManager.Instance.OnOFTalkingToSelfUI(false);
  }


}
