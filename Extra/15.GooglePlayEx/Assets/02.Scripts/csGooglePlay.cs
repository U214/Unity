﻿using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using GooglePlayGames;

public class csGooglePlay : MonoBehaviour
{

    bool bWaitingForAuth = false;
    Rect imageRect = new Rect(20f, 20f, 200f, 200f);
    bool bImageLoad = false;

    public Text btnText;
    public Text myLog;
    public Image myImage;

    static long myScore = 100;
    static long myTime = 90000;

    void Start()
    {
        btnText.text = "Sign In";
        myLog.text = "Ready...";

        GooglePlayGames.PlayGamesPlatform.Activate();

        doAutoLogin();
    }

    void doAutoLogin()
    {
        if (bWaitingForAuth)
        {
            return;
        }

        if (!Social.localUser.authenticated)
        {
            // Authenticate
            myLog.text = "Authenticating...";
            bWaitingForAuth = true;
            Social.localUser.Authenticate((bool success) => {
                bWaitingForAuth = false;
                if (success)
                {
                    myLog.text = "Welcome " + Social.localUser.userName;
                    btnText.text = "Sign Out";
                }
                else
                {
                    myLog.text = "Authentication failed.";
                }
            });
        }
    }

    public void doMyLogin()
    {
        myLog.text = "...";

        if (!Social.localUser.authenticated)
        {
            Social.localUser.Authenticate((bool success) => {
                if (success)
                {
                    myLog.text = "Welcome " + Social.localUser.userName;
                    btnText.text = "Sign Out";
                }
                else
                {
                    myLog.text = "Authentication failed.";
                    btnText.text = "Sign In";
                }
            });
        }
        else
        {
            // Sign out!
            myLog.text = "Signing out.";
            btnText.text = "Sign In";
            bImageLoad = false;
            ((PlayGamesPlatform)Social.Active).SignOut();
        }
    }

    // 업적(1회성)
    public void doAchievementOne()
    {
        myLog.text = "doAchievementOne called...";

        string unLock_id = "CgkI8Z724-QeEAIQAQ";
        Social.ReportProgress(unLock_id, 100.0f, (bool success) => { myLog.text = "Dod"; });

    }

    // 업적(단계별)
    public void doAchievementStep()
    {
        myLog.text = "doAchievementStep called...";

        string unLockAchievement_id = "CgkI8Z724-QeEAIQAg";

        Social.ReportProgress(unLockAchievement_id, 100.0f, (bool success) => {
            // handle success or failure
            myLog.text = "doAchievementStep ReportProgress...";
        });
    }

    // 업적보기
    public void doAchievementShow()
    {
        myLog.text = "doAchievementShow called...";
        Social.ShowAchievementsUI();
    }

    // 리더보드(소요시간)
    public void doLeaderboardTime()
    {
        string leader_board_id = "";
#if UNITY_ANDROID
        leader_board_id = "CgkI8Z724-QeEAIQAw";
#elif UNITY_IPHONE
        leader_board_id = "SOCIALTEST_HIGH_SCORE";
#endif

        Social.ReportScore(myTime, leader_board_id,
            (bool success) =>
            {
#if UNITY_ANDROID
                PlayGamesPlatform.Instance.ShowLeaderboardUI(leader_board_id);
#elif UNITY_IPHONE
                Social.ShowLeaderboardUI();
#endif
            }
        );

        myTime -= 1000;
    }

    // 리더보드(최고점수)
    public void doLeaderboardPoint()
    {
        string leader_board_id = "";
#if UNITY_ANDROID
        leader_board_id = "CgkI8Z724-QeEAIQAw";
#elif UNITY_IPHONE
        leader_board_id = "SOCIALTEST_HIGH_SCORE";
#endif

        Social.ReportScore(myScore, leader_board_id,
            (bool success) =>
            {
#if UNITY_ANDROID
                PlayGamesPlatform.Instance.ShowLeaderboardUI(leader_board_id);
#elif UNITY_IPHONE
                Social.ShowLeaderboardUI();
#endif
            }
        );

        myScore += 100;
    }

    // 리더보드 보기
    public void doLeaderboardShow()
    {
        myLog.text = "doLeaderboardShow called...";
        Social.ShowLeaderboardUI();
    }

    //    void OnGUI() 
    //    {
    //        if (Social.localUser.authenticated) {
    //            if (Social.localUser.image != null) {
    //                GUI.DrawTexture(imageRect, Social.localUser.image,
    //                    ScaleMode.ScaleToFit);
    //            }
    //        }
    //    }

    void Update()
    {

        if (bImageLoad == false)
        {
            if (Social.localUser.authenticated)
            {
                if (Social.localUser.image != null)
                {
                    Texture2D tex = Social.localUser.image;
                    Rect rec = new Rect(0, 0, tex.width, tex.height);
                    Sprite newSprite = Sprite.Create(tex, rec, new Vector2(0.5f, 0.5f), 100);

                    myImage.sprite = newSprite;
                    //myImage.sprite = Social.localUser.image;

                    bImageLoad = true;
                }
            }
        }
    }

}
