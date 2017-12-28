using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csMove : MonoBehaviour {

    public float movSpeed = 5.0f;
    public float rotSpeed = 120.0f;

    // Update is called once per frame
    void Update () {
        float amtMove = movSpeed * Time.deltaTime;
        float amtRot = rotSpeed * Time.deltaTime;

        // 키보드 입력
        float ang = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        // 실제 이동
        transform.Translate(Vector3.forward * ver * amtMove);
        transform.Rotate(Vector3.up * ang * amtRot);
    }
}
