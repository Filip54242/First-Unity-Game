using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    public float FOV;
    private float range;

    void Start()
    {
        range = GetComponent<EnemyShooting>().range;
    }

    public List<Collider> GetObjectsInSight()
    {
        List<Collider> colliders = new List<Collider>();
        foreach (Collider collider in Physics.OverlapSphere(transform.position, range))
        {
            Vector3 target = (collider.transform.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, target) > FOV / 2 && IsInSight(collider))
            {
                colliders.Add(collider);
            }
        }
        colliders.Sort((x, y) =>
            Vector3.Distance(x.transform.position, transform.position).CompareTo(
            Vector3.Distance(y.transform.position, transform.position)));

        return colliders;
    }
    bool IsInSight(Collider collider)
    {
        RaycastHit hit;
        Vector3 direction = collider.transform.position - transform.position;
        if (Physics.Raycast(transform.position, direction, out hit, range))
        {
            if (hit.transform.gameObject.tag.Equals(collider.transform.gameObject.tag))
            {
                return true;
            }
        }
        return false;
    }
}
