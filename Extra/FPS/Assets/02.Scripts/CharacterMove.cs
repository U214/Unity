using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterMove : MonoBehaviour {

    public Transform cameraTransform;

    public float moveSpeed = 10.0f;
    public float jumpSpeed = 10.0f;
    public float gravity = -20.0f;

    CharacterController characterController = null;
    float yVelocity = 0.0f;

    PlayerState playerHealth = null;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerHealth = GetComponent<PlayerState>();
    }

    void Update()
    {
        if (playerHealth.isDead) return;

        float y = transform.position.y;

        if (y < 0)
        {
            gameObject.transform.position = new Vector3(0.0f, 40.0f, 0.0f);
        }

        float z = CrossPlatformInputManager.GetAxis("Vertical");
       
        Vector3 moveDirection = new Vector3(transform.position.x, 0, z);
        moveDirection = cameraTransform.TransformDirection(moveDirection);

        moveDirection *= moveSpeed;

        if (characterController.isGrounded)
        {
            yVelocity = 0.0f;
        }

        yVelocity += (gravity * Time.deltaTime);
        moveDirection.y = yVelocity;

        characterController.Move(moveDirection * Time.deltaTime);
    }
}
