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
  
  
}
