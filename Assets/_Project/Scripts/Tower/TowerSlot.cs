using UnityEngine;

public class TowerSlot : MonoBehaviour
{
    public GameObject towerPrefab;

    private GameObject towerInstance;

    public void FreeTower()
    {
        towerInstance = null;
    }

    public bool UseTowerObject()
    {
        if(towerInstance == null)
        {
            towerInstance = Instantiate(towerPrefab, transform.position, Quaternion.identity);
            Tower tower = towerInstance.GetComponent<Tower>();
            tower.transform.parent = transform;
            tower.SetupTowerSlot(this);
            return true;
        } else
        {
            return false;
        }
    }
}
