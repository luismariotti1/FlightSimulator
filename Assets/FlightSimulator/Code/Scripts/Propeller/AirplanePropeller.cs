using UnityEngine;

namespace FlightSimulator
{
    public class AirplanePropeller : MonoBehaviour
    {
        #region Variables

        #endregion

        #region Builtin Methods
        

        #endregion
        
        #region Custom Methods

        public void HandlePropeller(float currentRpm)
        {
            //degrees per second
            float dps = ((currentRpm * 360f) / 60f) * Time.deltaTime;
            transform.Rotate(Vector3.forward, dps);
        }
        #endregion

        
    }
}