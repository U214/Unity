using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csLaser : MonoBehaviour {

    public float moveSpeed = 0.45f;
    public string type;

	void Update () {
        float moveY = moveSpeed * Time.deltaTime;

        if (type == "Enemy")
        {
            transform.eulerAngles = new Vector3(180.0f, 0.0f, 0.0f);
            transform.Translate(0, moveY, 0);
            if (transform.position.y <= -0.9f)
            {
                OnBecameInvisible();
            }
        }
        else
        {
            transform.Translate(0, moveY, 0);

            if (transform.position.y >= 0.9f)
            {
                OnBecameInvisible();
            }
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
