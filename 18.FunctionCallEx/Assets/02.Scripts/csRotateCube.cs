using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csRotateCube : MonoBehaviour {

    // static 변수는 인스펙터뷰에 나오지 않는다
    public static int numX = 0;
    public int numTest = 1;

    public static int AddTwoNum (int x, int y)
    {
        return x + y;
    }

    public void Rotate1()
    {
        transform.Rotate(Vector3.up * 90.0f);
    }

    public void Rotate2()
    {
        transform.Rotate(Vector3.up * 90.0f * -1);
    }
}
