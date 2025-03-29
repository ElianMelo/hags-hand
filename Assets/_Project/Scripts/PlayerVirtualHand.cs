using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerVirtualHand : MonoBehaviour
{
    public LayerMask towerSlotMask;
    public LayerMask enemiesMask;

    public bool CastTrigger()
    {
        if(CardSystemManager.Instance.CurrentCard.cardType == CardType.Magic)
        {
            return ConsumeCardMagic();
        } else
        {
            return SetupTowerSlot();
        }
        
    }
    public bool ConsumeCardMagic()
    {
        Card card = CardSystemManager.Instance.CurrentCard;
        RaycastHit[] raycastHits = Physics.SphereCastAll(transform.position, 5f, transform.up, 5f, enemiesMask);

        foreach (var hit in raycastHits)
        {
            Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
            enemy.ReceiveDamage(20f);
        }

        return true;
    }

    public bool SetupTowerSlot()
    {
        RaycastHit[] raycastHits = Physics.SphereCastAll(transform.position, 1f, transform.up, 1f, towerSlotMask);

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
