using System.Collections.Generic;
using UnityEngine;

namespace FlightSimulator
{
    [RequireComponent(typeof(AirplaneCharacteristics))]
    public class AirplaneController : BaseRigidbodyController
    {
        #region Variables
        [Header("Base Airplane Properties")] public AirplaneInputs inputs;
        public AirplaneCharacteristics characteristics;
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

                characteristics = GetComponent<AirplaneCharacteristics>();
                if (characteristics)
                {
                    characteristics.InitCharacteristics(rb);
                }
            }

            // Init the wheels to not stuck the plane
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
                HandleCharacteristics();
                HandleSteering();
                HandleBrakes();
                HandleAltitude();
            }
        }

        void HandleEngines()
        {
            // Apply the engine force to the plane
            if (engines != null)
            {
                if (engines.Count > 0)
                {
                    foreach (var engine in engines)
                    {
                        rb.AddForce(engine.CalculateForce(inputs.StickyThrottle));
                    }
                }
            }
        }

        void HandleCharacteristics()
        {
            if (characteristics)
            {
                characteristics.UpdateCharacteristics();
            }
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