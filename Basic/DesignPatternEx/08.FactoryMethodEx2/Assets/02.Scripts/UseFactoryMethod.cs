using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseFactoryMethod : MonoBehaviour
{

    DatabaseFactory factory = null;
    Database db = null;

    void Start()
    {
        factory = GetComponent<DatabaseGenerator>();

        // 어떤 데이터베이스가 사용될지 여기서는 모른다
        // 팩토리 메서드에서 제공되는 데이터베이스를 그냥 사용한ㄷ나
        db = factory.MakeDatabase();

        // 데이터베이스 접속
        db.ConnectDatabase();

        // 접속된 데이터베이스를 이용해 업무처리를 한다
        db.InsertData();
        db.SelectData();
    }
}