//copyright (c) FuchsFarbe

using System;
using UnityEngine;
using Dragon_Stones.Events;
using Dragon_Stones.Game_Managers.Time_System;
using Dragon_Stones.Game_Managers;
using Dragon_Stones.Input;
using Dragon_Stones.Spell_System.Forms;
using System.Collections.Generic;
using Dragon_Stones.Spell_System;
using System.Collections;

/* ============================================
 *              Character Stats
 * --------------------------------------------
 *      This is an archetype class for mobs
 *  meant for creating base stats for any 
 *  entity in the game. Each character has the
 *  potential to utilize the passive Regen 
 *  function.
 *      Character stats appear on game objects
 *  themselves so they are easier to find and 
 *  reference.
 *  ===========================================
 */

namespace Dragon_Stones.Character.State
{
    public class Character_Stats : MonoBehaviour, IDamage
    {
        [Header("Cost Stats")]
        [SerializeField] private float startMaxHP;
        [SerializeField] private float startMaxPhyr;
        //Magic skills use magic, guns use STR and DEX, Archery uses DEX, Melee uses STR
        //If a staff, wand, or gloves equipped, melee uses MAG. 
        [Header("Damage Stats")]
        [SerializeField] private float startStr;
        [SerializeField] private float startMag;
        [SerializeField] private float startDex;

        [Header("Defense Stats")]
        [SerializeField] private float startPhysDef;
        [SerializeField] private float startMagDef;

        [Header("Events")]
        private Action<TickTimeArgs> tickListener;
        private List<Form> onhitforms = new List<Form>();


        public float StartMaxHP { get => startMaxHP; set => startMaxHP = value; }
        public float StartMaxPhyr { get => startMaxPhyr; set => startMaxPhyr = value; }
        public float StartStr { get => startStr; set => startStr = value; }
        public float StartMag { get => startMag; set => startMag = value; }
        public float StartDex { get => startDex; set => startDex = value; }
		public float StartPhysDef { get => startPhysDef; set => startPhysDef = value; }
		public float StartMagDef { get => startMagDef; set => startMagDef = value; }
		public List<Form> Onhitforms { get => onhitforms; }

		#region Unity Methods
		private void Awake()
		{
            tickListener = new Action<TickTimeArgs>(OnTick);
		}
		//Enable and disable listeners
		private void OnEnable()
		{
            WorldEvents.StartListen("Tick", tickListener);
		}

        private void OnDisable()
		{
            WorldEvents.StopListen("Tick", tickListener);
		}

		#endregion
        public IEnumerator DoProjectileHitForms(Cast castInst, List<Form> onHitForms, GameObject caster)
		{
            yield return new Process_Forms(castInst, onHitForms, caster).ProcessForm();
		}

		public virtual void RegenStats() { }
        public virtual void OnTick(TickTimeArgs tick) { }
		public void OnDamage(Damage_Calculation dmgCalc)
		{
            return;
		}
        public void OnEquip()
		{
            //When a character equips something, refresh stats.
            return;
		}
        public void OnRefresh()
		{
            //This function refreshes stats of a character
            return;
		}
	}
}