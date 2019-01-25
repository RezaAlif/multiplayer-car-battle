using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Vehicles.Car
{
    public class Modification : MonoBehaviour
    {
        private GameManager Manager;            //Another Shitty Script
        private CarManager Car;

        private float Harga;                    //UIHarga
        public Text UIHarga;
        private string Prefs;
        private int Choice;

        public GameObject Parts;                //First Menu
        public GameObject Peformance;
        public GameObject FirstMenu;
        public GameObject Terjual;

        public GameObject[] PartsOpt;           //Opsi
        public GameObject[] PeformanceOpt;

        public GameObject[] Turbo;              //PeformanceOpt
        public GameObject[] Nitro;
        public GameObject[] Handling;

        public GameObject[] TurboOpsi;
        public GameObject[] NitroOpsi;
        public GameObject[] HandlingOpsi;

        public float[] HargaHood;               //Harga
        public float[] HargaWings;
        public float[] HargaRoof;
        public float[] HargaWeapon;
        public float[] HargaWheel;

        public float[] HargaTurbo;
        public float[] HargaNitro;
        public float[] HargaHandling;

        void Start()
        {
            Car = GameObject.FindWithTag("Player").GetComponent<CarManager>();
            Manager = GameObject.FindWithTag("Manager").GetComponent<GameManager>();
        }

        public void PilihParts()                            //Tahap 1
        {
            Parts.SetActive(true);
            FirstMenu.SetActive(false);
        }

        public void PilihPeformance()
        {
            Peformance.SetActive(true);
            FirstMenu.SetActive(false);
        }

        public void Back1(string Scene)
        {
            Application.LoadLevel(Scene);
        }

        public void PartsOpsi(int Pilihan)                  //Tahap 2
        {
            PartsOpt[Pilihan].SetActive(true);
            Parts.SetActive(false);
        }

        public void PeformanceOpsi(int Pilihan)
        {
            PeformanceOpt[Pilihan].SetActive(true);
            Peformance.SetActive(false);
        }

        public void Back2(GameObject Opsi)
        {
            Opsi.SetActive(false);
            FirstMenu.SetActive(true);
        }

        public void HoodOpt(int Pilihan)                    //Tahap 3 Parts
        {
            Car.HoodObj[Pilihan].SetActive(true);
            Car.HoodObj[--Pilihan].SetActive(false);
            Car.HoodObj[++Pilihan].SetActive(false);
            Harga = HargaHood[Pilihan];
            UIHarga.text = Harga.ToString();
            Prefs = "HOOD";
            Choice = Pilihan;
        }

        public void WingsOpt(int Pilihan)
        {
            Car.WingObj[Pilihan].SetActive(true);
            Car.WingObj[--Pilihan].SetActive(false);
            Car.WingObj[++Pilihan].SetActive(false);
            Harga = HargaWings[Pilihan];
            UIHarga.text = Harga.ToString();
            Prefs = "WING";
            Choice = Pilihan;
        }

        public void WeaponObj(int Pilihan)
        {
            Car.WeaponObj[Pilihan].SetActive(true);
            Car.WeaponObj[--Pilihan].SetActive(false);
            Car.WeaponObj[++Pilihan].SetActive(false);
            Harga = HargaWeapon[Pilihan];
            UIHarga.text = Harga.ToString();
            Prefs = "WEAPON";
            Choice = Pilihan;
        }

        public void WheelOpt(int Pilihan)
        {
            Car.Ban[0].mesh = Car.WheelObj[Pilihan];
            Car.Ban[1].mesh = Car.WheelObj[Pilihan];
            Car.Ban[2].mesh = Car.WheelObj[Pilihan];
            Car.Ban[3].mesh = Car.WheelObj[Pilihan];
            Harga = HargaWheel[Pilihan];
            UIHarga.text = Harga.ToString();
            Prefs = "WHEEL";
            Choice = Pilihan;
        }

        public void RoofOpt(int Pilihan)
        {
            Car.RoofObj[Pilihan].SetActive(true);
            Car.RoofObj[++Pilihan].SetActive(false);
            Car.RoofObj[--Pilihan].SetActive(false);
            Harga = HargaRoof[Pilihan];
            UIHarga.text = Harga.ToString();
            Prefs = "ROOF";
            Choice = Pilihan;
        }

        public void Back3Parts(int Pilihan)
        {
            Parts.SetActive(true);
            PartsOpt[Pilihan].SetActive(false);
            Harga = 0;
            UIHarga.text = Harga.ToString();
        }

        public void TurboOpt(int Pilihan)               //Tahap 3 Peforma
        {
            Harga = HargaTurbo[Pilihan];
            UIHarga.text = Harga.ToString();
            TurboOpsi[Pilihan].SetActive(true);
            TurboOpsi[--Pilihan].SetActive(false);
            TurboOpsi[++Pilihan].SetActive(false);
            Prefs = "TURBO";
            Choice = Pilihan;
        }

        public void NitroOpt(int Pilihan)
        {
            Harga = HargaNitro[Pilihan];
            UIHarga.text = Harga.ToString();
            NitroOpsi[Pilihan].SetActive(true);
            NitroOpsi[--Pilihan].SetActive(false);
            NitroOpsi[++Pilihan].SetActive(false);
            Prefs = "NITRO";
            Choice = Pilihan;
        }

        public void HandlingOpt(int Pilihan)
        {
            Harga = HargaHandling[Pilihan];
            UIHarga.text = Harga.ToString();
            HandlingOpsi[Pilihan].SetActive(true);
            HandlingOpsi[--Pilihan].SetActive(false);
            HandlingOpsi[++Pilihan].SetActive(false);
            Prefs = "HANDLING";
            Choice = Pilihan;
        }

        public void Back3Peformance(int Pilihan)
        {
            Peformance.SetActive(true);
            PeformanceOpt[Pilihan].SetActive(false);
            Harga = 0;
            UIHarga.text = Harga.ToString();
        }

        public void Purchase()
        {
            Manager.Scrap -= Harga;
            PlayerPrefs.SetFloat("PlayerPrefs_SCRAP",Manager.Scrap);
            PlayerPrefs.SetInt("PlayerPrefs_" + Prefs + Manager.Car, Choice);
            Terjual.SetActive(true);
        }

        public void Back4()
        {
            Terjual.SetActive(false);
        }
    }
}