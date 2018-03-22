using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csPlayerCommand : MonoBehaviour {

    bool bCmd;
    Text txt1;
    Text txt2;

    CommandKey btnA, btnB;

	void Start () {
        bCmd = true;
        txt1 = GameObject.Find("Text1").GetComponent<Text>();
        txt2 = GameObject.Find("Text2").GetComponent<Text>();

        SetCommand();
    }
	
    // SetCommand() 메서드를 통해 버튼을 누르면 어떤 동작을 수행할 지를 각 버튼에 등록
    public void SetCommand()
    {
        if (bCmd == true)
        {
            btnA = new CommandAttack();
            btnB = new CommandDefense();

            bCmd = false;
            txt1.text = "A - Attack";
            txt2.text = "B - Defense";
        } else
        {
            btnA = new CommandDefense();
            btnB = new CommandAttack();

            bCmd = true;
            txt1.text = "A - Defense";
            txt2.text = "B - Attack";
        }
    }

    // 버튼을 누르면 단지 버튼의 Execute() 만 호출
	void Update () {
		if (Input.GetKeyDown("a"))
        {
            btnA.Execute();
        } else if (Input.GetKeyDown("b"))
        {
            btnB.Execute();
        }
	}
}
