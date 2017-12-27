using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csRotate1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // 트랜스폼의 rotation 값 초기화 : 회전 #1
        transform.eulerAngles = new Vector3(0.0f, 50.0f, 0.0f);

        // 트랜스폼의 rotation 값 : 회전 #2
        // rotation은 Quaternion 값으로 대입해야함
        Quaternion target = Quaternion.Euler(0.0f, 100.0f, 0.0f);
        transform.rotation = target;

        // 회전
        transform.Rotate(Vector3.up * 90.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
