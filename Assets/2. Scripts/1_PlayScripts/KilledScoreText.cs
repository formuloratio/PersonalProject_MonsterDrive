using UnityEngine;
using TMPro;

public class KilledScoreText : MonoBehaviour
{
    TMP_Text GetscoreText;
    public static int newScore = 0;

    void Start()
    {
        newScore = 0;
        GetscoreText = GetComponent<TMP_Text>(); //초기화
    }

    void Update()
    {
        GetscoreText.text = newScore.ToString();
    }
}
