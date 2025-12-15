using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Serialization;

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
        //coinText.text = Score.savedMoney.ToString();

    }

}
