using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class csAutoLogin : MonoBehaviour {

    private string mStatusText = "Ready...";
    private bool bWaitingForAuth = false;

    Rect labelRect = new Rect(20, 20, Screen.width, Screen.height * 0.25f);
    Rect imageRect = new Rect(
        Screen.width / 2f - 200f,
        Screen.height / 2f - 200f,
        400f,
        400f);

	void Start () {
        GooglePlayGames.PlayGamesPlatform.Activate();
        doLogin();
	}

    void doLogin()
    {
        if (bWaitingForAuth)
        {
            return;
        }

        if (!Social.localUser.authenticated)
        {
            // Authenticate
            mStatusText = "Authenticating";
            bWaitingForAuth = true;
            Social.localUser.Authenticate((bool success) =>
            {
                bWaitingForAuth = false;
                if (success)
                {
                    mStatusText = "Welcome " + Social.localUser.userName;
                    string token = GooglePlayGames.PlayGamesPlatform.Instance.GetIdToken();
                    Debug.Log(token);
                }
                else
                {
                    mStatusText = "Authentication failed";
                }
            });
        }
    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = (int)(0.05f * Screen.height);
        GUI.Label(labelRect, mStatusText);

        if (Social.localUser.authenticated)
        {
            if (Social.localUser.image != null)
            {
                GUI.DrawTexture(imageRect, Social.localUser.image,
                    ScaleMode.ScaleToFit);
            }
        }
    }
}
