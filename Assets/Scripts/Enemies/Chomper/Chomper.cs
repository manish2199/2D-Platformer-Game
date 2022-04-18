using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper : Enemy
{

  void Awake()
  {
    canAttack = true;
  } 


   void Update()
   {
        enemyPatrolling();
      
        if (canMove)
        {
           enemyAttack();
        }
      
   }


   protected override IEnumerator attackAnimation()
   {
     player.reduceLife();
     animator.SetTrigger("Attack");
     AudioManager.instance.PlayMusic(Sound.ChomperAttack);

     yield return new WaitForSeconds(0.5f);
     
     gameObject.SetActive(false);
   }
   
}

