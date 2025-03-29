using UnityEngine;

public class TowerSlot : MonoBehaviour
{
    public GameObject towerObject;

    public void UseTowerObject()
    {
        towerObject.SetActive(true);
    }
}
