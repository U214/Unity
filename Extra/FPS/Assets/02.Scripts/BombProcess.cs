using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombProcess : MonoBehaviour {

    public GameObject groundExplosionObject;
    public GameObject airExplosionObject;

    public AudioClip clip;

    void Update()
    {
        float y = transform.position.y;
        if (y < 0)
        {
            Destroy(gameObject);
        }
    }

	void OnCollisionEnter (Collision collision)
    {
        //Debug.Log("Collision Object Name : " + collision.gameObject.name);

        AudioManager.Instance().PlaySfx(clip);

        int collisionLayer = collision.gameObject.layer;

        if (collisionLayer == LayerMask.NameToLayer("Ground"))
        {
            GameObject particleObj = (GameObject)Instantiate(groundExplosionObject);
            particleObj.transform.position = transform.position;
        } else
        {
            GameObject particleObj = (GameObject)Instantiate(airExplosionObject);
            particleObj.transform.position = transform.position;
        }

        Destroy(gameObject);
    }
}
