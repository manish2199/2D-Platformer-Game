using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TakeDamage : MonoBehaviour
{
   [SerializeField] Enemy enemyObj;


   int enemyHealth;


   void Awake()
   {
       enemyHealth = enemyObj.health;
   }

    
    void OnTriggerEnter2D(Collider2D target)
   {

       if ( target.gameObject.tag == "Bullet")
       {  
    
           int damage = target.gameObject.GetComponent<BulletScript>().damage;
           enemyHealth -= damage;

           Destroy(target.gameObject);

           if ( enemyHealth <= 0 )
           {
               enemyObj.enemyDead();
           }
       }
   }
}
