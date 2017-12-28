using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csMainScript : MonoBehaviour {

    public Transform firePos;
    public GameObject cannon;
	
	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(cannon, firePos.position, firePos.rotation);
        }
	}
}
