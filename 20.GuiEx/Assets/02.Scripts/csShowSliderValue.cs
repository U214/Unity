using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csShowSliderValue : MonoBehaviour {

	public void UpdateLabel (float value)
    {
        Text lbl = GetComponent<Text>();
        if (lbl != null)
        {
            lbl.text = Mathf.RoundToInt(value * 10) + "%";
        }
    }
}
