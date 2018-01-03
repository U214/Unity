using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCannon : MonoBehaviour {
    public GameObject myParticle;
    public AudioClip clip;

    float power = 1200.0f;
    Vector3 velocity = new Vector3(0.0f, 1.0f, 1.0f);
    
	void Start () {
        velocity = transform.forward  * power;
        velocity.y += 300.0f;
        GetComponent<Rigidbody>().AddForce(velocity);
	}

    void FixedUpdate()
    {
        if (this.transform.position.y < 0.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("cannon OnTriggerEnter");
        AudioManager.Instance().PlaySfx(clip);

        GameObject particleObj = (GameObject)Instantiate(myParticle);
        particleObj.transform.position = transform.position;
        Destroy(particleObj, 1.0f);
        Destroy(gameObject, clip.length);
    }
}
