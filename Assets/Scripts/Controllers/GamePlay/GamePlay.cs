using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GamePlay : MonoBehaviour
{
   public static GamePlay instace; 

   [SerializeField]private PlayerStats playerInfo;

   [SerializeField] GameObject gameOverPanel;


   [SerializeField] Animator playerAnim;

   [SerializeField] GameObject player;

   [SerializeField] GameOver gameOverCollider;

   [SerializeField] GameObject lifes;

   [SerializeField] Button restartButton;

   void Awake()
   {
       restartButton.onClick.AddListener(restartGame);
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
      gameOverPanel.SetActive(true);
    }


    void restartGame()
    {
      Scene scene = SceneManager.GetActiveScene();
      SceneFader.instance.sceneFader(scene.buildIndex);
    }

   
   









}
