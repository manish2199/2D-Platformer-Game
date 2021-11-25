using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [Header("Components")] 
   [SerializeField]Animator playerAnim;
   BoxCollider2D playerCollider;
   Rigidbody2D rigidbody2D;
   PlayerStats playerStats;
  
   [Header("\nMovement Settings")]
   public float Speed;
   public float jumpForce;
   float Horizontal;
   [HideInInspector]public bool canMove = true;
  

   
   [Header("\nCollision Settings")]
   public LayerMask groundLayer;
   public bool Grounded;
   public float groundLength;
   [SerializeField]Vector3 colliderOffset;


   [Header("\nGravity Settings")]
   [SerializeField]float gravity = 1 ;
   [SerializeField]float gravityMultiplyer = 5;


   [Header("\nShooting Settings")]
   [SerializeField] GameObject Bullet;
   [SerializeField] Transform BulletPos;
   bool isFacingLeft ;

   [Header("\nMeleeAttack Settings")]
   [SerializeField] int staffDamage;
  


   void Awake()
   {
     rigidbody2D = GetComponent<Rigidbody2D>();
     playerCollider = GetComponent<BoxCollider2D>();
     playerStats = GetComponent<PlayerStats>();
   }


   void Update()
   {
      
      Horizontal = Input.GetAxis("Horizontal");

     
     if ( playerStats.isAlive() && canMove && !GamePlay.instace.isPlayerFall)
     {
       Grounded =Physics2D.Raycast(transform.position + colliderOffset,Vector2.down,groundLength,groundLayer) || Physics2D.Raycast(transform.position-colliderOffset,Vector2.down,groundLength,groundLayer);
       
       AnimationController(Horizontal);
       
       PlayerMovement(Horizontal);

      

       
       if (Grounded && Input.GetButtonDown("Jump") )
       {
         Jump();
       }
     }
   }

   void FixedUpdate()
   {
     ModifyGravity();   
   }

   
   
   
   void ModifyGravity()
   {
     if( !Grounded)
     {
        rigidbody2D.gravityScale = gravity; 
        rigidbody2D.drag = 0.6f;
        if ( rigidbody2D.velocity.y < 0 )
        {
          rigidbody2D.gravityScale = gravity * gravityMultiplyer;
        }
        if ( rigidbody2D.velocity.y > 0 && !Input.GetButtonDown("Jump") )
        {
          rigidbody2D.gravityScale = gravity * ( gravityMultiplyer / 2);
        }
     }
     else
     {
        rigidbody2D.gravityScale = 0f;
     }
   }

 
       

   void Jump()
    {
        rigidbody2D.velocity= new Vector2(rigidbody2D.velocity.x,0);
        rigidbody2D.AddForce(Vector2.up * jumpForce , ForceMode2D.Impulse);
        playerAnim.SetTrigger("jump");   
    }

   void PlayerMovement(float horizontal )
   {
      
      Vector3 temp = transform.position;
      temp.x += horizontal * Speed * Time.deltaTime;
      transform.position = temp;
  
      PlayerFlip(horizontal);
   }


  void AnimationController(float horizontal)
   {
      // For Run Animation   
      playerAnim.SetFloat("Speed",Mathf.Abs(horizontal));

      //----------------------------------------------------------------------

      
    
      // For Crouch Animation
      if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl)  ) 
      {
        playerAnim.SetBool("Crouch",true);
        Speed = 0f;
      }
      else if ( Input.GetKeyUp(KeyCode.RightControl) || Input.GetKeyUp(KeyCode.LeftControl) )
      {
        playerAnim.SetBool("Crouch",false);
        Speed = 8f;
      }

       //----------------------------------------------------------------------
 
      // Shooting Bullet
      if(Grounded)
      {
        if ( Input.GetMouseButton(1))
        {
        // Aim the gun
        playerAnim.SetBool("Gun",true);

        if( Input.GetMouseButtonDown(0))
        {
           // Shoot 
            AudioManager.instance.PlayMusic(Sound.Shoot);
            GameObject bullet = Instantiate(Bullet);
            bullet.GetComponent<BulletScript>().ShootBullet(isFacingLeft);
            bullet.transform.position = BulletPos.position;
        }

      }
      else if ( Input.GetMouseButtonUp(1))
      {
         playerAnim.SetBool("Gun",false);
        
      }

    }
    
    //----------------------------------------------------------------------

    // Melee Attack 
    if (Input.GetKeyDown(KeyCode.M))
    {
      playerAnim.SetTrigger("Slash");
    }
   


   }


   void PlayerFlip(float horizontal)
   {
      Vector3 scale = transform.localScale;
      if(horizontal < 0)
      {
        scale.x = -1f * Mathf.Abs(scale.x);
        isFacingLeft = true;
      }
      if(horizontal > 0)
      {
        scale.x = Mathf.Abs(scale.x);
        isFacingLeft = false;
      }
      transform.localScale = scale;
   }


   

   
   void OnDrawGizmos()
   {
      Gizmos.color =  Color.red;
      Gizmos.DrawLine(transform.position + colliderOffset , transform.position + colliderOffset + Vector3.down * groundLength);
      Gizmos.DrawLine(transform.position - colliderOffset , transform.position - colliderOffset + Vector3.down * groundLength);
   }

  
}
       