using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject playButton;
    public GameObject pauseView;
    public GameObject pauseViewButton;
    public AudioClip clip;


    void Start()
    {
        
    }

    void Update()
    {

    }

    public void OnPause()
    {
        SoundManager.instance.SFXPlay("ButtonS", clip);
        pauseButton.SetActive(false);
        playButton.SetActive(true);
        pauseView.SetActive(true);
        pauseViewButton.SetActive(true);
        Time.timeScale = 0;
    }

    public void OffPause()
    {
        SoundManager.instance.SFXPlay("ButtonS", clip);
        playButton.SetActive(false);
        pauseButton.SetActive(true);
        pauseView.SetActive(false);
        pauseViewButton.SetActive(false);
        Time.timeScale = 1;
    }

    public void PReplay()
    {
        playButton.SetActive(false);
        pauseButton.SetActive(true);
        pauseView.SetActive(false);
        pauseViewButton.SetActive(false);
        Time.timeScale = 1;
        SoundManager.instance.SFXPlay("ButtonS", clip);
    }
    public void PShop()
    {
        Collision.copperCoin = KilledScoreText.newScore;
        if (KilledScoreText.newScore > User.Instance.bestScore)
        {
            int oldBestScore = User.Instance.bestScore;
            User.Instance.bestScore = KilledScoreText.newScore;
            Collision.newCoin = User.Instance.bestScore - oldBestScore;
        }
        User.Instance.AddCoin(Collision.newCoin);
        User.Instance.AddCopperCoin(Collision.copperCoin);

        playButton.SetActive(false);
        pauseButton.SetActive(true);
        pauseView.SetActive(false);
        pauseViewButton.SetActive(false);
        Time.timeScale = 1;
        SoundManager.instance.SFXPlay("ButtonS", clip);
        SceneManager.LoadScene("3_ShopScene");
    }
    public void PMenu()
    {
        Collision.copperCoin = KilledScoreText.newScore;
        if (KilledScoreText.newScore > User.Instance.bestScore)
        {
            int oldBestScore = User.Instance.bestScore;
            User.Instance.bestScore = KilledScoreText.newScore;
            Collision.newCoin = User.Instance.bestScore - oldBestScore;
        }
        User.Instance.AddCoin(Collision.newCoin);
        User.Instance.AddCopperCoin(Collision.copperCoin);

        playButton.SetActive(false);
        pauseButton.SetActive(true);
        pauseView.SetActive(false);
        pauseViewButton.SetActive(false);
        Time.timeScale = 1;
        SoundManager.instance.SFXPlay("ButtonS", clip);
        SceneManager.LoadScene("0_MainScene");
    }
    public void PGameOver()
    {
        Collision.copperCoin = KilledScoreText.newScore;
        if (KilledScoreText.newScore > User.Instance.bestScore)
        {
            int oldBestScore = User.Instance.bestScore;
            User.Instance.bestScore = KilledScoreText.newScore;
            Collision.newCoin = User.Instance.bestScore - oldBestScore;
        }
        User.Instance.AddCoin(Collision.newCoin);
        User.Instance.AddCopperCoin(Collision.copperCoin);
        
        playButton.SetActive(false);
        pauseButton.SetActive(true);
        pauseView.SetActive(false);
        pauseViewButton.SetActive(false);
        Time.timeScale = 1;
        SoundManager.instance.SFXPlay("ButtonS", clip);
        Application.Quit();
    }
}
