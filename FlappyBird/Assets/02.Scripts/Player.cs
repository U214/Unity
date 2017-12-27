using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool deadFlag = false;
    
    Vector3 velocity = new Vector3(0.0f, 200.0f, 0.0f);

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
           gameObject.GetComponent<Rigidbody>().AddForce(velocity);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        deadFlag = true;
        Destroy(gameObject);
    }
}
