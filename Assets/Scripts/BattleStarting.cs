using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleStarting : MonoBehaviour
{
    public GameObject battleSceneObject;

    private void OnMouseDown()
    {
        battleSceneObject.SetActive(true);

        GameObject battleSystemObject = GameObject.Find("BattleSystem");

        BattleSystem battleScene = battleSystemObject.GetComponent<BattleSystem>();
        battleScene.MoveCameraToNewPosition();
        battleScene.SetupBattle(); 
    }

}
