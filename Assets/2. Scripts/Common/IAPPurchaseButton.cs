using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPPurchaseButton : MonoBehaviour
{
    public void PurchaseGold1()
    {
        User.Instance.AddGoldCoin(1);
    }

    public void PurchaseGold10()
    {
        User.Instance.AddGoldCoin(10);
    }

    public void PurchaseGold100()
    {
        User.Instance.AddGoldCoin(100);
    }
}
