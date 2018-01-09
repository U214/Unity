using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csLaser : MonoBehaviour {

    public float moveSpeed = 0.45f;

	void Update () {
        float moveY = moveSpeed * Time.deltaTime;
        transform.Translate(0, moveY, 0);
	}

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
