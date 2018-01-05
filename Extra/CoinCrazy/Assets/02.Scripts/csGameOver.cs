using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class csGameOver : MonoBehaviour {

	public void GameOver()
    {
        GameObject.Find("GenericMan").GetComponent<csPlayerController>().playerDestroy();
        GameObject.Find("Hp").SetActive(false);
        GameObject.Find("Score").SetActive(false);
        GameObject.Find("Canvas").transform.FindChild("GameoverLogo").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.FindChild("FinalScore").gameObject.SetActive(true);
        GameObject.Find("FinalScore").GetComponent<Text>().text = "SCORE : " + GetComponent<csScore>().score;
        GameObject.Find("Canvas").transform.FindChild("GameoverText").gameObject.SetActive(true);

        StartCoroutine("newGame");
    }

    IEnumerator newGame()
    {
        yield return new WaitForEndOfFrame();

        if (Input.anyKey)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
