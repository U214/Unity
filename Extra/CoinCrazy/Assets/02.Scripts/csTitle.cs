using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class csTitle : MonoBehaviour {

    private Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.localRotation;
    }

    void Update()
    {
        transform.localRotation =
            Quaternion.AngleAxis(Mathf.Sin(2.0f * Time.time) * 20.0f, Vector3.up) *
            Quaternion.AngleAxis(Mathf.Sin(2.7f * Time.time) * 33.3f, Vector3.right) *
            originalRotation;

        transform.parent.localRotation =
            Quaternion.AngleAxis(Time.deltaTime * 10.0f, Vector3.up) *
            transform.parent.localRotation;

        if (Input.anyKey)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
