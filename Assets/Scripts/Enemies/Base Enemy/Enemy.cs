using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{ 
    public int health;

    protected bool playerCollide;
    
    public LayerMask playerLayer;
    
    public float distfromPlayer;
    
    public PlayerStats player;
    
    public bool canAttack ;
    
    [SerializeField] Vector3 offset;
    
    protected bool moveRight;
    
    protected bool canMove = true;    

    public Animator animator;

    public float distance;

    public float Speed;

    public Transform groundDetection;


   protected void SetRayCast()
    {
        if(moveRight)
       {
        playerCollide = Physics2D.Raycast(transform.position+offset,Vector2.right,distfromPlayer,playerLayer);
       }
       else if ( !moveRight)
       {
        playerCollide = Physics2D.Raycast(transform.position+offset,Vector2.left,distfromPlayer,playerLayer);
       }
    }
   //=========================================================================================================================================



   protected void OnDrawGizmos()
   {
      Gizmos.color =  Color.red;
      if ( moveRight )
     {
      Gizmos.DrawLine(transform.position+offset,transform.position+offset+Vector3.right*distfromPlayer);

     }
     else if(!moveRight )
     {
      Gizmos.DrawLine(transform.position+offset,transform.position+offset+Vector3.left*distfromPlayer);
     }
   }
   //=========================================================================================================================================
   



    public void enemyDead()
   {
     StartCoroutine(Dead());
   }


    protected virtual IEnumerator Dead()
   {
        canMove = false;
        animator.SetTrigger("Death"); 
        AudioManager.instance.PlayMusic(Sound.EnemyDead);
        
        yield return new WaitForSeconds(0.45f);

        Destroy(gameObject); 
   }
   
   //=========================================================================================================================================




  protected virtual void enemyPatrolling()
   {
     if (health > 0 && canMove)
     {
      transform.Translate ( Vector2.right * Speed * Time.deltaTime);

     RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.transform.position,Vector2.down,distance);
     
     if(groundInfo.collider == false)
     {
         if(moveRight)
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

   //=========================================================================================================================================


   protected virtual void enemyAttack()
   {
     if(canAttack && health > 0 && player.isAlive())
     {
       SetRayCast();

        if(playerCollide)
       {     
          StartCoroutine(attackAnimation());
          playerCollide = false;
          canAttack = false;
       }
     }
    }


    protected virtual IEnumerator attackAnimation()
    {
       yield return null;
    }


   //=========================================================================================================================================
   
}
