using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DBType
{
    MySQL,
    Oracle,
    Informix
}

/// <summary>
/// The 'Creator' abstract class
/// </summary>
public abstract class DatabaseFactory : MonoBehaviour {

    // Factory Method
    public abstract Database MakeDatabase();
}
