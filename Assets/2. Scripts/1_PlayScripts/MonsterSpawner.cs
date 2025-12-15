using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", Random.Range(2f, 5f)); //"호출할 함수", 몇초후에 생성할지
    }

    void Spawn()
    {
        GameObject mon = Instantiate(monsterPrefab);
        mon.transform.position = transform.position;
        Invoke("Spawn", Random.Range(0.3f, 10f));
    }

    // Update is called once per frame
    void Update()
    {
        OnDisable();
        OnEnable();
    }

    void OnDisable()
    {
        monsterPrefab.SetActive(false);
    }
    void OnEnable()
    {
        monsterPrefab.SetActive(true);
    }
}
