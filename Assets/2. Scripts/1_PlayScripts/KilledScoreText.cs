using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KilledScoreText : MonoBehaviour
{
    TMP_Text GetscoreText;
    public static int newScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        newScore = 0;
        GetscoreText = GetComponent<TMP_Text>(); //초기화
    }

    // Update is called once per frame
    void Update()
    {
        GetscoreText.text = newScore.ToString();
    }
}
