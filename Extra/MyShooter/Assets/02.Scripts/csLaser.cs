using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csLaser : MonoBehaviour {

    public float moveSpeed = 0.45f;

	void Update () {
        float moveY = moveSpeed * Time.deltaTime;

        if (gameObject.transform.parent.tag == "Enemy")
        {
            transform.eulerAngles = new Vector3(180.0f, 0.0f, 0.0f);
     
            if (transform.position.y <= -0.9f)
            {
                OnBecameInvisible();
            }
        }
        else
        {
            if (transform.position.y >= 0.9f)
            {
                OnBecameInvisible();
            }
        }

        transform.Translate(0, moveY, 0);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
