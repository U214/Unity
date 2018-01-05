using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csLegacy2 : MonoBehaviour {

    public float walkSpeed = 2.0f;
    public float gravity = 20.0f;
    public float jumpSpeed = 8.0f;
    private Vector3 velocity;
    private Vector3 moveTo;

    CharacterController controller;

	void Start () {
        controller = GetComponent<CharacterController>();
        // rapid walk
        GetComponent<Animation>()["walk"].speed = 1.5f;
	}

    void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                moveTo = new Vector3(0, 0, 0);

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    moveTo = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                }
            }

            if (moveTo.magnitude == 0)
            {
                // decide speed by key input
                velocity = new Vector3(
                    Input.GetAxis("Horizontal"),
                    0,
                    Input.GetAxis("Vertical"));
                velocity *= walkSpeed;

                // Jump
                if (Input.GetButtonDown("Jump"))
                {
                    velocity.y = jumpSpeed;
                    StartCoroutine("doJump");
                }
                else if (velocity.magnitude > 0.5)
                {
                    // turn walk animation
                    GetComponent<Animation>().CrossFade("walk", 0.1f);
                    transform.LookAt(transform.position + velocity);
                }
                else
                {
                    GetComponent<Animation>().CrossFade("iddle", 0.1f);
                }
            }
            else
            {
                float distance = (moveTo - transform.position).magnitude;
                Debug.Log("Distance .. " + distance);

                if (distance < 0.5)
                {
                    moveTo = new Vector3(0, 0, 0);
                }

                int xto = 0;
                int zto = 0;

                if ((moveTo.x - transform.position.x) > 0) xto = 1;
                if ((moveTo.x - transform.position.x) < 0) xto = -1;
                if ((moveTo.z - transform.position.z) > 0) zto = 1;
                if ((moveTo.z - transform.position.z) < 0) zto = -1;

                velocity = new Vector3(xto, 0, zto);
                velocity *= walkSpeed;

                if (velocity.magnitude > 0.5)
                {
                    // turn walk animation
                    GetComponent<Animation>().CrossFade("walk", 0.1f);
                    transform.LookAt(moveTo);
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

    IEnumerator doJump()
    {
        GetComponent<Animation>().Play("attack_leap");
        yield return new WaitForSeconds(0.46f);
        GetComponent<Animation>().Play("iddle");
    }
}
