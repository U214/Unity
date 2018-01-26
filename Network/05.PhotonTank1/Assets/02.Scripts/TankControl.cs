using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class TankControl : MonoBehaviour
{ 
    int moveSpeed = 10;     // (move/s)
    int rotSpeed = 120;     // (anle/s)

    private Transform tr;
    private PhotonView pv;
    public GameObject turret;   // 포탑

    private Vector3 currPos;
    private Quaternion currRot1;
    private Quaternion currRot2;

    public Transform firePos;
    public GameObject cannon;

    public float hp = 100.0f;
    float fireDelay = 1.5f;
    float fireTimer = 0.0f;

    void Awake()
    {
        tr = GetComponent<Transform>();
        pv = GetComponent<PhotonView>();

        // 동기화 콜백함수가 발생하려면 반드시 지금 스크립트를 연결시켜줘야함
        pv.ObservedComponents[0] = this;
        pv.ObservedComponents[1] = this;

        if (pv.isMine)
        {
            // 자신의 플레이어에만 카메라 제어권 연결
            Camera.main.GetComponent<SmoothFollow>().target = tr;
        }
        else
        {
            // 다른 플레이어의 움직임에서 발생하는 물리 계산을 제외시킨다.
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    void Update()
    {
        if (pv.isMine)
        {
            // distance to move for each frame
            float amtMove = moveSpeed * Time.smoothDeltaTime;
            // rotation angle for each frame
            float amtRot = rotSpeed * Time.smoothDeltaTime;

            float keyMove = Input.GetAxis("Vertical");
            float KeyRot = Input.GetAxis("Horizontal");
            float keyTurret = Input.GetAxis("Horizontal2");

            transform.Translate(Vector3.forward * amtMove * keyMove);
            transform.Rotate(Vector3.up * amtRot * KeyRot);
            turret.transform.Rotate(Vector3.up * amtRot * keyTurret);

            if (fireTimer > fireDelay)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Fire();
                    fireTimer = 0.0f;
                }
            }

            fireTimer += Time.deltaTime;
        }
        else
        {
            // 네트워크로 연결된 다른 유저의 경우에는
            // 실시간 전송 받는 변수를 이용해 이동시켜 준다
            tr.position = Vector3.Lerp(tr.position, currPos, Time.deltaTime * 10.0f);
            tr.rotation = Quaternion.Lerp(tr.rotation, currRot1, Time.deltaTime * 10.0f);
            turret.transform.rotation = Quaternion.Lerp(turret.transform.rotation, currRot2, Time.deltaTime * 10.0f);
        }
    }

    void Fire()
    {
        StartCoroutine(this.CreateCannon());
        pv.RPC("FireRPC", PhotonTargets.Others);
    }

    IEnumerator CreateCannon()
    {
        Instantiate(cannon, firePos.position, firePos.rotation);
        yield return null;
    }

    [PunRPC]
    void FireRPC()
    {
        StartCoroutine(this.CreateCannon());
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("onTriggerEnter");
        if (col.GetComponent<Collider>().tag == "CANNON")
        {
            Debug.Log("CANNON");
            Die();
            //hp -= col.gameObject.GetComponent<CannonControl>().damage;
            //if (hp <= 0)
            //{
            //    Die();
            //}
        }
    }

    void Die()
    {
        // Destroy 시키면 Photon에 관련된 연결도 다 끊어진다
        // 그러므로 재사용한다
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;

        foreach (Renderer _renderer in GetComponentsInChildren<Renderer>())
        {
            _renderer.enabled = false;
        }

        StartCoroutine(this.RespawnTank());
    }

    IEnumerator RespawnTank()
    {
        yield return new WaitForSeconds(3.0f);
        hp = 100;
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;

        foreach (Renderer _renderer in GetComponentsInChildren<Renderer>())
        {
            _renderer.enabled = true;
        }

        Transform[] sp;
        sp = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();
        int idx = Random.Range(1, sp.Length);
        this.transform.position = sp[idx].position;
    }

    // 동기화 콜백함수
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            // 자신의 플레이 정보는 다른 사용자에게 송신한다
            stream.SendNext(tr.position);
            stream.SendNext(tr.rotation);
            stream.SendNext(turret.transform.rotation);
        }
        else
        {
            // 타 플레이어의 정보를 수신한다
            currPos = (Vector3)stream.ReceiveNext();
            currRot1 = (Quaternion)stream.ReceiveNext();
            currRot2 = (Quaternion)stream.ReceiveNext();
        }
    }

}
