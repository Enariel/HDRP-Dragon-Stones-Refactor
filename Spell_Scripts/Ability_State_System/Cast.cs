//Copyright (c) FuchsFarbe

using System;
using System.Collections.Generic;
using UnityEngine;
using Dragon_Stones.Spell_System.Forms;
using System.Collections;

namespace Dragon_Stones.Spell_System
{
	public class Cast : MonoBehaviour
	{
		[SerializeField] private Ability data;
		[SerializeField] private GameObject caster;
		[SerializeField] private GameObject target;

		public Cast(Ability data, GameObject caster, GameObject target)
		{
			this.data = data;
			this.caster = caster;
			this.target = target;
		}

		public Ability Data => data;
		public GameObject Caster => caster;
		public GameObject Target => target;

		public IEnumerator OnCastExecute()
		{
			yield break;
		}
		public IEnumerator OnProjectileHit(GameObject target)
		{
			yield break;
		}
	}
}
