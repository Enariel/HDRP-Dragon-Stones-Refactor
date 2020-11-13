//Copyright (c) FuchsFarbe

using System;
using System.Collections.Generic;
using UnityEngine;
using Dragon_Stones.Spell_System.Forms;
using System.Collections;
using Dragon_Stones.Game_Managers.Target;

namespace Dragon_Stones.Spell_System
{
	public class Process_Forms
	{
		private Cast castInst;
		private List<Form> forms;
		private GameObject caster;
		private Vector3 target;

		public Process_Forms(Cast aCastInst, List<Form> forms, GameObject caster)
		{
			this.castInst = aCastInst;
			this.forms = forms;
			this.caster = caster;
		}
		public IEnumerator ProcessForm()
		{
			//Get caster information
			var casterTargets = caster.GetComponent<Target_System>();
			GameObject[] targetsInRange;
			GameObject mainTarget;

			Vector3 mainTargPos;
			Vector3 casterTargPos;

			casterTargPos = caster.transform.position;

			if (casterTargets == null || casterTargets.targets.Count > 0)
			{
				targetsInRange = caster.GetComponent<Target_System>().targets.ToArray();
				mainTarget = targetsInRange[0];
				mainTargPos = mainTarget.transform.position;
			}
			else
			{
				targetsInRange = null;
				mainTarget = null;
				mainTargPos = new Vector3(casterTargPos.x, casterTargPos.y, casterTargPos.z) + Vector3.forward;
			}

			casterTargPos = caster.transform.position;

			foreach (Form form in forms)
			{
				var targetStyle = form.target;
				var multiTarget = form.multiTarget;

				if (form != null)
				{
					//If a target doesnt exist, the target style is forward. 
					if (targetsInRange.Length < 1)
					{
						targetStyle = FormTarget.Direction;
					}
					//Do things based off each forms target.
					switch (targetStyle)
					{
						case FormTarget.Caster:
							yield return form.DoForm(castInst, caster, casterTargPos);
							break;
						case FormTarget.Target:
							if (multiTarget == true)
							{
								foreach (GameObject target in targetsInRange)
								{
									Vector3 targPos = target.transform.position;
									yield return form.DoForm(castInst, target, targPos);
								}
							}
							else
							{
								yield return form.DoForm(castInst, mainTarget, mainTargPos);
							}
							break;
						case FormTarget.Direction:
							//TODO
							yield return form.DoForm(castInst, caster, caster.transform.position + Vector3.forward);
							break;
						case FormTarget.Point:
							//TODO: get point from raycast if player, else get player position from enemy caster position
							break;
					}
					Debug.Log("Doing form: " + form.name);
				}
				else
				{
					Debug.Log("No forms");
				}
			}
			yield return null;
		}
		public IEnumerator ProcessEndForm()
		{
			foreach (Form form in forms)
			{
				form.Reset();
			}
			yield return null;
		}
	}
}
