using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnerDataSO", menuName = "ScriptableObjects/EnemySpawnerDataSO", order = 1)]
public class EnemySpawnerDataSO : ScriptableObject
{
    public List<Wave> waves = new();
    public float delayBetweenWaves;
}

[Serializable]
public class Wave
{
    public List<WaveData> waveDatas = new();
    public float spawnRate;
}

[Serializable]
public class WaveData
{
    public EnemyDataSO enemyData;
    public int amount;
}