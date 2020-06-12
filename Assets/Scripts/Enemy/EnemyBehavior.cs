using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float maxProximity = 3;
    public float maxDotProduct = 0.5f;
    private GameObject player;
    private List<Collider> colliders;
    void Update()
    {
        if (player == null)
        {
            colliders = GetComponent<EnemyFOV>().GetObjectsInSight();
            foreach (var collider in colliders)
            {
                if (collider.transform.gameObject.tag.Equals("Player"))
                {
                    player = collider.transform.gameObject;
                }
                if (collider.transform.gameObject.tag.Equals("Hazard"))
                {
                    float dotProduct = Vector3.Dot(transform.forward, (collider.transform.position - transform.position).normalized);
                    float distance = Vector3.Distance(transform.position, collider.transform.position);
                    if (dotProduct >= maxDotProduct && distance <= maxProximity)
                    {
                        GetComponent<EnemyMovement>().engageAvoidanceRoutine();
                    }
                }
            }
            if (player != null)
            {
                GetComponent<EnemyMovement>().PlayerFound(player);
            }
        }


    }
}
