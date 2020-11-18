//Copyright (c) FuchsFarbe

using System.Collections;
using UnityEngine;

/* ============================================
*               Buff Form
* --------------------------------------------
*       This attaches only buffs to the target
*  ===========================================
*/
namespace Dragon_Stones.Spell_System.Forms
{
	[CreateAssetMenu(fileName = "New Elemental Buff Form", menuName = "Form/Elemental Buff Form")]
	public class Buff_Form : Form
	{
		#region Variables

		//References

		//Variables

		#endregion
		public override IEnumerator DoForm(Cast casterSpell, GameObject target, Vector3 targetPos)
		{
			yield break;
			Debug.Log("Attached a buff");
		}

		private void AddBuffToTarget(Element elem, GameObject targetObj)
		{
			switch (elem)
			{
				//Add a new component monobehaviour to target that destroys itself after a set time.
				//Only add it if target doesnt have it.
				case Element.Air:
					Debug.Log("Target DEX up.");
					break;
				case Element.Dragon:
					Debug.Log("Target main MagDEF up.");
					break;
				case Element.Earth:
					Debug.Log("Target can't be knocked down.");
					break;
				case Element.Fire:
					Debug.Log("Target STR up.");
					break;
				case Element.Physical:
					Debug.Log("Target DEF up");
					break;
				case Element.Water:
					Debug.Log("Target INT up");
					break;
			}
		}
	}
}