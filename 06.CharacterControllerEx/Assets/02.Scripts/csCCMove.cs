using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCCMove : MonoBehaviour {

    public float movSpeed = 5.0f;
    public float rotSpeed = 120.0f;

    CharacterController controller;
    Vector3 moveDirection;

    float gravity = 20.0f;
    float jumpSpeed = 10.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            float amtRot = rotSpeed * Time.deltaTime;

            float ang = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");

            transform.Rotate(Vector3.up * ang * amtRot);
            moveDirection = new Vector3(0, 0, ver * movSpeed);
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);
    }
}
