using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button quitButton;

    [SerializeField] GameObject levelSelection;
    [SerializeField] GameObject[] menuUI;

    [SerializeField] Animator playerAnimator;


    void Awake()
    {
        startButton.onClick.AddListener(StartGame); 
        quitButton.onClick.AddListener(QuitButton);
    }

    void Start()
    {
       AudioManager.instance.PlayMusic(Sound.MainMenuMusic);
    }


    void Update ()
    {
      // if ( playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Push"))
      // {
      //    playerAnimator.SetTrigger("StopPush");
      // }
     
    }

    void StartGame()
    {
      AudioManager.instance.PlaySound(Sound.ButtonClick);
      levelSelection.SetActive(true);
      
      foreach ( GameObject o in menuUI)
      {
        o.SetActive(false);
      }
       
    }

   public void DeactivateLevelSelection()
    {
      AudioManager.instance.PlaySound(Sound.BackButton);
      levelSelection.SetActive(false);
       foreach ( GameObject o in menuUI)
      {
        o.SetActive(true);
      }
    }

    void QuitButton()
    {
      AudioManager.instance.PlaySound(Sound.BackButton);
      Application.Quit();
    }


  
}
