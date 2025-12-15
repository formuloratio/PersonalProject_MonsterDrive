using System.Collections;
using System.Collections.Generic;
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
