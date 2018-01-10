using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csMissile : MonoBehaviour
{

    public Transform target;
    public float Speed = 0.1f;

    void Update()
    {
        MissileControl4();
    }

    void MissileControl1()
    {
        Vector3 Dir = target.position - transform.position;
        Dir.Normalize();

        Quaternion qtn = Quaternion.identity;
        qtn.SetLookRotation(Dir);

        transform.rotation = qtn;
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    void MissileControl2()
    {
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    // 여기부터 선형보간
    void MissileControl3()
    {
        // 방향 벡터 구하기
        Vector3 Dir = transform.position - target.position;

        // 외적, Axis 축 구하기
        Vector3 Axis = Vector3.Cross(Dir, transform.forward);

        // Quaternion.AngleAxis(angle, Axis)
        // angle - 휘는 각도( 높을수록 정확도 나옴)
        // Axis - 축
        Quaternion NewRotation =
            Quaternion.AngleAxis(Time.deltaTime * 45, Axis) * transform.rotation;

        // 부드럽게 회전 - 안하면 각져보임
        transform.rotation = Quaternion.Lerp(transform.rotation, NewRotation, 50.0f * Time.deltaTime);

        // 초당 속도로 앞으로 이동
        Vector3 Pos = Vector3.forward * Time.deltaTime * 2.0f;
        transform.Translate(Pos);
    }

    void MissileControl4()
    {
        Vector3 Dir = target.position - transform.position;
        Dir.Normalize();

        Quaternion targetQtn = Quaternion.LookRotation(Dir);

        // 부드럽게 회전
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetQtn,
            1.0f * Time.deltaTime);

        // 초당 속도로 앞으로 이동
        Vector3 Pos = Vector3.forward * Time.deltaTime * 2.0f;
        transform.Translate(Pos);
    }
}
