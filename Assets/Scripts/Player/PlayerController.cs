using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
   public Animator playerAnim;
   public ScoreController scoreContro;

   public float Speed;
   public float jumpForce;

   float Horizontal;

   BoxCollider2D playerCollider;
   Rigidbody2D rigidbody2D;


    int playerHealth = 3;
    public GameObject[] lifes;

   // Ground  Collision
   public LayerMask groundLayer;
   public bool Grounded;
   public float groundLength;
   [SerializeField]Vector3 colliderOffset;
   [SerializeField]float gravity = 1 ;
   [SerializeField]float gravityMultiplyer = 5;
   

   public bool isAlive()
   {
     if( playerHealth <=0)
     {
       return false;
     }
       return true;
   }

   void Awake()
   {
     rigidbody2D = GetComponent<Rigidbody2D>();
     playerCollider = GetComponent<BoxCollider2D>();
   }


   void Update()
   {
     if ( isAlive() )
     {
       Grounded =Physics2D.Raycast(transform.position + colliderOffset,Vector2.down,groundLength,groundLayer) || Physics2D.Raycast(transform.position-colliderOffset,Vector2.down,groundLength,groundLayer);

       Horizontal = Input.GetAxis("Horizontal");
       
       AnimationController(Horizontal);
       
       PlayerMovement(Horizontal);

       if ( Grounded  && Input.GetButtonDown("Jump"))
       {
       Jump();
       }
     }
     else if ( !isAlive())
     {
      StartCoroutine("playerDied");
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

   public void KeyCollected()
   { 
     scoreContro.IncreaseScore(10); 
   }
       

   void Jump()
    {
      // Jump Controller
        rigidbody2D.velocity= new Vector2(rigidbody2D.velocity.x,0);
        rigidbody2D.AddForce(Vector2.up * jumpForce , ForceMode2D.Impulse);
        playerAnim.SetTrigger("jump");
    }

   void PlayerMovement(float horizontal )
   {
      // Horizontal Movement
      Vector3 temp = transform.position;
      temp.x += horizontal * Speed * Time.deltaTime;
      transform.position = temp;

      PlayerFlip(horizontal);
   }


  void AnimationController(float horizontal)
   {

      // For Run Animation   
       playerAnim.SetFloat("Speed",Mathf.Abs(horizontal));
      

      // For Crouch Animation
      if ( Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl)  ) 
      {
        playerAnim.SetBool("crouch",true);
        Speed = 0f;
      }
      else if ( Input.GetKeyUp(KeyCode.RightControl) || Input.GetKeyUp(KeyCode.LeftControl) )
      {
        playerAnim.SetBool("crouch",false);
        Speed = 8f;
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

   
   void OnDrawGizmos()
   {
      Gizmos.color =  Color.red;
      Gizmos.DrawLine(transform.position + colliderOffset , transform.position + colliderOffset + Vector3.down * groundLength);
      Gizmos.DrawLine(transform.position - colliderOffset , transform.position - colliderOffset + Vector3.down * groundLength);
   }


    public void reduceLife()
   {
       playerHealth --;
       Debug.Log(playerHealth);
       lifes[playerHealth].SetActive(false);
   }


   IEnumerator playerDied()
   {
     playerAnim.SetTrigger("Death");
     
      yield return new WaitForSeconds(1f);


    
    //  gameObject.SetActive(false);
     
    //  yield return new WaitForSeconds(0.5f);
      SceneManager.LoadScene("SampleScene");

   }

}
       