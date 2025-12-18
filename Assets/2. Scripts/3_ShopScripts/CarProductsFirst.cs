using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarProductsFirst : MonoBehaviour
{
    public GameObject carNone1Scroll;
    public GameObject carNone2Image;

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
        UpdatePanel(); //다른 씬에서 돌아왔을 때 UI 갱신
    }

    public void UpdatePanel() // 이 함수 호출 시 CarProductPanel UI 갱신
    {
        UserCar userCar = User.Instance.GetUserCar(carData.carKey); //패널에 보여지는 차 구매했는지 장착중인지 알기 위해 현재 패널에서 보여지고 있는 무기에 대한 유저카 객체를 반환 받음

        if (userCar != null && userCar.isOwn) // 구매한 무기인지 판별
        {
            carNone1Scroll.GetComponent<ScrollRect>().enabled = true;
            carNone2Image.SetActive(false);
        }
    }

    public void OnClickedPurchase()
    {
        if (User.Instance.goldCoin >= carData.price)
        {
            User.Instance.maxHp += 10;
            User.Instance.hp += 10;

            carNone1Scroll.GetComponent<ScrollRect>().enabled = true; //carNone1 오브젝트에 있는 스크롤 기능 활성화
            carNone2Image.SetActive(false);
            GetComponentInParent<CarShopCanvas>().UpdateCanvas();

            SoundManager.instance.SFXPlay("buyS", clipP);
            User.Instance.goldCoin = User.Instance.goldCoin - carData.price;
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

        GetComponentInParent<CarShopCanvas>().UpdateCanvas();
    }
}
