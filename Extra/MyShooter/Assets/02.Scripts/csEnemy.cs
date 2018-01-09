using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csEnemy : MonoBehaviour {

    public float moveSpeed = 0.5f;
    public GameObject explosionPrefab;

    int killScore = 100;

	void Update () {
        MoveEnemy();	
	}

    void MoveEnemy()
    {
        float yMove = moveSpeed * Time.deltaTime;
        transform.Translate(0, -yMove, 0);
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if ((col.gameObject.tag == "Player") ||
            (col.gameObject.tag == "Laser"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            SoundManager.instance.PlaySound();
            GameManager.instance.AddScroe(killScore);

            Destroy(col.gameObject);
            Destroy(gameObject);
        } 
    }
}
