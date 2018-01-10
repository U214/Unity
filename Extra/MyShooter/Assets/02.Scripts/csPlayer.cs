using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csPlayer : MonoBehaviour {

    public float moveSpeed = 0.5f;

    public GameObject laserPrefab;
    public static bool canShoot = false;

    float shootDelay = 0.5f;
    float shootTimer = 0.0f;

	void Update () {
        MovePlayer();
        ShootLaser();
	}

    void MovePlayer()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        transform.Translate(moveX, 0, 0);

        // 뷰포트보다 작거나 큰 쪽으로 플레이어가 움직이지 못하는 부분
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);

        transform.position = worldPos;
    }

    void ShootLaser()
    {
        if (canShoot == true)
        {
            if (shootTimer > shootDelay)
            {
                GameObject obj = (GameObject)Instantiate(laserPrefab, transform.position, Quaternion.identity);
                obj.GetComponent<csLaser>().type = "Player";
                shootTimer = 0.0f;
            }

            shootTimer += Time.deltaTime;
        }
    }
}
