using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iTweenPathTest : MonoBehaviour {

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Hashtable hash = new Hashtable();
            Vector3[] arr = iTweenPath.GetPath("MyPath1");
            arr[0] = new Vector3(5.0f, 5.0f, 5.0f);
            hash.Add("path", iTweenPath.GetPath("MyPath1"));
            hash.Add("movetopath", true);
            hash.Add("orienttopath", true);
            hash.Add("looktime", 1.0f);
            hash.Add("time", 10.0f);
            hash.Add("easetype", iTween.EaseType.easeInOutExpo);
            hash.Add("looptype", iTween.LoopType.none);
            hash.Add("islocal", true);

            hash.Add("onstart", "ItweenStart");
            hash.Add("onstarttarget", gameObject);

            hash.Add("onupdate", "ItweenUpdate");
            hash.Add("onupdatetarget", gameObject);

            hash.Add("oncomplete", "ItweenComplete");
            hash.Add("oncompletetarget", gameObject);

            hash.Add("ignoretimescale", true);

            iTween.MoveTo(gameObject, hash);
        }
    }

    void ItweenStart()
    {
        Debug.Log("Tween Start : " + Time.realtimeSinceStartup);
    }

    void ItweenUpdate()
    {
        Debug.Log("Tween Update : " + Time.realtimeSinceStartup);
    }

    void ItweenComplete()
    {
        Debug.Log("Tween Complete : " + Time.realtimeSinceStartup);
    }
}
