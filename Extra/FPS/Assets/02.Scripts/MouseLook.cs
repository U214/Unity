using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MouseLook : MonoBehaviour {
    float speed = 20.0f;

    public float sensitivity = 700.0f;
    public float rotationX;
    public float rotationY;

    PlayerState playerHealth = null;

    void Start()
    {
        playerHealth = transform.parent.GetComponent<PlayerState>();
    }

    void Update()
    {
        //float mouseMoveValueX = Input.GetAxis("Mouse X");
        //float mouseMoveValueY = Input.GetAxis("Mouse Y");

        //rotationY += mouseMoveValueX * sensitivity * Time.deltaTime;
        //rotationX += mouseMoveValueY * sensitivity * Time.deltaTime;

        //if (rotationX > 20.0f)
        //{
        //    rotationX = 20.0f;
        //}

        //if (rotationX < -30.0f)
        //{
        //    rotationX = -30.0f;
        //}

        //if (rotationY > 90.0f)
        //{
        //    rotationY = 90.0f;
        //}

        //if (rotationY < -90.0f)
        //{
        //    rotationY = -90.0f;
        //}

        //transform.eulerAngles = new Vector3(-rotationX, rotationY, 0.0f);

        float rotationValue = CrossPlatformInputManager.GetAxis("Horizontal");

        rotationValue = rotationValue * speed * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(rotationValue, Vector3.up);
        transform.eulerAngles = new Vector3(-rotationX, rotationY, 0.0f);
    }
}
