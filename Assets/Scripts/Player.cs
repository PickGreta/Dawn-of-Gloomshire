using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    public Inventory toolbar;
    
    private void Awake()
    {
        inventory = new Inventory(16);
        toolbar = new Inventory(4);
    }

    public void DropItem(Collectable item)
    {
        Vector3 spawnLocation = transform.position;

        Vector3 spawnOffset = Random.insideUnitCircle * .25f;

        Collectable droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);

    }

    public void DropItem(Collectable item, int numToDrop)
    {
        for (int i = 0; i < numToDrop; i++)
        {
            DropItem(item);
        }

    }
}
