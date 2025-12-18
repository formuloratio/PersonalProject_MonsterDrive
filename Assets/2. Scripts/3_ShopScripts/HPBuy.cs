using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HPBuy : MonoBehaviour
{
    public Button hpPriceButton;
    public TMP_Text hpText;
    public AudioClip clipP;
    public AudioClip nonePurchaseClip;

    void Start()
    {
        hpText = GetComponentInChildren<TMP_Text>();
    }

    void Update()
    {
        hpText.text = User.Instance.hp.ToString();
    }

    public void OnClickPurchaseHP()
    {
        if (User.Instance.copperCoin >= 50 && User.Instance.hp < User.Instance.maxHp)
        {
            SoundManager.instance.SFXPlay("buyS", clipP);
            User.Instance.AddCopperCoin(-50);
            User.Instance.AddHp(1);
        }
        else
        {
            SoundManager.instance.SFXPlay("sound", nonePurchaseClip);
        }
    }
}
