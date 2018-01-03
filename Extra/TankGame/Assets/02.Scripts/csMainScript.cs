using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csMainScript : MonoBehaviour {

    public GameObject player;
    public GameObject enemy;

    void OnGUI()
    {
        GUILayout.Label("Player HP : " + player.GetComponent<csDestroy>().hp 
            + "    Enemy HP : " + enemy.GetComponent<csDestroy>().hp);
    }
}
