using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGPS : MonoBehaviour {

    public Text mylatitude;
    public Text mylongitude;

    private float latitude;
    private float longitude;

    IEnumerator Start()
    {
        latitude = 0f;
        longitude = 0f;

        if (Input.location.isEnabledByUser)
        {
            Input.location.Start();

            int waitTime = 15;

            while (Input.location.status == LocationServiceStatus.Initializing && waitTime > 0)
            {
                yield return new WaitForSeconds(1);
                waitTime--;
            }

            if (waitTime == 0)
            {
                Debug.Log("Time Out");
            }
            else if (Input.location.status == LocationServiceStatus.Failed)
            {
                Debug.Log("Service Fail");
            }
            else
            {
                latitude = Input.location.lastData.latitude;
                longitude = Input.location.lastData.longitude;

                mylatitude.text = "" + latitude;
                mylongitude.text = "" + longitude;
            }
        }
    }
}
