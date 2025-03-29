using System.Collections;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject projectile;
    public float range;
    public float attackDelay;
    public LayerMask mask;

    private void Start()
    {
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
