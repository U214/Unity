using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exam02 : MonoBehaviour {

	public Exam02()
    {
        Debug.Log("기본 생성자");
    }

    public Exam02(string str)
    {
        Debug.Log("파라미터가 하나인 생성자");
    }

    public Exam02(string str1, string str2)
    {
        Debug.Log("파라미터가 두개인 생성자");
    }
}
