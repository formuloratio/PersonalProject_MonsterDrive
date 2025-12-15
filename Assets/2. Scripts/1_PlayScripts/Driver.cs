using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Driver : MonoBehaviour
{
    public LayerMask wallLayer; // 벽 레이어 지정
    private Rigidbody2D rb;

    public bool leftClick = false;
    public bool rightClick = false;
    public float horizontalAmount = 0;
    public static float moveSpeed = 6;
    public static float horizontalSpeed = 7;
    //public static float steerSpeed = 120;
    public GameObject clip1;
    public GameObject clip2;

    public FloatingJoystick joystick;
    ///[SerializeField]
    ///private	VirtualJoystick	virtualJoystick;

    void Start()
    {
        
    }

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

        

        //transform.position += (Vector3)joystick.Direction * moveSpeed * Time.deltaTime;
        //float x = joystick.Horizontal;   // 좌우
        //float y = joystick.Vertical;     // 위아래

        //float steerAmountX = x * steerSpeed * Time.deltaTime;
        //float steerAmountY = y * steerSpeed * Time.deltaTime; // 위아래 이동속도 부스팅 값
        //float moveAmount = y * moveSpeed * Time.deltaTime;

        //transform.Rotate(0, 0, -steerAmountX);
        //transform.Translate(0, moveAmount, 0); // 고정 전진속도
        //transform.Translate(0, steerAmountY, 0); // 위아래 입력키에 따른 속도 조정

        //if (horizontalAmount != 0)
        //{
        //    clip1.SetActive(false);
        //    clip2.SetActive(true);
        //}
        //else
        // {
        //    clip1.SetActive(true);
        //    clip2.SetActive(false);
        //}
    }


}
