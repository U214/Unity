using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The 'Product' abstract class
/// </summary>
public abstract class Database {

    public string name;
    public double rows;

    // 데이터베이스마다 접속 방식이 다르다.
    public abstract void ConnectDatabase();

    // 표준 SQL문을 사용한다 (업무처리 방식이 같다)
    public void InsertData()
    {
        Debug.Log(name + " 에 데이터를 추가했습니다");
    }

    public void SelectData()
    {
        Debug.Log(name + " 에서 데이터를 " + rows + "개 조회했습니다.");
    }
}

/// <summary>
/// A 'ConcreteProduct' class
/// </summary>
public class MySQL : Database
{
    public MySQL()
    {
        name = "MySQL";
        rows = 20;
    }

    public override void ConnectDatabase()
    {
        Debug.Log(name + " 에 접속했습니다");
    }
}

/// <summary>
/// B 'ConcreteProduct' class
/// </summary>
public class Oracle : Database
{
    public Oracle()
    {
        name = "Oracle";
        rows = 10;
    }

    public override void ConnectDatabase()
    {
        Debug.Log(name + " 에 접속했습니다");
    }
}

/// <summary>
/// C 'ConcreteProduct' class
/// </summary>
public class Informix : Database
{
    public Informix()
    {
        name = "Informix";
        rows = 40;
    }

    public override void ConnectDatabase()
    {
        Debug.Log(name + " 에 접속했습니다");
    }
}