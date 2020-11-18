//Copyright (c) FuchsFarbe

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dragon_Stones.Spell_System.Forms;
using Dragon_Stones.Character.Movement;
using Dragon_Stones.Character.State;

namespace Dragon_Stones.Spell_System
{
	public partial class Cast
	{
		//References
		private Ability data;
		private GameObject caster;
		private GameObject target;
		private Animator anim;
		private Movement_Controller move;
		//Variables
		private Dictionary<string, List<Form>> EventDict = new Dictionary<string, List<Form>>();
		private Dictionary<string, int> animID = new Dictionary<string, int>();
		private Dictionary<string, int> animTypeID = new Dictionary<string, int>();

		float timer = 0f;

		//Event dictionary
		private string ON_START = SpellEvent.OnStart.ToString();
		private string ON_SUCCESS = SpellEvent.OnSuccess.ToString();
		private string ON_PROJECTILE_HIT = SpellEvent.OnProjectileHit.ToString();
		private string ON_END = SpellEvent.OnEnd.ToString();

		//Getters
		public Ability Data { get => data; }
		public GameObject Caster { get => caster; }
		public GameObject Target { get => target; }
		public Animator Anim { get => anim; set => anim = value; }
		public Movement_Controller Move { get => move; set => move = value; }
		public Dictionary<string, List<Form>> _EventDict { get => EventDict; set => EventDict = value; }
		public Dictionary<string, int> AnimID { get => animID; set => animID = value; }
		public Dictionary<string, int> AnimTypeID { get => animTypeID; set => animTypeID = value; }

		//Constructor
		public Cast(Ability data, GameObject caster)
		{
			this.data = data;
			this.caster = caster;

			EventDict = new Dictionary<string, List<Form>>();
			animTypeID = new Dictionary<string, int>();
			animID = new Dictionary<string, int>();

			foreach (AbilityEventData eventData in data.abilityEvents)
			{
				EventDict.Add(eventData.EventType.ToString(), eventData.Forms);
			}
		}

		//Ability IEnumerations
		//Entry for the spell or ability
		public IEnumerator OnCastExecute()
		{
			//Get animator component
			anim = caster.GetComponent<Animator>();
			//Get movement component
			move = caster.GetComponent<Movement_Controller>();
			move.canMove = false;
			anim.SetBool("IsIdle", true);
			//Enum flags for spell comparisons
			var bFlags = Enum.GetValues(typeof(Behaviour));
			var spellFlags = data.behaviours;

			//Start ability
			yield return OnStart();

			//TODO add interruption for spellcasting.

			//Find its behaviours and do them before doing casting behaviours
			if (spellFlags.HasFlag(Behaviour.AreaOfEffect))
			{
				yield return null;
			}
			if (spellFlags.HasFlag(Behaviour.BuffOrDebuff))
			{
				yield return null;
			}
			if (spellFlags.HasFlag(Behaviour.CastTime))
			{
				yield return OnCastTime();
			}
			if (spellFlags.HasFlag(Behaviour.Channeled))
			{
				yield return OnChannel();
			}
			if (spellFlags.HasFlag(Behaviour.Directional))
			{
				yield return null;
			}
			if (spellFlags.HasFlag(Behaviour.StopMove))
			{
				yield return null;
			}
			if (spellFlags.HasFlag(Behaviour.TurnTowardsEnemy))
			{
				yield return null;
			}

			yield return OnEnd();
		}
		public IEnumerator OnStart()
		{
			anim.SetBool("IsCasting", true);

			if (EventDict[ON_START] != null)
			{
				yield return new Process_Forms(this, EventDict[ON_START], caster).ProcessForm();
			}
		}
		public IEnumerator OnCastTime()
		{
			anim.SetBool("IsCharging", true);

			yield return new WaitForSeconds(data.castTime);

			anim.SetBool("IsCharging", false);

			yield return new Process_Forms(this, EventDict[ON_SUCCESS], caster).ProcessForm();
		}
		public IEnumerator OnChannel()
		{
			int channelTimer = 0;

			while (channelTimer < data.duration)
			{
				yield return OnSuccess();
				yield return new WaitForSeconds(1f);
				channelTimer += 1;
			}
		}
		public IEnumerator OnSuccess()
		{
			if (EventDict[ON_SUCCESS] != null)
			{
				//Invert the time and multiply it by length so an appropriate duration is reached.
				var clipInfo = anim.GetCurrentAnimatorClipInfo(0);
				var clipTime = clipInfo[0].clip.length;

				Debug.Log(clipTime + " " + data.duration);
				//If duration is 0, make sure the clip can still play
				if (data.duration > 0f)
				{
					anim.SetFloat("SpellDuration", (1 / data.duration) * clipTime);
				}
				else
				{
					anim.SetFloat("SpellDuration", 1f);
				}

				yield return new Process_Forms(this, EventDict[ON_SUCCESS], caster).ProcessForm();
			}
			else
			{
				yield return null;
			}
		}
		public IEnumerator OnEnd()
		{
			anim.SetBool("IsCasting", false);

			if (EventDict[ON_END] != null)
			{
				yield return new Process_Forms(this, EventDict[ON_END], caster).ProcessForm();
				move.canMove = true;
			}
			else
			{
				move.canMove = true;
			}
		}
		public void OnProjectileHit(Cast castInst, GameObject target, List<Form> onHitForms)
		{
			var targetHit = target.GetComponent<Character_Stats>();

			if (onHitForms == null)
			{
				Debug.Log("No on hit forms");				
			}
			else
			{
				targetHit.StartCoroutine(targetHit.DoProjectileHitForms(castInst, onHitForms, castInst.caster));
			}
		}
	}
}
