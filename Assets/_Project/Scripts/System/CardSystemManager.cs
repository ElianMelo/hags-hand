using UnityEngine;

public class CardSystemManager : MonoBehaviour
{
    public static CardSystemManager Instance;

    public CardDataSO CurrentCardDataSO { get; set; }
    public bool IsDragging { get; set; }

    private void Awake()
    {
        Instance = this;
    }
}
