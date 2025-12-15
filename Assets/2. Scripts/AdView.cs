using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdView : MonoBehaviour
{
    
    private AdmobManager admobManager;
    // Start is called before the first frame update
    void Start()
    {
        admobManager = FindObjectOfType<AdmobManager>();
        if (admobManager == null)
        {
            // Debug.LogError("AdmobManager not found in the scene.");
        }

        admobManager.ShowFrontAd(); //광고 실행
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
