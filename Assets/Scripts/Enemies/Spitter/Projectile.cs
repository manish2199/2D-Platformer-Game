using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  PlayerStats player;

  [SerializeField]Rigidbody2D rgb;

  [SerializeField] GameObject destroyEffect;

  void Awake()
  {
    player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();  
  }


  void OnTriggerEnter2D ( Collider2D target)
   {
      if ( target.tag == "Player")
      {
      
        AudioManager.instance.PlayMusic(Sound.Explosion);
      
        player.reduceLife();
 
        Instantiate(destroyEffect , transform.position , Quaternion.identity);

        Destroy(gameObject);

      }
    }
}

