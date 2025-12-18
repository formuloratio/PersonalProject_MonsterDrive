using UnityEngine;

public class Driver : MonoBehaviour
{
    public LayerMask wallLayer; // 벽 레이어 지정

    public bool leftClick = false;
    public bool rightClick = false;
    public float horizontalAmount = 0;
    public static float moveSpeed = 6;
    public static float horizontalSpeed = 7;
    public GameObject clip1;
    public GameObject clip2;

    public FloatingJoystick joystick;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + new Vector3(1, 0, 0) * -horizontalSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + new Vector3(1, 0, 0) * horizontalSpeed * Time.deltaTime;
        }
    }
}
