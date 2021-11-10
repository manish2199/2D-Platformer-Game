using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public bool isPlayerFall;
    

    void OnTriggerEnter2D ( Collider2D target)
    {
        if ( target.gameObject.GetComponent<PlayerController>() != null)
        {
            isPlayerFall = true;
        }
    }

}
