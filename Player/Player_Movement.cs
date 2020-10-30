/* ============================================
 *              Player Movement
 * --------------------------------------------
 *      This script is just a controller for 
 *  the player's movement. Will eventually
 *  utilize Unity's Nav Mesh Agent.
 *  ===========================================
 */
namespace Dragon_Stones.Character.Player.Movement
{
    using UnityEngine;

    public class Player_Movement : MonoBehaviour
    {
        //References
        public GameObject gameManager;
        public Rigidbody playerBody;
        public Camera playerCam;
        public CharacterController controller;
        public LayerMask groundMask;

        //Variables
        //These are public because we want these to be modified later
        public int walkSpeed;
        public int runSpeed;
        public float jumpForce = 40f;

        //Public for knockbacks and other uses
        public bool isGrounded = true;
        private Vector3 direction;
        private Vector3 gVelocity;
        private Transform groundCheck;
        [SerializeField]
        private float turnSmoothVelocity = 0.1f, turnSmoothTime = 0.1f;
        private const float GRAVITY = -9.81f;
        private float groundCheckRadius = 0.4f;
        public bool run;

        // Start is called before the first frame update
        void Start()
        {
            //Obtain references
            playerBody = GetComponent<Rigidbody>();
            controller = GetComponent<CharacterController>();
            groundCheck = this.transform;
            gameManager = GameObject.FindGameObjectWithTag("GameController");
            playerCam = Camera.main;
            groundCheck.position = transform.position - new Vector3(0f, -1f, 0);
        }

        //Function to move the player
        public void MovePlayer(Vector2 input)
        {
            direction = new Vector3(input.x, 0f, input.y).normalized;

            if (direction.magnitude >= .01f)
            {
                if (run)
                {
                    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCam.transform.eulerAngles.y;
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

                    transform.rotation = Quaternion.Euler(0f, angle, 0f);
                    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                    controller.Move(moveDir * runSpeed * Time.deltaTime);
                }
                else
                {
                    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCam.transform.eulerAngles.y;
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

                    transform.rotation = Quaternion.Euler(0f, angle, 0f);
                    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                    controller.Move(moveDir * walkSpeed * Time.deltaTime);
                }
            }
        }

        public void isRunning(float ctx)
        {
            if (ctx > .015f)
            {
                run = true;
            }
            else
            {
                run = false;
            }
        }

        public void Jump(float ctx)
        {
            if (ctx > .15f && isGrounded)
            {
                gVelocity.y = Mathf.Sqrt(jumpForce * -2 * GRAVITY);
            }
        }
        void DoGravity()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);

            if (isGrounded && gVelocity.y < 0)
            {
                gVelocity.y = -2f;
            }
            //Multiplied times Time.deltaTime twice to square the gravity.
            gVelocity.y += GRAVITY * Time.deltaTime;
            controller.Move(gVelocity * Time.deltaTime);
        }

        public void Update()
        {
            MovePlayer(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
            DoGravity();
        }
    }
}
