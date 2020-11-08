//Copyright (c) FuchsFarbe

using Dragon_Stones.Spell_System;
using Dragon_Stones.Spell_System.Forms;
using System.Collections;
using UnityEngine;

/* ============================================
*               Sound Form
* --------------------------------------------
*		Dictates the sound at a certain state
*  ===========================================
*/
namespace Dragon_Stones
{
	[CreateAssetMenu(fileName = "New Sound Form", menuName = "Form/Sound Form")]
	public class Sound_Form : Form
	{
		#region Variables
		public AudioClip soundEffectObj;
		#endregion
		public override IEnumerator DoForm(Cast_Spell casterSpell, GameObject target, Vector3 targetPos)
		{
			yield return new WaitForEndOfFrame();
			Debug.Log("Sound played");
		}
	}
}