using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csHingeTest : MonoBehaviour {

    HingeJoint hinge;
    JointSpring hingeSpring;

	void Start () {
        hinge = GameObject.Find("Wall").GetComponent<HingeJoint>();
        hingeSpring = hinge.spring;
	}
	
	void OnGUI()
    {
        if (GUI.Button (new Rect(10, 10, 80, 50), "Spring 0"))
        {
            hinge.useSpring = false;
        }
        if (GUI.Button(new Rect(10, 70, 80, 50), "Spring 10"))
        {
            hinge.useSpring = true;
        }
        if (GUI.Button(new Rect(10, 130, 80, 50), "Limit True"))
        {
            hinge.useLimits = true;
        }
        if (GUI.Button(new Rect(10, 190, 80, 50), "Limit false"))
        {
            hinge.useLimits = false;
        }
    }
}
