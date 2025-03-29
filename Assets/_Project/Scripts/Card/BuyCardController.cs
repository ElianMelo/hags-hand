using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuyCardController : MonoBehaviour
{
    public List<GameObject> cardsPrefabs = new();
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
        GameObject instance = Instantiate(cardsPrefabs[Random.Range(0, cardsPrefabs.Count)], listCardsGroup.transform);
        instance.transform.SetParent(listCardsGroup.transform);
        instance.GetComponent<DragDrop>().SetupCanvas(canvas);
    }
}
