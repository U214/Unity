using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csAudioManager : MonoBehaviour {

    public AudioClip clip;

    void OnCollisionEnter(Collision collision)
    {
        AudioManager.Instance().PlaySfx(clip);
        Destroy(this.gameObject);
    }
}
