using System;
using UnityEngine;

[Serializable]
public class TalkingToSelf
{
  [Tooltip("��� ġ�� ĳ���� �̸�")]
  public string name;

  [Tooltip("��� ����")]
  public string[] contexts;
}

[Serializable]
public class DialogueEvent
{
  public string name; //�� �̺�Ʈ�� �̸�
  public Vector2 line; //n�ٺ��� n�ٱ��� ��� ����
  public TalkingToSelf[] dialogues;
}
