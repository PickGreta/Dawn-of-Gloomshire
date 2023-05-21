using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleStarting : MonoBehaviour
{
    public GameObject battleSceneObject;

    private void OnMouseDown()
    {
        var gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        gameManager.SetBattleSceneActive();
        
        GameObject battleSystemObject = GameObject.Find("BattleSystem");

        BattleSystem battleSystem = battleSystemObject.GetComponent<BattleSystem>();
        battleSystem.MoveCameraToNewPosition();
        battleSystem.SetupBattle(gameObject);
        
    }

}
