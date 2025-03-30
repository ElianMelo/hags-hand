using UnityEngine;

public class CardObject : MonoBehaviour
{
    public CardDataSO cardDataHolderSO {
        get => cardDataHolderSO;
        set
        {
            cardDataHolderSO = value;
            SetupCardData();
        }
    }

    public void SetupCardData()
    {

    }
}
