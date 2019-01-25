using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Vehicles.Car
{
    public class BeatdownBattle : MonoBehaviour
    {
        private GameManager Manager;

        public float carLeft;
        public Text carString;

        //Interface
        public Text Complete;
        public Text Reward;
        public GameObject Result;

        //Prefs In Event
        public string Prefs;
        public string Check;

        //Reward
        public int Money;
        public string[] Unlock;
        public GameObject[] Item;

        // Use this for initialization
        void Start()
        {
            Manager = GameObject.FindWithTag("Manager").GetComponent<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (carLeft <= 0)
            {
                //Complete
                Result.SetActive(true);
                Complete.text = "You Survived !!!";
                if (Check == "")
                {
                    Check = "true";
                    Manager.Scrap += Money;
                    Reward.text = "You Unlocked New Item";
                    Item[0].SetActive(true);
                    Item[1].SetActive(true);
                    PlayerPrefs.SetString(Prefs, "true");
                    PlayerPrefs.SetString(Unlock[0], "true");
                    PlayerPrefs.SetString(Unlock[1], "true");
                    PlayerPrefs.SetFloat("PlayerPrefs_SCRAP", Manager.Scrap);
                }
                else if (Check == "true")
                {
                    return;
                }
            }
        }
    }
}
