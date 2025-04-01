using UnityEngine;

public class InterfaceSystemManager : MonoBehaviour
{
    public static InterfaceSystemManager Instance;

    private StoreCornerController storeCornerController;

    private void Awake()
    {
        Instance = this;
        storeCornerController = GetComponentInChildren<StoreCornerController>();
    }

    public void AddCoin(int amount)
    {
        storeCornerController.AddCoin(amount);
    }

}
