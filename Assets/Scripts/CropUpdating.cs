using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Seed;

namespace Seed
{
    public class Farm_tile : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Dictionary<string, Seed> myDictionary = new Dictionary<string, Seed>();
            myDictionary.Add("strawberry", new Seed("Stawberry", 150, 2));
            myDictionary.Add("watermelon", new Seed("Watermelon", 200, 4));
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}