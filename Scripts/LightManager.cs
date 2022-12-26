using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Experimental.Rendering.LWRP;

public class LightManager : MonoBehaviour
{
  private UnityEngine.Experimental.Rendering.Universal.Light2D light;
  private void Start()
  {
    StartCoroutine(LightCtr());
  }
  IEnumerator LightCtr()
  {
    light = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
    while (true)
    {
      yield return new WaitForSeconds(5f);

      for (int i = 0; i < 2; i++)
      {
        light.enabled = false;
        yield return new WaitForSeconds(.01f);
        light.enabled = true;
        yield return new WaitForSeconds(1f);
      }

      //빛을 줄이는 효과를 할지..고민되네
      //for (; light.pointLightInnerAngle > 0;)
      //  light.pointLightInnerAngle -= 2f;
      //yield return new WaitForSeconds(.01f);
      //for (; light.pointLightInnerAngle < 174;)
      //  light.pointLightInnerAngle += 10f;
    }
  }

}
