using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemyPrefabs; // 0: zayýf, 1: orta, 2: güçlü düþman

    [SerializeField]
    private float baseInterval = 3.5f;
    private float minInterval = 0.75f;

    [SerializeField]
    private List<Vector3> spawnPoints = new List<Vector3>()
    {
        new Vector3(1.19f, 4.99f, 0f),
        new Vector3(-3.48f, -0.46f, 0f),
        new Vector3(1.19f, -6.04f, 0f),
        new Vector3(0.99f, -7.86f, 0f)
    };

    private PlayerExp playerExp;

    private IEnumerator spawnEnemy()
    {
        while (true)
        {
            float interval = Mathf.Max(minInterval, baseInterval - (playerExp.level - 1) * 0.2f);
            yield return new WaitForSeconds(interval);

            GameObject enemyToSpawn = GetEnemyBasedOnLevel(playerExp.level);
            if (enemyToSpawn == null)
            {
                Debug.LogError("Enemy prefab is NULL! Cannot spawn.");
                yield break;
            }

            Vector3 spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Count)];
            Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
            Debug.Log("Enemy spawned at: " + spawnPosition);
        }
    }

    private GameObject GetEnemyBasedOnLevel(int level)
    {
        if (level <= 3)
        {
            int index = Mathf.Clamp(level - 1, 0, enemyPrefabs.Count - 1);
            return enemyPrefabs[index];
        }
        else
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Count);
            return enemyPrefabs[randomIndex];
        }
    }


    void Start()
    {
        playerExp = FindObjectOfType<PlayerExp>();
        StartCoroutine(spawnEnemy());
    }
}
