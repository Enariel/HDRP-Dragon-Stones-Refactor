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
namespace Dragon_Stones.Game_Managers.Time
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class Time_Controller : MonoBehaviour
    {

        //References
        [Header("Light References")]
        public Light sun, moon;
        public Celestial_Parameters sunPresets, moonPresets;

        //Variables
        public bool pauseCycle;
        [SerializeField, Range(0, 24)] private float timeOfDay; //Clamp values to 24 hour clock
        [SerializeField] private float MINSPERDAY = 1f;
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


        private void Awake()
        {
            //Get the sun and moon with tags. They should be in every scene. 
            sun = GameObject.FindGameObjectWithTag("Sun").GetComponent<Light>();
            moon = GameObject.FindGameObjectWithTag("Moon").GetComponent<Light>();
        }

        private void Update()
        {
            if (sunPresets == null || moonPresets == null)
            {
                return;
            }
            if (Application.isPlaying)
            {
                if (!pauseCycle)
                {
                    //Time math
                    timeOfDay += Time.deltaTime / (MINSPERDAY * 60) * 24;
                    timeOfDay %= 24;
                    UpdateLighting(timeOfDay / 24);
                    UpdateClock();
                    TrackCycle(timeOfDay / 24);
                }
            }
        }

        //Keeps track of the time
        private void UpdateClock()
        {
            double minute = timeOfDay * 60;
            minute = Math.Round(minute, 0);
            min = (int)minute % 60;
            hour = (int)minute / 60;
            //turn over day
            //Has to be less than 24, but also not make a huge difference for the last minute on the clock in order for it to
            //Properly keep track of the day.
            if (timeOfDay >= 23.99f)
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

            UpdateCalender(day, week, month, year);
        }
        private void TrackCycle(float timePercent)
        {
            //Bool for nighttime and for displaying cycle message
            if (timePercent > .75f || timePercent < .25f)
            {
                isNight = true;
            }
            else if (timePercent < .75f || timePercent > .25f)
            {
                isNight = false;
            }
            //Night event handler
        }

        private void TrackMoons(int day)
        {
            //moon is full
            if (day >= 13 && day <= 15)
            {
                moonModifier = 3f;
            }
            else if (day == 28 || day <= 2)
            {
                moonModifier = 1.5f;
            }
            else
            {
                moonModifier = 1;
            }
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

            birthday = new List<int>();

            int monthDay = calDay - (month * 28);
            int monthWeek = calWeek - (month * 4);

            birthday.Add(monthDay);
            birthday.Add(calMonth);
            birthday.Add(calYear);

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
            TrackMoons(monthDay);
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
                sun.color = sunPresets.directionalColour.Evaluate(timePercent);
                RenderSettings.ambientLight = sunPresets.ambientColour.Evaluate(timePercent);
                RenderSettings.fogColor = sunPresets.fogColour.Evaluate(timePercent);
            }
            else if (moon != null)
            {
                moon.color = moonPresets.directionalColour.Evaluate(timePercent);
                RenderSettings.ambientLight = moonPresets.ambientColour.Evaluate(timePercent);
                RenderSettings.fogColor = moonPresets.fogColour.Evaluate(timePercent);
            }
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
    }
}
