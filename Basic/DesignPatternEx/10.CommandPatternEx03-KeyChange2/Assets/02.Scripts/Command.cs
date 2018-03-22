using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 인터페이스 : Execute() 메서드만 있는 추상클래스
public abstract class CommandKey
{
    public GameObject shield;
    public GameObject cannon;
    public Transform firePos;

    public MonoBehaviour mono;

    public virtual void Execute() { }
}

// Concrete Command 객체 : 직접적으로 동작하는 객체
public class CommandAttack : CommandKey
{
    public CommandAttack(MonoBehaviour _mono, GameObject _shield, GameObject _cannon, Transform _firePos)
    {
        this.shield = _shield;
        this.cannon = _cannon;
        this.firePos = _firePos;
        this.mono = _mono;
    }

    public override void Execute()
    {
        Attack();
    }

    void Attack()
    {
        Debug.Log("Attack");
        GameObject.Instantiate(cannon, firePos.position, firePos.rotation);
    }
}

public class CommandDefense : CommandKey
{
    public CommandDefense(MonoBehaviour _mono, GameObject _shield, GameObject _cannon, Transform _firePos)
    {
        this.shield = _shield;
        this.cannon = _cannon;
        this.firePos = _firePos;
        this.mono = _mono;
    }

    public override void Execute()
    {
        Defense();
    }

    void Defense()
    {
        Debug.Log("Defense");
        shield.SetActive(true);
        mono.StartCoroutine(Defense(0.5f));
    }

    IEnumerator Defense(float second)
    {
        yield return new WaitForSeconds(second);
        shield.SetActive(false);
    }
}