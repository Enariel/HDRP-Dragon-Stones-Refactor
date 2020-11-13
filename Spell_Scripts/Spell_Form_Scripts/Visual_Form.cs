//Copyright (c) FuchsFarbe

using System;
using System.Collections;
using UnityEngine;

/* ============================================
*					Visual Form
* --------------------------------------------
*		A form to create the visual effects of
*	a spell
*  ===========================================
*/
namespace Dragon_Stones.Spell_System.Forms
{
	[CreateAssetMenu(fileName = "New Visual Form", menuName = "Form/Visual Form")]
	public class Visual_Form : Form
	{
		#region Variables
		[SerializeField] private GameObject effectObj; //The visual effect to instantiate at the target position
		[SerializeField] private float duration; //How long does this last?
		[SerializeField] private Vector3 offset; //Its instantiation offset
		#endregion
		public override IEnumerator DoForm(Cast casterSpell, GameObject target, Vector3 targetPos)
		{
			yield return null;
		}
	}
}