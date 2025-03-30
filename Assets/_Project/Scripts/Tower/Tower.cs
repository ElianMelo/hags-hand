using System.Collections;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject projectile;
    public GameObject meleeAttack;
    public LayerMask mask;
    public GameObject healthCanvas;
    public Animator animator;

    private HealthBar healthBar;
    private float maxDurability;
    private float currentDurability;
    private TowerSlot slot;
    private CardDataSO card;
    private Vector3 upOffset = new Vector3(0f, 0.5f, 0f);

    private const string AttackAnim = "Attack";

    private void Start()
    {
        healthBar = GetComponent<HealthBar>();
        animator = GetComponentInChildren<Animator>();
        card = CardSystemManager.Instance.CurrentCardDataSO;
        maxDurability = card.durability;
        currentDurability = maxDurability;
        healthCanvas.SetActive(true);
        StartCoroutine(AttackCoroutine());
    }

    public void SetupTowerSlot(TowerSlot towerSlot)
    {
        slot = towerSlot;
    }

    private void Death()
    {
        slot.FreeTower();
        Destroy(gameObject);
    }

    private IEnumerator AttackCoroutine()
    {
        RaycastHit hit = SphereCastEnemy();
        Enemy enemy = hit.collider?.gameObject?.GetComponent<Enemy>();
        if (enemy != null)
        {
            CreateAttack(enemy.transform.position);
            currentDurability -= 1f;
            currentDurability = currentDurability <= 0 ? 0 : currentDurability;
            healthBar.UpdateHealthBar(maxDurability, currentDurability);
            if(currentDurability == 0)
            {
                Death();
                yield break;
            }
        }
        yield return new WaitForSeconds(card.attackSpeed);
        StartCoroutine(AttackCoroutine());
    }

    private void CreateAttack(Vector3 enemyPosition)
    {
        animator.SetTrigger(AttackAnim);
        if (card.cardType == CardType.Ranged)
        {
            Vector3 direction = enemyPosition - transform.position;
            GameObject instance = Instantiate(projectile, transform.position + upOffset, Quaternion.identity);
            instance.transform.forward = direction;
            Projectile currentProjectile = instance.GetComponent<Projectile>();
            currentProjectile.AddForce();
        } else
        {
            Instantiate(meleeAttack, enemyPosition + upOffset, Quaternion.identity);
        }
    }

    public RaycastHit SphereCastEnemy()
    {
        RaycastHit[] raycastHits = Physics.SphereCastAll(transform.position, card.range, transform.up, card.range, mask);

        if (raycastHits.Length > 0)
        {
            return raycastHits.FirstOrDefault();
        }

        return new RaycastHit();
    }
}
