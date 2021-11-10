using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper : MonoBehaviour
{
    // Movement
    public float Speed;
    public float distance;
    private bool moveRight;
    BoxCollider2D collider;

    // Attack 
    private bool playerCollide;
    public LayerMask playerLayer;
    public float distfromPlayer;
    private PlayerStats player;
    bool canAttack = true;
 
    public Transform groundDetection;

    // Animation
    Animator animator;

  void Awake()
  {
    collider = GetComponent<BoxCollider2D>();
    animator = GetComponent<Animator>();
    player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
  } 


   void Update()
   {
      enemyPatrolling();
      
      enemyAttack();
   }


   void enemyAttack()
   {
     if(canAttack)
     {
       SetRayCast();

        if(playerCollide && player.isAlive())
       {
          canAttack = false;
          player.reduceLife();
          StartCoroutine(attackAnimation());
       }
     }
    }

    void SetRayCast()
    {
        if(moveRight)
       {
        playerCollide = Physics2D.Raycast(transform.position,Vector2.right,distfromPlayer,playerLayer);
       }
       else
       {
        playerCollide = Physics2D.Raycast(transform.position,Vector2.left,distfromPlayer,playerLayer);
       }
    }


   IEnumerator attackAnimation()
   {
     animator.SetTrigger("Attack");

     yield return new WaitForSeconds(0.5f);
     
      gameObject.SetActive(false);
   }

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

