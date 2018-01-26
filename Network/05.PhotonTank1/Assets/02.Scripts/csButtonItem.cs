using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csButtonItem : MonoBehaviour {

    public Text txtRoomName;
    public Text txtNumMax;

    private PhotonInit myManager;

	void Start () {
        myManager = GameObject.Find("PhotonManager").GetComponent<PhotonInit>();
    }
	
	public void Button_Click()
    {
        myManager.JoinRoom(txtRoomName.text);
    }
}
