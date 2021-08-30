using UnityEngine;

namespace FlightSimulator
{
    public class AirplaneEngine : MonoBehaviour
    {
        #region Variables

        [Header("Engine Properties")]
        public float maxForce = 200f;
        public float maxRpm = 2550f;
        
        public AnimationCurve powerCurve = AnimationCurve.Linear(0f,0f,1f,1f);

        [Header("Propellers")] public AirplanePropeller propeller;
        
        #endregion

        #region Builtin Methods

        #endregion

        #region Custom Methods

        public Vector3 CalculateForce(float throttle)
        {
            // Calc Power
            float finalThrottle = throttle >= 0 ? throttle : 0f;
            finalThrottle = powerCurve.Evaluate(finalThrottle);

            // Calc RPM's
            float currentRpm = powerCurve.Evaluate(finalThrottle) * maxRpm;
            if (propeller)
            {
                propeller.HandlePropeller(currentRpm);
            }
            
            // Generate force
            float finalPower = finalThrottle * maxForce;
            Vector3 finalForce = transform.forward * finalPower;

            return finalForce;
        }

        #endregion
    }
}