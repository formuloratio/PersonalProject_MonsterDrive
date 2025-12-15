using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //씬 바꿀 때 필요

public class MainMenu : MonoBehaviour
{
    public AudioClip clip;
    public GameObject settingUI;
    public GameObject menuUI;
    public GameObject ruleUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void OnClickNewGame()
    {
        SoundManager.instance.SFXPlay("ButtonS", clip);
        Debug.Log("새로하기");
        SceneManager.LoadScene("1_PlayScene"); //""안에 씬 이름 넣으면 로드 됨

        SoundManager.instance.SFXPlay("ButtonS", clip);
        ES3.Save<int>("bestScore", User.Instance.bestScore);
        ES3.Save<int>("hp", User.Instance.hp);
        ES3.Save<int>("maxHp", User.Instance.maxHp);
        ES3.Save<int>("coin", User.Instance.coin);
        ES3.Save<int>("goldCoin", User.Instance.goldCoin);
        ES3.Save<int>("copperCoin", User.Instance.copperCoin);

        // 자동차 리스트 저장
        ES3.Save<List<UserCar>>("userCars", User.Instance.userCars);

        Debug.Log("User 데이터 저장 완료!");
    }

    public void OnClickShop()
    {
        SoundManager.instance.SFXPlay("ButtonS", clip);
        Debug.Log("상점");
        SceneManager.LoadScene("3_ShopScene");

        SoundManager.instance.SFXPlay("ButtonS", clip);
        ES3.Save<int>("bestScore", User.Instance.bestScore);
        ES3.Save<int>("hp", User.Instance.hp);
        ES3.Save<int>("maxHp", User.Instance.maxHp);
        ES3.Save<int>("coin", User.Instance.coin);
        ES3.Save<int>("goldCoin", User.Instance.goldCoin);
        ES3.Save<int>("copperCoin", User.Instance.copperCoin);

        // 자동차 리스트 저장
        ES3.Save<List<UserCar>>("userCars", User.Instance.userCars);

        Debug.Log("User 데이터 저장 완료!");
    }

    public void OnClickRule()
    {
        SoundManager.instance.SFXPlay("ButtonS", clip);
        ruleUI.SetActive(true);
    }

    public void OnClickOption()
    {
        SoundManager.instance.SFXPlay("ButtonS", clip);
        Debug.Log("옵션");
        settingUI.SetActive(true);

        SoundManager.instance.SFXPlay("ButtonS", clip);
        ES3.Save<int>("bestScore", User.Instance.bestScore);
        ES3.Save<int>("hp", User.Instance.hp);
        ES3.Save<int>("maxHp", User.Instance.maxHp);
        ES3.Save<int>("coin", User.Instance.coin);
        ES3.Save<int>("goldCoin", User.Instance.goldCoin);
        ES3.Save<int>("copperCoin", User.Instance.copperCoin);

        // 자동차 리스트 저장
        ES3.Save<List<UserCar>>("userCars", User.Instance.userCars);

        Debug.Log("User 데이터 저장 완료!");
    }

    public void OnClickRanking()
    {
        SoundManager.instance.SFXPlay("ButtonS", clip);
        Debug.Log("랭킹");
    }

    public void OnClickMenu()
    {
        SoundManager.instance.SFXPlay("ButtonS", clip);
        Debug.Log("메뉴");
        menuUI.SetActive(true);

        SoundManager.instance.SFXPlay("ButtonS", clip);
        ES3.Save<int>("bestScore", User.Instance.bestScore);
        ES3.Save<int>("hp", User.Instance.hp);
        ES3.Save<int>("maxHp", User.Instance.maxHp);
        ES3.Save<int>("coin", User.Instance.coin);
        ES3.Save<int>("goldCoin", User.Instance.goldCoin);
        ES3.Save<int>("copperCoin", User.Instance.copperCoin);

        // 자동차 리스트 저장
        ES3.Save<List<UserCar>>("userCars", User.Instance.userCars);

        Debug.Log("User 데이터 저장 완료!");
    }



    public void OnClickLoad()
    {
        SoundManager.instance.SFXPlay("ButtonS", clip);
        Debug.Log("불러오기");
    }

    public void OnClickQuit()
    {
        SoundManager.instance.SFXPlay("ButtonS", clip);
        ES3.Save<int>("bestScore", User.Instance.bestScore);
        ES3.Save<int>("hp", User.Instance.hp);
        ES3.Save<int>("maxHp", User.Instance.maxHp);
        ES3.Save<int>("coin", User.Instance.coin);
        ES3.Save<int>("goldCoin", User.Instance.goldCoin);
        ES3.Save<int>("copperCoin", User.Instance.copperCoin);

        // 자동차 리스트 저장
        ES3.Save<List<UserCar>>("userCars", User.Instance.userCars);

        Debug.Log("User 데이터 저장 완료!");
//#if UNITY_EDITOR
//        UnityEditor.EditorApplication.isPlaying = false;
//#else
        Application.Quit(); //유니티에선 실행안됨. 그래서 추가 코드 필요.
//#endif
    }
    
}
