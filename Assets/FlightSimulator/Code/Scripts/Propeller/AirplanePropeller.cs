using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FlightSimulator
{
    public class AirplanePropeller : MonoBehaviour
    {
        #region Variables

        [Header("Propeller Properties")] public float minQuadRpm = 300f;
        public float minTextureSwap = 600f;
        public GameObject mainProp;
        public GameObject blurredProp;
        [Header("Materials Properties")] public Material blurredPropMat;
        public Texture2D propellerLevel1;
        public Texture2D propellerLevel2;
        private bool isBlurred;
        private static readonly int MainTex = Shader.PropertyToID("_MainTex");

        #endregion

        #region Builtin Methods

        #endregion

        #region Custom Methods

        public void HandlePropeller(float currentRpm)
        {
            // Degrees per second
            float dps = ((currentRpm * 360f) / 60f) * Time.deltaTime;

            // Rotate the Propeller group
            transform.Rotate(Vector3.forward, dps);

            // Handle propeller and swap
            if (mainProp && blurredProp)
            {
                HandleSwapping(currentRpm);
            }
        }

        private void HandleSwapping(float currentRpm)
        {
            isBlurred = currentRpm > minQuadRpm;
            blurredProp.gameObject.SetActive(isBlurred);
            if (blurredPropMat && propellerLevel1 && propellerLevel2)
            {
                blurredPropMat.SetTexture(MainTex,
                    currentRpm < minTextureSwap ? propellerLevel1 : propellerLevel2);
            }
            mainProp.gameObject.SetActive(!isBlurred);
        }

        #endregion
    }
}