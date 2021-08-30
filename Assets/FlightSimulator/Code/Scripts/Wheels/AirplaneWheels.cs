using UnityEngine;

namespace FlightSimulator
{
    [RequireComponent(typeof(WheelCollider))]
    public class AirplaneWheels : MonoBehaviour
    {
        #region Variables

        private WheelCollider wheelCol;

        #endregion

        #region Builtin Methods

        private void Start()
        {
            wheelCol = GetComponent<WheelCollider>();
        }

        #endregion

        #region Custom Methods

        public void InitWheel()
        {
            if (wheelCol)
            {
                wheelCol.motorTorque = 1e-12f;
            }
        }
        #endregion
    }
}