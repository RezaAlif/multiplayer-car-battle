using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arah : MonoBehaviour {
    public Transform Waypoint;
    public bool WrongWay;
    public bool Jauh;
    float angle;

    // Use this for initialization
    void Start () {
        WrongWay = false;
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Waypoint);
        Rotasi();
        Far();
        angle = transform.localEulerAngles.y;
        angle = (angle > 180) ? angle - 360 : angle;
    }

    void Rotasi()
    {
        if (angle > 90 || angle < -180)
        {
            WrongWay = true;
        }
        else
        {
            WrongWay = false;
        }
    }

    void Far()
    {
        if(Waypoint.localPosition.z > 30)
        {
            Jauh = true;
        }
        else
        {
            Jauh = false;
        }
    }
}
