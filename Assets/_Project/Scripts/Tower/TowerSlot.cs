using UnityEngine;

public class TowerSlot : MonoBehaviour
{
    private GameObject towerInstance;

    public void FreeTower()
    {
        towerInstance = null;
    }

    public bool UseTowerObject(CardDataSO cardDataSO)
    {
        if(towerInstance == null)
        {
            towerInstance = Instantiate(cardDataSO.towerPrefab.gameObject, transform.position, Quaternion.identity);
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
