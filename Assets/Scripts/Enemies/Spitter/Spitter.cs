using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spitter : Enemy
{

    [SerializeField] GameObject projectile;
    
    [SerializeField] Transform SpitPos;
     
    float xAxisForce = 3.5f;
    float yAxisForce = 5f ;

    void Awake()
   {
     canAttack = true;
   }  


   void Update()
    {
      enemyAttack();
    }
 

   protected override IEnumerator attackAnimation()
   {
     animator.SetTrigger("SpitterAttack");
     AudioManager.instance.PlayMusic(Sound.SpitterAttack);
   
     yield return new WaitForSeconds(0.5f);    

     GameObject rgb = Instantiate(projectile,SpitPos.position,Quaternion.identity);
     rgb.GetComponent<Rigidbody2D>().velocity = new Vector2 (-xAxisForce , yAxisForce);


     yield return new WaitForSeconds(2f);

     animator.SetTrigger("Idle");
     canAttack = true;
    }

}
