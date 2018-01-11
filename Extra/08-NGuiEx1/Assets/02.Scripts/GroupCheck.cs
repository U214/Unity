using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupCheck : MonoBehaviour {

	public void MyCheck1()
    {
        if (UIToggle.current.value == false) return;
        Debug.Log("checked1");
    }

    public void MyCheck2()
    {
        if (UIToggle.current.value == false) return;
        Debug.Log("checked2");
    }
}
