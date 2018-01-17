using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Text;
using System;

public class ItemParser : MonoBehaviour
{
    string m_strName = "XmlData3.xml";

    void Start()
    {
        StartCoroutine(Process());
    }

    IEnumerator Process()
    {
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

        XmlNodeList xmlNodeList = null;
        XmlDocument xmlDoc = new XmlDocument();

        try
        {
            xmlDoc.LoadXml(stringReader.ReadToEnd());
        } catch (Exception e)
        {
            xmlDoc.LoadXml(_strSource);
        }

        // 최상위 노드 선택
        xmlNodeList = xmlDoc.SelectNodes("Items");

        // 아이템 매니저에 저장
        foreach (XmlNode node in xmlNodeList)
        {
            // 자식이 있을 때 실행 됨
            if (node.Name.Equals("Items") && node.HasChildNodes)
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    ItemInfo item = new ItemInfo();

                    item.ID = int.Parse(child.Attributes.GetNamedItem("id").Value);
                    item.NAME = child.Attributes.GetNamedItem("name").Value;
                    item.ICON = child.Attributes.GetNamedItem("icon").Value;
                    item.BUY_COST = int.Parse(child.Attributes.GetNamedItem("buy_cost").Value);
                    item.SELL_COST = int.Parse(child.Attributes.GetNamedItem("sell_cost").Value);

                    ItemManager.Instance().AddItem(item);
                    Debug.Log("완료 count : " + ItemManager.Instance().GetItemsCount());
                }
            }
        }
    }
}

