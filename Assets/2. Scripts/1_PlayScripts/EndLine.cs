using System.Collections;
using System.Collections.Generic;
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

    void Update()
    {

    }
}
