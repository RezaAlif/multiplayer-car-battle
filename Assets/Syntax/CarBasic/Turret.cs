using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public Transform Coll;
    public Transform objTurret;
    Transform targeting;
    Transform currentTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        objTurret.LookAt(currentTarget);
        if (Input.GetKeyDown(KeyCode.O))
        {
            currentTarget = targeting;
        }
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 100);

        RaycastHit rayHit;
        if (Physics.Raycast(ray, out rayHit))
        {
            if (rayHit.collider.tag == "Enemy")
            {
                Debug.Log("Kena");

                GameObject hit = rayHit.collider.gameObject;
                Transform target = hit.GetComponent<Transform>();

                targeting = target;
            }
        }
    }
}
