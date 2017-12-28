using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csMainScript : MonoBehaviour {

    GameObject box;
    string sStatus = "";

	// Use this for initialization
	void Start () {
        box = GameObject.Find("BattleShip");
	}
	
    void OnGUI()
    {
        // 누르고 있으면 계속 인식된다
        if(GUI.RepeatButton(new Rect(10, 240, 50, 30), " < "))
        {
            sStatus = "왼쪽으로 이동합니다.";
            box.transform.Translate(Vector3.left);
        }

        if (GUI.RepeatButton(new Rect(70, 240, 50, 30), " > "))
        {
            sStatus = "오른쪽으로 이동합니다.";
            box.transform.Translate(Vector3.right);
        }

        // 클릭할 때마다 인식된다
        if (GUI.Button(new Rect(400, 240, 50, 30), " Fire "))
        {
            sStatus = "총알이 발사됩니다.";

            GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            bullet.transform.position = box.transform.position;
            bullet.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            bullet.name = "bullet";
            bullet.AddComponent<csBullet>();
        }

        GUILayout.Label(sStatus);
    }
}
