using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    
    public AudioClip healSound, damageSound, hitSound;
    public AudioSource audioSrc;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Heal":
                audioSrc.PlayOneShot(healSound,0.7f);
                break;
            case "Damage":
                audioSrc.PlayOneShot(damageSound,0.4f);
                break;
            case "Hit":
                audioSrc.PlayOneShot(hitSound,0.7f);
                break;
        }
    }
}
