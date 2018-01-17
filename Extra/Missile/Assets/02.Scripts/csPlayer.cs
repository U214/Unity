using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csPlayer : MonoBehaviour {
    public float speed = 20.0f;

    public GameObject missile;
    public GameObject firePos;
    public GameObject Aim;

    float rotX = 0.0f;
    float rotY = 0.0f;
    float rotZ = 0.0f;

    void Start()
    {
        StartCoroutine(UpdateRotate());
    }

    void Update () {
        float roll = Input.GetAxis("Horizontal");
        float pitch = Input.GetAxis("Vertical");

        if ((roll > 0) && (rotZ > -40))
        {
            rotY++;
            rotZ--;
        } else if ((roll < 0) && (rotZ < 40))
        {
            rotY--;
            rotZ++;
        }

        if ((pitch < 0) && (rotX < 30))
        {
            rotX++;
        }
        else if ((pitch > 0) && (rotX > -30))
        {
            rotX--;
        }

        transform.rotation = Quaternion.Euler(new Vector3(rotX, rotY, rotZ));
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    IEnumerator UpdateRotate()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);

            if (!Input.anyKey)
            {
                if ((rotX > 0.0f) && (rotX <= 30.0f))
                {
                    rotX--;
                }

                if ((rotX < 0.0f) && (rotX >= -30.0f))
                {
                    rotX++;
                }

                if ((rotZ > 0.0f) && (rotZ <= 40.0f))
                {
                    rotZ--;
                }

                if ((rotZ < 0.0f) && (rotZ >= -40.0f))
                {
                    rotZ++;
                }

                transform.rotation = Quaternion.Euler(new Vector3(rotX, rotY, rotZ));
            }
        }
    }
}
