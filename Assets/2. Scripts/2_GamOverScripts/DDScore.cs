using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DDScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMP_Text>().text = RidingScoreText.meterScore.ToString("f2") + " km";
        
    }

}
