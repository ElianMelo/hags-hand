using UnityEngine;

public class TowerSlot : MonoBehaviour
{
    public GameObject towerObject;

    public bool UseTowerObject()
    {
        if(towerObject.activeSelf)
        {
            return false;
        } else
        {
            towerObject.SetActive(true);
            return true;
        }
    }
}
