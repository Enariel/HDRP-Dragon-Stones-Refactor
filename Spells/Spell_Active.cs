/* ============================================
 *                  Spell Active
 * --------------------------------------------
 *      Active spells require an input in order 
 *  to perform the spell. In each base spells
 *  scriptable object, the cast function will
 *  execute all the forms.
 *  ===========================================
 */
namespace Dragon_Stones.Spell_System
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Spell_Active : Spell
    {
        [SerializeField] private float cooldown = .5f, cost;

        public override void Cast(GameObject caster)
        {

        }
    }
}