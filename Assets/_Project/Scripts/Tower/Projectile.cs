using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody body;
    public float force;

    void Start()
    {
        body.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
