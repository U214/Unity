using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Marine 'ConcreteProduct' class
/// </summary>
public class Marine : Unit {

	public Marine()
    {
        type = UnitType.Marine;
        name = "Marine";
        hp = 100;
        exp = 50;

        Debug.Log(this.name + " : 생성!!");
    }

    public override void Attack()
    {
        Debug.Log(this.name + " : 공격!!");
    }
}
