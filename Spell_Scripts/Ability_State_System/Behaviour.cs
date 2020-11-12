//Copyright (c) FuchsFarbe

using System;

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
        BuffOrDebuff = 1 << 6,
    } 
}