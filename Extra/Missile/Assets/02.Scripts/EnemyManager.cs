using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public GameObject player;
    public GameObject enemy;

    void Start()
    {
        StartCoroutine("Generator");
    }

    IEnumerator Generator()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.0f, 2.5f));

            GameObject obj = (GameObject)Instantiate(enemy);

            int x = Random.Range(-300, 300);
            obj.transform.position = new Vector3(x, 30, 400) + player.transform.position;
        }
    }

    public void StopGenerator()
    {
        StopCoroutine("Generator");
    }
}
