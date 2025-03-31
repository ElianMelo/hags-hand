using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowTarget : MonoBehaviour
{
    // todo: scriptable
    public float speed;

    private NavMeshAgent agent;
    private Transform currentTarget;

    private Transform target;
    private Transform spawn;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetupTargets(Transform target, Transform spawn)
    {
        this.target = target;
        this.spawn = spawn;
        currentTarget = target;
    }

    void Update()
    {
        if (currentTarget == null) return;
        agent.destination = currentTarget.transform.position;
        agent.angularSpeed = 0f;
        agent.speed = speed;
    }

    public void StopFollowing()
    {
        currentTarget = transform;
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
