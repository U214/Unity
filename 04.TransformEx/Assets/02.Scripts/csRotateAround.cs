using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csRotateAround : MonoBehaviour {

    Transform obj = null;

    // Use this for initialization
    void Start()
    {
        obj = GameObject.Find("Earth").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // 주변 돌기 obj.position == Zero
        transform.RotateAround(obj.position, Vector3.right, 40 * Time.deltaTime);
        transform.LookAt(obj);
    }
}
