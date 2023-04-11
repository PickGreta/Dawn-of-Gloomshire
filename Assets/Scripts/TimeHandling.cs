using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTime
{
    public class TimeHandling : MonoBehaviour
    {
        public event EventHandler<TimeSpan> WorldTimeChanged;

        [SerializeField]
        private float dayLenght;

        private TimeSpan currentTime;

        public const int MinuteInDay = 1440;
        private float minuteLength => dayLenght / MinuteInDay;

        private void Start()
        {
            StartCoroutine(AddMinute());
        }

        private IEnumerator AddMinute()
        {
            currentTime += TimeSpan.FromMinutes(1);
            WorldTimeChanged?.Invoke(this, currentTime);
            yield return new WaitForSeconds(minuteLength);
            StartCoroutine(AddMinute());
        }

    }

}
