using UnityEngine;

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
namespace Dragon_Stones.Character.State
{
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
        [SerializeField] private PlayerGender gender;
        [SerializeField] private PlayerRace race;
        [Header("Birth and Age")]
        [SerializeField] private int[] fullBirthday = new int[3];
        [SerializeField] private int birthDay, birthMonth, birthYear;
        [SerializeField] private int age { get; set; }
		public PlayerGender Gender { get => gender; }
		public PlayerRace Race { get => race; }

		//Event Handlers
        public override void RegenStats()
        {

        }

    }
}