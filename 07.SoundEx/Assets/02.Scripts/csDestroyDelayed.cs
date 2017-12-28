using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csDestroyDelayed : MonoBehaviour {

    private AudioSource myAudio;

	// Use this for initialization
	void Start () {
        myAudio = GetComponent<AudioSource>();
	}

    void OnCollisionEnter(Collision collision)
    {
        myAudio.Play();

        Destroy(this.gameObject, myAudio.clip.length);
    }
}
