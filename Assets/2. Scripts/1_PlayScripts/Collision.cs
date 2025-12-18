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
