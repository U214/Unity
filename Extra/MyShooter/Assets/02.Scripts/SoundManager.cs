using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;
    public AudioClip sndExplosion;
    AudioSource myAudio;

    void Awake()
    {
        if (SoundManager.instance == null)
        {
            SoundManager.instance = this;
        }
    }

	void Start () {
        myAudio = GetComponent<AudioSource>();	
	}

    public void PlaySound()
    {
        myAudio.PlayOneShot(sndExplosion);    
    }
	
}
