using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public Animator playerAnim;

   public float Speed;

   void Update()
   {
       float Horizontal = Input.GetAxis("Horizontal");
       float Vertical = Input.GetAxisRaw("Jump"); 
       PlayerFlip(Horizontal);

       AnimationController(Horizontal,Vertical);

    
       PlayerMovement(Horizontal);
   }

   void PlayerMovement(float horizontal)
   {
      // Horizontal Movement
      Vector3 temp = transform.position;
      temp.x += horizontal * Speed * Time.deltaTime;
      transform.position = temp;

   }

   void AnimationController(float horizontal , float vertical)
   {

      // For Run Animation   
       playerAnim.SetFloat("Speed",Mathf.Abs(horizontal));
      
      
      // For Jump Animation
      if( vertical > 0)
      {
        playerAnim.SetTrigger("jump");
      }
  

      // For Crouch Animation
      if ( Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)  ) 
      {
        playerAnim.SetBool("crouch",true);
        Speed = 0f;
      }
      else
      {
        playerAnim.SetBool("crouch",false);
        Speed = 10f;
      }
   }


   void PlayerFlip(float horizontal)
   {
      Vector3 scale = transform.localScale;
      if(horizontal < 0)
      {
        scale.x = -1f * Mathf.Abs(scale.x);
      }
      if(horizontal > 0)
      {
        scale.x = Mathf.Abs(scale.x);
      }
      transform.localScale = scale;
   }




}
