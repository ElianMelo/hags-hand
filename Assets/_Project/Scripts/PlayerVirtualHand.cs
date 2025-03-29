using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerVirtualHand : MonoBehaviour
{
    public LayerMask towerSlotMask;
    public LayerMask enemiesMask;

    public bool CastTrigger()
    {
        if(CardSystemManager.Instance.CurrentCardDataSO.cardType == CardType.Magic)
        {
            return ConsumeCardMagic();
        } else
        {
            return SetupTowerSlot();
        }
        
    }
    public bool ConsumeCardMagic()
    {
        CardDataSO cardDataSO = CardSystemManager.Instance.CurrentCardDataSO;
        RaycastHit[] raycastHits = Physics.SphereCastAll(transform.position, cardDataSO.range, transform.up, cardDataSO.range, enemiesMask);

        foreach (var hit in raycastHits)
        {
            Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
            enemy.ReceiveDamage(cardDataSO.damage);
        }

        return true;
    }

    public bool SetupTowerSlot()
    {
        CardDataSO cardDataSO = CardSystemManager.Instance.CurrentCardDataSO;
        RaycastHit[] raycastHits = Physics.SphereCastAll(transform.position, 1f, transform.up, 1f, towerSlotMask);

        if (raycastHits.Length > 0)
        {
            var result = raycastHits.FirstOrDefault();
            TowerSlot towerSlot = result.collider.gameObject.GetComponent<TowerSlot>();
            bool isSlotAvaliable = towerSlot.UseTowerObject(cardDataSO);
            return isSlotAvaliable;
        }

        return false;
    }
}
