using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public Animator playerAnim;

   public float Speed;
   public float jumpForce;

   float Horizontal;
   float Vertical;


   BoxCollider2D playerCollider;
   Rigidbody2D rigidbody2D;

   bool Grounded = false;

   void Awake()
   {
     rigidbody2D = GetComponent<Rigidbody2D>();
     playerCollider = GetComponent<BoxCollider2D>();
   }

   void Update()
   {
       Horizontal = Input.GetAxis("Horizontal");
       Vertical = Input.GetAxisRaw("Jump"); 
     
       AnimationController(Horizontal,Vertical);

       
       PlayerMovement(Horizontal);
   }

   void FixedUpdate()
   {
      // Jump Controller
       if(Grounded && Vertical > 0 )
      {
        rigidbody2D.AddForce( new Vector2(0,jumpForce),ForceMode2D.Force);
      }
   }

   void PlayerMovement(float horizontal )
   {
      // Horizontal Movement
      Vector3 temp = transform.position;
      temp.x += horizontal * Speed * Time.deltaTime;
      transform.position = temp;

      PlayerFlip(horizontal);
   }


   

   void AnimationController(float horizontal , float vertical)
   {

      // For Run Animation   
       playerAnim.SetFloat("Speed",Mathf.Abs(horizontal));
      
      
      // For Jump Animation
      if(Grounded && vertical > 0 )
      {
        playerAnim.SetTrigger("jump");
      }
  

      // For Crouch Animation
      if ( Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)  ) 
      {
        playerAnim.SetBool("crouch",true);
        Speed = 0f;
        playerCollider.size = new Vector2 ( 0.6334516f,1.321949f);
        playerCollider.offset = new Vector2 ( 0.02000001f, 0.61f);
      }
      else
      {
        playerAnim.SetBool("crouch",false);
        Speed = 8f;
        playerCollider.size = new Vector2 (0.6334516f,2.07323f);
        playerCollider.offset= new Vector2 (0.02000001f,0.9816846f);
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

  
   void OnCollisionStay2D(Collision2D col)
   {
     if ( col.gameObject.tag == "Ground")
     {
       Grounded = true;
     }


   }

    void OnCollisionExit2D(Collision2D col)
   {
       Grounded = false;
        rigidbody2D.AddForce( new Vector2(0,-500f),ForceMode2D.Force);
   }


}
       