/* ============================================
 *                    Attack
 * --------------------------------------------
 *      The attack script extends Spell, but
 *  it is not a spell. It is simply a way for 
 *  the casters to perform a light or heavy 
 *  attack.
 *  ===========================================
 */
namespace Dragon_Stones.Spell_System
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Scriptable Objects/Spell/Attack")]
    public class Attacks : Spell
    {
        [SerializeField] private GameObject weapon { get; set; }
        public override void Cast(GameObject caster)
        {
            //Get weapon type
            //Execute animation based on that
            //Add damage script, remove post-animation
        }
    }
}