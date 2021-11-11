using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
  [SerializeField] GameObject SceneFaderPanel;  
  [SerializeField] Animator animator;

  public static SceneFader instance;

  void Awake()
  {
      SceneFaderPanel.SetActive(false);
      
      MakeSingleTon();
  }


  void MakeSingleTon()
  {
      if (instance != null)
      {
        Destroy(gameObject);
      }
      else if ( instance == null)
      {
        DontDestroyOnLoad(gameObject);
        instance = this;
      }
  }

  public void sceneFader(int Level)
  {
     StartCoroutine(scenefadeInOut(Level));
  }


  IEnumerator scenefadeInOut(int lev)
  {
      SceneFaderPanel.SetActive(true);
      animator.Play("Fade_In");
      yield return new WaitForSeconds(0.7f);
 
      SceneManager.LoadScene(lev);

      animator.Play("Fade_Out");

      yield return new WaitForSeconds(1f);

      SceneFaderPanel.SetActive(false);
  }


}
