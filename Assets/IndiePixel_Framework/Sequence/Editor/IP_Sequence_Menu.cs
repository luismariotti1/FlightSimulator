using UnityEditor;
using UnityEngine;

namespace IndiePixel_Framework.Sequence.Editor
{
    public static class IP_Sequence_Menu 
    {
        [MenuItem("Indie Pixel/Sequence/Create Sequence")]
        [MenuItem("GameObject/Indie-Pixel/Create Sequence", false, 11)]
        public static void CreateGameSequence()
        {
            GameObject sequenceGO = new GameObject("New Sequence", typeof(IP_Game_Sequence));
            sequenceGO.transform.position = Vector3.zero;
            Selection.activeGameObject = sequenceGO;
        }
    }
}
