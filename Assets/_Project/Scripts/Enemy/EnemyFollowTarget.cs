using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowTarget : MonoBehaviour
{
    public Transform target;
    public float speed;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.destination = target.transform.position;
        agent.angularSpeed = 0f;
        agent.speed = speed;
    }
}
