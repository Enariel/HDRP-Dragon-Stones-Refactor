
using System.Collections;
using UnityEngine;

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
		public LayerMask groundMask;
		//Variables

		#endregion

		#region Unity Methods
		private void Start()
		{
			gameManager = GameObject.FindGameObjectWithTag("GameController");
			rb = this.gameObject.GetComponent<Rigidbody>();
			controller = this.gameObject.GetComponent<CharacterController>();
			groundMask = LayerMask.GetMask("Ground");
		}
		#endregion
		public void LookTarget(Transform target)
		{
			StartCoroutine(Look(target));
		}
		public IEnumerator Look(Transform target)
		{
			yield return new WaitForEndOfFrame();
			this.gameObject.transform.LookAt(target);
		}
	}
}
