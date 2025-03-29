using System.Linq;
using UnityEngine;

public class PlayerVirtualHand : MonoBehaviour
{
    public LayerMask mask;

    public bool CastTrigger()
    {
        RaycastHit[] raycastHits = Physics.SphereCastAll(transform.position, 1f, transform.up, 1f, mask);

        if (raycastHits.Length > 0)
        {
            var result = raycastHits.FirstOrDefault();
            TowerSlot towerSlot = result.collider.gameObject.GetComponent<TowerSlot>();
            bool isSlotAvaliable = towerSlot.UseTowerObject();
            return isSlotAvaliable;
        }

        return false;
    }
}
