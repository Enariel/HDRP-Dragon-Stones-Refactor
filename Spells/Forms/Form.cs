//Copyright (c) FuchsFarbe
using Dragon_Stones.Character.Stats;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*********************************************
/* ============================================
 *      Spell Form Data and Spell Event Data
 * --------------------------------------------
 *      -Spell Form Data
 *      Spell form data takes in a a Form
 *  scriptable object. This dictates various
 *  behavious for the different events on a 
 *  spell. 
 *      -Spell Event Data
 *      Spell event data takes in a list of
 *  spell form data, this is a list of actions
 *  that are executed on each spell event. 
 *  ===========================================
 */
//*********************************************
/* --------------------------------------------
 *          Example of Forms actions
 * --------------------------------------------
 *  - Effect Forms
 *      - Play Sound
 *      - Visual
 *  - Attach effect
 *      - Adds an effect based on element
 *      - Good for DoTs and Buffs/Debuffs
 *  - Damage
 *      - The official damage calculation
 *  - Heal
 *      - Heals target for specified amount
 *  - Movement
 *      - Knockback
 *      - Knockup
 *      - Move
 *      - Blink/Teleports
 *      - Stun
 *      - Various other movement impedes
 */
//*********************************************

namespace Dragon_Stones.Spell_System.Forms
{
    [CreateAssetMenu(menuName ="Form")]
    public abstract class Form : ScriptableObject
    {
        public Target target;
        public bool multiTarget = true;
        public abstract IEnumerator DoForm(Cast_Spell casterSpell, GameObject target, Vector3 targetPos);
        public virtual IEnumerator Reset()
		{
            yield return null;
		}
    }
}