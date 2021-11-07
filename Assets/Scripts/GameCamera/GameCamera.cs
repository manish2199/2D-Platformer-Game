using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    GameObject player;

    void Awake()
    {
      player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
       CameraMovement();
    }

    void CameraMovement()
    {
      Vector3 temp = transform.position;
      temp.x = player.transform.position.x;
      temp.y = player.transform.position.y;
      transform.position = temp;
    }
}
