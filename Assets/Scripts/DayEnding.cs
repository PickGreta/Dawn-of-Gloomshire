using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTime
{

    public class DayEnding : MonoBehaviour
    {
        [SerializeField]
        private TimeHandling timeHandling;
        private void OnMouseDown()
        {
            timeHandling.endOfDay = true;
        }

    }
}
