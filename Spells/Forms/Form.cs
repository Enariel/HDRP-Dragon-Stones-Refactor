using System;
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
    [System.Serializable]
    public abstract class Form : MonoBehaviour
    {
        public abstract void DoForm(InvokeSpell invoke, GameObject target);
    }
}