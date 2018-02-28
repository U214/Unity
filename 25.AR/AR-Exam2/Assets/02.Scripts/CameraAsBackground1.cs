using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAsBackground1 : MonoBehaviour {

    private RawImage image;
    private WebCamTexture cam;

	void Start () {
        image = GetComponent<RawImage>();
        cam = new WebCamTexture(Screen.width, Screen.height);
        image.texture = cam;
        cam.Play();
	}
}
