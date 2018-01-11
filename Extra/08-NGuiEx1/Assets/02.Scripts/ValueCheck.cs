using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueCheck : MonoBehaviour {

	public void SetAlpha()
    {
        UIWidget widget = GetComponent<UIWidget>();
        widget.alpha = UISlider.current.value;
        Debug.Log("current value " + UISlider.current.value);
    }
}
