using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace WorldTime
{
    [RequireComponent(typeof(Light2D))]
    public class GameLight : MonoBehaviour
    {
        private Light2D light;

        [SerializeField]
        private TimeHandling timeHandling;

        [SerializeField]
        private Gradient gradient;

        private void Awake()
        {
            light = GetComponent<Light2D>();
            timeHandling.WorldTimeChanged += OnWorldTimeChanged;
        }

        private void OnDestroy()
        {
            timeHandling.WorldTimeChanged -= OnWorldTimeChanged;
        }

        private void OnWorldTimeChanged(object sender, TimeSpan newTime)
        {
            light.color = gradient.Evaluate(PercentOfDay(newTime));
        }

        private float PercentOfDay(TimeSpan timeSpan)
        {
            return (float) timeSpan.TotalMinutes % TimeHandling.MinuteInDay / TimeHandling.MinuteInDay;
        }
    }
}

