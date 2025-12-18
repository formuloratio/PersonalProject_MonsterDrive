using UnityEngine;
using TMPro;

public class RidingScoreText : MonoBehaviour
{
    TMP_Text meterScoreText;
    public static float meterScore = 0;

    void Start()
    {
        meterScore = 0;
        meterScoreText = GetComponent<TMP_Text>(); //초기화
    }

    void Update()
    {
        meterScore += Time.deltaTime * 0.08f;
        meterScoreText.text = meterScore.ToString("f2");
    }
}
