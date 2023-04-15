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
        if (isPlanted)
        {
            if (lastCheckedDay < timeHandling.currentDay)
            {
                if (plantStage < selectedPlant.plantStages.Length-1)
                {
                    plantStage++;
                    UpdatePlant();
                }
                
                lastCheckedDay = timeHandling.currentDay;
            }
            
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
            timeHandling.currentDay = lastCheckedDay;
        }
    }

    void Harvest()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }

    void Plant()
    {
        isPlanted = true;
        plantStage = 0;
        UpdatePlant();
        plant.gameObject.SetActive(true);
    }

    void UpdatePlant()
    {
        plant.sprite = selectedPlant.plantStages[plantStage];
    }

    
}