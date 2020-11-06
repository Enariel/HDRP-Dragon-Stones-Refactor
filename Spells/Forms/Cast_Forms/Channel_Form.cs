//Copyright (c) FuchsFarbe

using System;
using System.Collections;
using UnityEngine;
using Dragon_Stones.Events;
using Dragon_Stones.Game_Managers.Time_System;
using System.Collections.Generic;
/* ============================================
*                   Name
* --------------------------------------------
*           - Summary of script - 
*  ===========================================
*/
namespace Dragon_Stones.Spell_System.Forms
{
	[CreateAssetMenu(fileName = "New Channel Form", menuName = "Form/Channel Form")]
	public class Channel_Form : Form
	{
		[SerializeField] private int channelTime;

		public override IEnumerator DoForm(GameObject caster, List<GameObject> targets)
		{
			yield return new WaitForEndOfFrame();
			Debug.Log(channelTime);
		}
	}
}