using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public  Dictionary<string, InventoryUI> inventoryUIByName = new Dictionary<string, InventoryUI>();

    public GameObject inventoryPanel;

    public List<InventoryUI> inventoryUIs;
    public static SlotUI draggedSlot;
    public static Image draggedIcon;
    public static bool dragSingle;

    private void Awake()
    {
        Initialize();
    }

    private void Start()
    {
        inventoryPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.B))
        {
            ToggleInventoryUI();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            dragSingle = true;
        }
        else
        {
            dragSingle = false;
        }
    }

    public void ToggleInventoryUI()
    {
        if (inventoryPanel != null)
        {
            if (!inventoryPanel.activeSelf)
            {
                inventoryPanel.SetActive(true);
                RefreshInventoryUI("Backpack");
            }
            else
            {
                inventoryPanel.SetActive(false);
            }
        }
        
    }

    public void RefreshInventoryUI(string inventoryName)
    {
        if (inventoryUIByName.ContainsKey(inventoryName))
        {
            inventoryUIByName[inventoryName].Refresh();
        }
    }

    public void RefreshAll()
    {
        foreach (KeyValuePair<string, InventoryUI> keyValuePair in inventoryUIByName)
        {
            keyValuePair.Value.Refresh();
        }
    }

    public InventoryUI GetInventoryUI(string inventoryName)
    {
        if (inventoryUIByName.ContainsKey(inventoryName))
        {
            return inventoryUIByName[inventoryName];
        }

        return null;
    }

    void Initialize()
    {
        foreach (InventoryUI ui in inventoryUIs)
        {
            if (!inventoryUIByName.ContainsKey(ui.inventoryName))
            {
                inventoryUIByName.Add(ui.inventoryName, ui);
            }
        }
    }

}
