using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float maxHealth;
    private float currentHealth;
    private HealthBar healthBar;
    private EnemyFollowTarget enemyFollowTarget;
    private Animator animator;
    private bool isDead = false;
    private EnemyDataSO enemyDataSO;


    private const string DeathAnim = "Death";

    private Coroutine fearCoroutine;

    private void Awake()
    {
        healthBar = GetComponent<HealthBar>();
        animator = GetComponentInChildren<Animator>();
        enemyFollowTarget = GetComponent<EnemyFollowTarget>();
    }

    public void SetupEnemyDataSO(EnemyDataSO enemyDataSO)
    {
        this.enemyDataSO = enemyDataSO;

        maxHealth = enemyDataSO.health;
        currentHealth = maxHealth;
    }

    public float GetDamage()
    {
        return enemyDataSO.damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Projectile"))
        {
            Projectile projectile = other.GetComponent<Projectile>();
            ReceiveDamage(projectile.GetDamage());
            projectile.Death();
        }
    }

    public void ReceiveDamage(float damageAmount)
    {
        if (isDead) return;
        SoundSystemManager.Instance.EnemyHitSFX();
        currentHealth -= damageAmount;
        if(currentHealth <= 0)
        {
            isDead = true;
            gameObject.layer = LayerMask.NameToLayer("Default");
            currentHealth = 0;
            animator.SetTrigger(DeathAnim);
            enemyFollowTarget.StopFollowing();
            InterfaceSystemManager.Instance.AddCoin(enemyDataSO.coinReward);
            InterfaceSystemManager.Instance.AddExperience(enemyDataSO.experience);
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
        if (enemyDataSO.specialEffectResistance == SpecialEffect.Fear) return;
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
