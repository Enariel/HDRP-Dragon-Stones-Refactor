//Copyright (c) FuchsFarbe

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dragon_Stones.Spell_System.Forms;
using Dragon_Stones.Game_Managers.Target;
using Dragon_Stones.Character.Stats;
using Dragon_Stones.Character.Stats.Player;
using System;

/* ============================================
*               Cast Spell
* --------------------------------------------
*           - Summary of script - 
*  ===========================================
*/
namespace Dragon_Stones.Spell_System
{
	[Serializable]
    public class Cast_Spell
    {
		#region Variables

		//References
		public Spell spell;
		public GameObject caster;
		public Character_Stats casterStats;
		public List<SpellEventData> spellEventData;
		//Variables
		public Dictionary<string, List<Form>> eventsInSpell = new Dictionary<string, List<Form>>();
		
		//Targets
		private List<GameObject> targets;
		private GameObject mainTarget;

		//Behaviours
		private bool canTargetSelf;
		private bool canTargetEnemy;
		private bool canTargetGround;
		public bool AoE;
		public bool AutoCast;
		public bool HasCastTime;
		public bool IsChanneled;
		public bool IsDirectional;
		public bool DontStopMove;
		public bool IsImmediate;
		public bool NoTarget;
		public bool IsPassive;
		public bool IsPointTarget;
		public bool SomeTarget;
		public bool StopMove;

		//Event strings
		private string ON_CAST_START = SpellEvent.OnCastStart.ToString();
		private string ON_SPELL_CHANNEL = SpellEvent.OnSpellChannel.ToString();
		private string ON_SPELL_CHANNEL_SUCCEED = SpellEvent.OnSpellChannelSucceed.ToString();
		private string ON_SPELL_START = SpellEvent.OnSpellStart.ToString();
		private string ON_SPELL_END = SpellEvent.OnSpellEnd.ToString();
		#endregion

		//Constructor
		public Cast_Spell(Spell aSpell, GameObject aCaster, List<SpellEventData> aEventData)
		{
			this.spell = aSpell;
			this.caster = aCaster;
			//Bools
			this.canTargetSelf = aSpell.canTargetSelf;
			this.canTargetEnemy = aSpell.canTargetEnemy;
			this.canTargetGround = aSpell.canTargetGround;
			this.AoE = aSpell.AoE;
			this.AutoCast = aSpell.AutoCast;
			this.HasCastTime = aSpell.HasCastTime;
			//Event Data
			this.spellEventData = aEventData;


			foreach (SpellEventData eventData in spellEventData)
			{
				eventsInSpell.Add(eventData.spellEvent.ToString(), eventData.forms);
			}

			if (caster.GetComponent<Target_System>() != null)
			{
				this.targets = caster.GetComponent<Target_System>().targets;
			}
			if (caster.GetComponent<Character_Stats>() != null)
			{
				this.casterStats = caster.GetComponent<Character_Stats>();
			}
		}

		#region Spell Events
		public IEnumerator OnCastStart()
		{
			Debug.Log("Casting started");

			if (eventsInSpell[ON_CAST_START] != null)
			{
				yield return ProcessForms(eventsInSpell[ON_CAST_START]);
			}
			if (!StopMove)
			{
				yield return ProcessForms(eventsInSpell[ON_SPELL_START]);
			}

			yield return ProcessForms(eventsInSpell[ON_CAST_START]);

		}

		//This is what gets called to cast the spell. 
		public IEnumerator OnSpellStart(GameObject caster)
        {
			
            yield return ProcessForms(eventsInSpell[ON_SPELL_START]);
        }
        public IEnumerator OnSpellChannel()
		{
			yield return null;
		}
        public IEnumerator OnSpellChannelSucceed()
		{
			yield return null;
		}
        public IEnumerator OnSpellEnd()
        {
            yield return null;
        }
		//This will do each action, PER EVENT
		public IEnumerator ProcessForms(List<Form> forms)
		{
			Debug.Log("Processing Forms");

			foreach (Form form in forms)
			{
				
				yield return form.DoForm(caster, targets);
			}
		}
		#endregion

	}
}