using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour {

    public float rotationSpeed = 50.0f;
    public bool _isRotation = false;
	
	void Update () {
		if (_isRotation)
        {
            transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed);
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
        }
	}

    public void MyClick()
    {
        _isRotation = UIToggle.current.value;
    }
}
