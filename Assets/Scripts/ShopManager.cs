using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public PlantObject plant;
    
    public Player player;

    public InventoryManager inventoryManager;
    
    public ShopOpen shopOpen;

    public GameObject store;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI priceText;
    public Image icon;

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        player = FindObjectOfType<Player>();
        nameText.text = plant.plantName;
        priceText.text = "G" + plant.price;
        icon.sprite = plant.icon;
    }

    public void BuyPlant()
    {
        if (player.gold < plant.price)
        {
            return;
        }
        else
        {
            player.gold -= plant.price;
            inventoryManager.Add("Backpack", plant.seed);
        }
    }

    public void SellPlant()
    {
        var canRemoveItem = inventoryManager.CanRemoveItem("Toolbar", plant.crop);
        if (canRemoveItem)
        {
            inventoryManager.Remove("Toolbar", plant.crop);
            player.gold += plant.cropPrice;
        }
    }
}
