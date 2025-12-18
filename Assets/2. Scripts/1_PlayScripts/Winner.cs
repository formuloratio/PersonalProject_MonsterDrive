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
