using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iTweenValueToTest : MonoBehaviour {

    Color myColor = Color.black;

	void Update () {
	    if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<Renderer>().material.color = Color.white;
            myColor = GetComponent<Renderer>().material.color;

            Hashtable hash = new Hashtable();

            hash.Add("from", 0);
            hash.Add("to", 255.0f);
            hash.Add("time", 5.0f);
            hash.Add("onupdate", "ValueToUpdate");

            iTween.ValueTo(gameObject, hash);
        }	
	}

    void ValueToUpdate(float updateValue)
    {
        Debug.Log(updateValue + ", color : " + myColor.g);

        myColor.g = (255.0f - updateValue) / 255.0f;
        GetComponent<Renderer>().material.color = myColor;
    }
}
