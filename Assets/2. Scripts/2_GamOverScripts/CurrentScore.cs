using UnityEngine;
using TMPro;

public class CurrentScore : MonoBehaviour
{
    void Start()
    {
        GetComponent<TMP_Text>().text = KilledScoreText.newScore.ToString();
    }
}
