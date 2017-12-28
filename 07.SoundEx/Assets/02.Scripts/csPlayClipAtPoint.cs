using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csPlayClipAtPoint : MonoBehaviour {

    float speed = 20.0f;

    public Transform box;
    public AudioClip myClip;

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");

        v = v * speed * Time.deltaTime;

        box.Translate(Vector3.forward * v);

        if (Input.GetButtonDown("Fire1"))
        {
            AudioSource.PlayClipAtPoint(myClip, box.position);
        }
    }
}
