using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csRotateAround : MonoBehaviour {
    public GameObject target = null;
    Transform obj = null;

    void Start() {
        obj = target.transform;
    }

    void Update() {
        // 주변 돌기 obj.position == Zero
        transform.RotateAround(obj.position, Vector3.up, 10 * Time.deltaTime);
    }
}
