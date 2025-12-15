using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
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
