using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 인터페이스 : Execute() 메서드만 있는 추상클래스
public abstract class CommandKey
{
    public virtual void Execute() { }
}

// Concrete Command 객체 : 직접적으로 동작하는 객체
public class CommandAttack : CommandKey
{
    public override void Execute()
    {
        Attack();
    }

    void Attack()
    {
        Debug.Log("Attack");
    }
}

public class CommandDefense : CommandKey
{
    public override void Execute()
    {
        Defense();
    }

    void Defense()
    {
        Debug.Log("Defense");
    }
}