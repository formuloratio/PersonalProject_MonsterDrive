using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyWindow2 : MonoBehaviour
{
    private Animator animator;
    public TMP_Text priceText;
    public int price = 10;
    //private bool state;
    //public string carKey;
    //public GameObject purchaseButton;
    //public GameObject equipButton;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Start()
    {
        //CarState1.carState1 = FindObjectOfType<CarState1>();
        //state = CarState1.carState1;
        
    }

    void Update()
    {
        //priceText.text = "가격 : " + price.ToString("f0") + "코인";


       // if (CarState2.carState2 == false)
        //{
        //    gameObject.SetActive(true);
        //    priceText = GetComponentInChildren<TMP_Text>();
       // }
        //else
       // {
        //    gameObject.SetActive(false);
        //}

    }

    public void ButtonClose()
    {
        if (User.Instance.coin >= price)
        {
            User.Instance.coin = User.Instance.coin - price;
            //CarState2.carState2 = true;

            //User.Instance.PurchasedCar(carKey);
            //purchaseButton.SetActive(false);
           // equipButton.SetActive(true);

            animator.SetTrigger("close");
            gameObject.SetActive(false);
            animator.ResetTrigger("close");
        }
    }
    public void BackClose()
    {
        //animator.SetTrigger("close");
        //gameObject.SetActive(false);
        //animator.ResetTrigger("close");
    }
}
