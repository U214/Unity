using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Text;
using System;

public class csParseXML1 : MonoBehaviour {

    private static csParseXML1 instance;
    
    public static csParseXML1 Instance()
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

	void Start () {
        StartCoroutine(Process());
	}
	
	IEnumerator Process()
    {
        string m_strName = "XmlData1.xml";
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
        stringReader.Read();

        XmlNodeList xmlNodeList = null;

        XmlDocument xmlDoc = new XmlDocument();

        xmlDoc.LoadXml(stringReader.ReadToEnd());
        xmlNodeList = xmlDoc.SelectNodes("ROOT");

        foreach ( XmlNode node in xmlNodeList)
        {
            // 자식이 있을 때 실행 됨
            if (node.Name.Equals("ROOT") && node.HasChildNodes)
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    Debug.Log("Id : " + child.Attributes.GetNamedItem("id").Value);
                    Debug.Log("name : " + child.Attributes.GetNamedItem("name").Value);
                    Debug.Log("maxValue : " + child.Attributes.GetNamedItem("maxValue").Value);
                    Debug.Log("minValue : " + child.Attributes.GetNamedItem("minValue").Value);
                }
            }
        }
    }
}


//android에서 xml read
//   // xml FIlename without Extension
//   string m_strName = “data”;
//   XmlDocument document = new XmlDocument();
//TextAsset textAsset = (TextAsset)Resources.Load(m_strName, typeof(TextAsset));
//XmlDocument xmldoc = new XmlDocument();
//document.LoadXml(textAsset.text);
