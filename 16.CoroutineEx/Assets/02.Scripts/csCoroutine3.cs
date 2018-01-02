using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCoroutine3 : MonoBehaviour {

    // 비동기 작업이 끝날 때 까지 대기

    public string url;
    WWW www;

    bool isDownlading = false;

    IEnumerator Start()
    {
        www = new WWW(url);
        StartCoroutine("CheckProgress");
        yield return www;
        Debug.Log("Download Completed!");
    }

    IEnumerator CheckProgress()
    {
        Debug.Log("A : " + www.progress);

        while(!www.isDone)
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log("B : " + www.progress);
        }
    }
}
