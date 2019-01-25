using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace UnityStandardAssets.Vehicles.Car
{
    public class BeatdownCheck : NetworkBehaviour
    {
        public HealthNetwork Health;
        public GameObject Dead;

        int Posisi;
        bool Kalah;

        // Use this for initialization
        void Start()
        {
            Beatdown.Car += 1;
        }

        // Update is called once per frame
        void Update()
        {
            Win();
            Lose();
        }

        void Win()
        {
            if (Beatdown.Car <= 1 && Health.Dead == false && Beatdown.Mulai == true)
            {
                InterfaceNework.Menang = true;
            }
        }

        void Lose()
        {
            if (Health.Dead == true)
            {
                CmdDeath();
                Posisi = Beatdown.Car;
                InterfaceNework.Kalah = true;
                Kalah = true;
            }
        }

        [Command]
        void CmdDeath()
        {
            gameObject.SetActive(false);
            GameObject Mobil = this.gameObject;
            GameObject DeadBeat = (GameObject)Instantiate(Dead, transform.position, transform.rotation);

            NetworkServer.Spawn(DeadBeat);
            NetworkServer.Destroy(Mobil);
        }

        
    }
}