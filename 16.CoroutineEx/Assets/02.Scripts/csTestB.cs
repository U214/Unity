using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csTestB : MonoBehaviour {

	IEnumerator Start ()
    {
        Debug.Log(gameObject.name + " : 1");
        yield return null;
        Debug.Log(gameObject.name + " : 2");
        Debug.Log(gameObject.name + " : 3");
    }

}
