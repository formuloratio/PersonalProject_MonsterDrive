using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    [SerializeField] Car[] cars;
    [SerializeField] Car currentCar;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        cars = GetComponentsInChildren<Car>();

        UserCar currentUserCar = User.Instance.GetCurrentUserCar();

        if (currentUserCar == null)
        { // 기본 장비 장착 (car0)
            currentCar = GetCar("car0");
        }
        else
        { // 해당되는 장비 장착
            currentCar = GetCar(currentUserCar.carKey);
        }
        for (int i = 0; i < cars.Length; i++)
        { //일단 장비 비활성화
            cars[i].gameObject.SetActive(false);
        }
        //장착해야될 장비만 활성화
        currentCar.gameObject.SetActive(true);
    }

    Car GetCar(string key)
    {
        for (int i = 0; i < cars.Length; i++)
        {
            if (cars[i].carData.carKey == key)
                return cars[i];
        }
        return null;
    }
}
