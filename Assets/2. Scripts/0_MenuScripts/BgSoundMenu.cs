using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSoundMenu : MonoBehaviour
{
    public AudioSource bgSound;
    
    void Start()
    {
        bgSound.loop = true;
        bgSound.volume = 0.3f;
        bgSound.Play();
    }

}
