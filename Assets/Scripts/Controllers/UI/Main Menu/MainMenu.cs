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
        //  playerAnimator.SetTrigger("StopPush"); 
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
      //  SceneManager.LoadScene("Level1");
      // SceneFader.instance.sceneFader(1);
      levelSelection.SetActive(true);
      
      foreach ( GameObject o in menuUI)
      {
        o.SetActive(false);
      }
       
    }

    void QuitButton()
    {
      Application.Quit();
    }


  
}
