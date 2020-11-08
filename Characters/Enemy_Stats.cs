using UnityEngine;

/* ============================================
 *              Enemy Stats
 * --------------------------------------------
 *      Extends Character Stats, has added 
 *  information regarding JUST the enemy 
 *  game object this script belongs to.
 *  ===========================================
 */
namespace Dragon_Stones.Character.Stats.Enemy
{
    public class Enemy_Stats : Character_Stats
    {
        //Variables
        [SerializeField] private Enemy enemy;
        //Event Handlers
        private void Start()
        {

        }

        public override void RegenStats()
        {

        }
    }
}