/* ============================================
 *                  Tick System
 * --------------------------------------------
 *      The Tick System is dedicated to keeping
 *  time on spells, events, regens, and any 
 *  otherwise incrementing systems for the game.
 *  ===========================================
 */
namespace Dragon_Stones.Events
{
    using System;
    using UnityEngine;
    public class Tick_System : MonoBehaviour
    {
        //Tick event
        public class OnTickEventArgs : EventArgs
        {
            public int tick;
        }

        public static event EventHandler<OnTickEventArgs> OnTick;

        //Max time elapse for tick
        private const float MAX_TICK_TIME = 1f;
        //Tick controller variables
        [SerializeField] private int tick;
        [SerializeField] private float tickTimer;

        private void Awake()
        {
            tick = 0;
        }

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
                if (OnTick != null) OnTick(this, new OnTickEventArgs { tick = tick });
            }
        }
    }
}