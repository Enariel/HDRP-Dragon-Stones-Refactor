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
		public GameObject effectObj;
		public bool isSpin;
		public float duration;
		public Vector3 offset;
		#endregion
		public override IEnumerator DoForm(Cast_Spell casterSpell, GameObject target, Vector3 targetPos)
		{
			duration = casterSpell.SpellData.duration;
			CreateEffectObj(target);
			yield return null;
		}

		//Create it and play its animations
		public void CreateEffectObj(GameObject target)
		{
			GameObject effectInst = Instantiate(effectObj, target.transform.position, target.transform.rotation) as GameObject;
			effectInst.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
		}
	}
}