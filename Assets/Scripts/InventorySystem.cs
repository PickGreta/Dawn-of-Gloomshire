using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
   {
        public string name;
        public Sprite icon;
        public int quantity;
   }

public class InventorySystem : MonoBehaviour
{
    public List<InventoryItem> items;

    void AddItem(string name, Sprite icon, int quantity)
    {
        InventoryItem newItem = new InventoryItem();
        newItem.name = name;
        newItem.icon = icon;
        newItem.quantity = quantity;
        items.Add(newItem);
    }

    void RemoveItem(int index)
    {
        items.RemoveAt(index);
    }
}
