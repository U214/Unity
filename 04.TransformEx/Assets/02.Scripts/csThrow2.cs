using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csThrow2 : MonoBehaviour {

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(7, 7, 0);
        }
    }
}
