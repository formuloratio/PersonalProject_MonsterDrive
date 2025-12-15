using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSpEable : MonoBehaviour
{
    public GameObject eableR;
    public GameObject thisMonster1;
    public GameObject thisMonster2;
    public GameObject nextMonster1;
    public GameObject nestMonster2;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (eableR == true)
        {
            thisMonster1.SetActive(false);
            thisMonster2.SetActive(false);
            nextMonster1.SetActive(false);
            nestMonster2.SetActive(false);
        }
        else
        {
            thisMonster1.SetActive(true);
            thisMonster2.SetActive(true);
            nextMonster1.SetActive(true);
            nestMonster2.SetActive(true);
        }
    }
}
