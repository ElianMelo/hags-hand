using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreCornerController : MonoBehaviour
{
    public GameObject cardTemplate;
    public CardSpawnerDataSO cardSpawnerDataSO;
    public GameObject listCardsGroup;
    public Button buyCardButton;
    public Button buyExpButton;
    public Canvas canvas;
    public TMP_Text coinText;

    private const int CARDPRIZE = 5;
    private const int EXPPRIZE = 5;
    private const int EXPVALUE = 5;
    private int coin = 0;

    void Start()
    {
        buyCardButton.onClick.AddListener(OnBuyCardButtonClick);
        buyExpButton.onClick.AddListener(OnBuyExpButtonClick);
    }

    private void OnDestroy()
    {
        buyCardButton.onClick.RemoveAllListeners();
        buyExpButton.onClick.RemoveAllListeners();
    }

    public void AddCoin(int amount)
    {
        coin += amount;
        SetCoinText();
    }

    public bool RemoveCoin(int amount)
    {
        if(amount > coin)
        {
            return false;
        } else
        {
            coin -= amount;
            SetCoinText();
            return true;
        }
    }

    private void SetCoinText()
    {
        coinText.text = "COIN: " + coin;
    }

    private void TryToBuyCard()
    {
        var isBought = RemoveCoin(CARDPRIZE);
        if (isBought)
        {
            BuyCard();
        }
    }

    private void BuyCard()
    {
        Rarity rarity = InterfaceSystemManager.Instance.GetCardRarity();

        CardDataSO selectedCard = GetCardDataSOByRarity(rarity);

        GameObject instance = Instantiate(cardTemplate, listCardsGroup.transform);
        instance.transform.SetParent(listCardsGroup.transform);
        instance.GetComponent<DragDrop>().SetupCanvas(canvas);
        instance.GetComponent<CardObject>().CardDataHolderSO = selectedCard;
    }

    private CardDataSO GetCardDataSOByRarity(Rarity rarity)
    {
        switch (rarity)
        {
            case Rarity.Common:
                return cardSpawnerDataSO.commomCards[Random.Range(0, cardSpawnerDataSO.commomCards.Count)];
            case Rarity.Uncommon:
                return cardSpawnerDataSO.uncommomCards[Random.Range(0, cardSpawnerDataSO.uncommomCards.Count)];
            case Rarity.Rare:
                return cardSpawnerDataSO.rareCards[Random.Range(0, cardSpawnerDataSO.rareCards.Count)];
            case Rarity.Epic:
                return cardSpawnerDataSO.epicCards[Random.Range(0, cardSpawnerDataSO.epicCards.Count)];
            case Rarity.Legendary:
                return cardSpawnerDataSO.legendaryCards[Random.Range(0, cardSpawnerDataSO.legendaryCards.Count)];
            default:
                return cardSpawnerDataSO.commomCards[Random.Range(0, cardSpawnerDataSO.commomCards.Count)];
        }
    }

    private void TryToBuyExp()
    {
        var isBought = RemoveCoin(EXPPRIZE);
        if (isBought)
        {
            BuyExp();
        }
    }

    private void BuyExp()
    {
        InterfaceSystemManager.Instance.AddExperience(EXPVALUE);
    }

    private void OnBuyCardButtonClick()
    {
        TryToBuyCard();
    }

    private void OnBuyExpButtonClick()
    {
        TryToBuyExp();
    }
}
