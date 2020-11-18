using System;
using System.Collections.Generic;
using UnityEngine;
using Dragon_Stones.Events;

/* ============================================
 *              Time Controller
 * --------------------------------------------
 *      This script dictates the day and night
 *  cycle of the world of Getig. Here the 
 *  celestial bodies of sun and moon are 
 *  controlled using the Unity's Time.deltaTime
 *  
 *      This script also has references to what
 *  day of the week, month, and year it 
 *  currently is.
 *  ===========================================
 */
namespace Dragon_Stones.Game_Managers.Time_System
{
    public class Time_Controller : MonoBehaviour
    {
		#region Variables

		//References
		[Header("Light References")]
        Light sun;
        Light moon;
        public Celestial_Parameters sunPresets;
        public Celestial_Parameters moonPresets;

        //Variables
        [SerializeField] private bool pauseCycle;
        [SerializeField][Range(0, 24 * 60)] private int timeOfDay; //Clamp values to 24 hour clock
        [SerializeField] private float timeSpeed = 1;

        [Header("Game Time")]
        [SerializeField] private int min;
        [SerializeField] private int hour;
        [SerializeField] private int day;
        [SerializeField] private int week;
        [SerializeField] private int month;
        [SerializeField] private int year = 1;
        private string dayName, monthName;

        [Header("Birthday")]
        [SerializeField] private int birthDay;
        [SerializeField] private int birthMonth;
        [SerializeField] private int birthYear;
        [SerializeField] private List<int> birthday = new List<int>();
        [Header("Night Modifiers")]
        [SerializeField] private float moonModifier;
        [SerializeField] private bool isNight;

        //Event Listeners
        private Action<TickTimeArgs> tickListener;

		#endregion

		#region Unity Methods

		private void Awake()
        {
            //Get the sun and moon with tags. They should be in every scene. 
            sun = GameObject.FindGameObjectWithTag("Sun").GetComponent<Light>();
            moon = GameObject.FindGameObjectWithTag("Moon").GetComponent<Light>();

            tickListener = new Action<TickTimeArgs>(OnTick);
        }

		//Makes sure theres a sun, if not it makes one. 
		private void OnValidate()
        {
            if (sun != null && moon != null)
                return;
            if (RenderSettings.sun != null)
            {
                sun = RenderSettings.sun;
            }
            else
            {
                Light[] lights = GameObject.FindObjectsOfType<Light>();
                foreach (Light light in lights)
                {
                    if (light.type == LightType.Directional && light.CompareTag("Sun"))
                    {
                        sun = light;
                        return;
                    }
                    if (light.type == LightType.Directional && light.CompareTag("Moon"))
                    {
                        moon = light;
                        return;
                    }
                }
            }
        }


        //Enable and disable listeners
		private void OnEnable()
		{
            WorldEvents.StartListen("Tick", tickListener);
		}

		private void OnDisable()
		{
            WorldEvents.StopListen("Tick", tickListener);
        }

        #endregion

        #region Event Methods

        //On tick add time to the clock
        private void OnTick(TickTimeArgs t)
        {
            if (sunPresets == null || moonPresets == null)
            {
                return;
            }

            if (!pauseCycle)
            {
                timeOfDay = Convert.ToInt32(t.tick + (6 * 60));

                //Update important game functions each tick
                UpdateClock(timeOfDay);
                UpdateLighting(timeOfDay / (24f * 60f));
            }
        }

		#endregion

		#region Time Keeping Methods
		//Keeps track of the time
		private void UpdateClock(int time)
        {
            int min = time;
            hour = min / 60;
            //turn over day
            //Has to be less than 24, but also not make a huge difference for the last minute on the clock in order for it to
            //Properly keep track of the day.
            if (hour == 24)
            {
                day += 1;
                timeOfDay = 0;
            }

            //Track the week and month
            week = day / 7;
            month = week / 4;

            //Turn over the year
            if (month > 3)
            {
                year += 1;
                month = 0;
                day = 0;
            }

            TrackCycle(hour);
            TrackMoons(day);
            UpdateCalender(day, week, month, year);
        }
        private void TrackCycle(int hour)
        {
            //Bool for nighttime and for displaying cycle message
            if (hour > 18 || hour < 6)
            {
                isNight = true;
                WorldEvents.TriggerEvent("OnNightTime");
            }
            else
			{
                isNight = false;
                WorldEvents.TriggerEvent("OnDayTime");
			}
            //Night event handler
        }

        private void TrackMoons(int day)
        {
            //Moon is full for three days in the middle of the month
            if (day > 13 && day < 15)
            {
                moonModifier = 3f;
            }
            //New Moon
            else if (day == 28 || day < 2)
            {
                moonModifier = 1.5f;
            }
            //Half moon
            else
            {
                moonModifier = 1;
            }
            //Night bonus
            if (isNight == true)
            {
                moonModifier *= 2;
            }

        }

        //To properly update the calender UI with the correct display of date and time. 
        private void UpdateCalender(int calDay, int calWeek, int calMonth, int calYear)
        {
            //Make sure there are non-zero numbers on the calender.
            calDay += 1;
            calWeek += 1;
            calMonth += 1;
            calYear += 1;

            switch (day % 7)
            {
                case 0:
                    dayName = "Asha Vahista";
                    break;
                case 1:
                    dayName = "Vohu Manah";
                    break;
                case 2:
                    dayName = "Kshathra Vairya";
                    break;
                case 3:
                    dayName = "Spenta Armaiti";
                    break;
                case 4:
                    dayName = "Haurvatat";
                    break;
                case 5:
                    dayName = "Ameretat";
                    break;
                case 6:
                    dayName = "Spenta Mainyu";
                    break;
            }
            switch (month % 3)
            {
                case 0:
                    monthName = "Imbolk";
                    break;
                case 1:
                    monthName = "Östara";
                    break;
                case 2:
                    monthName = "Samhain";
                    break;
                case 3:
                    monthName = "Yüle";
                    break;
            }
        }

        //Modifies the sun
        private void UpdateLighting(float timePercent)
        {

            if (sun != null && moon != null)
            {
                sun.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, -90f, 0f));
                moon.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) + 90f, -90f, 0f));
            }

            if (sun != null)
            {
                sun.color = sunPresets.directionalFilterColour.Evaluate(timePercent);
                RenderSettings.ambientSkyColor = sunPresets.ambientColour.Evaluate(timePercent);
            }
            else if (moon != null)
            {
                moon.color = moonPresets.directionalFilterColour.Evaluate(timePercent);
            }
        }

		#endregion
	}
}
