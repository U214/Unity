using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCollisionCheck : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log(gameObject.name + " : OnTriggerEnter");
            Destroy(gameObject);
        } 
    }
}
