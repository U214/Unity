using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csCollisionCheck : MonoBehaviour {

    public GameObject Aim;
    public GameObject missile;

    Transform enemyTrans;
    bool isCollision = false;

	void Update () {
        Vector3 newPOs = Camera.main.WorldToScreenPoint(gameObject.transform.parent.transform.position);
        Aim.transform.position = new Vector3(newPOs.x, newPOs.y + 50, 1);

        if (isCollision)
        {
            Aim.GetComponent<Image>().color = Color.red;

            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("공격");
                GameObject obj = (GameObject)Instantiate(missile);
                obj.transform.position = gameObject.transform.parent.transform.position;
                obj.GetComponent<csMissile>().target = enemyTrans;
            }
        }
        else
        {
            Aim.GetComponent<Image>().color = Color.black;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter" + other.gameObject.name);
        enemyTrans = other.gameObject.transform;
        StartCoroutine(collision(other.gameObject.transform));
    }

    IEnumerator collision(Transform enemyTrans)
    {
        isCollision = true;

        yield return new WaitForSeconds(1.5f);

        isCollision = false;
    }
}
