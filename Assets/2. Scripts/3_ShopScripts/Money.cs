using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public TMP_Text coinText;

    void Start()
    {
        coinText = GetComponentInChildren<TMP_Text>();
    }

    void Update()
    {
        coinText.text = User.Instance.coin.ToString();
    }
}
