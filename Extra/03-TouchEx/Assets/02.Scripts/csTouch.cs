using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csTouch : MonoBehaviour {

    int fingerCount = 0;
    int size = 1;
    Text txtStatus1;
    Text txtStatus2;

    void Start () {
        GameObject obj1 = GameObject.Find("txtStatus1");
        GameObject obj2 = GameObject.Find("txtStatus2");
        txtStatus1 = obj1.GetComponent<Text>();
        txtStatus2 = obj2.GetComponent<Text>();

        txtStatus1.fontSize = Screen.height * size / 100;
        txtStatus2.fontSize = Screen.height * size / 100;
    }
	
    // 터치 처리
	void Update () {
		foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerCount++;

                if (touch.position.x > Screen.width/2)
                {
                    txtStatus1.text = "화면의 오른쪽 터치";
                } else
                {
                    txtStatus2.text = "화면의 왼쪽 터치";
                }
            }

            if (fingerCount > 0)
            {
                txtStatus2.text = "Touch Count : " + fingerCount;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerCount = 0;
                txtStatus2.text = "Touch Count : " + fingerCount;
            }
        }
	}
}
