//Copyright (c) FuchsFarbe

using System.Collections;
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
    [CreateAssetMenu(menuName = "Spell", fileName = "New Spell")]
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
        public Element element; //This dictates its damage type
        public Behaviour behaviours; //This is the spells behaviours
        public AoEInfo aoeInfo;
        [Header("Forms")]
        [Tooltip("OnInvoke: Gathers information. Put forms here that pertain to information gathering, if any at all. E.g. AoE spells to set an area. This is also where main Visuals and sounds should be put, \n " +
            "OnStart: The bulk of the spell. If a spell needs to be channeled THEN cast, make sure most of the information is here. If a spell needs to be channeled TO be cast, put the bulk of the forms in OnSuccess \n " +
            "OnSuccess: If a channel succeeds in casting, all these forms will be performed. \n" +
            "OnEnd: This signifies the spell is done. This can have ending animations or effects, as well as secondary effects post-channel. \n" +
            "OnPassive: These forms can be invoked every .5s if isPassive is set to true. \n")]
        public AbilityEventData[] abilityEvents = new AbilityEventData[6]
        {
            new AbilityEventData(new FormTarget { }, new List<Form>()),
            new AbilityEventData(new FormTarget { }, new List<Form>()),
            new AbilityEventData(new FormTarget { }, new List<Form>()),
            new AbilityEventData(new FormTarget { }, new List<Form>()),
            new AbilityEventData(new FormTarget { }, new List<Form>()),
            new AbilityEventData(new FormTarget { }, new List<Form>())
        };
        public IEnumerator Execute(Ability aSpell, GameObject caster, GameObject target)
        {
            {
                Cast cast = new Cast(aSpell, caster, target);
                yield return cast.OnCastExecute();
            }
        }
    }
}


    
