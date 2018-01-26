using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public Transform[] sp;

	void Start () {
        sp = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();

        PhotonNetwork.isMessageQueueRunning = true;
        StartCoroutine(this.CreateTank());
	}
	
	IEnumerator CreateTank()
    {
        int idx = Random.Range(1, sp.Length);

        PhotonNetwork.Instantiate(
            "Tank",
            sp[idx].position,
            Quaternion.identity,
            0);

        yield return null;
    }
}
