using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelFinished : MonoBehaviour
{
    public GameObject levelFinishedText;

    void OnTriggerEnter2D( Collider2D target)
    {
        if ( target.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level Finished");
            StartCoroutine(leveloneFinished());
        }
    }

    IEnumerator leveloneFinished()
   {
      levelFinishedText.SetActive(true);

      yield return new WaitForSeconds(3f);

      SceneManager.LoadScene("Level2");
    }


}


