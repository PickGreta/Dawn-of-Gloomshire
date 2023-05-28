using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Cinemachine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public Player player;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public TextMeshProUGUI dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    public GameObject battleScene;

    public GameObject endBattleButton;

    public CinemachineVirtualCamera vcam;
    
    public GameObject enemyGO;

    void Start()
    {
        GameObject endBattleButton = GameObject.Find("EndBattleButton");
        endBattleButton.SetActive(false);

        GameObject battleScene = GameObject.Find("BattleScene");
        battleScene.SetActive(false);
    }

    public void SetupBattle(GameObject enemyGO)
    {
        state = BattleState.START;

        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        this.enemyGO = enemyGO;
        enemyGO.transform.position = enemyBattleStation.transform.position;
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = enemyUnit.unitName + " is attacking";

        playerHUD.SetHUD(playerUnit);
        Debug.Log("playerHUD");
        enemyHUD.SetHUD(enemyUnit);
        Debug.Log("EnemyHUD"); 

        Debug.Log("waiting1");

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "The attack is successful!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            Destroy(enemyGO);
            player.EnemiesKilled();
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";
            EndBattleScene();
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated";
            EndBattleScene();
        }

        GameObject attackButton = GameObject.Find("AttackButton");
        GameObject healButton = GameObject.Find("HealButton");
        GameObject itemsButton = GameObject.Find("ItemsButton");

        attackButton.SetActive(false);
        healButton.SetActive(false);
        itemsButton.SetActive(false);

        endBattleButton.SetActive(true);
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(10);

        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "You healed!";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerHeal());
    }

    public void EndBattleScene()
    {
        battleScene.SetActive(false);

        vcam.Follow = player.transform;
    }

    public void MoveCameraToNewPosition()
    {
        Debug.Log(vcam.transform);
        vcam.Follow = null;
        vcam.transform.position = new Vector3(-33, 0, -10);
    }

}
