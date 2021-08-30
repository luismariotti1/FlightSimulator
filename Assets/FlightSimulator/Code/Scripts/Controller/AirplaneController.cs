using System.Collections.Generic;
using UnityEngine;

namespace FlightSimulator
{
    public class AirplaneController : BaseRigidbodyController
    {
        #region Variables

        [Header("Base Airplane Properties")] public AirplaneInputs inputs;
        public Transform centerOfGravity;
        [Tooltip("Weight is in kg")] public float weight = 360f;
        [Header("Engines")] public List<AirplaneEngine> engines = new List<AirplaneEngine>();
        [Header("Wheels")] public List<AirplaneWheels> wheels = new List<AirplaneWheels>();

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

            if (wheels != null)
            {
                if (wheels.Count > 0)
                {
                    
                    foreach (var wheel in wheels)
                    {
                        wheel.InitWheel();
                    }
                }
            }
        }

        #endregion
        
        #region Custom Methods

        protected override void HandlePhysics()
        {
            if (inputs)
            {
                HandleEngines();
                HandleAerodynamics();
                HandleSteering();
                HandleBrakes();
                HandleAltitude();
            }
        }

        void HandleEngines()
        {
            if (engines != null)
            {
                if (engines.Count > 0)
                {
                    foreach (var engine in engines)
                    {
                        rb.AddForce(engine.CalculateForce(inputs.Throttle));
                    }
                }
            }
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