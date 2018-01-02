using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class csSceneTrans4 : MonoBehaviour {

    // 이건 씬을 교체하는게 아니라 삽입하는 것이다

//    하나의 기본 씬에 여러 개의 씬을 붙여서 큰 맵을 구성할 때 사용할 수 있다.
//    캐릭터의 이동에 따라 지나간 곳은 씬을 제거하고 다가오는 곳은 씬을 추가.
//    여러 명이 공동작업을 할 때 씬을 나누어서 작업할 수 있다.

    public void AddScene()
    {
        SceneManager.LoadScene("08-Scene4-2", LoadSceneMode.Additive);
    }

    public void RemoveScene()
    {
        SceneManager.UnloadScene("08-Scene4-2");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
