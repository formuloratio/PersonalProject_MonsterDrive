using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioClip clip;

    public void BtSound()
    {
        SoundManager.instance.SFXPlay("sound", clip);
    }
}