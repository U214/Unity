using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 인터페이스 : Execute() 메서드만 있는 추상클래스
public abstract class CommandKey
{
    public virtual void Execute(GameObject obj) { }
}

// Concrete Command 객체 : 직접적으로 동작하는 객체
public class CommandAttack : CommandKey
{
    // 객체를 파라미터로 받아 어떤 객체라도 메서드를 호출하여 사용할 수 있도록 함
    public override void Execute(GameObject obj)
    {
        // 객체와 메서드는 디커플링 관계
        Attack(obj);
    }

    void Attack(GameObject obj)
    {
        Debug.Log(obj.name + "Attack");
        obj.transform.Translate(Vector3.forward);
    }
}

public class CommandDefense : CommandKey
{
    public override void Execute(GameObject obj)
    {
        Defense(obj);
    }

    void Defense(GameObject obj)
    {
        Debug.Log(obj.name + "Defense");
        obj.transform.Translate(Vector3.back);
    }
}