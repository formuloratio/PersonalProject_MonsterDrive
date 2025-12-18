using UnityEngine;
using TMPro;

public class BestScore : MonoBehaviour
{
    void Start()
    {
        GetComponent<TMP_Text>().text = User.Instance.bestScore.ToString();
    }
}
