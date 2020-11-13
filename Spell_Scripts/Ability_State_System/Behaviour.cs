//Copyright (c) FuchsFarbe

using System;

/* ============================================
 *          Behaviour Enumerations
 * ============================================
 */

namespace Dragon_Stones.Spell_System
{
	//These are flags that DO NOT change for the duration of the spell, instead they dictate how the rest of the spell behaves and what conditions need to be met to cast
	[Flags]
    public enum Behaviour
    {
        Default = Behaviour.TurnTowardsEnemy | Behaviour.CastTime | Behaviour.StopMove,
        AreaOfEffect = 1 << 0,
        //Cast time MUST come before channel
        CastTime = 1 << 1,
        Channeled = 1 << 2,
        TurnTowardsEnemy = 1 << 3,
        Directional = 1 << 4,
        StopMove = 1 << 5,
        BuffOrDebuff = 1 << 6,
    } 
}