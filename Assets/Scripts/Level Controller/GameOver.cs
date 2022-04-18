using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    void OnTriggerEnter2D ( Collider2D target)
    {
        if ( target.gameObject.GetComponent<PlayerController>() != null)
        {
            GamePlay.instace.isPlayerFall = true;
        }
    }

}
