using UnityEngine;

public class Close : MonoBehaviour
{
    public AudioClip clip;

    public void OnClose()
    {
        SoundManager.instance.SFXPlay("CloseS", clip);
        gameObject.SetActive(false);
    }
}
