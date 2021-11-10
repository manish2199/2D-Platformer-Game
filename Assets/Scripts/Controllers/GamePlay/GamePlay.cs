using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
   public static GamePlay instace; 

   [SerializeField]private PlayerStats playerInfo;

   [SerializeField] GameObject gameOverText;


   [SerializeField] Animator playerAnim;

   [SerializeField] GameObject player;

   [SerializeField] GameOver gameOverCollider;

   [SerializeField] GameObject lifes;



   void Awake()
   {
       makeStatiInstance();
   }

   void makeStatiInstance()
   {
       if ( instace == null)
       {
          instace = this;
       }
   }


   void Update()
   {
       if (!playerInfo.isAlive() || gameOverCollider.isPlayerFall)
       {
           StartCoroutine(playerDied());
       }
   }


    IEnumerator playerDied()
   {
      playerAnim.SetTrigger("Death");
      lifes.SetActive(false);
     
      yield return new WaitForSeconds(1f);

      player.GetComponent<SpriteRenderer>().enabled = false;
      gameOverText.SetActive(true);

      
      yield return new WaitForSeconds(1.5f);
    
      SceneManager.LoadScene("Level1");
    }

   









}
