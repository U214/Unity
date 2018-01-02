using System.Collections;
using UnityEngine;

public class csCoroutine2 : MonoBehaviour {

    // 비동기 작업이 끝날 때 까지 대기

    public string url;
    WWW www;

    bool isDownlading = false;

    IEnumerator Start()
    {
        www = new WWW(url);
        isDownlading = true;
        yield return www;
        isDownlading = false;
        Debug.Log("Download Completed!");
    }

    void Update()
    {
        if (isDownlading)
        {
            Debug.Log(www.progress);
        }
    }
}
