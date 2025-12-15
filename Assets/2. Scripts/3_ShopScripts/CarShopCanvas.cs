using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CarShopCanvas : MonoBehaviour
{
    public CarProducts[] carProducts;

    void Start()
    {
        carProducts = GetComponentsInChildren<CarProducts>();
    }

    public void UpdateCanvas() //호출 시 canvas 하위의 ui 갱신
    {
        for (int i = 0; i < carProducts.Length; i++)
        {
            carProducts[i].UpdatePanel();
        }
    }
}
