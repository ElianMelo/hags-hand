using System.Collections;
using System.Linq;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody body;
    public float force;

    private Collider currentCollider;
    private float damage = 1f;
    private bool canBeDestroyed = true;
    public bool isMelee = false;
    public GameObject explosion;

    [HideInInspector] public bool earlyReturn = false;

    private SpecialEffect specialEffect;
    private float specialEffectDuration;

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
        if (earlyReturn)
        {
            currentCollider.enabled = false;
            return;
        }
        if (!canBeDestroyed) return;
        // if(!isMelee) currentCollider.enabled = false;
        body.linearVelocity = Vector3.zero;
        if (explosion != null)
        {
            GameObject instance = Instantiate(explosion, transform.position, Quaternion.identity);
            instance.GetComponent<Projectile>().earlyReturn = true;
            Destroy(instance, 1f);
        }
        Destroy(gameObject, 0.1f);
    }

    public float GetDamage()
    {
        return damage;
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void SetEspecialEffect(SpecialEffect specialEffect)
    {
        this.specialEffect = specialEffect;
    }

    public SpecialEffect GetSpecialEffect()
    {
        return specialEffect;
    }

    public void SetSpecialEffectDuration(float specialEffectDuration)
    {
        this.specialEffectDuration = specialEffectDuration;
    }

    public float GetSpecialEffectDuration()
    {
        return specialEffectDuration;
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
