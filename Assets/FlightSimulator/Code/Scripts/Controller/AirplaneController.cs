using FlightSimulator;
using UnityEngine;

namespace FlightPhysics
{
    public class AirplaneController : BaseRigidbodyController
    {
        #region Variables

        [Header("Base Airplane Properties")] public AirplaneInputs inputs;
        public Transform centerOfGravity;
        [Tooltip("Weight is in kg")] public float weight = 360f;

        #endregion

        #region Builtin Methods

        protected override void Start()
        {
            base.Start();
            if (rb)
            {
                rb.mass = weight;
                if (centerOfGravity)
                {
                    rb.centerOfMass = centerOfGravity.localPosition;
                }
            }
        }

        #endregion
        
        #region Custom Methods

        protected override void HandlePhysics()
        {
            HandleEngines();
            HandleAerodynamics();
            HandleSteering();
            HandleBrakes();
            HandleAltitude();
        }

        void HandleEngines()
        {
            
        }

        void HandleAerodynamics()
        {
            
        }

        void HandleSteering()
        {
            
        }
        
        void HandleBrakes()
        {
            
        }

        void HandleAltitude()
        {
            
        }
        #endregion
    }
}