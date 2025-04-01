using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataSO", menuName = "ScriptableObjects/EnemyDataSO", order = 1)]
public class EnemyDataSO : ScriptableObject
{
    public string enemyName;
    public SpecialEffect specialEffectResistance;
    public float speed;
    public float health;
    public int coinReward;
    public int experience;
    public float damage;
    public Enemy enemyPrefab;
}