using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csLookPlayerAttack : MonoBehaviour {
    public GameObject cannon;
    public Transform player;
    public float distance;
    
    private Transform spPoint;
    private Transform viewer;

    RaycastHit hit;
    Vector3 fwd = Vector3.forward;
    int attackTimeout = -1;

    void Start() {
        viewer = transform.Find("/Enemy/Viewer");
        spPoint = transform.Find("/Enemy/Head/spawnPoint");
    }

    void Update () {
        viewer.LookAt(player);
        transform.rotation = viewer.rotation;
        transform.Find("/Enemy/Head/").rotation = viewer.rotation;

        Vector3 newSpPoint = new Vector3(
            spPoint.position.x,
            viewer.transform.position.y,
            spPoint.position.z);

        // DrawRay
        Debug.DrawRay(newSpPoint, spPoint.forward * distance, Color.red);

        fwd = transform.TransformDirection(viewer.transform.forward);

        // Raycast
        if (Physics.Raycast(newSpPoint, fwd, out hit, distance))
        {
            if (attackTimeout == -1) {
                attackTimeout = 60;
                //Debug.Log(hit.collider.gameObject.name);
                attack();
            }
        }

        if (attackTimeout > -1)
        {
            attackTimeout--;
        }
	}

    void attack()
    {
        Instantiate(cannon, spPoint.position, spPoint.rotation);
    }
}
