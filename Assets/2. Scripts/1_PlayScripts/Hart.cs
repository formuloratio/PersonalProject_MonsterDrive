using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hart : MonoBehaviour
{
    public TMP_Text hartText;

    void Start()
    {
        hartText = GetComponentInChildren<TMP_Text>();
    }

    void Update()
    {
        hartText.text = User.Instance.hp.ToString();
        //coinText.text = Score.savedMoney.ToString();
    }
}
