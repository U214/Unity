using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csViewpointChange : MonoBehaviour {

    public GameObject FirstPersonCamera;
    public GameObject ThirdPersonCamera;

    void Start () {
        // 3인칭 카메라를 사용하는 것으로 설정
        ThirdPersonCamera.GetComponent<Camera>().enabled = true;
        ThirdPersonCamera.GetComponent<AudioListener>().enabled = true;
        FirstPersonCamera.GetComponent<Camera>().enabled = false;
        FirstPersonCamera.GetComponent<AudioListener>().enabled = false;
    }
	
	void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 50), "FirstPersonCamera"))
        {
            FirstPersonCamera.GetComponent<Camera>().enabled = true;
            FirstPersonCamera.GetComponent<AudioListener>().enabled = true;
            ThirdPersonCamera.GetComponent<Camera>().enabled = false;
            ThirdPersonCamera.GetComponent<AudioListener>().enabled = false;
        }

        if (GUI.Button(new Rect(10, 70, 150, 50), "ThirdPersonCamera"))
        {
            ThirdPersonCamera.GetComponent<Camera>().enabled = true;
            ThirdPersonCamera.GetComponent<AudioListener>().enabled = true;
            FirstPersonCamera.GetComponent<Camera>().enabled = false;
            FirstPersonCamera.GetComponent<AudioListener>().enabled = false;
        }
    }
}
