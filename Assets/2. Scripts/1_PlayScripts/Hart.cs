using UnityEngine;
using TMPro;

public class Hart : MonoBehaviour
{
    public TMP_Text hartText;

    void Start()
    {
        hartText = GetComponentInChildren<TMP_Text>();
    }

    void Update()
    {
        hartText.text = User.Instance.hp.ToString();
    }
}
