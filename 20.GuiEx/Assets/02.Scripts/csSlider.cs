using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csSlider : MonoBehaviour {

    Text txt;
    Slider slider1;
    Slider slider2;
    int fonsSize;

	void Start () {
        txt = GameObject.Find("txtCenter").GetComponent<Text>();
        slider1 = GameObject.Find("Slider1").GetComponent<Slider>();
        slider2 = GameObject.Find("Slider2").GetComponent<Slider>();

        fonsSize = txt.fontSize;
    }

	public void ChangeSliderValue()
    {
        float val = slider2.value;
        Debug.Log("slider2.value : " + val);

        slider1.value = val;
        txt.fontSize = fonsSize + (int)val;
    }
}   
