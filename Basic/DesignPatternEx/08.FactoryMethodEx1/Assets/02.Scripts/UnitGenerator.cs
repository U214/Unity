using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The 'Creator' abstract class
/// </summary>
abstract class UnitGenerator {

    public List<Unit> units = new List<Unit>();

    public List<Unit> getUnits()
    {
        return units;
    }

    // Factory Method
    public abstract void CreateUnits();
}
