using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManeger : MonoBehaviour
{
    bool isPlanted = false;
    SpriteRenderer plant;
    SpriteRenderer wateredTile;
    BoxCollider2D plantCollider;

    int plantStage = 0;
    int lastCheckedDay = 0;

    bool rightSeason = true;
    bool isWatered = false;

    public PlantObject selectedPlant;
    public ToolbarUI toolbarUI;

    [SerializeField]
    private WorldTime.TimeHandling timeHandling;

    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        wateredTile = transform.GetChild(1).GetComponent<SpriteRenderer>();
        wateredTile.gameObject.SetActive(false);
        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        toolbarUI = FindObjectOfType<ToolbarUI>();
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

        var hasWateringCan = HasWateringCan();
        if (hasWateringCan)
        {
            WaterPlant();
        }
    }

    void Harvest()
    {
        DropItem(selectedPlant.crop);
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }

    void Plant()
    {
        if (toolbarUI.selectedSlot.inventory.SelectSlot(toolbarUI.selectedSlot.slotID).itemName == selectedPlant.seed.data.itemName)
        {
            var isRightSeason = RightSeason();
            if (isRightSeason)
            {
                isPlanted = true;
                plantStage = 0;
                UpdatePlant();
                plant.gameObject.SetActive(true);
                toolbarUI.selectedSlot.inventory.SelectSlot(toolbarUI.selectedSlot.slotID).RemoveItem();
            }
        }
    }

    void UpdatePlant()
    {
        plant.sprite = selectedPlant.plantStages[plantStage];
    }

    void GrowingPlant()
    {

        if (isWatered)
        {
            if (plantStage < selectedPlant.plantStages.Length-1)
            {
                plantStage++;
                UpdatePlant();
                isWatered = false;
                wateredTile.gameObject.SetActive(false);
            }
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

    bool HasWateringCan()
    {
        if (toolbarUI.selectedSlot.inventory.SelectSlot(toolbarUI.selectedSlot.slotID).itemName == "Watering Can")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void WaterPlant()
    {
        wateredTile.gameObject.SetActive(true);
        isWatered = true;
    }

    public void DropItem(Item item)
    {
        Vector3 spawnLocation = transform.position;

        Vector3 spawnOffset = Random.insideUnitCircle * .25f;

        Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);
    }

}