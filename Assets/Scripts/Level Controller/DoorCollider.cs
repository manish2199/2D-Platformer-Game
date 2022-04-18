using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    [HideInInspector] public bool isPlayerCollided;

    public GameObject d;

    void OnTriggerEnter2D ( Collider2D target)
    {
        if ( target.tag == "Player")
        {
            isPlayerCollided = true;
            d.SetActive(true);
        }
    }
}
