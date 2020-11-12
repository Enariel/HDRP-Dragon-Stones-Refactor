//Copyright (c) FuchsFarbe

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dragon_Stones.Spell_System.Forms;
using Dragon_Stones.Character.State;
using Dragon_Stones.Character.Movement;
using Dragon_Stones.Game_Managers.Target;

/* ============================================
*               Cast Spell
* --------------------------------------------
*		This script dictates how a spell is
*	cast as well as who cast it. This script
*	fully controls and implements a spell and
*	its forms.
*  ===========================================
*/
namespace Dragon_Stones.Spell_System
{
	[Serializable]
    public class Cast_Spell
    {
		#region Variables
		//Variables
		Vector3 castCenter = new Vector3();
		Vector3 targetPoint = new Vector3();
		private AoEInfo aoeData = new AoEInfo();
		//References
		private GameObject caster;
		private Character_Stats casterStats;
		private Movement_Controller casterMovement;

		private List<GameObject> targets;
		private GameObject casterAsTarget;
		private GameObject mainEnemyTarget;
		#endregion

		//Entry enumerator
		public IEnumerator Invoke()
		{
			targets = new List<GameObject>();

			var castPoint = caster.transform.position;

			#region Targetting
			//Get targetting information
			if (caster.GetComponent<Target_System>().targets != null)
			{
				targets = caster.GetComponent<Target_System>().targets;
				mainEnemyTarget = targets[0].gameObject;
			}

			//Checks null values
			if (spellData.needsCasterTarget && spellData.needsEnemyTarget)
			{
				if (!caster || !mainEnemyTarget)
				{
					Debug.Log("You need a caster AND a target.");
					yield return OnEnd();
				}
			}
			else if (spellData.needsCasterTarget)
			{
				if (!caster)
				{
					Debug.Log("You need a caster as a target.");
					yield return OnEnd();
				}
			}
			else if (spellData.needsEnemyTarget == true)
			{
				if (!mainEnemyTarget)
				{
					Debug.Log("You need a target.");
					yield return OnEnd();
				}
				else
				{
					if (SpellEventDict[ON_INVOKE] != null)
					{
						Debug.Log(spellData.title + " started to be cast.");
						yield return ProcessForms(SpellEventDict[ON_INVOKE]);
					}
				}
			}
			else
			{
				if (SpellEventDict[ON_INVOKE] != null)
				{
					Debug.Log(spellData.title + " started to be cast.");
					yield return ProcessForms(SpellEventDict[ON_INVOKE]);
				}
			}
			#endregion

			//Movement
			if (!spellData.behaviours.HasFlag(Behaviour.DontStopMove))
			{
				//Stop movement and look at target
				yield return casterMovement.Look(targets[0].transform);
			}
			else
			{
				casterMovement.LookTarget(targets[0].transform);
			}

			//If it needs to have a cast time first
			if (spellData.behaviours.HasFlag(Behaviour.CastTime))
			{
				//Cast first
				yield return null;
			}
			else if (spellData.behaviours.HasFlag(Behaviour.Channeled))
			{
				//Then channel
				yield return OnStart();
				yield return new WaitForSeconds(spellData.duration);
				yield return OnSuccess();
			}
			else
			{
				yield return OnStart();
			}

			if (spellData.isPassive == true)
			{
				if (SpellEventDict[ON_PASSIVE] != null)
				{
					Debug.Log(spellData.title + " started ON START");
					yield return OnPassive();
				}
				else
				{
					Debug.Log(spellData.title + " started ON START");
					yield return null;
				}
			}

			yield return OnEnd();
		}
		//State enumerators
		public IEnumerator OnStart()
		{
			//Start cooldown

			if (spellData.behaviours.HasFlag(Behaviour.AreaOfEffect))
			{
				//AoE hit check;
			}
			else
			{
				//targets.Add(mainEnemyTarget);
			}

			if (SpellEventDict[ON_START] != null)
			{
				Debug.Log(spellData.title + " started ON START");
				yield return ProcessForms(SpellEventDict[ON_START]);
			}
			else
			{
				Debug.Log("No ON START events");
				yield return null;
			}
		}
		public IEnumerator OnSuccess()
		{
			if (spellData.behaviours.HasFlag(Behaviour.AreaOfEffect))
			{
				//AoE hit check;
			}
			else
			{
				//targets.Add(mainEnemyTarget);
			}

			if (SpellEventDict[ON_SUCCESS] != null)
			{
				Debug.Log(spellData.title + " started ON SUCCESS");
				yield return ProcessForms(SpellEventDict[ON_SUCCESS]);
			}
			else
			{
				Debug.Log("No ON SUCCESS.");
				yield return null;
			}
		}
		public IEnumerator OnEnd()
		{
			Debug.Log("This spell: " + spellData.title + " has ended.");

			//Reset start forms

			if (SpellEventDict[ON_END] == null)
			{
				Debug.Log("No ON END.");
				yield return null;
			}
			else
			{
				yield return ProcessForms(SpellEventDict[ON_END]);
			}
		}
		public IEnumerator OnPassive()
		{
			while (true)
			{
				yield return new WaitForSeconds(.5f);
				ProcessForms(SpellEventDict[ON_PASSIVE]);
			}
		}
		//If a projectile form hits a thing
		public IEnumerator OnProjHit(GameObject target)
		{
			Debug.Log("On hit activated");

			if (ProcessForms(SpellEventDict[ON_PROJ_HIT]) != null && target != null)
			{
				foreach(Form form in SpellEventDict[ON_PROJ_HIT])
				{
					yield return form.DoForm(this, target, target.transform.position);
				}
			}
		}
		//Process forms in each state
		public IEnumerator ProcessForms(List<Form> forms)
		{
			foreach (Form form in forms)
			{
				Target mainTargetType = form.target;

				if (form != null)
				{
					Debug.Log("Performing form: " + form.name);

					switch (mainTargetType)
					{
						case Target.Caster:

							yield return form.DoForm(this, caster, caster.transform.position);
							Debug.Log("Current target for this form: " + caster.name);
							break;
						case Target.Target:

							if (form.multiTarget == true)
							{
								foreach (var target in targets)
								{
									targetPoint = target.transform.position;
									yield return form.DoForm(this, target, targetPoint);
									Debug.Log("Current target for this form: " + target.name);
								}
							}
							else
							{
								yield return form.DoForm(this, targets[0], targets[0].transform.position);
								Debug.Log("Current target for this form: " + targets[0].name);
							}
							
							break;
						case Target.Point:
							//Get mouse position from raycast, pass null value as cast target.
							RaycastHit hit;
							Ray ray = new Ray();

							if (caster.CompareTag("Player"))
							{

							}

							if (Physics.Raycast(ray, out hit))
							{
								//Look towards raycast and do form
								yield return form.DoForm(this, caster, hit.point);
							}
							else
							{
								yield return form.DoForm(this, null, hit.point);
							}
							break;
						case Target.Direction:
							//Gets forward vector of caster
							yield return form.DoForm(this, caster, caster.transform.forward);

							break;
					}
				}
			}
		}
	}
}