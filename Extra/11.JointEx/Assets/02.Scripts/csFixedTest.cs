using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csFixedTest : MonoBehaviour {

    public float speed = 100.0f;
    Transform obj = null;

	void Start () {
        obj = GameObject.Find("Right Root").GetComponent<Transform>();
	}
	
	void Update () {
        gameObject.GetComponent<Rigidbody>().AddTorque
            (Vector3.forward * speed, ForceMode.Impulse);
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 80, 50), " << "))
        {
            obj.position = new Vector3(3.5f, 0, 0);
        }
        if (GUI.Button(new Rect(10, 70, 80, 50), " >> "))
        {
            obj.position = new Vector3(4, 0, 0);
        }
    }
}
