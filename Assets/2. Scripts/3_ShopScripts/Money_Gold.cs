using System.Collections;
using System.Collections.Generic;
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
