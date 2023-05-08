using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GoldDisplay : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI goldText;

    public void Start()
    {
        goldText.text = player.gold + "G";
    }

    public void Update()
    {
        goldText.text = player.gold + "G";
    }
}
