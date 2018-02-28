using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCamera : MonoBehaviour {

    private Gyroscope gyro;
    private bool gyroSupported;
    private Quaternion rotFix;

    void Start()
    {
        gyroSupported = SystemInfo.supportsGyroscope;

        GameObject camParent = new GameObject("camParent");
        camParent.transform.position = transform.position;
        transform.parent = camParent.transform;

        if (gyroSupported)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            // 폰을 세웠을 때 정면이 보이게 한다 #1
            camParent.transform.rotation = Quaternion.Euler(90f, 180f, 0f);
            rotFix = new Quaternion(0, 0, 1, 0);
        }
    }

    void Update()
    {
        if (gyroSupported)
        {
            // 폰을 세웠을 때 정면이 보이게 한다 #2
            transform.localRotation = gyro.attitude * rotFix;
        }
    }
}
