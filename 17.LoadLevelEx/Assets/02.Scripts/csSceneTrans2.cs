using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class csSceneTrans2 : MonoBehaviour {

    public void SceneTrans2_1()
    {
        Application.LoadLevel("03-Scene2-1");
    }

    public void SceneTrans2_2()
    {
        Application.LoadLevel("04-Scene2-2");
    }

    void Awake()
    {
        Debug.Log("Awake : " + EditorApplication.currentScene);
    }

    void OnEnable()
    {
        Debug.Log("OnEnable : " + EditorApplication.currentScene);
    }

    void Start()
    {
        Debug.Log("Start : " + EditorApplication.currentScene);
    }

    void Fixedupdate()
    {

    }

    void Update()
    {

    }

    void OnGUI()
    {

    }

    void OnDisable()
    {
        Debug.Log("OnDisable : " + EditorApplication.currentScene);
    }

    void OnDestroy()
    {
        Debug.Log("OnDestroy : " + EditorApplication.currentScene);
    }
} 
