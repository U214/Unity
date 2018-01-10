using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iTweenMoveTest : MonoBehaviour {

    public Transform moveTarget;
	
	void Update () {
		if (Input.GetButtonDown("Fire1"))
        {
            Hashtable hash = new Hashtable();

            hash.Add("position", moveTarget);
            hash.Add("orienttopath", true);
            hash.Add("looktime", 1.0f);
            hash.Add("time", 3.0f);
            hash.Add("easetype", iTween.EaseType.easeInOutExpo);

            iTween.MoveTo(gameObject, hash);
        }
	}
}
