using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csGenerator : MonoBehaviour {
    public GameObject coin;
    public GameObject spikeBall;

    void Start () {
        Random.InitState((int)System.DateTime.Now.Ticks);

        StartCoroutine("Generator");
    }

    IEnumerator Generator()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.0f, 3.0f));

            Vector3 pos = new Vector3(
                Mathf.Cos(Random.Range(0.0f, Mathf.PI * 2.0f)),
                0,
                Mathf.Sin(Random.Range(0.0f, Mathf.PI * 2.0f))) * 6f;
            pos.y += 2;

            if (Random.Range(1, 10) > 6)
            {
                Instantiate(coin, pos, Quaternion.identity);
            }
            else
            {
                Instantiate(spikeBall, pos, Quaternion.identity);
            }
        }
    }

    public void StopGenerator()
    {
        StopCoroutine("Generator");
    }
}
