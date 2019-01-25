using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    public GameObject MenuUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Scene(string Bagian)
    {
        Application.LoadLevel(Bagian);
    }

    public void Active(GameObject Objek)
    {
        Objek.SetActive(true);
        MenuUI.SetActive(false);
    }

    public void Back(GameObject Objek)
    {
        Objek.SetActive(false);
        MenuUI.SetActive(true);
    }
}
