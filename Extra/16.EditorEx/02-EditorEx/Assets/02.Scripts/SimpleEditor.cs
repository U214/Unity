using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BLOODTYPE
{
    A = 0,
    B,
    AB,
    O
}

public class SimpleEditor : MonoBehaviour {

    public bool showButton = true;
    public int age = 32;
    public float height = 172.3f;
    public string userName = "Jerry";
    public BLOODTYPE bloodType = BLOODTYPE.A;
    public GameObject cameraObject;
    public Transform myTransform;
    public List<int> myList;
    public float[] arrayFloat;
    public Vector3[] arrayVector;
}
