using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;

public class Replay : MonoBehaviour
{
    public AudioClip clip;
    // private AdmobManager admobManager;

    void Start()
    {
        // admobManager = FindObjectOfType<AdmobManager>();
        // if (admobManager == null)
        // {
        //     Debug.LogError("AdmobManager not found in the scene.");
        // }
    }

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
