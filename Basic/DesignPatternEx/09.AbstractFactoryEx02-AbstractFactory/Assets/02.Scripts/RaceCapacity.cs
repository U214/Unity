using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RaceCapacity {

    public abstract void expand();
}

public class SupplyDepot : RaceCapacity
{
    public override void expand()
    {
        Debug.Log("Terran Capacity +8");
    }
}

public class Pylon : RaceCapacity
{
    public override void expand()
    {
        Debug.Log("Protoss Capacity +8");
    }
}
