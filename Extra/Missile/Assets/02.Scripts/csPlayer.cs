using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csPlayer : MonoBehaviour {
    float speed = 50.0f;

    public GameObject missile;
    public GameObject firePos;
    public GameObject Aim;

    void Start()
    {
        Aim.SetActive(false);
    }

    void Update () {
        float h = Input.GetAxis("Horizontal");
        h = h * speed * Time.deltaTime;

        //transform.Rotate(new Vector3(0, 1, -1) * h);
       // transform.Rotate(Vector3.right * h * 0.5f);
        transform.Translate(Vector3.right * h);

        // DrawRay
        Debug.DrawRay(firePos.transform.position, transform.forward * 130, Color.red);

        // Raycast
        RaycastHit hit;

        if (Physics.Raycast(firePos.transform.position, transform.forward, out hit, 130))
        {
           // Aim.transform.position = firePos.transform.position;
            Aim.SetActive(true);
            Debug.Log(hit.collider.gameObject.name);

            if (Input.GetButtonDown("Jump"))
            {
                GameObject obj = (GameObject)Instantiate(missile);
                obj.transform.position = firePos.transform.position;
                obj.GetComponent<csMissile>().target = hit.collider.gameObject.transform;
            }
        } else
        {
            Aim.SetActive(false);
        }
    }
}
