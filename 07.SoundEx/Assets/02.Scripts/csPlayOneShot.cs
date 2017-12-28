using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csPlayOneShot : MonoBehaviour {

    public AudioClip clip;

    void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().PlayOneShot(clip, 0.8f);
    }
}
