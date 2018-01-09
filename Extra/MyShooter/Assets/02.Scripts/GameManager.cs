using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    int score = 0;
    public bool isGameover = false;
    public Text scoreText;
    public GameObject readyText;
    public GameObject overText;

    void Awake()
    {
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
        }
    }

	void Start () {
        Invoke("StartGame", 3.0f);
        readyText.SetActive(false);
        overText.SetActive(false);
        overText.GetComponentInChildren<Text>().gameObject.SetActive(false);
        StartCoroutine(showReady());
	}
	
	void StartGame()
    {
        csPlayer.canShoot = true;
        csSpawnManager.isSpawn = true;
    }

    public void AddScroe(int score)
    {
        this.score += score;
        scoreText.text = "Score : " + this.score;
    }

    IEnumerator showReady()
    {
        int count = 0;

        while(count < 3)
        {
            readyText.SetActive(true);
            yield return new WaitForSeconds(0.5f);

            readyText.SetActive(false);
            yield return new WaitForSeconds(0.5f);

            count++;
        }
    }

    public void GameOver()
    {
        isGameover = true;
        overText.SetActive(true);
        overText.GetComponentInChildren<Text>().gameObject.SetActive(true);

        StartCoroutine(pressAnykey());
    }

    IEnumerator pressAnykey()
    {
        while (true)
        {
            if (Input.GetButton("Jump"))
            {
                SceneManager.LoadScene("Game");
            }
            yield return new WaitForEndOfFrame();
        }
        //yield return new WaitForSeconds(2.0f);
        //SceneManager.LoadScene("Game");
    }
}
