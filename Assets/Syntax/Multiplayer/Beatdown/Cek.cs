using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Cek : NetworkBehaviour
{
    public GameObject InterfacePrefab;
    public GameObject ManagerPrefab;

	// Use this for initialization
	void Start () {
        CmdSpawn();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    [Command]
    void CmdSpawn()
    {
        GameObject Interface = (GameObject)Instantiate(InterfacePrefab, transform.position, transform.rotation);
        
        GameObject GameManager = (GameObject)Instantiate(ManagerPrefab, transform.position, transform.rotation);

        NetworkServer.Spawn(Interface);
        NetworkServer.Spawn(GameManager);
    }
}
