using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csButtonItem2 : MonoBehaviour {

    public Text nameLabel;
    public Text descLabel;

    private csDynamicScrollList2 myManager;

    void Start()
    {
        myManager = GameObject.Find("GameManager").GetComponent<csDynamicScrollList2>();
    }

    public void Button_Click()
    {
        myManager.ButtonClicked(nameLabel.text);
    }
}
