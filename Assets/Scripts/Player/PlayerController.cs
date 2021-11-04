using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public Animator playerAnim;


   void Update()
   {
       float speed = Input.GetAxis("Horizontal");
       Debug.Log(speed);
       playerAnim.SetFloat("Speed",Mathf.Abs(speed));
   
      Vector3 scale = transform.localScale;
      if(speed < 0)
      {
        scale.x = -1f * Mathf.Abs(scale.x);
      }
      if(speed > 0)
      {
        scale.x = Mathf.Abs(scale.x);
      }
      transform.localScale = scale;
   }
}
