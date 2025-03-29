using UnityEngine;

public class PlayerVirtualHand : MonoBehaviour
{
    public LayerMask mask;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TowerSlot"))
        {
            CastTrigger();
        }

        if (other.CompareTag("TowerSlot") && CardSystemManager.Instance.IsDragging)
        {
            other.GetComponent<TowerSlot>().UseTowerObject();
            CastTrigger();
        }
    }

    private void CastTrigger()
    {
        RaycastHit hit;

        RaycastHit[] raycastHits = null;

        raycastHits = Physics.SphereCastAll(transform.position, 1f, transform.up, 1f, mask);

        if (raycastHits.Length > 0)
        {
            Debug.Log("Hit");
        }
    }
}
