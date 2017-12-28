using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csMainScript : MonoBehaviour {

    public Transform spawnPoint;
    public GameObject myParticle;
	
	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            DoMyParticle();
        }
	}

    void DoMyParticle()
    {
        GameObject particleObj = Instantiate(myParticle) as GameObject;
        particleObj.transform.position = spawnPoint.position;

        Destroy(particleObj, 1.0f);
    }
}
