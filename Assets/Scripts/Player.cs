using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    
    private void Awake()
    {
        inventory = new Inventory(16);
    }

    public void DropItem(Collectable item)
    {
        Vector3 spawnLocation = transform.position;

        Vector3 spawnOffset = Random.insideUnitCircle * .25f;

        Collectable droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);

    }
}
