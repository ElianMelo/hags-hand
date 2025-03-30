using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardObject : MonoBehaviour
{
    private CardDataSO _cardDataSO;
    public CardDataSO CardDataHolderSO {
        get => _cardDataSO;
        set
        {
            _cardDataSO = value;
            SetupCardData();
        }
    }

    public Image backgroundImage;
    public Image frontImage;
    public TMP_Text cardName;

    public void SetupCardData()
    {
        cardName.text = CardDataHolderSO.creatureName;
        backgroundImage.sprite = CardSystemManager.Instance.RarityToSprite(CardDataHolderSO.rarity);
        frontImage.sprite = CardDataHolderSO.cardSprite;
    }
}
