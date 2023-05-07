using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopClose : MonoBehaviour
{
    public GameObject store;

    public void Start()
    {
        store.SetActive(false);
    }
    
    public void CloseShopUI()
    {
        store.SetActive(false);
    }
}
