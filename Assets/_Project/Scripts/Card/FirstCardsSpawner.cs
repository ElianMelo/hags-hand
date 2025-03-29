using System.Collections.Generic;
using UnityEngine;

public class FirstCardsSpawner : MonoBehaviour
{
    public List<GameObject> firstCards;
    public Canvas canvas;

    void Start()
    {
        foreach (var item in firstCards)
        {
            var instance = Instantiate(item, transform);
            instance.transform.SetParent(transform);
            instance.GetComponent<DragDrop>().SetupCanvas(canvas);
        }
    }
}
