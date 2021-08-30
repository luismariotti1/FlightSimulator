using FlightSimulator;
using UnityEditor;
using UnityEngine;

namespace FlightSimulator
{
    public static class AirplaneMenus
    {
        [MenuItem("Airplane Tools/Create New Airplane")]
        public static void CreateNewAirplane()
        {
            GameObject curSelected = Selection.activeGameObject;
            if (curSelected)
            {
                AirplaneInputs inputs = curSelected.AddComponent<AirplaneInputs>();
                AirplaneController curController = curSelected.AddComponent<AirplaneController>();
                GameObject curCOG = new GameObject("COG");
                curCOG.transform.SetParent(curSelected.transform);
                curController.centerOfGravity = curCOG.transform;
                curController.inputs = inputs;
            }
        }
    }
}
