using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
   

   [SerializeField] Slider slider;

   public Vector3 offset;

   [SerializeField] Enemy enemyObj;

  
   [HideInInspector] public float hp;
   private float maxhp;
   
   
  void Awake()
  {
    maxhp =(float)enemyObj.health;
    Debug.Log(hp);
  }


  void Start()
  {
      hp = maxhp;
  }

  void Update()
  {
    slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    slider.value = (hp / maxhp); 
    print(slider.value);
  }


}
