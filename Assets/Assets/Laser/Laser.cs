using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField] PlayerStats player;


    void OnTriggerEnter2D ( Collider2D target)
    {


        if ( target.tag == "Player")
      {
        player.reduceLife();
        // Destroy(gameObject);
        print( "Hit the player");
      }
    }

}
