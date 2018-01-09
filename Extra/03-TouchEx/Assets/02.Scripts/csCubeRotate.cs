using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCubeRotate : MonoBehaviour {

    float accTime = 0.0f;
    bool bRotate = false;
	
	void Update () {
        if (accTime > 1.0)
        {
            bRotate = false;
        }		

        if (bRotate)
        {
            accTime += Time.deltaTime;
            transform.Rotate(100.0f * Time.deltaTime * Vector3.up);
            
        }
	}

    public void RotateByHit()
    {
        accTime = 0.0f;
        bRotate = true;
    }
}
