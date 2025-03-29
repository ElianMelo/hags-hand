using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody body;
    public float force;

    public void AddForce()
    {
        body.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
