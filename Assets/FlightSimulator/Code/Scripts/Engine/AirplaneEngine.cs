using UnityEngine;

namespace FlightSimulator
{
    public class AirplaneEngine : MonoBehaviour
    {
        #region Variables

        public float maxForce = 200f;
        public float maxRpm = 2550f;
        public AnimationCurve powerCurve = AnimationCurve.Linear(0f,0f,1f,1f);
        
        #endregion

        #region Builtin Methods

        #endregion

        #region Custom Methods

        public Vector3 CalculateForce(float throttle)
        {
            float finalThrottle = throttle >= 0 ? throttle : 0f;
            finalThrottle = powerCurve.Evaluate(finalThrottle);
            float finalPower = finalThrottle * maxForce;
            Vector3 finalForce = transform.forward * finalPower;

            return finalForce;
        }

        #endregion
    }
}