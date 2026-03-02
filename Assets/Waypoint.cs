using UnityEngine;
using System.Collections.Generic;

public class Waypoint : MonoBehaviour
{
    [Header("Rute Selanjutnya")]
    [Tooltip("Random Waypoint")]
    public List<Waypoint> nextWaypoints = new List<Waypoint>();

    [Header("Settings")]
    [Range(0, 1)] 
    public float chanceToTakeFirstPath = 0.5f; 

    public Waypoint GetNextWaypoint()
    {
        if (nextWaypoints.Count == 0) return null;

        if (nextWaypoints.Count == 2)
        {
            return (Random.value < chanceToTakeFirstPath) ? nextWaypoints[0] : nextWaypoints[1];
        }

        int randomIndex = Random.Range(0, nextWaypoints.Count);
        return nextWaypoints[randomIndex];
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.2f);

        foreach (Waypoint next in nextWaypoints)
        {
            if (next != null)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(transform.position, next.transform.position);
            }
        }
    }
}