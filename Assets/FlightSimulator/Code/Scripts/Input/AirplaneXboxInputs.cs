using UnityEngine;

namespace FlightSimulator
{
    public class AirplaneXboxInputs : AirplaneInputs
    {
        protected override void HandleInput()
        {
            // processes main inputs
            pitch = Input.GetAxis("Vertical");
            roll = Input.GetAxis("Horizontal");
            yaw = Input.GetAxis("X RH Stick");
            throttle = Input.GetAxis("X RV Stick");
            
            // processes break inputs
            brake = Input.GetButton("Fire1") ? 1f : 0f;

            // processes flaps inputs
            if (Input.GetButtonDown("X R Bumper"))
            {
                flaps += 1;
            }
            if (Input.GetButtonDown("X L Bumper"))
            {
                flaps -= 1;
            }

            flaps = Mathf.Clamp(flaps, 0, maxFlapIncrements);
        }
        
    }
}
