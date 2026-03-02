using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Waypoint currentWaypoint;
    private NavMeshAgent agent;
    private bool hasReachedEnd = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (currentWaypoint != null)
        {
            MoveToTarget(currentWaypoint.transform.position);
        }
    }

    void Update()
    {
        if (hasReachedEnd) return;

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance + 0.1f)
        {
            FindNextTarget();
        }
    }

    void FindNextTarget()
    {
        Waypoint next = currentWaypoint.GetNextWaypoint();

        if (next != null)
        {
            currentWaypoint = next;
            MoveToTarget(currentWaypoint.transform.position);
        }
        else
        {
            OnReachedBase();
        }
    }

    void MoveToTarget(Vector3 targetPos)
    {
        agent.SetDestination(targetPos);
    }

    void OnReachedBase()
    {
        hasReachedEnd = true;
        Debug.Log("Done");
        Destroy(gameObject, 0.5f); 
    }
}