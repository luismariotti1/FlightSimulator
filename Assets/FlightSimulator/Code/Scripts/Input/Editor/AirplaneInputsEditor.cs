using UnityEditor;
using UnityEngine;

namespace FlightSimulator
{
    [CustomEditor(typeof(AirplaneInputs))]
    public class AirplaneInputsEditor : Editor
    {
        #region Variables

        private AirplaneInputs targetInput;

        #endregion

        #region Builtin Methods

        void OnEnable()
        {
            targetInput = (AirplaneInputs) target;
        }

        public override void OnInspectorGUI()
        {
            
            base.OnInspectorGUI();
            
            string debugInfo = "";
            debugInfo += "Pitch = " + targetInput.Pitch + "\n";
            debugInfo += "Roll = " + targetInput.Roll + "\n";
            debugInfo += "Yaw = " + targetInput.Yaw  + "\n";
            debugInfo += "Throttle = " + targetInput.Throttle + "\n";
            debugInfo += "Brake = " + targetInput.Brake + "\n";
            debugInfo += "Flaps = " + targetInput.Flaps + "\n";

            EditorGUILayout.Space();
            EditorGUILayout.TextArea(debugInfo, GUILayout.Height(200));
            EditorGUILayout.Space();
            
            Repaint();
            
        }

        #endregion
    }
}
