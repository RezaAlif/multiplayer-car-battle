using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Vehicles.Car
{
    public class Aba : MonoBehaviour
    {
        float Timing = 3;
        public Text TimeUI;
        public CarAIControl[] AI;
        CarUserControl Player;

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            Player = GameObject.FindWithTag("Player").GetComponent<CarUserControl>();
            Timing -= Time.deltaTime;
            TimeUI.text = Timing.ToString();
            if(Timing <= 0)
            {
                AI[0].enabled = true;
                AI[1].enabled = true;
                AI[2].enabled = true;
                Player.enabled = true;
                TimeUI.text = "";
            }
        }
    }
}