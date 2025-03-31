using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody body;
    public float force;

    private float damage = 1f;

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
