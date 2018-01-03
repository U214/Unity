using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class csSceneTrans : MonoBehaviour
{

    public void SceneTransTo2()
    {
        SceneManager.LoadScene("02-Loading");
    }

    public void SceneTransTo1()
    {
        SceneManager.LoadScene("01-First");
    }
}
