using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 'ConcreteCreator' class
/// </summary>
public class DatabaseGenerator : DatabaseFactory {

    // 이번에 사용할 데이터베이스는 Orable이다
    // 데이터베이스 변경시 여기서 타입을 변경한다.
    public DBType dbType = DBType.MySQL;

    public override Database MakeDatabase()
    {
        // 회사 사정에 의해 어떤 데이터베이스를 다시 사용할지 모른다
        // 그래서 구축한 정보를 지우지 않고 재사용시를 대비한다.

        if (dbType == DBType.MySQL)
        {
            Debug.Log("MySQL use ...");
            return new MySQL();
        }
        else if (dbType == DBType.Oracle)
        {
            Debug.Log("Oracle use ...");
            return new Oracle();
        }
        else if (dbType == DBType.Informix)
        {
            Debug.Log("Informix use ...");
            return new Informix();
        } 
        else
        {
            return null;
        }
    }
}
