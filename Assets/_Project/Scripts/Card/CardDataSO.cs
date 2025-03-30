using UnityEngine;

[CreateAssetMenu(fileName = "CardDataSO", menuName = "ScriptableObjects/CardDataSO", order = 1)]
public class CardDataSO : ScriptableObject
{
    public string creatureName;
    public Sprite cardSprite;
    public CardType cardType;
    public Rarity rarity;
    public SpecialEffect specialEffect;
    public float specialEffectMultiplier;
    public float specialEffectDuration;
    public float range;
    public float attackSpeed;
    public float damage;
    public float durability;
    public Tower towerPrefab;
}

public enum CardType
{
    Melee,
    Ranged,
    Magic
}

public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}

public enum SpecialEffect
{
    None,
    Fear
}
