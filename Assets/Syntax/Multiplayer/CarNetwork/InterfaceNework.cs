using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Vehicles.Car
{
    public class InterfaceNework : MonoBehaviour
    {
        [SerializeField] static public Beatdown battle;
        [SerializeField] static public HealthNetwork Darah;
        [SerializeField] static public bool Kalah;
        [SerializeField] static public bool Menang;

        public GameObject Completed;
        public GameObject Gagal;

        public Text Health;
        public Text Alive;

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            Health.text = "Health : " + Darah.currentHelath.ToString();
            Alive.text = "Alive : " + Beatdown.Car.ToString();
            Dead();
            Berhasil();
        }

        void Dead()
        {
            if (Darah.Dead == true && Menang == false)
            {
                Gagal.SetActive(true);
            }
        }

        void Berhasil()
        {
            if (Menang == true && Kalah == false)
            {
                Completed.SetActive(true);
            }
        }
    }
}