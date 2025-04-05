using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            InterfaceSystemManager.Instance.WaveDamage(enemy.GetDamage());
            Destroy(enemy.gameObject);
        }
    }
}
