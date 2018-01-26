using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csButtonItem1 : MonoBehaviour {

    public Text nameLabel;
    public Text descLabel;

    private csDynamicScrollList1 myManager;

	void Start () {
        myManager = GameObject.Find("GameManager").GetComponent<csDynamicScrollList1>();
    }
	
	public void Button_Click()
    {
        myManager.ButtonClicked(nameLabel.text);
    }
}
