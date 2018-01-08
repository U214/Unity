using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {


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
        float mouseMoveValueX = Input.GetAxis("Mouse X");
        float mouseMoveValueY = Input.GetAxis("Mouse Y");

        rotationY += mouseMoveValueX * sensitivity * Time.deltaTime;
        rotationX += mouseMoveValueY * sensitivity * Time.deltaTime;

        if (rotationX > 20.0f)
        {
            rotationX = 20.0f;
        }

        if (rotationX < -30.0f)
        {
            rotationX = -30.0f;
        }

        if (rotationY > 90.0f)
        {
            rotationY = 90.0f;
        }

        if (rotationY < -90.0f)
        {
            rotationY = -90.0f;
        }

        transform.eulerAngles = new Vector3(-rotationX, rotationY, 0.0f);
    }
}
