using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csEnemy : MonoBehaviour {

    enum ENEMYTYPE
    {
        DIRECT = 0,
        SLASH,
        FOLLOW
    }

    public int type;
    Vector3 spawnPos;
    public float moveSpeed = 0.5f;
    public GameObject explosionPrefab;
    public GameObject laserPrefab;

    float shootDelay = 0.5f;
    float shootTimer = 0.0f;

    int killScore = 100;

    void Awake()
    {
        this.spawnPos = transform.position;
    }

    void Update()
    {
        MoveEnemy();
        ShootLaser();
    }

    void MoveEnemy()
    {
        if (transform.position.y < -0.9)
        {
            Destroy(gameObject);
        }
        else
        {
            float yMove = moveSpeed * Time.deltaTime;
            float xMove = moveSpeed * Time.deltaTime / 2.5f;

            switch ((ENEMYTYPE)type)
            {
                case ENEMYTYPE.DIRECT:
                    transform.Translate(0, -yMove, 0);
                    break;
                case ENEMYTYPE.SLASH:
                    if (spawnPos.x <= 0)
                    {
                        transform.Translate(xMove, -yMove, 0);
                    } else
                    {
                        transform.Translate(-xMove, -yMove, 0);
                    }
                    break;
                case ENEMYTYPE.FOLLOW:
                    float targetXPos = GameObject.Find("Player").gameObject.transform.position.x;
                    if (targetXPos < transform.position.x)
                    {
                        transform.Translate(-xMove, -yMove, 0);
                    } else if (targetXPos > transform.position.x)
                    {
                        transform.Translate(xMove, -yMove, 0);
                    } else
                    {
                        transform.Translate(0, -yMove, 0);
                    }
                    break;
            }
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if ((col.gameObject.tag == "Player") ||
            (col.gameObject.tag == "Laser") && col.gameObject.GetComponent<csLaser>().type.Equals("Player"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            SoundManager.instance.PlaySound();

            Destroy(col.gameObject);
            Destroy(gameObject);

            if (col.gameObject.tag == "Player")
            {
                GameManager.instance.GameOver();
            } else
            {
                GameManager.instance.AddScroe(killScore);
            }
        } 
    }

    void ShootLaser()
    {
        if (shootTimer > shootDelay)
        {
            GameObject obj = (GameObject)Instantiate(laserPrefab, transform.position, Quaternion.identity);
            obj.transform.parent = gameObject.transform;
            obj.GetComponent<csLaser>().type = "Enemy";
            shootTimer = 0.0f;
        }

        shootTimer += Time.deltaTime;
    }
}
