# 게임명: Monster Drive: Crash and Boom
<img width="1482" height="809" alt="스크린샷 2025-12-15 012944" src="https://github.com/user-attachments/assets/a1c5de13-24ce-47a4-85b7-f8cfea4bc20f" />

[구글 플레이 스토어 링크](https://play.google.com/store/apps/details?id=com.formuloratio.MonsterDrive&hl=ko)

## 📑 목차
1. [프로젝트 장르 및 소개](#프로젝트-장르-및-소개)
2. [주요기능](#주요기능)
3. [구현내용 및 스크립트](#구현내용-및-스크립트)
4. [기술스택](#기술스택)
5. [사용에셋 목록](#사용에셋-목록)

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

* 유니티 게임 개발 및 출시에 관한 학습 목적으로 한, 생애 첫 개인 개발 프로젝트.

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

## 구현내용 및 스크립트
<img width="2648" height="1235" alt="UML_N" src="https://github.com/user-attachments/assets/4992e2be-4234-4763-ac59-d72b65510b7f" />


### 스크립트
---

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


* ### 메인 메뉴 씬

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


* ### 게임 플레이 씬

  <details>
    <summary> Car.cs </summary>

    ```csharp
    using UnityEngine;
    
    public class Car : MonoBehaviour
    {
        //Car 컴퍼넌트에 차 데이터 담을 공간
        public CarData carData;
    }
    ```

  </details>

  <details>
    <summary> Collision.cs </summary>

    ```csharp
    using System.Collections;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    
    public class Collision : MonoBehaviour
    {
        public AudioClip clip;
        public static int newCoin = 0;
        public static int copperCoin = 0;
    
        void GameOver()
        {
            newCoin = 0;
            copperCoin = KilledScoreText.newScore;
            if (KilledScoreText.newScore > User.Instance.bestScore)
            {
                int oldBestScore = User.Instance.bestScore;
                User.Instance.bestScore = KilledScoreText.newScore;
                newCoin = User.Instance.bestScore - oldBestScore;
            }
            User.Instance.AddCoin(newCoin); // 유저-코인 함수에 현재의 Score.numOfMonsterKilled 수 만큼 추가
            User.Instance.AddCopperCoin(copperCoin);
            if (User.Instance.hp < 1)
            {
                User.Instance.hp = 1;
            }
            SceneManager.LoadScene("2_GameOverScene");
        }
    
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Car")
            {
                if (User.Instance.hp > 1)
                {
                    SoundManager.instance.SFXPlay("Boom_End", clip);
                    User.Instance.AddHp(-1);
                }
                else if (User.Instance.hp == 1)
                {
                    User.Instance.AddHp(-1);
                    StartCoroutine("DestroyAnimation");
                }
            }
        }
    
        private IEnumerator DestroyAnimation()
        {
            SoundManager.instance.SFXPlay("Boom_End", clip); // 사운드 넣기 코드 02
            Time.timeScale = 0f;
            yield return new WaitForSecondsRealtime(0.3f); //시간 멈춘 후에도 동작
            GameOver();
            Time.timeScale = 1f;
        }
    }
    ```

  </details>

  <details>
    <summary> Destroy.cs </summary>

    ```csharp
    using UnityEngine;
    
    public class Destroy : MonoBehaviour
    {
        [SerializeField] Animator animator;
    
        public AudioClip clip; // 사운드 넣기 코드 02
    
        void Start()
        {
            animator = GetComponent<Animator>(); //현재 게임 오브젝트에 있는 애니메이터 컴포넌트를 반환하는 함수
        }
    
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Car")
            {
                animator.SetBool("Change", true);
                SoundManager.instance.SFXPlay("Boom", clip); // 사운드 넣기 코드 02
                Destroy(gameObject, 0.2f);
                //Score.Instance.AddKilledMonster(1); // 유저-코인 함수에 현재의 Score.savedMoney 수 만큼 추가
                KilledScoreText.newScore += 1;
            }
        }
    }
    ```

  </details>

  <details>
    <summary> Driver.cs </summary>

    ```csharp
    using UnityEngine;
    
    public class Driver : MonoBehaviour
    {
        public LayerMask wallLayer; // 벽 레이어 지정
    
        public bool leftClick = false;
        public bool rightClick = false;
        public float horizontalAmount = 0;
        public static float moveSpeed = 6;
        public static float horizontalSpeed = 7;
        public GameObject clip1;
        public GameObject clip2;
    
        public FloatingJoystick joystick;
    
        void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position = transform.position + new Vector3(1, 0, 0) * -horizontalSpeed * Time.deltaTime;
            }
    
            if (Input.GetKey(KeyCode.D))
            {
                transform.position = transform.position + new Vector3(1, 0, 0) * horizontalSpeed * Time.deltaTime;
            }
        }
    }
    ```

  </details>

  <details>
    <summary> DriveSound1.cs </summary>

    ```csharp
    using UnityEngine;
    
    public class DriveSound1 : MonoBehaviour
    {
        public AudioSource bgSound1;
        
        public void OnEnable() // 오브젝트 활성화 마다 호출되는 함수
        {
            bgSound1.loop = true;
            bgSound1.volume = 0.2f;
            bgSound1.Play();
        }
    }
    ```

  </details>

  <details>
    <summary> DriveSound2.cs </summary>

    ```csharp
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
    ```

  </details>

  <details>
    <summary> EndLine.cs </summary>

    ```csharp
    using UnityEngine;
    
    public class EndLine : MonoBehaviour
    {
        public GameObject roadEnd;
    
        void Start()
        {
            OnEnable();
        }
    
        void OnEnable()
        {
            Invoke("ObjectStart", 60f); //나중에 60초로 맞추기 라인이 지나갈 타이밍
        }
    
        void ObjectStart()
        {
            roadEnd.SetActive(true);
            Invoke("ObjectEnd", 4f); //3.5초뒤 라인 비활성화
        }
    
        void ObjectEnd()
        {
            roadEnd.SetActive(false);
        }
    }
    
    ```

  </details>

  <details>
    <summary> EndLine_Collision.cs </summary>

    ```csharp
    using UnityEngine;
    
    public class EndLine_Collision : MonoBehaviour
    {
        public AudioClip clip;
    
        public GameObject nextRoad;
        public GameObject nextMonster;
        public GameObject nextSound;
        public GameObject nextDgMonsterInf;
        public GameObject thisRoad;
        public GameObject thisMonster;
        public GameObject thisSound;
        public GameObject thisDgMonsterInf;
    
        public GameObject thisMonster1;
        public GameObject thisMonster2;
        public GameObject thisMonster3;
        public GameObject thisMonster4;
        public GameObject thisMonster5;
        public GameObject thisMonster6;
        public GameObject thisMonster7;
        public GameObject thisMonster8;
        public GameObject nextMonster1;
        public GameObject nestMonster2;
    
        void OnEnable()
        {
            thisMonster1.SetActive(false);
            thisMonster2.SetActive(false);
            thisMonster3.SetActive(false);
            thisMonster4.SetActive(false);
            thisMonster5.SetActive(false);
            thisMonster6.SetActive(false);
            thisMonster7.SetActive(false);
            thisMonster8.SetActive(false);
            nextMonster1.SetActive(false);
            nestMonster2.SetActive(false);
        }
    
        void OnDisable()
        {
            thisMonster1.SetActive(true);
            thisMonster2.SetActive(true);
            thisMonster3.SetActive(true);
            thisMonster4.SetActive(true);
            thisMonster5.SetActive(true);
            thisMonster6.SetActive(true);
            thisMonster7.SetActive(true);
            thisMonster8.SetActive(true);
            nextMonster1.SetActive(true);
            nestMonster2.SetActive(true);
        }
    
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Car")
            {
                SoundManager.instance.SFXPlay("sound", clip);
                Invoke("OnNext", 0.3f);
                User.Instance.AddHp(1);
            }
        }
    
        public void OnNext()
        {
            nextRoad.SetActive(true);
            nextMonster.SetActive(true);
            nextSound.SetActive(true);
            nextDgMonsterInf.SetActive(true);
    
            thisRoad.SetActive(false);
            thisMonster.SetActive(false);
            thisSound.SetActive(false);
            thisDgMonsterInf.SetActive(false);
        }
    }
    ```

  </details>

  <details>
    <summary> FollowCamera.cs </summary>

    ```csharp
    using UnityEngine;
    
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] GameObject thingToFollow;
    
        void LateUpdate()
        {
            transform.position = thingToFollow.transform.position + new Vector3(0, 0, -10);
            transform.rotation = thingToFollow.transform.rotation;
        }
    }
    ```

  </details>

  <details>
    <summary> Hart.cs </summary>

    ```csharp
    using UnityEngine;
    using TMPro;
    
    public class Hart : MonoBehaviour
    {
        public TMP_Text hartText;
    
        void Start()
        {
            hartText = GetComponentInChildren<TMP_Text>();
        }
    
        void Update()
        {
            hartText.text = User.Instance.hp.ToString();
        }
    }
    ```

  </details>

  <details>
    <summary> KilledScoreText.cs </summary>

    ```csharp
    using UnityEngine;
    using TMPro;
    
    public class KilledScoreText : MonoBehaviour
    {
        TMP_Text GetscoreText;
        public static int newScore = 0;
    
        void Start()
        {
            newScore = 0;
            GetscoreText = GetComponent<TMP_Text>(); //초기화
        }
    
        void Update()
        {
            GetscoreText.text = newScore.ToString();
        }
    }
    ```

  </details>

  <details>
    <summary> Monster.cs </summary>

    ```csharp
    using UnityEngine;
    
    public class Monster : MonoBehaviour
    {
        private Vector2 min = new Vector2(-8f, -10f);
        private Vector2 max = new Vector2(8f, 30f);
    
        void Awake()
        {
            Application.targetFrameRate = 60;
        }
    
        void Update()
        {
            float moveAmount = -10 * Time.deltaTime;
            transform.Translate(0, moveAmount, 0);
    
            if (transform.position.x < min.x || transform.position.x > max.x ||
                transform.position.y < min.y || transform.position.y > max.y)
            {
                Destroy(gameObject);
            }
        }
    }
    ```

  </details>

  <details>
    <summary> MonsterSpawner.cs </summary>

    ```csharp
    using UnityEngine;
    
    public class MonsterSpawner : MonoBehaviour
    {
        public GameObject monsterPrefab;
        // Start is called before the first frame update
        void Start()
        {
            Invoke("Spawn", Random.Range(2f, 5f)); //"호출할 함수", 몇초후에 생성할지
        }
    
        void Spawn()
        {
            GameObject mon = Instantiate(monsterPrefab);
            mon.transform.position = transform.position;
            Invoke("Spawn", Random.Range(0.3f, 10f));
        }
    
        void Update()
        {
            OnDisable();
            OnEnable();
        }
    
        void OnDisable()
        {
            monsterPrefab.SetActive(false);
        }
        void OnEnable()
        {
            monsterPrefab.SetActive(true);
        }
    }
    ```

  </details>

  <details>
    <summary> Move.cs </summary>

    ```csharp
    using UnityEngine;
    
    public class Move : MonoBehaviour
    {
        public Transform Player;
        public bool leftClick = false;
        public bool rightClick = false;
        public static float moveSpeed = 6;
        public static float horizontalSpeed = 8;
    
        void Update()
        {
            if (leftClick)
            {
                Player.position += Vector3.left * horizontalSpeed * Time.deltaTime;
            }
            if (rightClick)
            {
                Player.position += Vector3.right * horizontalSpeed * Time.deltaTime;
            }
        }
    
        public void LftUp()
        {
            leftClick = false;
        }
        public void LftDown()
        {
            leftClick = true;
        }
        public void RitUp()
        {
            rightClick = false;
        }
        public void RitDown()
        {
            rightClick = true;
        }
    }
    ```

  </details>

  <details>
    <summary> Player.cs </summary>

    ```csharp
    using UnityEngine;
    
    public class Player : MonoBehaviour
    {
        public static Player Instance;
        [SerializeField] Car[] cars;
        [SerializeField] Car currentCar;
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }
    
        private void Start()
        {
            cars = GetComponentsInChildren<Car>();
    
            UserCar currentUserCar = User.Instance.GetCurrentUserCar();
    
            if (currentUserCar == null)
            { // 기본 장비 장착 (car0)
                currentCar = GetCar("car0");
            }
            else
            { // 해당되는 장비 장착
                currentCar = GetCar(currentUserCar.carKey);
            }
            for (int i = 0; i < cars.Length; i++)
            { //일단 장비 비활성화
                cars[i].gameObject.SetActive(false);
            }
            //장착해야될 장비만 활성화
            currentCar.gameObject.SetActive(true);
        }
    
        Car GetCar(string key)
        {
            for (int i = 0; i < cars.Length; i++)
            {
                if (cars[i].carData.carKey == key)
                    return cars[i];
            }
            return null;
        }
    }
    ```

  </details>

  <details>
    <summary> Winner.cs </summary>

    ```csharp
    using UnityEngine;
    using UnityEngine.SceneManagement;
    
    public class Winner : MonoBehaviour
    {
        public AudioClip clip;
        public AudioClip clipBT;
        public GameObject winWindow;
    
        void OnEnable()
        {
            SoundManager.instance.SFXPlay("ENDsound", clip);
            User.Instance.AddGoldCoin(1); // 1회 경주 완료시 1금화 획득
        }
    
        public void OnClickEnd()
        {
            SoundManager.instance.SFXPlay("BTsound", clipBT);
            GameOver();
            Time.timeScale = 1;
        }
    
        public void OnClickReplay()
        {
            SoundManager.instance.SFXPlay("BTsound", clipBT);
            Time.timeScale = 1;
            winWindow.SetActive(false);
        }
    
        void GameOver()
        {
            Collision.copperCoin = KilledScoreText.newScore;
            if (KilledScoreText.newScore > User.Instance.bestScore)
            {
                int oldBestScore = User.Instance.bestScore;
                User.Instance.bestScore = KilledScoreText.newScore;
                Collision.newCoin = User.Instance.bestScore - oldBestScore;
            }
            User.Instance.AddCoin(Collision.newCoin); // 유저-코인 함수에 현재의 Score.numOfMonsterKilled 수 만큼 추가
            User.Instance.AddCopperCoin(Collision.copperCoin);
            
            if (User.Instance.hp < 1)
            {
                User.Instance.hp = 1;
            }
            SceneManager.LoadScene("2_GameOverScene");
        }
    }
    ```

  </details>

  <details>
    <summary> MSpEable.cs </summary>

    ```csharp
    using UnityEngine;
    
    public class MSpEable : MonoBehaviour
    {
        public GameObject eableR;
        public GameObject thisMonster1;
        public GameObject thisMonster2;
        public GameObject nextMonster1;
        public GameObject nestMonster2;
    
        void Update()
        {
            if (eableR == true)
            {
                thisMonster1.SetActive(false);
                thisMonster2.SetActive(false);
                nextMonster1.SetActive(false);
                nestMonster2.SetActive(false);
            }
            else
            {
                thisMonster1.SetActive(true);
                thisMonster2.SetActive(true);
                nextMonster1.SetActive(true);
                nestMonster2.SetActive(true);
            }
        }
    }
    ```

  </details>

  <details>
    <summary> Pause.cs </summary>

    ```csharp
    using UnityEngine;
    using UnityEngine.SceneManagement;
    
    public class Pause : MonoBehaviour
    {
        public GameObject pauseButton;
        public GameObject playButton;
        public GameObject pauseView;
        public GameObject pauseViewButton;
        public AudioClip clip;
    
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
    ```

  </details>

  <details>
    <summary> RidingScoreText.cs </summary>

    ```csharp
    using UnityEngine;
    using TMPro;
    
    public class RidingScoreText : MonoBehaviour
    {
        TMP_Text meterScoreText;
        public static float meterScore = 0;
    
        void Start()
        {
            meterScore = 0;
            meterScoreText = GetComponent<TMP_Text>(); //초기화
        }
    
        void Update()
        {
            meterScore += Time.deltaTime * 0.08f;
            meterScoreText.text = meterScore.ToString("f2");
        }
    }
    ```

  </details>

  <details>
    <summary> WinOne.cs </summary>

    ```csharp
    using UnityEngine;
    
    public class WinOne : MonoBehaviour
    {
        public GameObject WinView;
    
        void Start()
        {
            Invoke("WinViews", 3f);
        }
    
        private void WinViews()
        {
            Time.timeScale = 0;
            WinView.SetActive(true);
        }
    }
    ```

  </details>


* ### 게임 오버 씬

  <details>
    <summary> Replay.cs </summary>

    ```csharp
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
    ```

  </details>

  <details>
    <summary> DDScore.cs </summary>

    ```csharp
    using UnityEngine;
    using TMPro;
    
    public class DDScore : MonoBehaviour
    {
        void Start()
        {
            GetComponent<TMP_Text>().text = RidingScoreText.meterScore.ToString("f2") + " km";
        }
    }
    ```

  </details>

  <details>
    <summary> CurrentScore.cs </summary>

    ```csharp
    using UnityEngine;
    using TMPro;
    
    public class CurrentScore : MonoBehaviour
    {
        void Start()
        {
            GetComponent<TMP_Text>().text = KilledScoreText.newScore.ToString();
        }
    }
    ```

  </details>

  <details>
    <summary> BestScore.cs </summary>

    ```csharp
    using UnityEngine;
    using TMPro;
    
    public class BestScore : MonoBehaviour
    {
        void Start()
        {
            GetComponent<TMP_Text>().text = User.Instance.bestScore.ToString();
        }
    }
    ```

  </details>


* ### 상점 씬

  <details>
    <summary> BgSoundShop.cs </summary>

    ```csharp
    using UnityEngine;
    
    public class BgSoundShop : MonoBehaviour
    {
        public AudioSource bgSound;
    
        void Start()
        {
            bgSound.loop = true;
            bgSound.volume = 0.33f;
            bgSound.Play();
        }
    }
    ```

  </details>

  <details>
    <summary> ButtonSound.cs </summary>

    ```csharp
    using UnityEngine;
    
    public class ButtonSound : MonoBehaviour
    {
        public AudioClip clip;
    
        public void BtSound()
        {
            SoundManager.instance.SFXPlay("sound", clip);
        }
    }
    ```

  </details>

  <details>
    <summary> BuyWindow2.cs </summary>

    ```csharp
    using UnityEngine;
    using TMPro;
    
    public class BuyWindow2 : MonoBehaviour
    {
        private Animator animator;
        public TMP_Text priceText;
        public int price = 10;
    
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
    
        public void ButtonClose()
        {
            if (User.Instance.coin >= price)
            {
                User.Instance.coin = User.Instance.coin - price;
                animator.SetTrigger("close");
                gameObject.SetActive(false);
                animator.ResetTrigger("close");
            }
        }
    }
    ```

  </details>

  <details>
    <summary> CarProducts.cs </summary>

    ```csharp
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    
    public class CarProducts : MonoBehaviour
    {
        public CarData carData;
        public Image thumImage;
        public TMP_Text priceText;
        public Image stateIM;
        public Image stateBT;
    
        public GameObject purchaseButton;
        public GameObject equipButton;
        public TMP_Text equipStateText;
        
        public AudioClip clipP;
        public AudioClip clipE;
    
        public AudioClip nonePurchaseClip;
    
        private void Start()
        {
            priceText.text = carData.price.ToString();
    
            UserCar userCar = User.Instance.GetUserCar(carData.carKey);
            if (userCar.isOwn == true) // 소유하면 흰색으로 비소유면 회색
            {
                stateIM.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
                stateBT.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
            }
            else
            {
                stateIM.GetComponent<Image>().color = new Color(155 / 255f, 155 / 255f, 155 / 255f);
                stateBT.GetComponent<Image>().color = new Color(155 / 255f, 155 / 255f, 155 / 255f);
            }
    
            UpdatePanel(); //다른 씬에서 돌아왔을 때 UI 갱신
    
        }
    
        public void UpdatePanel() // 이 함수 호출 시 CarProductPanel UI 갱신
        {
            UserCar userCar = User.Instance.GetUserCar(carData.carKey); //패널에 보여지는 차 구매했는지 장착중인지 알기 위해 현재 패널에서 보여지고 있는 무기에 대한 유저카 객체를 반환 받음
    
            if (userCar != null && userCar.isOwn) // 구매한 무기인지 판별
            {
                equipButton.SetActive(true);
                if (userCar.isEquipping) // 탑승하고 있으면 탑승중 출력
                {
                    equipStateText.text = "on board";
                }
                else // 탑승 안하고 있으면 탑승하기 출력
                {
                    equipStateText.text = "get in";
                }
            }
            else
            {
                equipButton.SetActive(false);
            }
        }
    
        public void OnClickedPurchase()
        {
            if (User.Instance.coin >= carData.price)
            {
                SoundManager.instance.SFXPlay("buyS", clipP);
                User.Instance.coin = User.Instance.coin - carData.price;
                User.Instance.PurchasedCar(carData.carKey);
    
                UserCar userCar = User.Instance.GetUserCar(carData.carKey);
                if (userCar.isOwn == true) // 소유하면 흰색으로 비소유면 회색
                {
                    stateIM.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
                    stateBT.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
                }
                else
                {
                    stateIM.GetComponent<Image>().color = new Color(155 / 255f, 155 / 255f, 155 / 255f);
                    stateBT.GetComponent<Image>().color = new Color(155 / 255f, 155 / 255f, 155 / 255f);
                }
    
                purchaseButton.SetActive(false);
            }
            else
            {
                SoundManager.instance.SFXPlay("sound", nonePurchaseClip);
            }
    
            //UpdatePanel();
    
            GetComponentInParent<CarShopCanvas>().UpdateCanvas();
        }
    
        public void OnClickedEquip()
        {
            SoundManager.instance.SFXPlay("equipS", clipE);
            User.Instance.EquipCar(carData.carKey);
            GetComponentInParent<CarShopCanvas>().UpdateCanvas();
        }
    }
    ```

  </details>

  <details>
    <summary> CarProductsFirst.cs </summary>

    ```csharp
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    
    public class CarProductsFirst : MonoBehaviour
    {
        public GameObject carNone1Scroll;
        public GameObject carNone2Image;
    
        public CarData carData;
        public Image thumImage;
        public TMP_Text priceText;
        public Image stateIM;
        public Image stateBT;
    
        public GameObject purchaseButton;
        public GameObject equipButton;
        public TMP_Text equipStateText;
        
        public AudioClip clipP;
        public AudioClip clipE;
    
        public AudioClip nonePurchaseClip;
    
        private void Start()
        {
            UpdatePanel(); //다른 씬에서 돌아왔을 때 UI 갱신
        }
    
        public void UpdatePanel() // 이 함수 호출 시 CarProductPanel UI 갱신
        {
            UserCar userCar = User.Instance.GetUserCar(carData.carKey); //패널에 보여지는 차 구매했는지 장착중인지 알기 위해 현재 패널에서 보여지고 있는 무기에 대한 유저카 객체를 반환 받음
    
            if (userCar != null && userCar.isOwn) // 구매한 무기인지 판별
            {
                carNone1Scroll.GetComponent<ScrollRect>().enabled = true;
                carNone2Image.SetActive(false);
            }
        }
    
        public void OnClickedPurchase()
        {
            if (User.Instance.goldCoin >= carData.price)
            {
                User.Instance.maxHp += 10;
                User.Instance.hp += 10;
    
                carNone1Scroll.GetComponent<ScrollRect>().enabled = true; //carNone1 오브젝트에 있는 스크롤 기능 활성화
                carNone2Image.SetActive(false);
                GetComponentInParent<CarShopCanvas>().UpdateCanvas();
    
                SoundManager.instance.SFXPlay("buyS", clipP);
                User.Instance.goldCoin = User.Instance.goldCoin - carData.price;
                User.Instance.PurchasedCar(carData.carKey);
    
                UserCar userCar = User.Instance.GetUserCar(carData.carKey);
                if (userCar.isOwn == true) // 소유하면 흰색으로 비소유면 회색
                {
                    stateIM.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
                    stateBT.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
                }
                else
                {
                    stateIM.GetComponent<Image>().color = new Color(155 / 255f, 155 / 255f, 155 / 255f);
                    stateBT.GetComponent<Image>().color = new Color(155 / 255f, 155 / 255f, 155 / 255f);
                }
    
                purchaseButton.SetActive(false);
            }
            else
            {
                SoundManager.instance.SFXPlay("sound", nonePurchaseClip);
            }
    
            GetComponentInParent<CarShopCanvas>().UpdateCanvas();
        }
    }
    
    ```

  </details>

  <details>
    <summary> CarShopCanvas.cs </summary>

    ```csharp
    using UnityEngine;
    
    public class CarShopCanvas : MonoBehaviour
    {
        public CarProducts[] carProducts;
    
        void Start()
        {
            carProducts = GetComponentsInChildren<CarProducts>();
        }
    
        public void UpdateCanvas() //호출 시 canvas 하위의 ui 갱신
        {
            for (int i = 0; i < carProducts.Length; i++)
            {
                carProducts[i].UpdatePanel();
            }
        }
    }
    ```

  </details>

  <details>
    <summary> HPBuy.cs </summary>

    ```csharp
    using UnityEngine;
    using TMPro;
    using UnityEngine.UI;
    
    public class HPBuy : MonoBehaviour
    {
        public Button hpPriceButton;
        public TMP_Text hpText;
        public AudioClip clipP;
        public AudioClip nonePurchaseClip;
    
        void Start()
        {
            hpText = GetComponentInChildren<TMP_Text>();
        }
    
        void Update()
        {
            hpText.text = User.Instance.hp.ToString();
        }
    
        public void OnClickPurchaseHP()
        {
            if (User.Instance.copperCoin >= 50 && User.Instance.hp < User.Instance.maxHp)
            {
                SoundManager.instance.SFXPlay("buyS", clipP);
                User.Instance.AddCopperCoin(-50);
                User.Instance.AddHp(1);
            }
            else
            {
                SoundManager.instance.SFXPlay("sound", nonePurchaseClip);
            }
        }
    }
    ```

  </details>

  <details>
    <summary> LackWindow.cs </summary>

    ```csharp
    using UnityEngine;
    
    public class LackWindow : MonoBehaviour
    {
        public CarData carData;
        private Animator animator;
    
        private void Awake()
        {
            GetComponentInParent<CarShopCanvas>().UpdateCanvas();
            animator = GetComponent<Animator>();
        }
    
        public void Start()
        {
            if (User.Instance.coin < carData.price)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    
        public void ButtonClose()
        {
            animator.SetTrigger("close");
            gameObject.SetActive(false);
            animator.ResetTrigger("close");
        }
    }
    ```

  </details>

  <details>
    <summary> Money.cs </summary>

    ```csharp
    using UnityEngine;
    using TMPro;
    
    public class Money : MonoBehaviour
    {
        public TMP_Text coinText;
    
        void Start()
        {
            coinText = GetComponentInChildren<TMP_Text>();
        }
    
        void Update()
        {
            coinText.text = User.Instance.coin.ToString();
        }
    }
    ```

  </details>

  <details>
    <summary> Money_Copper.cs </summary>

    ```csharp
    using UnityEngine;
    using TMPro;
    
    public class Money_Copper : MonoBehaviour
    {
        public TMP_Text copperCoinText;
    
        void Start()
        {
            copperCoinText = GetComponentInChildren<TMP_Text>();
        }
    
        void Update()
        {
            copperCoinText.text = User.Instance.copperCoin.ToString();
        }
    }
    ```

  </details>

  <details>
    <summary> Money_Gold.cs </summary>

    ```csharp
    using UnityEngine;
    using TMPro;
    
    public class Money_Gold : MonoBehaviour
    {
        public TMP_Text goldCoinText;
    
        void Start()
        {
            goldCoinText = GetComponentInChildren<TMP_Text>();
        }
    
        void Update()
        {
            goldCoinText.text = User.Instance.goldCoin.ToString();
        }
    }
    ```

  </details>

  <details>
    <summary> StateEquip.cs </summary>

    ```csharp
    using UnityEngine;
    using UnityEngine.UI;
    
    public class StateEquip : MonoBehaviour
    {
        public string carKey;
    
        void Update()
        {
            UserCar userCar = User.Instance.GetUserCar(carKey);
            if (userCar.isEquipping == true) // 장착하면 회색으로 비장착시 흰색으로
            {
                GetComponent<Image>().color = new Color(150 / 255f, 150 / 255f, 150 / 255f);
            }
            else
            {
                GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
            }
        }
    }
    ```

  </details>

  <details>
    <summary> TabButton.cs </summary>

    ```csharp
    using UnityEngine;
    using UnityEngine.UI;
    
    public class TabButton : MonoBehaviour
    {
        Image background;
        public Sprite defaultImg;
        public Sprite selectedImg;
    
        private void Awake()
        {
            background = GetComponent<Image>();
        }
    
        public void Selected()
        {
            background.sprite = selectedImg;
        }
    
        public void DeSelected()
        {
            background.sprite = defaultImg;
        }
    }//버튼 누르고 떼기에 따른 이미지 변경
    ```

  </details>

  <details>
    <summary> TabPanel.cs </summary>

    ```csharp
    using System.Collections.Generic;
    using UnityEngine;
    
    public class TabPanel : MonoBehaviour
    {
        public AudioClip clip;
        public List<TabButton> tabButtons;
        public List<GameObject> contentsPanels;
        int selected = 0;
    
        private void Start()
        {
            ClickTab(selected);
            SoundManager.instance.SFXPlay("sound", clip);
        }
    
        public void ClickTab(int id)
        {
            for (int i = 0; i < contentsPanels.Count; i++)
            {
                if (i == id)
                {
                    contentsPanels[i].SetActive(true);
                    tabButtons[i].Selected();
                }
                else
                {
                    contentsPanels[i].SetActive(false);
                    tabButtons[i].DeSelected();
                }
            }
        }
    }//패널 선택(버튼 클릭)에 따라 패널 보여주기
    ```

  </details>

  <details>
    <summary> Trade.cs </summary>

    ```csharp
    using UnityEngine;
    
    public class Trade : MonoBehaviour
    {
        public AudioClip purchaseClip;
        public AudioClip nonePurchaseClip;
    
        public void GoldPurchase()
        {
            if (User.Instance.coin >= 120)
            {
                SoundManager.instance.SFXPlay("sound", purchaseClip);
                User.Instance.goldCoin += 1;
                User.Instance.coin -= 120;
            }
            else
            {
                SoundManager.instance.SFXPlay("sound", nonePurchaseClip);
            }
        }
    
        public void GoldToSilverPurchase()
        {
            if (User.Instance.goldCoin >= 1)
            {
                SoundManager.instance.SFXPlay("sound", purchaseClip);
                User.Instance.goldCoin -= 1;
                User.Instance.coin += 80;
            }
            else
            {
                SoundManager.instance.SFXPlay("sound", nonePurchaseClip);
            }
        }
    
        public void CopperToSilverPurchase()
        {
            if (User.Instance.copperCoin >= 120)
            {
                SoundManager.instance.SFXPlay("sound", purchaseClip);
                User.Instance.coin += 1;
                User.Instance.copperCoin -= 120;
            }
            else
            {
                SoundManager.instance.SFXPlay("sound", nonePurchaseClip);
            }
        }
    
        public void CopperPurchase()
        {
            if (User.Instance.coin >= 1)
            {
                SoundManager.instance.SFXPlay("sound", purchaseClip);
                User.Instance.coin -= 1;
                User.Instance.copperCoin += 80;
            }
            else
            {
                SoundManager.instance.SFXPlay("sound", nonePurchaseClip);
            }
        }
    }
    ```

  </details>

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
