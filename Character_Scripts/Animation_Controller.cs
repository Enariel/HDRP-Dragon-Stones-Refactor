//Copyright (c) FuchsFarbe

using System;
using UnityEngine;
using Dragon_Stones.Input;
using Dragon_Stones.Character.Movement;

/* ============================================
*			Animation Controller
* --------------------------------------------
*           - Summary of script - 
*  ===========================================
*/
namespace Dragon_Stones.Character
{
    public class Animation_Controller : MonoBehaviour
	{
		#region Variables
		//References
		private Animator charAnimator;
		private Movement_Controller mc;
		#endregion

		#region Unity Methods
		private void Start()
		{
			charAnimator = this.GetComponent<Animator>();
			mc = this.GetComponent<Movement_Controller>();
			mc.OnCharacterMove += CharacterMoved;
			mc.OnCharacterIdle += CharacterIdled;
		}

		private void CharacterIdled(object sender, EventArgs e)
		{
			charAnimator.SetBool("IsIdle", true);
		}

		private void CharacterMoved(object sender, Movement_Controller.OnCharacterMovedArgs e)
		{
			charAnimator.SetBool("IsIdle", false);
			charAnimator.SetFloat("Speed", e.magnitude);
		}

		private void OnDisable()
		{

		}
		#endregion

		#region Events

		#endregion
	}
}