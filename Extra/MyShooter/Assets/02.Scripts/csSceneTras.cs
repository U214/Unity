using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class csSceneTras : MonoBehaviour {

    public GameObject title;

	void Start () {
        StartCoroutine(showTitle());
        StartCoroutine(SceneTrans());
    }

    IEnumerator showTitle()
    {
        while (true)
        {
            title.SetActive(true);
            yield return new WaitForSeconds(0.4f);

            title.SetActive(false);
            yield return new WaitForSeconds(0.3f);
        }
    }

    IEnumerator SceneTrans()
    {
        while (true)
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene("Game");
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
