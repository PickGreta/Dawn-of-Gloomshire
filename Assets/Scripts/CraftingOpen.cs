using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingOpen : MonoBehaviour
{
    public GameObject craftingSystem;
    private void OnMouseDown()
        {
            craftingSystem.SetActive(true);
        }
}
