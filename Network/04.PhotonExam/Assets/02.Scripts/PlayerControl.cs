using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class PlayerControl : MonoBehaviour {

    public float speed = 5.0f;
    public float rotSpeed = 120.0f;

    private Transform tr;
    private PhotonView pv;

    public Material[] _material;

    private Vector3 currPos;
    private Quaternion currRot;

    public Transform firePos;
    public GameObject bullet;

    void Start () {
        tr = GetComponent<Transform>();
        pv = GetComponent<PhotonView>();

        if (pv.isMine)
        {
            // 자신의 플레이어에만 카메라 제어권 연결
            Camera.main.GetComponent<SmoothFollow>().target = tr;
            this.GetComponent<Renderer>().material = _material[0];
        } else
        {
            this.GetComponent<Renderer>().material = _material[1];
        }

        // 동기화 콜백함수가 발생하려면 반드시 지금 스크립트를 연결시켜줘야함
        pv.ObservedComponents[0] = this;
	}
	
	void Update () {
        if (pv.isMine)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            tr.Translate(Vector3.forward * v * Time.deltaTime * speed);
            tr.Rotate(Vector3.up * h * Time.deltaTime * rotSpeed);

            if (Input.GetButtonDown("Fire1"))
            {
                Fire();
            }
        } else
        {
            tr.position = Vector3.Lerp(tr.position, currPos, Time.deltaTime * 10.0f);
            tr.rotation = Quaternion.Lerp(tr.rotation, currRot, Time.deltaTime * 10.0f);
        }
	}

    // 동기화 콜백함수
    void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            // 자신의 플레이 정보는 다른 사용자에게 송신한다
            stream.SendNext(tr.position);
            stream.SendNext(tr.rotation);
        } else
        {
            // 타 플레이어의 정보를 수신한다
            currPos = (Vector3)stream.ReceiveNext();
            currRot = (Quaternion)stream.ReceiveNext();
        }
    }

    void Fire()
    {
        StartCoroutine(this.CreateBullet());
        pv.RPC("FireRPC", PhotonTargets.Others);
    }

    IEnumerator CreateBullet()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
        yield return null;
    }

    [PunRPC]
    void FireRPC()
    {
        StartCoroutine(this.CreateBullet());
    }
}
