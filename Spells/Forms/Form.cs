using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ============================================
 *                    Form
 * --------------------------------------------
 *      This script functions as the archetype
 *  or base class for spell behaviours. Each
 *  spell will have many forms, which will, in
 *  turn, make up the whole functionality of a
 *  spell.
 *  ===========================================
 */
namespace Dragon_Stones.Spell_System.Forms
{
    [CreateAssetMenu(menuName ="Form")]
    public abstract class Form : ScriptableObject
    {
        public abstract IEnumerator DoForm(GameObject caster, List<GameObject> targets);
    }
}