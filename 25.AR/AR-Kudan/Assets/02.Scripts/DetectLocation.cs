using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Kudan.AR.Samples;

public class DetectLocation : MonoBehaviour
{
    // location marker show
    private Vector2 targetCoordinates;
    // device location var
    private Vector2 deviceCoordinates;
    // distance allowed from device to target
    private float distanceFromTarget = 0.00004f;
    // distance between device to target coordinates 
    private float proximity = 0.001f;
    // values for latitude and lon get from device gps
    private float sLatitude, sLongitude;
    // set value for target location
    public float dLatitude = -6.884687f, dLongitude = 107.605945f;
    // var for location request
    private bool enableByRequest = true;
    public int maxWait = 10;
    public bool ready = false;
    public Text text;
    // sampleapp script
    public SampleApp sa;

   
    void Start()
    {
        targetCoordinates = new Vector2(dLatitude, dLongitude);
        StartCoroutine(getLocation());
    }

    // get last update locaton, we need latitude and longitude
    IEnumerator getLocation()
    {
        LocationService service = Input.location;
        if (!enableByRequest && !service.isEnabledByUser)
        {
            Debug.Log("Location Services not enabled by user");
            yield break;
        }
        service.Start();
        while (service.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            yield break;
        }
        if (service.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }
        else
        {
            text.text = "Target Location : " + dLatitude + ", " + dLongitude + "\nMy Location: " + service.lastData.latitude + ", " + service.lastData.longitude;
            // hear we pass lat and lon values from device
            sLatitude = service.lastData.latitude;
            sLongitude = service.lastData.longitude;
        }
        // stop service if you want
        //service.Stop();
        ready = true;
        startCalculate();
    }

    // method to calculate distances between device location and target locaton
    public void startCalculate()
    {
        // create vector2 from device lat and lon
        deviceCoordinates = new Vector2(sLatitude, sLongitude);
        // proximity! calculate distance
        proximity = Vector2.Distance(targetCoordinates, deviceCoordinates);
        // if proximity < or = target...
        if (proximity <= distanceFromTarget)
        {
            text.text = text.text + "\nDistance : " + proximity.ToString();
            text.text += "\nTarget Detected";
            // show 3d object! call SampleApp script
            sa.StartClicked();
        }
        else
        {
            // else, show warning or wharever..
            text.text = text.text + "\nDistance : " + proximity.ToString();
            text.text += "\nTarget not detected, too far!";
        }
    }
}