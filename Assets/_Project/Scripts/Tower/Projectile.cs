using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody body;
    public float force;

    private Collider currentCollider;
    private float damage = 1f;

    private void Awake()
    {
        currentCollider = GetComponent<Collider>();
    }

    public void Death()
    {
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
}
