using UnityEditor;
using UnityEngine;

namespace FlightSimulator
{
    [CustomEditor(typeof(AirplaneCharacteristics))]
    public class AirplaneCharacteristicsEditor : Editor
    {
        #region Variables

        private AirplaneCharacteristics targetInput;

        #endregion

        #region Builtin Methods

        void OnEnable()
        {
            targetInput = (AirplaneCharacteristics) target;
        }

        public override void OnInspectorGUI()
        {
            
            base.OnInspectorGUI();

            float weight = targetInput.Rb != null ?  targetInput.Rb.mass * Physics.gravity.magnitude : 0f;
            
            string debugInfo = "";
            debugInfo += "Speed = " + targetInput.kmh + " km\\h" + "\n";
            debugInfo += "Weight = " + weight + " km\\h" + "\n";
            EditorGUILayout.Space();
            EditorGUILayout.TextArea(debugInfo, GUILayout.Height(200));
            EditorGUILayout.Space();
            
            Repaint();
            
        }

        #endregion
    }
}