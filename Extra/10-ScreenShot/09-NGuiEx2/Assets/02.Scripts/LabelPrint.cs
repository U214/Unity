using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelPrint : MonoBehaviour {

    UILabel label = null;

    string baseText =
        "I am a boy. You are a girl.\n" +
        "We are students. \n" +
        "동해물과 백두산이 마르고 닳도록 하느님이 보우하사 우리나라 만세";

    public float changeTime = 0.1f;
    float deltaTime = 0.0f;
    int currentTextIndedx = 0;

	void Start () {
        label = GetComponent<UILabel>();
	}
	
	void Update () {
		if (currentTextIndedx <= baseText.Length)
        {
            deltaTime += Time.deltaTime;

            if (deltaTime > changeTime)
            {
                deltaTime = 0.0f;

                label.text = "";
                label.text = baseText.Substring(0, currentTextIndedx);

                currentTextIndedx++;
            }
        }
	}
}
