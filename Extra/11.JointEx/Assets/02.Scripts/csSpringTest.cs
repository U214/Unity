using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csSpringTest : MonoBehaviour {

    public float speed = 5.0f;

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 80, 50), " Add Force "))
        {
            gameObject.GetComponent<Rigidbody>().AddForce
                (Vector3.up * speed, ForceMode.Impulse);
        }
    }
}
