using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Vehicles.Car
{
    public class Nitro : MonoBehaviour
    {
        private GameManager Car;
        private CarController Parts;

        private int Nitrous;
        private float Timing;

        public float[] Nitroisme;
        public Image NitroUI;

        // Use this for initialization
        void Start()
        {
            Car = GameObject.FindWithTag("Manager").GetComponent<GameManager>();
            Parts = GetComponent<CarController>();
            Nitrous = PlayerPrefs.GetInt("PlayerPrefs_NITRO" + Car.Car);
            Timing = 1;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if(Timing >= 0)
                {
                    Parts.m_Topspeed = Parts.m_Topspeed + 10;
                    Timing -= Timing * Nitroisme[Nitrous];
                    NitroUI.fillAmount = Timing;
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                if(Timing <= 1)
                {
                    Timing += Timing * 0.1f;
                    NitroUI.fillAmount = Timing;
                }
                else
                {
                    Timing += 0;
                    NitroUI.fillAmount = Timing;
                }
            }
        }
    }
}
