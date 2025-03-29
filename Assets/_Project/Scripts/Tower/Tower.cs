using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject projectile;
    public float range;
    public float attackDelay;
    public float durability;
    public LayerMask mask;
    public GameObject healthCanvas;

    private HealthBar healthBar;
    private float currentDurability;

    private void Start()
    {
        healthBar = GetComponent<HealthBar>();
        currentDurability = durability;
        healthCanvas.SetActive(true);
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        RaycastHit hit = SphereCastEnemy();
        Enemy enemy = hit.collider?.gameObject?.GetComponent<Enemy>();
        if (enemy != null)
        {
            Vector3 direction = enemy.transform.position - transform.position;
            GameObject instance = Instantiate(projectile, transform.position, Quaternion.identity);
            instance.transform.forward = direction;
            currentDurability -= 1f;
            currentDurability = currentDurability <= 0 ? 0 : currentDurability;
            healthBar.UpdateHealthBar(durability, currentDurability);
            if(currentDurability == 0)
            {
                yield break;
            }
        }
        yield return new WaitForSeconds(attackDelay);
        StartCoroutine(AttackCoroutine());
    }

    public RaycastHit SphereCastEnemy()
    {
        RaycastHit[] raycastHits = Physics.SphereCastAll(transform.position, range, transform.up, range, mask);

        if (raycastHits.Length > 0)
        {
            return raycastHits.FirstOrDefault();
        }

        return new RaycastHit();
    }
}
