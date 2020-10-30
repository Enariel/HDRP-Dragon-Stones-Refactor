/* ============================================
 *              Character Stats
 * --------------------------------------------
 *      This is an archetype struct-type class
 *  meant for creating base stats for any 
 *  entity in the game. Each character has the
 *  potential to utilize the passive Regen 
 *  function.
 *      Character stats appear on game objects
 *  themselves so they are easier to find and 
 *  reference.
 *  ===========================================
 */
namespace Dragon_Stones.Character.Stats
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Dragon_Stones.Events;
    public class Character_Stats : MonoBehaviour
    {
        [Header("Cost Stats")]
        [SerializeField] private float startMaxHP;
        [SerializeField] private float startMaxPhyr;
        //Magic skills use magic, guns use STR and DEX, Archery uses DEX, Melee uses STR
        //If a staff, wand, or gloves equipped, melee uses MAG. 
        [Header("Damage Stats")]
        [SerializeField] private float startStr;
        [SerializeField] private float startMag;
        [SerializeField] private float startDex;

        public float StartMaxHP { get => startMaxHP; set => startMaxHP = value; }
        public float StartMaxPhyr { get => startMaxPhyr; set => startMaxPhyr = value; }
        public float StartStr { get => startStr; set => startStr = value; }
        public float StartMag { get => startMag; set => startMag = value; }
        public float StartDex { get => startDex; set => startDex = value; }

        public virtual void RegenStats() { }

    }
}