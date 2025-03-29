using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    private HealthBar healthBar;

    private void Awake()
    {
        healthBar = GetComponent<HealthBar>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Projectile"))
        {
            ReceiveDamage(1);
            Destroy(other.gameObject, 0.5f);
        }
    }

    public void ReceiveDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }
}
