using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iTweenRotateTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Hashtable hash = new Hashtable();

            hash.Add("rotation", new Vector3(0.0f, 720.0f, 0.0f));
            hash.Add("tsime", 3.0f);
            hash.Add("easetype", iTween.EaseType.easeOutExpo);
            hash.Add("looptype", iTween.LoopType.none);

            iTween.RotateTo(gameObject, hash);
        }
    }
}
