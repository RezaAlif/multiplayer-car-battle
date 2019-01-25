using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class GameManager : MonoBehaviour
    {
        public float Scrap;
        public int Car;
        public int level;
        public float Bensin;

        // Use this for initialization
        void Start()
        {
            Scrap = PlayerPrefs.GetFloat("PlayerPrefs_SCRAP");
            Bensin = PlayerPrefs.GetFloat("PlayerPrefs_BENSIN");
            level = PlayerPrefs.GetInt("PlayerPrefs_LEVEL");
            Car = PlayerPrefs.GetInt("PlayerPrefs_CAR");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}