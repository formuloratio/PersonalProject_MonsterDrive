using System.Collections;
using System.Collections.Generic;
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
