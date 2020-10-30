/* ============================================
 *                  Melee Spell
 * --------------------------------------------
 *      Extends Spell scriptable object. Each
 *  melee spell/ability needs a weapon, if a 
 *  weapon cannot be found, the weapon is the
 *  caster's hands.
 *  ===========================================
 */
namespace Dragon_Stones.Spell_System
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Scriptable Objects/Spell/Active Spell/Melee Spell", fileName = "New Melee Skill")]
    public class Melee_Spell : Spell_Active
    {
        [SerializeField] private float cooldown = .5f, cost;
        public override void Cast(GameObject caster)
        {

        }
    }
}