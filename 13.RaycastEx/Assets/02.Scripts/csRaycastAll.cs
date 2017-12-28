using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csRaycastAll : MonoBehaviour {

    private float speed = 5.0f;

    void Update()
    {
        // 이동
        float amtMove = speed * Time.deltaTime;
        float hor = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * hor * amtMove);

        // DrawRay
        Debug.DrawRay(transform.position, transform.forward * 8, Color.red);

        // RaycastAll
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, 8.0f);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];

            Debug.Log(hit.collider.gameObject.name);
        }
    }
}
