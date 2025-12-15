using System.Collections;
using System.Collections.Generic;
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
