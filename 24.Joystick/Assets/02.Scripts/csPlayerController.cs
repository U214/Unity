using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class csPlayerController : MonoBehaviour {

    public float walkSpeed = 3.0f;
    public float gravity = 20.0f;
    public float jumpSpeed = 8.0f;
    private Vector3 velocity;

    CharacterController controller = null;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        // rapid walk
        GetComponent<Animation>()["walk"].speed = 2.0f;
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            velocity = new Vector3(
                CrossPlatformInputManager.GetAxis("Horizontal"),
                0,
                CrossPlatformInputManager.GetAxis("Vertical"));
            velocity *= walkSpeed;

            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                velocity.y = jumpSpeed;
                GetComponent<Animation>().Play("attack_leap");
            }
            else
            {
                if (velocity.magnitude > 0.5)
                {
                    GetComponent<Animation>().CrossFade("walk", 0.1f);
                    transform.LookAt(transform.position + velocity);
                }
                else
                {
                    GetComponent<Animation>().CrossFade("iddle", 0.1f);
                }
            }
        }

        // add speed (gravity)
        velocity.y -= gravity * Time.deltaTime;

        // move character controller
        controller.Move(velocity * Time.deltaTime);
    }

}
