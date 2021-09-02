using UnityEngine;

namespace FlightSimulator
{
    public class AirplaneCharacteristics : MonoBehaviour
    {
        #region Variables
        [Header("Characteristics Properties")] public float forwardSpeed;
        public float kmh;
        public float maxKmh = 170f;

        [Header("Lift Properties")] public float maxLiftPower = 800f;
        public AnimationCurve liftCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

        [Header("Drag Properties")] public float dragFactor = 0.01f;


        private float angleOfAttack;
        
        private float startDrag;
        private float startAngularDrag;
        
        public float maxKms;
        private float normalizedKmh;

        private Rigidbody rb;

        #endregion

        #region Constants

        private const float MpsToKmh = 3.6f;

        #endregion
        
        #region Properties

        public Rigidbody Rb => rb;

        #endregion
        
        #region Builtin Methods
        
        #endregion

        #region Custom Methods

        public void InitCharacteristics(Rigidbody curRb)
        {
            //Initialization
            rb = curRb;
            startDrag = rb.drag;
            startAngularDrag = rb.angularDrag;
            
            //Find the max Meter per second
            maxKms = maxKmh / MpsToKmh;
        }

        public void UpdateCharacteristics()
        {
            if (rb)
            {
                //Process the flight model
                CalculateForwardSpeed();
                CalculateLift();
                CalculateDrag();
                HandleRigidbodyTransform();
            }
        }

        void CalculateForwardSpeed()
        {
            // Transform the Rigidbody velocity vector from world space to local space
            Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
            forwardSpeed = localVelocity.z;
            forwardSpeed = Mathf.Clamp(forwardSpeed, 0f, maxKms);
            
            // Clamp the velocity
            kmh = forwardSpeed * MpsToKmh;
            kmh = Mathf.Clamp(kmh, 0, maxKmh);
            normalizedKmh = Mathf.InverseLerp(0f, maxKmh, kmh);
        }

        void CalculateLift()
        {
            // Get the angle of Attack
            angleOfAttack = Vector3.Dot(rb.velocity.normalized, transform.forward);
            angleOfAttack *= angleOfAttack;
            
            // Create the lift direction
            Vector3 liftDir = transform.up;
            float liftPower = liftCurve.Evaluate(normalizedKmh) * maxLiftPower;
            
            // Apply the final Lift Force to the Rigidbody
            Vector3 finalLiftForce = liftDir * liftPower * angleOfAttack;
            rb.AddForce(finalLiftForce);
        }

        void CalculateDrag()
        {
            float speedDrag = forwardSpeed * dragFactor;
            float finalDrag = startDrag + speedDrag;
            
            rb.drag = finalDrag;
            rb.angularDrag = startAngularDrag * forwardSpeed;

        }

        void HandleRigidbodyTransform()
        {
            if (rb.velocity.magnitude > 1f)
            {
                Vector3 updateVelocity = Vector3.Lerp(rb.velocity, transform.forward * forwardSpeed,
                    forwardSpeed * angleOfAttack * Time.deltaTime);
                rb.velocity = updateVelocity;
                
                Quaternion updatedRotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(rb.velocity.normalized, transform.up), Time.deltaTime);
                rb.MoveRotation(updatedRotation);;
            }
        }
        #endregion

    }
}