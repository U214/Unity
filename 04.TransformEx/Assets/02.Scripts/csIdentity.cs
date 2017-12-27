using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csIdentity : MonoBehaviour {

    public float rotSpeed = 120.0f;

	// Update is called once per frame
	void Update () {
        // 회전
        float amtRot = rotSpeed * Time.deltaTime;
        float ang = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * ang * amtRot);

        // 정렬
        if (Input.GetButtonDown("Fire1"))
        {
            // 글로벌
            transform.rotation = Quaternion.identity;

            // 부모
            //transform.localRotation = Quaternion.identity;
        }
	}
}
