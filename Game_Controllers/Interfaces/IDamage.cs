//Copyright (c) FuchsFarbe

using UnityEngine;
using Dragon_Stones.Character.Stats;

/* ============================================
*                   Name
* --------------------------------------------
*           - Summary of script - 
*  ===========================================
*/
namespace Dragon_Stones
{
    public interface IDamage
    {
        void ApplyDamage(Character_Stats target, int damage);
    }
}