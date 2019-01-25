using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class HealthBeatdown : MonoBehaviour
    {
        public BeatdownBattle beatdown;
        public float health;
        public GameObject Mobil;
        public GameObject Explosion;
        public bool Player;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (health <= 0)
            {
                if(Player == true)
                {
                    Mobil.SetActive(false);
                    Instantiate(Explosion, transform.position, transform.rotation);
                    beatdown.Result.SetActive(true);
                    beatdown.Complete.text = "You Lose !!!";
                }
                else
                {
                    Mobil.SetActive(false);
                    Instantiate(Explosion, transform.position, transform.rotation);
                    beatdown.carLeft -= 1;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Peluru")
            {
                health -= 2;
            }
            if (other.tag == "Obstacle")
            {
                health -= 101;
            }
        }
    }
}
