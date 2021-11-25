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


   [SerializeField] GameObject lifes;

   [SerializeField] Button restartButton;

   [HideInInspector] public bool isPlayerFall = false;

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


   void Start()
   {
       AudioManager.instance.PlayMusic(Sound.GamePlayMusic);
   }


   void Update()
   {
       if (!playerInfo.isAlive() || isPlayerFall )
       {
           StartCoroutine(playerDied());
       }
       else
       {
       }
     
   }


    IEnumerator playerDied()
   {
      playerAnim.SetTrigger("Death");
      lifes.SetActive(false);
      AudioManager.instance.PlayMusic(Sound.PlayerDead);

     
      yield return new WaitForSeconds(1f);

      player.GetComponent<SpriteRenderer>().enabled = false;
      gameOverPanel.SetActive(true);
      AudioManager.instance.StopMusic();
    }


    void restartGame()
    {
      Scene scene = SceneManager.GetActiveScene();
      SceneFader.instance.sceneFader(scene.name);
    }

   
   









}
