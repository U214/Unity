using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csGameManager2 : MonoBehaviour {

    static csGameManager2 _instance = null;

    public static csGameManager2 Instance()
    {
        return _instance;
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("aaaaa");
        }
        else
        {
            Debug.Log("bbbbb");
            if (this != _instance)
            {
                Destroy(gameObject);
                Debug.Log("ccccc");
            } else
            {
                Debug.Log("ddddd");
            }
        }
    }
}
