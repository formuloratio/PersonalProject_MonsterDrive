using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAPManager : MonoBehaviour, IStoreListener
{

    [SerializeField] Text stateText;
    [SerializeField] GameObject noAdsButton; //기존 버튼 가려줄 버튼
    [SerializeField] GameObject noFeeButton;

    private IStoreController storeController;

    private string gold1 = "md_gold_1";
    private string gold10 = "md_gold_10";
    private string gold100 = "md_gold_100";
    private string noAds = "no_ads_low";
    private string noFee = "md_no_fee";

    void Start()
    {
        InitIAP();
    }

    private void InitIAP()//초기설정
    {
        //UI에서 활성 혹은 비활성 되는 것 먼저 작성
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(gold1, ProductType.Consumable);
        builder.AddProduct(gold10, ProductType.Consumable);
        builder.AddProduct(gold100, ProductType.Consumable);
        builder.AddProduct(noAds, ProductType.NonConsumable);
        builder.AddProduct(noFee, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions) //자동 초기화
    {
        // throw new System.NotImplementedException();
        storeController = controller;
        CheckNonConsumable(noAds);
        CheckNonConsumable(noFee);
    }

    public void OnInitializeFailed(InitializationFailureReason error) //초기화 실패시 호출(에러만 받아옴)
    {
        // throw new System.NotImplementedException();
        Debug.Log("초기화 실패 : " + error);
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message) //초기화 실패시 호출 + 메세지까지 받아옴
    {
        // throw new System.NotImplementedException();
        Debug.Log("초기화 실패 : " + error + message);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason) //구매 실패시 호출
    {
        // throw new System.NotImplementedException();
        Debug.Log("구매 실패");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent) //결제 정상시 재화나 기능 등 적용
    {
        // throw new System.NotImplementedException();
        var product = purchaseEvent.purchasedProduct; //결제 정보를 product에 전달.
        Debug.Log("구매 성공 : " + product.definition.id); //뭐가 결제되었는지 확인.

        if (product.definition.id == gold1)
        {
            stateText.text = "You get 1 Gold.";
            User.Instance.goldCoin += 1;
        }
        else if (product.definition.id == gold10)
        {
            stateText.text = "You get 10 Gold.";
            User.Instance.AddGoldCoin(10);
        }
        else if (product.definition.id == gold100)
        {
            stateText.text = "You get 100 Gold.";
            User.Instance.AddGoldCoin(100);
        }
        else if (product.definition.id == noAds)
        {
            stateText.text = "Get the Ad-Free Experience.";
            noAdsButton.SetActive(true); //가려지게
        }
        else if (product.definition.id == noFee)
        {
            stateText.text = "Waive the currency exchange fee.";
            noFeeButton.SetActive(true); //가려지게
        }

        return PurchaseProcessingResult.Complete; //구매처리 정상 완료되었음을 전달해줌
    }

    public void Purchase(string productID) //버튼 이벤트에 연결, 인자로 제품ID 받아옴
    {
        storeController.InitiatePurchase(productID); //구매하는 상품ID 전달하여 결제 과정 초기화
    }

    private void CheckNonConsumable(string id) //구매 영수증 확인, 인자로 상품ID 받아옴
    {
        var product = storeController.products.WithID(id); //위드ID를 통해 해당 상품 정보 가져옴

        if (product != null) //정보가 있다면
        {
            if (id == noAds)
            {
                bool isCheck = product.hasReceipt; //해당 영수증 정보 있다면 isCheck가 true가 됨
                noAdsButton.SetActive(isCheck); //영수증 여부에 따라 활성화
            }
            else if (id == noFee)
            {
                bool isCheck1 = product.hasReceipt; //해당 영수증 정보 있다면 isCheck가 true가 됨
                noFeeButton.SetActive(isCheck1); //영수증 여부에 따라 활성화
            }
        }
    }
}
