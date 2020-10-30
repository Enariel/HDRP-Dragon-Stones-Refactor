/* ============================================
 *                    Form
 * --------------------------------------------
 *      This script functions as the archetype
 *  or base class for spell behaviours. Each
 *  spell can have one or many forms, which 
 *  will in turn, make up actions. 
 *  ===========================================
 */
namespace Dragon_Stones.Spell_System
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Scriptable Objects/Form")]
    public abstract class Form : ScriptableObject
    {
        public abstract void DoForm(GameObject caster);
    }
}