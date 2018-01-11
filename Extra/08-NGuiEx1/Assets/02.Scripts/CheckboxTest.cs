using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckboxTest : MonoBehaviour {

    UIToggle uiToggleBox = null;

	void Start () {
        uiToggleBox = GetComponent<UIToggle>();	
	}
	
	void Update () {
		if (uiToggleBox.value == true)
        {
            Debug.Log("Checked OK");
        } else
        {
            Debug.Log("Unchecked");
        }
	}
}
