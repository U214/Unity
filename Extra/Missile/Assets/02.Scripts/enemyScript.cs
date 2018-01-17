using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyScript : MonoBehaviour {
    public GameObject mini_enemy;
    public GameObject enemy;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        enemy = (GameObject)Instantiate(mini_enemy);
        enemy.transform.SetParent(GameObject.Find("MiniMap").transform);
        enemy.SetActive(false);

        Vector3[] path = new Vector3[2];

        if (player.transform.position.x > transform.position.x)
        {
            path[0] = new Vector3(
            player.transform.position.x - 300,
            player.transform.position.y + 20,
            player.transform.position.z + 400);

            path[1] = new Vector3(
                player.transform.position.x + 200,
                player.transform.position.y - 20,
                player.transform.position.z - 20);
        } else
        {
            path[0] = new Vector3(
            player.transform.position.x + 300,
            player.transform.position.y + 20,
            player.transform.position.z + 400);

            path[1] = new Vector3(
                player.transform.position.x - 200,
                player.transform.position.y - 20,
                player.transform.position.z - 20);
        }

        Hashtable hash = new Hashtable();

        hash.Add("path", path);
        hash.Add("movetopath", true);
        hash.Add("orienttopath", true);
        hash.Add("time", 40.0f);

        iTween.MoveTo(gameObject, hash);
    }

    void Update()
    {
        if ((transform.position.z <= player.transform.position.z + 400) ||
            (transform.position.z >= player.transform.position.z - 400) ||
            (transform.position.x <= player.transform.position.x + 400) ||
            (transform.position.x >= player.transform.position.x - 400))
        {

            enemy.SetActive(true);

            enemy.transform.localPosition = new Vector3(
                ((transform.position.x - player.transform.position.x) / 9.09f),
                ((transform.position.z - player.transform.position.z) / 9.09f),
                0);
        } else
        {
            enemy.SetActive(false);
        }

        if (transform.position.z < player.transform.position.z)
        { 
            Destroy(enemy);
            Destroy(gameObject);
        }
    }
}
