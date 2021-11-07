using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    
    [SerializeField] GameObject gameOverText;
  
    GameObject player;

    void Awake()
    {
      player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D ( Collider2D target)
    {
        if ( target.gameObject.GetComponent<PlayerController>() != null)
        {
             StartCoroutine(gameOver());
        }
    }


    IEnumerator gameOver()
   {
      gameOverText.SetActive(true);
      player.SetActive(false);

      yield return new WaitForSeconds(2f);

      gameOverText.SetActive(false);
      SceneManager.LoadScene("SampleScene");
    }
}
