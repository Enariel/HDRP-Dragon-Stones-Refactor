using System;
using System.Collections.Generic;
using UnityEngine;
using Dragon_Stones.Spell_System.Forms;

/* ============================================
 *                    Spell
 * --------------------------------------------
 *      Spell is the base scriptable object 
 *  from which all other spells will come from.
 *      Spells are data-driven, meaning that
 *  since each spell comes from this class, all
 *  their data will come from the modifications
 *  of this class in Unity-Editor. 
 *      Each spell has an EffectForm which is a
 *  behaviour of the spell in totality. This
 *  dictates the overarching theme of the spell
 *  and limits what it can and cannot do.
 *      Each spell has a set of events it must
 *  complete. Each event has a list of actions.
 *  These aren't standard events, rather just a
 *  list of IEnums that control the spell for
 *  its duration.
 *      Spells do not instantiate game objects,
 *  but rather the effects class does to give
 *  the spell or ability an effect.
 *  ===========================================
 */

namespace Dragon_Stones.Spell_System
{
    #region Enums
    //These are flags that DO NOT change for the duration of the spell, instead they dictate how the rest of the spell behaves and what conditions need to be met to cast
    [Flags]
    public enum Behaviour
    {
        AreaOfEffect = 1 << 0,
        Channeled = 1 << 1,
        CastTime = 1 << 2,
        TurnTowardsEnemy = 1 << 3,
        Directional = 1 << 4,
        DontStopMove = 1 << 5,
    } 
    //What to target
    public enum Target
	{
        Caster = 1 << 0, //for heals or buffs
        Target = 1 << 1, //for attacks and debuffs
        Direction = 1 << 2, //for projectiles and melee
        Point = 1 << 3, //For projectiles and AoE
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
    #endregion

    [CreateAssetMenu(menuName = "Spell", fileName = "New Spell")]
    public class Spell : ScriptableObject
    {
        //Simple spell information
        [Header("Spell Details")]
        public string title;
        public string id;
        public string desc;
        public Sprite icon;
        [Tooltip("In Seconds")]
        public int duration; //In ticks
        public int maxRange; //In unity units
        public int coolDown; //In tick
        public float modifierPercent; //This is a modifier most spells will take in, this should be changed per rank.
        [Range(15, 1)] private int rank = 15; //Every spell rank should start at 15.
        [Header("Forms")]
        public Element element; //This dictates its damage type
        public Behaviour behaviours; //This is the spells behaviours
        public bool needsEnemyTarget = false;
        public bool needsCasterTarget = false;
        public bool isPassive = false;
        public AoEInfo aoeInfo;
        [Tooltip("OnInvoke: Gathers information. Put forms here that pertain to information gathering, if any at all. E.g. AoE spells to set an area. This is also where main Visuals and sounds should be put, \n " +
            "OnStart: The bulk of the spell. If a spell needs to be channeled THEN cast, make sure most of the information is here. If a spell needs to be channeled TO be cast, put the bulk of the forms in OnSuccess \n " +
            "OnSuccess: If a channel succeeds in casting, all these forms will be performed. \n" +
            "OnEnd: This signifies the spell is done. This can have ending animations or effects, as well as secondary effects post-channel. \n" +
            "OnPassive: These forms can be invoked every .5s if isPassive is set to true. \n")]
        public SpellEventData[] spellStages = new SpellEventData[6] { 
            new SpellEventData(SpellEvent.OnInvoke, new List<Form>()), 
            new SpellEventData(SpellEvent.OnStart, new List<Form>()),
            new SpellEventData(SpellEvent.OnSuccess, new List<Form>()),
            new SpellEventData(SpellEvent.OnEnd, new List<Form>()),
            new SpellEventData(SpellEvent.OnPassive, new List<Form>()),
            new SpellEventData(SpellEvent.OnProjectileHit, new List<Form>())};
	}                                                                  

	#region AoE Information
    [Serializable]
    public struct AoEInfo
	{
        public CenterType center;
        public Shape shape;

        //For a circle shape
        [Header("Radius for circle shape")]
        public int radius;

        //For a rectangle shape
        [Header("Rectangle area shape")]
        public int width;
        public int height;
	}
    public enum CenterType
	{
        Caster,
        Target,
        Point,
        Projectile,
	}
    public enum Shape
	{
        Circle,
        Rectangle,
        Arc
	}
	#endregion

	#region Spell Events
    [Serializable]
    public class SpellEventData
	{
		[SerializeField] private SpellEvent spellEvent;
		[SerializeField] private List<Form> forms;

		public SpellEventData(SpellEvent spellEvent, List<Form> forms)
		{
			this.SpellEvent = spellEvent;
			this.Forms = forms;
		}

		public List<Form> Forms { get => forms; set => forms = value; }
		public SpellEvent SpellEvent { get => spellEvent; set => spellEvent = value; }
	}
    public enum SpellEvent
	{
        None,
        OnInvoke, //The start of the cast
        OnStart, //The forms right AFTEr a successful cast
        OnSuccess, //If success on channel
        OnEnd, //End the spell with a reset on the forms
        OnPassive, //Passive is always invoked.
        OnProjectileHit
	}
	#endregion
}