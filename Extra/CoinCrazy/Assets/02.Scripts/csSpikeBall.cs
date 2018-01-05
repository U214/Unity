using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csSpikeBall : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name == "GenericMan")
        {
            Debug.Log("SpikeBall : OnCollisionEnter");

            CollisionObj();
        }
    }

    public void CollisionObj()
    {
        GetComponent<csParticle>().makeParticle();
        GameObject.Find("GameManager").GetComponent<csScore>().hp -= 10;
        GameObject.Find("GameManager").GetComponent<csScore>().UpdateInfo();
        Destroy(gameObject);
    }
}
