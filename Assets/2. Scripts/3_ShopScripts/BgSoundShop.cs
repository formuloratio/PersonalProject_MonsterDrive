using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSoundShop : MonoBehaviour
{
    public AudioSource bgSound;

    void Start()
    {
        bgSound.loop = true;
        bgSound.volume = 0.33f;
        bgSound.Play();
    }
}
