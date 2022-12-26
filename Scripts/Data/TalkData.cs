using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class TalkData : MonoBehaviour
{
  const string URL = "https://docs.google.com/spreadsheets/d/1zlWfm9P_7GcIteUD7eROiDloWOXXj1r9PI4kstcl5DE/export?format=tsv&range=A2:B";
  IEnumerator Start()
  {
    UnityWebRequest www = UnityWebRequest.Get(URL);
    yield return www.SendWebRequest();

    string data = www.downloadHandler.text;
    print(data);
  }

}
