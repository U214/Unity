using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Firebat 'ConcreteProduct' class
/// </summary>
public class Firebat : Unit
{

    public Firebat()
    {
        type = UnitType.Firebat;
        name = "Firebat";
        hp = 120;
        exp = 15;

        Debug.Log(this.name + " : 생성!!");
    }

    public override void Attack()
    {
        Debug.Log(this.name + " : 공격!!");
    }
}
