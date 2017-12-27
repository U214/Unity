using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csLookAt : MonoBehaviour {

    Transform obj = null;

	// Use this for initialization
	void Start () {
        obj = GameObject.Find("Cube (1)").transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(obj);
	}
}
