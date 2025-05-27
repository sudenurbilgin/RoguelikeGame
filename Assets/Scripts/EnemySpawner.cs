using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject slimePrefab;

    [SerializeField]
    private float baseInterval = 3.5f;
    private float minInterval = 0.75f;

    [SerializeField]
    private List<Vector3> spawnPoints = new List<Vector3>()
    {
        new Vector3(0.4f, 7f, 0f),
        new Vector3(-6.96f, -0.17f, 0f),
        new Vector3(7.57f, -0.17f, 0f),
        new Vector3(0.99f, -7.86f, 0f)
    };

    private PlayerExp playerExp;

    private IEnumerator spawnEnemy()
    {
        while (true)
        {
            float interval = Mathf.Max(minInterval, baseInterval - (playerExp.level - 1) * 0.2f);
            yield return new WaitForSeconds(interval);

            if (slimePrefab == null)
            {
                Debug.LogError("Slime prefab is NULL! Cannot spawn.");
                yield break;
            }

            Vector3 spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Count)];
            Instantiate(slimePrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Enemy spawned at: " + spawnPosition);
        }
    }

    void Start()
    {
        playerExp = FindObjectOfType<PlayerExp>();
        StartCoroutine(spawnEnemy());
    }
}
