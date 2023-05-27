using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{
    public Item item;
    public Item material1;
    public Item material2;
    public Player player;
    public InventoryManager inventoryManager;
    public CraftingOpen craftingOpen;
    public GameObject cauldronUI;

    public TextMeshProUGUI nameText;
    public Image icon;

    public Image craftingMaterialIcon;
    public int requiredAmount1;
    public Image craftingMaterial2Icon;
    public int requiredAmount2;

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        player = FindObjectOfType<Player>();
        nameText.text = item.data.itemName;
        icon.sprite = item.data.icon;

        craftingMaterialIcon.sprite = material1.data.icon;
        craftingMaterial2Icon.sprite = material2.data.icon;
    }

    public void MakePotion()
    {
        if (inventoryManager.GetInventoryByName("Toolbar").IsThereEnoughItem(material1, requiredAmount1) && inventoryManager.GetInventoryByName("Toolbar").IsThereEnoughItem(material2, requiredAmount2))
        {
            for(int i = 0; i < requiredAmount1; i++)
            {   
                inventoryManager.Remove("Toolbar", material1);
            }

            for(int i = 0; i < requiredAmount2; i++)
            {   
                inventoryManager.Remove("Toolbar", material2);
            }

            inventoryManager.Add("Backpack", item);
        }
        else
        {
            return;
        }
    }
}
