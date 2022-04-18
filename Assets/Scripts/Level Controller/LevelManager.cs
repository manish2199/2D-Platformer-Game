using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   private static LevelManager instance;
    
   public static LevelManager Instance { get { return instance; } }

   [SerializeField] string[] Levels;




    void Awake()
    {
        MakeSingleTon();
    }

    void MakeSingleTon()
    {
        if ( instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }


    void Start()
    {
        if ( getLevelStatus(Levels[0]) == LevelStatus.Locked)
        {
           SetLevelStatus(Levels[0],LevelStatus.Unlocked);
        }
    }


    void UnlockCurrentLevel()
    {
      // Mark Current Level Completed
       Scene currentScene = SceneManager.GetActiveScene();
       SetLevelStatus(currentScene.name , LevelStatus.Completed);
 
      // Unlock Next Level
      int currentSceneIndex = Array.FindIndex(Levels , level => level == currentScene.name );
      int nextSceneIndex = currentSceneIndex + 1;
      if ( nextSceneIndex < Levels.Length)
     {
      SetLevelStatus(Levels[nextSceneIndex],LevelStatus.Unlocked);
     }
    }


    public void SetLevelStatus( string level , LevelStatus status)
    {
        PlayerPrefs.SetInt( level , (int)status);
    }

    public LevelStatus getLevelStatus(string level)
    {
        LevelStatus st = (LevelStatus)PlayerPrefs.GetInt(level , 0);
        return st;

    }


    
    

}
