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
		//References
		[SerializeField] private Animator targetAnimController;
		#region Variables
		[SerializeField] private GameObject effectObj;
		[SerializeField] private string targetAnimationState;
		[SerializeField] private float duration;
		[SerializeField] private Vector3 offset;
		#endregion
		public override IEnumerator DoForm(Cast casterSpell, GameObject target, Vector3 targetPos)
		{
			yield return null;
		}
	}
}