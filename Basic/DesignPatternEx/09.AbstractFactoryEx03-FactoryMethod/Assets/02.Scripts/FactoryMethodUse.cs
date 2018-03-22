using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryMethodUse : MonoBehaviour
{
    void Start()
    {
        //RaceFactory factory = null;
        //Race type = Race.Terran;

        //if (type == Race.Terran)
        //{
        //    factory = new TerranFactory();
        //} else if (type == Race.Protoss)
        //{
        //    factory = new ProtossFactory();
        //}

        // FactoryMethod 클래스는 정적 클래스로 만들어 바로 사용해도 된다
        FactoryMethod factoryMethod = new FactoryMethod();

        RaceFactory factory = factoryMethod.getFactory();

        // 하나의 팩토리 객체로 모든 건물을 다 만들 수 있다
        RaceCapacity capacity = factory.makeCapacityBuilding();
        UnitBuilding building = factory.makeUnitBuilding();

        capacity.expand();
        building.produce();
    }
}

/*
팩토리 메서드 패턴 적용 전 후 차이는 별로 없으나
종족별 Factory 객체를 생성하는 방식을 캡슐화 했다는 점이 다르다
*/