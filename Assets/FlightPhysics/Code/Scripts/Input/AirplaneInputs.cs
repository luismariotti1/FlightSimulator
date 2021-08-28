using System;
using UnityEngine;

namespace FlightPhysics.Code.Scripts.Input
{
    public class AirplaneInputs : MonoBehaviour
    {
        #region Variables

        protected float pitch = 0f;
        protected float roll = 0f;
        protected float yaw = 0f;
        protected float throttle = 0f;

        public KeyCode brakeKey = KeyCode.Space;
        protected float brake = 0f;
        

        public int maxFlapIncrements = 2;
        protected int flaps = 0;

        #endregion

        #region Properties

        public float Pitch => pitch;
        public float Roll => roll;
        public float Yaw => yaw;
        public float Throttles => throttle;
        public float Flaps => flaps;
        public float Brake => brake;

        #endregion

        #region Builtin Methods

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            HandleInput();
        }

        #endregion

        #region Custom Methods

        void HandleInput()
        {
            // processes main inputs
            pitch = UnityEngine.Input.GetAxis("Vertical");
            roll = UnityEngine.Input.GetAxis("Horizontal");
            yaw = UnityEngine.Input.GetAxis("Yaw");
            throttle = UnityEngine.Input.GetAxis("Throttle");

            // processes break inputs
            brake = UnityEngine.Input.GetKey(brakeKey) ? 1f : 0f;

            // processes flaps inputs
            if (UnityEngine.Input.GetKeyDown(KeyCode.F))
            {
                flaps += 1;
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.G))
            {
                flaps -= 1;
            }

            flaps = Mathf.Clamp(flaps, 0, maxFlapIncrements);
        }

        #endregion
    }
}