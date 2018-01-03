using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csSoundManager : MonoBehaviour {

    AudioClip clip1;
    AudioClip clip2;
    AudioClip clip3;

    void Start()
    {
        clip1 = Resources.Load("A1") as AudioClip;
        clip2 = Resources.Load("A2") as AudioClip;
        clip3 = Resources.Load("B1") as AudioClip;
    }
} 
