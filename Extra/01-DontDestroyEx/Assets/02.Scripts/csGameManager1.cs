using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csGameManager1 : MonoBehaviour {

    static csGameManager1 _instance = null;

    public static csGameManager1 Instance()
    {
        return _instance;
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            Debug.Log("aaaaa");
        } else
        {
            // 씬 전환에 따라 싱글톤 객체도 사라짐
            Debug.Log("bbbbb");
        }
    }
}
