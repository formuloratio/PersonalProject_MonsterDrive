using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Vector2 min = new Vector2(-8f, -10f);
    private Vector2 max = new Vector2(8f, 30f);


    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        float moveAmount = -10 * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);

        if (transform.position.x < min.x || transform.position.x > max.x ||
            transform.position.y < min.y || transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }
}
