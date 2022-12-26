using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Move : MonoBehaviour
{
  Animator anim;

  private void Start()
  {
    anim = this.GetComponent<Animator>();
    anim.SetBool("LMove", true);
     StartCoroutine(CheckClick());
  }
  IEnumerator CorMove()
  {
    while(true)
    {    
        
      yield return new WaitForSeconds(2f);
      anim.SetBool("RMove", false);
      anim.SetBool("LMove", true);
      yield return new WaitForSeconds(2f);
      anim.SetBool("LMove", false);
      anim.SetBool("RMove", true); 
      yield return new WaitForSeconds(2f);
      anim.SetBool("RMove", false); 
      yield return new WaitForSeconds(2f);
    }
  }

  public IEnumerator LWait()
  {
    yield return new WaitForSeconds(2f);
    anim.SetBool("RMove", true);
  }
  public IEnumerator RWait()
  {
    anim.SetBool("RMove", false);
    anim.SetBool("LMove", false);
    yield return new WaitForSeconds(10f);
    anim.SetBool("LMove", true);
  }  
  IEnumerator CheckClick()
  {
    while (true)
    {
      yield return new WaitForSeconds(.001f);
      if (Input.GetMouseButtonDown(0) && UIManager.Instance.CurrDDazo > 0)
      {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (true == (Physics.Raycast(ray.origin, ray.direction, out hit))) 
        {
          if (hit.collider.name.Equals("GGom"))
          {
            Manager.Instance.OnClickDialog();
            UIManager.Instance.ResetDDazo(-1);
          }
        }
      }
    }
  }
  
}
