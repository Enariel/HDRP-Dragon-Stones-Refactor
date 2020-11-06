using System;
using System.Collections.Generic;
using UnityEngine;
using Dragon_Stones.Character.Stats;
using System.Collections;
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
        StopMovement = 1 << 3,
        Directional = 1 << 4,
        AutoCast = 1 << 5,
        ImmediateCast = 1 << 6,
        DontStopMove = 1 << 7,
        Passive = 1 << 8,
        NoTarget = 1 << 9, //Doesn't need a target to be cast
        PointTarget = 1 << 10, //Needs a position target
        SomeTarget = 1 << 11, //Needs a specific gameobject target
    } 
    //How to target
    [Flags]
    public enum TargetType
	{
        Self = 1 << 0,
        Enemy = 1 << 1,
        Ground = 1 << 2
    }
    //What to target
    [Flags]
    public enum Target
	{
        Caster = 1 << 0,
        Target = 1 << 1,
        Point = 1 << 2
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
        public bool canTargetSelf { get { return ((targetType & TargetType.Self) != 0); } }
        public bool canTargetEnemy { get { return ((targetType & TargetType.Enemy) != 0); } }
        public bool canTargetGround { get { return ((targetType & TargetType.Ground) != 0); } }
        public bool AoE { get { return ((behaviours & Behaviour.AreaOfEffect) != 0); } }
        public bool AutoCast { get { return ((behaviours & Behaviour.AutoCast) != 0); } }
        public bool HasCastTime { get { return ((behaviours & Behaviour.CastTime) != 0); } }
        public bool IsChanneled { get { return ((behaviours & Behaviour.Channeled) != 0); } }
        public bool IsDirectional { get { return ((behaviours & Behaviour.Directional) != 0); } }
        public bool DontStopMove { get { return ((behaviours & Behaviour.DontStopMove) != 0); } }
        public bool IsImmediate { get { return ((behaviours & Behaviour.ImmediateCast) != 0); } }
        public bool NoTarget { get { return ((behaviours & Behaviour.NoTarget) != 0); } }
        public bool IsPassive { get { return ((behaviours & Behaviour.Passive) != 0); } }
        public bool IsPointTarget { get { return ((behaviours & Behaviour.PointTarget) != 0); } }
        public bool SomeTarget { get { return ((behaviours & Behaviour.SomeTarget) != 0); } }
        public bool StopMove { get { return ((behaviours & Behaviour.StopMovement) != 0); } }


        //Simple spell information
        [Header("Spell Details")]
        public string title;
        public string id;
        public string desc;
        public Sprite icon;
        [Tooltip("In Ticks")]
        public int duration; //In ticks
        public int maxRange; //In unity units
        public int coolDown; //In ticks
        public float modifierPercent; //This is a modifier most spells will take in, this should be changed per rank.
        [Range(15, 1)] private int rank = 15; //Every spell rank should start at 15.
        [Header("Forms")]
        public Element element; //This dictates its damage type
        public Behaviour behaviours; //This is the spells behaviours
        public TargetType targetType;
        public Target target;
        public List<SpellEventData> spellEvents;
    }

    #region Spell Forms
    //*********************************************
    /* ============================================
     *      Spell Form Data and Spell Event Data
     * --------------------------------------------
     *      -Spell Form Data
     *      Spell form data takes in a a Form
     *  scriptable object. This dictates various
     *  behavious for the different events on a 
     *  spell. 
     *      -Spell Event Data
     *      Spell event data takes in a list of
     *  spell form data, this is a list of actions
     *  that are executed on each spell event. 
     *  ===========================================
     */
    //*********************************************
    /* --------------------------------------------
     *          Example of Forms actions
     * --------------------------------------------
     *  - Effect Forms
     *      - Play Sound
     *      - Visual
     *  - Attach effect
     *      - Adds an effect based on element
     *      - Good for DoTs and Buffs/Debuffs
     *  - Damage
     *      - The official damage calculation
     *  - Heal
     *      - Heals target for specified amount
     *  - Movement
     *      - Knockback
     *      - Knockup
     *      - Move
     *      - Blink/Teleports
     *      - Stun
     *      - Various other movement impedes
     */
    //*********************************************

	#endregion

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
        public SpellEvent spellEvent;
        [SerializeField] public List<Form> forms;
	}
    public enum SpellEvent
	{
        None,
        OnCastStart,
        OnSpellStart,
        OnSpellChannel,
        OnSpellChannelSucceed,
        OnSpellEnd
	}
	#endregion
}