using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoSingleton<AdManager>
{
  // 구글 광고 - 보상형
  [SerializeField] private GameObject g_AdmobReward;
  public GameObject G_AdmobReward
  {
    set
    {
      if (g_AdmobReward == value) return;
      g_AdmobReward = value;
    }
    get { return g_AdmobReward; }
  }

  [SerializeField] private GameObject u_AdmobReward;
  public GameObject U_AdmobReward
  {
    set
    {
      if (u_AdmobReward == value) return;
      u_AdmobReward = value;
    }
    get { return u_AdmobReward; }
  }


}
