using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardBoardSO", menuName = "ScriptableObjects/CardBoardSO", order = 1)]
public class CardBoardSO : ScriptableObject
{
    public List<BoardRarity> boardsRarity = new ();
    public Sprite borderOverlay;
    public GameObject towerSpawnPrefab;
    public GameObject magicSpawnPrefab;
}

[Serializable]
public class BoardRarity
{
    public Sprite borderSprite;
    public Rarity rarity;
}
