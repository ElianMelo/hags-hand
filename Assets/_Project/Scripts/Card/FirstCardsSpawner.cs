using System.Collections.Generic;
using UnityEngine;

public class FirstCardsSpawner : MonoBehaviour
{
    public GameObject cardTemplate;
    public Canvas canvas;
    public List<CardDataSO> firstCards;

    void Start()
    {
        foreach (var cardData in firstCards)
        {
            var instance = Instantiate(cardTemplate, transform);
            instance.transform.SetParent(transform);
            instance.GetComponent<DragDrop>().SetupCanvas(canvas);
            instance.GetComponent<CardObject>().CardDataHolderSO = cardData;
        }
    }
}
