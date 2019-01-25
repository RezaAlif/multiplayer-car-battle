using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ShootingNetwork : NetworkBehaviour {
    public GameObject BulletPrefab;
    
    public Transform BulletSpawn;

    public float Speed;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdShoot();
        }
	}

    [Command]
    void CmdShoot()
    {
        GameObject bullet = (GameObject)Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * Speed;

        NetworkServer.Spawn(bullet);
    }
}
