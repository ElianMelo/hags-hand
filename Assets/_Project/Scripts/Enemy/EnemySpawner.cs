using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemySpawnerDataSO enemySpawnerDataSO;
    public EnemyDataSO eliteEnemy;
    public float firstPercentage;
    public float secondPercentage;
    public float eliteTime;
    public int firstPercentageAmount;
    public int secondPercentageAmount;
    public Transform enemyTarget;

    private int currentWave = 0;

    private bool firstTimeFirstPercentage = true;
    private bool firstTimeSecondPercentage = true;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnEliteEnemies());
    }

    private IEnumerator SpawnEliteEnemies()
    {
        if (InterfaceSystemManager.Instance.GetCurrentWavePercentage() >= secondPercentage)
        {
            if (firstTimeSecondPercentage)
            {
                firstTimeSecondPercentage = false;
                SoundSystemManager.Instance.Alert();
            }
            for (int i = 0; i < secondPercentageAmount; i++)
            {
                SpawnEnemy(eliteEnemy);
            }
        }
        else if (InterfaceSystemManager.Instance.GetCurrentWavePercentage() >= firstPercentage)
        {
            if(firstTimeFirstPercentage)
            {
                firstTimeFirstPercentage = false;
                SoundSystemManager.Instance.Alert();
            }
            for (int i = 0; i < firstPercentageAmount; i++)
            {
                SpawnEnemy(eliteEnemy);
            }
        }
        yield return new WaitForSeconds(eliteTime);
        StartCoroutine(SpawnEliteEnemies());
    }

    private void SpawnEnemy(EnemyDataSO currentEnemyData)
    {
        GameObject instance = Instantiate(currentEnemyData.enemyPrefab.gameObject, transform.position, Quaternion.identity);
        EnemyFollowTarget enemyFollowTarget = instance.GetComponent<EnemyFollowTarget>();
        enemyFollowTarget.SetupTargets(enemyTarget, transform);
        enemyFollowTarget.SetupSpeed(currentEnemyData.speed);
        Enemy enemy = instance.GetComponent<Enemy>();
        enemy.SetupEnemyDataSO(currentEnemyData);
    }

    private IEnumerator SpawnEnemies()
    {
        if (currentWave >= enemySpawnerDataSO.waves.Count)
        {
            LevelSystemManager.Instance.GoToWin();
            yield break;
        }
        if(currentWave == 0)
        {
            SoundSystemManager.Instance.WaveStart();
        }
        int waveAmount = enemySpawnerDataSO.waves[currentWave].waveDatas.Count;
        int waveCount;

        for (int i = 0; i < waveAmount; i++)
        {
            waveCount = i;
            EnemyDataSO currentEnemyData = enemySpawnerDataSO.waves[currentWave].waveDatas[waveCount].enemyData;

            int waveEnemyAmount = enemySpawnerDataSO.waves[currentWave].waveDatas[waveCount].amount;

            for (int j = 0; j < waveEnemyAmount; j++)
            {
                SpawnEnemy(currentEnemyData);
                yield return new WaitForSeconds(enemySpawnerDataSO.waves[currentWave].spawnRate);
            }
        }

        yield return new WaitForSeconds(enemySpawnerDataSO.delayBetweenWaves);
        
        currentWave++;
        SoundSystemManager.Instance.WaveStart();

        if (currentWave < enemySpawnerDataSO.waves.Count)
        {
            InterfaceSystemManager.Instance.AddWaveCount();
        }

        StartCoroutine(SpawnEnemies());
    }
}
