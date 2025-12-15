using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioClip clip;
    // Start is called before the first frame update
    public void BtSound()
    {
        SoundManager.instance.SFXPlay("sound", clip);
    }
}
