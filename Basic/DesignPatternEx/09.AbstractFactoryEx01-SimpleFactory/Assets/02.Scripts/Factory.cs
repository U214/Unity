using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Race
{
    Terran,
    Protoss,
    Zerg
}

public class CapacityFactory {

	public static RaceCapacity makeBuilding(Race type)
    {
        RaceCapacity capacity = null;

        switch(type)
        {
            case Race.Terran:
                capacity = new SupplyDepot();
                break;

            case Race.Protoss:
                capacity = new Pylon();
                break;
        }

        return capacity;
    }
}

public class UnitBuildingFactory
{

    public static UnitBuilding makeBuilding(Race type)
    {
        UnitBuilding building = null;

        switch (type)
        {
            case Race.Terran:
                building = new Barracks();
                break;

            case Race.Protoss:
                building = new GateWay();
                break;
        }

        return building;
    }
}