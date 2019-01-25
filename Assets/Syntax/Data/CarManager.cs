using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class CarManager : MonoBehaviour
    {
        private GameManager Car;                 //AnotherSyntax
        private CarController Parts;
        public MeshFilter[] Ban;

        private int Hood;                       //CarParts
        private int Roof;
        private int Weapon;
        private int Wing;
        private int Wheel;

        public GameObject[] HoodObj;
        public GameObject[] RoofObj;
        public GameObject[] WeaponObj;
        public GameObject[] WingObj;
        public Mesh[] WheelObj;

        private int Turbo;                      //CarMachine
        private int Handling;
        
        public float[] Turboisme;
        public float[] handlingisme;

        // Use this for initialization
        void Start()
        {
            Car = GameObject.FindWithTag("Manager").GetComponent<GameManager>();
            Parts = GetComponent<CarController>();

            Hood = PlayerPrefs.GetInt("PlayerPrefs_HOOD" + Car.Car);
            Roof = PlayerPrefs.GetInt("PlayerPrefs_ROOF" + Car.Car);
            Weapon = PlayerPrefs.GetInt("PlayerPrefs_WEAPON" + Car.Car);
            Wing = PlayerPrefs.GetInt("PlayerPrefs_WING" + Car.Car);
            Wheel = PlayerPrefs.GetInt("PlayerPrefs_WHEEL" + Car.Car);

            HoodObj[Hood].SetActive(true);
            RoofObj[Roof].SetActive(true);
            WeaponObj[Weapon].SetActive(true);
            WingObj[Wing].SetActive(true);
            Ban[0].mesh = WheelObj[Wheel];
            Ban[1].mesh = WheelObj[Wheel];
            Ban[2].mesh = WheelObj[Wheel];
            Ban[3].mesh = WheelObj[Wheel];

            Turbo = PlayerPrefs.GetInt("PlayerPrefs_TURBO" + Car.Car);
            Handling = PlayerPrefs.GetInt("PlayerPrefs_HANDLING" + Car.Car);

            Parts.m_Topspeed = Parts.m_Topspeed + Turboisme[Turbo];
            Parts.m_MaximumSteerAngle += handlingisme[Handling];
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}