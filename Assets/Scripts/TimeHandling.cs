using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTime
{
    public class TimeHandling : MonoBehaviour
    {
        public bool endOfDay = false;
        public event EventHandler<TimeSpan> WorldTimeChanged;

        [SerializeField]
        private float dayLenght;

        private TimeSpan currentTime;
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
                    currentDay++;
                }
                
                currentTime = TimeSpan.FromHours(6);
                endOfDay = false;
            }

            currentTime += TimeSpan.FromMinutes(1);
            WorldTimeChanged?.Invoke(this, currentTime);

            if (currentTime.TotalMinutes >= MinuteInDay)
            {
                currentTime = TimeSpan.Zero;
                currentDay++;
            }

            Debug.Log(currentTime);
            Debug.Log(currentDay);

            yield return new WaitForSeconds(minuteLength);
            StartCoroutine(AddMinute());
        }

    }

}