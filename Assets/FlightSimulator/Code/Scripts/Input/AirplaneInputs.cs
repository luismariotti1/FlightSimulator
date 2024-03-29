using UnityEngine;

namespace FlightSimulator
{
    public class AirplaneInputs : MonoBehaviour
    {
        #region Variables
        protected float pitch = 0f;
        protected float roll = 0f;
        protected float yaw = 0f;
        protected float throttle = 0f;

        private float throttleSpeed = 0.15f;
        protected KeyCode brakeKey = KeyCode.Space;
        protected float brake = 0f;
        protected float stickyThrottle;
        

        protected int maxFlapIncrements = 2;
        protected int flaps = 0;

        #endregion

        #region Properties

        public float Pitch => pitch;
        public float Roll => roll;
        public float Yaw => yaw;
        public float Throttle => throttle;
        public float Flaps => flaps;
        public float Brake => brake;
        public float StickyThrottle => stickyThrottle;

        #endregion

        #region Builtin Methods

        // Update is called once per frame
        void Update()
        {
            HandleInput();
        }

        #endregion

        #region Custom Methods

        protected virtual void HandleInput()
        {
            // processes main inputs
            pitch = Input.GetAxis("Vertical");
            roll = Input.GetAxis("Horizontal");
            StickyThrottleControl();
            
            yaw = Input.GetAxis("Yaw");
            throttle =Input.GetAxis("Throttle");
            

            // processes break inputs
            brake = Input.GetKey(brakeKey) ? 1f : 0f;

            // processes flaps inputs
            if (Input.GetKeyDown(KeyCode.F))
            {
                flaps += 1;
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                flaps -= 1;
            }

            flaps = Mathf.Clamp(flaps, 0, maxFlapIncrements);
        }

        protected void StickyThrottleControl()
        {
            // Increment gradually the speed and sticky it
            stickyThrottle += throttle * throttleSpeed * Time.deltaTime;
            stickyThrottle = Mathf.Clamp(StickyThrottle, 0f, 1f);
        }
        
        #endregion
    }
}