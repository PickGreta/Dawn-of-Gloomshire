using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManeger : MonoBehaviour
{
    bool isPlanted = false;
    SpriteRenderer plant;
    BoxCollider2D plantCollider;

    int plantStage = 0;
    int lastCheckedDay = 0;

    bool rightSeason = true;

    public PlantObject selectedPlant;

    [SerializeField]
    private WorldTime.TimeHandling timeHandling;

    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (!isPlanted)
        {
            return;
        }

        var isRightSeason = RightSeason();
        if (!isRightSeason)
        {
            return;
        }

        if (lastCheckedDay < timeHandling.currentDay)
        {
            GrowingPlant();

            lastCheckedDay = timeHandling.currentDay;
        }
        
    }

    private void OnMouseDown()
    {
        if(isPlanted)
        {
            if (plantStage == selectedPlant.plantStages.Length-1)
            {
                Harvest();
            }
        }
        else
        {
            Plant();
            //timeHandling.currentDay = lastCheckedDay;
        }
    }

    void Harvest()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }

    void Plant()
    {
        var isRightSeason = RightSeason();
        if (isRightSeason)
        {
            isPlanted = true;
            plantStage = 0;
            UpdatePlant();
            plant.gameObject.SetActive(true);
        }
    }

    void UpdatePlant()
    {
        plant.sprite = selectedPlant.plantStages[plantStage];
    }

    void GrowingPlant()
    {
        if (plantStage < selectedPlant.plantStages.Length-1)
        {
            plantStage++;
            UpdatePlant();
        }
    }
    

    bool RightSeason()
    {
        if (selectedPlant.seasonNeeded == timeHandling.currentSeason)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}