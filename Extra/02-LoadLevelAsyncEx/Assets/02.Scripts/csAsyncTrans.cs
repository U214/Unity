using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class csAsyncTrans : MonoBehaviour {
    Text txt;
    Slider slider;

    void Start()
    {
        txt = GameObject.Find("txtPercent").GetComponent<Text>();
        slider = GameObject.Find("Slider").GetComponent<Slider>();

        StartCoroutine(LoadNext());
    }

    IEnumerator LoadNext()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("03-Second");

        while(!async.isDone)
        {
            float progress = async.progress * 100.0f;
            int pRounded = Mathf.RoundToInt(progress);

            txt.text = "Loading ... " + pRounded.ToString() + "%";
            slider.value = pRounded;

            yield return true;
        }
    }
}
