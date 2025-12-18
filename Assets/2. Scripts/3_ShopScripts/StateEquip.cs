using UnityEngine;
using UnityEngine.UI;

public class StateEquip : MonoBehaviour
{
    public string carKey;

    void Update()
    {
        UserCar userCar = User.Instance.GetUserCar(carKey);
        if (userCar.isEquipping == true) // 장착하면 회색으로 비장착시 흰색으로
        {
            GetComponent<Image>().color = new Color(150 / 255f, 150 / 255f, 150 / 255f);
        }
        else
        {
            GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
        }
    }
}
