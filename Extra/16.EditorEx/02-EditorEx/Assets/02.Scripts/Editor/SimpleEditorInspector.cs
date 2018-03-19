using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// SimpleEditor 스크립트를 커스텀에디터로 사용하겠다
// Monobehaviour가 아닌 Editor를 상속받음
[CustomEditor(typeof(SimpleEditor))]
public class SimpleEditorInspector : Editor {

    bool myListFold1 = false;
    bool myListFold2 = false;
    bool myListFold3 = false;

    public override void OnInspectorGUI()
    {
        SimpleEditor se = target as SimpleEditor;

        se.showButton = EditorGUILayout.Toggle("Show Button", se.showButton);

        if (se.showButton)
        {
            GUILayout.Button("Show Button");
        }

        DrawSeparator(Color.gray);
        // 일반 변수
        se.age = EditorGUILayout.IntField("Age", se.age);
        se.height = EditorGUILayout.FloatField("Height", se.height);
        se.userName = EditorGUILayout.TextField("UserName", se.userName);
        se.bloodType = (BLOODTYPE)EditorGUILayout.EnumPopup("BloodType", se.bloodType);

        DrawSeparator(Color.gray);

        // 오브젝트 형태의 변수
        GUI.backgroundColor = (se.cameraObject != null) ?
                                Color.green : Color.red;
        se.cameraObject = (GameObject)EditorGUILayout.ObjectField(
            "Camera Object",
            se.cameraObject,
            typeof(GameObject), true);
        GUI.backgroundColor = Color.white;
        GUI.color = (se.myTransform != null) ?
                    Color.green : Color.red;
        se.myTransform = (Transform)EditorGUILayout.ObjectField(
            "My Tansform",
            se.myTransform,
            typeof(Transform),
            true);
        GUI.color = Color.white;

        DrawSeparator(Color.gray);

        if (myListFold1 = EditorGUILayout.Foldout(myListFold1, "MyList"))
        {
            // Generic 형태의 변수
            for (int i = 0; i < se.myList.Count; i++)
            {
                string fieldName = "My List " + i;
                se.myList[i] =
                    EditorGUILayout.IntField(fieldName, se.myList[i]);
            }

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Add"))
            {
                se.myList.Add(0);
            }
            if (GUILayout.Button("Remove"))
            {
                if (se.myList.Count > 0)
                    se.myList.RemoveAt(se.myList.Count - 1);
            }
            EditorGUILayout.EndHorizontal();
        }

        DrawSeparator(Color.gray);

        if (myListFold2 = EditorGUILayout.Foldout(myListFold2, "Array Float"))
        {
            // 배열 형태의 변수
            for (int i = 0; i < se.arrayFloat.Length; i++)
            {
                string fieldName = "array float " + i;
                se.arrayFloat[i] =
                    EditorGUILayout.FloatField(fieldName, se.arrayFloat[i]);
            }
        }

        DrawSeparator(Color.gray);

        if (myListFold3 = EditorGUILayout.Foldout(myListFold3, "Array Vector"))
        {
            for (int i = 0; i < se.arrayVector.Length; i++)
            {
                string fieldName = "array vector " + i;
                se.arrayVector[i] =
                    EditorGUILayout.Vector3Field(fieldName, se.arrayVector[i]);
            }
        }

        EditorGUILayout.Space();
    }

    void DrawSeparator(Color color)
    {
        EditorGUILayout.Space();

        Texture2D tex = new Texture2D(1, 1);
        GUI.color = color;
        float y = GUILayoutUtility.GetLastRect().yMax;
        GUI.DrawTexture(new Rect(0.0f, y, Screen.width, 1.0f), tex);
        tex.hideFlags = HideFlags.DontSave;
        GUI.color = Color.white;

        EditorGUILayout.Space();
    }
}
