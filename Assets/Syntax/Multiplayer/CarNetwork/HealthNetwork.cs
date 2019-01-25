using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace UnityStandardAssets.Vehicles.Car
{
    public class HealthNetwork : NetworkBehaviour
    {
        [SerializeField]
        private int maxHealth = 100;

        [SyncVar]
        public int currentHelath;

        public GameObject Car;
        public bool Dead;

        private void Awake()
        {
            currentHelath = maxHealth;
        }

        // Use this for initialization
        void Start()
        {
            if (!isLocalPlayer)
            {
                return;
            }
            if (isLocalPlayer)
            {
                InterfaceNework.Darah = this;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TakeDamage(int amount)
        {
            if (!isServer)
            {
                return;
            }
            currentHelath -= amount;
            if (currentHelath <= 0)
            {
                RpcDead();
                Dead = true;
            }
        }

        [ClientRpc]
        void RpcDead()
        {
            if (isLocalPlayer)
            {
                Car.SetActive(false);
            }
        }
    }
}