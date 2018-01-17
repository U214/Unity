using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_ADS
using UnityEngine.Advertisements;
#endif

public class UnityAdsExample : MonoBehaviour
{

    GameObject obj;
    Text txt;

    void Start()
    {
        obj = GameObject.Find("txtDebug");
        txt = obj.GetComponent<Text>();
    }

    public void ShowDefaultAd()
    {
#if UNITY_ADS
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
#endif
    }

    public void ShowRewardedAd()
    {
#if UNITY_ADS
        if (Advertisement.IsReady())
        {
            ShowOptions options = new ShowOptions();
            options.resultCallback = HandleShowResult;
            Advertisement.Show("rewardedVideo", options);
        }
#endif
    }

#if UNITY_ADS
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown");
                txt.text = "The ad was successfully shown";
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc
                break;

            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                txt.text = "The ad was skipped before reaching the end.";
                break;

            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown");
                txt.text = "The ad failed to be shown";
                break;
        }
    }
#endif
}
