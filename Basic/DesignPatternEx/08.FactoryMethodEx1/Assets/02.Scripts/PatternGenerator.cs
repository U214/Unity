using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A 'ConcreteCreator' class
/// </summary>
class PatternAGenerator : UnitGenerator {

    public override void CreateUnits()
    {
        units.Add(new Marine());
        units.Add(new Marine());
        units.Add(new Marine());
        units.Add(new Marine());
        units.Add(new Marine());
        units.Add(new Marine());
        units.Add(new Marine());
        units.Add(new Marine());
        units.Add(new Marine());
    }
}

/// <summary>
/// B 'ConcreteCreator' class
/// </summary>
class PatternBGenerator : UnitGenerator
{

    public override void CreateUnits()
    {
        units.Add(new Firebat());
        units.Add(new Firebat());
        units.Add(new Firebat());
        units.Add(new Marine());
        units.Add(new Marine());
        units.Add(new Marine());
        units.Add(new Marine());
    }
}

