using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowTarget : MonoBehaviour
{
    public Transform target;
    public Transform spawn;
    public float speed;

    private NavMeshAgent agent;
    private Transform currentTarget;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentTarget = target;
    }

    void Update()
    {
        agent.destination = currentTarget.transform.position;
        agent.angularSpeed = 0f;
        agent.speed = speed;
    }

    public void TargetSpawn()
    {
        currentTarget = spawn;
    }

    public void TargetTheTarget()
    {
        currentTarget = target;
    }
}
