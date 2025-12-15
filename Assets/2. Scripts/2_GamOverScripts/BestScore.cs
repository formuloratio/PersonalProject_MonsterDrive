using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BestScore : MonoBehaviour
{

    void Start()
    {
        GetComponent<TMP_Text>().text = User.Instance.bestScore.ToString();
    }
}
