using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCollisionCheck2 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");

        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 200.0f, -200.0f));
    }
}
