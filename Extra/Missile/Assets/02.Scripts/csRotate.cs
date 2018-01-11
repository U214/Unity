using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csRotate : MonoBehaviour {

   void Update()
    {
        transform.Rotate(Vector3.forward * 15.0f);
    }
}
