using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button quitButton;


    void Awake()
    {
        startButton.onClick.AddListener(StartGame); 
        quitButton.onClick.AddListener(QuitButton);
    }

    void StartGame()
    {
       SceneManager.LoadScene("Level1");
    }

    void QuitButton()
    {
      Application.Quit();
    }
  
}
