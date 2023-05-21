using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public List<GameObject> enemyObjects = new List<GameObject>();
    public Vector3 spawnCenter = new Vector3(-10, -3, 0);
    public float spawnRadius = 10f;

    public void SpawnEnemies()
    {
        foreach (var enemy in enemyPrefabs)
        {
            float spawnAngle = Random.Range(0, 2 * Mathf.PI);
            
            float spawnDistance = Random.Range(0, spawnRadius);

            Vector3 spawnPosition = new Vector3(
                spawnDistance * Mathf.Cos(spawnAngle),
                spawnDistance * Mathf.Sin(spawnAngle),
                0
            );

            spawnPosition += spawnCenter;

            var spawnedEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
            enemyObjects.Add(spawnedEnemy);
           
        }
    }

    public void DestroySpawnedEnemies()
    {
        foreach (var enemy in enemyObjects)
        {
            Destroy(enemy);
        }
    }

}
