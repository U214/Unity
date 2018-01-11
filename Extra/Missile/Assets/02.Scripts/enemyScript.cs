using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour {

    void Start()
    {
        Hashtable hash = new Hashtable();

        hash.Add("path", iTweenPath.GetPath("MyPath" + Random.Range(1, 4)));
        hash.Add("movetopath", true);
        hash.Add("orienttopath", true);
       // hash.Add("looktime", 1.0f);
        //hash.Add("delay", 1.0f);
        hash.Add("time", 30.0f);
        //hash.Add("easetype", iTween.EaseType.easeInOutExpo);

        iTween.MoveTo(gameObject, hash);
    }
	
	void Update () {
        if (transform.position.z < 0)
        {
            Destroy(gameObject);
        }
    }
}
