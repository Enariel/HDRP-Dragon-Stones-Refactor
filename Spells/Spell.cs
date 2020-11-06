using System;
using System.Collections.Generic;
using UnityEngine;
using Dragon_Stones.Character.Stats;

/* ============================================
 *                    Spell
 * --------------------------------------------
 *      Spell is the base scriptable object 
 *  from which all other spells will come from.
 *  
 *      Spells are given several enumerations,
 *  from there the enumerations dictate, via
 *  Forms, their behaviours.
 *  ===========================================
 */

namespace Dragon_Stones.Spell_System
{
    #region Enums
    //Which behaviours to add to the spell
    public enum EffectForm
    {
        Knockback,
        Knockdown,
        DoT,
        LinearProj,
        TrackingProj,
        Blink,
        AoE,
        ModifyStat
    }
    //How is it cast
    public enum CastForm
    {
        instant,
        channel,
        charge,
    }
    //Which stat is deducted or modified?
    public enum CostStat
    {
        HP,
        Phyr
    }
    //What kind of target style?
    public enum TargetStyle
    {
        None,
        Caster,
        Target,
        Point
    }
    //Elemental damage types
    public enum Element
    {
        Physical = 1 << 0,
        Water = 1 << 1,
        Earth = 1 << 2,
        Fire = 1 << 3,
        Air = 1 << 4,
        Dragon = 1 << 5
    }
    //What type of spell is it?
    public enum CastStyle
	{
        Melee = 1 << 0,
        Ranged = 1 << 1,
        Magic = 1 << 2,
	}

    #endregion

    [CreateAssetMenu(menuName = "Spell")]
    public abstract class Spell : ScriptableObject
    {

        [Header("Spell Details")]
        [SerializeField] private string title;
        [SerializeField] private string desc;
        [Tooltip("In Ticks")]
        [SerializeField] private int duration; //In ticks
        [SerializeField] private GameObject[] spellObjs; //Should only be one except in the cases of 2H weapons

        [Header("Forms")]
        [SerializeField] private Element element;
        [SerializeField] private EffectForm effectForm;
        [SerializeField] private TargetStyle target;
        [SerializeField] private CastStyle castStyle;
        [SerializeField] private CastForm castForm;
        [SerializeField] private CostStat costStat;
        [SerializeField] private SpellEffect[] spellEffects;

		public string Title { get => title; }
		public string Desc { get => desc; }
		public int Duration { get => duration; }
		public GameObject[] SpellObjs { get => spellObjs; }
		public EffectForm EffectForm { get => effectForm; }
		public TargetStyle Target { get => target; }
        public CastStyle CastStyle { get => castStyle; }
        public CastForm CastForm { get => castForm; }
        public Element Element { get => element; }
        public CostStat CostStat { get => costStat; }
        public SpellEffect[] SpellEffects { get => spellEffects; }

		#region Getters

		#endregion

		#region Unity Methods
		void Awake()
		{
		}

        void OnEnable()
		{
		}

        void OnDisable()
		{
        }
        #endregion

        public void Cast(Spell spell, GameObject caster)
		{

		}
    }

    #region Spell Visuals and Sounds
    // When an artist makes a visual effect, they generally make a GameObject Prefab.
    // You can extend this base class to support different kinds of visual effects
    // such as particle systems, post-processing screen effects, etc.
    [Serializable]
    public class SpellEffect
    {
        public VisualForm visual;
        public SoundForm sound;
    }
    [Serializable]
    public class VisualForm
    {
        public GameObject objFx;
        public virtual void PlayEffect()
		{
            Debug.Log("Visual is playing");
		}
    }
    [Serializable]
    public class SoundForm
    {
        public AudioClip soundFx;
        public virtual void PlayEffect()
		{
            Debug.Log("Audio is playing");
		}

    }
    #endregion
}