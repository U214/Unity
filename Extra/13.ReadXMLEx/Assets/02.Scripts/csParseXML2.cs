using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Text;
using System;

public class csParseXML2 : MonoBehaviour
{

    private static csParseXML2 instance;

    public static csParseXML2 Instance()
    {
        return instance;
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        StartCoroutine(Process());
    }

    IEnumerator Process()
    {
        string m_strName = "XmlData2.xml";
        string strPath = string.Empty;

        // 플랫폼 별로 다르게
#if (UNITY_EDITOR || UNITY_STANDALONE_WIN)
        strPath += ("file:///");
        strPath += (Application.streamingAssetsPath + "/" + m_strName);
#elif UNITY_ANDROID
        strPath = "jar:file://" + Application.dataPath + "!/assets/" + m_strName;
#endif

        WWW www = new WWW(strPath);

        yield return www;

        Interpret(www.text);
    }

    private void Interpret(string _strSource)
    {
        // 인코딩 문제 예외처리
        // 읽은 데이터의 앞 2바이트 제거(BOM제거)
        StringReader stringReader = new StringReader(_strSource);

        // BOM 제거한 데이터로 파싱
        //stringReader.Read();

        XmlDocument xmlDoc = new XmlDocument();

        xmlDoc.LoadXml(stringReader.ReadToEnd());
        ProcessBooks(xmlDoc.SelectNodes("books/book"));
    }

    // Converts an XmlNodelist info Book objects and shows a book out of it on the screen 
    private void ProcessBooks(XmlNodeList nodes) { 
        foreach (XmlNode node in nodes)
        {
            Debug.Log(Convert.ToInt16(node.Attributes.GetNamedItem("id").Value));
            Debug.Log(node.SelectSingleNode("title").InnerText);
            Debug.Log(node.SelectSingleNode("image").InnerText);
            Debug.Log(node.SelectSingleNode("description").InnerText);

            // Loop the authors
            foreach (XmlNode author in node.SelectNodes("authors/author"))
            {
                Debug.Log(author.InnerText);
            }
        }
    }
}

