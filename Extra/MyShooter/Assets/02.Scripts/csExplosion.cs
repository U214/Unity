using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csExplosion : MonoBehaviour {

	void Start () {
        Destroy(gameObject, 0.8f);
	}
}
