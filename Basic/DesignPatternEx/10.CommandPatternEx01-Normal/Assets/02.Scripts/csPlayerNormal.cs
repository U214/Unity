using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csPlayerNormal : MonoBehaviour {

    public GameObject shield;
    public GameObject cannon;
    public Transform firePos;
	
	void Update () {
		if (Input.GetKeyDown("a"))
        {
            Attack();
        } else if (Input.GetKeyDown("b"))
        {
            Defense();
        }
	}

    void Attack()
    {
        Debug.Log("Attack");
        Instantiate(cannon, firePos.position, firePos.rotation);
    }

    void Defense()
    {
        Debug.Log("Defense");
        shield.SetActive(true);
        StartCoroutine(Defense(0.5f));
    }

    IEnumerator Defense(float tm)
    {
        yield return new WaitForSeconds(tm);
        shield.SetActive(false);
    }
}
