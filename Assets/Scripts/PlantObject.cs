using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldTime;

[CreateAssetMenu(fileName ="New Plant", menuName ="Plant")]
public class PlantObject : ScriptableObject
{
    public string plantName;
    public Sprite[] plantStages;
    public float timeBtwStages;
    public Season seasonNeeded;
    public int price;
    public Sprite icon;
}
