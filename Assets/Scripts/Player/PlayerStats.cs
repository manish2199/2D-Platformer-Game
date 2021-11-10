using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerStats : MonoBehaviour
{
   public ScoreController scoreContro; 
   int playerHealth = 3; 
   public GameObject[] lifes;
   public Transform respawnPos;
   [SerializeField] Animator playerAnim;

  

   public bool isAlive()
   {
     if( playerHealth <=0)
     {
       return false;
     }
       return true;
   }


   
    public void KeyCollected()
   { 
     scoreContro.IncreaseScore(10); 
   }


    public void reduceLife()
   {
      playerHealth --;
      lifes[playerHealth].SetActive(false);    
      StartCoroutine(respawn());  
   }

   IEnumerator respawn()
   {
      playerAnim.SetTrigger("Death");

      yield return new WaitForSeconds(1f);
  
      GetComponent<SpriteRenderer>().enabled = false;
      
      yield return new WaitForSeconds(1f);

      playerAnim.SetTrigger("Respawn");
      transform.position = respawnPos.position;
      GetComponent<SpriteRenderer>().enabled = true;
    }
}
