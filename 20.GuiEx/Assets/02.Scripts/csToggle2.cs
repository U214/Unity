using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csToggle2 : MonoBehaviour {

    Text txt;
    Toggle tgChange;

    void Start()
    {
        txt = GameObject.Find("txtCenter").GetComponent<Text>();
        tgChange = GameObject.Find("tgChange1").GetComponent<Toggle>();
    }

    public void ChangeText()
    {
        if (tgChange.isOn)
        {
            txt.text = "Hello World";
        }
        else
        {
            txt.text = "홍길동";
        }
    }
}
