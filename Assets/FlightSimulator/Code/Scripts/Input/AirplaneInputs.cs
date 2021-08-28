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

        protected KeyCode brakeKey = KeyCode.Space;
        protected float brake = 0f;
        

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

        protected virtual void HandleInput()
        {
            // processes main inputs
            pitch = Input.GetAxis("Vertical");
            roll = Input.GetAxis("Horizontal");
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

        #endregion
    }
}