using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csPlayerController : MonoBehaviour {

    public float walkSpeed = 2.0f;
    public float gravity = 20.0f;
    public float jumpSpeed = 8.0f;
    private Vector3 velocity;

    CharacterController controller;

    void Start () {
        controller = GetComponent<CharacterController>();
        // rapid walk
        GetComponent<Animation>()["Walk"].speed = 1.5f;
    }
	
	void Update () {
        if (controller.isGrounded)
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
                GetComponent<Animation>().CrossFade("Walk", 0.1f);
                transform.LookAt(transform.position + velocity);
            }
            else
            {
                GetComponent<Animation>().CrossFade("Idle", 0.1f);
            }
        }
        // add speed (gravity)
        velocity.y -= gravity * Time.deltaTime;

        // move character controller
        controller.Move(velocity * Time.deltaTime);
    }

    IEnumerator doJump()
    {
        GetComponent<Animation>().Play("Jump");
        yield return new WaitForSeconds(0.46f);
        GetComponent<Animation>().Play("Idle");
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.tag == "coin")
        {
            Debug.Log("coin : OnControllerColliderHit");
            hit.collider.gameObject.GetComponent<csCoin>().CollisionObj();
        } else if (hit.collider.gameObject.tag == "spikeBall")
        {
            Debug.Log("spikeBall : OnControllerColliderHit");
            hit.collider.gameObject.GetComponent<csSpikeBall>().CollisionObj();
        }
    }

    public void playerDestroy()
    {
        GameObject.Find("GameManager").GetComponent<csGenerator>().StopGenerator();
        GetComponent<csParticle>().makeParticle();
        Destroy(gameObject);
    }
}
