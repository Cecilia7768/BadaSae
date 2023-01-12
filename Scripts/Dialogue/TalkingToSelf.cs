using System;
using UnityEngine;

[Serializable]
public class TalkingToSelf
{
  [Tooltip("대사 치는 캐릭터 이름")]
  public string name;

  [Tooltip("대사 내용")]
  public string[] contexts;
}

[Serializable]
public class DialogueEvent
{
  public string name; //이 이벤트의 이름
  public Vector2 line; //n줄부터 n줄까지 대사 추출
  public TalkingToSelf[] dialogues;
}
