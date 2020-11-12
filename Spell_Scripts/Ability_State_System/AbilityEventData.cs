//Copyright (c) FuchsFarbe

using System;
using System.Collections.Generic;
using UnityEngine;
using Dragon_Stones.Spell_System.Forms;
using System.Collections;

namespace Dragon_Stones.Spell_System
{
	[Serializable]
	public class AbilityEventData
	{
		[SerializeField] private FormTarget target;
		[SerializeField] private List<Form> forms;

		public AbilityEventData(FormTarget target, List<Form> forms)
		{
			this.target = target;
			this.forms = forms;
		}
	}
}
