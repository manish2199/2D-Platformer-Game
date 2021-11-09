using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper : MonoBehaviour
{
    // Movement
    public float Speed;
    public float distance;
    private bool moveRight;

    // Attack 
    private bool playerCollide;
    public LayerMask playerLayer;
    public float distfromPlayer;
    private PlayerController player;

    public Transform groundDetection;

    // Animation
    Animator animator;

  void Awake()
  {
    animator = GetComponent<Animator>();
   player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
  } 


   void Update()
   {
      enemyPatrolling();

     
      enemyAttack();
      
   }


   void enemyAttack()
   {
    if(moveRight)
    {
      playerCollide = Physics2D.Raycast(transform.position,Vector2.right,distfromPlayer,playerLayer);
    }
    else
    {
      playerCollide = Physics2D.Raycast(transform.position,Vector2.left,distfromPlayer,playerLayer);
    }

      if(playerCollide && player.isAlive())
      {
        player.reduceLife();
        // perform attack anim;
        animator.SetTrigger("Attack");

        // StartCoroutine(attackAnimation());
        // Debug.Log(player.playerHealth);
        gameObject.SetActive(false);
      }

   }


//    IEnumerator attackAnimation()
//    {
    //  animator.SetTrigger("Attack");

    //   yield return new WaitForSeconds(1f);

    //   gameObject.SetActive(false);
//    }

   void OnDrawGizmos()
   {
      Gizmos.color =  Color.red;
      if ( moveRight )
     {
      Gizmos.DrawLine(transform.position,transform.position+Vector3.right*distfromPlayer);
     }
     else if( !moveRight )
     {
      Gizmos.DrawLine(transform.position,transform.position+Vector3.left*distfromPlayer);
     }
   }


   void enemyPatrolling()
   {
     transform.Translate ( Vector2.right * Speed * Time.deltaTime);

     RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.transform.position,Vector2.down,distance);
     
     if(groundInfo.collider == false)
     {
         if( moveRight)
         {
             transform.eulerAngles = new Vector3 ( 0 , -180 , 0);
             moveRight = false;
         }
         else
         {
             transform.eulerAngles = new Vector3 ( 0 , 0 , 0);
             moveRight = true;
         }
     }
   }



}

