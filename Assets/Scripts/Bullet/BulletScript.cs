using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    
  [SerializeField]
  float speed;

  public int damage ;


  [SerializeField] GameObject destroyEffect;


  public void ShootBullet(bool isFacingLeft)
    {
        Rigidbody2D rigidbody2D =  GetComponent<Rigidbody2D>();
        
        if ( isFacingLeft)
        {
            
            rigidbody2D.velocity = new Vector2(-speed , 0 );
            transform.eulerAngles = new Vector3 ( 0 , -180 , 0);
        }
        else if (!isFacingLeft)
        {
          
           rigidbody2D.velocity = new Vector2(speed , 0 );
            transform.eulerAngles = new Vector3 ( 0 , 0 , 0);
        }

        Destroy( gameObject ,5f);  
    }


    void OnTriggerEnter2D ( Collider2D target)
  {
    if ( target.tag == "Enemy")
    {
        Instantiate(destroyEffect , transform.position , Quaternion.identity);
        target.gameObject.GetComponentInChildren<HealthBarBehaviour>().hp -= damage;
    }  
  }
}
