using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RidingScoreText : MonoBehaviour
{
    TMP_Text meterScoreText;
    public static float meterScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        meterScore = 0;
        meterScoreText = GetComponent<TMP_Text>(); //초기화
    }

    // Update is called once per frame
    void Update()
    {
        meterScore += Time.deltaTime * 0.08f;
        meterScoreText.text = meterScore.ToString("f2");
    }
}
