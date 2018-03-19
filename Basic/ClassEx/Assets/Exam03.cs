using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exam03 : MonoBehaviour {
	void Start () {
        Apple apple = new Apple();
        apple.getPrice();

        Banana banana = new Banana();
        banana.getPrice();
	}
}

public class Fruit
{
    public void getPrice()
    {
        Debug.Log("Fruit : 100원");
    }
}

public class Apple : Fruit
{
    public new void getPrice()
    {
        // 기능의 변경
        Debug.Log("Apple : 200원");
    }
}

public class Banana : Fruit
{
    public new void getPrice()
    {
        // 부모의 기능을 호출하여 먼저 수행하고
        base.getPrice();
        // 기능 추가
        Debug.Log("Banana : 100원 추가");
    }
}