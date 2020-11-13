//Copyright (c) FuchsFarbe

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dragon_Stones.Spell_System.Forms;

/* ============================================
 *                  Ability
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
    [CreateAssetMenu(menuName = "Ability", fileName = "New Ability")]
    public class Ability : ScriptableObject
    {
        //Simple spell information
        [Header("Ability Details")]
        public string title;
        public string id;
        public string desc;
        public Sprite icon;
        [Tooltip("In Seconds")]
        public float castTime; //In seconds
        public float duration; //In seconds
        public float coolDown; //In seconds
        public int maxRange;//In unity units
        public float modifierPercent; //This is a modifier most spells will take in, this should be changed per rank.
        [Range(15, 1)] private int rank = 15; //Every spell rank should start at 15.
        [Header("Form Information")]
        public Element element = Element.Physical; //This dictates its damage type
        public Behaviour behaviours = Behaviour.Default; //This is the spells behaviours
        public AoEInfo aoeInfo;
        [Header("Forms")]
        [Tooltip("")]
        public AbilityEventData[] abilityEvents = new AbilityEventData[4]
        {
            new AbilityEventData(SpellEvent.OnStart, new List<Form>()),
            new AbilityEventData(SpellEvent.OnSuccess, new List<Form>()),
            new AbilityEventData(SpellEvent.OnProjectileHit, new List<Form>()),
            new AbilityEventData(SpellEvent.OnEnd, new List<Form>()),
        };
		public IEnumerator Execute(Ability aSpell, GameObject caster)
        {
            {
                Cast cast = new Cast(aSpell, caster);
                yield return cast.OnCastExecute();
            }
        }
	}
}


    
