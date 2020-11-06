//Copyright (c) FuchsFarbe

using System;
using System.Collections;
using UnityEngine;
using Dragon_Stones.Events;
using Dragon_Stones.Game_Managers.Time_System;
/* ============================================
*                   Name
* --------------------------------------------
*           - Summary of script - 
*  ===========================================
*/
namespace Dragon_Stones.Spell_System.Forms
{
	public class Channel_Form : Form
	{
		private Action<TickTimeArgs> tickListener;
		private int channelTime;
		public override void DoForm(InvokeSpell invoke, GameObject target)
		{
			StartCoroutine(invoke.ChannelOrChargeCast(invoke.spell.Duration));
		}
	}
}