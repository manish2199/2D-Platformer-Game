using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class AudioManager : MonoBehaviour
{

   public static AudioManager instance;


  [HideInInspector] public bool isMute = true;
  
   public AudioSource soundEffect;
   public AudioSource soundMusic;

   public SoundType[] sounds;

   void Awake()
   {
       MakeSingleton();
   }

   void MakeSingleton()
   {
      if ( instance != null)
      {
        Destroy(gameObject);
      }
      else
      {
          instance = this;
          DontDestroyOnLoad(gameObject);
      }
   }


   public void MuteButton()
   {
       if(isMute)
       {
           isMute = false;

       }
       else if ( !isMute)
       {
           isMute = true;
       }
   }


   void Update()
   {

   }


   public void StopMusic()
   {
       soundMusic.Stop();
   }


    public void PlayMusic(Sound sound)
    {
       if(isMute)
       {
        AudioClip clip = GetAudioClip(sound);
        if(clip != null)
        {
         soundMusic.clip = clip;
         soundMusic.Play(); 
        }
        else
        {
            print("Clip not found");
        }
       }
       else if (!isMute )
       {
        //   soundMusic.Stop();
          soundMusic.Pause();
       }
    }

    
    public void PlaySound(Sound sound)
    {
       if( isMute)
       {
        AudioClip clip = GetAudioClip(sound);
        if(clip != null)
        {
         soundEffect.PlayOneShot(clip); 
        }
        else
        {
            print("Clip not found");
        }
       }
    }


    AudioClip GetAudioClip(Sound sound)
    {
        SoundType item = Array.Find(sounds, i => i.soundType == sound);
         if(item != null)
          return item.soundClip;
        return null;
    }
}



[Serializable]
public class SoundType
{
    public Sound soundType;
    public AudioClip soundClip;
}


public enum Sound
{
   ButtonClick,
   BackButton,
   LevelLocked,
   LevelUnlocked,
   MainMenuMusic,
   GamePlayMusic,
   Shoot,
   ChomperAttack,
   SpitterAttack,
   GunnerIntro,
   GunnerBeam,
   GunnerProjectile,
   GunnerDead,
   EnemyDead,
   KeyCollected,
   PlayerDead,
   Explosion,
}