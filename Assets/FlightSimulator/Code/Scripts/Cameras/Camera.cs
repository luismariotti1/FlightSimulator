using System;
using Cinemachine;
using UnityEngine;

namespace FlightSimulator
{
    public class Camera : MonoBehaviour
    {
        #region Variables

        #endregion

        private CinemachineVirtualCamera vcam;
        private Transform cameraPos;
        private readonly Vector3 cameraRotation1 = new Vector3(10f, 90f, 0);
        private readonly Vector3 cameraOffSet1 = new Vector3(-10f, 2f, 0);
        private readonly Vector3 cameraRotation2 = new Vector3(10f, 0f, 0f);
        private readonly Vector3 cameraOffSet2 = new Vector3(0f, 2f, -10f);
        private CinemachineTransposer transposer;
        
        #region Builtin Methods

        private void Start()
        {
            vcam = GetComponent<CinemachineVirtualCamera>();
            transposer = vcam.GetCinemachineComponent<CinemachineTransposer>();
            cameraPos = GetComponent<Transform>();
            cameraPos.Rotate(Vector3.zero);
            transposer.m_FollowOffset = Vector3.zero;
            changeCamera();
        }

        #endregion

        #region Custom Methods

        private void changeCamera()
        {
            // Camerapos.Rotate(cameraRotation1);
            // transposer.m_FollowOffset = cameraOffSet1;            
            cameraPos.Rotate(cameraRotation2);
            transposer.m_FollowOffset = cameraOffSet2;
        }
        #endregion

        
    }
}