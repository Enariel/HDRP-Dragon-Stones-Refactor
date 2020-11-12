//Copyright (c) FuchsFarbe

using System;
using System.Collections.Generic;
using UnityEngine;
using Dragon_Stones.Spell_System.Forms;
using System.Collections;

namespace Dragon_Stones.Spell_System
{
	public class Process_Forms
	{
		private List<Form> forms;
		private GameObject caster;
		private Vector3 target;

		public Process_Forms(List<Form> forms, GameObject caster, Vector3 target)
		{
			this.forms = forms;
			this.caster = caster;
			this.target = target;
		}
		public IEnumerator ProcessForms()
		{
			yield break;
		}
	}
}
