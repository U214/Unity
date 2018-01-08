﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour {

    enum SPIDERSTATE
    {
        NONE = -1,
        IDLE = 0,
        MOVE,
        ATTACK,
        DAMAGE,
        DEAD
    }

    SPIDERSTATE spiderState = SPIDERSTATE.IDLE;
    float stateTime = 0.0f;
    public float idleStateMaxTime = 2.0f;

    Transform target;

    public float speed = 5.0f;
    public float rotationSpeed = 10.0f;
    public float attackableRange = 2.5f;

    public float attackStateMaxTime = 2.0f;

    int hp;

    PlayerState playerState;
    CharacterController characterController;

    public GameObject explosionParticle = null;
    public GameObject deadObj = null;

    public int score = 10;

    public AudioClip clip;

    void Awake()
    {
        //spiderState = SPIDERSTATE.IDLE;
        //GetComponent<Animation>().Play("iddle");
        InitSpider();
    }

    void Start()
    {
        target = GameObject.Find("Player").transform;
        characterController = GetComponent<CharacterController>();
        playerState = target.GetComponent<PlayerState>();
    }

    void Update()
    {
        if (PauseScript.gamePause)
        {
            spiderState = SPIDERSTATE.IDLE;
        }

        switch (spiderState)
        {
            case SPIDERSTATE.IDLE:
                stateTime += Time.deltaTime;

                if (stateTime > idleStateMaxTime)
                {
                    stateTime = 0.0f;
                    spiderState = SPIDERSTATE.MOVE;
                }

                break;
            case SPIDERSTATE.MOVE:
                GetComponent<Animation>().Play("walk");

                float distance = (target.position - transform.position).magnitude;

                if (distance < attackableRange)
                {
                    // 공격 가능 범위에 있으면 알아서 공격하는듯
                    spiderState = SPIDERSTATE.ATTACK;
                    // 약간의 시간을 두고 공격하는 문제점 보완
                    stateTime = attackStateMaxTime;
                }
                else
                {
                    Vector3 dir = target.position - transform.position;
                    dir.y = 0.0f;
                    dir.Normalize();
                    characterController.SimpleMove(dir * speed);
                    transform.rotation = Quaternion.Lerp(
                        transform.rotation,
                        Quaternion.LookRotation(dir),
                        rotationSpeed * Time.deltaTime);
                }

                break;
            case SPIDERSTATE.ATTACK:
                stateTime += Time.deltaTime;

                if (stateTime > attackStateMaxTime)
                {
                    stateTime = 0.0f;
                    GetComponent<Animation>().Play("attack_Melee");
                    GetComponent<Animation>().PlayQueued("iddle", QueueMode.CompleteOthers);

                    playerState.DamageByEnemy();
                }

                // 플레이어를 따라가서 공격하는 부분
                float distance1 = (target.position - transform.position).magnitude;

                if (distance1 > attackableRange)
                {
                    spiderState = SPIDERSTATE.MOVE;
                }

                break;
            case SPIDERSTATE.DAMAGE:
                --hp;

                AudioManager.Instance().PlaySfx(clip);

                GetComponent<Animation>()["damage"].speed = 0.5f;
                GetComponent<Animation>().Play("damage");

                GetComponent<Animation>().PlayQueued("iddle", QueueMode.CompleteOthers);

                stateTime = 0.0f;
                spiderState = SPIDERSTATE.IDLE;

                if (hp <= 0)
                {
                    spiderState = SPIDERSTATE.DEAD;
                }

                break;
            case SPIDERSTATE.DEAD:
                //Destroy(gameObject);
                StartCoroutine(DeadProcess());
                spiderState = SPIDERSTATE.NONE;

                ScoreManager.Instance().myScore += score;

                break;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (spiderState == SPIDERSTATE.NONE ||
            spiderState == SPIDERSTATE.DEAD) return;
        // 태그를 이용한 충돌 감지
        //Debug.Log("Tag : " + collision.gameObject.tag);
        //if (collision.gameObject.tag != "Bomb") return;

        // 레이어를 통한 충돌 감지
        int layerIndex = collision.gameObject.layer;
        if (LayerMask.LayerToName(layerIndex) != "Bomb") return;

        spiderState = SPIDERSTATE.DAMAGE;
    }

    IEnumerator DeadProcess()
    {
        GetComponent<Animation>()["death"].speed = 0.5f;
        GetComponent<Animation>().Play("death");

        while(GetComponent<Animation>().isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }

        // 터지는 파티클 효과
        yield return new WaitForSeconds(1.0f);

        GameObject explosionObj = (GameObject)Instantiate(explosionParticle);
        Vector3 explosionObjPos = transform.position;
        explosionObjPos.y = 0.6f;
        explosionObj.transform.position = explosionObjPos;

        // 죽은 오브젝트 교체
        yield return new WaitForSeconds(0.5f);

        GameObject deadObj2 = (GameObject)Instantiate(deadObj);
        Vector3 deadObjPos = transform.position;
        deadObjPos.y = 0.6f;
        deadObj2.transform.position = deadObjPos;

        float rotationY = Random.Range(-180.0f, 180.0f);
        deadObj.transform.eulerAngles = new Vector3(0.0f, rotationY, 0.0f);

        //Destroy(gameObject);
        InitSpider();
        gameObject.SetActive(false);
    }

    void InitSpider()
    {
        hp = 1;
        spiderState = SPIDERSTATE.IDLE;
        GetComponent<Animation>().Play("iddle");
    }
}
