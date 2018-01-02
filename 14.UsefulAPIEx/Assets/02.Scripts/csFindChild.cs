using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csFindChild : MonoBehaviour {

    public Transform[] myChilds;

	void Start () {
        int randomSeedS;
        randomSeedS = (int)System.DateTime.Now.Ticks;
        Random.InitState(randomSeedS);

        myChilds = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();

        // 인덱스0은 부모(자기자신)
        int idx = Random.Range(1, myChilds.Length);

        Debug.Log("SpawnPoint.Length : " + myChilds.Length);
        Debug.Log("Random.Range : " + idx);

        for (int i = 0; i < myChilds.Length; i++)
        {
            Debug.Log(myChilds[i].gameObject.name);
        }
    }
}
