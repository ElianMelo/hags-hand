using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreCornerController : MonoBehaviour
{
    public GameObject cardTemplate;
    public List<CardDataSO> cards = new();
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
        CardDataSO selectedCard = cards[Random.Range(0, cards.Count)];
        GameObject instance = Instantiate(cardTemplate, listCardsGroup.transform);
        instance.transform.SetParent(listCardsGroup.transform);
        instance.GetComponent<DragDrop>().SetupCanvas(canvas);
        instance.GetComponent<CardObject>().CardDataHolderSO = selectedCard;
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
