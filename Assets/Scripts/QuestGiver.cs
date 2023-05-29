using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public Player player;
    public GameObject questWindow;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI description;
    public TextMeshProUGUI goldText;
    public InventoryManager inventoryManager;

    public void Start()
    {
        questWindow.SetActive(false);
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        description.text = quest.description;
        goldText.text = quest.goldReward.ToString() + " G";
    }

    public void OnMouseDown()
    {
        OpenQuestWindow();
    }
 
    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        player.quest = quest;
        
    }

    public void CloseWindow()
    {
        questWindow.SetActive(false);
    }

    public void CompletedGatheringQuest()
    {
        if (inventoryManager.GetInventoryByName("Toolbar").IsThereEnoughItem(quest.goal.item, quest.goal.requiredAmount))
        {
            player.gold += quest.goldReward;

            for(int i = 0; i < quest.goal.requiredAmount; i++)
            {   
                inventoryManager.Remove("Toolbar", quest.goal.item);
                questWindow.SetActive(false);
                
            }
        }   
    }

    public void CompletedKillingQuest()
    {
        if (player.enemiesKilled == quest.goal.requiredAmount)
        {
            player.gold += quest.goldReward;
            player.enemiesKilled = 0;
        }
    }

}
