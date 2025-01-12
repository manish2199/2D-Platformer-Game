using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelLoader : MonoBehaviour
{
   Button button;

   public string level;
 
   void Awake()
   {
       button = GetComponent<Button>();
       button.onClick.AddListener(whenClicked);
   }


   void whenClicked() 
  {
      if ( level != "MainMenu")
      {
          LevelStatus state = LevelManager.Instance.getLevelStatus(level);

      switch (state)
      {
          case LevelStatus.Locked :
          // print("Level Locked");
           AudioManager.instance.PlaySound(Sound.LevelLocked);
           break;

          case LevelStatus.Completed :
           SceneFader.instance.sceneFader(level);
           break;

          case LevelStatus.Unlocked :
           AudioManager.instance.PlaySound(Sound.LevelUnlocked);
           SceneFader.instance.sceneFader(level);
           break;
        }

      }
      else if ( level == "MainMenu")
      {
         SceneFader.instance.sceneFader(level);
      }

      
   }

} 
