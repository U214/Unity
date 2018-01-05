using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csScore : MonoBehaviour {

    public int score;
    public int hp;
    bool isGameOver = false;

    void Start()
    {
        score = 0;
        hp = 100;

        GameObject.Find("Canvas").transform.FindChild("Hp").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.FindChild("Score").gameObject.SetActive(true);
        GameObject.Find("GameoverLogo").SetActive(false);
        GameObject.Find("FinalScore").SetActive(false);
        GameObject.Find("GameoverText").SetActive(false);
    }

    public void UpdateInfo()
    {
        GameObject.Find("Hp").GetComponent<Text>().text = "HP : " + hp;
        GameObject.Find("Score").GetComponent<Text>().text = "SCORE : " + score;
    }

    void Update()
    {
        if ((hp <= 0) && !isGameOver)
        {
            isGameOver = true;
            GetComponent<csGameOver>().GameOver();
        }
    }
}
