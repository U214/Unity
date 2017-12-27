using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csJump2 : MonoBehaviour {

    Vector3 velocity = new Vector3(0.0f, 400.0f, 0.0f);

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().AddForce(velocity);
        }
    }
}
