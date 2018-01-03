using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csButton : MonoBehaviour {

    GameObject obj;
    Text txt;

    void Start()
    {
        obj = GameObject.Find("txtCenter");
        txt = obj.GetComponent<Text>();
    }

   public void ChangeText()
    {
        txt.text = "홍길동";
    }
}
