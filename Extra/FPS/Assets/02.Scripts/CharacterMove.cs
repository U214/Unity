using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterMove : MonoBehaviour {

    public Transform cameraTransform;

    public float moveSpeed = 5.0f;
    public float jumpSpeed = 10.0f;
    public float gravity = -20.0f;

    float speed = 20.0f;
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

        if (PauseScript.gamePause) return;

        float y = transform.position.y;

        if (y < 0)
        {
            gameObject.transform.position = new Vector3(0.0f, 40.0f, 0.0f);
        }

        float ang = CrossPlatformInputManager.GetAxis("Horizontal");
        float ver = CrossPlatformInputManager.GetAxis("Vertical");

        ver = ver * speed * Time.deltaTime;
        Vector3 moveDirection = new Vector3(0, 0, ver * moveSpeed);
        moveDirection = cameraTransform.TransformDirection(moveDirection);

        ang = ang * speed * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(ang, Vector3.up);

        if (characterController.isGrounded)
        {
            yVelocity = 0.0f;
        }

        yVelocity += (gravity * Time.deltaTime);
        moveDirection.y = yVelocity;

        characterController.Move(moveDirection * Time.deltaTime);
    }
}
