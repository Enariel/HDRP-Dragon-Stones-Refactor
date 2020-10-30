/* ============================================
 *                  Spell Magic
 * --------------------------------------------
 *      This will be the archetype for all mage
 *  related active casting abilities. Every 
 *  active magic spell comes directly from 
 *  creating this Scriptable Object Asset.
 *  ===========================================
 */
namespace Dragon_Stones.Spell_System
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Scriptable Objects/Spell/Active Spell/Magic", fileName = "New Magic Skill" )]
    public class Spell_Magic : Spell_Active
    {
        [Header("Magic Variables")] 
        [SerializeField] private float castTime = .5f;
        [SerializeField] private float additionalCooldown;
        [SerializeField] private float duration;
        [SerializeField] private GameObject circle, mainEffect;

        public override void Cast(GameObject caster)
        {
            foreach (Form form in Forms)
            {
                form.DoForm(caster);
            }
        }
    }
}