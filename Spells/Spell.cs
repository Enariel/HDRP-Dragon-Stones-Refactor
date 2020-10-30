/* ============================================
 *                    Spell
 * --------------------------------------------
 *      Spell is the base scriptable object 
 *  from which all other spells will derive 
 *  from. 
 *      Spells can be passive or active. 
 *      Passive spells utilize the tick event
 *      Active spells require input from either
 *  the code or the player.
 *      Active spells also come with forms or
 *  behaviours that dictate their actions.
 *  ===========================================
 */
namespace Dragon_Stones.Spell_System
{
    using System;
    using UnityEngine;

    public class Spell : ScriptableObject
    {
        [Flags]
        public enum Element
        {
            none,
            water,
            earth,
            fire,
            air,
            dragon
        }

        [Header("Basic Skill Information")]
        [SerializeField] private string title;
        [TextArea]
        [SerializeField] private string desc;
        [SerializeField] private string id;
        [SerializeField] private Sprite icon;
        [Header("Forms")]
        [SerializeField] private Form[] forms;
        [Header("Element")]
        [SerializeField] private Element element;



        //Getters and Setters
        public string Title { get => title; set => title = value; }
        public string Desc { get => desc; set => desc = value; }
        public string Id { get => id; set => id = value; }
        public Sprite Icon { get => icon; set => icon = value; }
        public Form[] Forms { get => forms; set => forms = value; }
        public Element Element1 { get => element; set => element = value; }

        public virtual void Cast(GameObject caster)
        {
            Debug.Log("No behaviours added");
        }
    }
}