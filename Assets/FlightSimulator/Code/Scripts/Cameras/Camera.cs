using System;
using Cinemachine;
using UnityEngine;

namespace FlightSimulator
{
    public class Camera : MonoBehaviour
    {
        #region Variables
        
        private CinemachineVirtualCamera vcam;
        private Transform cameraPos;
        private readonly Vector3 cameraRotation1 = new Vector3(10f, 90f, 0);
        private readonly Vector3 cameraOffSet1 = new Vector3(-10f, 2f, 0);
        private readonly Vector3 cameraRotation2 = new Vector3(10f, 0f, 0f);
        private readonly Vector3 cameraOffSet2 = new Vector3(0f, 2f, -10f);
        private CinemachineTransposer transposer;
        
        #endregion
        
        #region Builtin Methods

        private void Start()
        {
            vcam = GetComponent<CinemachineVirtualCamera>();
            transposer = vcam.GetCinemachineComponent<CinemachineTransposer>();
            cameraPos = GetComponent<Transform>();
            cameraPos.Rotate(Vector3.zero);
            transposer.m_FollowOffset = Vector3.zero;
            cameraPos.Rotate(cameraRotation2);
            transposer.m_FollowOffset = cameraOffSet2;     
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                ChangeCamera("c1");
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                ChangeCamera("c2");
            }
        }

        #endregion

        #region Custom Methods

        private void ChangeCamera(String cameraType)
        {
            cameraPos.rotation = Quaternion.identity;
            switch (cameraType)
            {
                case "c1":
                    cameraPos.Rotate(cameraRotation1);
                    transposer.m_FollowOffset = cameraOffSet1;     
                    break;
                case "c2":
                    cameraPos.Rotate(cameraRotation2);
                    transposer.m_FollowOffset = cameraOffSet2;     
                    break;
            }
        }
        #endregion

        
    }
}