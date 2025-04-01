using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemySpawnerDataSO enemySpawnerDataSO;
    public Transform enemyTarget;

    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        if (currentWave >= enemySpawnerDataSO.waves.Count) yield break;
        int waveAmount = enemySpawnerDataSO.waves[currentWave].waveDatas.Count;
        int waveCount;

        for (int i = 0; i < waveAmount; i++)
        {
            waveCount = i;
            EnemyDataSO currentEnemyData = enemySpawnerDataSO.waves[currentWave].waveDatas[waveCount].enemyData;

            int waveEnemyAmount = enemySpawnerDataSO.waves[currentWave].waveDatas[waveCount].amount;

            for (int j = 0; j < waveEnemyAmount; j++)
            {
                GameObject instance = Instantiate(currentEnemyData.enemyPrefab.gameObject, transform.position, Quaternion.identity);
                EnemyFollowTarget enemyFollowTarget = instance.GetComponent<EnemyFollowTarget>();
                enemyFollowTarget.SetupTargets(enemyTarget, transform);
                enemyFollowTarget.SetupSpeed(currentEnemyData.speed);
                Enemy enemy = instance.GetComponent<Enemy>();
                enemy.SetupEnemyDataSO(currentEnemyData);
                yield return new WaitForSeconds(enemySpawnerDataSO.waves[currentWave].spawnRate);
            }
        }

        yield return new WaitForSeconds(enemySpawnerDataSO.delayBetweenWaves);

        currentWave++;

        StartCoroutine(SpawnEnemies());
    }
}
