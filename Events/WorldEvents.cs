//Copyright (c) FuchsFarbe

using System;
using System.Collections.Generic;
using UnityEngine;
using Dragon_Stones.Game_Managers.Time_System;

/* ============================================
*               World Events
* --------------------------------------------
*       World events dictates global events
*  ===========================================
*/

namespace Dragon_Stones.Events
{
    public class WorldEvents : MonoBehaviour
    {

        #region Variables

        #endregion
        //Event dictionaries of Event types
        private Dictionary<string, Action> eventDict;
        private Dictionary<string, Action<TickTimeArgs>> tickDict;

        //Singleston instance
        private static WorldEvents worldEventManager;

        #region singleton
        public static WorldEvents instance
        {
            get
            {
                if (!worldEventManager)
                {
                    worldEventManager = FindObjectOfType(typeof(WorldEvents)) as WorldEvents;

                    if (!worldEventManager)
                    {
                        Debug.Log("Missing 'WorldEvents.cs' from the current scene.");
                    }
                    else
                    {
                        worldEventManager.Initialize();
                    }
                }

                return worldEventManager;
            }
        }

        private void Initialize()
        {
            if (eventDict == null)
            {
                eventDict = new Dictionary<string, Action>();
            }
            if (tickDict == null)
			{
                tickDict = new Dictionary<string, Action<TickTimeArgs>>();
			}
        }

        #endregion

        #region No Param Events

        public static void StartListen(string eventName, Action listener)
		{
            Action thisEvent = null;
            //Attempt to find dictionary stuff
            //If event already in dictionary, add listener
            if (instance.eventDict.TryGetValue(eventName, out thisEvent))
			{
                thisEvent += listener;

                //Update Dictionary
                instance.eventDict[eventName] = thisEvent;
			}
            //If not in dictionary, add a new Unity Event to dictionary
            else
			{
                thisEvent += listener;
                instance.eventDict.Add(eventName, thisEvent);
			}
		}

        public static void StopListen(string eventName, Action listener)
		{
            //Avoid null exceptions if dictionary is somehow deleted
            if (worldEventManager == null)
            {
                return;
            }
            Action thisEvent = null;
            if (instance.eventDict.TryGetValue(eventName, out thisEvent))
			{
                thisEvent -= listener;

                //Update dictionary
                instance.eventDict[eventName] = thisEvent;
			}
		}

        public static void TriggerEvent(string eventName)
        {
            Action thisEvent = null;

            if (instance.eventDict.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.Invoke();
            }
        }

		#endregion

		#region Tick Time Event Manager

		public static void StartListen(string eventName, Action<TickTimeArgs> listener)
        {
            Action<TickTimeArgs> thisEvent = null;
            //Attempt to find dictionary stuff
            //If event already in dictionary, add listener
            if (instance.tickDict.TryGetValue(eventName, out thisEvent))
            {
                thisEvent += listener;

                //Update Dictionary
                instance.tickDict[eventName] = thisEvent;
            }
            //If not in dictionary, add a new Unity Event to dictionary
            else
            {
                thisEvent += listener;
                instance.tickDict.Add(eventName, thisEvent);
            }
        }

        public static void StopListen(string eventName, Action<TickTimeArgs> listener)
        {
            //Avoid null exceptions if dictionary is somehow deleted
            if (worldEventManager == null)
            {
                return;
            }
            Action<TickTimeArgs> thisEvent = null;
            if (instance.tickDict.TryGetValue(eventName, out thisEvent))
            {
                thisEvent -= listener;

                //Update dictionary
                instance.tickDict[eventName] = thisEvent;
            }
        }


        public static void TriggerEvent(string eventName, TickTimeArgs action)
        {
            Action<TickTimeArgs> thisEvent = null;

            if (instance.tickDict.TryGetValue(eventName, out thisEvent))
			{
                thisEvent.Invoke(action);
			}
        }

        #endregion

        #region Spell Event Region
        [Serializable]
        public class SpellEvents
        {
            public enum Event
            {
                none,
                OnSpellStart,
                OnIncant,
                OnIncantInterrupt,
                OnIncantFinish,
                OnHit
            }
        }
        #endregion
    }
}