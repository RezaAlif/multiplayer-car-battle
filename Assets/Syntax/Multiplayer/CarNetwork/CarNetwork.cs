using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class CarNetwork : NetworkBehaviour
    {

        private CarController m_Car; // the car controller we want to use
        public MeshRenderer m_Mesh;

        public string pname = "Player";

        [SerializeField]
        Behaviour[] componentsToDisable;

        [SerializeField]
        string remoteLayerName = "RemotePlayer";

        private void Start()
        {
            if (isLocalPlayer)
            {
                gameObject.tag = "Player";
                SmoothFollow.target = this.transform;
            }
            if (!isLocalPlayer)
            {
                gameObject.tag = "Enemy";
                DisableComponents();
                AssignRemotePlayer();
            }
        }

        void DisableComponents()
        {
            for(int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }

        void AssignRemotePlayer()
        {
            gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
        }

        private void Update()
        {
            
        }

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            if (isLocalPlayer)
            {
                // pass the input to the car!
                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
                float handbrake = CrossPlatformInputManager.GetAxis("Jump");
                m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
            }


        }

        public override void OnStartLocalPlayer()
        {
            m_Mesh.material.color = Color.blue;
        }
    }
}

