using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csPlayerCommand : MonoBehaviour {

    CommandKey btnA, btnB;

	void Start () {
        SetCommand();
    }
	
    public void SetCommand()
    {
        btnA = new CommandAttack();
        btnB = new CommandDefense();
    }

	public void BtnCommandA()
    {
        btnA.Execute(gameObject);
    }

    public void BtnCommandB()
    {
        btnB.Execute(gameObject);
    }
}
