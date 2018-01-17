using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csBridge : MonoBehaviour
{

    public GameObject[] bridges;
    public GameObject[] coins;
    public GameObject bridgeTurn;   // 교차로

    GameObject newBridge;           // 새로 만들 다리(부모)
    GameObject childBridge;         // 각각의 다리(자식)
    GameObject oldBridge;           // 삭제할 예전의 다리

    GameObject bridge;              // 다리 종류
    GameObject coin;                // 동전셋 종류
    bool canCoin = false;           // 동전 만들기

    int dir = 0;                    // 주인공의 회전 방향(0~3, 12시 3시 6시 9시)
    Quaternion quatAng;             // 주인공의 회전각

    void Start()
    {
        newBridge = GameObject.Find("StartBridge");
        oldBridge = GameObject.Find("OldBridge");
        childBridge = newBridge;

        MakeBridge("FORWARD");
    }

    // 다리 만들기
    void MakeBridge(string sDir)
    {
        DeleteOldBridge();
        CalcRotation(sDir);
        MakeNewBridge();
    }

    // 지나간 다리 삭제
    void DeleteOldBridge()
    {
        Destroy(oldBridge);     // 예전 다리 삭제
        oldBridge = newBridge;  // 현재의 다리 저장

        // 다리 시작점 만들기
        newBridge = new GameObject("StartBridge");
    }

    // 회전 방향과 각도 계산
    void CalcRotation(string sDir)
    {
        switch (sDir)
        {
            case "LEFT": dir--; break;      // 왼쪽으로 회전
            case "RIGHT": dir--; break;      // 왼쪽으로 회전
        }

        if (dir < 0) dir = 3;       // 회전 방향을 0~3으로 제한
        if (dir > 3) dir = 0;

        // 회전각을 쿼터니언으로 변환
        quatAng.eulerAngles = new Vector3(0, dir * 90, 0);
    }

    // 새로운 다리 만들기
    void MakeNewBridge()
    {
        for (int i = 0; i < 10; i++)
        {
            bridge = bridges[0];                // 기본 다리
            coin = coins[Random.Range(0, 3)];   // 동전 셋
            canCoin = false;

            SelectBridge(i);                    // 다리 종류 설정

            Vector3 pos = Vector3.zero;         // 다리 위치

            // 다리의 localPosition
            Vector3 localPos = childBridge.transform.localPosition;

            switch (dir)
            {
                case 0:
                    pos = new Vector3(localPos.x, 0, localPos.z + 10);
                    break;
                case 1:
                    pos = new Vector3(localPos.x + 10, 0, localPos.z);
                    break;
                case 2:
                    pos = new Vector3(localPos.x, 0, localPos.z - 10);
                    break;
                case 3:
                    pos = new Vector3(localPos.x - 10, 0, localPos.z);
                    break;
            }

            // 새로운 다리 만들기
            childBridge = Instantiate(bridge, pos, quatAng) as GameObject;
            childBridge.transform.parent = newBridge.transform;

            if (canCoin)
            {
                childBridge = Instantiate(coin, pos, quatAng) as GameObject;
                childBridge.transform.parent = newBridge.transform;
            }
        }
    }

    // 다리 종류 설정
    void SelectBridge(int n)
    {
        switch (n)
        {
            case 9:             // 교차로
                bridge = bridgeTurn;
                break;
            case 1:             // 홀수는 장애물 있는 다리
            case 3:
            case 5:
            case 7:
                bridge = bridges[Random.Range(0, bridges.Length)];
                break;
            default:            // 짝수는 동전 있는 다리
                if (Random.Range(0, 100) > 50)
                {
                    canCoin = true;
                }
                break;
        }
    }
}
