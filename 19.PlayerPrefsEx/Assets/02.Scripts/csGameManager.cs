using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class csGameManager : MonoBehaviour {

	void OnGUI()
    {
        if (GUI.Button(new Rect(30, 50, 180, 30), "Set Value"))
        {
            SetData();
        }

        if (GUI.Button(new Rect(30, 100, 180, 30), "Get Value"))
        {
            GetData();
        }
    }

    void SetData()
    {
        PlayerPrefs.SetInt("Score", 100);
        PlayerPrefs.SetString("Name", "홍길동");
    }

    void GetData()
    {
        int myScore = PlayerPrefs.GetInt("Score");
        string myName = PlayerPrefs.GetString("Name", "N/A");

        // 윈도우에서만 가능
        if (EditorUtility.DisplayDialog("알림", "출력할 내용을 선택하세요", "이름", "점수"))
        {
            Debug.Log("Name" + myName);
        } else
        {
            Debug.Log("Score" + myScore);
        }
    }
}
