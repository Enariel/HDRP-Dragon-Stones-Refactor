//Copyright (c) FuchsFarbe

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ============================================
*               Attach Form
* --------------------------------------------
*       This attaches a buff or debuff and 
*   uses a IBuff interface.
*  ===========================================
*/
namespace Dragon_Stones.Spell_System.Forms
{
	[CreateAssetMenu(fileName = "New Attachment Form", menuName = "Form/Attach Form")]
	public class Attach_Form : Form
	{
		#region Variables

		//References

		//Variables
		public GameObject[] effectObjs;
		#endregion
		public override IEnumerator DoForm(Cast castInst, GameObject target, Vector3 targetPos)
		{
			yield return new WaitForSeconds(.1f);
			Debug.Log("Attached a buff");
		}
		private void AddFormToTarget(Cast castInst, Element elem, GameObject targetObj)
		{
			switch (elem)
			{
				//Add a new component monobehaviour to target that destroys itself after a set time.
				//Only add it if target doesnt have it.
				case Element.Air:
					Debug.Log("Target is slowed");
					break;
				case Element.Dragon:
					Debug.Log("Target is poisoned");
					break;
				case Element.Earth:
					Debug.Log("Target is petrified");
					break;
				case Element.Fire:
					Debug.Log("Target is burning");
					break;
				case Element.Physical:
					Debug.Log("Target is bleeding");
					break;
				case Element.Water:
					Debug.Log("Target is frozen");
					break;
			}
		}
	}
}