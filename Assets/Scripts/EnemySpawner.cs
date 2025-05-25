using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject slimePrefab;

    [SerializeField]
    private float slimeInterval = 3.5f;

    [SerializeField]
    private List<Vector3> spawnPoints = new List<Vector3>()
    {
        new Vector3(0.4f, 7f, 0f),
        new Vector3(-6.96f, -0.17f, 0f),
        new Vector3(7.57f, -0.17f, 0f),
        new Vector3(0.99f, -7.86f, 0f)
    };

    void Start()
    {
        StartCoroutine(spawnEnemy(slimeInterval, slimePrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        Vector3 spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Count)];
        Instantiate(enemy, spawnPosition, Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }

}
