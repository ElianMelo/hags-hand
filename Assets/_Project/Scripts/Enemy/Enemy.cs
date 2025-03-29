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
            currentHealth -= 1;
            healthBar.UpdateHealthBar(maxHealth, currentHealth);
            Destroy(other.gameObject);
        }
    }
}
