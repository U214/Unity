using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csDontDestroy2 : MonoBehaviour {

    private static csDontDestroy2 _instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if(_instance == null)
        {
            Debug.Log("1111");
            _instance = this;
        } else
        {
            Debug.Log("2222");
            DestroyObject(gameObject);
        }
    }

}
