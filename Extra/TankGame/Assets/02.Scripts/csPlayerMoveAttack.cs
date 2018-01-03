using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csPlayerMoveAttack : MonoBehaviour
{
    public GameObject cannon;
    public AudioClip clip;
    public float distance;

    public float movSpeed = 5.0f;
    public float rotSpeed = 120.0f;

    private Transform spPoint;

    CharacterController controller;
    Vector3 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        spPoint = transform.Find("/Player/Head/spawnPoint");
    }

    void Update()
    {
        float amtRot = rotSpeed * Time.deltaTime;

        float ang1 = Input.GetAxis("Horizontal1");
        float ver1 = Input.GetAxis("Vertical1");

        float ang2 = Input.GetAxis("Horizontal2");

        transform.Rotate(Vector3.up * ang1 * amtRot);
        transform.Find("/Player/Head/").Rotate(Vector3.up * ang2 * amtRot * 0.5f);

        moveDirection = new Vector3(0, 0, ver1 * movSpeed);
        moveDirection = transform.TransformDirection(moveDirection);

        if (Input.GetButtonDown("Jump"))
        {
            AudioManager.Instance().PlaySfx(clip);

            Instantiate(cannon, spPoint.position, spPoint.rotation);
        }

        controller.Move(moveDirection * Time.deltaTime);
    }
}
