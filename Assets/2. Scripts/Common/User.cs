using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{

    public static User Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //else if (Instance != null)
        //    return;
        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {

        LoadUserData();
    }

    public int bestScore;
    public void AddBestScore(int c)
    {
        bestScore += c;
    }

    public int hp = 10;
    public void AddHp(int c)
    {
        hp += c;
    }

    public int maxHp = 10;
    public void AddMaxHp(int c)
    {
        maxHp += c;
    }


    public int coin;
    public void AddCoin(int c)
    {
        coin += c;
        Debug.Log($"코인 {coin} 저장 됐습니다");
    }

    public int goldCoin;
    public void AddGoldCoin(int c)
    {
        goldCoin += c;
    }

    public int copperCoin;
    public void AddCopperCoin(int c)
    {
        copperCoin += c;
    }

    public CarData carDT;
    public List<UserCar> userCars = new List<UserCar>();
    public void PurchasedCar(string key)
    {
        UserCar currentUserCar = GetCurrentUserCar();
        if (currentUserCar != null)
            currentUserCar.isEquipping = false;

        UserCar userCar = new UserCar();
        userCar.carKey = key;
        userCar.isOwn = true;
        userCar.isEquipping = true;
        userCars.Add(userCar);
    }

    public UserCar GetCurrentUserCar()
    {
        for (int i = 0; i < userCars.Count; i++)
        {
            if (userCars[i].isEquipping == true)
                return userCars[i];
        }
        return null;
    }

    public UserCar GetUserCar(string key)
    {
        for (int i = 0; i < userCars.Count; i++)
        {
            if (userCars[i].carKey == key)
                return userCars[i];
        }
        return null;
    }

    public void EquipCar(string key)
    {
        UserCar currentUserCar = GetCurrentUserCar();
        if (currentUserCar != null)
        {
            currentUserCar.isEquipping = false;
        }
        UserCar userCar = GetUserCar(key);
        userCar.isEquipping = true;
    }

    private void OnApplicationQuit()
    {
        ES3.Save<int>("bestScore", bestScore);
        ES3.Save<int>("hp", hp);
        ES3.Save<int>("maxHp", maxHp);
        ES3.Save<int>("coin", coin);
        ES3.Save<int>("goldCoin", goldCoin);
        ES3.Save<int>("copperCoin", copperCoin);

        // 자동차 리스트 저장
        ES3.Save<List<UserCar>>("userCars", userCars);

        Debug.Log("User 데이터 저장 완료!");
    }
    public void LoadUserData()
    {
        bestScore = ES3.Load<int>("bestScore");
        hp = ES3.Load<int>("hp");
        maxHp = ES3.Load<int>("maxHp");
        coin = ES3.Load<int>("coin");
        goldCoin = ES3.Load<int>("goldCoin");
        copperCoin = ES3.Load<int>("copperCoin");

        // 자동차 리스트 불러오기
        userCars = ES3.Load<List<UserCar>>("userCars", new List<UserCar>());

        Debug.Log("User 데이터 불러오기 완료!");
    }
}

[System.Serializable]
public class UserCar
{
    public string carKey;
    public bool isOwn;
    public bool isEquipping;
}