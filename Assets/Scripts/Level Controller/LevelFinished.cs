using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelFinished : MonoBehaviour
{
    public GameObject levelFinishedText;

    GameObject player;

    [SerializeField] DoorCollider doorColl;

    public bool levelComplete;

    [SerializeField] GameObject door;

    void Awake()
    {
      player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
      if ( doorColl.isPlayerCollided)
      {
        door.SetActive(true);
      }
    }

    void OnTriggerEnter2D( Collider2D target)
    {
        if ( target.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level Finished");
            StartCoroutine(leveloneFinished());
            levelComplete = true;
            
        }
    }

    IEnumerator leveloneFinished()
   {
      levelFinishedText.SetActive(true);
      player.SetActive(false);

      yield return new WaitForSeconds(3f);

      SceneManager.LoadScene("Level2");
    }


}


