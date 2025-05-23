using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowTarget : MonoBehaviour
{
    private float speed;

    private NavMeshAgent agent;
    private SpriteRenderer spriteRenderer;
    private Transform currentTarget;

    private Transform target;
    private Transform spawn;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void SetupSpeed(float speed)
    {
        this.speed = speed;
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
        if(agent.nextPosition.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        } else
        {
            spriteRenderer.flipX = false;
        }
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
