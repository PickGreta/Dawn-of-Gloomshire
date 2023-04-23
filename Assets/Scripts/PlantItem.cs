using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{
    public PlantObject plant;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI priceText;
    public Image icon;

    void Start()
    {
        nameText.text = plant.plantName;
        priceText.text = "G" + plant.price;
        icon.sprite = plant.icon;
    }

    public void BuyPlant()
    {
        Debug.Log("Bought " + plant.plantName);
    }
}
