using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : Enemy
{

  [SerializeField] GameObject projectile;

  [SerializeField] Transform launchPos;

  bool canRotate;

  bool isRunning = false;


  float xAxisForce = 3.5f;
  float yAxisForce = 5f ;

  RaycastHit2D groundInfo;

  void Awake() 
  {
    health = 100;
    canAttack = true;
    moveRight = false;
  }

  
  void Update()
  {
    if (health > 0 && canMove)
    {

      SetRayCast();

      if(!playerCollide)
     {
      canAttack = true;

      enemyPatrolling();
     }
     else
     {  
      enemyAttack();
     }
    }
     
    if ( health <= 0 )
    {
      StopCoroutine(attackAnimation());
      StopCoroutine(GunnerAttack());
    }
  }

  protected override void enemyAttack()
   {
     if(canAttack && health > 0 && player.isAlive() )
     {
        if(playerCollide)
       { 
          StartCoroutine(attackAnimation());
          playerCollide = false;
          canAttack = false;
       }
     }
    }



 protected override IEnumerator attackAnimation()
  {
      animator.SetBool("Walk", false);
      
      yield return new WaitForSecondsRealtime(0.4f);
      
      animator.SetTrigger("Grenade");
      AudioManager.instance.PlayMusic(Sound.GunnerProjectile);

      yield return new WaitForSecondsRealtime(0.9f);

      GrenadeAttack();

      yield return new WaitForSecondsRealtime(0.3f);

      animator.ResetTrigger("Grenade");   
  }


 protected override void enemyPatrolling()
 {
   groundInfo = Physics2D.Raycast(groundDetection.transform.position,Vector2.down,distance);

    if( health > 0 && canAttack)
    {
      if (groundInfo.collider)
      {
        transform.Translate ( Vector2.right * Speed * Time.deltaTime);

        animator.SetBool("Walk",true);
  
      }
      else
      {
       if(!isRunning)
       {
         StartCoroutine(GunnerAttack());
        }
      }
    }
  }




  IEnumerator GunnerAttack()
  {
      isRunning = true;
      canRotate = true;
      animator.SetBool("Walk" ,false);

      yield return new WaitForSecondsRealtime(2f);
      
       
      animator.SetTrigger("BeamAttack");

      yield return new WaitForSecondsRealtime(0.5f);

      AudioManager.instance.PlayMusic(Sound.GunnerBeam);
      animator.ResetTrigger("BeamAttack");

      yield return new WaitForSecondsRealtime(1f);
       
      
      animator.SetTrigger("Grenade");
      AudioManager.instance.PlayMusic(Sound.GunnerProjectile);

      yield return new WaitForSecondsRealtime(0.9f);
       
      
      GrenadeAttack();
      

      yield return new WaitForSecondsRealtime(0.3f);
      
    
      animator.ResetTrigger("Grenade"); 

      yield return new WaitForSecondsRealtime(2f);       
    
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
            
      isRunning = false;     
   }


   void GrenadeAttack()
   { 
      GameObject rgb =  Instantiate(projectile,launchPos.position,Quaternion.identity);
     if ( moveRight)
     {
      rgb.GetComponent<Rigidbody2D>().velocity = new Vector2 (xAxisForce , yAxisForce);
     }
     else
     {
      rgb.GetComponent<Rigidbody2D>().velocity = new Vector2 (-xAxisForce , yAxisForce);
     }
  }




   protected override IEnumerator Dead()
   {
      canMove = false;
      animator.SetTrigger("Death"); 
      AudioManager.instance.PlayMusic(Sound.GunnerDead);
        
      yield return new WaitForSecondsRealtime(6f);

      Destroy(gameObject); 
    
   }





    
   
}
