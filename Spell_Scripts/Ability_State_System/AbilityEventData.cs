//Copyright (c) FuchsFarbe

using System;
using System.Collections.Generic;
using UnityEngine;
using Dragon_Stones.Spell_System.Forms;

namespace Dragon_Stones.Spell_System
{
	[Serializable]
	public class AbilityEventData
	{
		[SerializeField] private SpellEvent eventType;
		[SerializeField] private List<Form> forms;

		public AbilityEventData(SpellEvent eventType, List<Form> forms)
		{
			this.eventType = eventType;
			this.forms = forms;
		}
		public SpellEvent EventType { get => eventType; set => eventType = value; }
		public List<Form> Forms { get => forms; set => forms = value; }
	}
}
