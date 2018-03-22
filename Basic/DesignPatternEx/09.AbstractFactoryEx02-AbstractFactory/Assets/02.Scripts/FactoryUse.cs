using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryUse : MonoBehaviour
{
    void Start()
    {
        RaceFactory factory = null;
        Race type = Race.Terran;

        if (type == Race.Terran)
        {
            factory = new TerranFactory();
        } else if (type == Race.Protoss)
        {
            factory = new ProtossFactory();
        }

        // 하나의 팩토리 객체로 모든 건물을 다 만들 수 있다
        RaceCapacity capacity = factory.makeCapacityBuilding();
        UnitBuilding building = factory.makeUnitBuilding();

        capacity.expand();
        building.produce();
    }
}

/*
종족별로 Factory클래스를 정의해 종족별 생산 건물을 아주 간다히 생성할 수 있다
즉 Terran 종족을 이용할 때는 TerranFactory객체를 생성할 수 있고
Protoss의 건물을 이용할 때는 ProtossFactory객체를 생성할 수 있다

Terran 대신 Protoss를 사용할 경우
위 예제 10 라인의 Race 타입만 바꾸면 된다
*/