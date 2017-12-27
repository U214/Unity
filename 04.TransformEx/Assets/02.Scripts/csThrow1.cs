using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csThrow1 : MonoBehaviour {

    float power = 800.0f;
    Vector3 velocity = new Vector3(0.5f, 0.5f, 0.0f);

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            velocity = velocity * power;
            GetComponent<Rigidbody>().AddForce(velocity);
        }
    }
}
