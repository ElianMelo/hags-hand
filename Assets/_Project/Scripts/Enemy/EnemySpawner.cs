using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemyTarget;
    public float spawnRate;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        GameObject instance = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        instance.GetComponent<EnemyFollowTarget>().SetupTargets(enemyTarget, transform);
        yield return new WaitForSeconds(spawnRate);
        StartCoroutine(SpawnEnemies());
    }
}
