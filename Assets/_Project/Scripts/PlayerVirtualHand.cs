using System;
using System.Linq;
using UnityEngine;

public enum MouseReaction
{
    Regular,
    Browsing,
    Holding,
    Release,
    Click
}

public class PlayerVirtualHand : MonoBehaviour
{
    public LayerMask towerSlotMask;
    public LayerMask enemiesMask;
    public Animator animator;

    private MouseReaction mouseReaction;

    public void SetMouseReaction(MouseReaction mouseReaction)
    {
        this.mouseReaction = mouseReaction;
        SetupMouseVisuals();
    }

    private void SetupMouseVisuals()
    {
        animator.SetTrigger(ConvertToString(mouseReaction));
    }

    private string ConvertToString(MouseReaction mouseReaction)
    {
        return Enum.GetName(mouseReaction.GetType(), mouseReaction);
    }

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

        if(cardDataSO.magicSpawnPrefab)
        {
            var projectileInstance = Instantiate(cardDataSO.projectilePrefab.gameObject, transform.position, Quaternion.identity);
            Projectile projectile = projectileInstance.GetComponent<Projectile>();
            projectile.SetDamage(cardDataSO.damage);
            projectile.SetCanBeDestroyed(false);
            projectile.AddLeftForce();
            Destroy(projectile, 10f);
            return true;
        }

        RaycastHit[] raycastHits = Physics.SphereCastAll(transform.position, cardDataSO.range, transform.up, cardDataSO.range, enemiesMask);

        foreach (var hit in raycastHits)
        {
            Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
            enemy.ReceiveDamage(cardDataSO.damage);
            enemy.ReceiveSpecialEffect(cardDataSO.specialEffect);
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
