using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csDistance : MonoBehaviour {

    public Transform box1;
    public Transform box2;
    public Transform box3;

    void Start()
    {
        // 두 오브젝트 사이의 거리 구하기 1
        float distance1 = Vector3.Distance(transform.position, box2.position);
        Debug.Log("distance1 : " + distance1);

        // 두 오브젝트 사이의 거리 구하기 2 (타겟은 항상 앞에 있어야 함)
        float distance2 = (box3.position - transform.position).magnitude;
        Debug.Log("distance2 : " + distance2);

        // 방향 구하기
        Vector3 dir = box2.position - transform.position;
        dir.Normalize();

        // 회전
        transform.eulerAngles = dir;
    }
}
