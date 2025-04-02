using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody body;
    public float force;

    private Collider currentCollider;
    private float damage = 1f;
    private bool canBeDestroyed = true;

    private void Awake()
    {
        currentCollider = GetComponent<Collider>();
    }

    public void SetCanBeDestroyed(bool canBeDestroyed)
    {
        this.canBeDestroyed = canBeDestroyed;
    }

    public void Death()
    {
        if (!canBeDestroyed) return;
        currentCollider.enabled = false;
        body.linearVelocity = Vector3.zero;
        Destroy(gameObject, 0.5f);
    }

    public float GetDamage()
    {
        return damage;
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void AddForce()
    {
        body.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    public void AddLeftForce()
    {
        body.AddForce(transform.right * force * -1, ForceMode.Impulse);
    }
}
