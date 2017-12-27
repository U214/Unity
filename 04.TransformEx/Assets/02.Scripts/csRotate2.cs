using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csRotate2 : MonoBehaviour {

    float speed = 1000.0f;
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        h = h * speed * Time.deltaTime;
        v = v * speed * Time.deltaTime;

        // 회전 #1
        //transform.Rotate(Vector3.forward * h); // Z
        //transform.Rotate(Vector3.right * v); // X

        // 회전 #2
        transform.rotation *= Quaternion.AngleAxis(h, Vector3.forward);
        transform.rotation *= Quaternion.AngleAxis(v, Vector3.right);
    }
}
