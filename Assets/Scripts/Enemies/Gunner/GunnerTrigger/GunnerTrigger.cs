using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerTrigger : MonoBehaviour
{
   [SerializeField] Animator triggerAnim;

   public ParticleSystem particalEffect;

   [SerializeField] GameObject gunner;


  void Start()
  {
      particalEffect.Stop();
  }
 

  void OnTriggerEnter2D(Collider2D target)
  {
    if ( target.tag == "Player")
    {
      StartCoroutine(gunnerEntry());
    }
  }



  IEnumerator gunnerEntry()
  {
      triggerAnim.Play("Gunner_GateOpening");
      AudioManager.instance.PlayMusic(Sound.GunnerIntro);

      yield return new WaitForSeconds(5f);

      particalEffect.Play();

      yield return new WaitForSeconds(2f);

      triggerAnim.Play("Gunner_Appear");
     
      yield return new WaitForSeconds(5f);
     
      particalEffect.Stop();
 
      yield return new WaitForSeconds(2.4f);
      
     gunner.SetActive(true);
     gameObject.SetActive(false);
  }


}
