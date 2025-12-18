# 게임명: Monster Drive: Crash and Boom
<img width="1482" height="809" alt="스크린샷 2025-12-15 012944" src="https://github.com/user-attachments/assets/a1c5de13-24ce-47a4-85b7-f8cfea4bc20f" />

[구글 플레이 스토어 링크](https://play.google.com/store/apps/details?id=com.formuloratio.MonsterDrive&hl=ko)

## 📑 목차
1. [프로젝트 장르 및 소개](#프로젝트-장르-및-소개)
2. [주요기능](#주요기능)
3. [구현내용 및 스크립트](#구현내용-및-스크립트)
4. [트러블슈팅](#트러블슈팅)
5. [기술스택](#기술스택)
6. [사용에셋 목록](#사용에셋-목록)

---


## 프로젝트 장르 및 소개

<table>
  <tr>
    <th align="left" width="180"> 항목 </th>
    <th align="left" width="500"> 내용 </th>
  </tr>
  <tr><td> 장르 </td><td> 하이퍼 캐주얼 횡스크롤 레이스 </td></tr>
  <tr><td> 소개 </td><td> 스테이지 별로 특정 몬스터를 피하고 그 외는 충돌로 코인을 획득하면서 최종 목적지로 향해가는 하이퍼 캐주얼 게임 </td></tr>
  <tr><td> 개발 기간 </td><td> 총 59일 { 2025.08.20 ~ 2025.10.17 } </td></tr>
</table>

* 유니티 게임 개발 및 출시에 관한 학습 목적으로 한 생애 첫 개인 개발 프로젝트. 

---

## 주요기능
### 게임플레이
- 각 스테이지 별로 정해진 몬스터를 피하면서 총 5단계를 살아남으면 게임 클리어.
- 스테이지마다 회피해야 하는 몬스터와 충돌하면 HP가 깎이고, 그 외의 몬스터와 충돌하면 코인을 획득.
- 몬스터를 제거할 때마다, 다음 스테이지로 진입할 때마다, 최종 클리어를 할 때마다 각각 동화, 은화, 금화를 획득.
- 획득한 재화는 상점에서 HP 회복이나 자동차 스킨 구매에 활용.
- 동화, 은화, 금화는 환전소에서 20%의 수수료를 지불하고 상호 환전이 가능.

<img width="2078" height="885" alt="화면통합" src="https://github.com/user-attachments/assets/54ed4a6a-8cee-4fe1-bde7-b724f2cad666" />
<img width="342" height="826" alt="스크린샷 2025-12-15 020741" src="https://github.com/user-attachments/assets/4b916a5d-fee6-4524-a431-a64d8c09cbe1" />

---

## 구현내용


### 스크립트
---

* ### 메인 메뉴

  <details>
    <summary> MainMenu.cs </summary>

    ```csharp
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement; //씬 바꿀 때 필요
    
    public class MainMenu : MonoBehaviour
    {
        public AudioClip clip;
        public GameObject settingUI;
        public GameObject menuUI;
        public GameObject ruleUI;
    
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
    
    ```

  </details>

  <details>
    <summary> Close.cs </summary>

    ```csharp
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
    ```

  </details>


* ### 사운드

  <details>
    <summary> SoundManager.cs </summary>

    ```csharp
    using UnityEngine;
    
    public class SoundManager : MonoBehaviour
    {
        public AudioClip[] bglist;
        public static SoundManager instance;
    
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(instance);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    
        public void SFXPlay(string sfxName, AudioClip clip)
        {
            GameObject go = new GameObject(sfxName + "Sound");
            AudioSource audiosource = go.AddComponent<AudioSource>();
            audiosource.clip = clip; //여기까지 설정 끝남
            audiosource.Play(); //오디오 플레이 함수 호출
    
            Destroy(go, clip.length); //효과음 재생 끝나면 오브젝트 파괴
        }
    }
    
    ```

  </details>

  <details>
    <summary> BgSoundMenu.cs </summary>

    ```csharp
    using UnityEngine;
    
    public class BgSoundMenu : MonoBehaviour
    {
        public AudioSource bgSound;
        
        void Start()
        {
            bgSound.loop = true;
            bgSound.volume = 0.3f;
            bgSound.Play();
        }
    }
    ```

  </details>



* ### 해상도 조절

  <details>
    <summary> AspectRatio.cs </summary>

    ```csharp
    using UnityEngine;
    using UnityEngine.UI;
    
    public class AspectRatio : MonoBehaviour
    {
        Canvas canvas;
        CanvasScaler canvasScaler;
        private void Awake()
        {
            canvas = GetComponent<Canvas>();
            canvasScaler = canvas.GetComponent<CanvasScaler>();
    
            //기본 해상도 비율
            float fixedAspectRatio = 9f / 16f;
    
            //현재 해상도 비율
            float currentAspectRatio = (float)Screen.width / (float)Screen.height;
    
            //현재 해상도 가로 비율이 더 길 경우
            if (currentAspectRatio > fixedAspectRatio) canvasScaler.matchWidthOrHeight = 0;
            //현재 해상도의 세로 비율이 더 길 경우
            else if (currentAspectRatio < fixedAspectRatio) canvasScaler.matchWidthOrHeight = 1;
        }
    }
    
    ```

  </details>



* ### 유저 정보

  <details>
    <summary> User.cs </summary>

    ```csharp
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
    ```

  </details>

* ### 제목

  <details>
    <summary> .cs </summary>



  </details>

  <details>
    <summary> .cs </summary>



  </details>



* ### 제목

  <details>
    <summary> .cs </summary>



  </details>

  <details>
    <summary> .cs </summary>



  </details>

---

## 트러블슈팅



---

## 기술스택

<table>
  <tr>
    <th align="left" width="180"> 구분 </th>
    <th align="left" width="500"> 기술 </th>
  </tr>
  <tr>
    <td>Language</td>
    <td><img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white"></td>
  </tr>
  <tr>
    <td>Framework</td>
    <td><img src="https://img.shields.io/badge/unity-FFFFFF?style=for-the-badge&logo=unity&logoColor=black"></td>
  </tr>
  <tr>
    <td>IDE</td>
    <td><img src="https://img.shields.io/badge/Visual%20Studio-5C2D91?style=for-the-badge&logo=visualstudio&logoColor=white"></td>
  </tr>
  <tr>
    <td>Version Control</td>
    <td><img src="https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white"></td>
  </tr>
  <tr>
    <td>Distribution Platform</td>
    <td>  <img width="100" height="22" alt="구글플레이스토어" src="https://github.com/user-attachments/assets/e69f8f70-9ba7-41e2-84a3-5c8946f77ef1"> </td>
  </tr>
</table>

---

## 사용에셋 목록

<table>
  <tr>
    <th align="left" width="180"> 항목 </th>
    <th align="left" width="500"> 내용 </th>
  </tr>
  <tr><td> 자동차 효과음 </td><td> [Car Engine Sound - i6 German Free] (https://assetstore.unity.com/packages/audio/sound-fx/transportation/i6-german-free-engine-sound-pack-106037?srsltid=AfmBOopHcGX1xFTncRWssJAH710NPDsPhKaz97XG3vXm9XLLeOe_M30q) </td></tr>
  <tr><td> 배경 </td><td> [Mini Retro - 16bit action/adventure music] (https://assetstore.unity.com/packages/audio/music/mini-retro-16bit-action-adventure-music-315925?srsltid=AfmBOoqHsqErOhten5ja9nxa63NRTcqvXSrvxUyHiJYHfXPO-9vPwimA) </td></tr>
  <tr><td> 저장 </td><td> [Easy Save - The Complete Save & Load Tool for Unity] (https://assetstore.unity.com/packages/tools/utilities/easy-save-the-complete-save-game-data-serializer-system-768) </td></tr>
  <tr><td> 그 외 </td><td> AI </td></tr>
</table>
