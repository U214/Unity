using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csWhenDestroyPlay : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().Play();

        Destroy(this.gameObject);
    }
}
