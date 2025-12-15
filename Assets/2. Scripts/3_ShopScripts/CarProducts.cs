using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarProducts : MonoBehaviour
{
    public CarData carData;
    public Image thumImage;
    public TMP_Text priceText;
    public Image stateIM;
    public Image stateBT;

    public GameObject purchaseButton;
    public GameObject equipButton;
    public TMP_Text equipStateText;
    
    public AudioClip clipP;
    public AudioClip clipE;

    public AudioClip nonePurchaseClip;

    private void Start()
    {
        //        thumImage.sprite = carData.thum;
        priceText.text = carData.price.ToString();


        UserCar userCar = User.Instance.GetUserCar(carData.carKey);
        if (userCar.isOwn == true) // 소유하면 흰색으로 비소유면 회색
        {
            stateIM.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
            stateBT.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
        }
        else
        {
            stateIM.GetComponent<Image>().color = new Color(155 / 255f, 155 / 255f, 155 / 255f);
            stateBT.GetComponent<Image>().color = new Color(155 / 255f, 155 / 255f, 155 / 255f);
        }

        UpdatePanel(); //다른 씬에서 돌아왔을 때 UI 갱신

    }

    public void UpdatePanel() // 이 함수 호출 시 CarProductPanel UI 갱신
    {
        UserCar userCar = User.Instance.GetUserCar(carData.carKey); //패널에 보여지는 차 구매했는지 장착중인지 알기 위해 현재 패널에서 보여지고 있는 무기에 대한 유저카 객체를 반환 받음

        if (userCar != null && userCar.isOwn) // 구매한 무기인지 판별
        {
            equipButton.SetActive(true);
            if (userCar.isEquipping) // 탑승하고 있으면 탑승중 출력
            {
                equipStateText.text = "on board";
            }
            else // 탑승 안하고 있으면 탑승하기 출력
            {
                equipStateText.text = "get in";
            }
        }
        else
        {
            equipButton.SetActive(false);
        }
    }

    public void OnClickedPurchase()
    {
        if (User.Instance.coin >= carData.price)
        {
            SoundManager.instance.SFXPlay("buyS", clipP);
            User.Instance.coin = User.Instance.coin - carData.price;
            User.Instance.PurchasedCar(carData.carKey);

            UserCar userCar = User.Instance.GetUserCar(carData.carKey);
            if (userCar.isOwn == true) // 소유하면 흰색으로 비소유면 회색
            {
                stateIM.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
                stateBT.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
            }
            else
            {
                stateIM.GetComponent<Image>().color = new Color(155 / 255f, 155 / 255f, 155 / 255f);
                stateBT.GetComponent<Image>().color = new Color(155 / 255f, 155 / 255f, 155 / 255f);
            }

            purchaseButton.SetActive(false);
        }
        else
        {
            SoundManager.instance.SFXPlay("sound", nonePurchaseClip);
        }

        //UpdatePanel();

        GetComponentInParent<CarShopCanvas>().UpdateCanvas();
    }

    public void OnClickedEquip()
    {
        SoundManager.instance.SFXPlay("equipS", clipE);
        User.Instance.EquipCar(carData.carKey);
        GetComponentInParent<CarShopCanvas>().UpdateCanvas();
    }

}
