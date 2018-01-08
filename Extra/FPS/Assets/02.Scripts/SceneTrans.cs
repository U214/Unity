using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrans : MonoBehaviour
{
    public void PressPlayBtn()
    {
        SceneManager.LoadScene("Game");
    }
}