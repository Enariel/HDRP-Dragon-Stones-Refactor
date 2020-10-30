using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Dragon_Stones.CameraController
{
    [RequireComponent(typeof(CinemachineFreeLook))]
    public class Camera_Controller : MonoBehaviour
    {
        private CinemachineFreeLook cinemachine;
        private GameObject player;

        public float lookSpeed = 1f;
        public float zoomSpeed = 1f;

        private void Awake()
        {
            //Grab input controller and cinemachine cam
            cinemachine = GetComponent<CinemachineFreeLook>();
        }

        private void Update()
        {
            MoveCamera();
        }

        void MoveCamera()
        {
            float zoomChange = Input.GetAxis("Mouse ScrollWheel");

            if (Input.GetMouseButton(1))
            {
                Vector2 delta = new Vector2(Input.GetAxis("Mouse X"), 0);
                //Grab input vectors and spin cinemachina camera accordingly.
                cinemachine.m_XAxis.Value += delta.x * lookSpeed * Time.deltaTime;
            }

            if (zoomChange != 0)
            {
                cinemachine.m_YAxis.Value += zoomChange * zoomSpeed * Time.deltaTime;
            }
        }
    }

}
