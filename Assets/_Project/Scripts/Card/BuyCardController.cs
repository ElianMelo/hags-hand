using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuyCardController : MonoBehaviour
{
    public GameObject cardTemplate;
    public List<CardDataSO> cards = new();
    public GameObject listCardsGroup;
    public Button button;
    public Canvas canvas;

    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveAllListeners();
    }

    private void OnButtonClick()
    {
        CardDataSO selectedCard = cards[Random.Range(0, cards.Count)];
        GameObject instance = Instantiate(cardTemplate, listCardsGroup.transform);
        instance.transform.SetParent(listCardsGroup.transform);
        instance.GetComponent<DragDrop>().SetupCanvas(canvas);
        instance.GetComponent<CardObject>().CardDataHolderSO = selectedCard;
    }
}
