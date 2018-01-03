using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    float speed = 5.0f;
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Player").GetComponent<Player>().deadFlag != true)
        {
            float v = -1 * speed * Time.deltaTime;

            transform.Translate(Vector3.forward * v);

            if (transform.position.z < -10)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 30.0f);
            }
        }
    }
}
