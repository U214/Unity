using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCamera1 : MonoBehaviour {

    private Gyroscope gyro;
    private bool gyroSupported;

	void Start () {
        gyroSupported = SystemInfo.supportsGyroscope;

        if (gyroSupported)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
	}
	
	void Update () {
		if (gyroSupported)
        {
            // 폰이 누워있어야 큐브가 보인다
            transform.rotation = gyro.attitude;
        }
	}
}
