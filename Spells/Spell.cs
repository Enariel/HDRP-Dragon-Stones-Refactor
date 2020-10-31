using System;
using System.Collections.Generic;
using UnityEngine;

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

    [CreateAssetMenu(menuName = "Spell", fileName = "Spell")]
    public class Spell : ScriptableObject
    {
        #region Enums
        [Flags]
        public enum BehaviourForm
        {
            Passive = 1 << 0, //Doesn't cast but still does stuff
            No_Target = 1 << 1, //No target needed
            Must_Target = 1 << 2, //A thing must be targetted
            Point_Target = 1 << 3, //No target needed, but aims towards mouse or char direction
            AreaOfEffect = 1 << 4, //Area of Effect skill
            Channelled = 1 << 5, //Does this have an incantation or charge time?
            Instant = 1 << 6, //The ability is cast instantly
            MoveRemain = 1 << 7 //Does this skill cancel movement input? Checking this allows move while casting.
        }

        [Flags]
        public enum TargetForm
        {
            Self = 1 << 0, //A self target skill
            Enemy = 1 << 1, // An enemy is targetted
            Ground = 1 << 2, //The ground is targetted
            Ally = 1 << 3 //An ally is targetted
        }

        [Flags] //What kind of target style?
        public enum TargetStyle
        {
            Caster,
            Target,
            Point
        }

        //Elemental damage types
        public enum Element
        {
            None,
            Water,
            Earth,
            Fire,
            Air,
            Dragon
        }
        #endregion

        #region Booleans
        public bool CanTargetSelf
        {
            get
            {
                return ((targetForms & TargetForm.Self) != 0);
            }
        }

        public bool CanTargetEnemy
        {
            get
            {
                return ((targetForms & TargetForm.Enemy) != 0);
            }
        }

        public bool CanTargetGround
        {
            get
            {
                return ((targetForms & TargetForm.Ground) != 0);
            }
        }

        public bool CanTargetAlly
        {
            get
            {
                return ((targetForms & TargetForm.Ally) != 0);
            }
        }
        #endregion

        #region Scriptable Object Variables
        [Header("Spell Details")]
        [SerializeField] private string title;
        [SerializeField] private string desc;
        [SerializeField] private string id;
        [SerializeField] private float cost;
        [SerializeField] private float duration;
        [SerializeField] private GameObject[] spellObj;
        [SerializeField] private Sprite icon;
        [Range(1, 15)]public int rank = 15;

        [Header("Forms")]
        [SerializeField] private BehaviourForm bForms;
        [SerializeField] private TargetForm targetForms;
        [SerializeField] private TargetStyle targets;
        [SerializeField] private Element element;

        [Header("Events")]
        [SerializeField] private List<SpellEvents> events = new List<SpellEvents>();
        #endregion
    }

    #region AoE Region
    //Area of Effect struct
    [Serializable]
    public struct AoEData
    {
        public enum CenterPoint
        {
            Caster,
            Target,
            Point,
            Projectile,
        }
        public enum ShapeType
        {
            Circle,
            Rect,
            Cone
        }

        public CenterPoint center;
        public ShapeType shape;

        // circle shape
        public int radius;

        // rect shape
        public int width;
        public int distance;

        public int maxTargets;
    }
    #endregion

    #region Spell Event Region
    [Serializable]
    public class SpellEvents
    {
        public enum Event
        {
            none,
            OnSpellStart,
            OnIncant,
            OnIncantInterrupt,
            OnIncantFinish,
            OnHit
        }

        [SerializeField] private Event eventType;
        [SerializeField] private List<Spell_Form> spellForms = new List<Spell_Form>();
    }
    #endregion

    #region Spell Form Data
    [Serializable]
    public class SpellFormData
    {
        public enum SpellForm
        {

        }
    }
    #endregion
}