using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    private HealthBar healthBar;
    private EnemyFollowTarget enemyFollowTarget;
    private Animator animator;
    private bool isDead = false;

    private const string DeathAnim = "Death";

    private Coroutine fearCoroutine;

    private void Awake()
    {
        healthBar = GetComponent<HealthBar>();
        animator = GetComponentInChildren<Animator>();
        enemyFollowTarget = GetComponent<EnemyFollowTarget>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
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
