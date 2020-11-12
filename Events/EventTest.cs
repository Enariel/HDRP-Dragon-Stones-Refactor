using System;
using UnityEngine;
using UnityEngine.Events;
/* ============================================
 *              Event Testing
 * --------------------------------------------
 *      Template for learning events.
 *      This class acts like a listener to base
 *  events. Events MUST be subscribed AND 
 *  unsubscribed using OnEnable/Disable,
 *		
 *  ===========================================
 */
namespace Dragon_Stones.Events
{
	public class EventTest : MonoBehaviour
    {
		//Reference to Unityactions
		private Action listener; //This is what commands the other functions here to do stuff

		#region Unity Methods

		private void Awake()
		{
			listener = new Action(ThisFunction);
			listener += ThatFunction; //Can subscribe to more than one method.
		}

		//Mandatory for using events.
		private void OnEnable()
		{
			WorldEvents.StartListen("Class 1 Test", listener);
		}

		private void OnDisable()
		{
			WorldEvents.StopListen("Class 1 Test", listener);
		}

		#endregion

		#region Event Methods
		private void ThisFunction()
		{
			Debug.Log("This function");
		}
		private void ThatFunction()
		{
			Debug.Log("That function");
		}
		#endregion
	}
}