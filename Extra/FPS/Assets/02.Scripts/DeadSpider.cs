using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSpider : MonoBehaviour {

    public float downSpeed = 0.5f;

    void Start () {
        StartCoroutine(DeadProcess());	
	}
	
	IEnumerator DeadProcess()
    {
        yield return new WaitForSeconds(2.0f);

        while (transform.position.y > -2.0f)
        {
            Vector3 temp = transform.position;
            temp.y -= downSpeed * Time.deltaTime;
            transform.position = temp;

            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
