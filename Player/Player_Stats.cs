/* ============================================
 *              Player Stats
 * --------------------------------------------
 *      Extends Character Stats, has added 
 *  information regarding JUST the player 
 *  character. This serves only as a stat 
 *  controller. Other scripts will reference 
 *  this to change behaviours.
 *  ===========================================
 */
namespace Dragon_Stones.Character.Stats.Player
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Dragon_Stones.Events;
    using Dragon_Stones.Game_Managers.Time;
    public enum PlayerGender
    {
        Nonbinary,
        Male,
        Female
    }

    public enum PlayerRace
    {
        Human,
        Elf,
        Fomor
    }
    public class Player_Stats : Character_Stats
    {
        //Variables
        [Header("Lives")]
        [SerializeField] private int lives = 3;

        [Header("Race and Gender")]
        [SerializeField] PlayerGender gender;
        [SerializeField] PlayerRace race;

        [Header("Birth and Age")]
        [SerializeField] private int[] fullBirthday = new int[3];
        [SerializeField] private int birthDay, birthMonth, birthYear;
        [SerializeField] private int age { get; set; }

        //Event Handlers
        private void Start()
        {
            Tick_System.OnTick += OnTick;
        }

        private void OnTick(object sender, Tick_System.OnTickEventArgs e)
        {
            RegenStats();
        }

        public override void RegenStats()
        {

        }
    }
}