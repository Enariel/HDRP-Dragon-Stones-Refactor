//copyright (c) FuchsFarbe

using System;
using UnityEngine;
using Dragon_Stones.Character.State;
using Dragon_Stones.Input;
using UnityEngine.InputSystem;
using Dragon_Stones.Inventory_Systems;

/* ============================================
 *              Player Movement
 * --------------------------------------------
 *      This script is just a controller for 
 *  the player's movement. Will eventually
 *  utilize Unity's Nav Mesh Agent.S
 *  ===========================================
 */

namespace Dragon_Stones.Character.Movement
{
    public class Player_Movement : Movement_Controller
    {
		#region Variables
		//References
		public Camera playerCam;
        //Variables
        [SerializeField] private float interactRange = 1.5f;
        [SerializeField] private float turnSmoothVelocity = 0.1f, turnSmoothTime = 0.1f;
        #endregion

        #region Input Events
        //Main controls
        private Dragon_Stones_Input inputMaps;
        //Action map
        private InputActionMap moveMap;
        //Individual events
        private InputAction movement;
        private InputAction run;
        private InputAction jump;
        private InputAction interact;
		#endregion

		#region Unity Methods
		void Awake()
		{
            canMove = true;

            inputMaps = new Dragon_Stones_Input();

            moveMap = inputMaps.Player;
            movement = inputMaps.Player.Movement;
            run = inputMaps.Player.Run;
            jump = inputMaps.Player.Jump;
            interact = inputMaps.Player.Interact;

			interact.performed += ctx => InteractWithObject();
		}

		void Start()
        {
            playerCam = Camera.main;
            gameManager = GameObject.FindGameObjectWithTag("GameController");
            rb = this.gameObject.GetComponent<Rigidbody>();
            controller = this.gameObject.GetComponent<CharacterController>();
            groundMask = LayerMask.GetMask("Ground");
            groundCheck = this.transform;
            groundCheck.position = transform.position - new Vector3(0f, -1f, 0);
        }
		void OnEnable()
		{
            interact.Enable();
            movement.Enable();
            run.Enable();
            jump.Enable();
        }
		void OnDisable()
		{
            interact.Disable();
            movement.Disable();
            run.Disable();
            jump.Disable();
        }
        void Update()
        {
            Run(run.ReadValue<float>());
            if (canMove == true) { MoveCharacter(movement.ReadValue<Vector2>()); }
            DoGravity();
        }
        void OnDrawGizmos()
		{
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(this.gameObject.transform.position, interactRange);
		}
		#endregion

		//Player movement methods
		public override void MoveCharacter(Vector2 input)
        {            
            //Get direction from input
            base.MoveCharacter(input);
            Direction.Normalize();
            //Function to move the player
            if (Direction != Vector3.zero && isRunning)
            {
                float targetAngle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg + playerCam.transform.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                controller.Move(moveDir * runSpeed * Direction.magnitude * Time.deltaTime);
            }
            else if (Direction != Vector3.zero)
            {
                float targetAngle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg + playerCam.transform.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                controller.Move(moveDir * walkSpeed * Direction.magnitude * Time.deltaTime);
            }
        }
        private void PlayerJump()
        {
            if (isGrounded == true)
            {
                base.Jump();
            }
        }
        private void Run(float ctx)
        {
            if (ctx >= .1f)
            {
                isRunning = true;
            }
            else
            {
                isRunning = false;
            }
        }
        private void InteractWithObject()
		{
			//TODO: Rotate player towards object
            for (int i = 1; i < FindNearbyObjects().Length; i++)
			{
                var interactTarget = FindNearbyObjects()[i]?.GetComponent<IInteractable>();
                interactTarget?.Interact();
            }
		}

		private Collider[] FindNearbyObjects()
		{
			Collider[] colliders = new Collider[0];
			colliders = Physics.OverlapSphere(this.gameObject.transform.position, interactRange);
			return colliders;
		}
	}
}
