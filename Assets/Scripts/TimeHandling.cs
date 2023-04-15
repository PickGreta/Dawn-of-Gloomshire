using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTime
{
    public enum Season { Spring, Summer, Fall, Winter}

    public class TimeHandling : MonoBehaviour
    {
        public bool endOfDay = false;
        public event EventHandler<TimeSpan> WorldTimeChanged;

        [SerializeField]
        private float dayLenght;

        [SerializeField]
        public Season currentSeason;

        private TimeSpan currentTime = TimeSpan.FromHours(6);
        public int currentDay;

        public const int MinuteInDay = 1440;
        private float minuteLength => dayLenght / MinuteInDay;

        private void Start()
        {
            StartCoroutine(AddMinute());
        }

        private IEnumerator AddMinute()
        {
            if (endOfDay)
            {
                if (currentTime > TimeSpan.FromHours(6))
                {
                    AddDay();
                }
                
                currentTime = TimeSpan.FromHours(6);
                endOfDay = false;
            }

            currentTime += TimeSpan.FromMinutes(1);
            WorldTimeChanged?.Invoke(this, currentTime);

            if (currentTime.TotalMinutes >= MinuteInDay)
            {
                currentTime = TimeSpan.Zero;
                AddDay();
            }

            Debug.Log(currentTime);
            Debug.Log(currentDay);

            yield return new WaitForSeconds(minuteLength);
            StartCoroutine(AddMinute());
        }

        private void AddDay()
        {
            currentDay++;
            CheckSeason();

        }

        private void CheckSeason()
        {
            int dayOfYear = currentDay % 112; // 1 season 4 weeks
            if (dayOfYear < 28) currentSeason = Season.Spring;
            else if (dayOfYear < 56) currentSeason = Season.Summer;
            else if (dayOfYear < 84) currentSeason = Season.Fall;
            else currentSeason = Season.Winter;
        }

    }

}