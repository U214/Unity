using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject scoreText;

	public void UpdateScore(int score)
    {
        scoreText.GetComponent<Text>().text = "SCORE : " + score;
    }

    public void pressPlayBtn() {
        SceneManager.LoadScene("Game");
    }

    public void pressQuitBtn()
    {
        Application.Quit();
    }
}
