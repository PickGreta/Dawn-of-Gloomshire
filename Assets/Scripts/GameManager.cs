using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ItemManager itemManager;
    public UIManager uiManager;
    public Player player;
    public GameObject battleScene;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

        itemManager = GetComponent<ItemManager>();
        uiManager = GetComponent<UIManager>();

        player = FindObjectOfType<Player>();
    }

    public void SetBattleSceneActive()
    {
        battleScene.SetActive(true);
    }
}