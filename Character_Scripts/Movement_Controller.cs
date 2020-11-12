//copyright (c) FuchsFarbe

using System;
using System.Collections;
using UnityEngine;
using Dragon_Stones.Character.State;

/* ============================================
 *				Movement Controller
 * --------------------------------------------
 *		The base movement controller manages
 *	the player states as well as animations.
 *	Here all the required components are
 *	obtained and referenced, with different
 *	behaviours and modifications being made
 *	in the extended scripts.
 *		Animations are specified on animator
 *	components which extend the Humanoid
 *	animator.
 *  ===========================================
 */

namespace Dragon_Stones.Character.Movement
{
	[RequireComponent(typeof(Rigidbody), typeof(CharacterController))]
	public class Movement_Controller : MonoBehaviour
	{
		#region Variables
		//References
		public GameObject gameManager;
		public Rigidbody rb;
		public CharacterController controller;
		public Transform groundCheck;
		public LayerMask groundMask;
		//Variables
		public float groundCheckRadius = 0.1f;
		public float walkSpeed = 5f;
		public float runSpeed = 10f;
		public float jumpForce = 40f;
		public bool isRunning = false;
		public bool isGrounded = true;
		public bool isCasting = false;
		public bool isJumping = false;
		public const float GRAVITY = -9.81f;
		public Vector3 gVelocity;
		private Vector3 direction;
		public Vector3 Direction { get => direction; }
		//Events
		public event EventHandler<OnCharacterMovedArgs> OnCharacterMove;
		public event EventHandler OnCharacterIdle;
		public event EventHandler OnCharacterJump;
		public event EventHandler OnCharacterGrounded;
		public class OnCharacterMovedArgs : EventArgs
		{
			public float magnitude;

			public OnCharacterMovedArgs(float movement)
			{
				this.magnitude = movement;
			}
		}
		#endregion

		#region Unity Methods
		private void Update()
		{
			direction = Vector3.zero;
		}
		#endregion

		#region 
		public virtual void MoveCharacter(Vector2 input)
		{
			direction = new Vector3(input.x, 0f, input.y);

			//Invoke movement event for Animation script.

			if (direction != Vector3.zero)
			{
				if (isRunning)
				{
					OnCharacterMove?.Invoke(this, new OnCharacterMovedArgs(new Vector2(direction.x, direction.z).magnitude));
				}
				else
				{
					float jogSpecs = new Vector2(direction.x * .5f, direction.z * .5f).magnitude;
					OnCharacterMove?.Invoke(this, new OnCharacterMovedArgs(jogSpecs));
				}
			}
			else
			{
				OnCharacterMove?.Invoke(this, new OnCharacterMovedArgs(0));
				OnCharacterIdle?.Invoke(this, null);
			}
		}
		public virtual void Jump()
		{
			if (isGrounded)
			{
				gVelocity.y = Mathf.Sqrt(jumpForce * -2 * GRAVITY);
			}
		}
		public void LookTarget(Transform target)
		{
			StartCoroutine(Look(target));
		}
		public IEnumerator Look(Transform target)
		{
			yield return new WaitForEndOfFrame();
			this.gameObject.transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
		}
		public void DoGravity()
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
		#endregion
	}
}
