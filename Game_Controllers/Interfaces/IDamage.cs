//Copyright (c) FuchsFarbe

using UnityEngine;
using Dragon_Stones.Character.Stats;
using Dragon_Stones.Spell_System;

/* ============================================
*                   IDamage
* --------------------------------------------
*       Damage interface script for deciding
*   what happens when an object is damaged.
*  ===========================================
*/
namespace Dragon_Stones.Game_Managers
{
    public interface IDamage
    {
        void OnDamage(Damage_Calculation dmgCalc);
    }
}