using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seed
{
    public enum GrowingStage
    {
        seed,
        plant,
        growingPlant,
        harvestable
    }

    public class Seed
    {
        protected string name;
        protected int buyPrice;
        protected int timeToGrow;

        public Seed(string name, int buyPrice, int timeToGrow)
        {
            this.name = name;
            this.buyPrice = buyPrice;
            this.timeToGrow = timeToGrow;
        }

    }

    public class PlantedSeed : Seed
    {
        GrowingStage growingStage;
        bool isWatered;
        bool hasBug;

        public PlantedSeed(string name, int buyPrice, int timeToGrow, GrowingStage growingStage, bool isWatered, bool hasBug) : base(name, buyPrice, timeToGrow)
        {
            this.growingStage = growingStage;
            this.isWatered = isWatered;
            this.hasBug = hasBug;
        }
    }
}
