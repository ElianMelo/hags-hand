using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardSpawnerDataSO", menuName = "ScriptableObjects/CardSpawnerDataSO", order = 1)]
public class CardSpawnerDataSO : ScriptableObject
{
    public List<CardDataSO> commomCards = new();
    public List<CardDataSO> uncommomCards = new();
    public List<CardDataSO> rareCards = new();
    public List<CardDataSO> epicCards = new();
    public List<CardDataSO> legendaryCards = new();
}