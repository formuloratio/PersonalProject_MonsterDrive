using UnityEngine;

public class DriveSound2 : MonoBehaviour
{
    public AudioSource bgSound2;

    public void OnEnable()
    {
        bgSound2.loop = true;
        bgSound2.volume = 0.5f;
        bgSound2.Play();
    }
}