using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    PlayerStats player;

    public float OffsetX;
    public float OffsetY;
  

    void Awake()
    {
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    void Update()
    {
       CameraMovement();
    }

    void CameraMovement()
    {
      if ( player.isAlive())
      {
        Vector3 temp = transform.position;
        temp.x = player.transform.position.x + OffsetX;
        temp.y = player.transform.position.y + OffsetY;
        transform.position = temp;
      }
    }
}
