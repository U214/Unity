using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class FireManager : MonoBehaviour {

    public Transform cameraTransform;
    public GameObject fireObject;
    public Transform firePoint;

    public float power = 100.0f;

    PlayerState playerHealth = null;

    void Start()
    {
        playerHealth = GetComponent<PlayerState>();
    }

    void Update () {
        if (PauseScript.gamePause == true) return;

        if (playerHealth.isDead) return;

        if (CrossPlatformInputManager.GetButtonDown("Attack"))
        {
            GameObject obj = (GameObject)Instantiate(fireObject);

            obj.transform.position = firePoint.transform.position;
            Vector3 pos = cameraTransform.forward * power;
           // pos.y += 20;
            obj.GetComponent<Rigidbody>().velocity = pos;
        }
	}
}
