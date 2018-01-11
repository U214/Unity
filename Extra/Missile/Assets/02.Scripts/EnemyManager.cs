using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject enemy;

    void Start()
    {
        StartCoroutine("Generator");
    }

    IEnumerator Generator()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.0f, 3.0f));

            GameObject obj = (GameObject)Instantiate(enemy);

            int x = Random.Range(-120, 120);
            obj.transform.position = new Vector3(x, 0, 120);
        }
    }

    public void StopGenerator()
    {
        StopCoroutine("Generator");
    }
}
