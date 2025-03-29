using System;

[Serializable]
public class Card
{
    public int cardRarity = 1;
    public CardType cardType;
}

public enum CardType
{
    Melee,
    Ranged,
    Magic
}
