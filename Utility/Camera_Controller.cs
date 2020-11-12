//copyright (c) FuchsFarbe

using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using Dragon_Stones.Input;

namespace Dragon_Stones.CameraController
{
    [RequireComponent(typeof(CinemachineFreeLook))]
    public class Camera_Controller : MonoBehaviour
    {
        //References
        private CinemachineFreeLook cinemachine;
        private GameObject player;
        //Variables
        public float lookSpeed = 1f;
        public float zoomSpeed = 1f;

        #region Input Events
        //Main controls
        private Dragon_Stones_Input inputMaps;
        //Individual events
        private InputAction camRotation;
        private InputAction camZoom;
        #endregion



        private void Awake()
        {
            //Create new input map instance
            inputMaps = new Dragon_Stones_Input();
            //Grab input controller and cinemachine cam
            camRotation = inputMaps.Player.Camera_Rotate;
            camZoom = inputMaps.Player.Camera_Zoom;
        }
		private void Start()
		{
            cinemachine = GetComponent<CinemachineFreeLook>();
        }
		private void Update()
        {
            MoveCamera(camRotation.ReadValue<float>(), camZoom.ReadValue<float>());
        }
		private void OnEnable()
		{
            camRotation.Enable();
            camZoom.Enable();
		}
        private void OnDisable()
		{
            camRotation.Disable();
            camZoom.Disable();
		}

		void MoveCamera(float x, float y)
        {
            float zoomChange = y;

            Vector2 delta = new Vector2(x, 0);
            //Grab input vectors and spin cinemachina camera accordingly.
            cinemachine.m_XAxis.Value += delta.x * lookSpeed * Time.deltaTime;

            if (zoomChange != 0)
            {
                cinemachine.m_YAxis.Value += zoomChange * zoomSpeed * Time.deltaTime;
            }
        }
    }

}
