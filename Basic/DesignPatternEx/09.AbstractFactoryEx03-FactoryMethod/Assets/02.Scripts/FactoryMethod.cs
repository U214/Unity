using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryMethod : MonoBehaviour {

    public Race type = Race.Terran;

    public RaceFactory getFactory()
    {
        RaceFactory factory = null;

        switch (type)
        {
            case Race.Terran:
                factory = new TerranFactory();
                break;

            case Race.Protoss:
                factory = new ProtossFactory();
                break;
        }

        return factory;
    }
}
