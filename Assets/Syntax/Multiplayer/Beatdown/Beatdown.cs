using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class Beatdown : MonoBehaviour
    {
        [SerializeField] static public int Car;
        [SerializeField] static public bool Mulai;

        float Aba;
        public int Jumlah { get { return Car; } }

        // Use this for initialization
        void Start()
        {
            InterfaceNework.battle = this;
        }

        // Update is called once per frame
        void Update()
        {
            if (Car >= 2)
            {
                Mulai = true;
            }
        }
    }
}