using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csScreenPointTouch : MonoBehaviour {
    
	void Update () {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Ended)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag.Equals("Player"))
                    {
                        csCubeRotate cubeScript =
                            hit.transform.GetComponent<csCubeRotate>();
                        if (cubeScript != null)
                        {
                            cubeScript.RotateByHit();
                        }
                    }
                }
            }
        }
	}
}
