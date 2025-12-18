using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    public AudioClip clip;

    public void ReplayGame()
    {
        SoundManager.instance.SFXPlay("rplayS", clip);
        SceneManager.LoadScene("1_PlayScene");
    }

    public void ToShop()
    {
        SoundManager.instance.SFXPlay("rplayS", clip);
        SceneManager.LoadScene("3_ShopScene");
    }

    public void ToMenu()
    {
        SoundManager.instance.SFXPlay("rplayS", clip);
        SceneManager.LoadScene("0_MainScene");
    }

    public void ToQuit()
    {
        SoundManager.instance.SFXPlay("rplayS", clip);
        Application.Quit();
    }
}
