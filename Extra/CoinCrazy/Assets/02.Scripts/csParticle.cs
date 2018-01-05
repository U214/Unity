using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csParticle : MonoBehaviour {

    public GameObject myParticle;

    public void makeParticle()
    {
        GameObject particleObj = Instantiate(myParticle) as GameObject;
        particleObj.transform.position = transform.position;

        Destroy(particleObj, 1.0f);
    }
}
