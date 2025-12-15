using System.Collections;
using System.Collections.Generic;
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
