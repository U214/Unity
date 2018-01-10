using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iTweenScaleRotateTest : MonoBehaviour {

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            transform.localScale = Vector3.zero;

            Hashtable hash1 = new Hashtable();

            hash1.Add("x", 1.0f);
            hash1.Add("y", 1.0f);
            hash1.Add("z", 1.0f);
            hash1.Add("speed", 1.5f);
            hash1.Add("easetype", iTween.EaseType.easeOutQuart);
            hash1.Add("looptype", iTween.LoopType.none);

            iTween.ScaleTo(gameObject, hash1);

            Hashtable hash2 = new Hashtable();

            hash2.Add("rotation", new Vector3(0.0f, 1080.0f, 0.0f));
            hash2.Add("delay", 0.3f); // 이걸로 시퀀스활용
            hash2.Add("time", 3.0f);
            hash2.Add("easetype", iTween.EaseType.easeOutExpo);
            hash2.Add("looptype", iTween.LoopType.none);

            iTween.RotateTo(gameObject, hash2);
        }
    }
}
