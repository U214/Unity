using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csGeneratedObj : MonoBehaviour {
    float power = 800.0f;
    int timer = 0;

    bool flag = false;

    void Update()
    {
        if (!flag)
        {
            if (transform.position.y < 1)
            {
                Vector3 pos = GameObject.Find("Player").transform.position - transform.position;
                pos.Normalize();
                pos *= power;
                pos.y += 30;
                GetComponent<Rigidbody>().AddForce(pos);
                flag = true;
            }
        }

        if (timer == 120)
        {
            Destroy(gameObject);
        }
        timer++;
    }
}
