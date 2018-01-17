using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour {

    private string screenShotURL = "http://.........../image.php";

	// Take a screen shot immediately
	void Start () {
		
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(100, 100, 150, 20), "Upload"))
        {
            StartCoroutine(UploadPNG(screenShotURL));
        } else if (GUI.Button(new Rect(100, 200, 150, 20), "change material"))
        {
            StartCoroutine(MaterialPNG());
        }
    }

    IEnumerator UploadPNG(string URL)
    {
        // We should only read the screen after all rendering is complete
        yield return new WaitForEndOfFrame();
        // Create a texture the size of the screen, RGB24 format
        int width = Screen.width;
        int height = Screen.height;
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();
        // Encode texture into PNG
        byte[] bytes = tex.EncodeToPNG();
        Destroy(tex);
        // Create a Web Form
        WWWForm form = new WWWForm();
        form.AddField("frameCount", Time.frameCount.ToString());
        form.AddBinaryData("fileUpload", bytes, "screenShot.png", "image/png");
        // Upload to a cgi script    
        WWW w = new WWW(URL, form);
        yield return w;
        if (w.error != null)
        {
            print(w.error);
        }
        else
        {
            print("Finished Uploading Screenshot");
        }
    }

    IEnumerator MaterialPNG()
    {
        while (true)
        {
            // We should only read the screen after all rendering is complete
            yield return new WaitForEndOfFrame();

            // Create a texture the size of the screen, RGB24 format
            int width = Screen.width;
            int height = Screen.height;
            Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

            // Read screen contents into the texture
            tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            tex.Apply();

            gameObject.GetComponent<Renderer>().material.mainTexture = tex;
        }
    }

}
