using System;
using System.Linq;
using UnityEngine;

public enum MouseReaction
{
    Hold,
    Hover,
    Neutral,
    Release
}

public class PlayerVirtualHand : MonoBehaviour
{
    public LayerMask towerSlotMask;
    public LayerMask enemiesMask;
    public Animator animator;
    public GameObject towerRange;
    public SpriteRenderer towerRangeSpriteRenderer;

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

    public void ShowTowerRange(float range, CardType cardType)
    {
        towerRange.transform.localScale = new Vector3(range, range, range);
        towerRangeSpriteRenderer.color = cardType == CardType.Magic ? Color.blue : Color.red;
        towerRange.SetActive(true);
    }

    public void HideTowerRange()
    {
        towerRange.SetActive(false);
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
            projectile.SetEspecialEffect(cardDataSO.specialEffect);
            projectile.SetSpecialEffectDuration(cardDataSO.specialEffectDuration);
            projectile.SetCanBeDestroyed(false);
            if (cardDataSO.addLeftForce)
            {
                projectile.AddLeftForce();
                Destroy(projectile.gameObject, 10f);
            }
            Destroy(projectile.gameObject, 2f);
            InterfaceSystemManager.Instance.ConsumeCard();
            return true;
        }

        RaycastHit[] raycastHits = Physics.SphereCastAll(transform.position, cardDataSO.range/2, transform.up, cardDataSO.range/2, enemiesMask);

        foreach (var hit in raycastHits)
        {
            Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
            enemy.ReceiveDamage(cardDataSO.damage);
            enemy.ReceiveSpecialEffect(cardDataSO.specialEffect, cardDataSO.specialEffectDuration);
        }

        InterfaceSystemManager.Instance.ConsumeCard();
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
            if(isSlotAvaliable) InterfaceSystemManager.Instance.ConsumeCard();
            return isSlotAvaliable;
        }

        SoundSystemManager.Instance.CardCancel();
        return false;
    }
}
