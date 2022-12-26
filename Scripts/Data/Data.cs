using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Data;
using static UnityEngine.UI.CanvasScaler;

public class Data : MonoBehaviour
{
  public delegate void GameStartSetData();
  GameStartSetData gameStartSetData;

  private void Awake()
  {
    gameStartSetData += new GameStartSetData(Manager.Instance.Init);
    gameStartSetData += new GameStartSetData(UIManager.Instance.Init);


    Debug.Log("게임이 시작됨");
    if(PlayerPrefs.HasKey("Feel"))
      Load();
    else
    {
      PlayerPrefs.GetFloat("Feel", 0);
      PlayerPrefs.GetInt("Heart", 0);
      PlayerPrefs.GetInt("DDazo", 0);
      UIManager.Instance.CurrFeel = 0;
      Manager.Instance.HeartNum = 0;
      UIManager.Instance.CurrDDazo = 5;
    }
    gameStartSetData();
  }
  private void Update()
  {
   // Debug.Log(UIManager.Instance.CurrFeel);
  }
  public void Save()
  {
    PlayerPrefs.SetFloat("Feel", UIManager.Instance.CurrFeel);
    PlayerPrefs.SetInt("Heart", Manager.Instance.HeartNum);
    PlayerPrefs.SetInt("DDazo", UIManager.Instance.CurrDDazo);
    PlayerPrefs.Save();
  }
  public void Load()
  {
    UIManager.Instance.CurrFeel = PlayerPrefs.GetFloat("Feel");   
    Manager.Instance.HeartNum = PlayerPrefs.GetInt("Heart");
    UIManager.Instance.CurrDDazo = PlayerPrefs.GetInt("DDazo");
    Debug.Log("데이터 로드" + UIManager.Instance.CurrFeel);
  }

  private void OnApplicationFocus(bool focus)
  {
    Save();
  }
  private void OnApplicationQuit()
  {
    Debug.Log("게임이 종료됨");
    Save();
  }  

}
