using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCoin : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name == "GenericMan")
        {
            Debug.Log("Coin : OnCollisionEnter");

            CollisionObj();
        }
    }

    public void CollisionObj()
    {
        GetComponent<csParticle>().makeParticle();
        GameObject.Find("GameManager").GetComponent<csScore>().score++;
        GameObject.Find("GameManager").GetComponent<csScore>().UpdateInfo();
        Destroy(gameObject);
    }
}
