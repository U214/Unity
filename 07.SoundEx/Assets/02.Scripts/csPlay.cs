using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csPlay : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().Play();
    }
}
