using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float maxHealth;
    private float currentHealth;
    private int coinAmount;
    private HealthBar healthBar;
    private EnemyFollowTarget enemyFollowTarget;
    private Animator animator;
    private bool isDead = false;
    private SpecialEffect resistance;

    private const string DeathAnim = "Death";

    private Coroutine fearCoroutine;

    private void Awake()
    {
        healthBar = GetComponent<HealthBar>();
        animator = GetComponentInChildren<Animator>();
        enemyFollowTarget = GetComponent<EnemyFollowTarget>();
    }

    public void SetupResistance(SpecialEffect resistance)
    {
        this.resistance = resistance;
    }

    public void SetupHealth(float health)
    {
        currentHealth = health;
        currentHealth = maxHealth;
    }

    public void SetupCoinAmount(int amount)
    {
        coinAmount = amount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Projectile"))
        {
            var damage = other.GetComponent<Projectile>().GetDamage();
            ReceiveDamage(damage);
            Destroy(other.gameObject, 0.5f);
        }
    }

    public void ReceiveDamage(float damageAmount)
    {
        if (isDead) return;
        currentHealth -= damageAmount;
        if(currentHealth <= 0)
        {
            isDead = true;
            currentHealth = 0;
            animator.SetTrigger(DeathAnim);
            enemyFollowTarget.StopFollowing();
            InterfaceSystemManager.Instance.AddCoin(coinAmount);
            Destroy(gameObject, 1f);
        }
        healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }

    public void ReceiveSpecialEffect(SpecialEffect specialEffect)
    {
        if (isDead) return;
        switch (specialEffect)
        {
            case SpecialEffect.None: return;
            case SpecialEffect.Fear: ReceiveFear(); return;
            default: return;
        }
    }

    public void ReceiveFear()
    {
        if (resistance == SpecialEffect.Fear) return;
        if (fearCoroutine != null) StopCoroutine(fearCoroutine);
        fearCoroutine = StartCoroutine(ReceiveFearCoroutine());
    }

    private IEnumerator ReceiveFearCoroutine()
    {
        enemyFollowTarget.TargetSpawn();
        yield return new WaitForSeconds(CardSystemManager.Instance.CurrentCardDataSO.specialEffectDuration);
        enemyFollowTarget.TargetTheTarget();
    }
}
