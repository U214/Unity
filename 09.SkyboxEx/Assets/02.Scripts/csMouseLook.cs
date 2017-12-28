using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csMouseLook : MonoBehaviour {

    public float sensitivity = 500.0f;
    public float rotationX;
    public float rotationY;
	
	// Update is called once per frame
	void Update () {
        float mouseMoveValueX = Input.GetAxis("Mouse X");
        float mouseMoveValueY = Input.GetAxis("Mouse Y");

        rotationX += mouseMoveValueX * sensitivity * Time.deltaTime;
        rotationY += mouseMoveValueY * sensitivity * Time.deltaTime;

        // 마우스 앞으로 이동
        if (rotationY > 45.0f)
        {
            rotationY = 45.0f;
        }

        // 마우스 뒤로 이동
        if (rotationY > -20.0f)
        {
            rotationY = -20.0f;
        }

        transform.eulerAngles = new Vector3(-rotationY, rotationX, 0.0f);
    }
}
