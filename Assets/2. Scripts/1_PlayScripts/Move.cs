using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform Player;
    public bool leftClick = false;
    public bool rightClick = false;
    public static float moveSpeed = 6;
    public static float horizontalSpeed = 8;

    void Update()
    {
        if (leftClick)
        {
            Player.position += Vector3.left * horizontalSpeed * Time.deltaTime;
        }
        if (rightClick)
        {
            Player.position += Vector3.right * horizontalSpeed * Time.deltaTime;
        }
    }

    public void LftUp()
    {
        leftClick = false;
    }
    public void LftDown()
    {
        leftClick = true;
    }
    public void RitUp()
    {
        rightClick = false;
    }
    public void RitDown()
    {
        rightClick = true;
    }
}
