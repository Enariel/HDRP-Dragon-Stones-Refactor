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
		[Tooltip("The animation 'group' it belongs to. \n 0: For Auto attacks \n 1: For Magick \n 2: For Archery \n 3: For Melee \n 4: For Guns \n 5: For Life ")]
		[SerializeField] private int targetAnimationTypeID;
		[Tooltip("The animation ID to be used in conjunction with the aforementioned. To keep things easy the beginning number will reflect the above group. I.E. if its a magic animation, it will begin with the number '1'. ")]
		[SerializeField] private int targetAnimationID;
		[SerializeField] private float animDurationMultiplier = 1f;
		#endregion
		public override IEnumerator DoForm(Cast casterSpell, GameObject target, Vector3 targetPos)
		{
			yield return null;
			SetAnimations(casterSpell);

		}

		private void SetAnimations(Cast casterSpell)
		{
			Animator anim = casterSpell.Caster.GetComponent<Animator>();

			//Check null values and execute them if they arent null
			anim?.SetFloat("SpellDuration", animDurationMultiplier);
			anim?.SetInteger("AnimID", targetAnimationID);
			anim?.SetInteger("AnimTypeID", targetAnimationTypeID);
		}
	}
}