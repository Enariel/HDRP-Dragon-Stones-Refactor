using System;
using UnityEngine;
using Dragon_Stones.Events;
/* ============================================
 *                  Tick System
 * --------------------------------------------
 *      The Tick System is dedicated to keeping
 *  time on spells, events, regens, and any 
 *  otherwise incrementing systems for the game.
 *  ===========================================
 */
namespace Dragon_Stones.Game_Managers.Time_System
{
	#region TickTimeArgs Struct
    //This class is here to serve as a reference for the tick data

	public struct TickTimeArgs
    {
        public int tick;

		public TickTimeArgs(int t)
		{
			this.tick = t;
		}
	}

	#endregion

	public class Tick_System : MonoBehaviour
    {
        private Action<TickTimeArgs> OnTick;

        //Max time elapse for tick
        private const float MAX_TICK_TIME = 1f; //This dictates the games speed.
        //Tick controller variables
        [SerializeField] private int tick = 0;
        [SerializeField] private float tickTimer;

        private void Update()
        {
			tickTimer += Time.deltaTime;

            //If ticktimer reaches max tick time
            if (tickTimer >= MAX_TICK_TIME)
            {
                //Subtract the time to = 0
                tickTimer -= MAX_TICK_TIME;
                //Add a tick
                tick++;

                //Trigger the event and set its parameter to ticktime
                WorldEvents.TriggerEvent("Tick", new TickTimeArgs(tick));
            }
        }
    }
}