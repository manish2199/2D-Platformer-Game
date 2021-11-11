using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelLoader : MonoBehaviour
{
   Button button;

   public int level;
 
   void Awake()
   {
       button = GetComponent<Button>();
       button.onClick.AddListener(function);
   }


   void function()
   {
       SceneFader.instance.sceneFader(level);
   }

} 
