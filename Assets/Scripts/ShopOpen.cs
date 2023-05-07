using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOpen : MonoBehaviour
{
    public GameObject store;
    

    private void OnMouseDown()
        {
            store.SetActive(true);
        }
}
