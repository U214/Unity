﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCannon : MonoBehaviour {

    float power = 900.0f;
    Vector3 velocity = new Vector3(0.0f, 0.7f, 1.0f);

	void Start () {
        velocity = velocity * power;
        GetComponent<Rigidbody>().AddForce(velocity);
	}
	
	void FixedUpdate () {
		if(this.transform.position.z > 20.0f)
        {
            Destroy(this.gameObject);
        }
	}
}
