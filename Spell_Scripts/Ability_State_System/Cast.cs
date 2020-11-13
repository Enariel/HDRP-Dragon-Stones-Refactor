//Copyright (c) FuchsFarbe

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dragon_Stones.Spell_System.Forms;

namespace Dragon_Stones.Spell_System
{
	public partial class Cast
	{
		//Variables
		[SerializeField] private Ability data;
		[SerializeField] private GameObject caster;
		[SerializeField] private GameObject target;
		private Dictionary<string, List<Form>> EventDict = new Dictionary<string, List<Form>>();

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

		//Constructor
		public Cast(Ability data, GameObject caster)
		{
			this.data = data;
			this.caster = caster;

			EventDict = new Dictionary<string, List<Form>>();

			foreach (AbilityEventData eventData in data.abilityEvents)
			{
				EventDict.Add(eventData.EventType.ToString(), eventData.Forms);
			}
		}
		//Ability IEnumerations
		//Entry for the spell or ability
		public IEnumerator OnCastExecute()
		{
			//Enum flags for spell comparisons
			var bFlags = Enum.GetValues(typeof(Behaviour));
			var spellFlags = data.behaviours;

			//Start ability
			yield return OnStart();

			//TODO add interruption for spellcasting.

			//Find its behaviours and do them
			foreach (Behaviour flag in bFlags)
			{
				switch (flag)
				{
					case Behaviour.AreaOfEffect:
						//Grab aoe information and create a new AoE behaviour class from it
						break;
					case Behaviour.BuffOrDebuff:
						//Create new buff behaviour class
						break;
					case Behaviour.CastTime:
						//Do 'OnSuccess' after a certain time has passed
						yield return OnCastTime();
						break;
					case Behaviour.Channeled:
						//Do 'OnSuccess' for ticks specified by duration
						yield return OnChannel();
						break;
					case Behaviour.StopMove:
						//The spell doesnt stop spell movement
						break;
				}
			}

			yield return null;
		}
		public IEnumerator OnStart()
		{
			if (EventDict[ON_START] != null)
			{
				yield return new Process_Forms(this, EventDict[ON_START], caster).ProcessForm();
			}
		}
		public IEnumerator OnCastTime()
		{

			Debug.Log("Loading spell: "+ data.id);
			yield return new WaitForSeconds(data.castTime);

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
				yield return new Process_Forms(this, EventDict[ON_SUCCESS], caster).ProcessForm();
			}
		}
		public IEnumerator OnEnd()
		{
			if (EventDict[ON_END] != null)
			{
				yield return new Process_Forms(this, EventDict[ON_END], caster).ProcessForm();
			}
			yield return new Process_Forms(this, EventDict[ON_END], caster).ProcessEndForm();
		}
		public IEnumerator OnProjectileHit(GameObject target)
		{
			if (EventDict[ON_PROJECTILE_HIT] != null)
			{
				yield return new Process_Forms(this, EventDict[ON_PROJECTILE_HIT], target).ProcessForm();
			}
		}
	}
}
