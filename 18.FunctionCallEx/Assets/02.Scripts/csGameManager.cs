using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csGameManager : MonoBehaviour {

    GameObject obj = null;

	void Start () {
        obj = GameObject.Find("Cube");
	}
	
	void OnGUI()
    {
        if (GUI.Button(new Rect(30, 50, 180, 30), "Function Call (public)"))
        {
            // 특정 객체의 스크립트 메서드 호출
            csRotateCube script = obj.GetComponent<csRotateCube>();
            script.Rotate1();
        }

        if (GUI.Button(new Rect(30, 100, 180, 30), "Function Call (private)"))
        {
            // 메시지 보내기 (가진 놈은 다 반응함)
            obj.SendMessage("Rotate2", SendMessageOptions.DontRequireReceiver);
        }

        if (GUI.Button(new Rect(30, 150, 180, 30), "Static"))
        {
            // static 함수나 변수는 바로 접근 가능
            Debug.Log("Call Variable : " + csRotateCube.numX);
            Debug.Log("Call Function : " + csRotateCube.AddTwoNum(3, 5));
        }
    }
}
