using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csMissile : MonoBehaviour {

    public Transform target;
    public float Speed;
    public GameObject particle;

    void Update()
    {
        if (!target)
        {
            Destroy(gameObject);
        } else
        {
            MissileControl();
        }
    }

    void MissileControl()
    {
        Vector3 Dir = target.position - transform.position;
        Dir.Normalize();

        Quaternion targetQtn = Quaternion.LookRotation(Dir);

        // 부드럽게 회전
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetQtn,
            5.0f * Time.deltaTime);

        // 초당 속도로 앞으로 이동
        Vector3 Pos = Vector3.forward * Time.deltaTime * 200.0f;
        transform.Translate(Pos);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy : OnTriggerEnter");
            GameObject particleObj = (GameObject)Instantiate(particle);
            particleObj.transform.position = transform.position;
            Destroy(other.gameObject);
            Destroy(other.gameObject.GetComponent<enemyScript>().enemy);
            Destroy(gameObject);
        }
    }
}
