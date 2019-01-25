using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class DeadBeat : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            Beatdown.Car -= 1;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
