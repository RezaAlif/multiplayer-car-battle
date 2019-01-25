using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour {
    private float Timing;
    public string Scene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Timing += Time.deltaTime;
        if(Timing >= 10)
        {
            Application.LoadLevel(Scene);
        }
	}
}
