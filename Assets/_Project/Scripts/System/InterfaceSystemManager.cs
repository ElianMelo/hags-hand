using UnityEngine;

public class InterfaceSystemManager : MonoBehaviour
{
    public static InterfaceSystemManager Instance;

    private StoreCornerController storeCornerController;
    private CucaCornerController cucaCornerController;

    private void Awake()
    {
        Instance = this;
        storeCornerController = GetComponentInChildren<StoreCornerController>();
        cucaCornerController = GetComponentInChildren<CucaCornerController>();
    }

    public void AddCoin(int amount)
    {
        storeCornerController.AddCoin(amount);
    }

    public void AddExperience(int amount)
    {
        cucaCornerController.AddExperience(amount);
    }

    public Rarity GetCardRarity()
    {
        return cucaCornerController.CalculateCurrentPercentage();
    }

}
