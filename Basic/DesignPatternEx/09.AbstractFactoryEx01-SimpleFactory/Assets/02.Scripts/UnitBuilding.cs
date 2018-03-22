using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitBuilding {

    public abstract void produce();
}

public class Barracks : UnitBuilding
{
    public override void produce()
    {
        Debug.Log("Terran Unit 생산");
    }
}

public class GateWay : UnitBuilding
{
    public override void produce()
    {
        Debug.Log("Protoss Unit 생산");
    }
}
