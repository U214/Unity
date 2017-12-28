using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csScreenPointTouch : MonoBehaviour {

	void Update () {
	    if (Input.GetButtonUp("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
               if (hit.transform.tag.Equals("Enemy"))
                {
                    csCubeRotate cubeScript = hit.transform.GetComponent<csCubeRotate>();

                    if (cubeScript != null)
                    {
                        cubeScript.RotateByHit();
                    }
                }
            }
        }	
	}
}
