using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MyItem2
{
    public string name;
    public string desc;
    public string year;
}

public class csDynamicScrollList2 : MonoBehaviour {

    public Button myButton;
    public Transform myViewport;

    private List<MyItem2> itemList = new List<MyItem2>();

    void Start()
    {
        MyItem2 itemData1 = new MyItem2();
        itemData1.name = "을지문덕";
        itemData1.desc = "살수대첩";
        itemData1.year = "612";
        itemList.Add(itemData1);

        MyItem2 itemData2 = new MyItem2();
        itemData2.name = "강감찬";
        itemData2.desc = "귀주대첩";
        itemData2.year = "1018";
        itemList.Add(itemData2);

        MyItem2 itemData3 = new MyItem2();
        itemData3.name = "이순신";
        itemData3.desc = "한산도대첩";
        itemData3.year = "1592";
        itemList.Add(itemData3);

        MyItem2 itemData4 = new MyItem2();
        itemData4.name = "권율";
        itemData4.desc = "행주대첩";
        itemData4.year = "1593";
        itemList.Add(itemData4);

        PopulateList();
    }

    void PopulateList()
    {
        foreach (MyItem2 item in itemList)
        {
            Button newButton = Instantiate(myButton) as Button;

            csButtonItem2 button = newButton.GetComponent<csButtonItem2>();
            button.nameLabel.text = item.name;
            button.descLabel.text = item.desc;

            newButton.transform.SetParent(myViewport);
            newButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    public void ButtonClicked(string str)
    {
        Debug.Log(str + " button clicked");
    }
}
