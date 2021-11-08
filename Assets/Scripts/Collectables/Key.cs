using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
  Animator anim;
 
  void Awake()
  {
      anim = GetComponent<Animator>();
  }

  void Start()
  {
      anim.SetBool("Collected" , false);
  }


  void OnTriggerEnter2D ( Collider2D target)
  {
    if ( target.gameObject.GetComponent<PlayerController>() != null)
    {
       PlayerController player = target.gameObject.GetComponent<PlayerController>();
      //  anim.Play("Key_Collected");
       player.KeyCollected();
       Destroy(gameObject);
    }
  }
}
