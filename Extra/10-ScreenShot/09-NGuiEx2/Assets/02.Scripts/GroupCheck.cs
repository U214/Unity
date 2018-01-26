using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupCheck : MonoBehaviour {

	public void MyCheckRed()
    {
        if (UIToggle.current.value == false) return;
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void MyCheckGreen()
    {
        if (UIToggle.current.value == false) return;
        GetComponent<Renderer>().material.color = Color.green;
    }

    public void MyCheckBlue()
    {
        if (UIToggle.current.value == false) return;
        GetComponent<Renderer>().material.color = Color.blue;
    }
}
