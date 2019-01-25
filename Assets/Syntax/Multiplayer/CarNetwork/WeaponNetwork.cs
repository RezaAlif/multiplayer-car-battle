using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    [System.Serializable]
    public class WeaponNetwork : MonoBehaviour
    {


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            GameObject hit = other.gameObject;
            HealthNetwork health = hit.GetComponent<HealthNetwork>();

            if (health != null)
            {
                health.TakeDamage(20);
            }

            Destroy(gameObject);
        }
    }
}