using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCollisionCheck : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
    }
}
