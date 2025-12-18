using UnityEngine;
using TMPro;

public class DDScore : MonoBehaviour
{
    void Start()
    {
        GetComponent<TMP_Text>().text = RidingScoreText.meterScore.ToString("f2") + " km";
    }
}
