//Copyright (c) FuchsFarbe

using UnityEngine;

/* ============================================
*                   ICast
* --------------------------------------------
*       Interface for casting a Spell and
*   secondary spell.
*  ===========================================
*/
namespace Dragon_Stones.Spell_System
{
    public interface ICast
    {
        void Cast(Spell spell, GameObject caster);
    }
}