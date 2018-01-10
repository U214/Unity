using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

    public static bool gamePause = false;

    void Start()
    {
        GameObject.Find("Pause").SetActive(false);
    }

    public void PressPauseButton()
    {
        if (gamePause)
        {
            gamePause = false;
            GameObject.Find("Canvas").transform.FindChild("Pause").gameObject.SetActive(false);
        } else
        {
            if (!GameObject.Find("Player").gameObject.GetComponent<PlayerState>().isDead)
            {
                gamePause = true;
                GameObject.Find("Canvas").transform.FindChild("Pause").gameObject.SetActive(true);
            }
        }
    }

}
