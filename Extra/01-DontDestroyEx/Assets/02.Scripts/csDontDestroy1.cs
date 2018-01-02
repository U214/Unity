using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csDontDestroy1 : MonoBehaviour {

	void Awake()
    {
        // 새로운 씬을 로드할 때 객체가 사라지지 않는다
        // 유니티에서 싱글톤 대용
        DontDestroyOnLoad(gameObject);
    }
}
