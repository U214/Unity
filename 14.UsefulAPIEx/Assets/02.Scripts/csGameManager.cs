using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csGameManager : MonoBehaviour {

    public GameObject clone;
    public GameObject parent;

    int nName = 0;
    Transform[] SpawnObject;

    void OnGUI ()
    {
        if (GUI.Button(new Rect(10, 10, 80, 50), "Add One"))
        {
            GameObject goTemp = (GameObject)Instantiate(
                clone,
                Vector3.zero,
                Quaternion.identity);
            // 부모를 정해준다
            goTemp.transform.parent = parent.transform;
            goTemp.transform.position = new Vector3(nName, -2, 0);
            goTemp.name = "child_" + nName;
            nName++;
        }

        if (GUI.Button(new Rect(10, 70, 80, 50), "Delete All"))
        {
            SpawnObject = GameObject.Find("Parent").GetComponentsInChildren<Transform>();

            for(int i = 1; i < SpawnObject.Length; i++)
            {
                Destroy(SpawnObject[i].gameObject);
            }
            nName = 0;
        }
    }
}
