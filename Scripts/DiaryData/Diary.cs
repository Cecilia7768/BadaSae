using System;
using UnityEngine;

public class Diary
{
  public int diaryNum; //���°���� �б�����.. �ʿ��������?
  public string diaryfeelNum; //�ϱ⳻�뿡 ���� ��к�ȭ ��ġ
  [Tooltip("��ȭ ����")]
  public string[] contexts;
}

[Serializable]
public class DiaryEvent
{
  public Vector2 line; //������ ����
  public Diary[] diaries;
}
