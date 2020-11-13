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
		[Tooltip("The animation 'group' it belongs to. \n 0: For Auto attacks \n 1: For Magick \n 2: For Archery \n 3: For Melee \n 4: For Guns \n 5: For Life ")]
		[SerializeField] private int targetAnimationTypeID;
		[Tooltip("The animation ID to be used in conjunction with the aforementioned. To keep things easy the beginning number will reflect the above group. I.E. if its a magic animation, it will begin with the number '1'. ")]
		[SerializeField] private int targetAnimationID;
		[SerializeField] private SpellEvent eventType;
		[SerializeField] private List<Form> forms;

		public AbilityEventData(SpellEvent eventType, List<Form> forms)
		{
			this.eventType = eventType;
			this.forms = forms;
		}
		public SpellEvent EventType { get => eventType; set => eventType = value; }
		public List<Form> Forms { get => forms; set => forms = value; }
		public int TargetAnimation { get => targetAnimationID; set => targetAnimationID = value; }
		public int TargetAnimationTypeID { get => targetAnimationTypeID; set => targetAnimationTypeID = value; }
	}
}
