using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    [HideInInspector]public bool isGrounded;

    [SerializeField]private LayerMask platformLayer;

   void OnTriggerStay2D( Collider2D target)
  {
    isGrounded = target != null && (((1 << GetComponent<Collider2D>().gameObject.layer) & platformLayer) != 0) ;
    print(isGrounded);
  }

  void OnTriggerExit2D( Collider2D target)
  {
    isGrounded = false;
    print(isGrounded);

  }

}
