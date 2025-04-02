using UnityEngine;

public class CardSystemManager : MonoBehaviour
{
    public static CardSystemManager Instance;

    public CardDataSO CurrentCardDataSO { get; set; }
    public bool IsDragging { get; set; }

    public CardBoardSO CardBoardSO;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject TowerPrefabEvoke()
    {
        return CardBoardSO.towerSpawnPrefab;
    }

    public GameObject MagicPrefabEvoke()
    {
        return CardBoardSO.magicSpawnPrefab;
    }

    public Sprite RarityToSprite(Rarity rarity)
    {
        foreach (var boardRarity in CardBoardSO.boardsRarity)
        {
            if(boardRarity.rarity == rarity)
            {
                return boardRarity.borderSprite;
            }
        }
        return null;
    }
}
