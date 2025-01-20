using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public AudioClip hurtSound;
    public AudioClip deathSound;
    public AudioClip shootSound;
    // Start is called before the first frame update
  
    public void PlaySoundAtLocation(string soundName, Vector3 position){
        AudioClip clip = GetAudioClip(soundName);
        if(clip != null){
            AudioSource.PlayClipAtPoint(clip, position);
        }
    }

    private AudioClip GetAudioClip(string soundName){
        switch (soundName)
        {
            case "Hurt":
                return hurtSound;
            case "Death":
                return deathSound;
            case "Shoot":
                return shootSound;
            default:
                return null;
        }
    }
}
