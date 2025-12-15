using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trade : MonoBehaviour
{
    public AudioClip purchaseClip;
    public AudioClip nonePurchaseClip;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoldPurchase()
    {
        if (User.Instance.coin >= 120)
        {
            SoundManager.instance.SFXPlay("sound", purchaseClip);
            User.Instance.goldCoin += 1;
            User.Instance.coin -= 120;
        }
        else
        {
            SoundManager.instance.SFXPlay("sound", nonePurchaseClip);
        }
    }
    public void GoldToSilverPurchase()
    {
        if (User.Instance.goldCoin >= 1)
        {
            SoundManager.instance.SFXPlay("sound", purchaseClip);
            User.Instance.goldCoin -= 1;
            User.Instance.coin += 80;
        }
        else
        {
            SoundManager.instance.SFXPlay("sound", nonePurchaseClip);
        }

    }
    public void CopperToSilverPurchase()
    {
        if (User.Instance.copperCoin >= 120)
        {
            SoundManager.instance.SFXPlay("sound", purchaseClip);
            User.Instance.coin += 1;
            User.Instance.copperCoin -= 120;
        }
        else
        {
            SoundManager.instance.SFXPlay("sound", nonePurchaseClip);
        }
        
    }
    public void CopperPurchase()
    {
        if (User.Instance.coin >= 1)
        {
            SoundManager.instance.SFXPlay("sound", purchaseClip);
            User.Instance.coin -= 1;
            User.Instance.copperCoin += 80;
        }
        else
        {
            SoundManager.instance.SFXPlay("sound", nonePurchaseClip);
        }
    }
}
